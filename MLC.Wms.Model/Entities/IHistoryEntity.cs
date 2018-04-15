using System;

namespace MLC.Wms.Model.Entities
{
    public interface IHistoryEntity
    {
        Int64 HistoryID { get; set; }
        DateTime? HDateFrom { get; set; }
        DateTime? HDateTill { get; set; }
        Guid? ArchInstGUID_r { get; set; }
    }
}