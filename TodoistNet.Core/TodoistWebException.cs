using System;
using System.Collections.Generic;

namespace TodoistNet.Core
{
    public class TodoistWebException : Exception
    {
        public readonly static IReadOnlyDictionary<int, string> ErrorCodeMessages = new Dictionary<int, string>
        {
            [400] = "The request was incorrect.",
            [401] = "Authentication is required, and has failed, or has not yet been provided.",
            [403] = "The request was valid, but for something that is forbidden.",
            [404] = "The requested resource could not be found.",
            [429] = "Too Many Requests   The user has sent too many requests in a given amount of time.",
            [500] = "Internal Server Error   The request failed due to a server error.",
            [503] = "Service Unavailable The server is currently unable to handle the request."
        };

        public int HttpErrorCode { get; set; }

        public TodoistWebException(string message) : base(message)
        {
        }

        public TodoistWebException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public static TodoistWebException GenerateFromHttpErrorCode(int errorCode, Exception originalException)
        {
            string message;

            if (ErrorCodeMessages.ContainsKey(errorCode))
            {
                message = ErrorCodeMessages[errorCode];
            }
            else
            {
                message = "Unknown error";
            }

            var exception = new TodoistWebException(message, originalException);
            exception.HttpErrorCode = errorCode;

            return exception;
        }
    }
}
