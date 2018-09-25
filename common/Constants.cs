using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Common
{
    public static class Constants
    {
        
        public enum ResponseCode
        {
            OK = 0,
            InputDataError = 100,
            InvalidCredential = 101,          
            TechnicalFailure = 103
        }

        public enum ServiceResponse
        {
            Success = 0,
            ParallelFault = 103,
            GatewayFault =104,
            ServiceInternalError  = 909
        }


        /// <summary>
        /// Maps to a category in Enterprise Library logging configuration
        /// </summary>
        public enum Category
        {
Component1,
           Component2,
            GUI,
            Database,
            Common

        }

        public enum Severity
        {
            Critical,
            Error,
            Warning,
            Information,
            Verbose
        }

               public enum Key
        {
            [Description("Desc1")]
            A1,
            [Description("Desc2")]
            A2,
            [Description("Desc1")]
            A1,
            [Description("Desc2")]
            A2,
        }


        
        /// <summary>        
        ///This Regular expression is only loaded when required to check the form of payment in any use case for credit card- keyword CC is always followed by alphabet
        /// </summary>
        public static Lazy<Regex> regExpForCC = new Lazy<Regex>(() => new Regex("^.*CC[a-zA-Z]+.*$", RegexOptions.Compiled));

        /// <summary>
        /// This Regular expression is only loaded when check the form of payment in any use case for ACC- keyword ACC is always followed by number
        /// </summary>
        public static Lazy<Regex> regExpForACC = new Lazy<Regex>(() => new Regex("^.*ACC[0-9]+.*$", RegexOptions.Compiled));
    

    }

    /// <summary>
    /// Enum Helper Class which acts as Enum extension method
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class EnumExtensions<T>
    {
        public static string GetEnumDescription(string value  ,string addedErrorFromAmadeus = null)
        {
            Type type = typeof(T);
            var name = Enum.GetNames(type)
                           .Where(f => f.Equals(value, StringComparison.CurrentCultureIgnoreCase))
                           .Select(d => d).FirstOrDefault();
            if (name == null)
            {
                return string.Empty;
            }

            var field = type.GetField(name);
            var customAttribute = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return customAttribute.Length > 0 ? ((DescriptionAttribute)customAttribute[0]).Description 
                                                + ((addedErrorFromAmadeus != null) ? " / "+addedErrorFromAmadeus : string.Empty ): name;
        }
    }
}
