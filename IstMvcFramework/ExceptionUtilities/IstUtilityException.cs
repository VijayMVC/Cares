using System;

namespace IstMvcFramework.ExceptionUtilities
{

    public class IstUtilityException
    {
        [ThreadStatic]
        static string Message = string.Empty;
        /// <summary>
        /// handles cares exception and retrieves culture based message
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static string GetCaresExceptionMessage(CommonException ex)
        {
            try
            {
                if (ex.oExpType == CaresExceptionType.CaresDBForeignKeyVoilateExp)
                {
                    IstUtilityResourceManager rm = new IstUtilityResourceManager("TableList");
                    Message = rm.GetValueByKey(ex.ForignKeyTable);
                    return Message;
                }
                else if (ex.oExpType == CaresExceptionType.CaresDBExp && ex.InsertUpdateKeyVoilation)
                {
                    IstUtilityResourceManager rm = new IstUtilityResourceManager("InsertUpdateTableList");
                    Message = rm.GetValueByKey(ex.ForignKeyTable);
                    return Message;
                }
                else
                {
                    string[] message = ex.Message.Split('-');
                    IstUtilityResourceManager rm = new IstUtilityResourceManager(message[0]);
                    //Message = ISTUtilityResourceManager.GetConfigMessage(message[0], message[1]);
                    Message = rm.GetValueByKey(message[1]);
                    return Message;
                }
            }
            catch (Exception Ex)
            {
                return "There is some problem while performing the operation.";
            }
        }
        /// <summary>
        /// handles general exception and retrieves culture specific message
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static string getExceptionMessage(Exception ex)
        {
            try
            {
                CommonException Cex = new CommonException(ex.Message, ex);
                IstUtilityResourceManager rm = new IstUtilityResourceManager("ApplicationExceptions");
                Message = rm.GetValueByKey("GeneralException");
                return Message;
            }
            catch (Exception Ex)
            {
                return "There is some problem while performing the operation.";
            }
        }
    }
}