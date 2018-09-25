using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAS.AgentRedemption.Common
{


    /// <summary>
    /// Defines the Error code and Message
    /// </summary>
    [Serializable()]
    public enum ErrorDefinition
    {
        /// <summary>
        /// No error returned
        /// </summary>
        DefaultError = 0,  // not to be used // 0 code is considered to a Success only not error

        // Authentication errors
        DEFAULT = 100,
        SOAPHEADERAUTHENTICATION_FAILED = 101,

        // Message Validation
        INVALIDSASOFFICEID = 201,
        INVALIDMESSAGETYPE = 202,
        INVALIDMESSAGEBODY = 203,

        // Internal System Error Codes
        INTERNALSYSTEMERROR = 301,


        #region bookingServiceCodes

        //Booking Service Codes 

        // A general system error code if nothing matching is found
        BookingServiceSystemError = -1301,
        // No pnr found in amadeus
        NoPNRFound = -1302,
        TimeoutFault = -1303,
        AmadeusSimultaneousWarning = -1304,
        SeipFault = -1305,
        //

        //External Provider Error Codes
        RetrievePNRProviderFault = -1306,
        RetrievePNRMapperError = -1307,
        PricePNRProviderFault = -1308,
        PricePNRMapperError = -1309,
        PriceCurrencyMismatchError = -1310,
        UpdatePNRProviderFault = -1311,
        UpdatePNRMapperError = -1312,
        CreditCardProviderFault = -1313,
        CreditCardMapperError = -1314,
        SASCreditServiceProviderError = -1315,
        SASCreditServiceMapperError = -1316,
        TicketingProviderFault = -1317,
        TicketingMapperError = -1318,
        TransformSEIPWSResponseError = -1319,

        // DB error Code
        ARSDatabaseFault = -1320,

        EMDDocRefundProviderFault = -1322,
        EMDDocRefundMapperError = -1323,
        EMDDocRefundProviderError = -1324,


        //SAS Credit error code        
        CmpCodeNotFound = 30,
        InvalidCMPCode = 804,
        InCorrectOrMissingCMPCode = 805,
        InvalidCarrier = 811,
        InsufficientCredits = 814



        #endregion
    }


    /// <summary>
    /// Represents an Error Entity and contains methods to manage error objects
    /// </summary>
    public static class ErrorManager
    {


        /// <summary>
        /// Create a new Error. 
        /// Use a ErrorDefinition and ErrorType to create a new instance of an error Object. We can keep Error messages in one common file.
        /// </summary>
        /// <param name="errorDefinition">Error definition from enumeration in ErrorManager class</param>
        /// <param name="errorType">Error type from enumeration in Error class</param>
        /// <returns>Error</returns>
        public static Error GetError(ErrorDefinition errorDefinition)
        {
            Error error = new Error();
            error.ErrorMessage = errorDefinition.ToString();
            error.ErrorCode = ((int)errorDefinition).ToString();
            return error;
        }

        /// <summary>
        /// Returns Error Description for Audit Logger
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static string GetAuditErrorCompleteDescription(Exception exception)
        {
            if (exception.GetType() == typeof(SEIPAmadeusException))
            {
                SEIPAmadeusException seipException = (SEIPAmadeusException)exception;
                string message = seipException.Message;
                if (seipException.ErrorCode != 0)
                {
                    message = "Error Code :" + seipException.ErrorCode.ToString() + " " + seipException.Message.ToString();
                }
                return message;
            }
            else
            {
                return exception.Message.ToString();
            }
        }

        /// <summary>
        /// Returns Error Description from Error Code
        /// </summary>
        /// <param name="Errorcode"></param>
        /// <returns></returns>
        public static string GetErrorMessage(int Errorcode)
        {
            ErrorDefinition error = (ErrorDefinition)Errorcode;
            return error.ToString();
        }
    }

    /// <summary>
    /// Represents Error object
    /// </summary>
    public class Error
    {
        public enum Type
        {
            Error = 0,
            Warning = 1
        }

        #region Private declarations

        string _errorCode;
        string _errorMessage;
        //string _errorDefinition;
        Type _errorType;

        #endregion

        #region Public properties

        public string ErrorCode
        {
            get { return _errorCode; }
            set { _errorCode = value; }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; }
        }

        //public string ErrorDefinition
        //{
        //    get { return _errorDefinition; }
        //    set { _errorDefinition = value; }
        //}

        public Type ErrorType
        {
            get { return _errorType; }
            set { _errorType = value; }
        }


        #endregion

        #region constructors

        //Default Constructor without Arguments
        public Error()
        {
        }

        /// <summary>
        /// Initializes and Loads Error Object with provided  Params
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="errorMessage"></param>
        /// <param name="errorDefinition"></param>
        /// <param name="errorType"></param>
        public Error(string errorCode, string errorMessage, Type errorType)
        {
            _errorCode = errorCode;
            _errorMessage = errorMessage;
            //_errorDefinition = errorDefinition;
            _errorType = errorType;
        }
        #endregion constructors
    }
}
