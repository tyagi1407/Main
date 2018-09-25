using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SAS.AgentRedemption.Common
{
    public static class Constants
    {
        /// <summary>
        /// Defines the various available ticketing options 
        /// TKTL AutomatedTicketing , TTP_TTM_ET Instant Ticketing with end of transaction
        /// </summary>
        public enum TicketingServiceType
        {
            TKTL,   
            TTP_ET,
            TTP_TTM_ET,
            TTM_ET
        }

        public enum Direction
        {
            ExternalOUT,
            ExternalIN,
            Internal
        }

        public enum PayloadType
        {
            TextPayload,
            XmlPayload
        }

        public enum UpdatePNRDictionaryOption
        {
            TravelAgentOfficeID,
            QueueNumber,
            QueueCategory,
            SasManualOfficeID,
            TSMReference,
            TSTReference
        }

        public enum PNRState
        {
            Inserted,
            Started,
            Validated,
            Processed,
            Credited,
            Ticketed,
            Falied
        }
        public enum PNRMessgaeType
        {
            NEWBOOKING,
            TICKETINGREJECT,
            QUEUEDTOSAS,
            TICKETINGCOMPLETE,
            REJECT,
            ERROR,
            Error
        }
        public enum ResponseCode
        {
            OK = 0,
            InputDataError = 100,
            InvalidCredential = 101,
            NotEnoughCredit = 102,
            PNRAlreadyProcessing = 103,
            TechnicalFailure = 909
        }

        public enum BookingServiceResponse
        {
            Success = 0,
            ParallelPNRFault = 103,
            SeipGatewayFault =104,
            BookingServiceInternalError  = 909
        }


        /// <summary>
        /// Maps to a category in Enterprise Library logging configuration
        /// </summary>
        public enum Category
        {
            MessageQueueService,
            MessageQueueServiceDataAccess,
            DispacherService,
            DispacherServiceDataAccess,
            BookingService,
            BookingServiceDataAccess,
            ErrorHandlerService,
            ErrorHandlerServiceDataAccess,
            GUI,
            GUIDataAccess,
            Common,
            AuditLoggerService

        }

        public enum Severity
        {
            Critical,
            Error,
            Warning,
            Information,
            Verbose
        }

        public enum Rank
        {
            Rank500 = 500,
            Rank200 = 200,
            Rank100 = 100
        }

        public enum TravelAgentMessageKey
        {
            [Description("FZREPLY SASCREDITS")]
            FZREPLYSASCREDITS,
            [Description("CREDITS")]
            FZCREDITS,
            [Description("FZSEIP")]
            FZSEIP,
            [Description("FZ1-CREDITS")]
            FZCREDITSEMD
        }


        /// <summary>
        /// Used for Adding/Deleting/updating  pnr elements using Update PNR External call
        /// </summary>
        public enum UpdatePNRSegment
        {
            OP,
            FZ,
            RM,
            RC,
            FP,
            EMDFZ,
            EMDFP
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
