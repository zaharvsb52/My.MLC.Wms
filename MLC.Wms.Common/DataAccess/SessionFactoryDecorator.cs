using System;
using System.Collections.Generic;
using System.Data;
using MLC.Wms.Common.DataAccess.Impl;
using NHibernate;
using NHibernate.Engine;
using NHibernate.Metadata;
using NHibernate.Stat;

namespace MLC.Wms.Common.DataAccess
{
    public class SessionFactoryDecorator : ISessionFactory
    {
        private readonly ISessionFactory _factory;

        public SessionFactoryDecorator(ISessionFactory factory)
        {
            _factory = factory;

            Interceptor = new EnvironmentSignSessionInterceptor();
        }

        public ISession ExternalSession { get; set; }

        public IInterceptor Interceptor { get; set; }

        public void Dispose()
        {
            _factory.Dispose();
        }

        public ISession OpenSession(IDbConnection conn)
        {
            return OpenSessionInternal(conn);
        }

        public ISession OpenSession(IInterceptor sessionLocalInterceptor)
        {
            return OpenSessionInternal(null, sessionLocalInterceptor);
        }

        public ISession OpenSession(IDbConnection conn, IInterceptor sessionLocalInterceptor)
        {
            return OpenSessionInternal(conn, sessionLocalInterceptor);
        }

        public ISession OpenSession()
        {
            return OpenSessionInternal();
        }

        private ISession OpenSessionInternal(IDbConnection conn = null, IInterceptor sessionLocalInterceptor = null)
        {
            if (ExternalSession != null)
                return ExternalSession;

            return conn != null
                ? _factory.OpenSession(conn, sessionLocalInterceptor ?? Interceptor)
                : _factory.OpenSession(sessionLocalInterceptor ?? Interceptor);
        }

        public IClassMetadata GetClassMetadata(Type persistentClass)
        {
            return _factory.GetClassMetadata(persistentClass);
        }

        public IClassMetadata GetClassMetadata(string entityName)
        {
            return _factory.GetClassMetadata(entityName);
        }

        public ICollectionMetadata GetCollectionMetadata(string roleName)
        {
            return _factory.GetCollectionMetadata(roleName);
        }

        public IDictionary<string, IClassMetadata> GetAllClassMetadata()
        {
            return _factory.GetAllClassMetadata();
        }

        public IDictionary<string, ICollectionMetadata> GetAllCollectionMetadata()
        {
            return _factory.GetAllCollectionMetadata();
        }

        public void Close()
        {
            _factory.Close();
        }

        public void Evict(Type persistentClass)
        {
            _factory.Evict(persistentClass);
        }

        public void Evict(Type persistentClass, object id)
        {
            _factory.Evict(persistentClass, id);
        }

        public void EvictEntity(string entityName)
        {
            _factory.EvictEntity(entityName);
        }

        public void EvictEntity(string entityName, object id)
        {
            _factory.EvictEntity(entityName, id);
        }

        public void EvictCollection(string roleName)
        {
            _factory.EvictCollection(roleName);
        }

        public void EvictCollection(string roleName, object id)
        {
            _factory.EvictCollection(roleName, id);
        }

        public void EvictQueries()
        {
            _factory.EvictQueries();
        }

        public void EvictQueries(string cacheRegion)
        {
            _factory.EvictQueries(cacheRegion);
        }

        public IStatelessSession OpenStatelessSession()
        {
            return _factory.OpenStatelessSession();
        }

        public IStatelessSession OpenStatelessSession(IDbConnection connection)
        {
            return _factory.OpenStatelessSession(connection);
        }

        public FilterDefinition GetFilterDefinition(string filterName)
        {
            return _factory.GetFilterDefinition(filterName);
        }

        public ISession GetCurrentSession()
        {
            return _factory.GetCurrentSession();
        }

        public IStatistics Statistics
        {
            get { return _factory.Statistics; }
        }

        public bool IsClosed
        {
            get { return _factory.IsClosed; }
        }

        public ICollection<string> DefinedFilterNames
        {
            get { return _factory.DefinedFilterNames; }
        }
    }
}