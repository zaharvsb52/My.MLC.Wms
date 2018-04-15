Ext.define('WebClient.common.filters.FilterBinding', {
    config: {
        /**
         * @cfg {WebClient.common.binding.Binding} binding
         * Низлежащий binding который связывает компонент и FilterBinder.
         */
        binding: undefined,

        /**
         * @cfg {String} id
         * Ключ элемента фильтров. При изменении значения в source будет модифицироваться именно этот элемент (или все элементы с таким id) в коллекции фильтров
         */
        id: undefined,

        /**
         * @cfg {String} dataIndex
         * Поле в таблице, к которому применяется оператор фильтра и значение.
         */
        dataIndex: undefined,

        /**
         * @cfg {WebClient.FilterOps} operator
         * Оператор фильтра.
         */
        operator: undefined,

        /**
         * @cfg {Function}
         * Функция, которая конвертирует значение из source в элемент(ы) фильтров.
         * Function(WebClient.common.filters.FilterBinding filterBinding, Object value)
         */
        filterConvertor: WebClient.notImplementedFn
    },

    constructor: function(config) {
        this.initConfig(config);
        return this;
    },

    destroy: function() {
        var binding = this.getBinding();
        if (binding) {
            binding.destroy();
            this.setBinding(null);
        }
    }
});