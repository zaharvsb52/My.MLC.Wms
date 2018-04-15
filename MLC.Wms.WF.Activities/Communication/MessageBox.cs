using System;
using System.Activities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using MLC.WF.Activities;
using MLC.WF.Core;
using MLC.WF.Core.Client.Protocol;
using MLC.WF.Core.Extensions;
using MLC.WF.Core.Models;
using WebClient.Common.Metamodel.Bindings;

namespace MLC.Wms.WF.Activities.Communication
{
    public class MessageBox : NativeActivity
    {
        #region .  Properties  .
        /// <summary>
        /// Заголовок сообщения
        /// </summary>
        [RequiredArgument]
        public InArgument<string> Title { get; set; }

        /// <summary>
        /// Текст сообщения
        /// </summary>
        [RequiredArgument]
        public InArgument<string> Message { get; set; }

        /// <summary>
        /// Команда-результат
        /// </summary>
        [RequiredArgument]
        public OutArgument<string> ActionCode { get; set; }

        /// <summary>
        /// Кнопки
        /// </summary>
        [DefaultValue(null)]
        public InArgument<WfActionsModel> Actions { get; set; }

        #endregion

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            var collection = new Collection<RuntimeArgument>();

            ActivityHelper.AddCacheMetadata(collection, metadata, Title, "Title");
            ActivityHelper.AddCacheMetadata(collection, metadata, Message, "Message");
            ActivityHelper.AddCacheMetadata(collection, metadata, Actions, "Actions");
            ActivityHelper.AddCacheMetadata(collection, metadata, ActionCode, "ActionCode");

            metadata.SetArgumentsCollection(collection);
        }

        protected override void Execute(NativeActivityContext context)
        {
            const string viewKind = JsWfViewKind.Dialog;
            // check bookmark name
            var bookmarkName = Guid.NewGuid().ToString();
            var message = Message.Get(context);
            var title = Title.Get(context);
            var actions = Actions.Get(context) ?? new WfActionsModel() { new WfAction() { Code = "OK", Text = "OK" } };

            var data = new WfDataModel()
            {
                {
                    "MessageBoxStruct",
                    new List<WfDataObject>()
                    {
                        new WfDataObject
                        {
                            {"Message", message}
                        }
                    }
                }
            };
            var model = new WfMetadataModel
            {
                ControllerConfig = new SerializableDictionary<string, string> { { "message", message } },
                ViewConfig = new SerializableDictionary<string, object> { { "title", title } },
                KeyMap = new List<WfKeyMap>
                {
                    new WfKeyMap
                    {
                        ActionCode = actions[0].Code,
                        Key = 13
                    }
                },
                Structures = new List<WfStructure>()
                {
                    new WfStructure
                    {
                        Name = "MessageBoxStruct",
                        FieldBindings = new List<IFieldBinding>()
                        {
                            new WfFieldBinding()
                            {
                                FieldName = "Message",
                                EditorLabel = "Сообщение",
                                Visible = true,
                                ReadOnly = true
                            }
                        }
                    }
                }
            };

            Console.WriteLine("Execute bookmark '{0}'", bookmarkName);

            SyncWorkflowDataExtension.TryProcess(context, bookmarkName);

            // заполняем ответ сервису
            var protExt = context.GetExtension<ProtocolExtension>();
            if (protExt != null)
                protExt.FillResponse(context, bookmarkName, model, data, actions, viewKind);

            // sleep
            context.CreateBookmark(bookmarkName, OnResumeBookmark);
        }

        protected override bool CanInduceIdle
        {
            get { return true; }
        }

        private void OnResumeBookmark(NativeActivityContext context, Bookmark bookmark, object obj)
        {
            SyncWorkflowDataExtension.Resume(context, bookmark, obj);

            // заполняем ответ сервису
            var protExt = context.GetExtension<ProtocolExtension>();
            if (protExt != null)
            {
                var actionCode = protExt.GetRequestActionCode();
                ActionCode.Set(context, actionCode);
            }
        }
    }
}