using System;
using System.Collections.Generic;

namespace MLC.Wms.Model.Entities 
{
    /// <summary>
    /// История изменения Отношение областей перемещения к погрузчикам
    /// </summary>
    [Serializable]
    public partial class WmsTruck2MotionAreaGroupHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 Truck2MotionAreaGroupID { get; set; }
        /// <summary>
        /// Код погрузчика
        /// </summary>
        public virtual String TruckCode_r { get; set; }
        /// <summary>
        /// Код группы области перемещения
        /// </summary>
        public virtual String MotionAreaGroupCode_r { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Погрузчики
    /// </summary>
    [Serializable]
    public partial class WmsTruckHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код погрузчика
        /// </summary>
        public virtual String TruckCode { get; set; }
        /// <summary>
        /// Тип погрузчика
        /// </summary>
        public virtual String TruckTypeCode_r { get; set; }
        /// <summary>
        /// Служебное место
        /// </summary>
        public virtual String PlaceCode_r { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String TruckName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String TruckDesc { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Типы погрузчиков
    /// </summary>
    [Serializable]
    public partial class WmsTruckTypeHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код
        /// </summary>
        public virtual String TruckTypeCode { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String TruckTypeName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String TruckTypeDesc { get; set; }
        /// <summary>
        /// Вес груза
        /// </summary>
        public virtual Decimal TruckTypeWeightMax { get; set; }
        /// <summary>
        /// Кол-во листов пикинга
        /// </summary>
        public virtual Int32 TruckTypePickCount { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Группы инвентаризации
    /// </summary>
    [Serializable]
    public partial class WmsInvGroupHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 InvGroupID { get; set; }
        /// <summary>
        /// Инвентаризация
        /// </summary>
        public virtual Int32 InvID_r { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String InvGroupName { get; set; }
        /// <summary>
        /// Фильтр по менеджеру
        /// </summary>
        public virtual String InvGroupFilter { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public virtual String StatusCode_r { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Инвентаризационный срез
    /// </summary>
    [Serializable]
    public partial class WmsInvSnapShotHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 InvSSID { get; set; }
        /// <summary>
        /// Инвентаризация
        /// </summary>
        public virtual Int32 InvID_r { get; set; }
        /// <summary>
        /// Группа инвентаризации
        /// </summary>
        public virtual Int32 InvGroupID_r { get; set; }
        /// <summary>
        /// Место
        /// </summary>
        public virtual String PlaceCode_r { get; set; }
        /// <summary>
        /// ТЕ
        /// </summary>
        public virtual String InvSSTECode { get; set; }
        /// <summary>
        /// Тип ТЕ
        /// </summary>
        public virtual String TETypeCode_r { get; set; }
        /// <summary>
        /// Артикул
        /// </summary>
        public virtual String ArtCode_r { get; set; }
        /// <summary>
        /// SKU
        /// </summary>
        public virtual Int32 SKUID_r { get; set; }
        /// <summary>
        /// Фабрика
        /// </summary>
        public virtual Int32? FactoryID_r { get; set; }
        /// <summary>
        /// Количество SKU
        /// </summary>
        public virtual Int32 InvSSCount { get; set; }
        /// <summary>
        /// Количество в SKU
        /// </summary>
        public virtual Double InvSSCount2SKU { get; set; }
        /// <summary>
        /// Квалификация
        /// </summary>
        public virtual String QLFCode_r { get; set; }
        /// <summary>
        /// Детализация квалификации
        /// </summary>
        public virtual String QLFDetailCode_r { get; set; }
        /// <summary>
        /// Дата приемки
        /// </summary>
        public virtual DateTime? InvSSProductInputDate { get; set; }
        /// <summary>
        /// Дата производства
        /// </summary>
        public virtual DateTime? InvSSProductDate { get; set; }
        /// <summary>
        /// Срок годности
        /// </summary>
        public virtual DateTime? InvSSExpiryDate { get; set; }
        /// <summary>
        /// Партия
        /// </summary>
        public virtual String InvSSBatch { get; set; }
        /// <summary>
        /// Лот
        /// </summary>
        public virtual String InvSSLot { get; set; }
        /// <summary>
        /// Серийный номер
        /// </summary>
        public virtual String InvSSSerialNumber { get; set; }
        /// <summary>
        /// Цвет
        /// </summary>
        public virtual String InvSSColor { get; set; }
        /// <summary>
        /// Тон
        /// </summary>
        public virtual String InvSSTone { get; set; }
        /// <summary>
        /// Размер
        /// </summary>
        public virtual String InvSSSize { get; set; }
        /// <summary>
        /// BatchCode
        /// </summary>
        public virtual String InvSSBatchCode { get; set; }
        /// <summary>
        /// Приходная накладная
        /// </summary>
        public virtual Int32? IWBID_r { get; set; }
        /// <summary>
        /// Расходная накладная
        /// </summary>
        public virtual Int32? OWBID_r { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        /// <summary>
        /// Номер короба
        /// </summary>
        public virtual String InvSSBoxNumber { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Просчеты заданий
    /// </summary>
    [Serializable]
    public partial class WmsInvTaskStepHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 InvTaskStepID { get; set; }
        /// <summary>
        /// Номер просчета
        /// </summary>
        public virtual Int32 InvTaskStepNumber { get; set; }
        /// <summary>
        /// Группа заданий
        /// </summary>
        public virtual Int32 InvTaskGroupID_r { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public virtual String StatusCode_r { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Расходные накладные к грузу
    /// </summary>
    [Serializable]
    public partial class WmsOWB2CargoHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 OWB2CargoID { get; set; }
        /// <summary>
        /// Расходная накладная
        /// </summary>
        public virtual Int32 OWBID_r { get; set; }
        /// <summary>
        /// Груз на расход
        /// </summary>
        public virtual Int32 CargoOWBID_r { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Менеджер резервирования
    /// </summary>
    [Serializable]
    public partial class WmsMRHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код
        /// </summary>
        public virtual String MRCode { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String MRName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String MRDesc { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Очередь резервирования
    /// </summary>
    [Serializable]
    public partial class WmsQResHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 QResID { get; set; }
        /// <summary>
        /// Мандант
        /// </summary>
        public virtual WmsMandant Partner { get; set; }
        /// <summary>
        /// Расходная накладная
        /// </summary>
        public virtual Int32 OWBID_r { get; set; }
        /// <summary>
        /// Приоритет
        /// </summary>
        public virtual Int32 OWBPriority_r { get; set; }
        /// <summary>
        /// Действия при недостающем кол-ве
        /// </summary>
        public virtual String OWBProductNeed_r { get; set; }
        /// <summary>
        /// Тип резервирования
        /// </summary>
        public virtual String OWBReservType_r { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public virtual String StatusCode_r { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Применение менеджера резервирования
    /// </summary>
    [Serializable]
    public partial class WmsMRUseHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 MRUseID { get; set; }
        /// <summary>
        /// Менеджер резервирования
        /// </summary>
        public virtual String MRCode_r { get; set; }
        /// <summary>
        /// Родительская ветка. Может не задаваться для узла 1-го уровня.
        /// </summary>
        public virtual Int32? MRUseParent { get; set; }
        /// <summary>
        /// Тип стратегии
        /// </summary>
        public virtual String MRUseStrategyType { get; set; }
        /// <summary>
        /// Стратегия
        /// </summary>
        public virtual String MRUseStrategy { get; set; }
        /// <summary>
        /// Значение для стратегии
        /// </summary>
        public virtual String MRUseStrategyValue { get; set; }
        /// <summary>
        /// Сортировка стратегий
        /// </summary>
        public virtual Int32 MRUseOrder { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Груз на приход
    /// </summary>
    [Serializable]
    public partial class WmsCargoIWBHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 CargoIWBID { get; set; }
        /// <summary>
        /// Внутренний рейс
        /// </summary>
        public virtual Int32? InternalTrafficID_r { get; set; }
        /// <summary>
        /// Нетто
        /// </summary>
        public virtual Decimal? CargoIWBNet { get; set; }
        /// <summary>
        /// Брутто
        /// </summary>
        public virtual Decimal? CargoIWBBrutto { get; set; }
        /// <summary>
        /// Объем
        /// </summary>
        public virtual Decimal? CargoIWBVolume { get; set; }
        /// <summary>
        /// Кол-во ГМ
        /// </summary>
        public virtual Int32? CargoIWBCount { get; set; }
        /// <summary>
        /// Адрес загрузки
        /// </summary>
        public virtual Int32? CargoIWBLoadAddress { get; set; }
        /// <summary>
        /// Начало загрузки
        /// </summary>
        public virtual DateTime? CargoIWBLoadBegin { get; set; }
        /// <summary>
        /// Окончание загрузки
        /// </summary>
        public virtual DateTime? CargoIWBLoadEnd { get; set; }
        /// <summary>
        /// Пломба
        /// </summary>
        public virtual String CargoIWBStamp { get; set; }
        /// <summary>
        /// Состояние пломбы
        /// </summary>
        public virtual String CargoIWBStampState { get; set; }
        /// <summary>
        /// Контейнер
        /// </summary>
        public virtual String CargoIWBContainer { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Менеджер пикинга
    /// </summary>
    [Serializable]
    public partial class WmsMPLHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код
        /// </summary>
        public virtual String MPLCode { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String MPLName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String MPLDesc { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Выбор менеджера пикинга
    /// </summary>
    [Serializable]
    public partial class WmsMPLSelectHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 MPLSelectID { get; set; }
        /// <summary>
        /// Менеджер пикинга
        /// </summary>
        public virtual String MPLCode_r { get; set; }
        /// <summary>
        /// Приоритет
        /// </summary>
        public virtual Int32 Priority { get; set; }
        /// <summary>
        /// Мандант
        /// </summary>
        public virtual WmsMandant Partner { get; set; }
        /// <summary>
        /// Область склада
        /// </summary>
        public virtual String AreaCode_r { get; set; }
        /// <summary>
        /// Зона поставки
        /// </summary>
        public virtual String SupplyAreaCode_r { get; set; }
        /// <summary>
        /// По накладной
        /// </summary>
        public virtual String MPLSelectOWBCritPL { get; set; }
        /// <summary>
        /// По SKU
        /// </summary>
        public virtual String MPLSelectSKUCritPL { get; set; }
        /// <summary>
        /// По группе
        /// </summary>
        public virtual String MPLSelectArtGroupCritPL { get; set; }
        /// <summary>
        /// По группе опасности
        /// </summary>
        public virtual String MPLSelectArtGroupDangerCritPL { get; set; }
        /// <summary>
        /// Критерий по квалификации
        /// </summary>
        public virtual String QLFCode_r { get; set; }
        /// <summary>
        /// Полнота резервирования
        /// </summary>
        public virtual String MPLSelectReservTE { get; set; }
        /// <summary>
        /// Полнота ТЕ по группе накладных
        /// </summary>
        public virtual Boolean MPLSelectTECompleteOWBGroup { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Список пикинга
    /// </summary>
    [Serializable]
    public partial class WmsPLHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 PLID { get; set; }
        /// <summary>
        /// Тип
        /// </summary>
        public virtual String PLType { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public virtual String StatusCode_r { get; set; }
        /// <summary>
        /// Менеджер пикинга
        /// </summary>
        public virtual String MPLCode_r { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Позиции списка пикинга
    /// </summary>
    [Serializable]
    public partial class WmsPLPosHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 PLPosID { get; set; }
        /// <summary>
        /// Список пикинга
        /// </summary>
        public virtual Int32 PLID_r { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public virtual String StatusCode_r { get; set; }
        /// <summary>
        /// Код места
        /// </summary>
        public virtual String PlaceCode_r { get; set; }
        /// <summary>
        /// ТЕ
        /// </summary>
        public virtual String TECode_r { get; set; }
        /// <summary>
        /// Сортировка
        /// </summary>
        public virtual Int32 PLPosSort { get; set; }
        /// <summary>
        /// Единица учета
        /// </summary>
        public virtual Int32 SKUID_r { get; set; }
        /// <summary>
        /// Требуемое кол-во
        /// </summary>
        public virtual Int32 PLPosCountSKUPlan { get; set; }
        /// <summary>
        /// Фактическое кол-во
        /// </summary>
        public virtual Int32 PLPosCountSKUFact { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Резервирование
    /// </summary>
    [Serializable]
    public partial class WmsResHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 ResID { get; set; }
        /// <summary>
        /// Товар
        /// </summary>
        public virtual Int32 ProductID_r { get; set; }
        /// <summary>
        /// Позиция расходной накладной
        /// </summary>
        public virtual Int32 OWBPosID_r { get; set; }
        /// <summary>
        /// Менеджер резервирования
        /// </summary>
        public virtual String MRCode_r { get; set; }
        /// <summary>
        /// Позиция списка пикинга
        /// </summary>
        public virtual Int32? PlPosID_r { get; set; }
        /// <summary>
        /// Группа резервирования
        /// </summary>
        public virtual Int32? ResGroup { get; set; }
        /// <summary>
        /// Тип
        /// </summary>
        public virtual String ResType { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Применение менеджера пикинга
    /// </summary>
    [Serializable]
    public partial class WmsMPLUseHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 MPLUseID { get; set; }
        /// <summary>
        /// Менеджер пикинга
        /// </summary>
        public virtual String MPLCode_r { get; set; }
        /// <summary>
        /// По расходной накладной
        /// </summary>
        public virtual Boolean MPLUseByOWB { get; set; }
        /// <summary>
        /// По артикулу
        /// </summary>
        public virtual Boolean MPLUseByArt { get; set; }
        /// <summary>
        /// По группе артикулов
        /// </summary>
        public virtual Boolean MPLUseByArtGroup { get; set; }
        /// <summary>
        /// По весу
        /// </summary>
        public virtual Decimal MPLUseWeight { get; set; }
        /// <summary>
        /// По объему
        /// </summary>
        public virtual Decimal MPLUseVolume { get; set; }
        /// <summary>
        /// По ряду
        /// </summary>
        public virtual Boolean MPLUseBySegment { get; set; }
        /// <summary>
        /// По количеству строк
        /// </summary>
        public virtual Int32 MPLUseLine { get; set; }
        /// <summary>
        /// Ожидать пополнения
        /// </summary>
        public virtual Boolean MPLUseWait { get; set; }
        /// <summary>
        /// По зоне перемещения
        /// </summary>
        public virtual Boolean MPLUseByMotionArea { get; set; }
        /// <summary>
        /// Метод контроля места
        /// </summary>
        public virtual String MPLUsePickControlMethod { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Груз на расход
    /// </summary>
    [Serializable]
    public partial class WmsCargoOWBHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 CargoOWBID { get; set; }
        /// <summary>
        /// Внутренний рейс
        /// </summary>
        public virtual Int32? InternalTrafficID_r { get; set; }
        /// <summary>
        /// Нетто груза
        /// </summary>
        public virtual Decimal? CargoOWBNet { get; set; }
        /// <summary>
        /// Брутто груза
        /// </summary>
        public virtual Decimal? CargoOWBBrutto { get; set; }
        /// <summary>
        /// Объем груза
        /// </summary>
        public virtual Decimal? CargoOWBVolume { get; set; }
        /// <summary>
        /// Количество грузовых мест
        /// </summary>
        public virtual Int32? CargoOWBCount { get; set; }
        /// <summary>
        /// Адрес места разгрузки
        /// </summary>
        public virtual Int32? CargoOWBUnLoadAddress { get; set; }
        /// <summary>
        /// Начало загрузки
        /// </summary>
        public virtual DateTime? CargoOWBLoadBegin { get; set; }
        /// <summary>
        /// Окончание загрузки
        /// </summary>
        public virtual DateTime? CargoOWBLoadEnd { get; set; }
        /// <summary>
        /// Номер пломбы
        /// </summary>
        public virtual String CargoOWBStamp { get; set; }
        /// <summary>
        /// Номер контейнера
        /// </summary>
        public virtual String CargoOWBContainer { get; set; }
        /// <summary>
        /// Маршрут
        /// </summary>
        public virtual Int32? RouteID_r { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Расходная накладная
    /// </summary>
    [Serializable]
    public partial class WmsOWBHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 OWBID { get; set; }
        /// <summary>
        /// Мандант
        /// </summary>
        public virtual WmsMandant Partner { get; set; }
        /// <summary>
        /// Имя документа
        /// </summary>
        public virtual String OWBName { get; set; }
        /// <summary>
        /// Приоритет документа
        /// </summary>
        public virtual Int32 OWBPriority { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public virtual String StatusCode_r { get; set; }
        /// <summary>
        /// Планируемая дата отгрузки
        /// </summary>
        public virtual DateTime? OWBOutDatePlan { get; set; }
        /// <summary>
        /// Действия при недостающем кол-ве
        /// </summary>
        public virtual String OWBProductNeed { get; set; }
        /// <summary>
        /// Получатель
        /// </summary>
        public virtual Int32? OWBRecipient { get; set; }
        /// <summary>
        /// Плательщик
        /// </summary>
        public virtual Int32? OWBPayer { get; set; }
        /// <summary>
        /// Клиент-получатель
        /// </summary>
        public virtual Int32? OWBClientRecipient { get; set; }
        /// <summary>
        /// Адрес клиента-получателя
        /// </summary>
        public virtual Int32? OWBClientRecipientAddr { get; set; }
        /// <summary>
        /// Доставка, план
        /// </summary>
        public virtual DateTime? OWBPlannedDeliveryDate { get; set; }
        /// <summary>
        /// Клиент-плательщик
        /// </summary>
        public virtual Int32? OWBClientPayer { get; set; }
        /// <summary>
        /// Тип резервирования
        /// </summary>
        public virtual String OWBReservType { get; set; }
        /// <summary>
        /// Критерий пикинга
        /// </summary>
        public virtual String OWBCritPL { get; set; }
        /// <summary>
        /// Критерий поставки
        /// </summary>
        public virtual String OWBCritMSC { get; set; }
        /// <summary>
        /// Критерий срока коммерциализации
        /// </summary>
        public virtual String OWBCritED { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String OWBDesc { get; set; }
        /// <summary>
        /// Фабрика
        /// </summary>
        public virtual Int32? FactoryID_r { get; set; }
        /// <summary>
        /// адрес
        /// </summary>
        public virtual Int32? AddressBookID_r { get; set; }
        /// <summary>
        /// Номер доверенности
        /// </summary>
        public virtual String OWBProxyNumber { get; set; }
        /// <summary>
        /// Дата доверенности
        /// </summary>
        public virtual DateTime? OWBProxyDate { get; set; }
        /// <summary>
        /// Клиентская дата создания накладной
        /// </summary>
        public virtual DateTime? OWBHostRefDate { get; set; }
        /// <summary>
        /// Тип накладной
        /// </summary>
        public virtual String OWBType { get; set; }
        /// <summary>
        /// Плановый маршрут
        /// </summary>
        public virtual Int32? OWBRoutePlan { get; set; }
        /// <summary>
        /// Идентификатор в хост-системе
        /// </summary>
        public virtual String OWBHostRef { get; set; }
        /// <summary>
        /// Владелец
        /// </summary>
        public virtual WmsMandant OWBOwner { get; set; }
        /// <summary>
        /// Группа накладных
        /// </summary>
        public virtual String OWBGroup { get; set; }
        /// <summary>
        /// Перевозчик
        /// </summary>
        public virtual Int32? OWBCarrier { get; set; }
        /// <summary>
        /// Заказ КС
        /// </summary>
        public virtual String OWBPartnerOrder { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Приходная накладная
    /// </summary>
    [Serializable]
    public partial class WmsIWBHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 IWBID { get; set; }
        /// <summary>
        /// Мандант
        /// </summary>
        public virtual WmsMandant Partner { get; set; }
        /// <summary>
        /// Имя приходного документа
        /// </summary>
        public virtual String IWBName { get; set; }
        /// <summary>
        /// Приоритет документа
        /// </summary>
        public virtual Int32 IWBPriority { get; set; }
        /// <summary>
        /// ID записи расходной накладной
        /// </summary>
        public virtual Int32? OWBID_r { get; set; }
        /// <summary>
        /// Планируемая дата поставки
        /// </summary>
        public virtual DateTime? IWBInDatePlan { get; set; }
        /// <summary>
        /// Отправитель
        /// </summary>
        public virtual Int32? IWBSender { get; set; }
        /// <summary>
        /// Плательщик
        /// </summary>
        public virtual Int32? IWBPayer { get; set; }
        /// <summary>
        /// Получатель
        /// </summary>
        public virtual Int32? IWBRecipient { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public virtual String StatusCode_r { get; set; }
        /// <summary>
        /// Номер CMR/ТТН
        /// </summary>
        public virtual String IWBCMRNumber { get; set; }
        /// <summary>
        /// Дата CMR/ТТН
        /// </summary>
        public virtual DateTime? IWBCMRDate { get; set; }
        /// <summary>
        /// Идентификатор в хост-системе
        /// </summary>
        public virtual String IWBHostRef { get; set; }
        /// <summary>
        /// Тип накладной
        /// </summary>
        public virtual String IWBType { get; set; }
        /// <summary>
        /// Фабрика
        /// </summary>
        public virtual Int32? FactoryID_r { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String IWBDesc { get; set; }
        /// <summary>
        /// Инвентаризация
        /// </summary>
        public virtual Int32? InvID_r { get; set; }
        /// <summary>
        /// Группа накладных
        /// </summary>
        public virtual String IWBGroup { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Позиции груза
    /// </summary>
    [Serializable]
    public partial class WmsCargoIWBPosHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 CargoIWBPosID { get; set; }
        /// <summary>
        /// Груз
        /// </summary>
        public virtual Int32 CargoIWBID_r { get; set; }
        /// <summary>
        /// Количество
        /// </summary>
        public virtual Int32 CargoIWBPosCount { get; set; }
        /// <summary>
        /// Тип грузового места
        /// </summary>
        public virtual String TETypeCode_r { get; set; }
        /// <summary>
        /// Тип позиции
        /// </summary>
        public virtual String CargoIWBPosType { get; set; }
        /// <summary>
        /// Квалификация
        /// </summary>
        public virtual String QLFCode_r { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String CargoIWBPosDesc { get; set; }
        /// <summary>
        /// Приходная накладная
        /// </summary>
        public virtual Int32? IWBID_r { get; set; }
        /// <summary>
        /// Номер короба
        /// </summary>
        public virtual String CargoIWBPosBoxNumber { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Приходные накладные к грузу
    /// </summary>
    [Serializable]
    public partial class WmsIWB2CargoHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 IWB2CargoID { get; set; }
        /// <summary>
        /// ID приходной накладной
        /// </summary>
        public virtual Int32 IWBID_r { get; set; }
        /// <summary>
        /// ID груза
        /// </summary>
        public virtual Int32 CargoIWBID_r { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Позиции приходной накладной
    /// </summary>
    [Serializable]
    public partial class WmsIWBPosHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 IWBPosID { get; set; }
        /// <summary>
        /// Приходная накладная
        /// </summary>
        public virtual Int32 IWBID_r { get; set; }
        /// <summary>
        /// Номер позиции
        /// </summary>
        public virtual Int32 IWBPosNumber { get; set; }
        /// <summary>
        /// SKU
        /// </summary>
        public virtual Int32 SKUID_r { get; set; }
        /// <summary>
        /// Количество
        /// </summary>
        public virtual Int32 IWBPosCount { get; set; }
        /// <summary>
        /// Дробное кол-во
        /// </summary>
        public virtual Double IWBPosCount2SKU { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public virtual String StatusCode_r { get; set; }
        /// <summary>
        /// Цвет
        /// </summary>
        public virtual String IWBPosColor { get; set; }
        /// <summary>
        /// Тон
        /// </summary>
        public virtual String IWBPosTone { get; set; }
        /// <summary>
        /// Размер
        /// </summary>
        public virtual String IWBPosSize { get; set; }
        /// <summary>
        /// Партия
        /// </summary>
        public virtual String IWBPosBatch { get; set; }
        /// <summary>
        /// Лот
        /// </summary>
        public virtual String IWBPosLot { get; set; }
        /// <summary>
        /// Срок годности
        /// </summary>
        public virtual DateTime? IWBPosExpiryDate { get; set; }
        /// <summary>
        /// Дата производства
        /// </summary>
        public virtual DateTime? IWBPosProductDate { get; set; }
        /// <summary>
        /// Серийный номер
        /// </summary>
        public virtual String IWBPosSerialNumber { get; set; }
        /// <summary>
        /// Фабрика
        /// </summary>
        public virtual Int32? FactoryID_r { get; set; }
        /// <summary>
        /// Квалификация
        /// </summary>
        public virtual String QLFCode_r { get; set; }
        /// <summary>
        /// Блокировка
        /// </summary>
        public virtual String IWBPosBlocking { get; set; }
        /// <summary>
        /// Стоимость
        /// </summary>
        public virtual Double? IWBPosPriceValue { get; set; }
        /// <summary>
        /// Клиентский артикул
        /// </summary>
        public virtual String IWBPosArtName { get; set; }
        /// <summary>
        /// Клиентская ЕИ
        /// </summary>
        public virtual String IWBPosMeasure { get; set; }
        /// <summary>
        /// Добавлена вручную
        /// </summary>
        public virtual Boolean IWBPosManual { get; set; }
        /// <summary>
        /// TE
        /// </summary>
        public virtual String IWBPosTE { get; set; }
        /// <summary>
        /// BatchCode
        /// </summary>
        public virtual String IWBBatchCode { get; set; }
        /// <summary>
        /// Номер короба
        /// </summary>
        public virtual String IWBPosBoxNumber { get; set; }
        /// <summary>
        /// Хост-идентификатор
        /// </summary>
        public virtual String IWBPosHostRef { get; set; }
        /// <summary>
        /// Номер инвойса
        /// </summary>
        public virtual String IWBPosInvoiceNumber { get; set; }
        /// <summary>
        /// Дата инвойса
        /// </summary>
        public virtual DateTime? IWBPosInvoiceDate { get; set; }
        /// <summary>
        /// Артикул комплекта
        /// </summary>
        public virtual String IWBPosKitArtName { get; set; }
        /// <summary>
        /// Владелец
        /// </summary>
        public virtual WmsMandant IWBPosOwner { get; set; }
        /// <summary>
        /// Принятое количество
        /// </summary>
        public virtual Double? IWBPosProductCount { get; set; }
        /// <summary>
        /// Приоритет
        /// </summary>
        public virtual Int32? IWBPosProductPriority { get; set; }
        /// <summary>
        /// Критерий перемещения
        /// </summary>
        public virtual String IWBPosCritMM { get; set; }
        /// <summary>
        /// Страна
        /// </summary>
        public virtual String CountryCode_r { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual String IWBPosGTD { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Позиции расходной накладной
    /// </summary>
    [Serializable]
    public partial class WmsOWBPosHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 OWBPosID { get; set; }
        /// <summary>
        /// Расходная накладная
        /// </summary>
        public virtual Int32 OWBID_r { get; set; }
        /// <summary>
        /// Номер позиции
        /// </summary>
        public virtual Int32 OWBPosNumber { get; set; }
        /// <summary>
        /// SKU
        /// </summary>
        public virtual Int32 SKUID_r { get; set; }
        /// <summary>
        /// Количество
        /// </summary>
        public virtual Int32 OWBPosCount { get; set; }
        /// <summary>
        /// Дробное ко-во
        /// </summary>
        public virtual Double OWBPosCount2SKU { get; set; }
        /// <summary>
        /// Кол-во зарезервированного товара
        /// </summary>
        public virtual Int32? OWBPosReserved { get; set; }
        /// <summary>
        /// Недостающее кол-во
        /// </summary>
        public virtual Int32? OWBPosWantage { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public virtual String StatusCode_r { get; set; }
        /// <summary>
        /// Цвет
        /// </summary>
        public virtual String OWBPosColor { get; set; }
        /// <summary>
        /// Тон
        /// </summary>
        public virtual String OWBPosTone { get; set; }
        /// <summary>
        /// Размер
        /// </summary>
        public virtual String OWBPosSize { get; set; }
        /// <summary>
        /// Партия
        /// </summary>
        public virtual String OWBPosBatch { get; set; }
        /// <summary>
        /// Лот
        /// </summary>
        public virtual String OWBPosLot { get; set; }
        /// <summary>
        /// Срок годности
        /// </summary>
        public virtual DateTime? OWBPosExpiryDate { get; set; }
        /// <summary>
        /// Дата производства
        /// </summary>
        public virtual DateTime? OWBPosProductDate { get; set; }
        /// <summary>
        /// Серийный номер
        /// </summary>
        public virtual String OWBPosSerialNumber { get; set; }
        /// <summary>
        /// Фабрика
        /// </summary>
        public virtual Int32? FactoryID_r { get; set; }
        /// <summary>
        /// Квалификация
        /// </summary>
        public virtual String QLFCode_r { get; set; }
        /// <summary>
        /// Детализация квалификации
        /// </summary>
        public virtual String QLFDetailCode_r { get; set; }
        /// <summary>
        /// Блокировка
        /// </summary>
        public virtual String OWBPosBlocking { get; set; }
        /// <summary>
        /// Стоимость
        /// </summary>
        public virtual Double? OWBPosPriceValue { get; set; }
        /// <summary>
        /// Стоимость с НДС
        /// </summary>
        public virtual Double? OWBPosPriceValueVAT { get; set; }
        /// <summary>
        /// Клиентский артикул
        /// </summary>
        public virtual String OWBPosArtName { get; set; }
        /// <summary>
        /// Клиентская ЕИ
        /// </summary>
        public virtual String OWBPosMeasure { get; set; }
        /// <summary>
        /// Номер короба
        /// </summary>
        public virtual String OWBPosBoxNumber { get; set; }
        /// <summary>
        /// Хост-идентификатор
        /// </summary>
        public virtual String OWBPosHostRef { get; set; }
        /// <summary>
        /// Артикул комплекта
        /// </summary>
        public virtual String OWBPosKitArtName { get; set; }
        /// <summary>
        /// Владелец
        /// </summary>
        public virtual WmsMandant OWBPosOwner { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Выбор менеджера резервирования
    /// </summary>
    [Serializable]
    public partial class WmsMRSelectHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 MRSelectID { get; set; }
        /// <summary>
        /// Менеджер резервирования
        /// </summary>
        public virtual String MRCode_r { get; set; }
        /// <summary>
        /// Приоритет
        /// </summary>
        public virtual Int32 Priority { get; set; }
        /// <summary>
        /// Мандант
        /// </summary>
        public virtual WmsMandant Partner { get; set; }
        /// <summary>
        /// По накладной
        /// </summary>
        public virtual String MRSelectOWBRType { get; set; }
        /// <summary>
        /// По SKU
        /// </summary>
        public virtual String MRSelectSKURType { get; set; }
        /// <summary>
        /// Пересчет SKU
        /// </summary>
        public virtual Boolean MRSelectCalcSKU { get; set; }
        /// <summary>
        /// Фабрика
        /// </summary>
        public virtual Int32? FactoryID_r { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Применение менеджера инвентаризации
    /// </summary>
    [Serializable]
    public partial class WmsMIUseHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 MIUseID { get; set; }
        /// <summary>
        /// Менеджер инвентаризации
        /// </summary>
        public virtual Guid MICode_r { get; set; }
        /// <summary>
        /// Тип стратегии
        /// </summary>
        public virtual String MIUseStrategyType { get; set; }
        /// <summary>
        /// Имя сущности объекта
        /// </summary>
        public virtual String ObjectEntityCode_r { get; set; }
        /// <summary>
        /// Имя объекта
        /// </summary>
        public virtual String ObjectName_r { get; set; }
        /// <summary>
        /// Значение стратегии
        /// </summary>
        public virtual String MIUseStrategyValue { get; set; }
        /// <summary>
        /// Код группы
        /// </summary>
        public virtual String MIUseGroupCode { get; set; }
        /// <summary>
        /// Сортировка атрибутов
        /// </summary>
        public virtual Int32? MIUseOrder { get; set; }
        /// <summary>
        /// Фильтр
        /// </summary>
        public virtual String MIUseFilter { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        /// <summary>
        /// Преобразовать в текст
        /// </summary>
        public virtual Boolean? MIUseToChar { get; set; }
        /// <summary>
        /// Сортировка значений
        /// </summary>
        public virtual String MIUseOrderType { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Задания на просчет
    /// </summary>
    [Serializable]
    public partial class WmsInvTaskHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 InvTaskID { get; set; }
        /// <summary>
        /// Группа заданий
        /// </summary>
        public virtual Int32 InvTaskGroupID_r { get; set; }
        /// <summary>
        /// Просчёт
        /// </summary>
        public virtual Int32 InvTaskStepID_r { get; set; }
        /// <summary>
        /// Срез
        /// </summary>
        public virtual Int32? InvSnapShotID_r { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public virtual String StatusCode_r { get; set; }
        /// <summary>
        /// Номер строки
        /// </summary>
        public virtual Int32 InvTaskNumber { get; set; }
        /// <summary>
        /// Количество
        /// </summary>
        public virtual Int32? InvTaskCount { get; set; }
        /// <summary>
        /// Добавлена вручную
        /// </summary>
        public virtual Boolean InvTaskManual { get; set; }
        /// <summary>
        /// Место
        /// </summary>
        public virtual String PlaceCode_r { get; set; }
        /// <summary>
        /// ТЕ
        /// </summary>
        public virtual String InvTaskTECode { get; set; }
        /// <summary>
        /// Тип ТЕ
        /// </summary>
        public virtual String TETypeCode_r { get; set; }
        /// <summary>
        /// Артикул
        /// </summary>
        public virtual String ArtCode_r { get; set; }
        /// <summary>
        /// SKU
        /// </summary>
        public virtual Int32 SKUID_r { get; set; }
        /// <summary>
        /// Фабрика
        /// </summary>
        public virtual Int32? FactoryID_r { get; set; }
        /// <summary>
        /// Кол-во в SKU
        /// </summary>
        public virtual Double InvTaskCount2SKU { get; set; }
        /// <summary>
        /// Квалификация
        /// </summary>
        public virtual String QLFCode_r { get; set; }
        /// <summary>
        /// Детализация квалификации
        /// </summary>
        public virtual String QLFDetailCode_r { get; set; }
        /// <summary>
        /// Дата приемки
        /// </summary>
        public virtual DateTime? InvTaskProductInputDate { get; set; }
        /// <summary>
        /// Дата производства
        /// </summary>
        public virtual DateTime? InvTaskProductDate { get; set; }
        /// <summary>
        /// Срок годности
        /// </summary>
        public virtual DateTime? InvTaskExpiryDate { get; set; }
        /// <summary>
        /// Партия
        /// </summary>
        public virtual String InvTaskBatch { get; set; }
        /// <summary>
        /// Лот
        /// </summary>
        public virtual String InvTaskLot { get; set; }
        /// <summary>
        /// Серийный номер
        /// </summary>
        public virtual String InvTaskSerialNumber { get; set; }
        /// <summary>
        /// Цвет
        /// </summary>
        public virtual String InvTaskColor { get; set; }
        /// <summary>
        /// Тон
        /// </summary>
        public virtual String InvTaskTone { get; set; }
        /// <summary>
        /// Размер
        /// </summary>
        public virtual String InvTaskSize { get; set; }
        /// <summary>
        /// BatchCode
        /// </summary>
        public virtual String InvTaskBatchCode { get; set; }
        /// <summary>
        /// Приходная накладная
        /// </summary>
        public virtual Int32? IWBID_r { get; set; }
        /// <summary>
        /// Расходная накладная
        /// </summary>
        public virtual Int32? OWBID_r { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        /// <summary>
        /// Сошлось
        /// </summary>
        public virtual Boolean? InvTaskFinal { get; set; }
        /// <summary>
        /// Номер короба
        /// </summary>
        public virtual String InvTaskBoxNumber { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Менеджер инвентаризации
    /// </summary>
    [Serializable]
    public partial class WmsMIHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код
        /// </summary>
        public virtual Guid MICode { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String MIName { get; set; }
        /// <summary>
        /// Тип разбиения по группам
        /// </summary>
        public virtual String MILineType { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String MIDesc { get; set; }
        /// <summary>
        /// Тип инвентаризации
        /// </summary>
        public virtual String MIInvType { get; set; }
        /// <summary>
        /// Запрашивать SKU
        /// </summary>
        public virtual Boolean MIAskSKU { get; set; }
        /// <summary>
        /// Кол-во строк
        /// </summary>
        public virtual Int32 MILine { get; set; }
        /// <summary>
        /// Строк на страницу
        /// </summary>
        public virtual Int32 MILinePerPage { get; set; }
        /// <summary>
        /// Тип расчета
        /// </summary>
        public virtual String MICalcType { get; set; }
        /// <summary>
        /// Запрет расчета до закрытия
        /// </summary>
        public virtual Int32 MICalcBan { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Boolean MIPiece { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Инвентаризация
    /// </summary>
    [Serializable]
    public partial class WmsInvHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 InvID { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String InvName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String InvDesc { get; set; }
        /// <summary>
        /// Дата начала
        /// </summary>
        public virtual DateTime? InvDateBegin { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public virtual String StatusCode_r { get; set; }
        /// <summary>
        /// Мандант
        /// </summary>
        public virtual WmsMandant Partner { get; set; }
        /// <summary>
        /// Менеджер инвентаризации
        /// </summary>
        public virtual Guid MICode_r { get; set; }
        /// <summary>
        /// InvOrderNumber
        /// </summary>
        public virtual String InvOrderNumber { get; set; }
        /// <summary>
        /// Дата приказа
        /// </summary>
        public virtual DateTime? InvOrderDate { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Группа заданий
    /// </summary>
    [Serializable]
    public partial class WmsInvTaskGroupHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 InvTaskGroupID { get; set; }
        /// <summary>
        /// Группа инвентаризации
        /// </summary>
        public virtual Int32 InvGroupID_r { get; set; }
        /// <summary>
        /// Номер группы
        /// </summary>
        public virtual Int32 InvTaskGroupNumber { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public virtual String StatusCode_r { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Менеджер поставок
    /// </summary>
    [Serializable]
    public partial class WmsMSCHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Менеджер поставок
        /// </summary>
        public virtual String MSCCode { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String MSCName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String MSCDesc { get; set; }
        /// <summary>
        /// Тип
        /// </summary>
        public virtual String MSCTypeCode_r { get; set; }
        /// <summary>
        /// Стратегия пополнения
        /// </summary>
        public virtual String MSCStrategy { get; set; }
        /// <summary>
        /// Менеджер перемещения
        /// </summary>
        public virtual String MMCode_r { get; set; }
        /// <summary>
        /// Целевая зона поставки
        /// </summary>
        public virtual String MSCTargetSupplyArea { get; set; }
        /// <summary>
        /// Требуемая операция
        /// </summary>
        public virtual String MSCRequiredOperation { get; set; }
        /// <summary>
        /// Операционный приоритет
        /// </summary>
        public virtual Int32 MSCOperationOrder { get; set; }
        /// <summary>
        /// Текущий этап
        /// </summary>
        public virtual String MSCFrom { get; set; }
        /// <summary>
        /// Следующий этап
        /// </summary>
        public virtual String MSCTo { get; set; }
        /// <summary>
        /// Финальное
        /// </summary>
        public virtual Boolean MSCFinal { get; set; }
        /// <summary>
        /// Перезапуск
        /// </summary>
        public virtual Boolean MSCRestartSource { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Выбор менеджера поставки
    /// </summary>
    [Serializable]
    public partial class WmsMSCSelectHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 MSCSelectID { get; set; }
        /// <summary>
        /// Менеджер поставок
        /// </summary>
        public virtual String MSCCODE_r { get; set; }
        /// <summary>
        /// Приоритет
        /// </summary>
        public virtual Int32 Priority { get; set; }
        /// <summary>
        /// Исходная зона поставки
        /// </summary>
        public virtual String MSCSelectSourceSupplyArea { get; set; }
        /// <summary>
        /// Мандант
        /// </summary>
        public virtual WmsMandant Partner { get; set; }
        /// <summary>
        /// Фабрика
        /// </summary>
        public virtual Int32? FactoryID_r { get; set; }
        /// <summary>
        /// По накладной
        /// </summary>
        public virtual String MSCSelectOWB { get; set; }
        /// <summary>
        /// По SKU
        /// </summary>
        public virtual String MSCSelectSKU { get; set; }
        /// <summary>
        /// По группе артикулов
        /// </summary>
        public virtual String MSCSelectArtGroup { get; set; }
        /// <summary>
        /// По группе опасности артикулов
        /// </summary>
        public virtual String MSCSelectArtGroupDanger { get; set; }
        /// <summary>
        /// По группе партнеров
        /// </summary>
        public virtual String MSCSelectPartnerGroup { get; set; }
        /// <summary>
        /// Полнота товара на ТЕ min
        /// </summary>
        public virtual Int32? MSCSelectTECompleteMin { get; set; }
        /// <summary>
        /// Полнота товара на ТЕ max
        /// </summary>
        public virtual Int32? MSCSelectTECompleteMax { get; set; }
        /// <summary>
        /// Полнота резервирования
        /// </summary>
        public virtual String MSCSelectReservTE { get; set; }
        /// <summary>
        /// Критерий по SKU2TTE
        /// </summary>
        public virtual String MSCSelectSKU2TTE { get; set; }
        /// <summary>
        /// Критерий по TEType
        /// </summary>
        public virtual String MSCSelectTEType { get; set; }
        /// <summary>
        /// Критерий по квалификации
        /// </summary>
        public virtual String QLFCode_r { get; set; }
        /// <summary>
        /// Предшествующая операция
        /// </summary>
        public virtual String OperationCode_r { get; set; }
        /// <summary>
        /// Следующая операция
        /// </summary>
        public virtual String MSCSelectNextOperation { get; set; }
        /// <summary>
        /// Признак виртуальной ТЕ
        /// </summary>
        public virtual Boolean MSCSelectIsVirtual { get; set; }
        /// <summary>
        /// Владелец
        /// </summary>
        public virtual WmsMandant MSCSelectOwner { get; set; }
        /// <summary>
        /// Полнота ТЕ по группе накладных
        /// </summary>
        public virtual Boolean MSCSelectTECompleteOWBGroup { get; set; }
        /// <summary>
        /// Несущая
        /// </summary>
        public virtual Boolean MSCSelectIsBase { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения 
    /// </summary>
    [Serializable]
    public partial class WmsQSupplyChainHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 QSupplyChainID { get; set; }
        /// <summary>
        /// Мандант
        /// </summary>
        public virtual Int32? PartnerID_r { get; set; }
        /// <summary>
        /// Группа резервирования
        /// </summary>
        public virtual Int32? ResGroup_r { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public virtual String StatusCode_r { get; set; }
        /// <summary>
        /// Предшествующая операция
        /// </summary>
        public virtual String OperationCode_r { get; set; }
        /// <summary>
        /// ТЕ
        /// </summary>
        public virtual String TECode_r { get; set; }
        /// <summary>
        /// Поставка
        /// </summary>
        public virtual Int32? SupplyChainID_r { get; set; }
        /// <summary>
        /// Процесс
        /// </summary>
        public virtual String QSupplyChainProcess { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения 
    /// </summary>
    [Serializable]
    public partial class WmsSupplyChainHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 SupplyChainID { get; set; }
        /// <summary>
        /// Менеджер поставок
        /// </summary>
        public virtual String MSCCode_r { get; set; }
        /// <summary>
        /// Исходная зона поставки
        /// </summary>
        public virtual String SupplyChainSourceSupplyArea { get; set; }
        /// <summary>
        /// Целевая зона поставки
        /// </summary>
        public virtual String SupplyChainTargetSupplyArea { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public virtual String StatusCode_r { get; set; }
        /// <summary>
        /// Предшествующая операция
        /// </summary>
        public virtual String OperationCode_r { get; set; }
        /// <summary>
        /// Требуемая операция
        /// </summary>
        public virtual String SupplyChainRequiredOperation { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Общий конфигуратор
    /// </summary>
    [Serializable]
    public partial class WmsGCHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Guid GCCode { get; set; }
        /// <summary>
        /// Сущность
        /// </summary>
        public virtual String GCEntity { get; set; }
        /// <summary>
        /// Экземпляр
        /// </summary>
        public virtual String GCKey { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Сущность к конфигуратору
    /// </summary>
    [Serializable]
    public partial class WmsEntity2GCHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 Entity2GCID { get; set; }
        /// <summary>
        /// Конфигуратор
        /// </summary>
        public virtual Guid GCCode_r { get; set; }
        /// <summary>
        /// Сущность
        /// </summary>
        public virtual String Entity2GCEntity { get; set; }
        /// <summary>
        /// Экземпляр
        /// </summary>
        public virtual String Entity2GCKey { get; set; }
        /// <summary>
        /// Атрибут сущности
        /// </summary>
        public virtual String Entity2GCAttr { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Запрос инвентаризации
    /// </summary>
    [Serializable]
    public partial class WmsInvReqHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 InvReqID { get; set; }
        /// <summary>
        /// Мандант
        /// </summary>
        public virtual WmsMandant Partner { get; set; }
        /// <summary>
        /// Инвентаризация
        /// </summary>
        public virtual Int32? InvID_r { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String InvReqName { get; set; }
        /// <summary>
        /// Плановая дата
        /// </summary>
        public virtual DateTime? InvReqDatePlan { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public virtual String StatusCode_r { get; set; }
        /// <summary>
        /// Хост-идентификатор
        /// </summary>
        public virtual String InvReqHostRef { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Позиции запроса на инвентаризацию
    /// </summary>
    [Serializable]
    public partial class WmsInvReqPosHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 InvReqPosID { get; set; }
        /// <summary>
        /// Запрос на инвентаризацию
        /// </summary>
        public virtual Int32 InvReqID_r { get; set; }
        /// <summary>
        /// Группа инвентаризации
        /// </summary>
        public virtual Int32? InvGroupID_r { get; set; }
        /// <summary>
        /// Номер позиции
        /// </summary>
        public virtual Int32 InvReqPosNumber { get; set; }
        /// <summary>
        /// Код артикула
        /// </summary>
        public virtual String ArtCode_r { get; set; }
        /// <summary>
        /// Клиентский артикул
        /// </summary>
        public virtual String InvReqPosArtName { get; set; }
        /// <summary>
        /// Клиентская ЕИ
        /// </summary>
        public virtual String InvReqPosMeasure { get; set; }
        /// <summary>
        /// Количество
        /// </summary>
        public virtual Int32? InvReqPosCount { get; set; }
        /// <summary>
        /// Хост-идентификатор
        /// </summary>
        public virtual String InvReqPosHostRef { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Менеджер приемки
    /// </summary>
    [Serializable]
    public partial class WmsMINHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 MINID { get; set; }
        /// <summary>
        /// Мандант
        /// </summary>
        public virtual WmsMandant Partner { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String MINName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String MINDesc { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Выбор менеджера приемки
    /// </summary>
    [Serializable]
    public partial class WmsMINSelectHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 MINSelectID { get; set; }
        /// <summary>
        /// Менеджер приемки
        /// </summary>
        public virtual Int32 MINID_r { get; set; }
        /// <summary>
        /// Приоритет
        /// </summary>
        public virtual Int32 Priority { get; set; }
        /// <summary>
        /// Мандант
        /// </summary>
        public virtual WmsMandant Partner { get; set; }
        /// <summary>
        /// Критерий приходной накладной
        /// </summary>
        public virtual String MINSelectCritOwb { get; set; }
        /// <summary>
        /// Тип приходной накладной
        /// </summary>
        public virtual String MINSelectIwbType { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Тип менеджера поставки
    /// </summary>
    [Serializable]
    public partial class WmsMSCTypeHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код
        /// </summary>
        public virtual String MSCTypeCode { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String MSCTypeName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String MSCTypeDesc { get; set; }
        /// <summary>
        /// Последовательность
        /// </summary>
        public virtual Int32 MSCTypeOrder { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Контроль срока годности
    /// </summary>
    [Serializable]
    public partial class WmsExpiryDateHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 ExpiryDateID { get; set; }
        /// <summary>
        /// Мандант
        /// </summary>
        public virtual WmsMandant Partner { get; set; }
        /// <summary>
        /// По накладной
        /// </summary>
        public virtual String ExpiryDateSelectOWB { get; set; }
        /// <summary>
        /// Приоритет
        /// </summary>
        public virtual Int32 Priority { get; set; }
        /// <summary>
        /// Тип контроля
        /// </summary>
        public virtual String ExpiryDateType { get; set; }
        /// <summary>
        /// Значение
        /// </summary>
        public virtual Int32? ExpiryDateValue { get; set; }
        /// <summary>
        /// Тип значения
        /// </summary>
        public virtual String ExpiryDateValueType { get; set; }
        /// <summary>
        /// Вариант использования
        /// </summary>
        public virtual String ExpiryDateUsingOption { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Этапы обработки
    /// </summary>
    [Serializable]
    public partial class WmsOperationStageHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код
        /// </summary>
        public virtual String OperationStageCode { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String OperationStageName { get; set; }
        /// <summary>
        /// Откуда
        /// </summary>
        public virtual Boolean OperationStageFrom { get; set; }
        /// <summary>
        /// Куда
        /// </summary>
        public virtual Boolean OperationStageTo { get; set; }
        /// <summary>
        /// Петля
        /// </summary>
        public virtual Boolean OperationStageLoop { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Позиции заявки на декларирование
    /// </summary>
    [Serializable]
    public partial class CstReqCustomsPosHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 ReqCustomsPosID { get; set; }
        /// <summary>
        /// Заявка на декларирование
        /// </summary>
        public virtual Int32 ReqCustomsId_r { get; set; }
        /// <summary>
        /// Номер позиции
        /// </summary>
        public virtual Int32 ReqCustomsPosNumber { get; set; }
        /// <summary>
        /// Артикул
        /// </summary>
        public virtual String ArtCode_r { get; set; }
        /// <summary>
        /// Количество
        /// </summary>
        public virtual Int32? ReqCustomsCount { get; set; }
        /// <summary>
        /// ТНВЭД
        /// </summary>
        public virtual String ReqCustomsTNVD { get; set; }
        /// <summary>
        /// Страна-производитель
        /// </summary>
        public virtual String CountryCode_r { get; set; }
        /// <summary>
        /// Стоимость
        /// </summary>
        public virtual Double? ReqCustomsAmount { get; set; }
        /// <summary>
        /// Брутто
        /// </summary>
        public virtual Double? ReqCustomsWeightGross { get; set; }
        /// <summary>
        /// Сертификат
        /// </summary>
        public virtual String ReqCustomsCertificate { get; set; }
        /// <summary>
        /// Дата сертификата
        /// </summary>
        public virtual DateTime? ReqCustomsCertificateDate { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Заявка к накладным
    /// </summary>
    [Serializable]
    public partial class CstReqCustoms2WBHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 ReqCustoms2WBId { get; set; }
        /// <summary>
        /// Заявка на декларирование
        /// </summary>
        public virtual Int32 ReqCustomsId_r { get; set; }
        /// <summary>
        /// Приходная накладная
        /// </summary>
        public virtual Int32? IWBID_r { get; set; }
        /// <summary>
        /// Расходная накладная
        /// </summary>
        public virtual Int32? OWBID_r { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Транспортные договора
    /// </summary>
    [Serializable]
    public partial class CstTransportContractHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 TransportContractId { get; set; }
        /// <summary>
        /// Заявка на декларирование
        /// </summary>
        public virtual Int32 ReqCustomsId_r { get; set; }
        /// <summary>
        /// Номер
        /// </summary>
        public virtual String TransportContractNumber { get; set; }
        /// <summary>
        /// Дата
        /// </summary>
        public virtual DateTime? TransportContractDate { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Документы на перевозку
    /// </summary>
    [Serializable]
    public partial class CstTransportDocumentHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 TransportDocumentId { get; set; }
        /// <summary>
        /// Заявка на декларирование
        /// </summary>
        public virtual Int32 ReqCustomsId_r { get; set; }
        /// <summary>
        /// Тип
        /// </summary>
        public virtual USERENUM_CSTTRANSPORTDOC_TYPE TransportDocumentType { get; set; }
        /// <summary>
        /// Номер
        /// </summary>
        public virtual String TransportDocumentNumber { get; set; }
        /// <summary>
        /// Дата
        /// </summary>
        public virtual DateTime? TransportDocumentDate { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Заявка на декларирование
    /// </summary>
    [Serializable]
    public partial class CstReqCustomsHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 ReqCustomsID { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public virtual String StatusCode_r { get; set; }
        /// <summary>
        /// Мандант
        /// </summary>
        public virtual WmsMandant Partner { get; set; }
        /// <summary>
        /// ВЭК
        /// </summary>
        public virtual String ReqCustomsContract { get; set; }
        /// <summary>
        /// Орган въезда/выезда
        /// </summary>
        public virtual Int32? ReqCustomsPost { get; set; }
        /// <summary>
        /// Дата
        /// </summary>
        public virtual DateTime? ReqCustomsPostDate { get; set; }
        /// <summary>
        /// Пост предыдущей выгрузки
        /// </summary>
        public virtual String ReqCustomsLastPost { get; set; }
        /// <summary>
        /// Дата предыдущей выгрузки
        /// </summary>
        public virtual DateTime? ReqCustomsLastPostDate { get; set; }
        /// <summary>
        /// Пост следующей выгрузки
        /// </summary>
        public virtual String ReqCustomsNextPost { get; set; }
        /// <summary>
        /// Номер TIR
        /// </summary>
        public virtual String ReqCustomsTIRNumber { get; set; }
        /// <summary>
        /// Дата TIR
        /// </summary>
        public virtual DateTime? ReqCustomsTIRDate { get; set; }
        /// <summary>
        /// Номер TTD
        /// </summary>
        public virtual String ReqCustomsTTDNumber { get; set; }
        /// <summary>
        /// Дата TTD
        /// </summary>
        public virtual DateTime? ReqCustomsTTDDate { get; set; }
        /// <summary>
        /// Идентификатор ТС на границе
        /// </summary>
        public virtual String ReqCustomsVehicleOutRef { get; set; }
        /// <summary>
        /// Код ТС на границе
        /// </summary>
        public virtual String ReqCustomsVehicleOutCode { get; set; }
        /// <summary>
        /// Страна ТС на границе
        /// </summary>
        public virtual String ReqCustomsVehicleOutCountry { get; set; }
        /// <summary>
        /// Идентификатор ТС внутри страны
        /// </summary>
        public virtual String ReqCustomsVehicleInRef { get; set; }
        /// <summary>
        /// Код ТС внутри страны
        /// </summary>
        public virtual String ReqCustomsVehicleInCode { get; set; }
        /// <summary>
        /// Страна ТС внутри страны
        /// </summary>
        public virtual String ReqCustomsVehicleInCountry { get; set; }
        /// <summary>
        /// Пломба
        /// </summary>
        public virtual String ReqCustomsVehicleStamp { get; set; }
        /// <summary>
        /// Условия поставки
        /// </summary>
        public virtual String ReqCustomsDeliveryConditions { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения 
    /// </summary>
    [Serializable]
    public partial class WmsRes2SupplyChainHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 Res2SupplyChainID { get; set; }
        /// <summary>
        /// Резервирование
        /// </summary>
        public virtual Int32 ResID_r { get; set; }
        /// <summary>
        /// Поставка
        /// </summary>
        public virtual Int32 SupplyChainID_r { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Адреса работников
    /// </summary>
    [Serializable]
    public partial class WmsWorker2AddressBookHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID работника
        /// </summary>
        public virtual Int32 WorkerID_r { get; set; }
        /// <summary>
        /// ID адреса
        /// </summary>
        public virtual Int32 AddressBookID_r { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Типы клиентов
    /// </summary>
    [Serializable]
    public partial class SysClientTypeHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код типа системы
        /// </summary>
        public virtual String ClientTypeCode { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String ClientTypeName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String ClientTypeDesc { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Работа
    /// </summary>
    [Serializable]
    public partial class WmsWorkHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 WorkID { get; set; }
        /// <summary>
        /// Группа
        /// </summary>
        public virtual Int32? WorkGroupID_r { get; set; }
        /// <summary>
        /// Операция
        /// </summary>
        public virtual String OperationCode_r { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String WorkDesc { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public virtual String StatusCode_r { get; set; }
        /// <summary>
        /// Клиентская сессия
        /// </summary>
        public virtual Int32 ClientSessionID_r { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Работник к группе
    /// </summary>
    [Serializable]
    public partial class WmsWorker2GroupHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 Worker2GroupID { get; set; }
        /// <summary>
        /// Группа работников
        /// </summary>
        public virtual Int32 WorkerGroupID_r { get; set; }
        /// <summary>
        /// Работник
        /// </summary>
        public virtual Int32 WorkerID_r { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Работники к складам
    /// </summary>
    [Serializable]
    public partial class WmsWorker2WarehouseHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 Worker2WarehouseID { get; set; }
        /// <summary>
        /// Группа работников
        /// </summary>
        public virtual Int32? WorkerGroupID_r { get; set; }
        /// <summary>
        /// Работник
        /// </summary>
        public virtual Int32? WorkerID_r { get; set; }
        /// <summary>
        /// Склад
        /// </summary>
        public virtual String WarehouseCode_r { get; set; }
        /// <summary>
        /// Дата с
        /// </summary>
        public virtual DateTime Worker2WarehouseFrom { get; set; }
        /// <summary>
        /// Дата по
        /// </summary>
        public virtual DateTime Worker2WarehouseTill { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Группа работников
    /// </summary>
    [Serializable]
    public partial class WmsWorkerGroupHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 WorkerGroupID { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String WorkerGroupName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String WorkerGroupDesc { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Справочник работников
    /// </summary>
    [Serializable]
    public partial class WmsWorkerHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 WorkerID { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public virtual String WorkerLastName { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        public virtual String WorkerName { get; set; }
        /// <summary>
        /// Отчество
        /// </summary>
        public virtual String WorkerMiddleName { get; set; }
        /// <summary>
        /// Сотрудник
        /// </summary>
        public virtual Boolean WorkerEmployee { get; set; }
        /// <summary>
        /// Рабочий телефон
        /// </summary>
        public virtual String WorkerPhoneWork { get; set; }
        /// <summary>
        /// Мобильный
        /// </summary>
        public virtual String WorkerPhoneMobile { get; set; }
        /// <summary>
        /// Рабочий email
        /// </summary>
        public virtual String WorkerEmailWork { get; set; }
        /// <summary>
        /// Личный email
        /// </summary>
        public virtual String WorkerEmailPersonal { get; set; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public virtual DateTime? WorkerBirthday { get; set; }
        /// <summary>
        /// Системный пользователь
        /// </summary>
        public virtual WmsUser User { get; set; }
        /// <summary>
        /// Фото
        /// </summary>
        public virtual String WorkerPhoto { get; set; }
        /// <summary>
        /// PIN
        /// </summary>
        public virtual String WorkerPIN { get; set; }
        /// <summary>
        /// Адрес прописки
        /// </summary>
        public virtual String WorkerResidenceAddr { get; set; }
        /// <summary>
        /// Согласие обработки персональных данных
        /// </summary>
        public virtual DateTime? WorkerProcPersData { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Удостоверяющий документ
    /// </summary>
    [Serializable]
    public partial class WmsWorkerPassHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 WorkerPassID { get; set; }
        /// <summary>
        /// Работник
        /// </summary>
        public virtual Int32 WorkerID_r { get; set; }
        /// <summary>
        /// Документ
        /// </summary>
        public virtual USERENUM_PASSPORTTYPE_TYPE WorkerPassType { get; set; }
        /// <summary>
        /// Серия документа
        /// </summary>
        public virtual String WorkerPassSeries { get; set; }
        /// <summary>
        /// Номер документа
        /// </summary>
        public virtual String WorkerPassNumber { get; set; }
        /// <summary>
        /// Дата получения
        /// </summary>
        public virtual DateTime? WorkerPassReceipt { get; set; }
        /// <summary>
        /// Кем выдан
        /// </summary>
        public virtual String WorkerPassAgency { get; set; }
        /// <summary>
        /// Страна
        /// </summary>
        public virtual IsoCountry Country { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Работа к сущности
    /// </summary>
    [Serializable]
    public partial class WmsWork2EntityHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 Work2EntityID { get; set; }
        /// <summary>
        /// Работа
        /// </summary>
        public virtual Int32 WorkID_r { get; set; }
        /// <summary>
        /// Сущность
        /// </summary>
        public virtual String Work2EntityEntity { get; set; }
        /// <summary>
        /// Экземпляр сущности
        /// </summary>
        public virtual String Work2EntityKey { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Выполнение работ
    /// </summary>
    [Serializable]
    public partial class WmsWorkingHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 WorkingID { get; set; }
        /// <summary>
        /// Работа
        /// </summary>
        public virtual Int32 WorkID_r { get; set; }
        /// <summary>
        /// Группа работников
        /// </summary>
        public virtual Int32? WorkerGroupID_r { get; set; }
        /// <summary>
        /// Работник
        /// </summary>
        public virtual Int32 WorkerID_r { get; set; }
        /// <summary>
        /// Дата с
        /// </summary>
        public virtual DateTime WorkingFrom { get; set; }
        /// <summary>
        /// Дата по
        /// </summary>
        public virtual DateTime? WorkingTill { get; set; }
        /// <summary>
        /// Коэффициент участия
        /// </summary>
        public virtual Int32 WorkingMult { get; set; }
        /// <summary>
        /// Обработанные единицы
        /// </summary>
        public virtual Int32? WorkingCount { get; set; }
        /// <summary>
        /// ЕИ
        /// </summary>
        public virtual String WorkingMeasure { get; set; }
        /// <summary>
        /// Погрузчик
        /// </summary>
        public virtual String TruckCode_r { get; set; }
        /// <summary>
        /// Дополнительный
        /// </summary>
        public virtual Boolean? WorkingAddl { get; set; }
        /// <summary>
        /// Ошибки
        /// </summary>
        public virtual Int32? WorkingError { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual String WorkingDoc { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Клиенты
    /// </summary>
    [Serializable]
    public partial class SysClientHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код системы
        /// </summary>
        public virtual String ClientCode { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String ClientName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String ClientDesc { get; set; }
        /// <summary>
        /// MAC-адрес
        /// </summary>
        public virtual String ClientMac { get; set; }
        /// <summary>
        /// IP адрес
        /// </summary>
        public virtual String ClientIP { get; set; }
        /// <summary>
        /// Погрузчик по умолчанию
        /// </summary>
        public virtual String TruckCode_r { get; set; }
        /// <summary>
        /// Версия ОС
        /// </summary>
        public virtual String ClientOSVersion { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Сессии подключения
    /// </summary>
    [Serializable]
    public partial class SysClientSessionHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 ClientSessionID { get; set; }
        /// <summary>
        /// Код пользователя
        /// </summary>
        public virtual WmsUser User { get; set; }
        /// <summary>
        /// Код системы
        /// </summary>
        public virtual String ClientCode_r { get; set; }
        /// <summary>
        /// Начало сессии
        /// </summary>
        public virtual DateTime ClientSessionBegin { get; set; }
        /// <summary>
        /// Окончание сессии
        /// </summary>
        public virtual DateTime? ClientSessionEnd { get; set; }
        /// <summary>
        /// Код экземпляра приложения
        /// </summary>
        public virtual String ClientSessionAppKey { get; set; }
        /// <summary>
        /// Корректное завершение работы
        /// </summary>
        public virtual Boolean? ClientSessionCorrectlyOff { get; set; }
        /// <summary>
        /// Код типа системы
        /// </summary>
        public virtual String ClientTypeCode_r { get; set; }
        /// <summary>
        /// Погрузчик
        /// </summary>
        public virtual String TruckCode_r { get; set; }
        /// <summary>
        /// Работник
        /// </summary>
        public virtual Int32? WorkerID_r { get; set; }
        /// <summary>
        /// Домен / Имя пользователя
        /// </summary>
        public virtual String ClientSessionUserDomainName { get; set; }
        /// <summary>
        /// Версия клиента
        /// </summary>
        public virtual String ClientSessionClientVersion { get; set; }
        /// <summary>
        /// Имя и код клиента
        /// </summary>
        public virtual String ClientSessionServiceID { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Сущность к выполнению работ
    /// </summary>
    [Serializable]
    public partial class WmsW2E2WorkingHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 W2E2WorkingID { get; set; }
        /// <summary>
        /// Выполненная работа
        /// </summary>
        public virtual Int32 WorkingID_r { get; set; }
        /// <summary>
        /// Работа к сущности
        /// </summary>
        public virtual Int32 Work2EntityID_r { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Правила обработки
    /// </summary>
    [Serializable]
    public partial class WmsRuleHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 RuleID { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String RuleName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String RuleDesc { get; set; }
        /// <summary>
        /// Выполняемая операция
        /// </summary>
        public virtual String OperationCode_r { get; set; }
        /// <summary>
        /// Идентификатор в хост-системе
        /// </summary>
        public virtual String RuleHostRef { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Параметры правил
    /// </summary>
    [Serializable]
    public partial class WmsRuleParamHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 RuleParamID { get; set; }
        /// <summary>
        /// Правило
        /// </summary>
        public virtual Int32 RuleID_r { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String RuleParamName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String RuleParamDesc { get; set; }
        /// <summary>
        /// Тип данных
        /// </summary>
        public virtual Int32 RuleParamDataType { get; set; }
        /// <summary>
        /// Обязательный пвараметр
        /// </summary>
        public virtual Boolean RuleParamMustSet { get; set; }
        /// <summary>
        /// Формат отображения
        /// </summary>
        public virtual String RuleParamFormat { get; set; }
        /// <summary>
        /// Lookup
        /// </summary>
        public virtual String ObjectLookupCode_r { get; set; }
        /// <summary>
        /// Значение по-умолчанию
        /// </summary>
        public virtual String RuleParamDefault { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Настройка правил
    /// </summary>
    [Serializable]
    public partial class WmsRuleConfigHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 RuleConfigID { get; set; }
        /// <summary>
        /// Мандант
        /// </summary>
        public virtual WmsMandant Partner { get; set; }
        /// <summary>
        /// Правило
        /// </summary>
        public virtual Int32 RuleID_r { get; set; }
        /// <summary>
        /// Операция
        /// </summary>
        public virtual String OperationCode_r { get; set; }
        /// <summary>
        /// Последовательность
        /// </summary>
        public virtual Int32 RuleConfigOrder { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Выполнение правил
    /// </summary>
    [Serializable]
    public partial class WmsRuleExecHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 RuleExecID { get; set; }
        /// <summary>
        /// Правило
        /// </summary>
        public virtual Int32 RuleID_r { get; set; }
        /// <summary>
        /// Выполнение работ
        /// </summary>
        public virtual Int32? WorkingID_r { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Параметры выполнения правил
    /// </summary>
    [Serializable]
    public partial class WmsRuleExecParamHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 RuleExecParamID { get; set; }
        /// <summary>
        /// Выполняемое правило
        /// </summary>
        public virtual Int32 RuleExecID_r { get; set; }
        /// <summary>
        /// Параметр
        /// </summary>
        public virtual Int32 RuleParamID_r { get; set; }
        /// <summary>
        /// Значение
        /// </summary>
        public virtual String RuleExecParamValue { get; set; }
        /// <summary>
        /// ПРимечание
        /// </summary>
        public virtual String RuleExecParamNote { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Календарь
    /// </summary>
    [Serializable]
    public partial class WmsCalendarHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 CalendarID { get; set; }
        /// <summary>
        /// Дата
        /// </summary>
        public virtual DateTime CalendarDate { get; set; }
        /// <summary>
        /// День недели
        /// </summary>
        public virtual Int32 CalendarDayOfWeek { get; set; }
        /// <summary>
        /// Время с
        /// </summary>
        public virtual DateTime CalendarTimeFrom { get; set; }
        /// <summary>
        /// Время по
        /// </summary>
        public virtual DateTime CalendarTimeTill { get; set; }
        /// <summary>
        /// Тип времени
        /// </summary>
        public virtual String CalendarType { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Календарь к манданту
    /// </summary>
    [Serializable]
    public partial class WmsCalendar2MandantHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 Calendar2MandantID { get; set; }
        /// <summary>
        /// Календарь
        /// </summary>
        public virtual Int32 CalendarID_r { get; set; }
        /// <summary>
        /// Мандант
        /// </summary>
        public virtual WmsMandant Partner { get; set; }
        /// <summary>
        /// Тип времени
        /// </summary>
        public virtual String Calendar2MandantType { get; set; }
        /// <summary>
        /// Сверхурочное
        /// </summary>
        public virtual Boolean? Calendar2MandantOverTime { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Группа работ
    /// </summary>
    [Serializable]
    public partial class WmsWorkGroupHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 WorkGroupID { get; set; }
        /// <summary>
        /// Мандант
        /// </summary>
        public virtual WmsMandant Partner { get; set; }
        /// <summary>
        /// Группа
        /// </summary>
        public virtual String WorkGroupCode { get; set; }
        /// <summary>
        /// Тип
        /// </summary>
        public virtual String WorkGroupType { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Тип работ
    /// </summary>
    [Serializable]
    public partial class WmsWTSelectHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 WTSelectID { get; set; }
        /// <summary>
        /// Мандант
        /// </summary>
        public virtual WmsMandant Partner { get; set; }
        /// <summary>
        /// Операция
        /// </summary>
        public virtual String OperationCode_r { get; set; }
        /// <summary>
        /// Требуется документ
        /// </summary>
        public virtual Boolean? WTSelectDoc { get; set; }
        /// <summary>
        /// Требуется ввод количества
        /// </summary>
        public virtual Boolean? WTSelectValue { get; set; }
        /// <summary>
        /// ЕИ
        /// </summary>
        public virtual String WTSelectValueType { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Черный список
    /// </summary>
    [Serializable]
    public partial class WmsBlackListHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 BlackListID { get; set; }
        /// <summary>
        /// Работник
        /// </summary>
        public virtual Int32 WorkerID_r { get; set; }
        /// <summary>
        /// Дата нарушения
        /// </summary>
        public virtual DateTime BlackListDate { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String BlackListDesk { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Марки автомобилей
    /// </summary>
    [Serializable]
    public partial class WmsCarTypeHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 CarTypeID { get; set; }
        /// <summary>
        /// Марка
        /// </summary>
        public virtual String CarTypeMark { get; set; }
        /// <summary>
        /// Модель
        /// </summary>
        public virtual String CarTypeModel { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String CarTypeDesc { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Парковочные места
    /// </summary>
    [Serializable]
    public partial class YParkingHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 ParkingID { get; set; }
        /// <summary>
        /// Номер парковочного места
        /// </summary>
        public virtual String ParkingNumber { get; set; }
        /// <summary>
        /// Наименование места
        /// </summary>
        public virtual String ParkingName { get; set; }
        /// <summary>
        /// Парковочная зона
        /// </summary>
        public virtual USERENUM_CAR_PARKINGAREA ParkingArea { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Справочник автомобилей
    /// </summary>
    [Serializable]
    public partial class YVehicleHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 VehicleID { get; set; }
        /// <summary>
        /// Марка и модель
        /// </summary>
        public virtual Int32? CarTypeID_r { get; set; }
        /// <summary>
        /// Рег.ном.
        /// </summary>
        public virtual String VehicleRN { get; set; }
        /// <summary>
        /// VIN
        /// </summary>
        public virtual String VehicleVIN { get; set; }
        /// <summary>
        /// Цвет
        /// </summary>
        public virtual USERENUM_CAR_COLOR VehicleColor { get; set; }
        /// <summary>
        /// Разреш. max масса
        /// </summary>
        public virtual Decimal? VehicleMaxWeight { get; set; }
        /// <summary>
        /// Масса без нагрузки
        /// </summary>
        public virtual Decimal? VehicleEmptyWeight { get; set; }
        /// <summary>
        /// Тип автомобиля
        /// </summary>
        public virtual USERENUM_CAR_TYPE VehicleType { get; set; }
        /// <summary>
        /// Рег.ном. прицепа
        /// </summary>
        public virtual String VehicleTrailerRN { get; set; }
        /// <summary>
        /// Разреш. max масса прицепа
        /// </summary>
        public virtual Decimal? VehicleTrailerMaxWeight { get; set; }
        /// <summary>
        /// Масса прицепа без нагрузки
        /// </summary>
        public virtual Decimal? VehicleTrailerEmptyWeight { get; set; }
        /// <summary>
        /// Рег.ном. полуприцепа
        /// </summary>
        public virtual String VehicleSemiTrailerRN { get; set; }
        /// <summary>
        /// Разреш. max масса полуприцепа
        /// </summary>
        public virtual Decimal? VehicleSemiTrailerMaxWeight { get; set; }
        /// <summary>
        /// Масса полуприцепа без нагрузки
        /// </summary>
        public virtual Decimal? VehicleSemiTrailerEmptyWeight { get; set; }
        /// <summary>
        /// Владелец ЮР
        /// </summary>
        public virtual Int32? VehicleOwnerLegal { get; set; }
        /// <summary>
        /// Владелец ФИЗ
        /// </summary>
        public virtual Int32? VehiclePerson { get; set; }
        /// <summary>
        /// Владелец
        /// </summary>
        public virtual String VehicleOwner { get; set; }
        /// <summary>
        /// Адрес владельца
        /// </summary>
        public virtual String VehicleOwnerAddr { get; set; }
        /// <summary>
        /// Ref
        /// </summary>
        public virtual String VehicleHostRef { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Рейс
    /// </summary>
    [Serializable]
    public partial class YExternalTrafficHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 ExternalTrafficID { get; set; }
        /// <summary>
        /// Автомобиль
        /// </summary>
        public virtual Int32? VehicleID_r { get; set; }
        /// <summary>
        /// Прицеп
        /// </summary>
        public virtual String ExternalTrafficTrailerRN { get; set; }
        /// <summary>
        /// Прибытие, план
        /// </summary>
        public virtual DateTime? ExternalTrafficPlanArrived { get; set; }
        /// <summary>
        /// Прибытие, факт
        /// </summary>
        public virtual DateTime? ExternalTrafficFactArrived { get; set; }
        /// <summary>
        /// Убытие, факт
        /// </summary>
        public virtual DateTime? ExternalTrafficFactDeparted { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public virtual String StatusCode_r { get; set; }
        /// <summary>
        /// Водитель
        /// </summary>
        public virtual Int32? ExternalTrafficDriver { get; set; }
        /// <summary>
        /// Документ водителя
        /// </summary>
        public virtual Int32? WorkerPassID_r { get; set; }
        /// <summary>
        /// Экспедитор
        /// </summary>
        public virtual Int32? ExternalTrafficForvarder { get; set; }
        /// <summary>
        /// Перевозчик
        /// </summary>
        public virtual Int32? ExternalTrafficCarrier { get; set; }
        /// <summary>
        /// Место стоянки
        /// </summary>
        public virtual Int32? ParkingID_r { get; set; }
        /// <summary>
        /// Номер пропуска
        /// </summary>
        public virtual String ExternalTrafficPassNumber { get; set; }
        /// <summary>
        /// Ref
        /// </summary>
        public virtual String ExternalTrafficHostRef { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String ExternalTrafficDesc { get; set; }
        /// <summary>
        /// Подтвержден
        /// </summary>
        public virtual Boolean? ExternalTrafficVerified { get; set; }
        /// <summary>
        /// Примечание
        /// </summary>
        public virtual String ExternalTrafficComment { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Маршрут
    /// </summary>
    [Serializable]
    public partial class YRouteHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 RouteID { get; set; }
        /// <summary>
        /// Мандант
        /// </summary>
        public virtual WmsMandant Partner { get; set; }
        /// <summary>
        /// Маршрут
        /// </summary>
        public virtual String RouteNumber { get; set; }
        /// <summary>
        /// Менеджер маршрута
        /// </summary>
        public virtual Int32? MgRouteID_r { get; set; }
        /// <summary>
        /// Дата
        /// </summary>
        public virtual DateTime RouteDate { get; set; }
        /// <summary>
        /// Ворота
        /// </summary>
        public virtual String GateCode_r { get; set; }
        /// <summary>
        /// Идентификатор в хост-системе
        /// </summary>
        public virtual String RouteHostRef { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Менеджер маршрутов
    /// </summary>
    [Serializable]
    public partial class YMgRouteHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 MgRouteID { get; set; }
        /// <summary>
        /// Мандант
        /// </summary>
        public virtual WmsMandant Partner { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String MgRouteName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String MgRouteDesc { get; set; }
        /// <summary>
        /// Маршрут
        /// </summary>
        public virtual String MgRouteNumber { get; set; }
        /// <summary>
        /// Ворота
        /// </summary>
        public virtual String GateCode_r { get; set; }
        /// <summary>
        /// Создавать маршруты
        /// </summary>
        public virtual Boolean MgRouteCreateRoute { get; set; }
        /// <summary>
        /// Идентификатор в хост-системе
        /// </summary>
        public virtual String MgRouteHostRef { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Выбор менеджера маршрутов
    /// </summary>
    [Serializable]
    public partial class YMgRouteSelectHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 MgRouteSelectID { get; set; }
        /// <summary>
        /// Менеджер маршрутов
        /// </summary>
        public virtual Int32 MgRouteID_r { get; set; }
        /// <summary>
        /// Приоритет
        /// </summary>
        public virtual Int32 Priority { get; set; }
        /// <summary>
        /// Мандант
        /// </summary>
        public virtual WmsMandant Partner { get; set; }
        /// <summary>
        /// Регион
        /// </summary>
        public virtual String MgRouteSelectRegion { get; set; }
        /// <summary>
        /// Перевозчик
        /// </summary>
        public virtual WmsMandant OWBCarrier { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Выбор даты маршрута
    /// </summary>
    [Serializable]
    public partial class YMgRouteDateSelectHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 MgRouteDateSelectID { get; set; }
        /// <summary>
        /// Приоритет
        /// </summary>
        public virtual Int32 Priority { get; set; }
        /// <summary>
        /// Мандант
        /// </summary>
        public virtual WmsMandant Partner { get; set; }
        /// <summary>
        /// Регион
        /// </summary>
        public virtual String MgRouteDateSelectRegion { get; set; }
        /// <summary>
        /// Время с
        /// </summary>
        public virtual DateTime? MgRouteDateSelectFrom { get; set; }
        /// <summary>
        /// Время по
        /// </summary>
        public virtual DateTime? MgRouteDateSelectTill { get; set; }
        /// <summary>
        /// Источник времени
        /// </summary>
        public virtual String MgRouteDateSelectDateSource { get; set; }
        /// <summary>
        /// Конечны получатель
        /// </summary>
        public virtual Int32? MgRouteDateSelectFinRecipient { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Цель визита
    /// </summary>
    [Serializable]
    public partial class YPurposeVisitHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 PurposeVisitID { get; set; }
        /// <summary>
        /// Код
        /// </summary>
        public virtual String PurposeVisitCode { get; set; }
        /// <summary>
        /// Цель
        /// </summary>
        public virtual String PurposeVisitName { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Документы автомобиля
    /// </summary>
    [Serializable]
    public partial class YVehiclePassHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 VehiclePassID { get; set; }
        /// <summary>
        /// Автомобиль
        /// </summary>
        public virtual Int32 VehicleID_r { get; set; }
        /// <summary>
        /// Тип документа
        /// </summary>
        public virtual USERENUM_VEHICLEDOC_TYPE VehiclePassType { get; set; }
        /// <summary>
        /// Серия
        /// </summary>
        public virtual String VehiclePassSeries { get; set; }
        /// <summary>
        /// Номер
        /// </summary>
        public virtual String VehiclePassNumber { get; set; }
        /// <summary>
        /// Выдан
        /// </summary>
        public virtual DateTime? VehiclePassReceipt { get; set; }
        /// <summary>
        /// Кем выдан
        /// </summary>
        public virtual String VehiclePassAgency { get; set; }
        /// <summary>
        /// Страна
        /// </summary>
        public virtual String CountryCode_r { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Заявка на пропуск
    /// </summary>
    [Serializable]
    public partial class YPassRequestHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 PassRequestID { get; set; }
        /// <summary>
        /// Документ
        /// </summary>
        public virtual String WorkerPassNumber { get; set; }
        /// <summary>
        /// Документ
        /// </summary>
        public virtual Int32? WorkerPassID_r { get; set; }
        /// <summary>
        /// ФИО
        /// </summary>
        public virtual String WorkerFio { get; set; }
        /// <summary>
        /// Водитель
        /// </summary>
        public virtual Int32? WorkerID_r { get; set; }
        /// <summary>
        /// № ТС
        /// </summary>
        public virtual String VehicleNumber { get; set; }
        /// <summary>
        /// ТС
        /// </summary>
        public virtual Int32? VehicleID_r { get; set; }
        /// <summary>
        /// № прицепа
        /// </summary>
        public virtual String VehicleTrailerNumber { get; set; }
        /// <summary>
        /// Телефон
        /// </summary>
        public virtual String PhoneNumber { get; set; }
        /// <summary>
        /// Прибытие план
        /// </summary>
        public virtual DateTime? ArrivalDatePlan { get; set; }
        /// <summary>
        /// Проект
        /// </summary>
        public virtual WmsMandant Mandant { get; set; }
        /// <summary>
        /// Цель
        /// </summary>
        public virtual Int32? PurposeVisitID_r { get; set; }
        /// <summary>
        /// Номер пропуска
        /// </summary>
        public virtual String PassNumber { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public virtual PassRequestStates State { get; set; }
        /// <summary>
        /// Разрешил въезд
        /// </summary>
        public virtual Int32? WorkerAcceptEntry { get; set; }
        /// <summary>
        /// Выписал пропуск
        /// </summary>
        public virtual Int32? WorkerWritePass { get; set; }
        /// <summary>
        /// Закрыл пропуск
        /// </summary>
        public virtual Int32? WorkerClosePass { get; set; }
        /// <summary>
        /// Примечание
        /// </summary>
        public virtual String PassRequestComment { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        /// <summary>
        /// Склад
        /// </summary>
        public virtual String WarehouseCode_r { get; set; }
        /// <summary>
        /// Офис
        /// </summary>
        public virtual Int32? WarehouseOfficeID_r { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Внутренний рейс
    /// </summary>
    [Serializable]
    public partial class YInternalTrafficHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 InternalTrafficID { get; set; }
        /// <summary>
        /// Рейс
        /// </summary>
        public virtual Int32 ExternalTrafficID_r { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public virtual String StatusCode_r { get; set; }
        /// <summary>
        /// Мандант
        /// </summary>
        public virtual WmsMandant Partner { get; set; }
        /// <summary>
        /// Склад
        /// </summary>
        public virtual String WarehouseCode_r { get; set; }
        /// <summary>
        /// Цель
        /// </summary>
        public virtual Int32 PurposeVisitID_r { get; set; }
        /// <summary>
        /// Ворота
        /// </summary>
        public virtual String GateCode_r { get; set; }
        /// <summary>
        /// Прибытие, факт
        /// </summary>
        public virtual DateTime? InternalTrafficFactArrived { get; set; }
        /// <summary>
        /// Убытие, факт
        /// </summary>
        public virtual DateTime? InternalTrafficFactDeparted { get; set; }
        /// <summary>
        /// Очередь
        /// </summary>
        public virtual Int32? InternalTrafficOrder { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        /// <summary>
        /// Офис
        /// </summary>
        public virtual Int32? WarehouseOfficeID_r { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Товар к базовой 
    /// </summary>
    [Serializable]
    public partial class WmsSKU2BaseHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// SKU
        /// </summary>
        public virtual Int32 SKUID { get; set; }
        /// <summary>
        /// Непосредственная родительская SKU
        /// </summary>
        public virtual Int32? SKUParent { get; set; }
        /// <summary>
        /// Родительская SKU в дереве
        /// </summary>
        public virtual Int32 SKUParentRoot { get; set; }
        /// <summary>
        /// Базовая SKU
        /// </summary>
        public virtual Int32? SKUBase { get; set; }
        /// <summary>
        /// Кол-во в SKU по отношению к родительской
        /// </summary>
        public virtual Double? SKUCount { get; set; }
        /// <summary>
        /// Кол-во в SKU по отношению к базовой
        /// </summary>
        public virtual Double? SKUCountBase { get; set; }
        /// <summary>
        /// Признак базовой SKU
        /// </summary>
        public virtual Boolean? SKUPrimary { get; set; }
        /// <summary>
        /// Признак неделимости
        /// </summary>
        public virtual Boolean? SKUIndivisible { get; set; }
        /// <summary>
        /// Артикул
        /// </summary>
        public virtual String ArtCode_r { get; set; }
        /// <summary>
        /// Единица измерения
        /// </summary>
        public virtual String MeasureCode_r { get; set; }
        /// <summary>
        /// Наименование SKU
        /// </summary>
        public virtual String SKUName { get; set; }
        /// <summary>
        /// Level в дереве SKU
        /// </summary>
        public virtual Int32? SKULevel { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Отношение менеджера товара к артикулам и группам артикулов
    /// </summary>
    [Serializable]
    public partial class WmsPM2ArtHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 PM2ArtID { get; set; }
        /// <summary>
        /// Код артикула
        /// </summary>
        public virtual String ArtCode_r { get; set; }
        /// <summary>
        /// Код группы артикулов
        /// </summary>
        public virtual String ArtGroupCode_r { get; set; }
        /// <summary>
        /// Код менеджера товара
        /// </summary>
        public virtual String PMCode_r { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Менеджер товара
    /// </summary>
    [Serializable]
    public partial class WmsPMHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код менеджера товара
        /// </summary>
        public virtual String PMCode { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String PMName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String PMDesc { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Тип комплекта
    /// </summary>
    [Serializable]
    public partial class WmsKitTypeHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код типа комплекта
        /// </summary>
        public virtual String KitTypeCode { get; set; }
        /// <summary>
        /// Наименование типа комплекта
        /// </summary>
        public virtual String KitTypeName { get; set; }
        /// <summary>
        /// Описание типа комплекта
        /// </summary>
        public virtual String KitTypeDesc { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Комплект
    /// </summary>
    [Serializable]
    public partial class WmsKitHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код комплекта
        /// </summary>
        public virtual String KitCode { get; set; }
        /// <summary>
        /// Код типа комплекта
        /// </summary>
        public virtual String KitTypeCode_r { get; set; }
        /// <summary>
        /// Код артикула
        /// </summary>
        public virtual String ArtCode_r { get; set; }
        /// <summary>
        /// Приоритет при приемке
        /// </summary>
        public virtual Int32 KitPriorityIn { get; set; }
        /// <summary>
        /// Приоритет при выдаче
        /// </summary>
        public virtual Int32 KitPriorityOut { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Способы обработки
    /// </summary>
    [Serializable]
    public partial class WmsPMMethodHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код способа обработки
        /// </summary>
        public virtual String PMMethodCode { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String PMMethodName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String PMMethodDesc { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Операции к менеджеру товара
    /// </summary>
    [Serializable]
    public partial class WmsPM2OperationHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код пересечения
        /// </summary>
        public virtual String PM2OperationCode { get; set; }
        /// <summary>
        /// Код менеджера товара
        /// </summary>
        public virtual String PMCode_r { get; set; }
        /// <summary>
        /// Код операции
        /// </summary>
        public virtual String OperationCode_r { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Коммерческий акт
    /// </summary>
    [Serializable]
    public partial class WmsCommActHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 CommActID { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String CommActName { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public virtual String StatusCode_r { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String CommActDesc { get; set; }
        /// <summary>
        /// Мандант
        /// </summary>
        public virtual WmsMandant Partner { get; set; }
        /// <summary>
        /// Ссылка на инвентаризацию
        /// </summary>
        public virtual String Invid_r { get; set; }
        /// <summary>
        /// Подтверждено СТН
        /// </summary>
        public virtual Boolean CommActWTVConfirm { get; set; }
        /// <summary>
        /// Причина корректировки
        /// </summary>
        public virtual Int32? AdjustmentReasonID_r { get; set; }
        /// <summary>
        /// Описание присины корректировки
        /// </summary>
        public virtual String CommActA4RDesc { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Группы артикулов
    /// </summary>
    [Serializable]
    public partial class WmsArtGroupHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код группы артикулов
        /// </summary>
        public virtual String ArtGroupCode { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String ArtGroupName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String ArtGroupDesc { get; set; }
        /// <summary>
        /// Критерий пикинга
        /// </summary>
        public virtual String ArtGroupCritPL { get; set; }
        /// <summary>
        /// Критерий поставки
        /// </summary>
        public virtual String ArtGroupCritMSC { get; set; }
        /// <summary>
        /// Критерий перемещения
        /// </summary>
        public virtual String ArtGroupCritMM { get; set; }
        /// <summary>
        /// Batch-критерий
        /// </summary>
        public virtual String ArtGroupCritBatch { get; set; }
        /// <summary>
        /// Критерий контроля веса
        /// </summary>
        public virtual String ArtGroupCritWC { get; set; }
        /// <summary>
        /// Тип группы
        /// </summary>
        public virtual String ArtGroupType { get; set; }
        /// <summary>
        /// Мандант
        /// </summary>
        public virtual WmsMandant Partner { get; set; }
        /// <summary>
        /// Хост-идентификатор
        /// </summary>
        public virtual String ArtGroupHostRef { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Справочник штрих-кодов
    /// </summary>
    [Serializable]
    public partial class WmsBarcodeHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 BarcodeID { get; set; }
        /// <summary>
        /// Связь с сущностью
        /// </summary>
        public virtual String Barcode2Entity { get; set; }
        /// <summary>
        /// Код экземпляра сущности
        /// </summary>
        public virtual String BarcodeKey { get; set; }
        /// <summary>
        /// ШК
        /// </summary>
        public virtual String BarcodeValue { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Справочник артикулов
    /// </summary>
    [Serializable]
    public partial class WmsArtHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код
        /// </summary>
        public virtual String ArtCode { get; set; }
        /// <summary>
        /// Артикул
        /// </summary>
        public virtual String ArtName { get; set; }
        /// <summary>
        /// Фабрика
        /// </summary>
        public virtual Int32? FactoryID_r { get; set; }
        /// <summary>
        /// Мандант
        /// </summary>
        public virtual WmsMandant Partner { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String ArtDesc { get; set; }
        /// <summary>
        /// Расширенное описание
        /// </summary>
        public virtual String ArtDescExt { get; set; }
        /// <summary>
        /// ABCD
        /// </summary>
        public virtual Char ArtABCD { get; set; }
        /// <summary>
        /// Цвет
        /// </summary>
        public virtual String ArtColor { get; set; }
        /// <summary>
        /// Тон
        /// </summary>
        public virtual String ArtColorTone { get; set; }
        /// <summary>
        /// Размер
        /// </summary>
        public virtual String ArtSize { get; set; }
        /// <summary>
        /// Сортировка пикинга
        /// </summary>
        public virtual Int32 ArtPickOrder { get; set; }
        /// <summary>
        /// Мин. температура хранения
        /// </summary>
        public virtual Double? ArtTempMin { get; set; }
        /// <summary>
        /// Макс. температура хранения
        /// </summary>
        public virtual Double? ArtTempMax { get; set; }
        /// <summary>
        /// Метод даты приемки
        /// </summary>
        public virtual SYSENUM_ART_FIFO ArtInputDateMethod { get; set; }
        /// <summary>
        /// Срок жизни
        /// </summary>
        public virtual Int32? ArtLifeTime { get; set; }
        /// <summary>
        /// ЕИ срока жизни
        /// </summary>
        public virtual String ArtLifeTimeMeasure { get; set; }
        /// <summary>
        /// Тип приходной накладной
        /// </summary>
        public virtual String ArtIWBType { get; set; }
        /// <summary>
        /// Класс опасности
        /// </summary>
        public virtual String ArtDangerLevel { get; set; }
        /// <summary>
        /// Подкласс опасности
        /// </summary>
        public virtual String ArtDangerSubLevel { get; set; }
        /// <summary>
        /// Хост-идентификатор
        /// </summary>
        public virtual String ArtHostRef { get; set; }
        /// <summary>
        /// Срок коммерциализации
        /// </summary>
        public virtual Int32? ArtCommercTime { get; set; }
        /// <summary>
        /// ЕИ срока коммерциализации
        /// </summary>
        public virtual String ArtCommercTimeMeasure { get; set; }
        /// <summary>
        /// Удален
        /// </summary>
        public virtual Boolean ArtDeleted { get; set; }
        /// <summary>
        /// Маркировка
        /// </summary>
        public virtual String ArtMark { get; set; }
        /// <summary>
        /// Брэнд
        /// </summary>
        public virtual String ArtBrand { get; set; }
        /// <summary>
        /// Модель
        /// </summary>
        public virtual String ArtModel { get; set; }
        /// <summary>
        /// Производитель
        /// </summary>
        public virtual WmsMandant ArtManufacturer { get; set; }
        /// <summary>
        /// Тип
        /// </summary>
        public virtual String ArtType { get; set; }
        /// <summary>
        /// Страна
        /// </summary>
        public virtual String CountryCode_r { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Int32? ArtPicture { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Отношение артикулов к группам
    /// </summary>
    [Serializable]
    public partial class WmsArt2GroupHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 Art2GroupID { get; set; }
        /// <summary>
        /// Код артикула
        /// </summary>
        public virtual String ArtCode_r { get; set; }
        /// <summary>
        /// Код группы артикулов
        /// </summary>
        public virtual String ArtGroupCode_r { get; set; }
        /// <summary>
        /// Приоритет
        /// </summary>
        public virtual Int32 Art2GroupPriority { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения SKU (Stock Keeping Unit) — единица учёта запасов
    /// </summary>
    [Serializable]
    public partial class WmsSKUHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 SKUID { get; set; }
        /// <summary>
        /// Код артикула
        /// </summary>
        public virtual String ArtCode_r { get; set; }
        /// <summary>
        /// Единица измерения
        /// </summary>
        public virtual String MeasureCode_r { get; set; }
        /// <summary>
        /// Дробное кол-во
        /// </summary>
        public virtual Double SKUCount { get; set; }
        /// <summary>
        /// Базовая
        /// </summary>
        public virtual Boolean SKUPrimary { get; set; }
        /// <summary>
        /// Клиентская
        /// </summary>
        public virtual Boolean SKUClient { get; set; }
        /// <summary>
        /// Неделимая
        /// </summary>
        public virtual Boolean SKUIndivisible { get; set; }
        /// <summary>
        /// Родительская SKU
        /// </summary>
        public virtual Int32? SKUParent { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String SKUName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String SKUDesc { get; set; }
        /// <summary>
        /// Длина
        /// </summary>
        public virtual Int32? SKULength { get; set; }
        /// <summary>
        /// Ширина
        /// </summary>
        public virtual Int32? SKUWidth { get; set; }
        /// <summary>
        /// Высота
        /// </summary>
        public virtual Int32? SKUHeight { get; set; }
        /// <summary>
        /// Объем
        /// </summary>
        public virtual Decimal? SKUVolume { get; set; }
        /// <summary>
        /// Вес
        /// </summary>
        public virtual Decimal? SKUWeight { get; set; }
        /// <summary>
        /// Длина от клиента
        /// </summary>
        public virtual Int32? SKULengthCL { get; set; }
        /// <summary>
        /// Ширина от клиента
        /// </summary>
        public virtual Int32? SKUWidthCL { get; set; }
        /// <summary>
        /// Высота от клиента
        /// </summary>
        public virtual Int32? SKUHeightCL { get; set; }
        /// <summary>
        /// Вес от клиента
        /// </summary>
        public virtual Decimal? SKUWeightCL { get; set; }
        /// <summary>
        /// Объем от клиента
        /// </summary>
        public virtual Decimal? SKUVolumeCL { get; set; }
        /// <summary>
        /// Тип резервирования
        /// </summary>
        public virtual String SKUReservType { get; set; }
        /// <summary>
        /// Критерий пикинга
        /// </summary>
        public virtual String SKUCritPL { get; set; }
        /// <summary>
        /// Критерий поставки
        /// </summary>
        public virtual String SKUCritMSC { get; set; }
        /// <summary>
        /// Batch-критерий
        /// </summary>
        public virtual String SKUCritBatch { get; set; }
        /// <summary>
        /// По-умолчанию
        /// </summary>
        public virtual Boolean? SKUDefault { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Справочник стоимостей артикулов
    /// </summary>
    [Serializable]
    public partial class WmsArtPriceHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 ArtPriceID { get; set; }
        /// <summary>
        /// ID записи SKU
        /// </summary>
        public virtual Int32 SKUID_r { get; set; }
        /// <summary>
        /// Дата начала
        /// </summary>
        public virtual DateTime? ArtPriceDateBegin { get; set; }
        /// <summary>
        /// Дата окончания
        /// </summary>
        public virtual DateTime? ArtPriceDateEnd { get; set; }
        /// <summary>
        /// Стоимость
        /// </summary>
        public virtual Double ArtPriceValue { get; set; }
        /// <summary>
        /// НДС
        /// </summary>
        public virtual Double? ArtPriceVAT { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Комплектующие
    /// </summary>
    [Serializable]
    public partial class WmsKitPosHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 KitPosID { get; set; }
        /// <summary>
        /// Код комплекта
        /// </summary>
        public virtual String KitCode_r { get; set; }
        /// <summary>
        /// ID записи SKU
        /// </summary>
        public virtual Int32 SKUID_r { get; set; }
        /// <summary>
        /// Количество в SKU
        /// </summary>
        public virtual Int32 KitPosCount { get; set; }
        /// <summary>
        /// Приоритет в комплекте
        /// </summary>
        public virtual Int32 KitPosPriority { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Блокировка товара
    /// </summary>
    [Serializable]
    public partial class wmsProduct2BlockingHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 Product2BlockingID { get; set; }
        /// <summary>
        /// ID товара
        /// </summary>
        public virtual Int32 ProductID_r { get; set; }
        /// <summary>
        /// Код блокировки
        /// </summary>
        public virtual String BlockingCode_r { get; set; }
        /// <summary>
        /// Комментарии к блокировке
        /// </summary>
        public virtual String Product2BlockingDesc { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Весовой контроль
    /// </summary>
    [Serializable]
    public partial class WmsWeightControlHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 WeightControlID { get; set; }
        /// <summary>
        /// Приоритет
        /// </summary>
        public virtual Int32 Priority { get; set; }
        /// <summary>
        /// Мандант
        /// </summary>
        public virtual WmsMandant Partner { get; set; }
        /// <summary>
        /// Погрешность
        /// </summary>
        public virtual Double WeightControlDev { get; set; }
        /// <summary>
        /// По группе артикулов
        /// </summary>
        public virtual String WeightControlArtGroup { get; set; }
        /// <summary>
        /// ЕИ
        /// </summary>
        public virtual String MeasureCode_r { get; set; }
        /// <summary>
        /// Тип ТЕ
        /// </summary>
        public virtual String TETypeCode_r { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения SKU к партнерам
    /// </summary>
    [Serializable]
    public partial class WmsSKU2PartnerHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 SKU2PartnerID { get; set; }
        /// <summary>
        /// SKU
        /// </summary>
        public virtual Int32 SKUID_r { get; set; }
        /// <summary>
        /// Партнер
        /// </summary>
        public virtual Int32 PartnerID_r { get; set; }
        /// <summary>
        /// Артикул партнера
        /// </summary>
        public virtual String SKU2PartnerArtName { get; set; }
        /// <summary>
        /// Наименование артикула партнера
        /// </summary>
        public virtual String SKU2PartnerArtDesc { get; set; }
        /// <summary>
        /// Расширенное наименование артикула партнера
        /// </summary>
        public virtual String SKU2PartnerArtDescExt { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения СТН
    /// </summary>
    [Serializable]
    public partial class WmsWTVHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 WTVID { get; set; }
        /// <summary>
        /// Id истории товара
        /// </summary>
        public virtual Int32 WTVProductHistory { get; set; }
        /// <summary>
        /// Количество SKU
        /// </summary>
        public virtual Int32 WTVCountSKU { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Причины корректировки товара
    /// </summary>
    [Serializable]
    public partial class WmsAdjustmentReasonHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 AdjustmentReasonID { get; set; }
        /// <summary>
        /// Код
        /// </summary>
        public virtual String AdjustmentReasonCode { get; set; }
        /// <summary>
        /// Мандант
        /// </summary>
        public virtual WmsMandant Partner { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String AdjustmentReasonDesc { get; set; }
        /// <summary>
        /// Хост-идентификатор
        /// </summary>
        public virtual String AdjustmentReasonHostRef { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Товар
    /// </summary>
    [Serializable]
    public partial class WmsProductHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 ProductID { get; set; }
        /// <summary>
        /// ТЕ
        /// </summary>
        public virtual String TECode_r { get; set; }
        /// <summary>
        /// SKU
        /// </summary>
        public virtual WmsSKU SKU { get; set; }
        /// <summary>
        /// Кол-во
        /// </summary>
        public virtual Int32 ProductCountSKU { get; set; }
        /// <summary>
        /// Дробное кол-во
        /// </summary>
        public virtual Double ProductCount { get; set; }
        /// <summary>
        /// ЗТЕ
        /// </summary>
        public virtual Int32 ProductTTEQuantity { get; set; }
        /// <summary>
        /// Квалификация
        /// </summary>
        public virtual String QLFCode_r { get; set; }
        /// <summary>
        /// Детализация квалификации
        /// </summary>
        public virtual String QLFDetailCode_r { get; set; }
        /// <summary>
        /// Дата приемки
        /// </summary>
        public virtual DateTime ProductInputDate { get; set; }
        /// <summary>
        /// Метод даты приемки
        /// </summary>
        public virtual SYSENUM_ART_FIFO ProductInputDateMethod { get; set; }
        /// <summary>
        /// Дата производства
        /// </summary>
        public virtual DateTime? ProductDate { get; set; }
        /// <summary>
        /// Упаковка
        /// </summary>
        public virtual String ProductPack { get; set; }
        /// <summary>
        /// Затарка в упаковке
        /// </summary>
        public virtual Int32? ProductPackCountSKU { get; set; }
        /// <summary>
        /// Срок годности
        /// </summary>
        public virtual DateTime? ProductExpiryDate { get; set; }
        /// <summary>
        /// Партия
        /// </summary>
        public virtual String ProductBatch { get; set; }
        /// <summary>
        /// Лот
        /// </summary>
        public virtual String ProductLot { get; set; }
        /// <summary>
        /// Серийный номер
        /// </summary>
        public virtual String ProductSerialNumber { get; set; }
        /// <summary>
        /// Цвет
        /// </summary>
        public virtual String ProductColor { get; set; }
        /// <summary>
        /// Тон
        /// </summary>
        public virtual String ProductTone { get; set; }
        /// <summary>
        /// Размер
        /// </summary>
        public virtual String ProductSize { get; set; }
        /// <summary>
        /// Артикул
        /// </summary>
        public virtual WmsArt Art { get; set; }
        /// <summary>
        /// Мандант
        /// </summary>
        public virtual WmsMandant Partner { get; set; }
        /// <summary>
        /// Позиция приходной накладной
        /// </summary>
        public virtual WmsIWBPos IWBPos { get; set; }
        /// <summary>
        /// Позиция расходной накладной
        /// </summary>
        public virtual WmsOWBPos OWBPos { get; set; }
        /// <summary>
        /// Фабрика
        /// </summary>
        public virtual WmsFactory Factory { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public virtual String StatusCode_r { get; set; }
        /// <summary>
        /// Batch-код
        /// </summary>
        public virtual String ProductBatchCode { get; set; }
        /// <summary>
        /// Номер короба
        /// </summary>
        public virtual String ProductBoxNumber { get; set; }
        /// <summary>
        /// Хост-идентификатор
        /// </summary>
        public virtual String ProductHostRef { get; set; }
        /// <summary>
        /// ЗНТ
        /// </summary>
        public virtual Int32? TransportTaskID_r { get; set; }
        /// <summary>
        /// Артикул комплекта
        /// </summary>
        public virtual String ProductKitArtName { get; set; }
        /// <summary>
        /// Владелец
        /// </summary>
        public virtual WmsMandant ProductOwner { get; set; }
        /// <summary>
        /// Предок
        /// </summary>
        public virtual Int32? ProductRoot { get; set; }
        /// <summary>
        /// Приоритет
        /// </summary>
        public virtual Int32? ProductPriority { get; set; }
        /// <summary>
        /// Страна
        /// </summary>
        public virtual String CountryCode_r { get; set; }
        /// <summary>
        /// ГТД
        /// </summary>
        public virtual String ProductGTD { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Справочник бизнес-процессов
    /// </summary>
    [Serializable]
    public partial class BpProcessHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код бизнес-процесса
        /// </summary>
        public virtual String ProcessCode { get; set; }
        /// <summary>
        /// Наименование бизнес-процесса
        /// </summary>
        public virtual String ProcessName { get; set; }
        /// <summary>
        /// Описание бизнес-процесса
        /// </summary>
        public virtual String ProcessDesc { get; set; }
        /// <summary>
        /// Блокировка бизнес-процесса
        /// </summary>
        public virtual Boolean ProcessLocked { get; set; }
        /// <summary>
        /// Исполнительный механизм
        /// </summary>
        public virtual String ProcessExecutor { get; set; }
        /// <summary>
        /// Движок бизнес-процесса
        /// </summary>
        public virtual String ProcessEngine { get; set; }
        /// <summary>
        /// Тип
        /// </summary>
        public virtual String ProcessType { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public virtual String StatusCode_r { get; set; }
        /// <summary>
        /// WF
        /// </summary>
        public virtual String WorkFlowCode_r { get; set; }
        /// <summary>
        /// Команда
        /// </summary>
        public virtual String ProcessCommand { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Журнал выполнения бизнес-процессов
    /// </summary>
    [Serializable]
    public partial class BpLogHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 BpLogID { get; set; }
        /// <summary>
        /// Код бизнес-процесса
        /// </summary>
        public virtual String ProcessCode_r { get; set; }
        /// <summary>
        /// Код системного пользователя
        /// </summary>
        public virtual WmsUser User { get; set; }
        /// <summary>
        /// Код запущенного экземпляра БП
        /// </summary>
        public virtual String BpLogInstance { get; set; }
        /// <summary>
        /// Текущий шаг выполнения БП
        /// </summary>
        public virtual String BpLogCurrentStep { get; set; }
        /// <summary>
        /// Статус выполняемого шага
        /// </summary>
        public virtual String BpLogStatus { get; set; }
        /// <summary>
        /// Время начала выполнения шага
        /// </summary>
        public virtual DateTime BpLogStartTime { get; set; }
        /// <summary>
        /// Время окончания выполнения шага
        /// </summary>
        public virtual DateTime BpLogEndTime { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Триггер бизнес-процессов
    /// </summary>
    [Serializable]
    public partial class BpTriggerHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код триггера
        /// </summary>
        public virtual String TriggerCode { get; set; }
        /// <summary>
        /// Код бизнес-процесса
        /// </summary>
        public virtual String ProcessCode_r { get; set; }
        /// <summary>
        /// Имя объекта
        /// </summary>
        public virtual String ObjectName_r { get; set; }
        /// <summary>
        /// Действие для срабатывания
        /// </summary>
        public virtual String TriggerAction { get; set; }
        /// <summary>
        /// Выражение для срабатывания
        /// </summary>
        public virtual String TriggerExpression { get; set; }
        /// <summary>
        /// Режим работы
        /// </summary>
        public virtual SYSENUM_BPTRIGGER_MODE TriggerMode { get; set; }
        /// <summary>
        /// Фильтр по сущности
        /// </summary>
        public virtual String TriggerEntityFilter { get; set; }
        /// <summary>
        /// Кнопка
        /// </summary>
        public virtual String UIButtonCode_r { get; set; }
        /// <summary>
        /// Номер
        /// </summary>
        public virtual Int32? TriggerOrder { get; set; }
        /// <summary>
        /// Команда
        /// </summary>
        public virtual String TriggerCommand { get; set; }
        /// <summary>
        /// По одной записи
        /// </summary>
        public virtual Boolean? TriggerOnlyByOneItem { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Batch
    /// </summary>
    [Serializable]
    public partial class BPBatchHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код
        /// </summary>
        public virtual String BatchCode { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String BatchName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String BatchDesc { get; set; }
        /// <summary>
        /// Workflow
        /// </summary>
        public virtual String WorkflowCode_r { get; set; }
        /// <summary>
        /// SQL
        /// </summary>
        public virtual String BatchSQL { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Выбор Batch
    /// </summary>
    [Serializable]
    public partial class BPBatchSelectHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 BatchSelectID { get; set; }
        /// <summary>
        /// Batch-код
        /// </summary>
        public virtual String BatchCode_r { get; set; }
        /// <summary>
        /// Приоритет
        /// </summary>
        public virtual Int32 Priority { get; set; }
        /// <summary>
        /// Мандант
        /// </summary>
        public virtual WmsMandant Partner { get; set; }
        /// <summary>
        /// По SKU
        /// </summary>
        public virtual String BatchSelectSKUCritBatch { get; set; }
        /// <summary>
        /// По группе артикулов
        /// </summary>
        public virtual String BatchSelectArtGroupCritBatch { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Workflow
    /// </summary>
    [Serializable]
    public partial class BpWorkflowHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код WF
        /// </summary>
        public virtual String WorkflowCode { get; set; }
        /// <summary>
        /// Наименование WF
        /// </summary>
        public virtual String WorkflowName { get; set; }
        /// <summary>
        /// Описание WF
        /// </summary>
        public virtual String WorkflowDesc { get; set; }
        /// <summary>
        /// Версия WF
        /// </summary>
        public virtual String WorkflowVersion { get; set; }
        /// <summary>
        /// Тело потока процесса
        /// </summary>
        public virtual Byte[] WorkflowXAML { get; set; }
        /// <summary>
        /// Activities
        /// </summary>
        public virtual String WorkFlowActivities { get; set; }
        /// <summary>
        /// Internal
        /// </summary>
        public virtual String WorkFlowInternal { get; set; }
        /// <summary>
        /// Кем заблокировано
        /// </summary>
        public virtual WmsUser User { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Области перемещения
    /// </summary>
    [Serializable]
    public partial class WmsMotionAreaHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код области перемещения
        /// </summary>
        public virtual String MotionAreaCode { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String MotionAreaName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String MotionAreaDesc { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Области приемки
    /// </summary>
    [Serializable]
    public partial class WmsReceiveAreaHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код области приемки
        /// </summary>
        public virtual String ReceiveAreaCode { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String ReceiveAreaName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String ReceiveAreaDesc { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Области поставки
    /// </summary>
    [Serializable]
    public partial class WmsSupplyAreaHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код области поставки
        /// </summary>
        public virtual String SupplyAreaCode { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String SupplyAreaName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String SupplyAreaDesc { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Справочник классов мест
    /// </summary>
    [Serializable]
    public partial class WmsPlaceClassHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код класса места
        /// </summary>
        public virtual String PlaceClassCode { get; set; }
        /// <summary>
        /// Наименование класса места
        /// </summary>
        public virtual String PlaceClassName { get; set; }
        /// <summary>
        /// Описание класса места
        /// </summary>
        public virtual String PlaceClassDesc { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Типы мест
    /// </summary>
    [Serializable]
    public partial class WmsPlaceTypeHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код типа места
        /// </summary>
        public virtual String PlaceTypeCode { get; set; }
        /// <summary>
        /// Наименование типа места
        /// </summary>
        public virtual String PlaceTypeName { get; set; }
        /// <summary>
        /// Описание типа места
        /// </summary>
        public virtual String PlaceTypeDesc { get; set; }
        /// <summary>
        /// Вместимость места
        /// </summary>
        public virtual Int32 PlaceTypeCapacity { get; set; }
        /// <summary>
        /// Длина места
        /// </summary>
        public virtual Int32 PlaceTypeLength { get; set; }
        /// <summary>
        /// Ширина места
        /// </summary>
        public virtual Int32 PlaceTypeWidth { get; set; }
        /// <summary>
        /// Высота места
        /// </summary>
        public virtual Int32 PlaceTypeHeight { get; set; }
        /// <summary>
        /// Максимальный разрешенный вес
        /// </summary>
        public virtual Decimal PlaceTypeMaxWeight { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Отношения мест к блокировкам
    /// </summary>
    [Serializable]
    public partial class WmsPlace2BlockingHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 Place2BlockingID { get; set; }
        /// <summary>
        /// Код места
        /// </summary>
        public virtual String PlaceCode_r { get; set; }
        /// <summary>
        /// Код блокировки
        /// </summary>
        public virtual String BlockingCode_r { get; set; }
        /// <summary>
        /// Комментарии к блокировке
        /// </summary>
        public virtual String Place2BlockingDesc { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Описывает типы областей склада
    /// </summary>
    [Serializable]
    public partial class WmsAreaTypeHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код типа области склада
        /// </summary>
        public virtual String AreaTypeCode { get; set; }
        /// <summary>
        /// Наименование типа области склада
        /// </summary>
        public virtual String AreaTypeName { get; set; }
        /// <summary>
        /// Описание типа области склада
        /// </summary>
        public virtual String AreaTypeDesc { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Отношение области к блокировкам
    /// </summary>
    [Serializable]
    public partial class WmsArea2BlockingHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код записи
        /// </summary>
        public virtual Int32 Area2BlockingID { get; set; }
        /// <summary>
        /// Код области склада
        /// </summary>
        public virtual String AreaCode_r { get; set; }
        /// <summary>
        /// Код блокировки
        /// </summary>
        public virtual String BlockingCode_r { get; set; }
        /// <summary>
        /// Комментарии к блокировке
        /// </summary>
        public virtual String Area2BlockingDesc { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Отношение сектора к блокировкам
    /// </summary>
    [Serializable]
    public partial class WmsSegment2BlockingHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код записи
        /// </summary>
        public virtual Int32 Segment2BlockingID { get; set; }
        /// <summary>
        /// Код записи сектора
        /// </summary>
        public virtual String SegmentCode_r { get; set; }
        /// <summary>
        /// Код блокировки
        /// </summary>
        public virtual String BlockingCode_r { get; set; }
        /// <summary>
        /// Комментарии к блокировке
        /// </summary>
        public virtual String Segment2BlockingDesc { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Дерево групп областей перемещения
    /// </summary>
    [Serializable]
    public partial class WmsMotionAreaGroupTreeHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 MotionAreaGroupTreeID { get; set; }
        /// <summary>
        /// Группа области перемещения
        /// </summary>
        public virtual String MotionAreaGroupCode_r { get; set; }
        /// <summary>
        /// Родительская группа
        /// </summary>
        public virtual String MotionAreaGroupCodeParent { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Отношение областей перемещения к группам
    /// </summary>
    [Serializable]
    public partial class WmsMotionArea2GroupHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 MotionArea2GroupID { get; set; }
        /// <summary>
        /// Группа области перемещения
        /// </summary>
        public virtual String MotionAreaGroupCode_r { get; set; }
        /// <summary>
        /// Область перемещения
        /// </summary>
        public virtual String MotionAreaCode_r { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Группы областей перемещения
    /// </summary>
    [Serializable]
    public partial class WmsMotionAreaGroupHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код группы области перемещения
        /// </summary>
        public virtual String MotionAreaGroupCode { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String MotionAreaGroupName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String MotionAreaGroupDesc { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Справочник типов секторов склада
    /// </summary>
    [Serializable]
    public partial class WmsSegmentTypeHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код типа сектора склада
        /// </summary>
        public virtual String SegmentTypeCode { get; set; }
        /// <summary>
        /// Наименование типа сектора области склада
        /// </summary>
        public virtual String SegmentTypeName { get; set; }
        /// <summary>
        /// Описание типа сектора области склада
        /// </summary>
        public virtual String SegmentTypeDesc { get; set; }
        /// <summary>
        /// Формат адреса места
        /// </summary>
        public virtual String SegmentTypeCodeFormat { get; set; }
        /// <summary>
        /// Формат отображения адреса места
        /// </summary>
        public virtual String SegmentTypeCodeView { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Справочник секторов
    /// </summary>
    [Serializable]
    public partial class WmsSegmentHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код сектора
        /// </summary>
        public virtual String SegmentCode { get; set; }
        /// <summary>
        /// Номер сектора
        /// </summary>
        public virtual String SegmentNumber { get; set; }
        /// <summary>
        /// Код области склада
        /// </summary>
        public virtual String AreaCode_r { get; set; }
        /// <summary>
        /// Код типа сектора склада
        /// </summary>
        public virtual String SegmentTypeCode_r { get; set; }
        /// <summary>
        /// Наименование сектора области
        /// </summary>
        public virtual String SegmentName { get; set; }
        /// <summary>
        /// Описание сектора области
        /// </summary>
        public virtual String SegmentDesc { get; set; }
        /// <summary>
        /// X
        /// </summary>
        public virtual Int32? SegmentPosX { get; set; }
        /// <summary>
        /// Y
        /// </summary>
        public virtual Int32? SegmentPosY { get; set; }
        /// <summary>
        /// Угол
        /// </summary>
        public virtual Int32? SegmentAngle { get; set; }
        /// <summary>
        /// Идентификатор сектора в хост-системе
        /// </summary>
        public virtual String SegmentHostRef { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Справочник складов
    /// </summary>
    [Serializable]
    public partial class WmsWarehouseHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код
        /// </summary>
        public virtual String WarehouseCode { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String WarehouseName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String WarehouseDesc { get; set; }
        /// <summary>
        /// Площадка
        /// </summary>
        public virtual String SiteCode_r { get; set; }
        /// <summary>
        /// Ref
        /// </summary>
        public virtual String WarehouseHostRef { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Ворота
    /// </summary>
    [Serializable]
    public partial class WmsGateHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код ворот
        /// </summary>
        public virtual String GateCode { get; set; }
        /// <summary>
        /// Код склада
        /// </summary>
        public virtual String WarehouseCode_r { get; set; }
        /// <summary>
        /// Номер ворот
        /// </summary>
        public virtual String GateNumber { get; set; }
        /// <summary>
        /// Наименование ворот
        /// </summary>
        public virtual String GateName { get; set; }
        /// <summary>
        /// Описание ворот
        /// </summary>
        public virtual String GateDesc { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Справочник областей склада
    /// </summary>
    [Serializable]
    public partial class WmsAreaHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код области склада
        /// </summary>
        public virtual String AreaCode { get; set; }
        /// <summary>
        /// Наименование области склада
        /// </summary>
        public virtual String AreaName { get; set; }
        /// <summary>
        /// Описание области склада
        /// </summary>
        public virtual String AreaDesc { get; set; }
        /// <summary>
        /// Код типа области склада
        /// </summary>
        public virtual String AreaTypeCode_r { get; set; }
        /// <summary>
        /// Код склада
        /// </summary>
        public virtual String WarehouseCode_r { get; set; }
        /// <summary>
        /// Площадь области склада
        /// </summary>
        public virtual Int32? AreaSquare { get; set; }
        /// <summary>
        /// Идентификатор области в хост-системе
        /// </summary>
        public virtual String AreaHostRef { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Площадка
    /// </summary>
    [Serializable]
    public partial class WmsSiteHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код
        /// </summary>
        public virtual String SiteCode { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String SiteName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String SiteDesc { get; set; }
        /// <summary>
        /// Идентификатор в хост-системе
        /// </summary>
        public virtual String SiteHostRef { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Места
    /// </summary>
    [Serializable]
    public partial class WmsPlaceHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код
        /// </summary>
        public virtual String PlaceCode { get; set; }
        /// <summary>
        /// Код сектора
        /// </summary>
        public virtual String SegmentCode_r { get; set; }
        /// <summary>
        /// Секция
        /// </summary>
        public virtual Int32 PlaceS { get; set; }
        /// <summary>
        /// Место
        /// </summary>
        public virtual Int32 PlaceX { get; set; }
        /// <summary>
        /// Ярус
        /// </summary>
        public virtual Int32 PlaceY { get; set; }
        /// <summary>
        /// По глубине
        /// </summary>
        public virtual Int32 PlaceZ { get; set; }
        /// <summary>
        /// Ширина
        /// </summary>
        public virtual Int32? PlaceWidth { get; set; }
        /// <summary>
        /// Глубина
        /// </summary>
        public virtual Int32? PlaceLength { get; set; }
        /// <summary>
        /// Высота
        /// </summary>
        public virtual Int32? PlaceHeight { get; set; }
        /// <summary>
        /// Вместимость максимальная
        /// </summary>
        public virtual Int32 PlaceCapacityMax { get; set; }
        /// <summary>
        /// Вместимость остаточная
        /// </summary>
        public virtual Int32 PlaceCapacity { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public virtual String StatusCode_r { get; set; }
        /// <summary>
        /// Контрольное число
        /// </summary>
        public virtual String PlaceCheckNumber { get; set; }
        /// <summary>
        /// Контрольное число для яруса
        /// </summary>
        public virtual String PlaceCheckNumberY { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String PlaceName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String PlaceDesc { get; set; }
        /// <summary>
        /// Тип места
        /// </summary>
        public virtual String PlaceTypeCode_r { get; set; }
        /// <summary>
        /// Класс места
        /// </summary>
        public virtual String PlaceClassCode_r { get; set; }
        /// <summary>
        /// Сортировка A
        /// </summary>
        public virtual Int32 PlaceSortA { get; set; }
        /// <summary>
        /// Сортировка B
        /// </summary>
        public virtual Int32 PlaceSortB { get; set; }
        /// <summary>
        /// Сортировка C
        /// </summary>
        public virtual Int32 PlaceSortC { get; set; }
        /// <summary>
        /// Сортировка D
        /// </summary>
        public virtual Int32 PlaceSortD { get; set; }
        /// <summary>
        /// Сортировка для пикинга
        /// </summary>
        public virtual Int32 PlaceSortPick { get; set; }
        /// <summary>
        /// Область приемки
        /// </summary>
        public virtual String ReceiveAreaCode_r { get; set; }
        /// <summary>
        /// Область перемещения
        /// </summary>
        public virtual String MotionAreaCode_r { get; set; }
        /// <summary>
        /// Область поставки
        /// </summary>
        public virtual String SupplyAreaCode_r { get; set; }
        /// <summary>
        /// Код группы мест
        /// </summary>
        public virtual String PlaceGroupCode { get; set; }
        /// <summary>
        /// Вес на место
        /// </summary>
        public virtual Decimal PlaceWeight { get; set; }
        /// <summary>
        /// Вес на группу
        /// </summary>
        public virtual Decimal PlaceWeightGroup { get; set; }
        /// <summary>
        /// Критерий выбора менеджера перемещения
        /// </summary>
        public virtual String PlaceSelMM { get; set; }
        /// <summary>
        /// X
        /// </summary>
        public virtual Int32? PlacePosX { get; set; }
        /// <summary>
        /// Y
        /// </summary>
        public virtual Int32? PlacePosY { get; set; }
        /// <summary>
        /// Хост-идентификатор
        /// </summary>
        public virtual String PlaceHostRef { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        /// <summary>
        /// Рассчитывать вместимость
        /// </summary>
        public virtual Boolean PlaceIsCapacityCalc { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Офис
    /// </summary>
    [Serializable]
    public partial class WmsWarehouseOfficeHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 WarehouseOfficeID { get; set; }
        /// <summary>
        /// Скад
        /// </summary>
        public virtual String WarehouseCode_r { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String WarehouseOfficeName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String WarehouseOfficeDesc { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Виды событий
    /// </summary>
    [Serializable]
    public partial class WmsEventKindHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код
        /// </summary>
        public virtual String EventKindCode { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String EventKindName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String EventKindDesc { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Классы операций
    /// </summary>
    [Serializable]
    public partial class BillOperationClassHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код класса операций
        /// </summary>
        public virtual String OperationClassCode { get; set; }
        /// <summary>
        /// Наименование класса операций
        /// </summary>
        public virtual String OperationClassName { get; set; }
        /// <summary>
        /// Описание класса операций
        /// </summary>
        public virtual String OperationClassDesc { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Шкала расчетов
    /// </summary>
    [Serializable]
    public partial class BillScaleHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код записи
        /// </summary>
        public virtual String ScaleCode { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        public virtual String ScaleName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String ScaleDescription { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Шкалы к операциям по договору
    /// </summary>
    [Serializable]
    public partial class BillScale2O2CHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 Scale2O2CID { get; set; }
        /// <summary>
        /// Шкала
        /// </summary>
        public virtual String ScaleCode_r { get; set; }
        /// <summary>
        /// Услуга по договору
        /// </summary>
        public virtual Int32 Operation2ContractID_r { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Значения шкал
    /// </summary>
    [Serializable]
    public partial class BillScaleValueHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 ScaleValueID { get; set; }
        /// <summary>
        /// Шкала
        /// </summary>
        public virtual String ScaleCode_r { get; set; }
        /// <summary>
        /// Значение от
        /// </summary>
        public virtual String ScaleValueFrom { get; set; }
        /// <summary>
        /// Значение до
        /// </summary>
        public virtual String ScaleValueTill { get; set; }
        /// <summary>
        /// Значение
        /// </summary>
        public virtual String ScaleValueValue { get; set; }
        /// <summary>
        /// Тип значения
        /// </summary>
        public virtual String ScaleValueTypeCode_r { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Biller
    /// </summary>
    [Serializable]
    public partial class BillBillerHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код записи
        /// </summary>
        public virtual String BillerCode { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String BillerName { get; set; }
        /// <summary>
        /// Блокирован
        /// </summary>
        public virtual Boolean BillerLocked { get; set; }
        /// <summary>
        /// Процедура подготовки
        /// </summary>
        public virtual String BillerProcedureBefore { get; set; }
        /// <summary>
        /// Процедура расчета
        /// </summary>
        public virtual String BillerProcedureCalc { get; set; }
        /// <summary>
        /// Процедура постобработки
        /// </summary>
        public virtual String BillerProcedureAfter { get; set; }
        /// <summary>
        /// Крон триггер
        /// </summary>
        public virtual String BillerCron { get; set; }
        /// <summary>
        /// Порядок запуска
        /// </summary>
        public virtual Int32? BillerOrder { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Детализация транзакций
    /// </summary>
    [Serializable]
    public partial class BillTransactionDetailHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 TransactionDetailID { get; set; }
        /// <summary>
        /// Транзакция
        /// </summary>
        public virtual Int32 TransactionID_r { get; set; }
        /// <summary>
        /// Имя параметра
        /// </summary>
        public virtual String TransactionDetailName { get; set; }
        /// <summary>
        /// Значение параметра
        /// </summary>
        public virtual String TransactionDetailValue { get; set; }
        /// <summary>
        /// Основание
        /// </summary>
        public virtual Int32? OperationCauseID_r { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Финансовые транзакции сотрудников
    /// </summary>
    [Serializable]
    public partial class BillTransactionWHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 TransactionWID { get; set; }
        /// <summary>
        /// Заголовок
        /// </summary>
        public virtual Int32 EventHeaderID_r { get; set; }
        /// <summary>
        /// Биллер
        /// </summary>
        public virtual String BillerCode_r { get; set; }
        /// <summary>
        /// Тип транзакции
        /// </summary>
        public virtual String TransactionTypeCode_r { get; set; }
        /// <summary>
        /// Плательщик
        /// </summary>
        public virtual WmsMandant Partner { get; set; }
        /// <summary>
        /// Получатель
        /// </summary>
        public virtual Int32 WorkerID_r { get; set; }
        /// <summary>
        /// К услуге по договору
        /// </summary>
        public virtual Int32? Operation2ContractID_r { get; set; }
        /// <summary>
        /// Сумма
        /// </summary>
        public virtual Double TransactionWAmmount { get; set; }
        /// <summary>
        /// Валюта договора
        /// </summary>
        public virtual String CurrencyCode_r { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Детализация транзакций сотрудников
    /// </summary>
    [Serializable]
    public partial class BillTransactionWDetailHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 TransactionWDetailID { get; set; }
        /// <summary>
        /// Транзакция
        /// </summary>
        public virtual Int32 TransactionWID_r { get; set; }
        /// <summary>
        /// Имя параметра
        /// </summary>
        public virtual String TransactionWDetailName { get; set; }
        /// <summary>
        /// Значение параметра
        /// </summary>
        public virtual String TransactionWDetailValue { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Типы значений шкал
    /// </summary>
    [Serializable]
    public partial class BillScaleValueTypeHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код записи
        /// </summary>
        public virtual String ScaleValueTypeCode { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String ScaleValueTypeName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String ScaleValueTypeDesc { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Тариф на услугу
    /// </summary>
    [Serializable]
    public partial class BillTariffHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 TariffID { get; set; }
        /// <summary>
        /// К услуге по договору
        /// </summary>
        public virtual Int32 Operation2ContractID_r { get; set; }
        /// <summary>
        /// Дата начала действия тарифа
        /// </summary>
        public virtual DateTime TariffDateFrom { get; set; }
        /// <summary>
        /// Дата окончания действия тарифа
        /// </summary>
        public virtual DateTime TariffDateTill { get; set; }
        /// <summary>
        /// Значение
        /// </summary>
        public virtual Double TariffValue { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String TariffDesc { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Типы транзакций
    /// </summary>
    [Serializable]
    public partial class BillTransactionTypeHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код записи
        /// </summary>
        public virtual String TransactionTypeCode { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String TransactionTypeName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String TransactionTypeDesc { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения События для расчетов
    /// </summary>
    [Serializable]
    public partial class BillEvent2BillerHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код записи
        /// </summary>
        public virtual Int32 Event2BillerID { get; set; }
        /// <summary>
        /// Событие
        /// </summary>
        public virtual Int32 EventHeaderID_r { get; set; }
        /// <summary>
        /// Биллер
        /// </summary>
        public virtual String BillerCode_r { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Основание для оказания услуги
    /// </summary>
    [Serializable]
    public partial class BillOperationCauseHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 OperationCauseID { get; set; }
        /// <summary>
        /// Услуга по договору
        /// </summary>
        public virtual Int32 Operation2ContractID_r { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String OperationCauseName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String OperationCauseDesc { get; set; }
        /// <summary>
        /// Указание детализации
        /// </summary>
        public virtual Int32? OperationCauseOrdinal { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Виды событий к Biller-ам
    /// </summary>
    [Serializable]
    public partial class BillEventKind2BillerHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 EventKind2BillerID { get; set; }
        /// <summary>
        /// Вид события
        /// </summary>
        public virtual String EventKindCode_r { get; set; }
        /// <summary>
        /// Целевой код
        /// </summary>
        public virtual String EventKind2BillerTargetCode { get; set; }
        /// <summary>
        /// Атрибут сущности
        /// </summary>
        public virtual String EventKind2BillerEventDetail { get; set; }
        /// <summary>
        /// Биллер
        /// </summary>
        public virtual String BillerCode_r { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения События к мандантам
    /// </summary>
    [Serializable]
    public partial class WmsEventKind2MandantHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 EventKind2MandantID { get; set; }
        /// <summary>
        /// Мандант
        /// </summary>
        public virtual WmsMandant Partner { get; set; }
        /// <summary>
        /// Вид события
        /// </summary>
        public virtual String EventKindCode_r { get; set; }
        /// <summary>
        /// Batch
        /// </summary>
        public virtual String EventKind2MandantBatch { get; set; }
        /// <summary>
        /// Интерфейс
        /// </summary>
        public virtual String EventKind2MandantIO { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Договоры
    /// </summary>
    [Serializable]
    public partial class BillContractHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 ContractID { get; set; }
        /// <summary>
        /// Номер
        /// </summary>
        public virtual String ContractNumber { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String ContractDesc { get; set; }
        /// <summary>
        /// Дата начала действия
        /// </summary>
        public virtual DateTime ContractDateFrom { get; set; }
        /// <summary>
        /// Дата окончания действия
        /// </summary>
        public virtual DateTime? ContractDateTill { get; set; }
        /// <summary>
        /// Владелец
        /// </summary>
        public virtual WmsMandant ContractOwner { get; set; }
        /// <summary>
        /// Заказчик
        /// </summary>
        public virtual WmsMandant ContractCustomer { get; set; }
        /// <summary>
        /// Валюта договора
        /// </summary>
        public virtual String CurrencyCode_r { get; set; }
        /// <summary>
        /// НДС
        /// </summary>
        public virtual String VATTypeCode_r { get; set; }
        /// <summary>
        /// Идентификатор в хост-системе
        /// </summary>
        public virtual String ContractHostRef { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Услуги по договору
    /// </summary>
    [Serializable]
    public partial class BillOperation2ContractHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 Operation2ContractID { get; set; }
        /// <summary>
        /// Контракт
        /// </summary>
        public virtual Int32 ContractID_r { get; set; }
        /// <summary>
        /// Услуга
        /// </summary>
        public virtual String OperationCode_r { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String Operation2ContractName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String Operation2ContractDesc { get; set; }
        /// <summary>
        /// Биллер
        /// </summary>
        public virtual String BillerCode_r { get; set; }
        /// <summary>
        /// Аналитика
        /// </summary>
        public virtual String AnalyticsCode_r { get; set; }
        /// <summary>
        /// Код операции к контракту
        /// </summary>
        public virtual String Operation2ContractCode { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Акты к операциям по договору
    /// </summary>
    [Serializable]
    public partial class BillWorkAct2Op2CHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 WorkAct2Op2CID { get; set; }
        /// <summary>
        /// Акт работ
        /// </summary>
        public virtual Int32 WorkActID_r { get; set; }
        /// <summary>
        /// Услуга по договору
        /// </summary>
        public virtual Int32 Operation2ContractID_r { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Детализация акта производственных работ
    /// </summary>
    [Serializable]
    public partial class BillWorkActDetailHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 WorkActDetailID { get; set; }
        /// <summary>
        /// Акт
        /// </summary>
        public virtual Int32 WorkActID_r { get; set; }
        /// <summary>
        /// Транзакция
        /// </summary>
        public virtual Int32? TransactionID_r { get; set; }
        /// <summary>
        /// Услуга по договору
        /// </summary>
        public virtual Int32 Operation2ContractID_r { get; set; }
        /// <summary>
        /// Итоговая сумма
        /// </summary>
        public virtual Double? WorkActDetailTotalSum { get; set; }
        /// <summary>
        /// Признак ручного добавления
        /// </summary>
        public virtual Boolean WorkActDetailManual { get; set; }
        /// <summary>
        /// Основание1
        /// </summary>
        public virtual String WorkActDetailCause1 { get; set; }
        /// <summary>
        /// Основание2
        /// </summary>
        public virtual String WorkActDetailCause2 { get; set; }
        /// <summary>
        /// Основание3
        /// </summary>
        public virtual String WorkActDetailCause3 { get; set; }
        /// <summary>
        /// Основание4
        /// </summary>
        public virtual String WorkActDetailCause4 { get; set; }
        /// <summary>
        /// Основание5
        /// </summary>
        public virtual String WorkActDetailCause5 { get; set; }
        /// <summary>
        /// Основание6
        /// </summary>
        public virtual String WorkActDetailCause6 { get; set; }
        /// <summary>
        /// Основание7
        /// </summary>
        public virtual String WorkActDetailCause7 { get; set; }
        /// <summary>
        /// Основание8
        /// </summary>
        public virtual String WorkActDetailCause8 { get; set; }
        /// <summary>
        /// Основание9
        /// </summary>
        public virtual String WorkActDetailCause9 { get; set; }
        /// <summary>
        /// Основание10
        /// </summary>
        public virtual String WorkActDetailCause10 { get; set; }
        /// <summary>
        /// Количество
        /// </summary>
        public virtual Double? WorkActDetailCount { get; set; }
        /// <summary>
        /// Сумма1
        /// </summary>
        public virtual Double? WorkActDetailSum1 { get; set; }
        /// <summary>
        /// Сумма2
        /// </summary>
        public virtual Double? WorkActDetailSum2 { get; set; }
        /// <summary>
        /// Сумма3
        /// </summary>
        public virtual Double? WorkActDetailSum3 { get; set; }
        /// <summary>
        /// Сумма4
        /// </summary>
        public virtual Double? WorkActDetailSum4 { get; set; }
        /// <summary>
        /// Сумма5
        /// </summary>
        public virtual Double? WorkActDetailSum5 { get; set; }
        /// <summary>
        /// Сумма6
        /// </summary>
        public virtual Double? WorkActDetailSum6 { get; set; }
        /// <summary>
        /// Сумма7
        /// </summary>
        public virtual Double? WorkActDetailSum7 { get; set; }
        /// <summary>
        /// Сумма8
        /// </summary>
        public virtual Double? WorkActDetailSum8 { get; set; }
        /// <summary>
        /// Сумма9
        /// </summary>
        public virtual Double? WorkActDetailSum9 { get; set; }
        /// <summary>
        /// Сумма10
        /// </summary>
        public virtual Double? WorkActDetailSum10 { get; set; }
        /// <summary>
        /// Площадка
        /// </summary>
        public virtual String SiteCode_r { get; set; }
        /// <summary>
        /// Коэффициент
        /// </summary>
        public virtual Double? WorkActDetailMult { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Акт производственных работ
    /// </summary>
    [Serializable]
    public partial class BillWorkActHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 WorkActID { get; set; }
        /// <summary>
        /// Договор
        /// </summary>
        public virtual Int32 ContractID_r { get; set; }
        /// <summary>
        /// Биллер
        /// </summary>
        public virtual String BillerCode_r { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String WorkActName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String WorkActDesc { get; set; }
        /// <summary>
        /// Дата начала расчетного периода
        /// </summary>
        public virtual DateTime WorkActDateFrom { get; set; }
        /// <summary>
        /// Дата окончания расчетного периода
        /// </summary>
        public virtual DateTime WorkActDateTill { get; set; }
        /// <summary>
        /// Дата акта
        /// </summary>
        public virtual DateTime WorkActDate { get; set; }
        /// <summary>
        /// Дата фиксации
        /// </summary>
        public virtual DateTime? WorkActFixDate { get; set; }
        /// <summary>
        /// Дата проводки
        /// </summary>
        public virtual DateTime? WorkActPostingDate { get; set; }
        /// <summary>
        /// Номер проводки
        /// </summary>
        public virtual String WorkActPostingNumber { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public virtual String StatusCode_r { get; set; }
        /// <summary>
        /// Хост идентификатор
        /// </summary>
        public virtual String WorkActHostRef { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Операции системы
    /// </summary>
    [Serializable]
    public partial class BillOperationHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код операции
        /// </summary>
        public virtual String OperationCode { get; set; }
        /// <summary>
        /// Код класса операции
        /// </summary>
        public virtual String OperationClassCode_r { get; set; }
        /// <summary>
        /// Сущность
        /// </summary>
        public virtual String OperationEntity { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String OperationName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String OperationDesc { get; set; }
        /// <summary>
        /// Тип работы
        /// </summary>
        public virtual String WorkGroupType { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Аналитика
    /// </summary>
    [Serializable]
    public partial class BillAnalyticsHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код записи
        /// </summary>
        public virtual String AnalyticsCode { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String AnalyticsName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String AnalyticsDesc { get; set; }
        /// <summary>
        /// Родительский узел
        /// </summary>
        public virtual String AnalyticsCode_r { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения События
    /// </summary>
    [Serializable]
    public partial class WmsEventHeaderHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 EventHeaderID { get; set; }
        /// <summary>
        /// Событие
        /// </summary>
        public virtual String EventKindCode_r { get; set; }
        /// <summary>
        /// Тип клиента
        /// </summary>
        public virtual String ClientTypeCode_r { get; set; }
        /// <summary>
        /// Операция
        /// </summary>
        public virtual String OperationCode_r { get; set; }
        /// <summary>
        /// Бизнес-операция
        /// </summary>
        public virtual SYSENUM_OPERATION_BUSINESS EventHeaderOperationBusiness { get; set; }
        /// <summary>
        /// Бизнес-процесс
        /// </summary>
        public virtual String ProcessCode_r { get; set; }
        /// <summary>
        /// Экземпляр БП
        /// </summary>
        public virtual String EventHeaderInstance { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public virtual String StatusCode_r { get; set; }
        /// <summary>
        /// Статус биллинга
        /// </summary>
        public virtual String EventHeaderBillStatus { get; set; }
        /// <summary>
        /// Мандант
        /// </summary>
        public virtual WmsMandant Partner { get; set; }
        /// <summary>
        /// Время начала
        /// </summary>
        public virtual DateTime EventHeaderStartTime { get; set; }
        /// <summary>
        /// Время окончания
        /// </summary>
        public virtual DateTime? EventHeaderEndTime { get; set; }
        /// <summary>
        /// Работа
        /// </summary>
        public virtual Int32? WorkID_r { get; set; }
        /// <summary>
        /// Выполнение работ
        /// </summary>
        public virtual Int32? WorkingID_r { get; set; }
        /// <summary>
        /// Сессия
        /// </summary>
        public virtual Int32? ClientSessionID_r { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Исходящие события
    /// </summary>
    [Serializable]
    public partial class WmsOutHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 OutID { get; set; }
        /// <summary>
        /// Время события
        /// </summary>
        public virtual DateTime EventHeaderStartTime_r { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public virtual String StatusCode_r { get; set; }
        /// <summary>
        /// Вид события
        /// </summary>
        public virtual String EventKindCode_r { get; set; }
        /// <summary>
        /// Событие
        /// </summary>
        public virtual Int32 EventHeaderID_r { get; set; }
        /// <summary>
        /// Операция
        /// </summary>
        public virtual String OperationCode_r { get; set; }
        /// <summary>
        /// Бизнес-операция
        /// </summary>
        public virtual String OutOperationBusiness { get; set; }
        /// <summary>
        /// Мандант
        /// </summary>
        public virtual Int32 PartnerID_r { get; set; }
        /// <summary>
        /// Код манданта
        /// </summary>
        public virtual String MandantCode_r { get; set; }
        /// <summary>
        /// Тело сообщения
        /// </summary>
        public virtual String OutMessage { get; set; }
        /// <summary>
        /// Тип телеграммы
        /// </summary>
        public virtual String OutType { get; set; }
        /// <summary>
        /// Повторы
        /// </summary>
        public virtual Int32? OutTryCount { get; set; }
        /// <summary>
        /// Статус обработки
        /// </summary>
        public virtual Int32? Status { get; set; }
        /// <summary>
        /// Номер транзакции
        /// </summary>
        public virtual String TRXID { get; set; }
        /// <summary>
        /// Интерфейс
        /// </summary>
        public virtual String OutIO { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Выбор бизнес-операций
    /// </summary>
    [Serializable]
    public partial class BillEvent2OperationHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 Event2OperationID { get; set; }
        /// <summary>
        /// Мандант
        /// </summary>
        public virtual WmsMandant Partner { get; set; }
        /// <summary>
        /// Вид события
        /// </summary>
        public virtual String EventKindCode_r { get; set; }
        /// <summary>
        /// Операция
        /// </summary>
        public virtual String OperationCode_r { get; set; }
        /// <summary>
        /// Приоритет
        /// </summary>
        public virtual Int32 Priority { get; set; }
        /// <summary>
        /// Бизнес-операция
        /// </summary>
        public virtual String Event2OperationBusiness { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Стратегии
    /// </summary>
    [Serializable]
    public partial class BillStrategyHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код
        /// </summary>
        public virtual String StrategyCode { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String StrategyName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String StrategyDesc { get; set; }
        /// <summary>
        /// Группа стратегий
        /// </summary>
        public virtual String StrategyGroup { get; set; }
        /// <summary>
        /// Процедура стратегии
        /// </summary>
        public virtual String StrategyProcedure { get; set; }
        /// <summary>
        /// Предв. расчёт
        /// </summary>
        public virtual Boolean? StrategyAdvanceCalc { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Параметры стратегий
    /// </summary>
    [Serializable]
    public partial class BillStrategyParamsHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 StrategyParamsID { get; set; }
        /// <summary>
        /// Стратегия
        /// </summary>
        public virtual String StrategyCode_r { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String StrategyParamsName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String StrategyParamsDesc { get; set; }
        /// <summary>
        /// Тип данных
        /// </summary>
        public virtual Int32 StrategyParamsDataType { get; set; }
        /// <summary>
        /// Лукап параметра
        /// </summary>
        public virtual String StrategyParamsLookup { get; set; }
        /// <summary>
        /// Обязательный
        /// </summary>
        public virtual Boolean StrategyParamsMustSet { get; set; }
        /// <summary>
        /// Порядковый номер
        /// </summary>
        public virtual Int32 StrategyParamsIndex { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Применение стратегии
    /// </summary>
    [Serializable]
    public partial class BillStrategyUseHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 StrategyUseID { get; set; }
        /// <summary>
        /// Стратегия
        /// </summary>
        public virtual String StrategyCode_r { get; set; }
        /// <summary>
        /// Услуга по договору
        /// </summary>
        public virtual Int32 Operation2ContractID_r { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String StrategyUseName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String StrategyUseDesc { get; set; }
        /// <summary>
        /// Приоритет
        /// </summary>
        public virtual Int32 StrategyUseOrder { get; set; }
        /// <summary>
        /// Дата с
        /// </summary>
        public virtual DateTime StrategyUseFrom { get; set; }
        /// <summary>
        /// Дата до
        /// </summary>
        public virtual DateTime StrategyUseTill { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Значения применения стратегий
    /// </summary>
    [Serializable]
    public partial class BillStrategyUseValuesHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 StrategyUseValuesID { get; set; }
        /// <summary>
        /// Применение стратегии
        /// </summary>
        public virtual Int32 StrategyUseID_r { get; set; }
        /// <summary>
        /// Параметр стратегии
        /// </summary>
        public virtual Int32 StrategyParamsID_r { get; set; }
        /// <summary>
        /// Значение
        /// </summary>
        public virtual String StrategyUseValuesValue { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Типы БПП
    /// </summary>
    [Serializable]
    public partial class BillUserParamsTypeHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код
        /// </summary>
        public virtual String UserParamsTypeCode { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String UserParamsTypeName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String UserParamsTypeDesc { get; set; }
        /// <summary>
        /// Тип диапазона параметра
        /// </summary>
        public virtual String UserParamsTypeRangeType { get; set; }
        /// <summary>
        /// Тип данных параметра
        /// </summary>
        public virtual Int32 UserParamsTypeRangeDataType { get; set; }
        /// <summary>
        /// Тип данных значения
        /// </summary>
        public virtual Int32 UserParamsTypeValueDataType { get; set; }
        /// <summary>
        /// Лукап параметра
        /// </summary>
        public virtual String UserParamsTypeRangeLookup { get; set; }
        /// <summary>
        /// Лукап значения
        /// </summary>
        public virtual String UserParamsTypeValueLookup { get; set; }
        /// <summary>
        /// Вариант применения
        /// </summary>
        public virtual String UserParamsTypeUsingOption { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения БПП
    /// </summary>
    [Serializable]
    public partial class BillUserParamsHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код
        /// </summary>
        public virtual String UserParamsCode { get; set; }
        /// <summary>
        /// Тип БПП
        /// </summary>
        public virtual String UserParamsTypeCode_r { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String UserParamsName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String UserParamsDesc { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения БПП к услугам по договору
    /// </summary>
    [Serializable]
    public partial class BillUserParams2O2CHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 UserParams2O2CID { get; set; }
        /// <summary>
        /// БПП
        /// </summary>
        public virtual String UserParamsCode_r { get; set; }
        /// <summary>
        /// Услуга по договору
        /// </summary>
        public virtual Int32 Operation2ContractID_r { get; set; }
        /// <summary>
        /// Код типа применения
        /// </summary>
        public virtual String UserParams2O2CApplyCode { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Типы применения БПП
    /// </summary>
    [Serializable]
    public partial class BillUserParamsTypeApplyHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 UserParamsTypeApplyID { get; set; }
        /// <summary>
        /// Тип БПП
        /// </summary>
        public virtual String UserParamsTypeCode_r { get; set; }
        /// <summary>
        /// Код типа применения
        /// </summary>
        public virtual String UserParamsTypeApplyCode { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String UserParamsTypeApplyName { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Значения БПП
    /// </summary>
    [Serializable]
    public partial class BillUserParamsValueHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 UserParamsValueID { get; set; }
        /// <summary>
        /// БПП
        /// </summary>
        public virtual String UserParamsCode_r { get; set; }
        /// <summary>
        /// Дата с
        /// </summary>
        public virtual DateTime UserParamsValueDateFrom { get; set; }
        /// <summary>
        /// Дата по
        /// </summary>
        public virtual DateTime UserParamsValueDateTill { get; set; }
        /// <summary>
        /// Начальное значение
        /// </summary>
        public virtual String UserParamsValueFrom { get; set; }
        /// <summary>
        /// Конечное значение
        /// </summary>
        public virtual String UserParamsValueTill { get; set; }
        /// <summary>
        /// Значение БПП
        /// </summary>
        public virtual String UserParamsValueValue { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Специальная функция
    /// </summary>
    [Serializable]
    public partial class BillSpecialFunctionHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код
        /// </summary>
        public virtual String SpecialFunctionCode { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String SpecialFunctionName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String SpecialFunctionDesc { get; set; }
        /// <summary>
        /// Тело функции
        /// </summary>
        public virtual String SpecialFunctionBody { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Параметры специальной функции
    /// </summary>
    [Serializable]
    public partial class BillSpecialFuncParamsHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 SpecialFunctionParamsID { get; set; }
        /// <summary>
        /// Специальная функция
        /// </summary>
        public virtual String SpecialFunctionCode_r { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String SpecialFunctionParamsName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String SpecialFunctionParamsDesc { get; set; }
        /// <summary>
        /// Порядковый номер
        /// </summary>
        public virtual Int32 SpecialFunctionParamsOrder { get; set; }
        /// <summary>
        /// Лукап значения параметра
        /// </summary>
        public virtual String SpecialFunctionParamsLookup { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Сущности специальной функции
    /// </summary>
    [Serializable]
    public partial class BillSpecialFuncEntityHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 SpecialFunctionEntityID { get; set; }
        /// <summary>
        /// Специальная функция
        /// </summary>
        public virtual String SpecialFunctionCode_r { get; set; }
        /// <summary>
        /// Имя сущности объекта
        /// </summary>
        public virtual String SpecialFuncEntityObjectEntity { get; set; }
        /// <summary>
        /// Имя объекта
        /// </summary>
        public virtual String SpecialFuncEntityObjectAttr { get; set; }
        /// <summary>
        /// Тело функции
        /// </summary>
        public virtual String SpecialFunctionEntityBody { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Шаблон источника данных
    /// </summary>
    [Serializable]
    public partial class PattTDataSourceHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код
        /// </summary>
        public virtual String TemplateDataSourceCode { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String TemplateDataSourceName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String TemplateDataSourceDesc { get; set; }
        /// <summary>
        /// Тип
        /// </summary>
        public virtual String TemplateDataSourceType { get; set; }
        /// <summary>
        /// Тело запроса
        /// </summary>
        public virtual Byte[] TemplateDataSourceBody { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Секция полей шаблона ИД
    /// </summary>
    [Serializable]
    public partial class PattTFieldSectionHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 TemplateFieldSectionID { get; set; }
        /// <summary>
        /// Шаблон
        /// </summary>
        public virtual String TemplateDataSourceCode_r { get; set; }
        /// <summary>
        /// Код секции
        /// </summary>
        public virtual String TemplateFieldSectionCode { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String TemplateFieldSectionName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String TemplateFieldSectionDesc { get; set; }
        /// <summary>
        /// Результирующий набор
        /// </summary>
        public virtual Boolean TemplateFieldSectionResult { get; set; }
        /// <summary>
        /// Предопределенная секция
        /// </summary>
        public virtual Boolean TemplateFieldSectionDeterm { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Секция условий шаблона ИД
    /// </summary>
    [Serializable]
    public partial class PattTWhereSectionHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 TemplateWhereSectionID { get; set; }
        /// <summary>
        /// Шаблон
        /// </summary>
        public virtual String TemplateDataSourceCode_r { get; set; }
        /// <summary>
        /// Код
        /// </summary>
        public virtual String TemplateWhereSectionCode { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String TemplateWhereSectionName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String TemplateWhereSectionDesc { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Параметры шаблона ИД
    /// </summary>
    [Serializable]
    public partial class PattTParamsHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 TemplateParamsID { get; set; }
        /// <summary>
        /// Шаблон
        /// </summary>
        public virtual String TemplateDataSourceCode_r { get; set; }
        /// <summary>
        /// Код
        /// </summary>
        public virtual String TemplateParamsCode { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String TemplateParamsName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String TemplateParamsDesc { get; set; }
        /// <summary>
        /// Тип данных
        /// </summary>
        public virtual Int32 TemplateParamsDataType { get; set; }
        /// <summary>
        /// Значение по умолчанию
        /// </summary>
        public virtual String TemplateParamsValue { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Сущности условий шаблона ИД
    /// </summary>
    [Serializable]
    public partial class PattTWhereEntityHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 TemplateWhereEntityID { get; set; }
        /// <summary>
        /// Секция условий источника данных
        /// </summary>
        public virtual Int32 TemplateWhereSectionID_r { get; set; }
        /// <summary>
        /// Имя сущности объекта
        /// </summary>
        public virtual String TWhereEntityObjectEntity { get; set; }
        /// <summary>
        /// Имя объекта
        /// </summary>
        public virtual String TWhereEntityObjectAttr { get; set; }
        /// <summary>
        /// Псевдоним сущности
        /// </summary>
        public virtual String TemplateWhereEntityAliasEntity { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Поля шаблона ИД
    /// </summary>
    [Serializable]
    public partial class PattTFieldHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 TemplateFieldID { get; set; }
        /// <summary>
        /// Секция полей источника данных
        /// </summary>
        public virtual Int32 TemplateFieldSectionID_r { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String TemplateFieldName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String TemplateFieldDesc { get; set; }
        /// <summary>
        /// Псевдоним
        /// </summary>
        public virtual String TemplateFieldAlias { get; set; }
        /// <summary>
        /// Тип данных
        /// </summary>
        public virtual Int32 TemplateFieldDataType { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Сущности полей шаблона ИД
    /// </summary>
    [Serializable]
    public partial class PattTFieldEntityHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 TemplateFieldEntityID { get; set; }
        /// <summary>
        /// Секция полей источника данных
        /// </summary>
        public virtual Int32 TemplateFieldSectionID_r { get; set; }
        /// <summary>
        /// Имя сущности объекта
        /// </summary>
        public virtual String TFieldEntityObjectEntity { get; set; }
        /// <summary>
        /// Имя объекта
        /// </summary>
        public virtual String TFieldEntityObjectAttr { get; set; }
        /// <summary>
        /// Псевдоним сущности
        /// </summary>
        public virtual String TemplateFieldEntityAliasEntity { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Источник данных
    /// </summary>
    [Serializable]
    public partial class PattCalcDataSourceHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код
        /// </summary>
        public virtual String CalcDataSourceCode { get; set; }
        /// <summary>
        /// Шаблон
        /// </summary>
        public virtual String TemplateDataSourceCode_r { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String CalcDataSourceName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String CalcDataSourceDesc { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Поля источника данных
    /// </summary>
    [Serializable]
    public partial class PattCalcFieldHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 CalcFieldID { get; set; }
        /// <summary>
        /// Источник данных
        /// </summary>
        public virtual String CalcDataSourceCode_r { get; set; }
        /// <summary>
        /// Секция полей шаблона ИД
        /// </summary>
        public virtual Int32 TemplateFieldSectionID_r { get; set; }
        /// <summary>
        /// Специальная функция
        /// </summary>
        public virtual String SpecialFunctionCode_r { get; set; }
        /// <summary>
        /// Псевдоним
        /// </summary>
        public virtual String CalcFieldAlias { get; set; }
        /// <summary>
        /// 1-й параметр
        /// </summary>
        public virtual String CalcFieldFunctionParam1 { get; set; }
        /// <summary>
        /// 2-й параметр
        /// </summary>
        public virtual String CalcFieldFunctionParam2 { get; set; }
        /// <summary>
        /// 3-й параметр
        /// </summary>
        public virtual String CalcFieldFunctionParam3 { get; set; }
        /// <summary>
        /// 4-й параметр
        /// </summary>
        public virtual String CalcFieldFunctionParam4 { get; set; }
        /// <summary>
        /// 5-й параметр
        /// </summary>
        public virtual String CalcFieldFunctionParam5 { get; set; }
        /// <summary>
        /// Имя сущности объекта
        /// </summary>
        public virtual String CalcFieldObjectEntity { get; set; }
        /// <summary>
        /// Имя объекта
        /// </summary>
        public virtual String CalcFieldObjectAttr { get; set; }
        /// <summary>
        /// Псевдоним сущности
        /// </summary>
        public virtual String CalcFieldAliasEntity { get; set; }
        /// <summary>
        /// Альтернативное выражение
        /// </summary>
        public virtual String CalcFieldExpression { get; set; }
        /// <summary>
        /// Тип поля
        /// </summary>
        public virtual Int32 CalcFieldDataType { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Условия источника данных
    /// </summary>
    [Serializable]
    public partial class PattCalcWhereHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 CalcWhereID { get; set; }
        /// <summary>
        /// Источник данных
        /// </summary>
        public virtual String CalcDataSourceCode_r { get; set; }
        /// <summary>
        /// Секция условий шаблона ИД
        /// </summary>
        public virtual Int32 TemplateWhereSectionID_r { get; set; }
        /// <summary>
        /// Специальная функция
        /// </summary>
        public virtual String SpecialFunctionCode_r { get; set; }
        /// <summary>
        /// Группа условий
        /// </summary>
        public virtual Int32? CalcWhereGroup { get; set; }
        /// <summary>
        /// 1-й параметр
        /// </summary>
        public virtual String CalcWhereParam1 { get; set; }
        /// <summary>
        /// 2-й параметр
        /// </summary>
        public virtual String CalcWhereParam2 { get; set; }
        /// <summary>
        /// 3-й параметр
        /// </summary>
        public virtual String CalcWhereParam3 { get; set; }
        /// <summary>
        /// 4-й параметр
        /// </summary>
        public virtual String CalcWhereParam4 { get; set; }
        /// <summary>
        /// 5-й параметр
        /// </summary>
        public virtual String CalcWhereParam5 { get; set; }
        /// <summary>
        /// Имя сущности объекта
        /// </summary>
        public virtual String CalcWhereObjectEntity { get; set; }
        /// <summary>
        /// Имя объекта
        /// </summary>
        public virtual String CalcWhereObjectAttr { get; set; }
        /// <summary>
        /// Псевдоним сущности
        /// </summary>
        public virtual String CalcWhereAliasEntity { get; set; }
        /// <summary>
        /// Условие запроса
        /// </summary>
        public virtual String CalcWhereClause { get; set; }
        /// <summary>
        /// Альтернативное выражение
        /// </summary>
        public virtual String CalcWhereExpression { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Параметры источника данных
    /// </summary>
    [Serializable]
    public partial class PattCalcParamHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 CalcParamID { get; set; }
        /// <summary>
        /// Источник данных
        /// </summary>
        public virtual String CalcDataSourceCode_r { get; set; }
        /// <summary>
        /// Параметр шаблона ИД
        /// </summary>
        public virtual Int32 TemplateParamsID_r { get; set; }
        /// <summary>
        /// Значение
        /// </summary>
        public virtual String CalcParamValue { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Биллинговая сущность
    /// </summary>
    [Serializable]
    public partial class BillBillEntityHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код
        /// </summary>
        public virtual String BillEntityCode { get; set; }
        /// <summary>
        /// Атрибут сущности
        /// </summary>
        public virtual String BillEntityEventField { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Биллер к манданту
    /// </summary>
    [Serializable]
    public partial class BillBiller2MandantHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 Biller2MandantID { get; set; }
        /// <summary>
        /// Мандант
        /// </summary>
        public virtual WmsMandant Partner { get; set; }
        /// <summary>
        /// Биллер
        /// </summary>
        public virtual String BillerCode_r { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Настройка расчета
    /// </summary>
    [Serializable]
    public partial class BillCalcConfigHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 CalcConfigID { get; set; }
        /// <summary>
        /// Биллер
        /// </summary>
        public virtual String BillerCode_r { get; set; }
        /// <summary>
        /// Услуга по договору
        /// </summary>
        public virtual Int32 Operation2ContractID_r { get; set; }
        /// <summary>
        /// Источник данных
        /// </summary>
        public virtual String CalcDataSourceCode_r { get; set; }
        /// <summary>
        /// Биллинговая сущность
        /// </summary>
        public virtual String BillEntityCode_r { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String CalcConfigName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String CalcConfigDesc { get; set; }
        /// <summary>
        /// Блокировка
        /// </summary>
        public virtual Boolean CalcConfigLocked { get; set; }
        /// <summary>
        /// Процедура предобработки
        /// </summary>
        public virtual String CalcConfigProcBefore { get; set; }
        /// <summary>
        /// Процедура постобработки
        /// </summary>
        public virtual String CalcConfigProcAfter { get; set; }
        /// <summary>
        /// Процедура проверки
        /// </summary>
        public virtual String CalcConfigProcVerification { get; set; }
        /// <summary>
        /// Процедура расчета
        /// </summary>
        public virtual String CalcConfigProcCalc { get; set; }
        /// <summary>
        /// Процедура стратегии
        /// </summary>
        public virtual String CalcConfigProcStrategy { get; set; }
        /// <summary>
        /// Дата с
        /// </summary>
        public virtual DateTime CalcConfigDateFrom { get; set; }
        /// <summary>
        /// Дата по
        /// </summary>
        public virtual DateTime CalcConfigDateTill { get; set; }
        /// <summary>
        /// SQL-запрос
        /// </summary>
        public virtual Byte[] CalcConfigSQL { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Детализация настройки расчета
    /// </summary>
    [Serializable]
    public partial class BillCalcConfigDetailHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 CalcConfigDetailID { get; set; }
        /// <summary>
        /// Настройка расчета
        /// </summary>
        public virtual Int32 CalcConfigID_r { get; set; }
        /// <summary>
        /// Назначение
        /// </summary>
        public virtual String CalcConfigDetailDestination { get; set; }
        /// <summary>
        /// Псевдоним источника данных
        /// </summary>
        public virtual String CalcConfigDetailFieldSource { get; set; }
        /// <summary>
        /// Метод округления
        /// </summary>
        public virtual String CalcConfigDetailFieldRound { get; set; }
        /// <summary>
        /// Порядок округления
        /// </summary>
        public virtual String CalcConfigDetailFieldRoundRate { get; set; }
        /// <summary>
        /// Агригирующая функция
        /// </summary>
        public virtual String CalcConfigDetailFunc { get; set; }
        /// <summary>
        /// Метод округления агригирующей функции
        /// </summary>
        public virtual String CalcConfigDetailFuncRound { get; set; }
        /// <summary>
        /// Порядок округления агригирующей функции
        /// </summary>
        public virtual String CalcConfigDetailFuncRoundRate { get; set; }
        /// <summary>
        /// Корректировка
        /// </summary>
        public virtual Double? CalcConfigDetailCorrectRate { get; set; }
        /// <summary>
        /// Альтернативное выражение
        /// </summary>
        public virtual String CalcConfigDetailExpression { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Настройка предварительной проверки
    /// </summary>
    [Serializable]
    public partial class BillCalcVerificationHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 CalcVerificationID { get; set; }
        /// <summary>
        /// Биллер
        /// </summary>
        public virtual String BillerCode_r { get; set; }
        /// <summary>
        /// Услуга по договору
        /// </summary>
        public virtual Int32 Operation2ContractID_r { get; set; }
        /// <summary>
        /// Источник данных
        /// </summary>
        public virtual String CalcDataSourceCode_r { get; set; }
        /// <summary>
        /// Биллинговая сущность
        /// </summary>
        public virtual String BillEntityCode_r { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String CalcVerificationName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String CalcVerificationDesc { get; set; }
        /// <summary>
        /// Дата с
        /// </summary>
        public virtual DateTime CalcVerificationFrom { get; set; }
        /// <summary>
        /// Дата по
        /// </summary>
        public virtual DateTime CalcVerificationTill { get; set; }
        /// <summary>
        /// Сообщение
        /// </summary>
        public virtual String CalcVerificationMessage { get; set; }
        /// <summary>
        /// Источник ошибки
        /// </summary>
        public virtual String CalcVerificationFieldException { get; set; }
        /// <summary>
        /// Блокировка
        /// </summary>
        public virtual Boolean CalcVerificationLocked { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Настройка биллинговых событий
    /// </summary>
    [Serializable]
    public partial class BillCalcEventConfigHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 CalcEventConfigID { get; set; }
        /// <summary>
        /// Биллер
        /// </summary>
        public virtual String BillerCode_r { get; set; }
        /// <summary>
        /// Услуга по договору
        /// </summary>
        public virtual Int32 Operation2ContractID_r { get; set; }
        /// <summary>
        /// Источник данных
        /// </summary>
        public virtual String CalcDataSourceCode_r { get; set; }
        /// <summary>
        /// Биллинговая сущность
        /// </summary>
        public virtual String BillEntityCode_r { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String CalcEventConfigName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String CalcEventConfigDesc { get; set; }
        /// <summary>
        /// Дата с
        /// </summary>
        public virtual DateTime CalcEventConfigFrom { get; set; }
        /// <summary>
        /// Дата по
        /// </summary>
        public virtual DateTime CalcEventConfigFromTill { get; set; }
        /// <summary>
        /// Поле даты источника
        /// </summary>
        public virtual String CalcEventConfigFieldDate { get; set; }
        /// <summary>
        /// Блокировка
        /// </summary>
        public virtual Boolean CalcEventConfigLocked { get; set; }
        /// <summary>
        /// Вид события
        /// </summary>
        public virtual String EventKindCode_r { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения События к обработчикам
    /// </summary>
    [Serializable]
    public partial class WmsEventKind2ActionHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 EventKind2ActionID { get; set; }
        /// <summary>
        /// Вид события
        /// </summary>
        public virtual String EventKindCode_r { get; set; }
        /// <summary>
        /// Мандант
        /// </summary>
        public virtual WmsMandant Partner { get; set; }
        /// <summary>
        /// Обработчик
        /// </summary>
        public virtual String EventKind2ActionCode { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Финансовые транзакции
    /// </summary>
    [Serializable]
    public partial class BillTransactionHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 TransactionID { get; set; }
        /// <summary>
        /// Событие
        /// </summary>
        public virtual Int32 EventHeaderID_r { get; set; }
        /// <summary>
        /// Биллер
        /// </summary>
        public virtual String BillerCode_r { get; set; }
        /// <summary>
        /// Тип транзакции
        /// </summary>
        public virtual String TransactionTypeCode_r { get; set; }
        /// <summary>
        /// Плательщик
        /// </summary>
        public virtual WmsMandant Partner { get; set; }
        /// <summary>
        /// Получатель
        /// </summary>
        public virtual WmsMandant TransactionRecipient { get; set; }
        /// <summary>
        /// К услуге по договору
        /// </summary>
        public virtual Int32? Operation2ContractID_r { get; set; }
        /// <summary>
        /// Сумма
        /// </summary>
        public virtual Double TransactionAmmount { get; set; }
        /// <summary>
        /// Валюта
        /// </summary>
        public virtual String CurrencyCode_r { get; set; }
        /// <summary>
        /// Начало оказания услуги
        /// </summary>
        public virtual DateTime? TransactionDateFrom { get; set; }
        /// <summary>
        /// Окончание оказания услуги
        /// </summary>
        public virtual DateTime? TransactionDateTill { get; set; }
        /// <summary>
        /// Транзакция недействительна
        /// </summary>
        public virtual Boolean? TransactionCanceled { get; set; }
        /// <summary>
        /// Биллинговая дата
        /// </summary>
        public virtual DateTime? TransactionBillDate { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        /// <summary>
        /// HashKey
        /// </summary>
        public virtual String TransactionHashKey { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Менеджер перемещения
    /// </summary>
    [Serializable]
    public partial class WmsMMHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код
        /// </summary>
        public virtual String MMCode { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String MMName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String MMDesc { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Отношение типов ТЕ к типам ТЕ
    /// </summary>
    [Serializable]
    public partial class WmsTEType2TETypeHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 TEType2TETypeID { get; set; }
        /// <summary>
        /// Ведомый тип ТЕ
        /// </summary>
        public virtual String TEType2TETypeSlave { get; set; }
        /// <summary>
        /// Ведущий тип ТЕ
        /// </summary>
        public virtual String TEType2TETypeMaster { get; set; }
        /// <summary>
        /// Вместимость
        /// </summary>
        public virtual Int32 TEType2TETypeCapacity { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String TEType2TETypeDesc { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Отношение типов ТЕ к типам погрузчиков
    /// </summary>
    [Serializable]
    public partial class WmsTeType2TruckTypeHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 TeType2TruckTypeID { get; set; }
        /// <summary>
        /// Код типа ТЕ
        /// </summary>
        public virtual String TETypeCode_r { get; set; }
        /// <summary>
        /// Код типа погрузчика
        /// </summary>
        public virtual String TruckTypeCode_r { get; set; }
        /// <summary>
        /// Кол-во ТЕ
        /// </summary>
        public virtual Int32 TeType2TruckTypeCount { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String TeType2TruckTypeDesc { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Отношение ТЕ к блокировкам
    /// </summary>
    [Serializable]
    public partial class WmsTE2BlockingHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 TE2BlockingID { get; set; }
        /// <summary>
        /// Код ТЕ
        /// </summary>
        public virtual String TECode_r { get; set; }
        /// <summary>
        /// Код блокировки
        /// </summary>
        public virtual String BlockingCode_r { get; set; }
        /// <summary>
        /// Комментарии к блокировке
        /// </summary>
        public virtual String TE2BlockingDesc { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Справочник типов ТЕ
    /// </summary>
    [Serializable]
    public partial class WmsTETypeHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код типа ТЕ
        /// </summary>
        public virtual String TETypeCode { get; set; }
        /// <summary>
        /// Наименование типа ТЕ
        /// </summary>
        public virtual String TETypeName { get; set; }
        /// <summary>
        /// Вес пустой тары в граммах
        /// </summary>
        public virtual Decimal? TETypeTareWeight { get; set; }
        /// <summary>
        /// Длина типа ТЕ
        /// </summary>
        public virtual Int32 TETypeLength { get; set; }
        /// <summary>
        /// Ширина типа ТЕ
        /// </summary>
        public virtual Int32 TETypeWidth { get; set; }
        /// <summary>
        /// Высота типа ТЕ
        /// </summary>
        public virtual Int32 TETypeHeight { get; set; }
        /// <summary>
        /// Маскимальный разрешенный вес груза на этом типе ТЕ, в граммах
        /// </summary>
        public virtual Decimal TETypeMaxWeight { get; set; }
        /// <summary>
        /// Длина типа ТЕ внутренняя
        /// </summary>
        public virtual Int32? TETypeLengthInternal { get; set; }
        /// <summary>
        /// Ширина типа ТЕ внутренняя
        /// </summary>
        public virtual Int32? TETypeWidthInternal { get; set; }
        /// <summary>
        /// Высота типа ТЕ внутренняя
        /// </summary>
        public virtual Int32? TETypeHeightInternal { get; set; }
        /// <summary>
        /// Префикс для номера ТЕ
        /// </summary>
        public virtual String TETypeNumberPrefix { get; set; }
        /// <summary>
        /// Критерий выбора менеджера перемещения
        /// </summary>
        public virtual String TETypeSelMM { get; set; }
        /// <summary>
        /// Критерий поставки
        /// </summary>
        public virtual String TETypeCritMSC { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Отношение типов ТЕ к классам мест
    /// </summary>
    [Serializable]
    public partial class WmsTEType2PlaceClassHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 TEType2PlaceClassID { get; set; }
        /// <summary>
        /// Код типа ТЕ
        /// </summary>
        public virtual String TETypeCode_r { get; set; }
        /// <summary>
        /// Код класса места
        /// </summary>
        public virtual String PlaceClassCode_r { get; set; }
        /// <summary>
        /// Вместимость
        /// </summary>
        public virtual Int32? TEType2PlaceClassCapacity { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String TEType2PlaceClassDesc { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Типы транспортных заданий
    /// </summary>
    [Serializable]
    public partial class WmsTransportTaskTypeHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код типа транспортного задания
        /// </summary>
        public virtual String TTaskTypeCode { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String TTaskTypeName { get; set; }
        /// <summary>
        /// Приоритет
        /// </summary>
        public virtual Int32? TTaskTypePriority { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String TTaskTypeDesc { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Транспортные задания
    /// </summary>
    [Serializable]
    public partial class WmsTransportTaskHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID транспортного задания
        /// </summary>
        public virtual Int32 TTaskID { get; set; }
        /// <summary>
        /// Код ТЕ
        /// </summary>
        public virtual String TECode_r { get; set; }
        /// <summary>
        /// Код типа транспортного задания
        /// </summary>
        public virtual String TTaskTypeCode_r { get; set; }
        /// <summary>
        /// Дозагруз
        /// </summary>
        public virtual Boolean TTaskLoad { get; set; }
        /// <summary>
        /// Исходное место
        /// </summary>
        public virtual String TTaskStartPlace { get; set; }
        /// <summary>
        /// Текущее место
        /// </summary>
        public virtual String TTaskCurrentPlace { get; set; }
        /// <summary>
        /// Следующее место
        /// </summary>
        public virtual String TTaskNextPlace { get; set; }
        /// <summary>
        /// Конечное место
        /// </summary>
        public virtual String TTaskFinishPlace { get; set; }
        /// <summary>
        /// Статус транспортного задания
        /// </summary>
        public virtual String StatusCode_r { get; set; }
        /// <summary>
        /// Погрузчик
        /// </summary>
        public virtual String TruckCode_r { get; set; }
        /// <summary>
        /// Система
        /// </summary>
        public virtual String ClientCode_r { get; set; }
        /// <summary>
        /// Приоритет транспортного задания
        /// </summary>
        public virtual Int32 TTaskPriority { get; set; }
        /// <summary>
        /// Код целевой ТЕ для дозагруза на нее
        /// </summary>
        public virtual String TTaskTargetTE { get; set; }
        /// <summary>
        /// Время и дата начала выполнения
        /// </summary>
        public virtual DateTime? TTaskBegin { get; set; }
        /// <summary>
        /// Время и дата завершения выполнения
        /// </summary>
        public virtual DateTime? TTaskEnd { get; set; }
        /// <summary>
        /// Стратегия размещения
        /// </summary>
        public virtual String TransportTaskStrategy { get; set; }
        /// <summary>
        /// Мандант
        /// </summary>
        public virtual WmsMandant Partner { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Применение менеджера перемещения
    /// </summary>
    [Serializable]
    public partial class WmsMMUseHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 MMUseID { get; set; }
        /// <summary>
        /// Менеджер перемещения
        /// </summary>
        public virtual String MMCode_r { get; set; }
        /// <summary>
        /// Приоритет
        /// </summary>
        public virtual Int32 MMUsePriority { get; set; }
        /// <summary>
        /// Стратегия размещения
        /// </summary>
        public virtual String MMUseStrategy { get; set; }
        /// <summary>
        /// Дополнительное значение
        /// </summary>
        public virtual String MMUseStrategyValue { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Справочник выбора менеджера перемещения
    /// </summary>
    [Serializable]
    public partial class WmsMMSelectHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 MMSelectID { get; set; }
        /// <summary>
        /// Менеджер перемещения
        /// </summary>
        public virtual String MMCode_r { get; set; }
        /// <summary>
        /// Приоритет
        /// </summary>
        public virtual Int32 Priority { get; set; }
        /// <summary>
        /// Мандант
        /// </summary>
        public virtual Int32? PartnerID_r { get; set; }
        /// <summary>
        /// Фабрика
        /// </summary>
        public virtual Int32? FactoryID_r { get; set; }
        /// <summary>
        /// По группе артикулов
        /// </summary>
        public virtual String MMSelectArtGroup { get; set; }
        /// <summary>
        /// По группе опасности артикулов
        /// </summary>
        public virtual String MMSelectArtGroupDanger { get; set; }
        /// <summary>
        /// Критерий по SKU2TEType
        /// </summary>
        public virtual String MMSelectSKU2TTE { get; set; }
        /// <summary>
        /// Критерий по TEType
        /// </summary>
        public virtual String MMSelectTTE { get; set; }
        /// <summary>
        /// Критерий по Place
        /// </summary>
        public virtual String MMSelectPlace { get; set; }
        /// <summary>
        /// Критерий по квалификации
        /// </summary>
        public virtual String QLFCode_r { get; set; }
        /// <summary>
        /// Критерий по полноте ТЕ min
        /// </summary>
        public virtual Int32? MMSelectTECompleteMin { get; set; }
        /// <summary>
        /// Критерий по полноте ТЕ max
        /// </summary>
        public virtual Int32? MMSelectTECompleteMax { get; set; }
        /// <summary>
        /// Признак миксовой ТЕ
        /// </summary>
        public virtual Boolean MMSelectTEMix { get; set; }
        /// <summary>
        /// Исходная зона приемки
        /// </summary>
        public virtual String MMSelectSourceReceiveArea { get; set; }
        /// <summary>
        /// По позиции прихода
        /// </summary>
        public virtual String MMSelectIWBPos { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Транспортные единицы
    /// </summary>
    [Serializable]
    public partial class WmsTEHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ТЕ
        /// </summary>
        public virtual String TECode { get; set; }
        /// <summary>
        /// Тип ТЕ
        /// </summary>
        public virtual String TETypeCode_r { get; set; }
        /// <summary>
        /// Несущая
        /// </summary>
        public virtual String TECarrierBaseCode { get; set; }
        /// <summary>
        /// Промежуточная
        /// </summary>
        public virtual String TECarrierStreakCode { get; set; }
        /// <summary>
        /// Текущее место
        /// </summary>
        public virtual String TECurrentPlace { get; set; }
        /// <summary>
        /// Место создания
        /// </summary>
        public virtual String TECreationPlace { get; set; }
        /// <summary>
        /// Длина
        /// </summary>
        public virtual Int32 TELength { get; set; }
        /// <summary>
        /// Ширина
        /// </summary>
        public virtual Int32 TEWidth { get; set; }
        /// <summary>
        /// Высота
        /// </summary>
        public virtual Int32 TEHeight { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public virtual String StatusCode_r { get; set; }
        /// <summary>
        /// Статус упаковки
        /// </summary>
        public virtual String TEPackStatus { get; set; }
        /// <summary>
        /// Итоговый вес
        /// </summary>
        public virtual Int32? TEWeight { get; set; }
        /// <summary>
        /// Итоговый максимальный вес
        /// </summary>
        public virtual Decimal TEMaxWeight { get; set; }
        /// <summary>
        /// Вес тары
        /// </summary>
        public virtual Decimal? TETareWeight { get; set; }
        /// <summary>
        /// Хост-идентификатор
        /// </summary>
        public virtual String TEHostRef { get; set; }
        /// <summary>
        /// Груз на выдачу
        /// </summary>
        public virtual Int32? CargoOWBID_r { get; set; }
        /// <summary>
        /// Поставка
        /// </summary>
        public virtual Int32? SupplyChainID_r { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Отношение типов ТЕ к артикулу
    /// </summary>
    [Serializable]
    public partial class WmsSKU2TTEHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 SKU2TTEID { get; set; }
        /// <summary>
        /// Код типа ТЕ
        /// </summary>
        public virtual String TETypeCode_r { get; set; }
        /// <summary>
        /// ID записи SKU
        /// </summary>
        public virtual Int32 SKUID_r { get; set; }
        /// <summary>
        /// Тип ТЕ по умолчанию
        /// </summary>
        public virtual Boolean SKU2TTEDefault { get; set; }
        /// <summary>
        /// Стандартное кол-во товара на ТЕ
        /// </summary>
        public virtual Int32 SKU2TTEQuantity { get; set; }
        /// <summary>
        /// Максимально разрешенное кол-во товара на ТЕ
        /// </summary>
        public virtual Int32 SKU2TTEQuantityMax { get; set; }
        /// <summary>
        /// Максимально разрешенный вес товара на ТЕ
        /// </summary>
        public virtual Decimal SKU2TTEMaxWeight { get; set; }
        /// <summary>
        /// Длина с товаром
        /// </summary>
        public virtual Int32? SKU2TTELength { get; set; }
        /// <summary>
        /// Ширина с товаром
        /// </summary>
        public virtual Int32? SKU2TTEWidth { get; set; }
        /// <summary>
        /// Высота с товаром
        /// </summary>
        public virtual Int32? SKU2TTEHeight { get; set; }
        /// <summary>
        /// Критерий выбора менеджера перемещения
        /// </summary>
        public virtual String SKU2TTESelMM { get; set; }
        /// <summary>
        /// Критерий поставки
        /// </summary>
        public virtual String SKU2TTECritMSC { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Отношение типов ТЕ к мандантам
    /// </summary>
    [Serializable]
    public partial class WmsTEType2MandantHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 TEType2MandantID { get; set; }
        /// <summary>
        /// Тип ТЕ
        /// </summary>
        public virtual String TETypeCode_r { get; set; }
        /// <summary>
        /// Мандант
        /// </summary>
        public virtual WmsMandant Partner { get; set; }
        /// <summary>
        /// Автосоздание
        /// </summary>
        public virtual Boolean TEType2MandantAutoCreate { get; set; }
        /// <summary>
        /// Кол-во товара на ТЕ
        /// </summary>
        public virtual Int32? TEType2MandantQuantity { get; set; }
        /// <summary>
        /// Максимальное кол-во товара на ТЕ
        /// </summary>
        public virtual Int32? TEType2MandantQuantityMax { get; set; }
        /// <summary>
        /// Максимальный вес товара на ТЕ
        /// </summary>
        public virtual Decimal? TEType2MandantMaxWeight { get; set; }
        /// <summary>
        /// Тип ТЕ по умолчанию
        /// </summary>
        public virtual Boolean? TEType2MandantDefault { get; set; }
        /// <summary>
        /// Хост-идентификатор
        /// </summary>
        public virtual String TEType2MandantHostRef { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Машина состояний
    /// </summary>
    [Serializable]
    public partial class SysStateMachineHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 StateMachineID { get; set; }
        /// <summary>
        /// Сущность
        /// </summary>
        public virtual String ObjectName_r { get; set; }
        /// <summary>
        /// Операция
        /// </summary>
        public virtual String OperationCode_r { get; set; }
        /// <summary>
        /// Текущий статус
        /// </summary>
        public virtual String CurrentStatus { get; set; }
        /// <summary>
        /// Следующий статус
        /// </summary>
        public virtual String NextStatus { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Конфигурации к сущностям и атрибутам
    /// </summary>
    [Serializable]
    public partial class SysConfig2ObjectHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 Config2ObjectID { get; set; }
        /// <summary>
        /// Код конфигурации
        /// </summary>
        public virtual String ObjectConfigCode_r { get; set; }
        /// <summary>
        /// Имя сущности объекта
        /// </summary>
        public virtual String ObjectEntityCode_r { get; set; }
        /// <summary>
        /// Имя объекта
        /// </summary>
        public virtual String ObjectName_r { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Конфигурации
    /// </summary>
    [Serializable]
    public partial class SysObjectConfigHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код конфигурации
        /// </summary>
        public virtual String ObjectConfigCode { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String ObjectConfigName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String ObjectConfigDesc { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Сущности к конфигурациям
    /// </summary>
    [Serializable]
    public partial class SysObject2ConfigHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 Object2ConfigID { get; set; }
        /// <summary>
        /// Код конфигурации
        /// </summary>
        public virtual String ObjectConfigCode_r { get; set; }
        /// <summary>
        /// Имя объекта
        /// </summary>
        public virtual String ObjectName_r { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Системный справочник перечислений
    /// </summary>
    [Serializable]
    public partial class SysEnumHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 EnumID { get; set; }
        /// <summary>
        /// Группа объединения
        /// </summary>
        public virtual String EnumGroup { get; set; }
        /// <summary>
        /// Аттрибут для перечислителя
        /// </summary>
        public virtual String EnumKey { get; set; }
        /// <summary>
        /// Значение перечислителя
        /// </summary>
        public virtual SysEnum EnumValue { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String EnumName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String EnumDesc { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Описание системных объектов для PL
    /// </summary>
    [Serializable]
    public partial class SysObjectExtHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Сущность
        /// </summary>
        public virtual String ObjectExtEntity { get; set; }
        /// <summary>
        /// Имя объекта
        /// </summary>
        public virtual String ObjectName_r { get; set; }
        /// <summary>
        /// Заголовок объекта
        /// </summary>
        public virtual String ObjectExtCaption { get; set; }
        /// <summary>
        /// Описание объекта
        /// </summary>
        public virtual String ObjectExtDesc { get; set; }
        /// <summary>
        /// Расширенное описание объекта
        /// </summary>
        public virtual String ObjectExtDescExt { get; set; }
        /// <summary>
        /// Наименование списка
        /// </summary>
        public virtual String ObjectExtListName { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Запрещенные операции для состояния
    /// </summary>
    [Serializable]
    public partial class SysState2OperationHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 State2OperationID { get; set; }
        /// <summary>
        /// Сущность
        /// </summary>
        public virtual String ObjectName_r { get; set; }
        /// <summary>
        /// Состояние
        /// </summary>
        public virtual String StatusCode_r { get; set; }
        /// <summary>
        /// Операция
        /// </summary>
        public virtual String OperationCode_r { get; set; }
        /// <summary>
        /// Признак запрета
        /// </summary>
        public virtual Boolean State2OperationDisable { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Быстрые переходы
    /// </summary>
    [Serializable]
    public partial class SysEntityLinkHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код
        /// </summary>
        public virtual String EntityLinkCode { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String EntityLinkName { get; set; }
        /// <summary>
        /// Откуда
        /// </summary>
        public virtual String EntityLinkFrom { get; set; }
        /// <summary>
        /// Куда
        /// </summary>
        public virtual String EntityLinkTo { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String EntityLinkDesc { get; set; }
        /// <summary>
        /// Тип
        /// </summary>
        public virtual String EntityLinkType { get; set; }
        /// <summary>
        /// Фильтр
        /// </summary>
        public virtual String EntityLinkFilter { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Описание lookup-ов системных объектов
    /// </summary>
    [Serializable]
    public partial class SysObjectLookupHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код lookupа
        /// </summary>
        public virtual String ObjectLookupCode { get; set; }
        /// <summary>
        /// Ссылка на исходную сущность
        /// </summary>
        public virtual String ObjectLookupSource { get; set; }
        /// <summary>
        /// Ссылка на аттрибут исходной сущности
        /// </summary>
        public virtual String ObjectLookupDisplay { get; set; }
        /// <summary>
        /// Первичный ключ для связи
        /// </summary>
        public virtual String ObjectLookupPkey { get; set; }
        /// <summary>
        /// Формат отображения lookup
        /// </summary>
        public virtual Int32 ObjectLookupSimple { get; set; }
        /// <summary>
        /// Фильтр
        /// </summary>
        public virtual String ObjectLookupFilter { get; set; }
        /// <summary>
        /// Количество строк
        /// </summary>
        public virtual Int32? ObjectLookupFetchRowCount { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Параметры виртуальных полей
    /// </summary>
    [Serializable]
    public partial class SysObjectVirtualFieldParamHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код параметра виртуального поля
        /// </summary>
        public virtual String VirtualFieldParamCode { get; set; }
        /// <summary>
        /// Ссылка на аттрибут сущности
        /// </summary>
        public virtual String ObjectName_r { get; set; }
        /// <summary>
        /// Значение параметра
        /// </summary>
        public virtual String VirtualFieldParamValue { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Описывает базовые типы данных, сущности и их аттрибуты
    /// </summary>
    [Serializable]
    public partial class SysObjectHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID объекта
        /// </summary>
        public virtual Int32 ObjectID { get; set; }
        /// <summary>
        /// ID родительского объекта
        /// </summary>
        public virtual Int32? ObjectParentID { get; set; }
        /// <summary>
        /// Имя объекта
        /// </summary>
        public virtual String ObjectName { get; set; }
        /// <summary>
        /// Имя объекта в БД (имя типа реализующего сущность)
        /// </summary>
        public virtual String ObjectDBName { get; set; }
        /// <summary>
        /// Имя сущности объекта
        /// </summary>
        public virtual String ObjectEntityCode { get; set; }
        /// <summary>
        /// Аттрибут является первичным ключем
        /// </summary>
        public virtual Boolean? ObjectPK { get; set; }
        /// <summary>
        /// Тип данных объекта
        /// </summary>
        public virtual Int32? ObjectDataType { get; set; }
        /// <summary>
        /// Максимальная длина поля
        /// </summary>
        public virtual Int32? ObjectFieldLength { get; set; }
        /// <summary>
        /// Отношение к дочерней сущности
        /// </summary>
        public virtual String ObjectRelationship { get; set; }
        /// <summary>
        /// Значение по умолчанию
        /// </summary>
        public virtual String ObjectDefaultValue { get; set; }
        /// <summary>
        /// Ссылка на ключевое поле
        /// </summary>
        public virtual String ObjectFieldKeyLink { get; set; }
        /// <summary>
        /// Код lookup-a
        /// </summary>
        public virtual String ObjectLookupCode_r { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Дерево меню
    /// </summary>
    [Serializable]
    public partial class SysObjectTreeMenuHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код пункта меню
        /// </summary>
        public virtual String ObjectTreeCode { get; set; }
        /// <summary>
        /// Имя объекта
        /// </summary>
        public virtual String ObjectName_r { get; set; }
        /// <summary>
        /// Код родительского объекта меню
        /// </summary>
        public virtual SysObjectTreeMenu ObjectTreeParent { get; set; }
        /// <summary>
        /// Наименование пункта меню
        /// </summary>
        public virtual String ObjectTreeName { get; set; }
        /// <summary>
        /// Сортировка меню
        /// </summary>
        public virtual Int32? ObjectTreeOrder { get; set; }
        /// <summary>
        /// Команда меню
        /// </summary>
        public virtual String ObjectTreeAction { get; set; }
        /// <summary>
        /// Описание изображения - small
        /// </summary>
        public virtual String ObjectTreePictureSmall { get; set; }
        /// <summary>
        /// Описание изображения - large
        /// </summary>
        public virtual String ObjectTreePictureLarge { get; set; }
        /// <summary>
        /// Тип меню
        /// </summary>
        public virtual String ObjectTreeMenuType { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Атрибуты валидации
    /// </summary>
    [Serializable]
    public partial class SysObjectValidHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID строки
        /// </summary>
        public virtual Int32 ObjectValidID { get; set; }
        /// <summary>
        /// Наименование атрибута валидации
        /// </summary>
        public virtual String ObjectValidName { get; set; }
        /// <summary>
        /// Сущность
        /// </summary>
        public virtual String ObjectValidEntity { get; set; }
        /// <summary>
        /// Имя объекта
        /// </summary>
        public virtual String ObjectName_r { get; set; }
        /// <summary>
        /// Уровень ошибки атрибута валидации
        /// </summary>
        public virtual String ObjectValidLevel { get; set; }
        /// <summary>
        /// Сообщение к атрибуту валидации
        /// </summary>
        public virtual String ObjectValidMessage { get; set; }
        /// <summary>
        /// Параметры атрибута валидации
        /// </summary>
        public virtual String ObjectValidParameters { get; set; }
        /// <summary>
        /// Значение
        /// </summary>
        public virtual String ObjectValidValue { get; set; }
        /// <summary>
        /// Приоритет аттрибута относительно остальных
        /// </summary>
        public virtual Int32 ObjectValidPriority { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Справочник значений системных параметров
    /// </summary>
    [Serializable]
    public partial class SysGlobalParamValueHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID строки
        /// </summary>
        public virtual Int32 GParamID { get; set; }
        /// <summary>
        /// Отношение к сущности экземпляра
        /// </summary>
        public virtual String GParamVal2Entity { get; set; }
        /// <summary>
        /// Код параметра
        /// </summary>
        public virtual String GlobalParamCode_r { get; set; }
        /// <summary>
        /// Код экземпляра сущности
        /// </summary>
        public virtual String GParamValKey { get; set; }
        /// <summary>
        /// Значение параметра
        /// </summary>
        public virtual String GParamValValue { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Справочник системных параметров для сущностей Sys иWms
    /// </summary>
    [Serializable]
    public partial class SysGlobalParamHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код параметра
        /// </summary>
        public virtual String GlobalParamCode { get; set; }
        /// <summary>
        /// Отношение к сущности
        /// </summary>
        public virtual String GlobalParam2Entity { get; set; }
        /// <summary>
        /// Тип данных параметра
        /// </summary>
        public virtual Int32? GlobalParamDataType { get; set; }
        /// <summary>
        /// Количество значений

        /// </summary>
        public virtual Int32? GlobalParamCount { get; set; }
        /// <summary>
        /// Обязательное наличие параметра
        /// </summary>
        public virtual Boolean? GlobalParamMustSet { get; set; }
        /// <summary>
        /// Блокировка параметра
        /// </summary>
        public virtual Boolean? GlobalParamLocked { get; set; }
        /// <summary>
        /// Значение по-умолчанию
        /// </summary>
        public virtual String GlobalParamDefault { get; set; }
        /// <summary>
        /// Наименование параметра
        /// </summary>
        public virtual String GlobalParamName { get; set; }
        /// <summary>
        /// Описание параметра
        /// </summary>
        public virtual String GlobalParamDesc { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Системные сервисы
    /// </summary>
    [Serializable]
    public partial class SysServiceHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID сервиса
        /// </summary>
        public virtual Int32 ServiceID { get; set; }
        /// <summary>
        /// Код сервиса
        /// </summary>
        public virtual String ServiceCode { get; set; }
        /// <summary>
        /// Группа сервисов
        /// </summary>
        public virtual String ServiceGroup { get; set; }
        /// <summary>
        /// Тип сервиса
        /// </summary>
        public virtual String ServiceType { get; set; }
        /// <summary>
        /// По-умолчанию
        /// </summary>
        public virtual Boolean ServiceDefault { get; set; }
        /// <summary>
        /// Приоритет
        /// </summary>
        public virtual Int32 ServicePriority { get; set; }
        /// <summary>
        /// Доступен с
        /// </summary>
        public virtual DateTime? ServiceAvailableFrom { get; set; }
        /// <summary>
        /// Доступен по
        /// </summary>
        public virtual DateTime? ServiceAvailableTill { get; set; }
        /// <summary>
        /// Запрещение использовать
        /// </summary>
        public virtual Boolean ServiceLocked { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Архив
    /// </summary>
    [Serializable]
    public partial class SysArchInstHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// GUID
        /// </summary>
        public virtual Guid ArchInstGUID { get; set; }
        /// <summary>
        /// Конфигурация
        /// </summary>
        public virtual String ArchCode_r { get; set; }
        /// <summary>
        /// Дата архивации
        /// </summary>
        public virtual DateTime ArchInstDate { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public virtual String StatusCode_r { get; set; }
        /// <summary>
        /// Количество
        /// </summary>
        public virtual Int32? ArchInstCount { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Справочник физических цветов
    /// </summary>
    [Serializable]
    public partial class SysColorPhysicalHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Уникальный 16-ричный код цвета
        /// </summary>
        public virtual String ColorPhysicalCode { get; set; }
        /// <summary>
        /// Общепринятое наименование цвета
        /// </summary>
        public virtual String ColorPhysicalName { get; set; }
        /// <summary>
        /// Код alpha-канала, т.е. прозрачность
        /// </summary>
        public virtual String ColorPhysicalAlpha { get; set; }
        /// <summary>
        /// Уникальный код для перевода данных
        /// </summary>
        public virtual String LDCode_r { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Справочник счетчиков системы
    /// </summary>
    [Serializable]
    public partial class SysSequenceHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код счетчика
        /// </summary>
        public virtual String SequenceCode { get; set; }
        /// <summary>
        /// Начало диапазона
        /// </summary>
        public virtual Int32 SequenceMinValue { get; set; }
        /// <summary>
        /// Окончание диапазона
        /// </summary>
        public virtual Int32? SequenceMaxValue { get; set; }
        /// <summary>
        /// Начальное значение
        /// </summary>
        public virtual Int32 SequenceStartValue { get; set; }
        /// <summary>
        /// Шаг и направление движения
        /// </summary>
        public virtual Int32 SequenceIncrement { get; set; }
        /// <summary>
        /// Кешируемое количество
        /// </summary>
        public virtual Int32 SequenceCache { get; set; }
        /// <summary>
        /// Цикличность
        /// </summary>
        public virtual Boolean SequenceCycle { get; set; }
        /// <summary>
        /// Наименование счетчика
        /// </summary>
        public virtual String SequenceName { get; set; }
        /// <summary>
        /// Описание счетчика
        /// </summary>
        public virtual String SequenceDesc { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Справочник языковых данных
    /// </summary>
    [Serializable]
    public partial class LangDataHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Уникальный код для перевода данных
        /// </summary>
        public virtual String LDCode { get; set; }
        /// <summary>
        /// Код языка
        /// </summary>
        public virtual String LangCode_r { get; set; }
        /// <summary>
        /// Данные полей вида ...Name
        /// </summary>
        public virtual String LDName { get; set; }
        /// <summary>
        /// Данные полей вида ...Description
        /// </summary>
        public virtual String LDDescription { get; set; }
        /// <summary>
        /// Данные полей вида ...Full
        /// </summary>
        public virtual String LDDescriptionExt { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Конфигурация архива
    /// </summary>
    [Serializable]
    public partial class SysArchHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код
        /// </summary>
        public virtual String ArchCode { get; set; }
        /// <summary>
        /// Тип действия
        /// </summary>
        public virtual String ArchType { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String ArchName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String ArchDesc { get; set; }
        /// <summary>
        /// Batch
        /// </summary>
        public virtual String ArchBatch { get; set; }
        /// <summary>
        /// Последовательность
        /// </summary>
        public virtual Int32 ArchOrder { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        /// <summary>
        /// Тип таблицы
        /// </summary>
        public virtual String ArchDataType { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Кнопка
    /// </summary>
    [Serializable]
    public partial class SysUIButtonHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код
        /// </summary>
        public virtual String UIButtonCode { get; set; }
        /// <summary>
        /// Панель
        /// </summary>
        public virtual String UIButtonPanel { get; set; }
        /// <summary>
        /// Родительская кнопка
        /// </summary>
        public virtual String UIButtonParent { get; set; }
        /// <summary>
        /// Последовательность
        /// </summary>
        public virtual Int32 UIButtonOrder { get; set; }
        /// <summary>
        /// Заголовок
        /// </summary>
        public virtual String UIButtonCaption { get; set; }
        /// <summary>
        /// Подсказка
        /// </summary>
        public virtual String UIButtonHint { get; set; }
        /// <summary>
        /// Горячая клавиша
        /// </summary>
        public virtual String UIButtonHotKey { get; set; }
        /// <summary>
        /// Изображение
        /// </summary>
        public virtual String UIButtonImage { get; set; }
        /// <summary>
        /// Условие доступности
        /// </summary>
        public virtual String UIButtonEnableFilter { get; set; }
        /// <summary>
        /// Условие видимости
        /// </summary>
        public virtual String UIButtonVisibleFilter { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String UIButtonDesc { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Права на доступ к мандантам
    /// </summary>
    [Serializable]
    public partial class WmsUser2MandantHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 User2MandantID { get; set; }
        /// <summary>
        /// Код пользователя
        /// </summary>
        public virtual WmsUser User { get; set; }
        /// <summary>
        /// Мандант
        /// </summary>
        public virtual WmsMandant Partner { get; set; }
        /// <summary>
        /// Активный
        /// </summary>
        public virtual Boolean User2MandantIsActive { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Справочник бизнес-партнеров
    /// </summary>
    [Serializable]
    public partial class WmsPartnerHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 PartnerID { get; set; }
        /// <summary>
        /// Код
        /// </summary>
        public virtual String PartnerCode { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String PartnerName { get; set; }
        /// <summary>
        /// Полное наименование
        /// </summary>
        public virtual String PartnerFullName { get; set; }
        /// <summary>
        /// Мандант
        /// </summary>
        public virtual WmsMandant PartnerLink2Mandant { get; set; }
        /// <summary>
        /// Владелец
        /// </summary>
        public virtual Int32? PartnerParent { get; set; }
        /// <summary>
        /// Вид организации
        /// </summary>
        public virtual String PartnerKind { get; set; }
        /// <summary>
        /// Блокирован
        /// </summary>
        public virtual Boolean PartnerLocked { get; set; }
        /// <summary>
        /// Договор
        /// </summary>
        public virtual String PartnerContract { get; set; }
        /// <summary>
        /// Дата заключения договора
        /// </summary>
        public virtual DateTime? PartnerDateContract { get; set; }
        /// <summary>
        /// Телефон
        /// </summary>
        public virtual String PartnerPhone { get; set; }
        /// <summary>
        /// Факс
        /// </summary>
        public virtual String PartnerFax { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public virtual String PartnerEmail { get; set; }
        /// <summary>
        /// ИНН
        /// </summary>
        public virtual String PartnerINN { get; set; }
        /// <summary>
        /// КПП
        /// </summary>
        public virtual String PartnerKPP { get; set; }
        /// <summary>
        /// ОГРН
        /// </summary>
        public virtual String PartnerOGRN { get; set; }
        /// <summary>
        /// ОКПО
        /// </summary>
        public virtual String PartnerOKPO { get; set; }
        /// <summary>
        /// ОКВЕД
        /// </summary>
        public virtual String PartnerOKVED { get; set; }
        /// <summary>
        /// Расчетный счет
        /// </summary>
        public virtual String PartnerSettlementAccount { get; set; }
        /// <summary>
        /// Корреспондентский счет
        /// </summary>
        public virtual String PartnerCorrespondentAccount { get; set; }
        /// <summary>
        /// БИК
        /// </summary>
        public virtual String PartnerBIK { get; set; }
        /// <summary>
        /// Срок коммерциализации
        /// </summary>
        public virtual Int32? PartnerCommercTime { get; set; }
        /// <summary>
        /// ЕИ СК
        /// </summary>
        public virtual String PartnerCommercTimeMeasure { get; set; }
        /// <summary>
        /// Ref
        /// </summary>
        public virtual String PartnerHostRef { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Партнеры к группам
    /// </summary>
    [Serializable]
    public partial class WmsPartner2GroupHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 Partner2GroupID { get; set; }
        /// <summary>
        /// Группа партнеров
        /// </summary>
        public virtual Int32 PartnerGroupID_r { get; set; }
        /// <summary>
        /// Партнер
        /// </summary>
        public virtual Int32 PartnerID_r { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Группы партнеров
    /// </summary>
    [Serializable]
    public partial class WmsPartnerGroupHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 PartnerGroupID { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String PartnerGroupName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String PartnerGroupDesc { get; set; }
        /// <summary>
        /// Критерий поставки
        /// </summary>
        public virtual String PartnerGroupCritMSC { get; set; }
        /// <summary>
        /// Идентификатор в хост-системе
        /// </summary>
        public virtual String PartnerGroupHostRef { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Фабрика
    /// </summary>
    [Serializable]
    public partial class WmsFactoryHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 FactoryID { get; set; }
        /// <summary>
        /// Код
        /// </summary>
        public virtual String FactoryCode { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String FactoryName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String FactoryDesc { get; set; }
        /// <summary>
        /// Мандант
        /// </summary>
        public virtual WmsMandant Partner { get; set; }
        /// <summary>
        /// Batch-код
        /// </summary>
        public virtual String FactoryBatchCode { get; set; }
        /// <summary>
        /// Идентификатор в хост-системе
        /// </summary>
        public virtual String FactoryHostRef { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Отношение партнеров к адресам
    /// </summary>
    [Serializable]
    public partial class WmsPartner2AddressBookHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код партнера
        /// </summary>
        public virtual WmsMandant Partner { get; set; }
        /// <summary>
        /// ID адреса
        /// </summary>
        public virtual Int32 AddressBookID_r { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Контактные лица
    /// </summary>
    [Serializable]
    public partial class WmsEmployeeHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 EmployeeID { get; set; }
        /// <summary>
        /// Партнер
        /// </summary>
        public virtual WmsMandant PartnerID_r { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public virtual String EmployeeLastName { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        public virtual String EmployeeName { get; set; }
        /// <summary>
        /// Отчество
        /// </summary>
        public virtual String EmployeeMiddleName { get; set; }
        /// <summary>
        /// Мобильный
        /// </summary>
        public virtual String EmployeeMobile { get; set; }
        /// <summary>
        /// Рабочий
        /// </summary>
        public virtual String EmployeePhoneWork { get; set; }
        /// <summary>
        /// Внутренний
        /// </summary>
        public virtual String EmployeePhoneInternal { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public virtual String EmployeeEmail { get; set; }
        /// <summary>
        /// Должность
        /// </summary>
        public virtual String EmployeeOfficialCapacity { get; set; }
        /// <summary>
        /// Подразделение
        /// </summary>
        public virtual String EmployeeDepartment { get; set; }
        /// <summary>
        /// По-умолчанию
        /// </summary>
        public virtual Boolean? EmployeeIsDefault { get; set; }
        /// <summary>
        /// Идентификатор контакного лица в хост-системе 
        /// </summary>
        public virtual String EmployeeHostRef { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Контакты партнера к расходу
    /// </summary>
    [Serializable]
    public partial class WmsEmployee2OWBHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 Employee2OWBID { get; set; }
        /// <summary>
        /// Контакт
        /// </summary>
        public virtual Int32 EmployeeID_r { get; set; }
        /// <summary>
        /// Расходная накладная
        /// </summary>
        public virtual Int32 OWBID_r { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Клиенты
    /// </summary>
    [Serializable]
    public partial class ecomClientHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 ClientID { get; set; }
        /// <summary>
        /// Мандант
        /// </summary>
        public virtual WmsMandant PartnerID_r { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public virtual String ClientLastName { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        public virtual String ClientName { get; set; }
        /// <summary>
        /// Очество
        /// </summary>
        public virtual String ClientMiddleName { get; set; }
        /// <summary>
        /// Мобильный телефон
        /// </summary>
        public virtual String ClientPhoneMobile { get; set; }
        /// <summary>
        /// Рабочий телефон
        /// </summary>
        public virtual String ClientPhoneWork { get; set; }
        /// <summary>
        /// Добавочный номер
        /// </summary>
        public virtual String ClientPhoneInternal { get; set; }
        /// <summary>
        /// Домашний телефон
        /// </summary>
        public virtual String ClientPhoneHome { get; set; }
        /// <summary>
        /// E-mail
        /// </summary>
        public virtual String ClientEmail { get; set; }
        /// <summary>
        /// HostRef
        /// </summary>
        public virtual String ClientHostRef { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Адреса клиентов
    /// </summary>
    [Serializable]
    public partial class ecomClient2AddressBookHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 Client2AddressBookID { get; set; }
        /// <summary>
        /// Клиент
        /// </summary>
        public virtual Int32 ClientID_r { get; set; }
        /// <summary>
        /// Адрес
        /// </summary>
        public virtual Int32 AddressBookID_r { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Файл
    /// </summary>
    [Serializable]
    public partial class WmsFileHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 FileID { get; set; }
        /// <summary>
        /// Сущность
        /// </summary>
        public virtual String File2Entity { get; set; }
        /// <summary>
        /// Экземпляр
        /// </summary>
        public virtual String FileKey { get; set; }
        /// <summary>
        /// Имя файла
        /// </summary>
        public virtual String FileName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String FileDesc { get; set; }
        /// <summary>
        /// Связь БД
        /// </summary>
        public virtual String FileLink { get; set; }
        /// <summary>
        /// Размер
        /// </summary>
        public virtual Int32? FileSize { get; set; }
        /// <summary>
        /// Версия файла
        /// </summary>
        public virtual String FileVersion { get; set; }
        /// <summary>
        /// Файл
        /// </summary>
        public virtual String DBFile { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        /// <summary>
        /// Данные
        /// </summary>
        public virtual Byte[] FileData { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Квалификация
    /// </summary>
    [Serializable]
    public partial class WmsQLFHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код
        /// </summary>
        public virtual String QLFCode { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String QLFName { get; set; }
        /// <summary>
        /// Тип
        /// </summary>
        public virtual String QLFType { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String QLFDesc { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Детализация квалификации
    /// </summary>
    [Serializable]
    public partial class WmsQLFDetailHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код
        /// </summary>
        public virtual String QLFDetailCode { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String QLFDetailName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String QLFDetailDesc { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Детализация квалификации к мандантам
    /// </summary>
    [Serializable]
    public partial class WmsQLFDetail2MandantHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 QLFDetail2MandantID { get; set; }
        /// <summary>
        /// Детализация квалификации
        /// </summary>
        public virtual String QLFDetailCode_r { get; set; }
        /// <summary>
        /// Мандант
        /// </summary>
        public virtual WmsMandant Partner { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Квалификация к мандантам
    /// </summary>
    [Serializable]
    public partial class WmsQLF2MandantHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 QLF2MandantID { get; set; }
        /// <summary>
        /// Квалификация
        /// </summary>
        public virtual String QLFCode_r { get; set; }
        /// <summary>
        /// Мандант
        /// </summary>
        public virtual WmsMandant Partner { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Служит для представления сущностей на разных языках
    /// </summary>
    [Serializable]
    public partial class WmsEntityLangDataHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Таблица сущности
        /// </summary>
        public virtual String EntityLDTable { get; set; }
        /// <summary>
        /// Код строки сущности
        /// </summary>
        public virtual String EntityLDKey { get; set; }
        /// <summary>
        /// Код языка
        /// </summary>
        public virtual String LangCode_r { get; set; }
        /// <summary>
        /// Короткое имя сущности
        /// </summary>
        public virtual String EntityLDShortName { get; set; }
        /// <summary>
        /// Обычное имя сущности
        /// </summary>
        public virtual String EntityLDName { get; set; }
        /// <summary>
        /// Длинное имя сущности
        /// </summary>
        public virtual String EntityLDLongName { get; set; }
        /// <summary>
        /// Описание сущности
        /// </summary>
        public virtual String EntityLDDescription { get; set; }
        /// <summary>
        /// Расширенное описание сущности
        /// </summary>
        public virtual String EntityLDDescExt { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Статусы сущностей
    /// </summary>
    [Serializable]
    public partial class WmsStatusHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код статуса
        /// </summary>
        public virtual String StatusCode { get; set; }
        /// <summary>
        /// Сущность
        /// </summary>
        public virtual String Status2Entity { get; set; }
        /// <summary>
        /// Наименование статуса
        /// </summary>
        public virtual String StatusName { get; set; }
        /// <summary>
        /// Описание статуса
        /// </summary>
        public virtual String StatusDesc { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Пользовательские перечисления
    /// </summary>
    [Serializable]
    public partial class WmsUserEnumHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 UserEnumID { get; set; }
        /// <summary>
        /// Группа объединения
        /// </summary>
        public virtual String UserEnumGroup { get; set; }
        /// <summary>
        /// Аттрибут для перечислителя
        /// </summary>
        public virtual String UserEnumKey { get; set; }
        /// <summary>
        /// Значение перечислителя
        /// </summary>
        public virtual WmsUserEnum UserEnumValue { get; set; }
        /// <summary>
        /// Наименование перечисления
        /// </summary>
        public virtual String UserEnumName { get; set; }
        /// <summary>
        /// Описание элемента перечисления
        /// </summary>
        public virtual String UserEnumDesc { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Справочник блокировок
    /// </summary>
    [Serializable]
    public partial class WmsProductBlockingHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код блокировки
        /// </summary>
        public virtual String BlockingCode { get; set; }
        /// <summary>
        /// Идентификатор блокировки в хост-системе
        /// </summary>
        public virtual String BlockingHostRef { get; set; }
        /// <summary>
        /// Наименование блокировки
        /// </summary>
        public virtual String BlockingName { get; set; }
        /// <summary>
        /// Описание блокировки
        /// </summary>
        public virtual String BlockingDesc { get; set; }
        /// <summary>
        /// Признак товарной блокировки
        /// </summary>
        public virtual Boolean? BlockingForProduct { get; set; }
        /// <summary>
        /// Признак транспортной блокировки
        /// </summary>
        public virtual Boolean? BlockingForTE { get; set; }
        /// <summary>
        /// Признак топологической блокировки
        /// </summary>
        public virtual Boolean? BlockingForPlace { get; set; }
        /// <summary>
        /// Запрет использования блокировки
        /// </summary>
        public virtual Boolean? BlockingLocked { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Справочник типов НДС
    /// </summary>
    [Serializable]
    public partial class WmsVATTypeHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код записи
        /// </summary>
        public virtual String VATTypeCode { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String VATTypeName { get; set; }
        /// <summary>
        /// Процентная ставка
        /// </summary>
        public virtual Double VATTypeInterestRate { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Справочник типов единиц измерения
    /// </summary>
    [Serializable]
    public partial class WmsMeasureTypeHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код типа единицы измерения
        /// </summary>
        public virtual String MeasureTypeCode { get; set; }
        /// <summary>
        /// Наименование типа единицы измерения
        /// </summary>
        public virtual String MeasureTypeName { get; set; }
        /// <summary>
        /// Описание типа единицы измерения
        /// </summary>
        public virtual String MeasureTypeDesc { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Справочник единиц измерения
    /// </summary>
    [Serializable]
    public partial class WmsMeasureHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код ЕИ. Международный код единицы измерения
        /// </summary>
        public virtual String MeasureCode { get; set; }
        /// <summary>
        /// Клд типа ЕИ
        /// </summary>
        public virtual String MeasureTypeCode_r { get; set; }
        /// <summary>
        /// Признак базовой ЕИ
        /// </summary>
        public virtual Boolean MeasurePrimary { get; set; }
        /// <summary>
        /// Коэффициент пересчета к базовой ЕИ

        /// </summary>
        public virtual Double MeasureFactor { get; set; }
        /// <summary>
        /// ЕИ по умолчанию
        /// </summary>
        public virtual Boolean MeasureDefault { get; set; }
        /// <summary>
        /// Сокращенное наименование ЕИ
        /// </summary>
        public virtual String MeasureShortName { get; set; }
        /// <summary>
        /// Наименование ЕИ
        /// </summary>
        public virtual String MeasureName { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Пользовательские параметры
    /// </summary>
    [Serializable]
    public partial class WmsCustomParamHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Параметр
        /// </summary>
        public virtual String CustomParamCode { get; set; }
        /// <summary>
        /// Сущность
        /// </summary>
        public virtual String CustomParam2Entity { get; set; }
        /// <summary>
        /// ГК источник
        /// </summary>
        public virtual String CustomParamSource { get; set; }
        /// <summary>
        /// ГК потребитель
        /// </summary>
        public virtual String CustomParamTarget { get; set; }
        /// <summary>
        /// Тип данных
        /// </summary>
        public virtual Int32 CustomParamDataType { get; set; }
        /// <summary>
        /// Количество значений
        /// </summary>
        public virtual Int32 CustomParamCount { get; set; }
        /// <summary>
        /// Обязательный параметр
        /// </summary>
        public virtual Boolean CustomParamMustSet { get; set; }
        /// <summary>
        /// Обязательный для сущности
        /// </summary>
        public virtual Boolean CustomParamMustHave { get; set; }
        /// <summary>
        /// Значение по-умолчанию
        /// </summary>
        public virtual String CustomParamDefault { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String CustomParamName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String CustomParamDesc { get; set; }
        /// <summary>
        /// Владелец
        /// </summary>
        public virtual WmsCustomParam Parent { get; set; }
        /// <summary>
        /// Формат отображения
        /// </summary>
        public virtual String CustomParamFormat { get; set; }
        /// <summary>
        /// Запрет ввода
        /// </summary>
        public virtual Boolean CustomParamInputDisable { get; set; }
        /// <summary>
        /// Lookup
        /// </summary>
        public virtual String ObjectLookupCode_r { get; set; }
        /// <summary>
        /// Режим сохранения
        /// </summary>
        public virtual Boolean? CustomParamSaveMode { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Значения пользовательских параметров
    /// </summary>
    [Serializable]
    public partial class WmsCustomParamValueHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 CPVID { get; set; }
        /// <summary>
        /// Параметр
        /// </summary>
        public virtual String CustomParamCode_r { get; set; }
        /// <summary>
        /// Значение
        /// </summary>
        public virtual String CPVValue { get; set; }
        /// <summary>
        /// Владелец
        /// </summary>
        public virtual WmsCustomParamValue Parent { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Справочник адресов
    /// </summary>
    [Serializable]
    public partial class WmsAddressBookHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID адреса
        /// </summary>
        public virtual Int32 AddressBookID { get; set; }
        /// <summary>
        /// Страна
        /// </summary>
        public virtual String AddressBookCountry { get; set; }
        /// <summary>
        /// Почтовый индекс
        /// </summary>
        public virtual Int32? AddressBookIndex { get; set; }
        /// <summary>
        /// Регион (регион, область, район, край)

        /// </summary>
        public virtual String AddressBookRegion { get; set; }
        /// <summary>
        /// Город
        /// </summary>
        public virtual String AddressBookCity { get; set; }
        /// <summary>
        /// Район
        /// </summary>
        public virtual String AddressBookDistrict { get; set; }
        /// <summary>
        /// Улица
        /// </summary>
        public virtual String AddressBookStreet { get; set; }
        /// <summary>
        /// Здание
        /// </summary>
        public virtual String AddressBookBuilding { get; set; }
        /// <summary>
        /// Квартира или офис
        /// </summary>
        public virtual String AddressBookApartment { get; set; }
        /// <summary>
        /// Тип адреса

        /// </summary>
        public virtual String AddressBookTypeCode { get; set; }
        /// <summary>
        /// Необработанный адрес
        /// </summary>
        public virtual String AddressBookRaw { get; set; }
        /// <summary>
        /// По умолчанию
        /// </summary>
        public virtual Boolean? AddressBookDefault { get; set; }
        /// <summary>
        /// HostRef
        /// </summary>
        public virtual String AddressBookHostRef { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Параметры к мандантам
    /// </summary>
    [Serializable]
    public partial class WmsCP2MandantHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 CP2MandantID { get; set; }
        /// <summary>
        /// Мандант
        /// </summary>
        public virtual WmsMandant Partner { get; set; }
        /// <summary>
        /// Параметр
        /// </summary>
        public virtual String CustomParamCode_r { get; set; }
        /// <summary>
        /// Обязательный параметр
        /// </summary>
        public virtual Boolean CP2MandantMustSet { get; set; }
        /// <summary>
        /// Сортировка
        /// </summary>
        public virtual Int32 CP2MandantOrder { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Значения пользовательских параметров
    /// </summary>
    [Serializable]
    public partial class WmsCustomParamValueOWBHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 CPVID { get; set; }
        /// <summary>
        /// Параметр
        /// </summary>
        public virtual String CustomParamCode_r { get; set; }
        /// <summary>
        /// Значение
        /// </summary>
        public virtual String CPVValue { get; set; }
        /// <summary>
        /// Владелец
        /// </summary>
        public virtual WmsCustomParamValue Parent { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Заголовок транзита
    /// </summary>
    [Serializable]
    public partial class WmsTransitHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 TransitID { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String TransitName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String TransitDesc { get; set; }
        /// <summary>
        /// Мандант
        /// </summary>
        public virtual WmsMandant Partner { get; set; }
        /// <summary>
        /// Сущность
        /// </summary>
        public virtual String Transit2Entity { get; set; }
        /// <summary>
        /// Отображать в интерфейсе
        /// </summary>
        public virtual Boolean TransitV2GUI { get; set; }
        /// <summary>
        /// Идентификатор в хост-системе
        /// </summary>
        public virtual String TransitHostRef { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Транзитные данные
    /// </summary>
    [Serializable]
    public partial class WmsTransitDataHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 TransitDataID { get; set; }
        /// <summary>
        /// Заголовок
        /// </summary>
        public virtual Int32 TransitID_r { get; set; }
        /// <summary>
        /// Экземпляр сущности
        /// </summary>
        public virtual String TransitDataKey { get; set; }
        /// <summary>
        /// Значение
        /// </summary>
        public virtual String TransitDataValue { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Справочник клиентских цветов
    /// </summary>
    [Serializable]
    public partial class WmsPartnerColorHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 PartnerColorID { get; set; }
        /// <summary>
        /// Мандант
        /// </summary>
        public virtual WmsMandant PartnerID_r { get; set; }
        /// <summary>
        /// Код цвета
        /// </summary>
        public virtual String PartnerColorCode { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String PartnerColorName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String PartnerColorDesc { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Справочник типов системных ошибок
    /// </summary>
    [Serializable]
    public partial class SysErrorTypeHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код типа ошибки
        /// </summary>
        public virtual String ErrorTypeCode { get; set; }
        /// <summary>
        /// Уникальный код для перевода данных
        /// </summary>
        public virtual String LDCode_r { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Справочник системных ошибок
    /// </summary>
    [Serializable]
    public partial class SysErrorHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код ошибки
        /// </summary>
        public virtual String ErrorCode { get; set; }
        /// <summary>
        /// Класс исключения(хранит классы исключений)
        /// </summary>
        public virtual String ExceptionClass { get; set; }
        /// <summary>
        /// Уникальный код для перевода данных
        /// </summary>
        public virtual String LDCode_r { get; set; }
        /// <summary>
        /// Код типа ошибки
        /// </summary>
        public virtual String ErrorTypeCode_r { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Справочник статусов системных событий
    /// </summary>
    [Serializable]
    public partial class SysEventStatusHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код статуса события
        /// </summary>
        public virtual String EventStatusCode { get; set; }
        /// <summary>
        /// Уникальный код для перевода данных
        /// </summary>
        public virtual String LDCode_r { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Справочник сообщений логов
    /// </summary>
    [Serializable]
    public partial class SysLogMessageHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код сообщения
        /// </summary>
        public virtual String LogMessageCode { get; set; }
        /// <summary>
        /// Уровень логирования
        /// </summary>
        public virtual Int32 LogMessageLevel { get; set; }
        /// <summary>
        /// Уникальный код для перевода данных
        /// </summary>
        public virtual String LDCode_r { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Журнал системных событий
    /// </summary>
    [Serializable]
    public partial class SysEventHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код системного события
        /// </summary>
        public virtual Int32 EventID { get; set; }
        /// <summary>
        /// Код статуса события
        /// </summary>
        public virtual String EventStatusCode_r { get; set; }
        /// <summary>
        /// Дата и время события
        /// </summary>
        public virtual DateTime EventDate { get; set; }
        /// <summary>
        /// Код ошибки
        /// </summary>
        public virtual String ErrorCode_r { get; set; }
        /// <summary>
        /// Имя хоста(ПК или сервер)
        /// </summary>
        public virtual String Host_r { get; set; }
        /// <summary>
        /// Имя хоста (DNS имя, IP допустимо), на котором работает сервис, инициировавший запись
        /// </summary>
        public virtual String SystemHost_r { get; set; }
        /// <summary>
        /// Имя системного пользователя, под которым работает SystemHost
        /// </summary>
        public virtual String SystemLogin_r { get; set; }
        /// <summary>
        /// Имя модуля/приложения/сервиса, инициировавшего событие
        /// </summary>
        public virtual String Module { get; set; }
        /// <summary>
        /// Версия модуля/приложения/сервиса
        /// </summary>
        public virtual String ModuleVersion { get; set; }
        /// <summary>
        /// Имя объекта в коде(имя процедуры, функции, откуда пришло событие)
        /// </summary>
        public virtual String CodeObjectName { get; set; }
        /// <summary>
        /// Содержание события(служебная информация - содержание текста ошибки Exception.Message)
        /// </summary>
        public virtual String EventMessage { get; set; }
        /// <summary>
        /// Трассировка стека(содержание Exception.StackTrace)
        /// </summary>
        public virtual String StackTrace { get; set; }
        /// <summary>
        /// Содержит текстовое название бизнес-процесса, в процессе выполнения которого возникла ошибка.
        /// </summary>
        public virtual String BP { get; set; }
        /// <summary>
        /// Последовательный номер очередного запуска процесса. 
        /// </summary>
        public virtual Int32? BPUniqueNum { get; set; }
        /// <summary>
        /// Связь с какой-либо сущностью системы по ее коду.
        /// </summary>
        public virtual String LinkByID { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Конфигурация физических принтеров
    /// </summary>
    [Serializable]
    public partial class EpsPrinterPhysicalHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Полное имя физического принтера, установленного на принт-сервере.

        /// </summary>
        public virtual String PhysicalPrinter { get; set; }
        /// <summary>
        /// Признак блокировки принтера логического(при блокировке печать не осуществляется).

        /// </summary>
        public virtual Boolean PhysicalPrinterLocked { get; set; }
        /// <summary>
        /// Описание принтера
        /// </summary>
        public virtual String PhysicalPrinterDesc { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Хранилище печатных форм и отчетов системы
    /// </summary>
    [Serializable]
    public partial class WmsReportFileHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Уникальный Id  отчета(reportfile_gen)
        /// </summary>
        public virtual Int32 ReportFileId { get; set; }
        /// <summary>
        /// Файл отчета (наименование с расширением)
        /// </summary>
        public virtual String ReportFile { get; set; }
        /// <summary>
        /// Хеш-код тела файла отчета
        /// </summary>
        public virtual String ReportFileHashCode { get; set; }
        /// <summary>
        /// Подкаталог хранения файла
        /// </summary>
        public virtual String ReportFileSubFolder { get; set; }
        /// <summary>
        /// Признак блокировки файла отчета для печати
        /// </summary>
        public virtual Boolean ReportFileLocked { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String ReportFileName { get; set; }
        /// <summary>
        /// Описание файла отчета
        /// </summary>
        public virtual String ReportFileDesc { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Конфигурация печатных форм
    /// </summary>
    [Serializable]
    public partial class EpsConfigHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID строки(epsconfig_gen)
        /// </summary>
        public virtual Int32 EpsConfigID { get; set; }
        /// <summary>
        /// Код параметра
        /// </summary>
        public virtual String EpsConfigParamCode { get; set; }
        /// <summary>
        /// Значение параметра
        /// </summary>
        public virtual String EpsConfigValue { get; set; }
        /// <summary>
        /// Жесткая привязка значения

        /// </summary>
        public virtual Boolean EpsConfigStrongUse { get; set; }
        /// <summary>
        /// Признак блокировки параметра
        /// </summary>
        public virtual Boolean EpsConfigLocked { get; set; }
        /// <summary>
        /// Описание параметра отчета
        /// </summary>
        public virtual String EpsConfigDesc { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Задания для EPS
    /// </summary>
    [Serializable]
    public partial class EpsJobHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код задания
        /// </summary>
        public virtual String JobCode { get; set; }
        /// <summary>
        /// Наименование задания
        /// </summary>
        public virtual String JobName { get; set; }
        /// <summary>
        /// Описание задания
        /// </summary>
        public virtual String JobDesc { get; set; }
        /// <summary>
        /// Блокировка задания
        /// </summary>
        public virtual Boolean JobLocked { get; set; }
        /// <summary>
        /// Обработчик отчета
        /// </summary>
        public virtual Int32? JobHandler { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Справочник переопределения печатных форм
    /// </summary>
    [Serializable]
    public partial class WmsReportRedefinitionHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID строки переопределения
        /// </summary>
        public virtual Int32 ReportRedefinitionID { get; set; }
        /// <summary>
        /// Исходный отчет, подлежащий переопределению
        /// </summary>
        public virtual String Report_r { get; set; }
        /// <summary>
        /// Код манданта
        /// </summary>
        public virtual Int32? PartnerID_r { get; set; }
        /// <summary>
        /// Завод-изготовитель изделия
        /// </summary>
        public virtual WmsMandant Factory_r { get; set; }
        /// <summary>
        /// Группа артикула
        /// </summary>
        public virtual String ArtGroup_r { get; set; }
        /// <summary>
        /// Тип транспортной единицы
        /// </summary>
        public virtual String TeType_r { get; set; }
        /// <summary>
        /// Группа пользователей
        /// </summary>
        public virtual String UserGroup_r { get; set; }
        /// <summary>
        /// Имя хоста (DNS имя, IP допустимо) (в том числе и терминальное оборудование)
        /// </summary>
        public virtual String Host_r { get; set; }
        /// <summary>
        /// Уникальное имя принтера в системе WMS
        /// </summary>
        public virtual String LogicalPrinter_r { get; set; }
        /// <summary>
        /// Перед отчетом выполняется select, возвращающий значение, с которым производится сравнение параметра
        /// </summary>
        public virtual String ReportRedefinitionParam { get; set; }
        /// <summary>
        /// Альтернативный отчет, на который происходит замена исходного
        /// </summary>
        public virtual String ReportRedefinition { get; set; }
        /// <summary>
        /// Количество копий печатаемх документов
        /// </summary>
        public virtual Int32 ReportRedefinitionCopies { get; set; }
        /// <summary>
        /// Признак блокировки переопределения отчета для печати
        /// </summary>
        public virtual Boolean ReportRedefinitionLocked { get; set; }
        /// <summary>
        /// Определяет строгую последовательность анализа строк как "order by Priority asc"
        /// </summary>
        public virtual Int32? Priority { get; set; }
        /// <summary>
        /// Описание переопределения
        /// </summary>
        public virtual String ReportRedefinitionDesc { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Рассписание для EPS
    /// </summary>
    [Serializable]
    public partial class WmsScheduleHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID строки
        /// </summary>
        public virtual Int32 ScheduleID { get; set; }
        /// <summary>
        /// Код задания
        /// </summary>
        public virtual String JobCode_r { get; set; }
        /// <summary>
        /// Рассписание запуска
        /// </summary>
        public virtual String ScheduleCron { get; set; }
        /// <summary>
        /// Дата и время начала действия рассписания
        /// </summary>
        public virtual DateTime? ScheduleDateBegin { get; set; }
        /// <summary>
        /// Дата и время окончания действия рассписания
        /// </summary>
        public virtual DateTime? ScheduleDateEnd { get; set; }
        /// <summary>
        /// Наименование рассписания
        /// </summary>
        public virtual String ScheduleName { get; set; }
        /// <summary>
        /// Описание рассписания
        /// </summary>
        public virtual String ScheduleDesc { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Справочник логических(системных) принтеров и привязки к физическим
    /// </summary>
    [Serializable]
    public partial class EpsPrinterLogicalHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Логический принтер, уникальное имя принтера в системе WMS
        /// </summary>
        public virtual String LogicalPrinter { get; set; }
        /// <summary>
        /// Полное имя физического принтера, установленного на принт-сервере.
        /// </summary>
        public virtual String PhysicalPrinter_r { get; set; }
        /// <summary>
        /// Количество копий печатаемых документов. умножается на кол-во копий от других настроек
        /// </summary>
        public virtual Int32 LogicalPrinterCopies { get; set; }
        /// <summary>
        /// Признак блокировки принтера логического(при блокировке печать не осуществляется).

        /// </summary>
        public virtual Boolean LogicalPrinterLocked { get; set; }
        /// <summary>
        /// Лоток принтера, с которого берется бумага
        /// </summary>
        public virtual Int32 LogicalPrinterTray { get; set; }
        /// <summary>
        /// ШК логического принтера
        /// </summary>
        public virtual String LogicalPrinterBarcode { get; set; }
        /// <summary>
        /// Описание логического принтера
        /// </summary>
        public virtual String LogicalPrinterDesc { get; set; }
        /// <summary>
        /// Комментарии к штрих коду
        /// </summary>
        public virtual String LogicalPrinterBarcodeDesc { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Задачи для EPS
    /// </summary>
    [Serializable]
    public partial class EpsTaskHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код задачи
        /// </summary>
        public virtual String TaskCode { get; set; }
        /// <summary>
        /// Наименование задачи
        /// </summary>
        public virtual String TaskName { get; set; }
        /// <summary>
        /// Описание задачи
        /// </summary>
        public virtual String TaskDesc { get; set; }
        /// <summary>
        /// Блокировка задачи
        /// </summary>
        public virtual Boolean TaskLocked { get; set; }
        /// <summary>
        /// Тип задачи
        /// </summary>
        public virtual EpsTaskTypes TaskType { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Задачи к заданию
    /// </summary>
    [Serializable]
    public partial class EpsTask2JobHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID записи (task2job_gen)
        /// </summary>
        public virtual Int32 Task2JobID { get; set; }
        /// <summary>
        /// Код задания
        /// </summary>
        public virtual String JobCode_r { get; set; }
        /// <summary>
        /// Код задачи
        /// </summary>
        public virtual String TaskCode_r { get; set; }
        /// <summary>
        /// Последовательность выполнения
        /// </summary>
        public virtual Int32 Task2JobOrder { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Дочерние отчеты
    /// </summary>
    [Serializable]
    public partial class WmsReport2ReportHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код
        /// </summary>
        public virtual Int32 R2RID { get; set; }
        /// <summary>
        /// Отчет-пакет
        /// </summary>
        public virtual String R2RParent { get; set; }
        /// <summary>
        /// Дочерний отчет
        /// </summary>
        public virtual String Report_r { get; set; }
        /// <summary>
        /// Приоритет
        /// </summary>
        public virtual Int32 R2RPriority { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Справочник печатных форм 
    /// </summary>
    [Serializable]
    public partial class WmsReportHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Имя логического отчета
        /// </summary>
        public virtual String Report { get; set; }
        /// <summary>
        /// Имя файла отчета с расширением
        /// </summary>
        public virtual String ReportFile_r { get; set; }
        /// <summary>
        /// Обработчик отчета
        /// </summary>
        public virtual Int32 EpsHandler { get; set; }
        /// <summary>
        /// Количество копий печатаемх документов
        /// </summary>
        public virtual Int32 ReportCopies { get; set; }
        /// <summary>
        /// Признак блокировки отчета для печати
        /// </summary>
        public virtual Boolean ReportLocked { get; set; }
        /// <summary>
        /// Наименование отчета
        /// </summary>
        public virtual String ReportName { get; set; }
        /// <summary>
        /// Описание отчета
        /// </summary>
        public virtual String ReportDesc { get; set; }
        /// <summary>
        /// Тип отчета
        /// </summary>
        public virtual String ReportType { get; set; }
        /// <summary>
        /// Универсальный
        /// </summary>
        public virtual Boolean ReportUniversal { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Привязка отчетов к сущностям
    /// </summary>
    [Serializable]
    public partial class WmsReport2EntityHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 Report2EntityID { get; set; }
        /// <summary>
        /// Отчет
        /// </summary>
        public virtual String Report_r { get; set; }
        /// <summary>
        /// Имя объекта
        /// </summary>
        public virtual String ObjectName_r { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Конфигурация потока печати
    /// </summary>
    [Serializable]
    public partial class EpsPrintStreamConfigHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID конфигурационной записи
        /// </summary>
        public virtual Int32 PrintStreamID { get; set; }
        /// <summary>
        /// Имя хоста (DNS имя или IP), откуда инициирована печать (в том числе и терминальное оборудование)
        /// </summary>
        public virtual String Host_r { get; set; }
        /// <summary>
        /// Логин пользователя системы, инициировавшего печать
        /// </summary>
        public virtual String Login_r { get; set; }
        /// <summary>
        /// ID манданта. Если заполнен - параметр будет участвовать в конфигурировании
        /// </summary>
        public virtual WmsMandant Partner { get; set; }
        /// <summary>
        /// Печатная форма
        /// </summary>
        public virtual String Report_r { get; set; }
        /// <summary>
        /// Вид события
        /// </summary>
        public virtual String EventKindCode_r { get; set; }
        /// <summary>
        /// Фабрика
        /// </summary>
        public virtual Int32? FactoryID_r { get; set; }
        /// <summary>
        /// Начало диапазона времени печати. 
        /// </summary>
        public virtual DateTime? PeriodBegin { get; set; }
        /// <summary>
        /// Окончание диапазона времени печати
        /// </summary>
        public virtual DateTime? PeriodEnd { get; set; }
        /// <summary>
        /// Логический принтер
        /// </summary>
        public virtual String LogicalPrinter_r { get; set; }
        /// <summary>
        /// Количество копий печатаемых документов
        /// </summary>
        public virtual Int32 PrintStreamCopies { get; set; }
        /// <summary>
        /// Признак блокировки конфигурации потока печати.

        /// </summary>
        public virtual Boolean PrintStreamLocked { get; set; }
        /// <summary>
        /// Приоритет записи
        /// </summary>
        public virtual Int32? Priority { get; set; }
        /// <summary>
        /// Описание конфигурации потока печати
        /// </summary>
        public virtual String PrintStreamDesc { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Права на печать отчетов
    /// </summary>
    [Serializable]
    public partial class WmsReport2UserHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 Report2UserID { get; set; }
        /// <summary>
        /// Код системного пользователя
        /// </summary>
        public virtual WmsUser User { get; set; }
        /// <summary>
        /// Код группы пользователей
        /// </summary>
        public virtual String UserGroupCode_r { get; set; }
        /// <summary>
        /// Отчет
        /// </summary>
        public virtual String Report_r { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Фильт отчета
    /// </summary>
    [Serializable]
    public partial class WmsReportFilterHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 ReportFilterID { get; set; }
        /// <summary>
        /// Отчет
        /// </summary>
        public virtual String Report_r { get; set; }
        /// <summary>
        /// Параметр
        /// </summary>
        public virtual String ReportFilterParameter { get; set; }
        /// <summary>
        /// Тип данных
        /// </summary>
        public virtual Int32 ReportFilterDataType { get; set; }
        /// <summary>
        /// Заголовок
        /// </summary>
        public virtual String ReportFilterDisplayName { get; set; }
        /// <summary>
        /// Метод обработки
        /// </summary>
        public virtual String ReportFilterMethod { get; set; }
        /// <summary>
        /// Последовательность отображения
        /// </summary>
        public virtual Int32? ReportFilterOrder { get; set; }
        /// <summary>
        /// Формат
        /// </summary>
        public virtual String ReportFilterFormat { get; set; }
        /// <summary>
        /// Лукап
        /// </summary>
        public virtual String ObjectLookupCode_r { get; set; }
        /// <summary>
        /// Значение по умолчанию
        /// </summary>
        public virtual String ReportFilterDefaultValue { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String ReportFilterDesc { get; set; }
        /// <summary>
        /// Параметр отчета
        /// </summary>
        public virtual String ReportFilterConfigParamCode { get; set; }
        /// <summary>
        /// Алиас
        /// </summary>
        public virtual String ReportFilterAlias { get; set; }
        /// <summary>
        /// Оператор SQL
        /// </summary>
        public virtual String ReportFilterOperatorSQL { get; set; }
        /// <summary>
        /// Видимость
        /// </summary>
        public virtual Boolean ReportFilterVisible { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Стикер
    /// </summary>
    [Serializable]
    public partial class WmsLabelHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код
        /// </summary>
        public virtual String LabelCode { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String LabelName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String LabelDesc { get; set; }
        /// <summary>
        /// Отчет
        /// </summary>
        public virtual String Report_r { get; set; }
        /// <summary>
        /// Мандант
        /// </summary>
        public virtual WmsMandant Partner { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Параметры стикера
    /// </summary>
    [Serializable]
    public partial class WmsLabelParamsHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 LabelParamsID { get; set; }
        /// <summary>
        /// Стикер
        /// </summary>
        public virtual String LabelCode_r { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String LabelParamsName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String LabelParamsDesc { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Применение стикера
    /// </summary>
    [Serializable]
    public partial class WmsLabelUseHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 LabelUseID { get; set; }
        /// <summary>
        /// Стикер
        /// </summary>
        public virtual String LabelCode_r { get; set; }
        /// <summary>
        /// SKU
        /// </summary>
        public virtual Int32? SKUID_r { get; set; }
        /// <summary>
        /// Артикул
        /// </summary>
        public virtual String ArtCode_r { get; set; }
        /// <summary>
        /// Группа артикулов
        /// </summary>
        public virtual String ArtGroupCode_r { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Значения параметров стикера
    /// </summary>
    [Serializable]
    public partial class WmsLabelParamsValueHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 LabelParamsValueID { get; set; }
        /// <summary>
        /// Применение стикера
        /// </summary>
        public virtual Int32 LabelUseID_r { get; set; }
        /// <summary>
        /// Параметр
        /// </summary>
        public virtual Int32 LabelParamsID_r { get; set; }
        /// <summary>
        /// Текстовое значение
        /// </summary>
        public virtual String LabelParamsValueText { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Буфер данных отчетов
    /// </summary>
    [Serializable]
    public partial class WmsReportDataBufferHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 ReportDataBufferID { get; set; }
        /// <summary>
        /// Группа записей
        /// </summary>
        public virtual Guid ReportDataBufferGroup { get; set; }
        /// <summary>
        /// Запись
        /// </summary>
        public virtual Guid ReportDataBufferRecord { get; set; }
        /// <summary>
        /// Параметр
        /// </summary>
        public virtual String ReportDataBufferKey { get; set; }
        /// <summary>
        /// Значение
        /// </summary>
        public virtual String ReportDataBufferValue { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Dashboard
    /// </summary>
    [Serializable]
    public partial class WmsDashboardHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код
        /// </summary>
        public virtual String DashboardCode { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String DashboardName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String DashboardDesc { get; set; }
        /// <summary>
        /// Версия
        /// </summary>
        public virtual String DashboardVersion { get; set; }
        /// <summary>
        /// Тело Dashboard
        /// </summary>
        public virtual Byte[] DashboardBody { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Права на отображение Dashboard
    /// </summary>
    [Serializable]
    public partial class WmsDashboard2UserHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 Dashboard2UserID { get; set; }
        /// <summary>
        /// Dashboard
        /// </summary>
        public virtual String DashboardCode_r { get; set; }
        /// <summary>
        /// Код системного пользователя
        /// </summary>
        public virtual WmsUser User { get; set; }
        /// <summary>
        /// Код группы пользователей
        /// </summary>
        public virtual String UserGroupCode_r { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Планировщик
    /// </summary>
    [Serializable]
    public partial class SchSchedulerHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Guid ID { get; set; }
        /// <summary>
        /// Код
        /// </summary>
        public virtual String Code { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String Description { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Тип задания
    /// </summary>
    [Serializable]
    public partial class SchJobTypeHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Guid ID { get; set; }
        /// <summary>
        /// Планировщик
        /// </summary>
        public virtual Guid SchedulerId { get; set; }
        /// <summary>
        /// Code
        /// </summary>
        public virtual String Code { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        public virtual String Description { get; set; }
        /// <summary>
        /// Реализатор
        /// </summary>
        public virtual String ClassName { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Параметр типа задания
    /// </summary>
    [Serializable]
    public partial class SchJobTypeParamHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Guid ID { get; set; }
        /// <summary>
        /// JobTypeId
        /// </summary>
        public virtual Guid JobTypeId { get; set; }
        /// <summary>
        /// Code
        /// </summary>
        public virtual String Code { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        public virtual String Description { get; set; }
        /// <summary>
        /// По-умолчанию
        /// </summary>
        public virtual String DefaultValue { get; set; }
        /// <summary>
        /// Обязательность
        /// </summary>
        public virtual Boolean IsRequired { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Задание
    /// </summary>
    [Serializable]
    public partial class SchJobHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Guid ID { get; set; }
        /// <summary>
        /// Планировщик
        /// </summary>
        public virtual Guid SchedulerId { get; set; }
        /// <summary>
        /// Тип задания
        /// </summary>
        public virtual Guid JobTypeId { get; set; }
        /// <summary>
        /// Группа
        /// </summary>
        public virtual String JobGroup { get; set; }
        /// <summary>
        /// Код
        /// </summary>
        public virtual String Code { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String Description { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Параметр задания
    /// </summary>
    [Serializable]
    public partial class SchJobParamHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Guid ID { get; set; }
        /// <summary>
        /// Задание
        /// </summary>
        public virtual Guid JobId { get; set; }
        /// <summary>
        /// Тип параметра задания
        /// </summary>
        public virtual Guid? JobTypeParamId { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String Name { get; set; }
        /// <summary>
        /// Значение
        /// </summary>
        public virtual String Value { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения 
    /// </summary>
    [Serializable]
    public partial class SchTriggerHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Guid ID { get; set; }
        /// <summary>
        /// Задача
        /// </summary>
        public virtual Guid JobId { get; set; }
        /// <summary>
        /// Планировщик
        /// </summary>
        public virtual Guid SchedulerId { get; set; }
        /// <summary>
        /// Code
        /// </summary>
        public virtual String Code { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String Description { get; set; }
        /// <summary>
        /// Группа
        /// </summary>
        public virtual String TriggerGroup { get; set; }
        /// <summary>
        /// Приоритет
        /// </summary>
        public virtual Int32 Priority { get; set; }
        /// <summary>
        /// Доступен с, UTC
        /// </summary>
        public virtual DateTime StartTimeUtc { get; set; }
        /// <summary>
        /// Доступен по, UTC
        /// </summary>
        public virtual DateTime? EndTimeUtc { get; set; }
        /// <summary>
        /// Отключен
        /// </summary>
        public virtual Boolean? Disabled { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Тип сообщения
    /// </summary>
    [Serializable]
    public partial class IoQueueMessageTypeHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Guid ID { get; set; }
        /// <summary>
        /// Код
        /// </summary>
        public virtual String Code { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String Name { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String Description { get; set; }
        /// <summary>
        /// Создал
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Создано
        /// </summary>
        public virtual DateTime DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Входящая очередь
    /// </summary>
    [Serializable]
    public partial class IoQueueInHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Guid ID { get; set; }
        /// <summary>
        /// Тип сообщения
        /// </summary>
        public virtual Guid QueueMessageTypeId { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public virtual QueueMessageStates QueueMessageState { get; set; }
        /// <summary>
        /// Признак объединения записей
        /// </summary>
        public virtual Guid? GroupCode { get; set; }
        /// <summary>
        /// Процесс
        /// </summary>
        public virtual String ProcessCode { get; set; }
        /// <summary>
        /// Мандант
        /// </summary>
        public virtual WmsMandant Mandant { get; set; }
        /// <summary>
        /// Исходящее сообщение
        /// </summary>
        public virtual Guid? QueueOutId { get; set; }
        /// <summary>
        /// Дополнительная информация
        /// </summary>
        public virtual String Message { get; set; }
        /// <summary>
        /// Данные
        /// </summary>
        public virtual Byte[] Data { get; set; }
        /// <summary>
        /// Uri
        /// </summary>
        public virtual String Uri { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Исходящая очередь
    /// </summary>
    [Serializable]
    public partial class IoQueueOutHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Guid ID { get; set; }
        /// <summary>
        /// Тип сообщения
        /// </summary>
        public virtual Guid QueueMessageTypeId { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public virtual QueueMessageStates QueueMessageState { get; set; }
        /// <summary>
        /// Группа обработки
        /// </summary>
        public virtual Guid? GroupCode { get; set; }
        /// <summary>
        /// Процесс
        /// </summary>
        public virtual String ProcessCode { get; set; }
        /// <summary>
        /// Мандант
        /// </summary>
        public virtual WmsMandant Mandant { get; set; }
        /// <summary>
        /// Входящее сообщение
        /// </summary>
        public virtual Guid? QueueInId { get; set; }
        /// <summary>
        /// Информация
        /// </summary>
        public virtual String Message { get; set; }
        /// <summary>
        /// Данные
        /// </summary>
        public virtual Byte[] Data { get; set; }
        /// <summary>
        /// Дата обработки
        /// </summary>
        public virtual DateTime? RequiredProcessDate { get; set; }
        /// <summary>
        /// Selector
        /// </summary>
        public virtual String Selector { get; set; }
        /// <summary>
        /// Uri
        /// </summary>
        public virtual String Uri { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Контроль исполнения
    /// </summary>
    [Serializable]
    public partial class IoLaunchControlHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Guid ID { get; set; }
        /// <summary>
        /// QueueMessageTypeId
        /// </summary>
        public virtual Guid? QueueMessageTypeId { get; set; }
        /// <summary>
        /// MandantId
        /// </summary>
        public virtual WmsMandant Mandant { get; set; }
        /// <summary>
        /// EventHeaderID_r
        /// </summary>
        public virtual Int32? EventHeaderID_r { get; set; }
        /// <summary>
        /// ProcessCode
        /// </summary>
        public virtual String ProcessCode { get; set; }
        /// <summary>
        /// QueueOutId
        /// </summary>
        public virtual Guid? QueueOutId { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Справочник международных языков
    /// </summary>
    [Serializable]
    public partial class IsoLanguageHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код языка
        /// </summary>
        public virtual String LangCode { get; set; }
        /// <summary>
        /// Наименование языка на английском
        /// </summary>
        public virtual String LangNameEng { get; set; }
        /// <summary>
        /// Наименование языка на русском
        /// </summary>
        public virtual String LangNameRus { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Справочник валют
    /// </summary>
    [Serializable]
    public partial class IsoCurrencyHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код валюты
        /// </summary>
        public virtual String CurrencyCode { get; set; }
        /// <summary>
        /// Наименование валюты на русском
        /// </summary>
        public virtual String CurrencyNameRus { get; set; }
        /// <summary>
        /// Наименование валюты на английском
        /// </summary>
        public virtual String CurrencyNameEng { get; set; }
        /// <summary>
        /// Цифровой код валюты
        /// </summary>
        public virtual String CurrencyNumeric { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

    /// <summary>
    /// История изменения Справочник стран (ISO 3166-1)
    /// </summary>
    [Serializable]
    public partial class IsoCountryHistory : IHistoryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int64 HistoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? HDateTill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ArchInstGUID_r { get; set; }
        /// <summary>
        /// Код Alpha-3
        /// </summary>
        public virtual String CountryCode { get; set; }
        /// <summary>
        /// Наименование на английском
        /// </summary>
        public virtual String CountryNameEng { get; set; }
        /// <summary>
        /// Наименование на русском
        /// </summary>
        public virtual String CountryNameRus { get; set; }
        /// <summary>
        /// Код Alpha-2
        /// </summary>
        public virtual String CountryAlpha2 { get; set; }
        /// <summary>
        /// Цифровой код
        /// </summary>
        public virtual String CountryNumeric { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
        public virtual Boolean IsArchive { get; set; }
    }

}
