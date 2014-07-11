using System;
using System.Data.SqlClient;

namespace Cares.Web.ExceptionUtilities
{
    [Serializable]
    public class CommonException : ApplicationException
    {
        public CaresExceptionType oExpType;
        public string ForignKeyTable;
        public bool InsertUpdateKeyVoilation;
        public CommonException(string Message, Exception ex)
            : base(Message, ex)
        {
            InsertUpdateKeyVoilation = false;

        }
        /// <summary>
        /// Returns a freindly delete message after parsing the exception.
        /// </summary>
        /// <param name="oExp"></param>
        /// <returns></returns>
        public string GetForignKeyTableName(SqlException oExp)
        {
            string szTableName = "";
            if (oExp.Class >= 11 && oExp.Class <= 16 && oExp.Number == 547
                && !string.IsNullOrEmpty((szTableName = GetTableNameFriendly(ParseTableName(oExp.Message)))))
            {
                return szTableName;
            }
            return string.Empty;
        }
        /// <summary>
        /// Parses the message of an exception and retuns the name of the table.
        /// </summary>
        /// <param name="szExcpMsg"></param>
        /// <returns></returns>
        public static string ParseTableName(string szExcpMsg)
        {
            if (szExcpMsg.Contains("table"))
            {
                char[] delim = { '\"' };
                string[] tokens = szExcpMsg.Substring(szExcpMsg.IndexOf("table")).Split(delim);
                if (tokens.Length > 1)
                    return tokens[1];
            }
            return "";
        }
        /// <summary>
        /// Returns the friendly name of the table.
        /// </summary>
        /// <param name="szTableName"></param>
        /// <returns></returns>
        public static string GetTableNameFriendly(string szTableName)
        {
            if (!string.IsNullOrEmpty(szTableName))
            {
                if (szTableName.Substring(0, 4) == "dbo.")
                    szTableName = szTableName.Substring(4);
                else
                    return szTableName;
            }
            return szTableName;
        }

    }
    /// <summary>
    /// Cares Business Exception. Throw this exception if any business rule is voilated.
    /// </summary>
    public class CommonBusinessException : CommonException
    {
        //CaresExceptionType oExpType = CaresExceptionType.CaresBusinessExp;
        /// <summary>
        /// Initializes with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="exception">The exception that is the cause of the current exception. </param>
        public CommonBusinessException(string message, Exception exception)
            : base(message, exception)
        {
        }
    }
    /// <summary>
    /// Cares DB Exception. Throw this exception if any Exception occured during data load.
    /// </summary>
    public class CommonDbException : CommonException
    {
        /// <summary>
        /// Initializes with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="exception">The exception that is the cause of the current exception. 
        /// </param>
        public CommonDbException(string message, Exception exception)
            : base(message, exception)
        {
        }
    }
    /// <summary>
    /// Cares Business Exception. Throw this exception if any business rule is voilated.
    /// </summary>
    public class CommonDbConcurrencyException : CommonException
    {
        /// <summary>
        /// Initializes with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="exception">The exception that is the cause of the current exception. 
        /// </param>
        public CommonDbConcurrencyException(string message, Exception exception)
            : base(message, exception)
        {
        }
    }
    public class CommonDbForeignKeyException : CommonException
    {
        /// <summary>
        /// Initializes with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="exception">The exception that is the cause of the current exception. 
        /// </param>
        public CommonDbForeignKeyException(string message, Exception exception)
            : base(message, exception)
        {
        }
    }
    public enum CaresExceptionType
    {
        CaresBusinessExp,
        CaresDBConcurrencyExp,
        CaresDBForeignKeyVoilateExp,
        CaresDBExp,
        CaresUIExp
    }
}