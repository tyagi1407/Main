using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using System.Globalization;
using System.Reflection;

namespace Common
{
    public static class LoggingManager
    {

        #region EL logging

        /// <summary>
        /// Log a message of severity Error
        /// </summary>
        /// <param name="c">Category, mapped to categories in EntLib config file</param>
        /// <param name="m">Message string logged</param>
        /// <param name="p">Parameters</param>
        public static void LogError(Constants.Category c, string m, IDictionary<string, object> d = null)
        {
            if (Logger.IsLoggingEnabled())
            {
                LogEntry entry = CreateLogEntry(m, c, Constants.Severity.Error);
                PerformLogging(d, entry);
            }
        }

        /// <summary>
        /// Log a message of severity Error
        /// </summary>
        /// <param name="c">Category, mapped to categories in EntLib config file</param>
        /// <param name="m">Message string logged</param>
        /// <param name="p">Parameters</param>
        public static void LogError(Constants.Category c, Exception ex, LoggingDTO log)
        {
            if (Logger.IsLoggingEnabled())
            {
                log.StackTrace = ex.StackTrace;
                log.ErrorDescription = ex.ToString();

                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic = log.GetType()
                 .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                     .ToDictionary(prop => prop.Name, prop => prop.GetValue(log, null));

                LogEntry entry = CreateLogEntry(ex.Message, c, Constants.Severity.Error);
                PerformLogging(dic, entry);
            }
        }

        /// <summary>
        /// Return logging dto with initial values
        /// </summary>
        /// <returns></returns>
        public static LoggingDTO GetLogDTO(string ProcessName, string ProcessId)
        {
            LoggingDTO logDTO = new LoggingDTO();

            if (string.IsNullOrEmpty(logDTO.BaseTransactionID))
                logDTO.BaseTransactionID = Guid.NewGuid().ToString();

            if (string.IsNullOrEmpty(logDTO.ProcessID))
                logDTO.ProcessID = ProcessId;

            if (string.IsNullOrEmpty(logDTO.ProcessName))
                logDTO.ProcessName = ProcessName;

            logDTO.Server = System.Net.Dns.GetHostName();
            logDTO.ExecutedOn = System.Environment.MachineName;
            logDTO.UserId = System.Environment.UserName;
            logDTO.Created = DateTime.Now.ToString();

            return logDTO;
        }

        /// <summary>
        /// GetLogDTO
        /// </summary>
        /// <param name="logDTO"></param>
        /// <param name="method"></param>
        /// <param name="InText"></param>
        /// <param name="ResponseText"></param>
        /// <returns></returns>
        public static LoggingDTO GetLogDTO(LoggingDTO logDTO, MethodBase method, string RequestText = null, string ResponseText = null)
        {
            if (logDTO == null)
                logDTO = GetLogDTO("", "");

            logDTO.Method = method;
            var fullName = method.DeclaringType.FullName + "." + method.Name;
            logDTO.Source = fullName;

            if (ResponseText != null)
                logDTO.ResponseText = ResponseText;
            return logDTO;
        }

        /// <summary>
        /// Log a message of severity Information
        /// </summary>
        /// <param name="m">Message string logged</param>
        /// <param name="c">Category, mapped to categories in EntLib config file</param>
        /// <param name="p">Parameters</param>
        public static void LogInfo(Constants.Category c, string m, IDictionary<string, object> d = null)
        {
            if (Logger.IsLoggingEnabled())
            {
                LogEntry entry = CreateLogEntry(m, c, Constants.Severity.Information);
                PerformLogging(d, entry);
            }

        }


        /// <summary>
        /// Log an object into text file for Audit log
        /// </summary>
        /// <param name="m">Message string logged</param>
        /// <param name="c">Category, mapped to categories in EntLib config file</param>
        /// <param name="p">Parameters</param>
        public static void LogObjectInfo(Constants.Category c, object m, Constants.Direction direction)
        {
            if (Logger.IsLoggingEnabled())
            {
                // Create a Dictionary of extended properties
                Dictionary<string, object> exProperties = new Dictionary<string, object>();
                exProperties.Add(direction.ToString(), MessageTransform.CreateXML(m));
                LogEntry entry = CreateLogEntryWithObject(m.GetType().Name, c, Constants.Severity.Information, exProperties);
                Logger.Write(entry);
            }
        }


        /// <summary>
        /// Log a message of severity Warning
        /// </summary>
        /// <param name="m">Message string logged</param>
        /// <param name="c">Category, mapped to categories in EntLib config file</param>
        /// <param name="p">Parameters</param>
        public static void LogWarning(Constants.Category c, string m, IDictionary<string, object> d = null)
        {
            if (Logger.IsLoggingEnabled())
            {
                LogEntry entry = CreateLogEntry(m, c, Constants.Severity.Warning);
                PerformLogging(d, entry);
            }
        }

        private static void PerformLogging(IDictionary<string, object> d, LogEntry entry)
        {
            if (null != d)
            {
                // Seems like a bug in Enterprise Library: Logging does not seem to handle null values properly, they do not get logged.
                for (int i = 0; i < d.Count; i++)
                {
                    if (d.Values.ElementAt(i) == null)
                        d[d.Keys.ElementAt(i)] = "null";
                }
            }

            entry.ExtendedProperties = d;
            Logger.Write(entry);
        }

    
        private static LogEntry CreateLogEntry(string message, Constants.Category c, Constants.Severity s, IDictionary<string, object> d = null)
        {
            LogEntry logentry = new LogEntry();
            logentry.Message = message;
            logentry.Severity = MapToTraceEventType(s);
            logentry.Title = c.ToString();
            return logentry;
        }


        private static LogEntry CreateLogEntry(Exception ex, Constants.Category c, Constants.Severity s, IDictionary<string, object> d = null)
        {
            LogEntry logentry = new LogEntry();
            logentry.Message = ex.Message;
            logentry.Severity = MapToTraceEventType(s);
            logentry.Title = c.ToString();
            return logentry;
        }


        /// <summary>
        /// For Audit Log with extended properties
        /// </summary>
        /// <param name="message"></param>
        /// <param name="c"></param>
        /// <param name="s"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        private static LogEntry CreateLogEntryWithObject(string message, Constants.Category c, Constants.Severity s, IDictionary<string, object> d)
        {
            LogEntry logentry = new LogEntry();
            logentry.Message = message;
            logentry.Severity = MapToTraceEventType(s);
            logentry.Title = c.ToString();
            logentry.ExtendedProperties = d;
            return logentry;
        }

        static internal TraceEventType MapToTraceEventType(Constants.Severity s)
        {
            switch (s)
            {
                case Constants.Severity.Critical:
                    return TraceEventType.Critical;
                case Constants.Severity.Error:
                    return TraceEventType.Error;
                case Constants.Severity.Information:
                    return TraceEventType.Information;
                case Constants.Severity.Verbose:
                    return TraceEventType.Verbose;
                case Constants.Severity.Warning:
                    return TraceEventType.Warning;
                default:
                    throw new Exception("Invalid Severity");
            }
        }
        #endregion



        #region Asych Logging

        /* public delegate void AuditLog_Delegate(AuditLog loginfo);

        public static void Log(AuditLog log)
        {
            AuditLog_Delegate del = new AuditLog_Delegate(LogAuditData);
            del.BeginInvoke(log, null, null);
        }

        private static void LogAuditData(AuditLog loginfo)
        {
            var agent = new CMLogAgent();

            AuditLog auditLog = new AuditLog();
            auditLog.PNRNumber = "123456789";
            agent.SaveAuditLog(auditLog);
            System.Threading.Thread.Sleep(5000);


        }*/

        #endregion

    }

    public class LoggingDTO
    {
        public string AssemblyLocation { get; set; }
        public string BaseTransactionID { get; set; }
        public string Created { get; set; }
        public string ErrorDescription { get; set; }
        public string ErrorNumber { get; set; }
        public string EventDescription { get; set; }
        public string EventType { get; set; }
        public string ExecutedOn { get; set; }
        public MethodBase Method { get; set; }
        public string Source { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseText { get; set; }
        public string Server { get; set; }
        public string SessionID { get; set; }
        public string StackTrace { get; set; }
        public string TextFieldsXML { get; set; }
        public string ProcessID { get; set; }
        public string ProcessName { get; set; }
        public string UserId { get; set; }
        public string Version { get; set; }
    }

}
