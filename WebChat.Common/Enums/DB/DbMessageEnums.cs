#region NameSpace
namespace WebChat.Common.Enums.DB;
#endregion

#region DbMessageEnums
#region DbMessageEnums Summary
/// <summary>
/// All Kind Of DB Response Message Enum
/// Developer: ALI RAZA MUSHTAQ
/// Date: 30-Jan-2024
/// alisaivi786@gmail.com
/// </summary> 
#endregion
public enum DbMessageEnums
{
    #region ... Common Messages
    [Description("None")]
    None = -1,

    [Description("Succeed")]
    Succeed = 0,

    [Description("Failed")]
    Failed = 1,

    [Description("Presistence Data Failed")]
    FailedPresistence = -2, 
    
    [Description("Canceled Operation")]
    CanceledOperation = -2,
    #endregion

    #region ... DB Operation Range 2~30

    /// <summary>
    /// Db Data Insert Message
    /// </summary>
    [Description("Data Inserted Successfully")]
    Inserted = 2,

    /// <summary>
    /// Db Data Bulk Insert Message
    /// </summary>
    [Description("Data Bulk Inserted Successfully")]
    BulkInserted = 3,

    /// <summary>
    /// Db Data Update Message
    /// </summary>
    [Description("Data Update Successfully")]
    Updated = 4,

    /// <summary>
    /// Db Data Bulk Update Message
    /// </summary>
    [Description("Data Bulk Update Successfully")]
    BulkUpdated = 5,

    /// <summary>
    /// Db Single Data Fetch Message
    /// </summary>
    [Description("Data Fecth Successfully")]
    Fetch = 6,

    /// <summary>
    /// Db Data All Fetch Message
    /// </summary>
    [Description("Data Fecth All Successfully")]
    FetchAll = 7,

    /// <summary>
    /// Db Data Delete Message
    /// </summary>
    [Description("Data Deleted Successfully")]
    Deleted = 8,

    /// <summary>
    /// Db Data Bulk Delete Message
    /// </summary>
    [Description("Data Bulk Deleted Successfully")]
    BulkDeleted = 9,

    /// <summary>
    /// Db Entity Not Found Message
    /// </summary>
    [Description("Entity Not Found!")]
    EntityNotFound = 10,

    #endregion
}

#endregion