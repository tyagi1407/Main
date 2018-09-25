using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.ExceptionServices;


namespace Common
{

    [global::System.Serializable]
    public class CustomException : Exception
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
        public CustomException()
        { }


        /// <summary>
        /// Initializes a new instance of the <see cref="CustomException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public CustomException(string message)
            : base(message)
        { }


        /// <summary>
        /// Initializes a new instance of the <see cref="CustomException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        public CustomException(string message, Exception inner) : base(message, inner) { }



        /// <summary>
        /// Initializes a new instance of the <see cref="CustomException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="errorCode">The error code.</param>
        public CustomException(string message, int errorCode, Exception inner)
            : base(message, inner)
        {
            this._errorCode = errorCode;
        }

        public CustomException(ExceptionDispatchInfo exceptionDispatchInfo, Exception source, int errorCode, string message)
            : base(message)
        {
            exceptionDispatchInfo = ExceptionDispatchInfo.Capture(source);
        }



    }




    [global::System.Serializable]
    public class SCredException : Exception
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
        /// Initializes a new instance of the <see cref="SCredException"/> class.
        /// </summary>
        public SCredException()
        { }


        /// <summary>
        /// Initializes a new instance of the <see cref="SCredException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public SCredException(string message)
            : base(message)
        { }


        /// <summary>
        /// Initializes a new instance of the <see cref="SCredException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        public SCredException(string message, System.Exception inner) : base(message, inner) { }



        /// <summary>
        /// Initializes a new instance of the <see cref="SCredException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="errorCode">The error code.</param>
        public SCredException(string message, int errorCode)
            : base(message)
        {
            this._errorCode = errorCode;
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SCredException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="errorCode">The error code.</param>
        public SCredException(string message, int errorCode, Exception inner)
            : base(message, inner)
        {
            this._errorCode = errorCode;
        }



        public SCredException(ExceptionDispatchInfo exceptionDispatchInfo, Exception source, int errorCode, string message)
            : base(message)
        {
            exceptionDispatchInfo = ExceptionDispatchInfo.Capture(source);
        }

    }
}
