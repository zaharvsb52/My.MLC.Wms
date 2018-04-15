using System.Collections;
using System.Collections.Specialized;
using System.Configuration.Fakes;
using System.DirectoryServices;
using System.DirectoryServices.Fakes;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using FluentAssertions;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MLC.Wms.Bootstrap.Services.Impl;
using MLC.Wms.Common.Environment.Impl;
using MLC.Wms.Model.Entities;
using Moq;
using NHibernate;
using NHibernate.Linq.Fakes;

namespace MLC.Wms.Model.Tests
{
    [TestClass]
    public class AuthServiceTest
    {
        [TestMethod]
        public void When_user_not_exist_in_db_then_auth_is_invalid()
        {
            var user = new WmsUser
            {
                Login = "Login",
                UserPassword = "Password"
            };

            var factory = GetSessionFactoryMock();

            using (ShimsContext.Create())
            {
                ShimLinqExtensionMethods.QueryOf1ISession(s => new[] { user }.AsQueryable());
                string userName;

                var authService = new AuthService(factory.Object, new SvcWmsEnvironmentInfoProvider());
                var res = authService.Authenticate("1", "1", out userName);
                res.Should().BeFalse();
            }
        }

        [TestMethod]
        public void When_user_exist_in_db_user_is_locked_then_auth_is_invalid()
        {
            var user = new WmsUser
            {
                Login = "Login",
                UserPassword = "Password",
                UserLocked = true
            };

            var factory = GetSessionFactoryMock();

            using (ShimsContext.Create())
            {
                ShimLinqExtensionMethods.QueryOf1ISession(s => new[] { user }.AsQueryable());
                string userName;

                var authService = new AuthService(factory.Object, new SvcWmsEnvironmentInfoProvider());
                var res = authService.Authenticate(user.Login, user.UserPassword, out userName);
                res.Should().BeFalse();
            }
        }

        [TestMethod]
        public void When_user_exist_in_db_user_is_not_locked_basic_auth_then_auth_is_invalid()
        {
            var user = new WmsUser
            {
                Login = "Login",
                UserPassword = "Password",
                UserLocked = false,
                UserAuthentication = false
            };

            var factory = GetSessionFactoryMock();

            using (ShimsContext.Create())
            {
                ShimLinqExtensionMethods.QueryOf1ISession(s => new[] { user }.AsQueryable());
                string userName;

                var authService = new AuthService(factory.Object, new SvcWmsEnvironmentInfoProvider());
                var res = authService.Authenticate(user.Login, "1", out userName);
                res.Should().BeFalse();

                res = authService.Authenticate("1", user.UserPassword, out userName);
                res.Should().BeFalse();

                res = authService.Authenticate("5", "6", out userName );
                res.Should().BeFalse();
            }
        }

        [TestMethod]
        public void When_user_exist_in_db_user_is_not_locked_basic_auth_then_auth_is_valid()
        {
            var user = new WmsUser
            {
                Login = "Login",
                UserPassword = "Password",
                UserLocked = false,
                UserAuthentication = false
            };

            var factory = GetSessionFactoryMock();

            using (ShimsContext.Create())
            {
                ShimLinqExtensionMethods.QueryOf1ISession(s => new[] { user }.AsQueryable());
                string userName;

                var authService = new AuthService(factory.Object, new SvcWmsEnvironmentInfoProvider());
                var res = authService.Authenticate(user.Login, user.UserPassword, out userName);
                res.Should().BeTrue();
            }
        }

        [TestMethod]
        public void When_user_exist_in_db_user_is_not_locked_ad_auth_then_auth_is_invalid()
        {
            var user = new WmsUser
            {
                Login = "Login",
                UserPassword = null,
                UserLocked = false,
                UserAuthentication = true
            };

            var factory = GetSessionFactoryMock();

            using (ShimsContext.Create())
            {
                ShimLinqExtensionMethods.QueryOf1ISession(s => new[] { user }.AsQueryable());

                ShimConfigurationManager.AppSettingsGet = () =>
                {
                    var nameValueCollection = new NameValueCollection
                    {
                        {"AdPath", "AD"}
                    };
                    return nameValueCollection;
                };

                ShimDirectorySearcher.ConstructorDirectoryEntryString = (@this, dentry, filter) =>
                {
                    var dirSearcher = new ShimDirectorySearcher(@this)
                    {
                        FindOne = () => null
                    };
                };

                string userName;
                var authService = new AuthService(factory.Object, new SvcWmsEnvironmentInfoProvider());
                var res = authService.Authenticate(user.Login, user.UserPassword, out userName);
                res.Should().BeFalse();
            }
        }

        [TestMethod]
        public void When_user_exist_in_db_user_is_not_locked_ad_auth_then_auth_is_valid()
        {
            var user = new WmsUser
            {
                Login = "Login",
                UserPassword = "Password",
                UserLocked = false,
                UserAuthentication = true
            };

            var factory = GetSessionFactoryMock();

            using (ShimsContext.Create())
            {
                ShimLinqExtensionMethods.QueryOf1ISession(s => new[] { user }.AsQueryable());

                ShimConfigurationManager.AppSettingsGet = () =>
                {
                    var nameValueCollection = new NameValueCollection
                    {
                        {"AdPath", "AD"}
                    };
                    return nameValueCollection;
                };

                ShimDirectorySearcher.ConstructorDirectoryEntryString = (@this, dentry, filter) =>
                {
                    var dirSearcher = new ShimDirectorySearcher(@this)
                    {
                        FindOne = () => SearchResultFactory.Construct(new
                        {
                            name = "testUser"
                        })
                    };
                };

                string userName;

                var authService = new AuthService(factory.Object, new SvcWmsEnvironmentInfoProvider());
                var res = authService.Authenticate(user.Login, user.UserPassword, out userName);
                res.Should().BeTrue();
            }
        }

        private Mock<ISessionFactory> GetSessionFactoryMock()
        {
            var session = new Mock<ISession>(MockBehavior.Strict);
            session.Setup(i => i.Dispose());
            var sessionFactory = new Mock<ISessionFactory>();
            sessionFactory.Setup(i => i.OpenSession()).Returns(session.Object);
            sessionFactory.Setup(i => i.Dispose());
            return sessionFactory;
        }

        //http://stackoverflow.com/questions/2069106/how-to-mock-system-directoryservices-searchresult
        private static class SearchResultFactory
        {
            private const BindingFlags NonPublicInstance = BindingFlags.NonPublic | BindingFlags.Instance;
            private const BindingFlags PublicInstance = BindingFlags.Public | BindingFlags.Instance;

            public static SearchResult Construct<T>(T anonInstance)
            {
                var searchResult = GetUninitializedObject<SearchResult>();
                SetPropertiesFieled(searchResult);
                var dictionary = (IDictionary)searchResult.Properties;
                var type = typeof(T);
                var propertyInfos = type.GetProperties(PublicInstance);
                foreach (var propertyInfo in propertyInfos)
                {
                    var value = propertyInfo.GetValue(anonInstance, null);
                    var propertyCollection = GetUninitializedObject<ResultPropertyValueCollection>();
                    var innerList = GetInnerList(propertyCollection);
                    innerList.Add(value);
                    var lowerKey = propertyInfo.Name.ToLower(CultureInfo.InvariantCulture);
                    dictionary.Add(lowerKey, propertyCollection);
                }
                return searchResult;
            }

            private static ArrayList GetInnerList(object resultPropertyCollection)
            {
                var propertyInfo = typeof(ResultPropertyValueCollection).GetProperty("InnerList", NonPublicInstance);
                return (ArrayList)propertyInfo.GetValue(resultPropertyCollection, null);
            }

            private static void SetPropertiesFieled(SearchResult searchResult)
            {
                var propertiesFiled = typeof(SearchResult).GetField("properties", NonPublicInstance);
                if (propertiesFiled != null)
                    propertiesFiled.SetValue(searchResult, GetUninitializedObject<ResultPropertyCollection>());
            }

            private static T GetUninitializedObject<T>()
            {
                return (T)FormatterServices.GetUninitializedObject(typeof(T));
            }
        }
    }
}
