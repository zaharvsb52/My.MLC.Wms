using System;
using System.Collections.Generic;

namespace MLC.Wms.Model.Entities 
{
    /// <summary>
    /// Погрузчики
    /// </summary>
    [Serializable]
    public partial class WmsTruck : BaseEntity
    {
        /// <summary>
        /// Код погрузчика
        /// </summary>
        public virtual String TruckCode { get; set; }
        /// <summary>
        /// Тип погрузчика
        /// </summary>
        public virtual WmsTruckType TruckType { get; set; }
        /// <summary>
        /// Служебное место
        /// </summary>
        public virtual WmsPlace Place { get; set; }
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
    }

    /// <summary>
    /// Типы погрузчиков
    /// </summary>
    [Serializable]
    public partial class WmsTruckType : BaseEntity
    {
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
    }

    /// <summary>
    /// Группы инвентаризации
    /// </summary>
    [Serializable]
    public partial class WmsInvGroup : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 InvGroupID { get; set; }
        /// <summary>
        /// Инвентаризация
        /// </summary>
        public virtual WmsInv Inv { get; set; }
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
        public virtual WmsInvGroupStatus Status { get; set; }
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
    }

    /// <summary>
    /// Инвентаризационный срез
    /// </summary>
    [Serializable]
    public partial class WmsInvSnapShot : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 InvSSID { get; set; }
        /// <summary>
        /// Инвентаризация
        /// </summary>
        public virtual WmsInv Inv { get; set; }
        /// <summary>
        /// Группа инвентаризации
        /// </summary>
        public virtual WmsInvGroup InvGroup { get; set; }
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
    }

    /// <summary>
    /// Просчеты заданий
    /// </summary>
    [Serializable]
    public partial class WmsInvTaskStep : BaseEntity
    {
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
        public virtual WmsInvTaskGroup InvTaskGroup { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public virtual WmsInvTaskStepStatus Status { get; set; }
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
    }

    /// <summary>
    /// Менеджер резервирования
    /// </summary>
    [Serializable]
    public partial class WmsMR : BaseEntity
    {
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
    }

    /// <summary>
    /// Очередь резервирования
    /// </summary>
    [Serializable]
    public partial class WmsQRes : BaseEntity
    {
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
        public virtual WmsOWB OWB { get; set; }
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
    }

    /// <summary>
    /// Применение менеджера резервирования
    /// </summary>
    [Serializable]
    public partial class WmsMRUse : BaseEntity
    {
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 MRUseID { get; set; }
        /// <summary>
        /// Менеджер резервирования
        /// </summary>
        public virtual WmsMR MR { get; set; }
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
    }

    /// <summary>
    /// Груз на приход
    /// </summary>
    [Serializable]
    public partial class WmsCargoIWB : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 CargoIWBID { get; set; }
        /// <summary>
        /// Внутренний рейс
        /// </summary>
        public virtual YInternalTraffic InternalTraffic { get; set; }
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
        public virtual WmsAddressBook CargoIWBLoadAddress { get; set; }
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
    }

    /// <summary>
    /// Менеджер пикинга
    /// </summary>
    [Serializable]
    public partial class WmsMPL : BaseEntity
    {
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
    }

    /// <summary>
    /// Выбор менеджера пикинга
    /// </summary>
    [Serializable]
    public partial class WmsMPLSelect : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 MPLSelectID { get; set; }
        /// <summary>
        /// Менеджер пикинга
        /// </summary>
        public virtual WmsMPL MPL { get; set; }
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
    }

    /// <summary>
    /// Список пикинга
    /// </summary>
    [Serializable]
    public partial class WmsPL : BaseEntity
    {
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
        public virtual WmsPLStatus Status { get; set; }
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
    }

    /// <summary>
    /// Позиции списка пикинга
    /// </summary>
    [Serializable]
    public partial class WmsPLPos : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 PLPosID { get; set; }
        /// <summary>
        /// Список пикинга
        /// </summary>
        public virtual WmsPL PL { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public virtual WmsPLPosStatus Status { get; set; }
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
        public virtual WmsSKU SKU { get; set; }
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
    }

    /// <summary>
    /// Резервирование
    /// </summary>
    [Serializable]
    public partial class WmsRes : BaseEntity
    {
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 ResID { get; set; }
        /// <summary>
        /// Товар
        /// </summary>
        public virtual WmsProduct Product { get; set; }
        /// <summary>
        /// Позиция расходной накладной
        /// </summary>
        public virtual WmsOWBPos OWBPos { get; set; }
        /// <summary>
        /// Менеджер резервирования
        /// </summary>
        public virtual String MRCode_r { get; set; }
        /// <summary>
        /// Позиция списка пикинга
        /// </summary>
        public virtual WmsPLPos PlPos { get; set; }
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
    }

    /// <summary>
    /// Применение менеджера пикинга
    /// </summary>
    [Serializable]
    public partial class WmsMPLUse : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 MPLUseID { get; set; }
        /// <summary>
        /// Менеджер пикинга
        /// </summary>
        public virtual WmsMPL MPL { get; set; }
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
    }

    /// <summary>
    /// Груз на расход
    /// </summary>
    [Serializable]
    public partial class WmsCargoOWB : BaseEntity
    {
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 CargoOWBID { get; set; }
        /// <summary>
        /// Внутренний рейс
        /// </summary>
        public virtual YInternalTraffic InternalTraffic { get; set; }
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
        public virtual WmsAddressBook CargoOWBUnLoadAddress { get; set; }
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
        public virtual YRoute Route { get; set; }
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
    }

    /// <summary>
    /// Расходная накладная
    /// </summary>
    [Serializable]
    public partial class WmsOWB : BaseEntity
    {
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
        public virtual WmsOWBStatus Status { get; set; }
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
        public virtual WmsPartner OWBRecipient { get; set; }
        /// <summary>
        /// Плательщик
        /// </summary>
        public virtual WmsPartner OWBPayer { get; set; }
        /// <summary>
        /// Клиент-получатель
        /// </summary>
        public virtual ecomClient OWBClientRecipient { get; set; }
        /// <summary>
        /// Адрес клиента-получателя
        /// </summary>
        public virtual WmsAddressBook OWBClientRecipientAddr { get; set; }
        /// <summary>
        /// Доставка, план
        /// </summary>
        public virtual DateTime? OWBPlannedDeliveryDate { get; set; }
        /// <summary>
        /// Клиент-плательщик
        /// </summary>
        public virtual ecomClient OWBClientPayer { get; set; }
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
        public virtual WmsFactory Factory { get; set; }
        /// <summary>
        /// адрес
        /// </summary>
        public virtual WmsAddressBook AddressBook { get; set; }
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
        public virtual WmsPartner OWBCarrier { get; set; }
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
    }

    /// <summary>
    /// Приходная накладная
    /// </summary>
    [Serializable]
    public partial class WmsIWB : BaseEntity
    {
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
        public virtual WmsPartner IWBSender { get; set; }
        /// <summary>
        /// Плательщик
        /// </summary>
        public virtual WmsPartner IWBPayer { get; set; }
        /// <summary>
        /// Получатель
        /// </summary>
        public virtual WmsPartner IWBRecipient { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public virtual WmsIWBStatus Status { get; set; }
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
        public virtual WmsFactory Factory { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String IWBDesc { get; set; }
        /// <summary>
        /// Инвентаризация
        /// </summary>
        public virtual WmsInv Inv { get; set; }
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
    }

    /// <summary>
    /// Позиции груза
    /// </summary>
    [Serializable]
    public partial class WmsCargoIWBPos : BaseEntity
    {
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 CargoIWBPosID { get; set; }
        /// <summary>
        /// Груз
        /// </summary>
        public virtual WmsCargoIWB CargoIWB { get; set; }
        /// <summary>
        /// Количество
        /// </summary>
        public virtual Int32 CargoIWBPosCount { get; set; }
        /// <summary>
        /// Тип грузового места
        /// </summary>
        public virtual WmsTEType TEType { get; set; }
        /// <summary>
        /// Тип позиции
        /// </summary>
        public virtual String CargoIWBPosType { get; set; }
        /// <summary>
        /// Квалификация
        /// </summary>
        public virtual WmsQLF QLF { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String CargoIWBPosDesc { get; set; }
        /// <summary>
        /// Приходная накладная
        /// </summary>
        public virtual WmsIWB IWB { get; set; }
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
    }

    /// <summary>
    /// Позиции приходной накладной
    /// </summary>
    [Serializable]
    public partial class WmsIWBPos : BaseEntity
    {
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 IWBPosID { get; set; }
        /// <summary>
        /// Приходная накладная
        /// </summary>
        public virtual WmsIWB IWB { get; set; }
        /// <summary>
        /// Номер позиции
        /// </summary>
        public virtual Int32 IWBPosNumber { get; set; }
        /// <summary>
        /// SKU
        /// </summary>
        public virtual WmsSKU SKU { get; set; }
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
        public virtual WmsIWBPosStatus Status { get; set; }
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
        public virtual WmsFactory Factory { get; set; }
        /// <summary>
        /// Квалификация
        /// </summary>
        public virtual WmsQLF QLF { get; set; }
        /// <summary>
        /// Блокировка
        /// </summary>
        public virtual WmsProductBlocking IWBPosBlocking { get; set; }
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
        public virtual IsoCountry Country { get; set; }
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
    }

    /// <summary>
    /// Позиции расходной накладной
    /// </summary>
    [Serializable]
    public partial class WmsOWBPos : BaseEntity
    {
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 OWBPosID { get; set; }
        /// <summary>
        /// Расходная накладная
        /// </summary>
        public virtual WmsOWB OWB { get; set; }
        /// <summary>
        /// Номер позиции
        /// </summary>
        public virtual Int32 OWBPosNumber { get; set; }
        /// <summary>
        /// SKU
        /// </summary>
        public virtual WmsSKU SKU { get; set; }
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
        public virtual WmsOWBPosStatus Status { get; set; }
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
        public virtual WmsFactory Factory { get; set; }
        /// <summary>
        /// Квалификация
        /// </summary>
        public virtual WmsQLF QLF { get; set; }
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
    }

    /// <summary>
    /// Выбор менеджера резервирования
    /// </summary>
    [Serializable]
    public partial class WmsMRSelect : BaseEntity
    {
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 MRSelectID { get; set; }
        /// <summary>
        /// Менеджер резервирования
        /// </summary>
        public virtual WmsMR MR { get; set; }
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
        public virtual WmsFactory Factory { get; set; }
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
    }

    /// <summary>
    /// Применение менеджера инвентаризации
    /// </summary>
    [Serializable]
    public partial class WmsMIUse : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 MIUseID { get; set; }
        /// <summary>
        /// Менеджер инвентаризации
        /// </summary>
        public virtual WmsMI MI { get; set; }
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
    }

    /// <summary>
    /// Задания на просчет
    /// </summary>
    [Serializable]
    public partial class WmsInvTask : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 InvTaskID { get; set; }
        /// <summary>
        /// Группа заданий
        /// </summary>
        public virtual WmsInvTaskGroup InvTaskGroup { get; set; }
        /// <summary>
        /// Просчёт
        /// </summary>
        public virtual WmsInvTaskStep InvTaskStep { get; set; }
        /// <summary>
        /// Срез
        /// </summary>
        public virtual Int32? InvSnapShotID_r { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public virtual WmsInvTaskStatus Status { get; set; }
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
    }

    /// <summary>
    /// Менеджер инвентаризации
    /// </summary>
    [Serializable]
    public partial class WmsMI : BaseEntity
    {
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
    }

    /// <summary>
    /// Инвентаризация
    /// </summary>
    [Serializable]
    public partial class WmsInv : BaseEntity
    {
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
        public virtual WmsInvStatus Status { get; set; }
        /// <summary>
        /// Мандант
        /// </summary>
        public virtual WmsMandant Partner { get; set; }
        /// <summary>
        /// Менеджер инвентаризации
        /// </summary>
        public virtual WmsMI MI { get; set; }
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
    }

    /// <summary>
    /// Группа заданий
    /// </summary>
    [Serializable]
    public partial class WmsInvTaskGroup : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 InvTaskGroupID { get; set; }
        /// <summary>
        /// Группа инвентаризации
        /// </summary>
        public virtual WmsInvGroup InvGroup { get; set; }
        /// <summary>
        /// Номер группы
        /// </summary>
        public virtual Int32 InvTaskGroupNumber { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public virtual WmsInvTaskGroupStatus Status { get; set; }
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
    }

    /// <summary>
    /// Менеджер поставок
    /// </summary>
    [Serializable]
    public partial class WmsMSC : BaseEntity
    {
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
        public virtual WmsMSCType MSCType { get; set; }
        /// <summary>
        /// Стратегия пополнения
        /// </summary>
        public virtual String MSCStrategy { get; set; }
        /// <summary>
        /// Менеджер перемещения
        /// </summary>
        public virtual WmsMM MM { get; set; }
        /// <summary>
        /// Целевая зона поставки
        /// </summary>
        public virtual String MSCTargetSupplyArea { get; set; }
        /// <summary>
        /// Требуемая операция
        /// </summary>
        public virtual BillOperation MSCRequiredOperation { get; set; }
        /// <summary>
        /// Операционный приоритет
        /// </summary>
        public virtual Int32 MSCOperationOrder { get; set; }
        /// <summary>
        /// Текущий этап
        /// </summary>
        public virtual WmsOperationStage MSCFrom { get; set; }
        /// <summary>
        /// Следующий этап
        /// </summary>
        public virtual WmsOperationStage MSCTo { get; set; }
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
    }

    /// <summary>
    /// Выбор менеджера поставки
    /// </summary>
    [Serializable]
    public partial class WmsMSCSelect : BaseEntity
    {
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 MSCSelectID { get; set; }
        /// <summary>
        /// Менеджер поставок
        /// </summary>
        public virtual WmsMSC MSCCODE_r { get; set; }
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
    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public partial class WmsQSupplyChain : BaseEntity
    {
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
        public virtual WmsQSupplyChainStatus Status { get; set; }
        /// <summary>
        /// Предшествующая операция
        /// </summary>
        public virtual BillOperation Operation { get; set; }
        /// <summary>
        /// ТЕ
        /// </summary>
        public virtual WmsTE TE { get; set; }
        /// <summary>
        /// Поставка
        /// </summary>
        public virtual WmsSupplyChain SupplyChain { get; set; }
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
    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public partial class WmsSupplyChain : BaseEntity
    {
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 SupplyChainID { get; set; }
        /// <summary>
        /// Менеджер поставок
        /// </summary>
        public virtual WmsMSC MSC { get; set; }
        /// <summary>
        /// Исходная зона поставки
        /// </summary>
        public virtual WmsSupplyArea SupplyChainSourceSupplyArea { get; set; }
        /// <summary>
        /// Целевая зона поставки
        /// </summary>
        public virtual WmsSupplyArea SupplyChainTargetSupplyArea { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public virtual WmsSupplyChainStatus Status { get; set; }
        /// <summary>
        /// Предшествующая операция
        /// </summary>
        public virtual BillOperation Operation { get; set; }
        /// <summary>
        /// Требуемая операция
        /// </summary>
        public virtual BillOperation SupplyChainRequiredOperation { get; set; }
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
    }

    /// <summary>
    /// Общий конфигуратор
    /// </summary>
    [Serializable]
    public partial class WmsGC : BaseEntity
    {
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
    }

    /// <summary>
    /// Сущность к конфигуратору
    /// </summary>
    [Serializable]
    public partial class WmsEntity2GC : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 Entity2GCID { get; set; }
        /// <summary>
        /// Конфигуратор
        /// </summary>
        public virtual WmsGC GC { get; set; }
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
    }

    /// <summary>
    /// Запрос инвентаризации
    /// </summary>
    [Serializable]
    public partial class WmsInvReq : BaseEntity
    {
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
        public virtual WmsInv Inv { get; set; }
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
        public virtual WmsInvReqStatus Status { get; set; }
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
    }

    /// <summary>
    /// Позиции запроса на инвентаризацию
    /// </summary>
    [Serializable]
    public partial class WmsInvReqPos : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 InvReqPosID { get; set; }
        /// <summary>
        /// Запрос на инвентаризацию
        /// </summary>
        public virtual WmsInvReq InvReq { get; set; }
        /// <summary>
        /// Группа инвентаризации
        /// </summary>
        public virtual WmsInvGroup InvGroup { get; set; }
        /// <summary>
        /// Номер позиции
        /// </summary>
        public virtual Int32 InvReqPosNumber { get; set; }
        /// <summary>
        /// Код артикула
        /// </summary>
        public virtual WmsArt Art { get; set; }
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
    }

    /// <summary>
    /// Менеджер приемки
    /// </summary>
    [Serializable]
    public partial class WmsMIN : BaseEntity
    {
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
    }

    /// <summary>
    /// Выбор менеджера приемки
    /// </summary>
    [Serializable]
    public partial class WmsMINSelect : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 MINSelectID { get; set; }
        /// <summary>
        /// Менеджер приемки
        /// </summary>
        public virtual WmsMIN MIN { get; set; }
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
    }

    /// <summary>
    /// Тип менеджера поставки
    /// </summary>
    [Serializable]
    public partial class WmsMSCType : BaseEntity
    {
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
    }

    /// <summary>
    /// Контроль срока годности
    /// </summary>
    [Serializable]
    public partial class WmsExpiryDate : BaseEntity
    {
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
    }

    /// <summary>
    /// Оперативные данные инвентаризации
    /// </summary>
    [Serializable]
    public partial class WmsInvOperationData : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 InvOperationDataID { get; set; }
        /// <summary>
        /// Группа заданий
        /// </summary>
        public virtual WmsInvTaskGroup InvTaskGroup { get; set; }
        /// <summary>
        /// Просчёт
        /// </summary>
        public virtual WmsInvTaskStep InvTaskStep { get; set; }
        /// <summary>
        /// Количество
        /// </summary>
        public virtual Int32? InvOperationDataCount { get; set; }
        /// <summary>
        /// Количество в SKU
        /// </summary>
        public virtual Double InvOperationDataCount2SKU { get; set; }
        /// <summary>
        /// Место
        /// </summary>
        public virtual String PlaceCode_r { get; set; }
        /// <summary>
        /// ТЕ
        /// </summary>
        public virtual String InvOperationDataTECode { get; set; }
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
        public virtual Int32? SKUID_r { get; set; }
        /// <summary>
        /// Квалификация
        /// </summary>
        public virtual String QLFCode_r { get; set; }
        /// <summary>
        /// Детализация квалификации
        /// </summary>
        public virtual String QLFDetailCode_r { get; set; }
        /// <summary>
        /// Приходная накладная
        /// </summary>
        public virtual Int32? IWBID_r { get; set; }
        /// <summary>
        /// Расходная накладная
        /// </summary>
        public virtual Int32? OWBID_r { get; set; }
        /// <summary>
        /// Фабрика
        /// </summary>
        public virtual Int32? FactoryID_r { get; set; }
        /// <summary>
        /// Дата приемки
        /// </summary>
        public virtual DateTime? InvOperationDataInputDate { get; set; }
        /// <summary>
        /// Дата производства
        /// </summary>
        public virtual DateTime? InvOperationDataProductDate { get; set; }
        /// <summary>
        /// Срок годности
        /// </summary>
        public virtual DateTime? InvOperationDataExpiryDate { get; set; }
        /// <summary>
        /// Партия
        /// </summary>
        public virtual String InvOperationDataBatch { get; set; }
        /// <summary>
        /// Лот
        /// </summary>
        public virtual String InvOperationDataLot { get; set; }
        /// <summary>
        /// Серийный номер
        /// </summary>
        public virtual String InvOperationDataSerialNumber { get; set; }
        /// <summary>
        /// Цвет
        /// </summary>
        public virtual String InvOperationDataColor { get; set; }
        /// <summary>
        /// Тон
        /// </summary>
        public virtual String InvOperationDataTone { get; set; }
        /// <summary>
        /// Размер
        /// </summary>
        public virtual String InvOperationDataSize { get; set; }
        /// <summary>
        /// BatchCode
        /// </summary>
        public virtual String InvOperationDataBatchCode { get; set; }
        /// <summary>
        /// Номер короба
        /// </summary>
        public virtual String InvOperationDataBoxNumber { get; set; }
    }

    /// <summary>
    /// Этапы обработки
    /// </summary>
    [Serializable]
    public partial class WmsOperationStage : BaseEntity
    {
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
    }

    /// <summary>
    /// Заявка на декларирование
    /// </summary>
    [Serializable]
    public partial class CstReqCustoms : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 ReqCustomsID { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public virtual CstReqCustomsStatus Status { get; set; }
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
        public virtual WmsPartner ReqCustomsPost { get; set; }
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
        public virtual IsoCountry ReqCustomsVehicleOutCountry { get; set; }
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
        public virtual IsoCountry ReqCustomsVehicleInCountry { get; set; }
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
    }

    /// <summary>
    /// Позиции заявки на декларирование
    /// </summary>
    [Serializable]
    public partial class CstReqCustomsPos : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 ReqCustomsPosID { get; set; }
        /// <summary>
        /// Заявка на декларирование
        /// </summary>
        public virtual CstReqCustoms ReqCustoms { get; set; }
        /// <summary>
        /// Номер позиции
        /// </summary>
        public virtual Int32 ReqCustomsPosNumber { get; set; }
        /// <summary>
        /// Артикул
        /// </summary>
        public virtual WmsArt Art { get; set; }
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
        public virtual IsoCountry Country { get; set; }
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
    }

    /// <summary>
    /// Заявка к накладным
    /// </summary>
    [Serializable]
    public partial class CstReqCustoms2WB : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 ReqCustoms2WBId { get; set; }
        /// <summary>
        /// Заявка на декларирование
        /// </summary>
        public virtual CstReqCustoms ReqCustoms { get; set; }
        /// <summary>
        /// Приходная накладная
        /// </summary>
        public virtual WmsIWB IWB { get; set; }
        /// <summary>
        /// Расходная накладная
        /// </summary>
        public virtual WmsOWB OWB { get; set; }
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
    }

    /// <summary>
    /// Транспортные договора
    /// </summary>
    [Serializable]
    public partial class CstTransportContract : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 TransportContractId { get; set; }
        /// <summary>
        /// Заявка на декларирование
        /// </summary>
        public virtual CstReqCustoms ReqCustoms { get; set; }
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
    }

    /// <summary>
    /// Документы на перевозку
    /// </summary>
    [Serializable]
    public partial class CstTransportDocument : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 TransportDocumentId { get; set; }
        /// <summary>
        /// Заявка на декларирование
        /// </summary>
        public virtual CstReqCustoms ReqCustoms { get; set; }
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
    }

    /// <summary>
    /// Типы клиентов
    /// </summary>
    [Serializable]
    public partial class SysClientType : BaseEntity
    {
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
    }

    /// <summary>
    /// Работа
    /// </summary>
    [Serializable]
    public partial class WmsWork : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 WorkID { get; set; }
        /// <summary>
        /// Группа
        /// </summary>
        public virtual WmsWorkGroup WorkGroup { get; set; }
        /// <summary>
        /// Операция
        /// </summary>
        public virtual BillOperation Operation { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String WorkDesc { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public virtual WmsWorkStatus Status { get; set; }
        /// <summary>
        /// Клиентская сессия
        /// </summary>
        public virtual SysClientSession ClientSession { get; set; }
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
    }

    /// <summary>
    /// Работники к складам
    /// </summary>
    [Serializable]
    public partial class WmsWorker2Warehouse : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 Worker2WarehouseID { get; set; }
        /// <summary>
        /// Группа работников
        /// </summary>
        public virtual WmsWorkerGroup WorkerGroup { get; set; }
        /// <summary>
        /// Работник
        /// </summary>
        public virtual WmsWorker Worker { get; set; }
        /// <summary>
        /// Склад
        /// </summary>
        public virtual WmsWarehouse Warehouse { get; set; }
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
    }

    /// <summary>
    /// Группа работников
    /// </summary>
    [Serializable]
    public partial class WmsWorkerGroup : BaseEntity
    {
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
    }

    /// <summary>
    /// Справочник работников
    /// </summary>
    [Serializable]
    public partial class WmsWorker : BaseEntity
    {
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
    }

    /// <summary>
    /// Удостоверяющий документ
    /// </summary>
    [Serializable]
    public partial class WmsWorkerPass : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 WorkerPassID { get; set; }
        /// <summary>
        /// Работник
        /// </summary>
        public virtual WmsWorker Worker { get; set; }
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
    }

    /// <summary>
    /// Работа к сущности
    /// </summary>
    [Serializable]
    public partial class WmsWork2Entity : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 Work2EntityID { get; set; }
        /// <summary>
        /// Работа
        /// </summary>
        public virtual WmsWork Work { get; set; }
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
    }

    /// <summary>
    /// Выполнение работ
    /// </summary>
    [Serializable]
    public partial class WmsWorking : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 WorkingID { get; set; }
        /// <summary>
        /// Работа
        /// </summary>
        public virtual WmsWork Work { get; set; }
        /// <summary>
        /// Группа работников
        /// </summary>
        public virtual WmsWorkerGroup WorkerGroup { get; set; }
        /// <summary>
        /// Работник
        /// </summary>
        public virtual WmsWorker Worker { get; set; }
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
    }

    /// <summary>
    /// Клиенты
    /// </summary>
    [Serializable]
    public partial class SysClient : BaseEntity
    {
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
        public virtual WmsTruck Truck { get; set; }
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
    }

    /// <summary>
    /// Сессии подключения
    /// </summary>
    [Serializable]
    public partial class SysClientSession : BaseEntity
    {
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
        public virtual SysClient Client { get; set; }
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
        public virtual SysClientType ClientType { get; set; }
        /// <summary>
        /// Погрузчик
        /// </summary>
        public virtual WmsTruck Truck { get; set; }
        /// <summary>
        /// Работник
        /// </summary>
        public virtual WmsWorker Worker { get; set; }
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
    }

    /// <summary>
    /// Правила обработки
    /// </summary>
    [Serializable]
    public partial class WmsRule : BaseEntity
    {
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
        public virtual BillOperation Operation { get; set; }
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
    }

    /// <summary>
    /// Параметры правил
    /// </summary>
    [Serializable]
    public partial class WmsRuleParam : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 RuleParamID { get; set; }
        /// <summary>
        /// Правило
        /// </summary>
        public virtual WmsRule Rule { get; set; }
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
    }

    /// <summary>
    /// Настройка правил
    /// </summary>
    [Serializable]
    public partial class WmsRuleConfig : BaseEntity
    {
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
        public virtual WmsRule Rule { get; set; }
        /// <summary>
        /// Операция
        /// </summary>
        public virtual BillOperation Operation { get; set; }
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
    }

    /// <summary>
    /// Выполнение правил
    /// </summary>
    [Serializable]
    public partial class WmsRuleExec : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 RuleExecID { get; set; }
        /// <summary>
        /// Правило
        /// </summary>
        public virtual WmsRule Rule { get; set; }
        /// <summary>
        /// Выполнение работ
        /// </summary>
        public virtual WmsWorking Working { get; set; }
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
    }

    /// <summary>
    /// Параметры выполнения правил
    /// </summary>
    [Serializable]
    public partial class WmsRuleExecParam : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 RuleExecParamID { get; set; }
        /// <summary>
        /// Выполняемое правило
        /// </summary>
        public virtual WmsRuleExec RuleExec { get; set; }
        /// <summary>
        /// Параметр
        /// </summary>
        public virtual WmsRuleParam RuleParam { get; set; }
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
    }

    /// <summary>
    /// Календарь
    /// </summary>
    [Serializable]
    public partial class WmsCalendar : BaseEntity
    {
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
    }

    /// <summary>
    /// Календарь к манданту
    /// </summary>
    [Serializable]
    public partial class WmsCalendar2Mandant : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 Calendar2MandantID { get; set; }
        /// <summary>
        /// Календарь
        /// </summary>
        public virtual WmsCalendar Calendar { get; set; }
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
    }

    /// <summary>
    /// Группа работ
    /// </summary>
    [Serializable]
    public partial class WmsWorkGroup : BaseEntity
    {
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
    }

    /// <summary>
    /// Тип работ
    /// </summary>
    [Serializable]
    public partial class WmsWTSelect : BaseEntity
    {
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
    }

    /// <summary>
    /// Черный список
    /// </summary>
    [Serializable]
    public partial class WmsBlackList : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 BlackListID { get; set; }
        /// <summary>
        /// Работник
        /// </summary>
        public virtual WmsWorker Worker { get; set; }
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
    }

    /// <summary>
    /// Марки автомобилей
    /// </summary>
    [Serializable]
    public partial class WmsCarType : BaseEntity
    {
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
    }

    /// <summary>
    /// Парковочные места
    /// </summary>
    [Serializable]
    public partial class YParking : BaseEntity
    {
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
    }

    /// <summary>
    /// Справочник автомобилей
    /// </summary>
    [Serializable]
    public partial class YVehicle : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 VehicleID { get; set; }
        /// <summary>
        /// Марка и модель
        /// </summary>
        public virtual WmsCarType CarType { get; set; }
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
        public virtual WmsPartner VehicleOwnerLegal { get; set; }
        /// <summary>
        /// Владелец ФИЗ
        /// </summary>
        public virtual WmsWorker VehiclePerson { get; set; }
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
    }

    /// <summary>
    /// Рейс
    /// </summary>
    [Serializable]
    public partial class YExternalTraffic : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 ExternalTrafficID { get; set; }
        /// <summary>
        /// Автомобиль
        /// </summary>
        public virtual YVehicle Vehicle { get; set; }
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
        public virtual YExternalTrafficStatus Status { get; set; }
        /// <summary>
        /// Водитель
        /// </summary>
        public virtual WmsWorker ExternalTrafficDriver { get; set; }
        /// <summary>
        /// Документ водителя
        /// </summary>
        public virtual WmsWorkerPass WorkerPass { get; set; }
        /// <summary>
        /// Экспедитор
        /// </summary>
        public virtual WmsWorker ExternalTrafficForvarder { get; set; }
        /// <summary>
        /// Перевозчик
        /// </summary>
        public virtual WmsPartner ExternalTrafficCarrier { get; set; }
        /// <summary>
        /// Место стоянки
        /// </summary>
        public virtual YParking Parking { get; set; }
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
    }

    /// <summary>
    /// Внутренний рейс
    /// </summary>
    [Serializable]
    public partial class YInternalTraffic : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 InternalTrafficID { get; set; }
        /// <summary>
        /// Рейс
        /// </summary>
        public virtual YExternalTraffic ExternalTraffic { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public virtual YInternalTrafficStatus Status { get; set; }
        /// <summary>
        /// Мандант
        /// </summary>
        public virtual WmsMandant Partner { get; set; }
        /// <summary>
        /// Склад
        /// </summary>
        public virtual WmsWarehouse Warehouse { get; set; }
        /// <summary>
        /// Цель
        /// </summary>
        public virtual YPurposeVisit PurposeVisit { get; set; }
        /// <summary>
        /// Ворота
        /// </summary>
        public virtual WmsGate Gate { get; set; }
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
        public virtual WmsWarehouseOffice WarehouseOffice { get; set; }
    }

    /// <summary>
    /// Маршрут
    /// </summary>
    [Serializable]
    public partial class YRoute : BaseEntity
    {
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
        public virtual YMgRoute MgRoute { get; set; }
        /// <summary>
        /// Дата
        /// </summary>
        public virtual DateTime RouteDate { get; set; }
        /// <summary>
        /// Ворота
        /// </summary>
        public virtual WmsGate Gate { get; set; }
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
    }

    /// <summary>
    /// Менеджер маршрутов
    /// </summary>
    [Serializable]
    public partial class YMgRoute : BaseEntity
    {
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
        public virtual WmsGate Gate { get; set; }
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
    }

    /// <summary>
    /// Выбор менеджера маршрутов
    /// </summary>
    [Serializable]
    public partial class YMgRouteSelect : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 MgRouteSelectID { get; set; }
        /// <summary>
        /// Менеджер маршрутов
        /// </summary>
        public virtual YMgRoute MgRoute { get; set; }
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
        public virtual WmsPartner OWBCarrier { get; set; }
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
    }

    /// <summary>
    /// Выбор даты маршрута
    /// </summary>
    [Serializable]
    public partial class YMgRouteDateSelect : BaseEntity
    {
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
    }

    /// <summary>
    /// Цель визита
    /// </summary>
    [Serializable]
    public partial class YPurposeVisit : BaseEntity
    {
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
    }

    /// <summary>
    /// Документы автомобиля
    /// </summary>
    [Serializable]
    public partial class YVehiclePass : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 VehiclePassID { get; set; }
        /// <summary>
        /// Автомобиль
        /// </summary>
        public virtual YVehicle Vehicle { get; set; }
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
    }

    /// <summary>
    /// Заявка на пропуск
    /// </summary>
    [Serializable]
    public partial class YPassRequest : BaseEntity
    {
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
        public virtual WmsWorkerPass WorkerPass { get; set; }
        /// <summary>
        /// ФИО
        /// </summary>
        public virtual String WorkerFio { get; set; }
        /// <summary>
        /// Водитель
        /// </summary>
        public virtual WmsWorker Worker { get; set; }
        /// <summary>
        /// № ТС
        /// </summary>
        public virtual String VehicleNumber { get; set; }
        /// <summary>
        /// ТС
        /// </summary>
        public virtual YVehicle Vehicle { get; set; }
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
        public virtual YPurposeVisit PurposeVisit { get; set; }
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
        public virtual WmsWorker WorkerAcceptEntry { get; set; }
        /// <summary>
        /// Выписал пропуск
        /// </summary>
        public virtual WmsWorker WorkerWritePass { get; set; }
        /// <summary>
        /// Закрыл пропуск
        /// </summary>
        public virtual WmsWorker WorkerClosePass { get; set; }
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
        public virtual WmsWarehouse Warehouse { get; set; }
        /// <summary>
        /// Офис
        /// </summary>
        public virtual WmsWarehouseOffice WarehouseOffice { get; set; }
    }

    /// <summary>
    /// Отношение менеджера товара к артикулам и группам артикулов
    /// </summary>
    [Serializable]
    public partial class WmsPM2Art : BaseEntity
    {
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 PM2ArtID { get; set; }
        /// <summary>
        /// Код артикула
        /// </summary>
        public virtual WmsArt Art { get; set; }
        /// <summary>
        /// Код группы артикулов
        /// </summary>
        public virtual WmsArtGroup ArtGroup { get; set; }
        /// <summary>
        /// Код менеджера товара
        /// </summary>
        public virtual WmsPM PM { get; set; }
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
    }

    /// <summary>
    /// Менеджер товара
    /// </summary>
    [Serializable]
    public partial class WmsPM : BaseEntity
    {
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
    }

    /// <summary>
    /// Тип комплекта
    /// </summary>
    [Serializable]
    public partial class WmsKitType : BaseEntity
    {
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
    }

    /// <summary>
    /// Комплект
    /// </summary>
    [Serializable]
    public partial class WmsKit : BaseEntity
    {
        /// <summary>
        /// Код комплекта
        /// </summary>
        public virtual String KitCode { get; set; }
        /// <summary>
        /// Код типа комплекта
        /// </summary>
        public virtual WmsKitType KitType { get; set; }
        /// <summary>
        /// Код артикула
        /// </summary>
        public virtual WmsArt Art { get; set; }
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
    }

    /// <summary>
    /// Способы обработки
    /// </summary>
    [Serializable]
    public partial class WmsPMMethod : BaseEntity
    {
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
    }

    /// <summary>
    /// Операции к менеджеру товара
    /// </summary>
    [Serializable]
    public partial class WmsPM2Operation : BaseEntity
    {
        /// <summary>
        /// Код пересечения
        /// </summary>
        public virtual String PM2OperationCode { get; set; }
        /// <summary>
        /// Код менеджера товара
        /// </summary>
        public virtual WmsPM PM { get; set; }
        /// <summary>
        /// Код операции
        /// </summary>
        public virtual BillOperation Operation { get; set; }
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
    }

    /// <summary>
    /// Методы к операциям
    /// </summary>
    [Serializable]
    public partial class WmsPMMethod2Operation : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 PMMethod2OperationID { get; set; }
        /// <summary>
        /// Операция
        /// </summary>
        public virtual BillOperation Operation { get; set; }
        /// <summary>
        /// Метод
        /// </summary>
        public virtual String PMMethodCode_r { get; set; }
        /// <summary>
        /// Конфигурация
        /// </summary>
        public virtual Int32 Config2ObjectID_r { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String PMMethod2OperationDesc { get; set; }
        /// <summary>
        /// По товару
        /// </summary>
        public virtual Boolean? PMMethod2OperationByProduct { get; set; }
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
        /// Маска ввода
        /// </summary>
        public virtual Boolean? PMMethod2OperationInputMask { get; set; }
        /// <summary>
        /// Массовый ввод
        /// </summary>
        public virtual Boolean? PMMethod2OperationInputMass { get; set; }
    }

    /// <summary>
    /// Конфигурация менеджера товара
    /// </summary>
    [Serializable]
    public partial class WmsPMConfig : BaseEntity
    {
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 PMConfigID { get; set; }
        /// <summary>
        /// Операция менеджера
        /// </summary>
        public virtual WmsPM2Operation PM2Operation { get; set; }
        /// <summary>
        /// Имя сущности объекта
        /// </summary>
        public virtual String ObjectEntityCode_r { get; set; }
        /// <summary>
        /// Имя объекта
        /// </summary>
        public virtual String ObjectName_r { get; set; }
        /// <summary>
        /// Код способа обработки
        /// </summary>
        public virtual WmsPMMethod PMMethod { get; set; }
        /// <summary>
        /// По товару
        /// </summary>
        public virtual Boolean? PMConfigByProduct { get; set; }
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
        /// Маска ввода
        /// </summary>
        public virtual String PMConfigInputMask { get; set; }
        /// <summary>
        /// Массовый ввод
        /// </summary>
        public virtual Boolean? PMConfigInputMass { get; set; }
    }

    /// <summary>
    /// Коммерческий акт
    /// </summary>
    [Serializable]
    public partial class WmsCommAct : BaseEntity
    {
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
        public virtual WmsCommActStatus Status { get; set; }
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
        public virtual WmsInv Invid_r { get; set; }
        /// <summary>
        /// Подтверждено СТН
        /// </summary>
        public virtual Boolean CommActWTVConfirm { get; set; }
        /// <summary>
        /// Причина корректировки
        /// </summary>
        public virtual WmsAdjustmentReason AdjustmentReason { get; set; }
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
    }

    /// <summary>
    /// Группы артикулов
    /// </summary>
    [Serializable]
    public partial class WmsArtGroup : BaseEntity
    {
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
    }

    /// <summary>
    /// Справочник штрих-кодов
    /// </summary>
    [Serializable]
    public partial class WmsBarcode : BaseEntity
    {
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
    }

    /// <summary>
    /// Справочник артикулов
    /// </summary>
    [Serializable]
    public partial class WmsArt : BaseEntity
    {
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
        public virtual WmsFactory Factory { get; set; }
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
        public virtual IsoCountry Country { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual WmsFile ArtPicture { get; set; }
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
    }

    /// <summary>
    /// Отношение артикулов к группам
    /// </summary>
    [Serializable]
    public partial class WmsArt2Group : BaseEntity
    {
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 Art2GroupID { get; set; }
        /// <summary>
        /// Код артикула
        /// </summary>
        public virtual WmsArt Art { get; set; }
        /// <summary>
        /// Код группы артикулов
        /// </summary>
        public virtual WmsArtGroup ArtGroup { get; set; }
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
    }

    /// <summary>
    /// SKU (Stock Keeping Unit) — единица учёта запасов
    /// </summary>
    [Serializable]
    public partial class WmsSKU : BaseEntity
    {
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 SKUID { get; set; }
        /// <summary>
        /// Код артикула
        /// </summary>
        public virtual WmsArt Art { get; set; }
        /// <summary>
        /// Единица измерения
        /// </summary>
        public virtual WmsMeasure Measure { get; set; }
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
        public virtual WmsSKU SKUParent { get; set; }
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
    }

    /// <summary>
    /// Справочник стоимостей артикулов
    /// </summary>
    [Serializable]
    public partial class WmsArtPrice : BaseEntity
    {
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 ArtPriceID { get; set; }
        /// <summary>
        /// ID записи SKU
        /// </summary>
        public virtual WmsSKU SKU { get; set; }
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
    }

    /// <summary>
    /// Комплектующие
    /// </summary>
    [Serializable]
    public partial class WmsKitPos : BaseEntity
    {
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 KitPosID { get; set; }
        /// <summary>
        /// Код комплекта
        /// </summary>
        public virtual WmsKit Kit { get; set; }
        /// <summary>
        /// ID записи SKU
        /// </summary>
        public virtual WmsSKU SKU { get; set; }
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
    }

    /// <summary>
    /// Блокировка товара
    /// </summary>
    [Serializable]
    public partial class wmsProduct2Blocking : BaseEntity
    {
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 Product2BlockingID { get; set; }
        /// <summary>
        /// ID товара
        /// </summary>
        public virtual WmsProduct Product { get; set; }
        /// <summary>
        /// Код блокировки
        /// </summary>
        public virtual WmsProductBlocking Blocking { get; set; }
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
    }

    /// <summary>
    /// Товар
    /// </summary>
    [Serializable]
    public partial class WmsProduct : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 ProductID { get; set; }
        /// <summary>
        /// ТЕ
        /// </summary>
        public virtual WmsTE TE { get; set; }
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
        public virtual WmsQLF QLF { get; set; }
        /// <summary>
        /// Детализация квалификации
        /// </summary>
        public virtual WmsQLFDetail QLFDetail { get; set; }
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
        public virtual WmsProductStatus Status { get; set; }
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
        public virtual IsoCountry Country { get; set; }
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
    }

    /// <summary>
    /// Весовой контроль
    /// </summary>
    [Serializable]
    public partial class WmsWeightControl : BaseEntity
    {
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
        public virtual WmsMeasure Measure { get; set; }
        /// <summary>
        /// Тип ТЕ
        /// </summary>
        public virtual WmsTEType TEType { get; set; }
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
    }

    /// <summary>
    /// SKU к партнерам
    /// </summary>
    [Serializable]
    public partial class WmsSKU2Partner : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 SKU2PartnerID { get; set; }
        /// <summary>
        /// SKU
        /// </summary>
        public virtual WmsSKU SKU { get; set; }
        /// <summary>
        /// Партнер
        /// </summary>
        public virtual WmsPartner Partner { get; set; }
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
    }

    /// <summary>
    /// СТН
    /// </summary>
    [Serializable]
    public partial class WmsWTV : BaseEntity
    {
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
    }

    /// <summary>
    /// Причины корректировки товара
    /// </summary>
    [Serializable]
    public partial class WmsAdjustmentReason : BaseEntity
    {
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
    }

    /// <summary>
    /// История изменения Методы к операциям
    /// </summary>
    [Serializable]
    public partial class WmsPMMethod2Operation_h : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int32 HistoryID { get; set; }
    }

    /// <summary>
    /// История изменения Конфигурация менеджера товара
    /// </summary>
    [Serializable]
    public partial class WmsPMConfig_h : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual Int32 HistoryID { get; set; }
    }

    /// <summary>
    /// Справочник бизнес-процессов
    /// </summary>
    [Serializable]
    public partial class BpProcess : BaseEntity
    {
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
        public virtual BpWorkflow WorkFlow { get; set; }
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
    }

    /// <summary>
    /// Журнал выполнения бизнес-процессов
    /// </summary>
    [Serializable]
    public partial class BpLog : BaseEntity
    {
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 BpLogID { get; set; }
        /// <summary>
        /// Код бизнес-процесса
        /// </summary>
        public virtual BpProcess Process { get; set; }
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
    }

    /// <summary>
    /// Триггер бизнес-процессов
    /// </summary>
    [Serializable]
    public partial class BpTrigger : BaseEntity
    {
        /// <summary>
        /// Код триггера
        /// </summary>
        public virtual String TriggerCode { get; set; }
        /// <summary>
        /// Код бизнес-процесса
        /// </summary>
        public virtual BpProcess Process { get; set; }
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
        public virtual SysUIButton UIButton { get; set; }
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
    }

    /// <summary>
    /// Batch
    /// </summary>
    [Serializable]
    public partial class BPBatch : BaseEntity
    {
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
        public virtual BpWorkflow Workflow { get; set; }
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
    }

    /// <summary>
    /// Выбор Batch
    /// </summary>
    [Serializable]
    public partial class BPBatchSelect : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 BatchSelectID { get; set; }
        /// <summary>
        /// Batch-код
        /// </summary>
        public virtual BPBatch Batch { get; set; }
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
    }

    /// <summary>
    /// Workflow
    /// </summary>
    [Serializable]
    public partial class BpWorkflow : BaseEntity
    {
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
    }

    /// <summary>
    /// Области перемещения
    /// </summary>
    [Serializable]
    public partial class WmsMotionArea : BaseEntity
    {
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
    }

    /// <summary>
    /// Области приемки
    /// </summary>
    [Serializable]
    public partial class WmsReceiveArea : BaseEntity
    {
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
    }

    /// <summary>
    /// Области поставки
    /// </summary>
    [Serializable]
    public partial class WmsSupplyArea : BaseEntity
    {
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
    }

    /// <summary>
    /// Справочник классов мест
    /// </summary>
    [Serializable]
    public partial class WmsPlaceClass : BaseEntity
    {
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
    }

    /// <summary>
    /// Типы мест
    /// </summary>
    [Serializable]
    public partial class WmsPlaceType : BaseEntity
    {
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
    }

    /// <summary>
    /// Отношения мест к блокировкам
    /// </summary>
    [Serializable]
    public partial class WmsPlace2Blocking : BaseEntity
    {
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 Place2BlockingID { get; set; }
        /// <summary>
        /// Код места
        /// </summary>
        public virtual WmsPlace Place { get; set; }
        /// <summary>
        /// Код блокировки
        /// </summary>
        public virtual WmsProductBlocking Blocking { get; set; }
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
    }

    /// <summary>
    /// Описывает типы областей склада
    /// </summary>
    [Serializable]
    public partial class WmsAreaType : BaseEntity
    {
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
    }

    /// <summary>
    /// Отношение области к блокировкам
    /// </summary>
    [Serializable]
    public partial class WmsArea2Blocking : BaseEntity
    {
        /// <summary>
        /// Код записи
        /// </summary>
        public virtual Int32 Area2BlockingID { get; set; }
        /// <summary>
        /// Код области склада
        /// </summary>
        public virtual WmsArea Area { get; set; }
        /// <summary>
        /// Код блокировки
        /// </summary>
        public virtual WmsProductBlocking Blocking { get; set; }
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
    }

    /// <summary>
    /// Отношение сектора к блокировкам
    /// </summary>
    [Serializable]
    public partial class WmsSegment2Blocking : BaseEntity
    {
        /// <summary>
        /// Код записи
        /// </summary>
        public virtual Int32 Segment2BlockingID { get; set; }
        /// <summary>
        /// Код записи сектора
        /// </summary>
        public virtual WmsSegment Segment { get; set; }
        /// <summary>
        /// Код блокировки
        /// </summary>
        public virtual WmsProductBlocking Blocking { get; set; }
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
    }

    /// <summary>
    /// Дерево групп областей перемещения
    /// </summary>
    [Serializable]
    public partial class WmsMotionAreaGroupTree : BaseEntity
    {
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 MotionAreaGroupTreeID { get; set; }
        /// <summary>
        /// Группа области перемещения
        /// </summary>
        public virtual WmsMotionAreaGroup MotionAreaGroup { get; set; }
        /// <summary>
        /// Родительская группа
        /// </summary>
        public virtual WmsMotionAreaGroup MotionAreaGroupCodeParent { get; set; }
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
    }

    /// <summary>
    /// Группы областей перемещения
    /// </summary>
    [Serializable]
    public partial class WmsMotionAreaGroup : BaseEntity
    {
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
    }

    /// <summary>
    /// Справочник типов секторов склада
    /// </summary>
    [Serializable]
    public partial class WmsSegmentType : BaseEntity
    {
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
    }

    /// <summary>
    /// Справочник секторов
    /// </summary>
    [Serializable]
    public partial class WmsSegment : BaseEntity
    {
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
        public virtual WmsArea Area { get; set; }
        /// <summary>
        /// Код типа сектора склада
        /// </summary>
        public virtual WmsSegmentType SegmentType { get; set; }
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
    }

    /// <summary>
    /// Справочник складов
    /// </summary>
    [Serializable]
    public partial class WmsWarehouse : BaseEntity
    {
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
        public virtual WmsSite Site { get; set; }
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
    }

    /// <summary>
    /// Ворота
    /// </summary>
    [Serializable]
    public partial class WmsGate : BaseEntity
    {
        /// <summary>
        /// Код ворот
        /// </summary>
        public virtual String GateCode { get; set; }
        /// <summary>
        /// Код склада
        /// </summary>
        public virtual WmsWarehouse Warehouse { get; set; }
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
    }

    /// <summary>
    /// Справочник областей склада
    /// </summary>
    [Serializable]
    public partial class WmsArea : BaseEntity
    {
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
        public virtual WmsAreaType AreaType { get; set; }
        /// <summary>
        /// Код склада
        /// </summary>
        public virtual WmsWarehouse Warehouse { get; set; }
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
    }

    /// <summary>
    /// Места
    /// </summary>
    [Serializable]
    public partial class WmsPlace : BaseEntity
    {
        /// <summary>
        /// Код
        /// </summary>
        public virtual String PlaceCode { get; set; }
        /// <summary>
        /// Код сектора
        /// </summary>
        public virtual WmsSegment Segment { get; set; }
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
        public virtual WmsPlaceStatus Status { get; set; }
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
        public virtual WmsPlaceType PlaceType { get; set; }
        /// <summary>
        /// Класс места
        /// </summary>
        public virtual WmsPlaceClass PlaceClass { get; set; }
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
        public virtual WmsReceiveArea ReceiveArea { get; set; }
        /// <summary>
        /// Область перемещения
        /// </summary>
        public virtual WmsMotionArea MotionArea { get; set; }
        /// <summary>
        /// Область поставки
        /// </summary>
        public virtual WmsSupplyArea SupplyArea { get; set; }
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
    }

    /// <summary>
    /// Площадка
    /// </summary>
    [Serializable]
    public partial class WmsSite : BaseEntity
    {
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
    }

    /// <summary>
    /// Офис
    /// </summary>
    [Serializable]
    public partial class WmsWarehouseOffice : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 WarehouseOfficeID { get; set; }
        /// <summary>
        /// Скад
        /// </summary>
        public virtual WmsWarehouse Warehouse { get; set; }
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
    }

    /// <summary>
    /// Детализация события
    /// </summary>
    [Serializable]
    public partial class wmsEventDetailIWB : BaseEntity
    {
        /// <summary>
        /// ID детализации
        /// </summary>
        public virtual Int32 EventDetailID { get; set; }
        /// <summary>
        /// Заголовок
        /// </summary>
        public virtual WmsEventHeader EventHeader { get; set; }
        /// <summary>
        /// Накладная
        /// </summary>
        public virtual Int32? IWBID_r { get; set; }
        /// <summary>
        /// Наименование накладной
        /// </summary>
        public virtual String IWBName_r { get; set; }
        /// <summary>
        /// Позиция накладной
        /// </summary>
        public virtual Int32? IWBPosID_r { get; set; }
        /// <summary>
        /// Номерр позиции накладной
        /// </summary>
        public virtual Int32? IWBPosNumber_r { get; set; }
        /// <summary>
        /// ID фабрики из накладной/позиции
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
        /// Событие
        /// </summary>
        public virtual String EventKindCode_r { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public virtual String StatusCode_r { get; set; }
        /// <summary>
        /// Мандант
        /// </summary>
        public virtual WmsMandant Partner { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? EventHeaderStartTime { get; set; }
    }

    /// <summary>
    /// Детализация событий 
    /// </summary>
    [Serializable]
    public partial class wmsEventDetailCAR : BaseEntity
    {
        /// <summary>
        /// ID детализации
        /// </summary>
        public virtual Int32 EventDetailID { get; set; }
        /// <summary>
        /// Заголовок
        /// </summary>
        public virtual WmsEventHeader EventHeader { get; set; }
        /// <summary>
        /// Внутренний рейс
        /// </summary>
        public virtual YInternalTraffic InternalTraffic { get; set; }
        /// <summary>
        /// Рейс
        /// </summary>
        public virtual YExternalTraffic ExternalTraffic { get; set; }
        /// <summary>
        /// Автомобиль
        /// </summary>
        public virtual YVehicle Vehicle { get; set; }
        /// <summary>
        /// Водитель
        /// </summary>
        public virtual WmsWorker ExternalTrafficDriver_r { get; set; }
        /// <summary>
        /// Рег.ном. автомобиля
        /// </summary>
        public virtual String VehicleRN_r { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Событие
        /// </summary>
        public virtual String EventKindCode_r { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public virtual String StatusCode_r { get; set; }
        /// <summary>
        /// Мандант
        /// </summary>
        public virtual WmsMandant Partner { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? EventHeaderStartTime { get; set; }
    }

    /// <summary>
    /// Детализация событий работам
    /// </summary>
    [Serializable]
    public partial class wmsEventDetailWORK : BaseEntity
    {
        /// <summary>
        /// ID детализации
        /// </summary>
        public virtual Int32 EventDetailID { get; set; }
        /// <summary>
        /// Заголовок
        /// </summary>
        public virtual WmsEventHeader EventHeader { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 WorkID_r { get; set; }
        /// <summary>
        /// Дата с
        /// </summary>
        public virtual DateTime? WorkFrom_r { get; set; }
        /// <summary>
        /// Дата по
        /// </summary>
        public virtual DateTime? WorkTill_r { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Событие
        /// </summary>
        public virtual String EventKindCode_r { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public virtual String StatusCode_r { get; set; }
        /// <summary>
        /// Мандант
        /// </summary>
        public virtual WmsMandant Partner { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? EventHeaderStartTime { get; set; }
    }

    /// <summary>
    /// Детализация событий по грузу
    /// </summary>
    [Serializable]
    public partial class wmsEventDetailCargo : BaseEntity
    {
        /// <summary>
        /// ID детализации
        /// </summary>
        public virtual Int32 EventDetailID { get; set; }
        /// <summary>
        /// Заголовок
        /// </summary>
        public virtual WmsEventHeader EventHeader { get; set; }
        /// <summary>
        /// ID груза на поставку
        /// </summary>
        public virtual Int32? CargoIWBID_r { get; set; }
        /// <summary>
        /// Место на воротах приемки
        /// </summary>
        public virtual String PlaceGateIn_r { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Событие
        /// </summary>
        public virtual String EventKindCode_r { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public virtual String StatusCode_r { get; set; }
        /// <summary>
        /// Мандант
        /// </summary>
        public virtual WmsMandant Partner { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? EventHeaderStartTime { get; set; }
    }

    /// <summary>
    /// Детализация событий резервирования / расхода (уровень накладной)
    /// </summary>
    [Serializable]
    public partial class wmsEventDetailOWB : BaseEntity
    {
        /// <summary>
        /// ID детализации
        /// </summary>
        public virtual Int32 EventDetailID { get; set; }
        /// <summary>
        /// Заголовок
        /// </summary>
        public virtual WmsEventHeader EventHeader { get; set; }
        /// <summary>
        /// ID расходной накладной
        /// </summary>
        public virtual Int32? OWBID_r { get; set; }
        /// <summary>
        /// Наименование расходной накладной
        /// </summary>
        public virtual String OWBName { get; set; }
        /// <summary>
        /// Статус накладной
        /// </summary>
        public virtual String OWBStatusCode_r { get; set; }
        /// <summary>
        /// ID очереди резервирования
        /// </summary>
        public virtual Int32? QResID_r { get; set; }
        /// <summary>
        /// ID фабрики из расходной накладной
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
        /// Событие
        /// </summary>
        public virtual String EventKindCode_r { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public virtual String StatusCode_r { get; set; }
        /// <summary>
        /// Мандант
        /// </summary>
        public virtual WmsMandant Partner { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? EventHeaderStartTime { get; set; }
    }

    /// <summary>
    /// Виды событий
    /// </summary>
    [Serializable]
    public partial class WmsEventKind : BaseEntity
    {
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
    }

    /// <summary>
    /// Классы операций
    /// </summary>
    [Serializable]
    public partial class BillOperationClass : BaseEntity
    {
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
    }

    /// <summary>
    /// Шкала расчетов
    /// </summary>
    [Serializable]
    public partial class BillScale : BaseEntity
    {
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
    }

    /// <summary>
    /// Значения шкал
    /// </summary>
    [Serializable]
    public partial class BillScaleValue : BaseEntity
    {
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 ScaleValueID { get; set; }
        /// <summary>
        /// Шкала
        /// </summary>
        public virtual BillScale Scale { get; set; }
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
        public virtual BillScaleValueType ScaleValueType { get; set; }
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
    }

    /// <summary>
    /// Biller
    /// </summary>
    [Serializable]
    public partial class BillBiller : BaseEntity
    {
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
    }

    /// <summary>
    /// Детализация транзакций
    /// </summary>
    [Serializable]
    public partial class BillTransactionDetail : BaseEntity
    {
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 TransactionDetailID { get; set; }
        /// <summary>
        /// Транзакция
        /// </summary>
        public virtual BillTransaction Transaction { get; set; }
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
        public virtual BillOperationCause OperationCause { get; set; }
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
    }

    /// <summary>
    /// Финансовые транзакции сотрудников
    /// </summary>
    [Serializable]
    public partial class BillTransactionW : BaseEntity
    {
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 TransactionWID { get; set; }
        /// <summary>
        /// Заголовок
        /// </summary>
        public virtual WmsEventHeader EventHeader { get; set; }
        /// <summary>
        /// Биллер
        /// </summary>
        public virtual BillBiller Biller { get; set; }
        /// <summary>
        /// Тип транзакции
        /// </summary>
        public virtual BillTransactionType TransactionType { get; set; }
        /// <summary>
        /// Плательщик
        /// </summary>
        public virtual WmsMandant Partner { get; set; }
        /// <summary>
        /// Получатель
        /// </summary>
        public virtual WmsWorker Worker { get; set; }
        /// <summary>
        /// К услуге по договору
        /// </summary>
        public virtual BillOperation2Contract Operation2Contract { get; set; }
        /// <summary>
        /// Сумма
        /// </summary>
        public virtual Double TransactionWAmmount { get; set; }
        /// <summary>
        /// Валюта договора
        /// </summary>
        public virtual IsoCurrency Currency { get; set; }
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
    }

    /// <summary>
    /// Детализация транзакций сотрудников
    /// </summary>
    [Serializable]
    public partial class BillTransactionWDetail : BaseEntity
    {
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 TransactionWDetailID { get; set; }
        /// <summary>
        /// Транзакция
        /// </summary>
        public virtual BillTransactionW TransactionW { get; set; }
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
    }

    /// <summary>
    /// Типы значений шкал
    /// </summary>
    [Serializable]
    public partial class BillScaleValueType : BaseEntity
    {
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
    }

    /// <summary>
    /// Тариф на услугу
    /// </summary>
    [Serializable]
    public partial class BillTariff : BaseEntity
    {
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 TariffID { get; set; }
        /// <summary>
        /// К услуге по договору
        /// </summary>
        public virtual BillOperation2Contract Operation2Contract { get; set; }
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
    }

    /// <summary>
    /// Типы транзакций
    /// </summary>
    [Serializable]
    public partial class BillTransactionType : BaseEntity
    {
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
    }

    /// <summary>
    /// Основание для оказания услуги
    /// </summary>
    [Serializable]
    public partial class BillOperationCause : BaseEntity
    {
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 OperationCauseID { get; set; }
        /// <summary>
        /// Услуга по договору
        /// </summary>
        public virtual BillOperation2Contract Operation2Contract { get; set; }
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
    }

    /// <summary>
    /// Виды событий к Biller-ам
    /// </summary>
    [Serializable]
    public partial class BillEventKind2Biller : BaseEntity
    {
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 EventKind2BillerID { get; set; }
        /// <summary>
        /// Вид события
        /// </summary>
        public virtual WmsEventKind EventKind { get; set; }
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
        public virtual BillBiller Biller { get; set; }
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
    }

    /// <summary>
    /// Финансовые транзакции
    /// </summary>
    [Serializable]
    public partial class BillTransaction : BaseEntity
    {
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 TransactionID { get; set; }
        /// <summary>
        /// Событие
        /// </summary>
        public virtual WmsEventHeader EventHeader { get; set; }
        /// <summary>
        /// Биллер
        /// </summary>
        public virtual BillBiller Biller { get; set; }
        /// <summary>
        /// Тип транзакции
        /// </summary>
        public virtual BillTransactionType TransactionType { get; set; }
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
        public virtual BillOperation2Contract Operation2Contract { get; set; }
        /// <summary>
        /// Сумма
        /// </summary>
        public virtual Double TransactionAmmount { get; set; }
        /// <summary>
        /// Валюта
        /// </summary>
        public virtual IsoCurrency Currency { get; set; }
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
    }

    /// <summary>
    /// События к мандантам
    /// </summary>
    [Serializable]
    public partial class WmsEventKind2Mandant : BaseEntity
    {
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
        public virtual WmsEventKind EventKind { get; set; }
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
    }

    /// <summary>
    /// Договоры
    /// </summary>
    [Serializable]
    public partial class BillContract : BaseEntity
    {
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
        public virtual IsoCurrency Currency { get; set; }
        /// <summary>
        /// НДС
        /// </summary>
        public virtual WmsVATType VATType { get; set; }
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
    }

    /// <summary>
    /// Услуги по договору
    /// </summary>
    [Serializable]
    public partial class BillOperation2Contract : BaseEntity
    {
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 Operation2ContractID { get; set; }
        /// <summary>
        /// Контракт
        /// </summary>
        public virtual BillContract Contract { get; set; }
        /// <summary>
        /// Услуга
        /// </summary>
        public virtual BillOperation Operation { get; set; }
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
        public virtual BillBiller Biller { get; set; }
        /// <summary>
        /// Аналитика
        /// </summary>
        public virtual BillAnalytics Analytics { get; set; }
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
    }

    /// <summary>
    /// Детализация акта производственных работ
    /// </summary>
    [Serializable]
    public partial class BillWorkActDetail : BaseEntity
    {
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 WorkActDetailID { get; set; }
        /// <summary>
        /// Акт
        /// </summary>
        public virtual BillWorkAct WorkAct { get; set; }
        /// <summary>
        /// Транзакция
        /// </summary>
        public virtual Int32? TransactionID_r { get; set; }
        /// <summary>
        /// Услуга по договору
        /// </summary>
        public virtual BillOperation2Contract Operation2Contract { get; set; }
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
        public virtual WmsSite Site { get; set; }
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
    }

    /// <summary>
    /// Акт производственных работ
    /// </summary>
    [Serializable]
    public partial class BillWorkAct : BaseEntity
    {
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 WorkActID { get; set; }
        /// <summary>
        /// Договор
        /// </summary>
        public virtual BillContract Contract { get; set; }
        /// <summary>
        /// Биллер
        /// </summary>
        public virtual BillBiller Biller { get; set; }
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
    }

    /// <summary>
    /// Операции системы
    /// </summary>
    [Serializable]
    public partial class BillOperation : BaseEntity
    {
        /// <summary>
        /// Код операции
        /// </summary>
        public virtual String OperationCode { get; set; }
        /// <summary>
        /// Код класса операции
        /// </summary>
        public virtual BillOperationClass OperationClass { get; set; }
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
    }

    /// <summary>
    /// Аналитика
    /// </summary>
    [Serializable]
    public partial class BillAnalytics : BaseEntity
    {
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
        public virtual BillAnalytics Analytics { get; set; }
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
    }

    /// <summary>
    /// События
    /// </summary>
    [Serializable]
    public partial class WmsEventHeader : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 EventHeaderID { get; set; }
        /// <summary>
        /// Событие
        /// </summary>
        public virtual WmsEventKind EventKind { get; set; }
        /// <summary>
        /// Тип клиента
        /// </summary>
        public virtual SysClientType ClientType { get; set; }
        /// <summary>
        /// Операция
        /// </summary>
        public virtual BillOperation Operation { get; set; }
        /// <summary>
        /// Бизнес-операция
        /// </summary>
        public virtual SYSENUM_OPERATION_BUSINESS EventHeaderOperationBusiness { get; set; }
        /// <summary>
        /// Бизнес-процесс
        /// </summary>
        public virtual BpProcess Process { get; set; }
        /// <summary>
        /// Экземпляр БП
        /// </summary>
        public virtual String EventHeaderInstance { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public virtual WmsEventHeaderStatus Status { get; set; }
        /// <summary>
        /// Статус биллинга
        /// </summary>
        public virtual EventHeaderBillStatus EventHeaderBillStatus { get; set; }
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
        public virtual WmsWork Work { get; set; }
        /// <summary>
        /// Выполнение работ
        /// </summary>
        public virtual WmsWorking Working { get; set; }
        /// <summary>
        /// Сессия
        /// </summary>
        public virtual SysClientSession ClientSession { get; set; }
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
    }

    /// <summary>
    /// Детализация событий по ком. актам
    /// </summary>
    [Serializable]
    public partial class wmsEventDetailCommAct : BaseEntity
    {
        /// <summary>
        /// ID детализации
        /// </summary>
        public virtual Int32 EventDetailID { get; set; }
        /// <summary>
        /// Заголовок
        /// </summary>
        public virtual WmsEventHeader EventHeader { get; set; }
        /// <summary>
        /// ID коммерческого акта
        /// </summary>
        public virtual Int32 CommActID_r { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Событие
        /// </summary>
        public virtual String EventKindCode_r { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public virtual String StatusCode_r { get; set; }
        /// <summary>
        /// Мандант
        /// </summary>
        public virtual WmsMandant Partner { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? EventHeaderStartTime { get; set; }
    }

    /// <summary>
    /// Детализация событий по СТН
    /// </summary>
    [Serializable]
    public partial class wmsEventDetailWTV : BaseEntity
    {
        /// <summary>
        /// ID детализации
        /// </summary>
        public virtual Int32 EventDetailID { get; set; }
        /// <summary>
        /// Заголовок
        /// </summary>
        public virtual WmsEventHeader EventHeader { get; set; }
        /// <summary>
        /// ID коммерческого акта
        /// </summary>
        public virtual Int32 CommActID_r { get; set; }
        /// <summary>
        /// ID строки СТН
        /// </summary>
        public virtual Int32 WTVID_r { get; set; }
        /// <summary>
        /// ID строки истории товара
        /// </summary>
        public virtual Int32? PHID_r { get; set; }
        /// <summary>
        /// ID приходной накладной
        /// </summary>
        public virtual Int32? WTVIWBID_r { get; set; }
        /// <summary>
        /// количество по СТН
        /// </summary>
        public virtual Int32 WTVCountSKU { get; set; }
        /// <summary>
        /// предыдущее количество по СТН
        /// </summary>
        public virtual Int32 OLDWTVCountSKU { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Событие
        /// </summary>
        public virtual String EventKindCode_r { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public virtual String StatusCode_r { get; set; }
        /// <summary>
        /// Мандант
        /// </summary>
        public virtual WmsMandant Partner { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? EventHeaderStartTime { get; set; }
    }

    /// <summary>
    /// Выбор бизнес-операций
    /// </summary>
    [Serializable]
    public partial class BillEvent2Operation : BaseEntity
    {
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
        public virtual WmsEventKind EventKind { get; set; }
        /// <summary>
        /// Операция
        /// </summary>
        public virtual BillOperation Operation { get; set; }
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
    }

    /// <summary>
    /// Стратегии
    /// </summary>
    [Serializable]
    public partial class BillStrategy : BaseEntity
    {
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
    }

    /// <summary>
    /// Параметры стратегий
    /// </summary>
    [Serializable]
    public partial class BillStrategyParams : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 StrategyParamsID { get; set; }
        /// <summary>
        /// Стратегия
        /// </summary>
        public virtual BillStrategy Strategy { get; set; }
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
    }

    /// <summary>
    /// Применение стратегии
    /// </summary>
    [Serializable]
    public partial class BillStrategyUse : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 StrategyUseID { get; set; }
        /// <summary>
        /// Стратегия
        /// </summary>
        public virtual BillStrategy Strategy { get; set; }
        /// <summary>
        /// Услуга по договору
        /// </summary>
        public virtual BillOperation2Contract Operation2Contract { get; set; }
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
    }

    /// <summary>
    /// Значения применения стратегий
    /// </summary>
    [Serializable]
    public partial class BillStrategyUseValues : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 StrategyUseValuesID { get; set; }
        /// <summary>
        /// Применение стратегии
        /// </summary>
        public virtual BillStrategyUse StrategyUse { get; set; }
        /// <summary>
        /// Параметр стратегии
        /// </summary>
        public virtual BillStrategyParams StrategyParams { get; set; }
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
    }

    /// <summary>
    /// Типы БПП
    /// </summary>
    [Serializable]
    public partial class BillUserParamsType : BaseEntity
    {
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
    }

    /// <summary>
    /// БПП
    /// </summary>
    [Serializable]
    public partial class BillUserParams : BaseEntity
    {
        /// <summary>
        /// Код
        /// </summary>
        public virtual String UserParamsCode { get; set; }
        /// <summary>
        /// Тип БПП
        /// </summary>
        public virtual BillUserParamsType UserParamsType { get; set; }
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
    }

    /// <summary>
    /// БПП к услугам по договору
    /// </summary>
    [Serializable]
    public partial class BillUserParams2O2C : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 UserParams2O2CID { get; set; }
        /// <summary>
        /// БПП
        /// </summary>
        public virtual BillUserParams UserParams { get; set; }
        /// <summary>
        /// Услуга по договору
        /// </summary>
        public virtual BillOperation2Contract Operation2Contract { get; set; }
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
    }

    /// <summary>
    /// Типы применения БПП
    /// </summary>
    [Serializable]
    public partial class BillUserParamsTypeApply : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 UserParamsTypeApplyID { get; set; }
        /// <summary>
        /// Тип БПП
        /// </summary>
        public virtual BillUserParamsType UserParamsType { get; set; }
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
    }

    /// <summary>
    /// Значения БПП
    /// </summary>
    [Serializable]
    public partial class BillUserParamsValue : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 UserParamsValueID { get; set; }
        /// <summary>
        /// БПП
        /// </summary>
        public virtual BillUserParams UserParams { get; set; }
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
    }

    /// <summary>
    /// Детализация события
    /// </summary>
    [Serializable]
    public partial class wmsEventDetailTTask : BaseEntity
    {
        /// <summary>
        /// ID детализации
        /// </summary>
        public virtual Int32 EventDetailID { get; set; }
        /// <summary>
        /// Заголовок
        /// </summary>
        public virtual WmsEventHeader EventHeader { get; set; }
        /// <summary>
        /// ЗНТ
        /// </summary>
        public virtual Int32 TTaskID_r { get; set; }
        /// <summary>
        /// Место куда
        /// </summary>
        public virtual String PlaceCode_r { get; set; }
        /// <summary>
        /// Зона приемки куда
        /// </summary>
        public virtual String ReceiveAreaCode_r { get; set; }
        /// <summary>
        /// Зона перемещения куда
        /// </summary>
        public virtual String MotionAreaCode_r { get; set; }
        /// <summary>
        /// Зона поставки куда
        /// </summary>
        public virtual String SupplyAreaCode_r { get; set; }
        /// <summary>
        /// Место откуда
        /// </summary>
        public virtual String OLDPlaceCode_r { get; set; }
        /// <summary>
        /// Зона приемки откуда
        /// </summary>
        public virtual String OLDReceiveAreaCode_r { get; set; }
        /// <summary>
        /// Зона перемещения откуда
        /// </summary>
        public virtual String OLDMotionAreaCode_r { get; set; }
        /// <summary>
        /// Зона поставки откуда
        /// </summary>
        public virtual String OLDSupplyAreaCode_r { get; set; }
        /// <summary>
        /// Менеджер поставок
        /// </summary>
        public virtual String MSCCode_r { get; set; }
        /// <summary>
        /// Тип менеджера поставок
        /// </summary>
        public virtual String MSCTypeCode_r { get; set; }
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
        public virtual Boolean? MSCFinal { get; set; }
        /// <summary>
        /// Несущая ТЕ
        /// </summary>
        public virtual String TECarrierBaseCode { get; set; }
        /// <summary>
        /// Несущая ТЕ
        /// </summary>
        public virtual String OLDTECarrierBaseCode { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Событие
        /// </summary>
        public virtual String EventKindCode_r { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public virtual String StatusCode_r { get; set; }
        /// <summary>
        /// Мандант
        /// </summary>
        public virtual WmsMandant Partner { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? EventHeaderStartTime { get; set; }
    }

    /// <summary>
    /// Специальная функция
    /// </summary>
    [Serializable]
    public partial class BillSpecialFunction : BaseEntity
    {
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
    }

    /// <summary>
    /// Параметры специальной функции
    /// </summary>
    [Serializable]
    public partial class BillSpecialFuncParams : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 SpecialFunctionParamsID { get; set; }
        /// <summary>
        /// Специальная функция
        /// </summary>
        public virtual BillSpecialFunction SpecialFunction { get; set; }
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
    }

    /// <summary>
    /// Сущности специальной функции
    /// </summary>
    [Serializable]
    public partial class BillSpecialFuncEntity : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 SpecialFunctionEntityID { get; set; }
        /// <summary>
        /// Специальная функция
        /// </summary>
        public virtual BillSpecialFunction SpecialFunction { get; set; }
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
    }

    /// <summary>
    /// Шаблон источника данных
    /// </summary>
    [Serializable]
    public partial class PattTDataSource : BaseEntity
    {
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
    }

    /// <summary>
    /// Секция полей шаблона ИД
    /// </summary>
    [Serializable]
    public partial class PattTFieldSection : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 TemplateFieldSectionID { get; set; }
        /// <summary>
        /// Шаблон
        /// </summary>
        public virtual PattTDataSource TemplateDataSource { get; set; }
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
    }

    /// <summary>
    /// Секция условий шаблона ИД
    /// </summary>
    [Serializable]
    public partial class PattTWhereSection : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 TemplateWhereSectionID { get; set; }
        /// <summary>
        /// Шаблон
        /// </summary>
        public virtual PattTDataSource TemplateDataSource { get; set; }
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
    }

    /// <summary>
    /// Параметры шаблона ИД
    /// </summary>
    [Serializable]
    public partial class PattTParams : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 TemplateParamsID { get; set; }
        /// <summary>
        /// Шаблон
        /// </summary>
        public virtual PattTDataSource TemplateDataSource { get; set; }
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
    }

    /// <summary>
    /// Сущности условий шаблона ИД
    /// </summary>
    [Serializable]
    public partial class PattTWhereEntity : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 TemplateWhereEntityID { get; set; }
        /// <summary>
        /// Секция условий источника данных
        /// </summary>
        public virtual PattTWhereSection TemplateWhereSection { get; set; }
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
    }

    /// <summary>
    /// Поля шаблона ИД
    /// </summary>
    [Serializable]
    public partial class PattTField : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 TemplateFieldID { get; set; }
        /// <summary>
        /// Секция полей источника данных
        /// </summary>
        public virtual PattTFieldSection TemplateFieldSection { get; set; }
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
    }

    /// <summary>
    /// Сущности полей шаблона ИД
    /// </summary>
    [Serializable]
    public partial class PattTFieldEntity : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 TemplateFieldEntityID { get; set; }
        /// <summary>
        /// Секция полей источника данных
        /// </summary>
        public virtual PattTFieldSection TemplateFieldSection { get; set; }
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
    }

    /// <summary>
    /// Источник данных
    /// </summary>
    [Serializable]
    public partial class PattCalcDataSource : BaseEntity
    {
        /// <summary>
        /// Код
        /// </summary>
        public virtual String CalcDataSourceCode { get; set; }
        /// <summary>
        /// Шаблон
        /// </summary>
        public virtual PattTDataSource TemplateDataSource { get; set; }
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
    }

    /// <summary>
    /// Поля источника данных
    /// </summary>
    [Serializable]
    public partial class PattCalcField : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 CalcFieldID { get; set; }
        /// <summary>
        /// Источник данных
        /// </summary>
        public virtual PattCalcDataSource CalcDataSource { get; set; }
        /// <summary>
        /// Секция полей шаблона ИД
        /// </summary>
        public virtual PattTFieldSection TemplateFieldSection { get; set; }
        /// <summary>
        /// Специальная функция
        /// </summary>
        public virtual BillSpecialFunction SpecialFunction { get; set; }
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
    }

    /// <summary>
    /// Условия источника данных
    /// </summary>
    [Serializable]
    public partial class PattCalcWhere : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 CalcWhereID { get; set; }
        /// <summary>
        /// Источник данных
        /// </summary>
        public virtual PattCalcDataSource CalcDataSource { get; set; }
        /// <summary>
        /// Секция условий шаблона ИД
        /// </summary>
        public virtual PattTWhereSection TemplateWhereSection { get; set; }
        /// <summary>
        /// Специальная функция
        /// </summary>
        public virtual BillSpecialFunction SpecialFunction { get; set; }
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
    }

    /// <summary>
    /// Параметры источника данных
    /// </summary>
    [Serializable]
    public partial class PattCalcParam : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 CalcParamID { get; set; }
        /// <summary>
        /// Источник данных
        /// </summary>
        public virtual PattCalcDataSource CalcDataSource { get; set; }
        /// <summary>
        /// Параметр шаблона ИД
        /// </summary>
        public virtual PattTParams TemplateParams { get; set; }
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
    }

    /// <summary>
    /// Биллинговая сущность
    /// </summary>
    [Serializable]
    public partial class BillBillEntity : BaseEntity
    {
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
    }

    /// <summary>
    /// Настройка расчета
    /// </summary>
    [Serializable]
    public partial class BillCalcConfig : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 CalcConfigID { get; set; }
        /// <summary>
        /// Биллер
        /// </summary>
        public virtual BillBiller Biller { get; set; }
        /// <summary>
        /// Услуга по договору
        /// </summary>
        public virtual BillOperation2Contract Operation2Contract { get; set; }
        /// <summary>
        /// Источник данных
        /// </summary>
        public virtual PattCalcDataSource CalcDataSource { get; set; }
        /// <summary>
        /// Биллинговая сущность
        /// </summary>
        public virtual BillBillEntity BillEntity { get; set; }
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
    }

    /// <summary>
    /// Детализация настройки расчета
    /// </summary>
    [Serializable]
    public partial class BillCalcConfigDetail : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 CalcConfigDetailID { get; set; }
        /// <summary>
        /// Настройка расчета
        /// </summary>
        public virtual BillCalcConfig CalcConfig { get; set; }
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
    }

    /// <summary>
    /// Настройка предварительной проверки
    /// </summary>
    [Serializable]
    public partial class BillCalcVerification : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 CalcVerificationID { get; set; }
        /// <summary>
        /// Биллер
        /// </summary>
        public virtual BillBiller Biller { get; set; }
        /// <summary>
        /// Услуга по договору
        /// </summary>
        public virtual BillOperation2Contract Operation2Contract { get; set; }
        /// <summary>
        /// Источник данных
        /// </summary>
        public virtual PattCalcDataSource CalcDataSource { get; set; }
        /// <summary>
        /// Биллинговая сущность
        /// </summary>
        public virtual BillBillEntity BillEntity { get; set; }
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
    }

    /// <summary>
    /// Настройка биллинговых событий
    /// </summary>
    [Serializable]
    public partial class BillCalcEventConfig : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 CalcEventConfigID { get; set; }
        /// <summary>
        /// Биллер
        /// </summary>
        public virtual BillBiller Biller { get; set; }
        /// <summary>
        /// Услуга по договору
        /// </summary>
        public virtual BillOperation2Contract Operation2Contract { get; set; }
        /// <summary>
        /// Источник данных
        /// </summary>
        public virtual PattCalcDataSource CalcDataSource { get; set; }
        /// <summary>
        /// Биллинговая сущность
        /// </summary>
        public virtual BillBillEntity BillEntity { get; set; }
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
        public virtual WmsEventKind EventKind { get; set; }
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
    }

    /// <summary>
    /// События к обработчикам
    /// </summary>
    [Serializable]
    public partial class WmsEventKind2Action : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 EventKind2ActionID { get; set; }
        /// <summary>
        /// Вид события
        /// </summary>
        public virtual WmsEventKind EventKind { get; set; }
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
    }

    /// <summary>
    /// Детализация событий 
    /// </summary>
    [Serializable]
    public partial class wmsEventDetailPL : BaseEntity
    {
        /// <summary>
        /// ID детализации
        /// </summary>
        public virtual Int32 EventDetailID { get; set; }
        /// <summary>
        /// Заголовок
        /// </summary>
        public virtual WmsEventHeader EventHeader { get; set; }
        /// <summary>
        /// Список пикинга
        /// </summary>
        public virtual Int32? PLID_r { get; set; }
        /// <summary>
        /// Позиция списка пикинга
        /// </summary>
        public virtual Int32? PLPosID_r { get; set; }
        /// <summary>
        /// Место
        /// </summary>
        public virtual String PlaceCode_r { get; set; }
        /// <summary>
        /// История позиции списка пикинга
        /// </summary>
        public virtual Int32? HistoryID_r { get; set; }
        /// <summary>
        /// Вид события
        /// </summary>
        public virtual String EventKindCode_r { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public virtual String StatusCode_r { get; set; }
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
        /// 
        /// </summary>
        public virtual DateTime? EventHeaderStartTime { get; set; }
    }

    /// <summary>
    /// Менеджер перемещения
    /// </summary>
    [Serializable]
    public partial class WmsMM : BaseEntity
    {
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
    }

    /// <summary>
    /// Отношение типов ТЕ к типам ТЕ
    /// </summary>
    [Serializable]
    public partial class WmsTEType2TEType : BaseEntity
    {
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 TEType2TETypeID { get; set; }
        /// <summary>
        /// Ведомый тип ТЕ
        /// </summary>
        public virtual WmsTEType TEType2TETypeSlave { get; set; }
        /// <summary>
        /// Ведущий тип ТЕ
        /// </summary>
        public virtual WmsTEType TEType2TETypeMaster { get; set; }
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
    }

    /// <summary>
    /// Отношение типов ТЕ к типам погрузчиков
    /// </summary>
    [Serializable]
    public partial class WmsTeType2TruckType : BaseEntity
    {
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 TeType2TruckTypeID { get; set; }
        /// <summary>
        /// Код типа ТЕ
        /// </summary>
        public virtual WmsTEType TEType { get; set; }
        /// <summary>
        /// Код типа погрузчика
        /// </summary>
        public virtual WmsTruckType TruckType { get; set; }
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
    }

    /// <summary>
    /// Отношение ТЕ к блокировкам
    /// </summary>
    [Serializable]
    public partial class WmsTE2Blocking : BaseEntity
    {
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 TE2BlockingID { get; set; }
        /// <summary>
        /// Код ТЕ
        /// </summary>
        public virtual WmsTE TE { get; set; }
        /// <summary>
        /// Код блокировки
        /// </summary>
        public virtual WmsProductBlocking Blocking { get; set; }
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
    }

    /// <summary>
    /// Справочник типов ТЕ
    /// </summary>
    [Serializable]
    public partial class WmsTEType : BaseEntity
    {
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
    }

    /// <summary>
    /// Отношение типов ТЕ к классам мест
    /// </summary>
    [Serializable]
    public partial class WmsTEType2PlaceClass : BaseEntity
    {
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 TEType2PlaceClassID { get; set; }
        /// <summary>
        /// Код типа ТЕ
        /// </summary>
        public virtual WmsTEType TEType { get; set; }
        /// <summary>
        /// Код класса места
        /// </summary>
        public virtual WmsPlaceClass PlaceClass { get; set; }
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
    }

    /// <summary>
    /// Типы транспортных заданий
    /// </summary>
    [Serializable]
    public partial class WmsTransportTaskType : BaseEntity
    {
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
    }

    /// <summary>
    /// Транспортные задания
    /// </summary>
    [Serializable]
    public partial class WmsTransportTask : BaseEntity
    {
        /// <summary>
        /// ID транспортного задания
        /// </summary>
        public virtual Int32 TTaskID { get; set; }
        /// <summary>
        /// Код ТЕ
        /// </summary>
        public virtual WmsTE TE { get; set; }
        /// <summary>
        /// Код типа транспортного задания
        /// </summary>
        public virtual WmsTransportTaskType TTaskType { get; set; }
        /// <summary>
        /// Дозагруз
        /// </summary>
        public virtual Boolean TTaskLoad { get; set; }
        /// <summary>
        /// Исходное место
        /// </summary>
        public virtual WmsPlace TTaskStartPlace { get; set; }
        /// <summary>
        /// Текущее место
        /// </summary>
        public virtual WmsPlace TTaskCurrentPlace { get; set; }
        /// <summary>
        /// Следующее место
        /// </summary>
        public virtual WmsPlace TTaskNextPlace { get; set; }
        /// <summary>
        /// Конечное место
        /// </summary>
        public virtual WmsPlace TTaskFinishPlace { get; set; }
        /// <summary>
        /// Статус транспортного задания
        /// </summary>
        public virtual WmsTransportTaskStatus Status { get; set; }
        /// <summary>
        /// Погрузчик
        /// </summary>
        public virtual WmsTruck Truck { get; set; }
        /// <summary>
        /// Система
        /// </summary>
        public virtual SysClient Client { get; set; }
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
    }

    /// <summary>
    /// Применение менеджера перемещения
    /// </summary>
    [Serializable]
    public partial class WmsMMUse : BaseEntity
    {
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 MMUseID { get; set; }
        /// <summary>
        /// Менеджер перемещения
        /// </summary>
        public virtual WmsMM MM { get; set; }
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
    }

    /// <summary>
    /// Справочник выбора менеджера перемещения
    /// </summary>
    [Serializable]
    public partial class WmsMMSelect : BaseEntity
    {
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 MMSelectID { get; set; }
        /// <summary>
        /// Менеджер перемещения
        /// </summary>
        public virtual WmsMM MM { get; set; }
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
        public virtual WmsQLF QLF { get; set; }
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
    }

    /// <summary>
    /// Транспортные единицы
    /// </summary>
    [Serializable]
    public partial class WmsTE : BaseEntity
    {
        /// <summary>
        /// ТЕ
        /// </summary>
        public virtual String TECode { get; set; }
        /// <summary>
        /// Тип ТЕ
        /// </summary>
        public virtual WmsTEType TEType { get; set; }
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
        public virtual WmsPlace TECurrentPlace { get; set; }
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
        public virtual WmsTEStatus Status { get; set; }
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
        public virtual WmsCargoOWB CargoOWB { get; set; }
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
    }

    /// <summary>
    /// Отношение типов ТЕ к артикулу
    /// </summary>
    [Serializable]
    public partial class WmsSKU2TTE : BaseEntity
    {
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 SKU2TTEID { get; set; }
        /// <summary>
        /// Код типа ТЕ
        /// </summary>
        public virtual WmsTEType TEType { get; set; }
        /// <summary>
        /// ID записи SKU
        /// </summary>
        public virtual WmsSKU SKU { get; set; }
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
    }

    /// <summary>
    /// Отношение типов ТЕ к мандантам
    /// </summary>
    [Serializable]
    public partial class WmsTEType2Mandant : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 TEType2MandantID { get; set; }
        /// <summary>
        /// Тип ТЕ
        /// </summary>
        public virtual WmsTEType TEType { get; set; }
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
    }

    /// <summary>
    /// Системные параметры
    /// </summary>
    [Serializable]
    public partial class SysParam_ : BaseEntity
    {
        /// <summary>
        /// Наименование параметра
        /// </summary>
        public virtual String ParamName { get; set; }
        /// <summary>
        /// Его значение
        /// </summary>
        public virtual String ParamValue { get; set; }
        /// <summary>
        /// Человеческое описание для чего, чтоб незабыть )
        /// </summary>
        public virtual String ParamDesc { get; set; }
    }

    /// <summary>
    /// Машина состояний
    /// </summary>
    [Serializable]
    public partial class SysStateMachine : BaseEntity
    {
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
        public virtual BillOperation Operation { get; set; }
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
    }

    /// <summary>
    /// Конфигурации к сущностям и атрибутам
    /// </summary>
    [Serializable]
    public partial class SysConfig2Object : BaseEntity
    {
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 Config2ObjectID { get; set; }
        /// <summary>
        /// Код конфигурации
        /// </summary>
        public virtual SysObjectConfig ObjectConfig { get; set; }
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
    }

    /// <summary>
    /// Конфигурации
    /// </summary>
    [Serializable]
    public partial class SysObjectConfig : BaseEntity
    {
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
    }

    /// <summary>
    /// Сущности к конфигурациям
    /// </summary>
    [Serializable]
    public partial class SysObject2Config : BaseEntity
    {
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 Object2ConfigID { get; set; }
        /// <summary>
        /// Код конфигурации
        /// </summary>
        public virtual SysObjectConfig ObjectConfig { get; set; }
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
    }

    /// <summary>
    /// Системный справочник перечислений
    /// </summary>
    [Serializable]
    public partial class SysEnum : BaseEntity
    {
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
        public virtual String EnumValue { get; set; }
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
    }

    /// <summary>
    /// Запрещенные операции для состояния
    /// </summary>
    [Serializable]
    public partial class SysState2Operation : BaseEntity
    {
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
        public virtual SysState2OperationStatus Status { get; set; }
        /// <summary>
        /// Операция
        /// </summary>
        public virtual BillOperation Operation { get; set; }
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
    }

    /// <summary>
    /// Быстрые переходы
    /// </summary>
    [Serializable]
    public partial class SysEntityLink : BaseEntity
    {
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
    }

    /// <summary>
    /// Кнопка
    /// </summary>
    [Serializable]
    public partial class SysUIButton : BaseEntity
    {
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
    }

    /// <summary>
    /// Описание lookup-ов системных объектов
    /// </summary>
    [Serializable]
    public partial class SysObjectLookup : BaseEntity
    {
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
    }

    /// <summary>
    /// Параметры виртуальных полей
    /// </summary>
    [Serializable]
    public partial class SysObjectVirtualFieldParam : BaseEntity
    {
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
    }

    /// <summary>
    /// Дерево меню
    /// </summary>
    [Serializable]
    public partial class SysObjectTreeMenu : BaseEntity
    {
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
    }

    /// <summary>
    /// Атрибуты валидации
    /// </summary>
    [Serializable]
    public partial class SysObjectValid : BaseEntity
    {
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
    }

    /// <summary>
    /// Справочник значений системных параметров
    /// </summary>
    [Serializable]
    public partial class SysGlobalParamValue : BaseEntity
    {
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
        public virtual SysGlobalParam GlobalParam { get; set; }
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
    }

    /// <summary>
    /// Справочник системных параметров для сущностей Sys иWms
    /// </summary>
    [Serializable]
    public partial class SysGlobalParam : BaseEntity
    {
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
    }

    /// <summary>
    /// Системные сервисы
    /// </summary>
    [Serializable]
    public partial class SysService : BaseEntity
    {
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
    }

    /// <summary>
    /// Конфигурация архива
    /// </summary>
    [Serializable]
    public partial class SysArch : BaseEntity
    {
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
    }

    /// <summary>
    /// Архив
    /// </summary>
    [Serializable]
    public partial class SysArchInst : BaseEntity
    {
        /// <summary>
        /// GUID
        /// </summary>
        public virtual Guid ArchInstGUID { get; set; }
        /// <summary>
        /// Конфигурация
        /// </summary>
        public virtual SysArch Arch { get; set; }
        /// <summary>
        /// Дата архивации
        /// </summary>
        public virtual DateTime ArchInstDate { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public virtual SysArchInstStatus Status { get; set; }
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
    }

    /// <summary>
    /// Справочник физических цветов
    /// </summary>
    [Serializable]
    public partial class SysColorPhysical : BaseEntity
    {
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
    }

    /// <summary>
    /// Справочник счетчиков системы
    /// </summary>
    [Serializable]
    public partial class SysSequence : BaseEntity
    {
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
    }

    /// <summary>
    /// Права на доступ к мандантам
    /// </summary>
    [Serializable]
    public partial class WmsUser2Mandant : BaseEntity
    {
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
    }

    /// <summary>
    /// Справочник бизнес-партнеров
    /// </summary>
    [Serializable]
    public partial class WmsPartner : BaseEntity
    {
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
        public virtual WmsPartner PartnerParent { get; set; }
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
    }

    /// <summary>
    /// Группы партнеров
    /// </summary>
    [Serializable]
    public partial class WmsPartnerGroup : BaseEntity
    {
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
    }

    /// <summary>
    /// Фабрика
    /// </summary>
    [Serializable]
    public partial class WmsFactory : BaseEntity
    {
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
    }

    /// <summary>
    /// Контактные лица
    /// </summary>
    [Serializable]
    public partial class WmsEmployee : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 EmployeeID { get; set; }
        /// <summary>
        /// Партнер
        /// </summary>
        public virtual WmsPartner Partner { get; set; }
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
    }

    /// <summary>
    /// Контакты партнера к расходу
    /// </summary>
    [Serializable]
    public partial class WmsEmployee2OWB : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 Employee2OWBID { get; set; }
        /// <summary>
        /// Контакт
        /// </summary>
        public virtual WmsEmployee Employee { get; set; }
        /// <summary>
        /// Расходная накладная
        /// </summary>
        public virtual WmsOWB OWB { get; set; }
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
    }

    /// <summary>
    /// Клиенты
    /// </summary>
    [Serializable]
    public partial class ecomClient : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 ClientID { get; set; }
        /// <summary>
        /// Мандант
        /// </summary>
        public virtual WmsPartner Partner { get; set; }
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
    }

    /// <summary>
    /// Адреса клиентов
    /// </summary>
    [Serializable]
    public partial class ecomClient2AddressBook : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 Client2AddressBookID { get; set; }
        /// <summary>
        /// Клиент
        /// </summary>
        public virtual ecomClient Client { get; set; }
        /// <summary>
        /// Адрес
        /// </summary>
        public virtual WmsAddressBook AddressBook { get; set; }
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
    }

    /// <summary>
    /// Файл
    /// </summary>
    [Serializable]
    public partial class WmsFile : BaseEntity
    {
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
    }

    /// <summary>
    /// Квалификация
    /// </summary>
    [Serializable]
    public partial class WmsQLF : BaseEntity
    {
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
    }

    /// <summary>
    /// Детализация квалификации
    /// </summary>
    [Serializable]
    public partial class WmsQLFDetail : BaseEntity
    {
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
    }

    /// <summary>
    /// Статусы сущностей
    /// </summary>
    [Serializable]
    public partial class WmsStatus : BaseEntity
    {
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
    }

    /// <summary>
    /// Пользовательские перечисления
    /// </summary>
    [Serializable]
    public partial class WmsUserEnum : BaseEntity
    {
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
        public virtual String UserEnumValue { get; set; }
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
    }

    /// <summary>
    /// Справочник блокировок
    /// </summary>
    [Serializable]
    public partial class WmsProductBlocking : BaseEntity
    {
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
    }

    /// <summary>
    /// Справочник типов НДС
    /// </summary>
    [Serializable]
    public partial class WmsVATType : BaseEntity
    {
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
    }

    /// <summary>
    /// Справочник типов единиц измерения
    /// </summary>
    [Serializable]
    public partial class WmsMeasureType : BaseEntity
    {
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
    }

    /// <summary>
    /// Справочник единиц измерения
    /// </summary>
    [Serializable]
    public partial class WmsMeasure : BaseEntity
    {
        /// <summary>
        /// Код ЕИ. Международный код единицы измерения
        /// </summary>
        public virtual String MeasureCode { get; set; }
        /// <summary>
        /// Клд типа ЕИ
        /// </summary>
        public virtual WmsMeasureType MeasureType { get; set; }
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
    }

    /// <summary>
    /// Пользовательские параметры
    /// </summary>
    [Serializable]
    public partial class WmsCustomParam : BaseEntity
    {
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
    }

    /// <summary>
    /// Значения пользовательских параметров
    /// </summary>
    [Serializable]
    public partial class WmsCustomParamValue : BaseEntity
    {
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 CPVID { get; set; }
        /// <summary>
        /// Параметр
        /// </summary>
        public virtual WmsCustomParam CustomParam { get; set; }
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
    }

    /// <summary>
    /// Справочник адресов
    /// </summary>
    [Serializable]
    public partial class WmsAddressBook : BaseEntity
    {
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
    }

    /// <summary>
    /// Параметры к мандантам
    /// </summary>
    [Serializable]
    public partial class WmsCP2Mandant : BaseEntity
    {
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
        public virtual WmsCustomParam CustomParam { get; set; }
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
    }

    /// <summary>
    /// Заголовок транзита
    /// </summary>
    [Serializable]
    public partial class WmsTransit : BaseEntity
    {
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
    }

    /// <summary>
    /// Транзитные данные
    /// </summary>
    [Serializable]
    public partial class WmsTransitData : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 TransitDataID { get; set; }
        /// <summary>
        /// Заголовок
        /// </summary>
        public virtual WmsTransit Transit { get; set; }
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
    }

    /// <summary>
    /// Справочник клиентских цветов
    /// </summary>
    [Serializable]
    public partial class WmsPartnerColor : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 PartnerColorID { get; set; }
        /// <summary>
        /// Мандант
        /// </summary>
        public virtual WmsPartner Partner { get; set; }
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
    }

    /// <summary>
    /// Справочник типов системных ошибок
    /// </summary>
    [Serializable]
    public partial class SysErrorType : BaseEntity
    {
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
    }

    /// <summary>
    /// Справочник системных ошибок
    /// </summary>
    [Serializable]
    public partial class SysError : BaseEntity
    {
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
        public virtual SysErrorType ErrorType { get; set; }
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
    }

    /// <summary>
    /// Справочник статусов системных событий
    /// </summary>
    [Serializable]
    public partial class SysEventStatus : BaseEntity
    {
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
    }

    /// <summary>
    /// Справочник сообщений логов
    /// </summary>
    [Serializable]
    public partial class SysLogMessage : BaseEntity
    {
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
    }

    /// <summary>
    /// Журнал системных событий
    /// </summary>
    [Serializable]
    public partial class SysEvent : BaseEntity
    {
        /// <summary>
        /// Код системного события
        /// </summary>
        public virtual Int32 EventID { get; set; }
        /// <summary>
        /// Код статуса события
        /// </summary>
        public virtual SysEventStatus EventStatus { get; set; }
        /// <summary>
        /// Дата и время события
        /// </summary>
        public virtual DateTime EventDate { get; set; }
        /// <summary>
        /// Код ошибки
        /// </summary>
        public virtual SysError Error { get; set; }
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
    }

    /// <summary>
    /// Конфигурация физических принтеров
    /// </summary>
    [Serializable]
    public partial class EpsPrinterPhysical : BaseEntity
    {
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
    }

    /// <summary>
    /// Хранилище печатных форм и отчетов системы
    /// </summary>
    [Serializable]
    public partial class WmsReportFile : BaseEntity
    {
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
    }

    /// <summary>
    /// Конфигурация печатных форм
    /// </summary>
    [Serializable]
    public partial class EpsConfig : BaseEntity
    {
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
    }

    /// <summary>
    /// Задания для EPS
    /// </summary>
    [Serializable]
    public partial class EpsJob : BaseEntity
    {
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
    }

    /// <summary>
    /// Справочник переопределения печатных форм
    /// </summary>
    [Serializable]
    public partial class WmsReportRedefinition : BaseEntity
    {
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
    }

    /// <summary>
    /// Рассписание для EPS
    /// </summary>
    [Serializable]
    public partial class WmsSchedule : BaseEntity
    {
        /// <summary>
        /// ID строки
        /// </summary>
        public virtual Int32 ScheduleID { get; set; }
        /// <summary>
        /// Код задания
        /// </summary>
        public virtual EpsJob Job { get; set; }
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
    }

    /// <summary>
    /// Справочник логических(системных) принтеров и привязки к физическим
    /// </summary>
    [Serializable]
    public partial class EpsPrinterLogical : BaseEntity
    {
        /// <summary>
        /// Логический принтер, уникальное имя принтера в системе WMS
        /// </summary>
        public virtual String LogicalPrinter { get; set; }
        /// <summary>
        /// Полное имя физического принтера, установленного на принт-сервере.
        /// </summary>
        public virtual EpsPrinterPhysical PhysicalPrinter_r { get; set; }
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
    }

    /// <summary>
    /// Задачи для EPS
    /// </summary>
    [Serializable]
    public partial class EpsTask : BaseEntity
    {
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
    }

    /// <summary>
    /// Задачи к заданию
    /// </summary>
    [Serializable]
    public partial class EpsTask2Job : BaseEntity
    {
        /// <summary>
        /// ID записи (task2job_gen)
        /// </summary>
        public virtual Int32 Task2JobID { get; set; }
        /// <summary>
        /// Код задания
        /// </summary>
        public virtual EpsJob Job { get; set; }
        /// <summary>
        /// Код задачи
        /// </summary>
        public virtual EpsTask Task { get; set; }
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
    }

    /// <summary>
    /// Дочерние отчеты
    /// </summary>
    [Serializable]
    public partial class WmsReport2Report : BaseEntity
    {
        /// <summary>
        /// Код
        /// </summary>
        public virtual Int32 R2RID { get; set; }
        /// <summary>
        /// Отчет-пакет
        /// </summary>
        public virtual WmsReport R2RParent { get; set; }
        /// <summary>
        /// Дочерний отчет
        /// </summary>
        public virtual WmsReport Report_r { get; set; }
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
    }

    /// <summary>
    /// Справочник печатных форм 
    /// </summary>
    [Serializable]
    public partial class WmsReport : BaseEntity
    {
        /// <summary>
        /// Имя логического отчета
        /// </summary>
        public virtual String Report { get; set; }
        /// <summary>
        /// Имя файла отчета с расширением
        /// </summary>
        public virtual WmsReportFile ReportFile_r { get; set; }
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
    }

    /// <summary>
    /// Привязка отчетов к сущностям
    /// </summary>
    [Serializable]
    public partial class WmsReport2Entity : BaseEntity
    {
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 Report2EntityID { get; set; }
        /// <summary>
        /// Отчет
        /// </summary>
        public virtual WmsReport Report_r { get; set; }
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
    }

    /// <summary>
    /// Конфигурация потока печати
    /// </summary>
    [Serializable]
    public partial class EpsPrintStreamConfig : BaseEntity
    {
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
        public virtual WmsReport Report_r { get; set; }
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
        public virtual EpsPrinterLogical LogicalPrinter_r { get; set; }
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
    }

    /// <summary>
    /// Права на печать отчетов
    /// </summary>
    [Serializable]
    public partial class WmsReport2User : BaseEntity
    {
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
        public virtual WmsReport Report_r { get; set; }
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
    }

    /// <summary>
    /// Журнал заданий на печать и экспорт
    /// </summary>
    [Serializable]
    public partial class EpsOutput : BaseEntity
    {
        /// <summary>
        /// ID задания на печать (epsoutput_gen)
        /// </summary>
        public virtual Int32 OutputID { get; set; }
        /// <summary>
        /// Подкаталог хранения файла
        /// </summary>
        public virtual String ReportFileSubFolder_r { get; set; }
        /// <summary>
        /// Имя пользователя, инициировавшего печать
        /// </summary>
        public virtual String Login_r { get; set; }
        /// <summary>
        /// Имя хоста (DNS имя или IP), откуда инициирована печать (в том числе и терминальное оборудование)
        /// </summary>
        public virtual String Host_r { get; set; }
        /// <summary>
        /// Статус задания на печать
        /// </summary>
        public virtual OutputStatuses OutputStatus { get; set; }
        /// <summary>
        /// Обратная связь
        /// </summary>
        public virtual String OutputFeedback { get; set; }
        /// <summary>
        /// Время выполнения
        /// </summary>
        public virtual String OutputTime { get; set; }
        /// <summary>
        /// Обработчик отчета. Цифровой идентификатор внешней EPS-системы, связывающий ее с данным отчетом
        /// </summary>
        public virtual Int32 EpsHandler { get; set; }
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
    }

    /// <summary>
    /// Задачи для заданий на печать и экспорт
    /// </summary>
    [Serializable]
    public partial class EpsOutputTask : BaseEntity
    {
        /// <summary>
        /// ID подзадачи задания на печать(epsoutputtask_gen)
        /// </summary>
        public virtual Int32 OutputTaskID { get; set; }
        /// <summary>
        /// ID задания
        /// </summary>
        public virtual EpsOutput Output { get; set; }
        /// <summary>
        /// Код задачи
        /// </summary>
        public virtual EpsOutputTaskCodes OutputTaskCode { get; set; }
        /// <summary>
        /// Статус задачи (для необработанных  записей статус отсутствует)
        /// </summary>
        public virtual OutputStatuses OutputTaskStatus { get; set; }
        /// <summary>
        /// Последовательность выполнения
        /// </summary>
        public virtual Int32 OutputTaskOrder { get; set; }
        /// <summary>
        /// Обратная связь EPS
        /// </summary>
        public virtual String OutputTaskFeedback { get; set; }
        /// <summary>
        /// Время выполнения задачи в формате 00:00:00.0000
        /// </summary>
        public virtual String OutputTaskTime { get; set; }
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
    }

    /// <summary>
    /// Параметры для заданий на печать и экспорт
    /// </summary>
    [Serializable]
    public partial class EpsOutputParam : BaseEntity
    {
        /// <summary>
        /// ID(epsoutputparam_gen) 
        /// </summary>
        public virtual Int32 OutputParamID { get; set; }
        /// <summary>
        /// Связь с заданием на печать
        /// </summary>
        public virtual EpsOutput Output { get; set; }
        /// <summary>
        /// Связь с задачей задания на печать
        /// </summary>
        public virtual EpsOutputTask OutputTask { get; set; }
        /// <summary>
        /// Параметр
        /// </summary>
        public virtual String OutputParamCode { get; set; }
        /// <summary>
        /// Значение параметра
        /// </summary>
        public virtual String OutputParamValue { get; set; }
        /// <summary>
        /// Дополнительное значение к параметру
        /// </summary>
        public virtual String OutputParamSubValue { get; set; }
        /// <summary>
        /// Тип параметра
        /// </summary>
        public virtual EpsParamTypes OutputParamType { get; set; }
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
    }

    /// <summary>
    /// Фильт отчета
    /// </summary>
    [Serializable]
    public partial class WmsReportFilter : BaseEntity
    {
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 ReportFilterID { get; set; }
        /// <summary>
        /// Отчет
        /// </summary>
        public virtual WmsReport Report_r { get; set; }
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
        public virtual SysObjectLookup ObjectLookup { get; set; }
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
    }

    /// <summary>
    /// Стикер
    /// </summary>
    [Serializable]
    public partial class WmsLabel : BaseEntity
    {
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
        public virtual WmsReport Report_r { get; set; }
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
    }

    /// <summary>
    /// Параметры стикера
    /// </summary>
    [Serializable]
    public partial class WmsLabelParams : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 LabelParamsID { get; set; }
        /// <summary>
        /// Стикер
        /// </summary>
        public virtual WmsLabel Label { get; set; }
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
    }

    /// <summary>
    /// Применение стикера
    /// </summary>
    [Serializable]
    public partial class WmsLabelUse : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 LabelUseID { get; set; }
        /// <summary>
        /// Стикер
        /// </summary>
        public virtual WmsLabel Label { get; set; }
        /// <summary>
        /// SKU
        /// </summary>
        public virtual WmsSKU SKU { get; set; }
        /// <summary>
        /// Артикул
        /// </summary>
        public virtual WmsArt Art { get; set; }
        /// <summary>
        /// Группа артикулов
        /// </summary>
        public virtual WmsArtGroup ArtGroup { get; set; }
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
    }

    /// <summary>
    /// Значения параметров стикера
    /// </summary>
    [Serializable]
    public partial class WmsLabelParamsValue : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 LabelParamsValueID { get; set; }
        /// <summary>
        /// Применение стикера
        /// </summary>
        public virtual WmsLabelUse LabelUse { get; set; }
        /// <summary>
        /// Параметр
        /// </summary>
        public virtual WmsLabelParams LabelParams { get; set; }
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
    }

    /// <summary>
    /// Буфер данных отчетов
    /// </summary>
    [Serializable]
    public partial class WmsReportDataBuffer : BaseEntity
    {
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
    }

    /// <summary>
    /// Dashboard
    /// </summary>
    [Serializable]
    public partial class WmsDashboard : BaseEntity
    {
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
    }

    /// <summary>
    /// Права на отображение Dashboard
    /// </summary>
    [Serializable]
    public partial class WmsDashboard2User : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 Dashboard2UserID { get; set; }
        /// <summary>
        /// Dashboard
        /// </summary>
        public virtual WmsDashboard Dashboard { get; set; }
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
    }

    /// <summary>
    /// Планировщик
    /// </summary>
    [Serializable]
    public partial class SchScheduler : BaseEntity
    {
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
    }

    /// <summary>
    /// Тип задания
    /// </summary>
    [Serializable]
    public partial class SchJobType : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Guid ID { get; set; }
        /// <summary>
        /// Планировщик
        /// </summary>
        public virtual SchScheduler Scheduler { get; set; }
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
    }

    /// <summary>
    /// Параметр типа задания
    /// </summary>
    [Serializable]
    public partial class SchJobTypeParam : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Guid ID { get; set; }
        /// <summary>
        /// JobTypeId
        /// </summary>
        public virtual SchJobType JobType { get; set; }
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
    }

    /// <summary>
    /// Задание
    /// </summary>
    [Serializable]
    public partial class SchJob : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Guid ID { get; set; }
        /// <summary>
        /// Планировщик
        /// </summary>
        public virtual SchScheduler Scheduler { get; set; }
        /// <summary>
        /// Тип задания
        /// </summary>
        public virtual SchJobType JobType { get; set; }
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
    }

    /// <summary>
    /// Параметр задания
    /// </summary>
    [Serializable]
    public partial class SchJobParam : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Guid ID { get; set; }
        /// <summary>
        /// Задание
        /// </summary>
        public virtual SchJob Job { get; set; }
        /// <summary>
        /// Тип параметра задания
        /// </summary>
        public virtual SchJobTypeParam JobTypeParam { get; set; }
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
    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public partial class SchTrigger : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Guid ID { get; set; }
        /// <summary>
        /// Задача
        /// </summary>
        public virtual SchJob Job { get; set; }
        /// <summary>
        /// Планировщик
        /// </summary>
        public virtual SchScheduler Scheduler { get; set; }
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
    }

    /// <summary>
    /// Cron триггер
    /// </summary>
    [Serializable]
    public partial class SchCronTrigger : SchTrigger
    {
        /// <summary>
        /// Cron
        /// </summary>
        public virtual String CronExpression { get; set; }
        /// <summary>
        /// Действие при ошибке
        /// </summary>
        public virtual Int32? MisfireInstruction { get; set; }
    }

    /// <summary>
    /// Периодический триггер
    /// </summary>
    [Serializable]
    public partial class SchSimpleTrigger : SchTrigger
    {
        /// <summary>
        /// Повторов
        /// </summary>
        public virtual Int32 RepeatCount { get; set; }
        /// <summary>
        /// Интервал, [мс]
        /// </summary>
        public virtual Int32 RepeatIntervalInMs { get; set; }
        /// <summary>
        /// Действие при ошибке
        /// </summary>
        public virtual Int32? MisfireInstruction { get; set; }
    }

    /// <summary>
    /// Тип сообщения
    /// </summary>
    [Serializable]
    public partial class IoQueueMessageType : BaseEntity
    {
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
    }

    /// <summary>
    /// Входящая очередь
    /// </summary>
    [Serializable]
    public partial class IoQueueIn : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Guid ID { get; set; }
        /// <summary>
        /// Тип сообщения
        /// </summary>
        public virtual IoQueueMessageType QueueMessageType { get; set; }
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
        public virtual IoQueueOut QueueOut { get; set; }
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
    }

    /// <summary>
    /// Исходящая очередь
    /// </summary>
    [Serializable]
    public partial class IoQueueOut : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Guid ID { get; set; }
        /// <summary>
        /// Тип сообщения
        /// </summary>
        public virtual IoQueueMessageType QueueMessageType { get; set; }
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
        public virtual IoQueueIn QueueIn { get; set; }
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
    }

    /// <summary>
    /// Контроль исполнения
    /// </summary>
    [Serializable]
    public partial class IoLaunchControl : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Guid ID { get; set; }
        /// <summary>
        /// QueueMessageTypeId
        /// </summary>
        public virtual IoQueueMessageType QueueMessageType { get; set; }
        /// <summary>
        /// MandantId
        /// </summary>
        public virtual WmsMandant Mandant { get; set; }
        /// <summary>
        /// EventHeaderID_r
        /// </summary>
        public virtual WmsEventHeader EventHeader { get; set; }
        /// <summary>
        /// ProcessCode
        /// </summary>
        public virtual String ProcessCode { get; set; }
        /// <summary>
        /// QueueOutId
        /// </summary>
        public virtual IoQueueOut QueueOut { get; set; }
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
    }

    /// <summary>
    /// Справочник международных языков
    /// </summary>
    [Serializable]
    public partial class IsoLanguage : BaseEntity
    {
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
    }

    /// <summary>
    /// Справочник валют
    /// </summary>
    [Serializable]
    public partial class IsoCurrency : BaseEntity
    {
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
    }

    /// <summary>
    /// Справочник стран (ISO 3166-1)
    /// </summary>
    [Serializable]
    public partial class IsoCountry : BaseEntity
    {
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
    }

}
