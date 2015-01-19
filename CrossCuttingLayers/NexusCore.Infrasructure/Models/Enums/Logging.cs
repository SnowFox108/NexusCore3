
using NexusCore.Infrasructure.Attributes;

namespace NexusCore.Infrasructure.Models.Enums
{
    public enum TaskCategory
    {
        None = 0,
        System = 1,
        Website = 5,
        Module = 10
    }

    public enum LogLevel
    {
        Critical = 1,
        Error = 2,
        Warning = 3,
        Information = 4,
        Alert = 5,
        Notice = 6,
        Emergency = 7,
        Debug = 8
    }

    public enum LogCode
    {

        #region 1-199 System Critical Error

        [StoreInLog]
        None = 0,
        [StoreInLog(true, TaskCategory.System, LogLevel.Critical)]
        CriticalUncategoriedError = 1,
        [StoreInLog(true, TaskCategory.System, LogLevel.Critical)]
        CriticalInstallationRepeated = 2,
        [StoreInLog(true, TaskCategory.System, LogLevel.Critical)]
        CriticalCurrentUserNotLogin = 20,

        [StoreInLog(true, TaskCategory.System, LogLevel.Critical)]
        CriticalEngineDiContainerNotInitialized = 50,
        [StoreInLog(true, TaskCategory.System, LogLevel.Critical)]
        CriticalEngineCurrentUserProviderNotInitialized = 51,

        [StoreInLog(true, TaskCategory.System, LogLevel.Critical)]
        CriticalWebsiteSettingCannotReadValue = 60,
        [StoreInLog(true, TaskCategory.System, LogLevel.Critical)]
        CriticalWebsiteSettingRepeated = 61,

        #endregion

        #region 200-599 System Error

        [StoreInLog(false, TaskCategory.System, LogLevel.Error)]
        ErrorUserLoginFailed = 200,

        #endregion

        #region 600-999 System Warning

        [StoreInLog(false, TaskCategory.System, LogLevel.Warning)]
        WarningUserEmailAlreadyExist = 600,

        #endregion

        #region 400-499 System Information

        #endregion

        #region 500-599 Web page Error

        #endregion

        #region 600-699 Web page Warning

        #endregion

        #region 700-799 Web page Information

        #endregion

        #region 800-899 Module Error

        #endregion

        #region 900-999 Module Warning

        #endregion

        #region 1000-1099 Module Information

        #endregion

    }

}
