using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.ExceptionServices;


namespace SAS.AgentRedemption.Common
{

    [global::System.Serializable]
    public class SEIPAmadeusException : Exception
    {
        private int _errorCode;

        /// <summary>
        /// Gets or sets the error code.
        /// </summary>
        /// <value>The error code.</value>
        public int ErrorCode
        {
            get { return _errorCode; }
            set { _errorCode = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SEIPAmadeusException"/> class.
        /// </summary>
        public SEIPAmadeusException()
        { }


        /// <summary>
        /// Initializes a new instance of the <see cref="SEIPAmadeusException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public SEIPAmadeusException(string message)
            : base(message)
        { }


        /// <summary>
        /// Initializes a new instance of the <see cref="SEIPAmadeusException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        public SEIPAmadeusException(string message, Exception inner) : base(message, inner) { }



        /// <summary>
        /// Initializes a new instance of the <see cref="SEIPAmadeusException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="errorCode">The error code.</param>
        public SEIPAmadeusException(string message, int errorCode, Exception inner)
            : base(message, inner)
        {
            this._errorCode = errorCode;
        }

        public SEIPAmadeusException(ExceptionDispatchInfo exceptionDispatchInfo, Exception source, int errorCode, string message)
            : base(message)
        {
            exceptionDispatchInfo = ExceptionDispatchInfo.Capture(source);
        }



    }




    [global::System.Serializable]
    public class SasCreditsException : Exception
    {
        private int _errorCode;

        /// <summary>
        /// Gets or sets the error code.
        /// </summary>
        /// <value>The error code.</value>
        public int ErrorCode
        {
            get { return _errorCode; }
            set { _errorCode = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SEIPAmadeusException"/> class.
        /// </summary>
        public SasCreditsException()
        { }


        /// <summary>
        /// Initializes a new instance of the <see cref="SEIPAmadeusException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public SasCreditsException(string message)
            : base(message)
        { }


        /// <summary>
        /// Initializes a new instance of the <see cref="SEIPAmadeusException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        public SasCreditsException(string message, System.Exception inner) : base(message, inner) { }



        /// <summary>
        /// Initializes a new instance of the <see cref="SEIPAmadeusException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="errorCode">The error code.</param>
        public SasCreditsException(string message, int errorCode)
            : base(message)
        {
            this._errorCode = errorCode;
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SEIPAmadeusException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="errorCode">The error code.</param>
        public SasCreditsException(string message, int errorCode, Exception inner)
            : base(message, inner)
        {
            this._errorCode = errorCode;
        }



        public SasCreditsException(ExceptionDispatchInfo exceptionDispatchInfo, Exception source, int errorCode, string message)
            : base(message)
        {
            exceptionDispatchInfo = ExceptionDispatchInfo.Capture(source);
        }

    }
}