using System;
using System.Linq;
using System.Text;
using FluentAssertions;
using MLC.Wms.Bootstrap;
using MLC.Wms.Integration.v1;
using MLC.Wms.Integration.v1.Messages;
using NHibernate;
using NUnit.Framework;
using Microsoft.Practices.Unity;
using MLC.Wms.Common;
using MLC.Wms.Common.Environment;
using MLC.Wms.Common.Environment.Impl;
using MLC.Wms.Common.LocalStorage;
using MLC.Wms.Model.Entities;
using NHibernate.Linq;

namespace MLC.Wms.Integration.Tests
{
    [TestFixture]
    public class QueueServiceTests
    {
        [Test]
        public void EnqueueTest()
        {
            UnityConfig.RegisterComponents(container =>
            {
                var svc = container.Resolve<QueueService>();
                var factory = container.Resolve<ISessionFactory>();

                container.RegisterType<IWmsEnvironmentInfoProvider, SvcWmsEnvironmentInfoProvider>(new ContainerControlledLifetimeManager());
                container.RegisterType<ILocalData, ThreadStaticLocalData>(new ContainerControlledLifetimeManager());
                WmsEnvironment.Init(container.Resolve<IWmsEnvironmentInfoProvider>(), container.Resolve<ILocalData>());

                var request = new EnqueueListRequest();
                request.PartnerCode = "TST";
                request.MessageList = new[]
                {
                    new QueueMessage
                    {
                        Data = "test data",
                        QueueMessageTypeCode = "TST"
                    }
                };

                var response = svc.EnqueueListIn(request);
                response.MessageList.Should().HaveCount(1);
                response.MessageList[0].ID.Should().HaveValue();
                response.MessageList[0].QueueMessageTypeCode.ShouldBeEquivalentTo(request.MessageList[0].QueueMessageTypeCode);
                response.MessageList[0].Data.ShouldBeEquivalentTo(request.MessageList[0].Data);

                using (var session = factory.OpenSession())
                using (var transaction = session.BeginTransaction())
                {
                    foreach (var message in response.MessageList)
                    {
                        var item = session.Get<IoQueueIn>(message.ID);
                        //TODO: проверка, что записалось правильно

                        // удалеям лишнее
                        session.Delete(item);
                    }
                    transaction.Commit();
                }
            });
        }

        [Test]
        public void DequeueTest()
        {
            UnityConfig.RegisterComponents(container =>
            {
                var svc = container.Resolve<QueueService>();
                var factory = container.Resolve<ISessionFactory>();

                container.RegisterType<IWmsEnvironmentInfoProvider, SvcWmsEnvironmentInfoProvider>(new ContainerControlledLifetimeManager());
                container.RegisterType<ILocalData, ThreadStaticLocalData>(new ContainerControlledLifetimeManager());
                WmsEnvironment.Init(container.Resolve<IWmsEnvironmentInfoProvider>(), container.Resolve<ILocalData>());
                
                // пишем тестовое сообщение
                var outMessage = new IoQueueOut();
                using (var session = factory.OpenSession())
                using (var transaction = session.BeginTransaction())
                {
                    outMessage.Mandant = session.Query<WmsMandant>().Single(i => i.PartnerCode == "TST");
                    outMessage.Data = Encoding.UTF8.GetBytes("test data");
                    outMessage.GroupCode = Guid.NewGuid();
                    outMessage.QueueMessageState = QueueMessageStates.Ready;
                    outMessage.QueueMessageType = session.Query<IoQueueMessageType>().Single(i => i.Code == "TST");
                    outMessage.Selector = "test selector";
                    outMessage.Uri = "test uri";

                    session.Save(outMessage);
                    transaction.Commit();
                }

                // создаем запрос
                var request = new DequeueRequest();
                request.EnablePratnersCodes = "TST";
                request.EnableTypes = "TST";
                request.RequiresConfirmation = false;

                // запрашиваем
                var response = svc.DequeueOut(request);

                // проверяем ответ
                response.PartnerCode.ShouldBeEquivalentTo("TST");
                response.MessageType = "TST";
                response.Message.Should().NotBeNull();
                response.Message.ID.Should().Be(outMessage.ID);
                response.Message.Data.Should().Be("test data");
                response.Message.QueueMessageTypeCode.Should().Be("TST");
                response.Message.GroupCode.Should().Be(outMessage.GroupCode);
                //response.Message.ID

                using (var session = factory.OpenSession())
                using (var transaction = session.BeginTransaction())
                {
                    var item = session.Get<IoQueueOut>(outMessage.ID);
                    session.Delete(item);
                    transaction.Commit();
                }
            });
        }

        [Test]
        public void DequeueListOutTest()
        {
            var messageCount = 2;

            UnityConfig.RegisterComponents(container =>
            {
                container.RegisterType<IWmsEnvironmentInfoProvider, SvcWmsEnvironmentInfoProvider>(
                    new ContainerControlledLifetimeManager());
                container.RegisterType<ILocalData, ThreadStaticLocalData>(new ContainerControlledLifetimeManager());
                WmsEnvironment.Init(container.Resolve<IWmsEnvironmentInfoProvider>(),
                    container.Resolve<ILocalData>());
                
                var factory = container.Resolve<ISessionFactory>();
                var svc = container.Resolve<QueueService>();

                using (var session = factory.OpenSession())
                {
                    var request = new DequeueListRequest
                    {
                        MessagesCount = messageCount,
                        RequiresConfirmation = true,
                        EnableTypes = "ORDER_RESERVE",
                        Selector = "ROUTE=OMS"
                    };

                    var testResult = svc.DequeueListOut(request);
                    testResult.Should().NotBeNull();
                    testResult.Items.Should().NotBeNull();
                    testResult.Items.Count().ShouldBeEquivalentTo(messageCount);
                }
            });
        }
    }
}
