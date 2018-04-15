using System;
using System.Activities;
using System.Activities.Presentation;
using System.Activities.Presentation.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using MLC.Wms.WF.Activities.Business;

namespace MLC.Wms.WF.Activities.Designer
{
    public partial class ExecuteWmsApiDesigner
    {
        #region .  Consts & Fields  .
        public const string ResultParamName = "result";
        private ParameterInfo[] _methodParameters;
        private MethodInfo _methodInfo;
        private MethodInfo[] _methods;
        private bool _initializing;
        #endregion .  Consts & Fields  .

        public ExecuteWmsApiDesigner()
        {
            _initializing = true;
            Items = new ObservableCollection<NameValueObject>();
            InitializeComponent();
        }

        #region .  Properties  .
        public ObservableCollection<NameValueObject> Items { get; private set; }
        #endregion .  Properties  .

        //public static void RegisterMetadata(AttributeTableBuilder builder)
        //{
        //    builder.AddCustomAttributes(typeof(ExecuteWmsApi), new DesignerAttribute(typeof(ExecuteWmsApiDesigner)));
        //}

        #region .  Methods  .

        protected override void OnModelItemChanged(object newItem)
        {
            base.OnModelItemChanged(newItem);

            if (ModelItem == null)
                return;

            _methods = GetMethods();
            FillItems();
            UpdateParameters();

            // обновляем выбранное значение из Combobox
            var expression = BindingOperations.GetBindingExpression(CbProperties, Selector.SelectedValueProperty);
            if (expression != null)
                expression.UpdateTarget();
        }

        private MethodInfo[] GetMethods()
        {
            var methodActivity = ModelItem.GetCurrentValue() as IMethodContainer;
            if (methodActivity == null)
                throw new Exception("Can't use ExecuteProcedureActivityDesigner with non IMethodContainer implementator.");

            // получаем доступные методы
            return methodActivity.GetMethods();
        }

        private void FillItems()
        {
            Items.Clear();
            var tempInfos = new List<NameValueObject>();
            foreach (var method in _methods)
            {
                var displayName = method.Name;
                //var displayNameAtt = method.GetOneCustomAttributes<DisplayNameAttribute>();
                //if (displayNameAtt != null)
                //    displayName = displayNameAtt.DisplayName;

                tempInfos.Add(new NameValueObject { Value = method.Name, DisplayName = displayName, Name = method.Name });
            }

            foreach (var ordmethod in tempInfos.OrderBy(i => i.DisplayName))
            {

                Items.Add(new NameValueObject { Value = ordmethod.Name, DisplayName = ordmethod.DisplayName, Name = ordmethod.Name });
            }
        }

        private void UpdateParameters()
        {
            // получаем имя метода
            var propertyValue = ModelItem.Properties["Value"];
            if (propertyValue == null || propertyValue.Value == null)
                return;

            var argument = (InArgument<string>)propertyValue.Value.GetCurrentValue();
            if (argument == null)
                return;

            //Gleb
            //var methodName = argument.Expression.ToString();
            //var value = argument.Expression as VisualBasicValue<string>;
            //if (value != null)
            //    methodName = value.ExpressionText.Replace("\"", string.Empty);
            //if (string.IsNullOrEmpty(methodName))
            //    return;

            //_methodInfo = _methods.FirstOrDefault(i => i.Name == methodName);
            //if (_methodInfo == null)
            //    throw new Exception("Can't find method by name " + methodName);
            //var parameters = new List<ParameterInfo>();
            //parameters.AddRange(_methodInfo.GetParameters());
            //if (_methodInfo.ReturnType != typeof(void))
            //    parameters.Add(_methodInfo.ReturnParameter);
            //_methodParameters = parameters.ToArray();
        }

        private ModelItemDictionary GetParametersProperty()
        {
            var paramProperty = ModelItem.Properties["Parameters"];
            if (paramProperty == null || paramProperty.Dictionary == null)
                throw new Exception("Не задано обязательное св-во модели Parameters.");
            return paramProperty.Dictionary;
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!_initializing)
            {
                var parameters = GetParametersProperty();
                if (parameters != null)
                    parameters.Clear();
            }
            _initializing = false;
            UpdateParameters();
        }

        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            var options = new DynamicArgumentDesignerOptions
            {
                Title = string.Format("Параметры метода {0}", _methodInfo.Name)
            };

            var modelParameters = GetParametersProperty();
            foreach (var p in _methodParameters)
            {
                if (modelParameters.ContainsKey(p.Name ?? ResultParamName))
                    continue;

                var direction = (p.IsOut || p.IsRetval || string.IsNullOrEmpty(p.Name)) ? ArgumentDirection.Out : ArgumentDirection.In;
                //gleb
                //modelParameters.Add(p.Name ?? ResultParamName, ActivityHelpers.CreateDefaultValue(p.ParameterType, direction));
            }

            using (var change = modelParameters.BeginEdit("ObjectEditing"))
            {
                if (DynamicArgumentDialog.ShowDialog(ModelItem, modelParameters, Context, ModelItem.View, options))
                    change.Complete();
                else
                    change.Revert();
            }
        }
        #endregion .  Methods  .

        public sealed class NameValueObject : ICloneable
        {
            public string DisplayName { get; set; }
            public string Name { get; set; }
            public object Value { get; set; }

            public object Clone()
            {
                return new NameValueObject
                {
                    DisplayName = DisplayName,
                    Name = Name,
                    Value = Value
                };
                //return this.Clone(GetType(), false);
            }
        }
    }

    //public interface IExecuteMethodActivity
    //{
    //    MethodInfo[] GetMethods();
    //}
}
