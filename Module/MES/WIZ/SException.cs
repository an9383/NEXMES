using System;

namespace WIZ
{
    public class SException : Exception
    {
        public string ErrorCode = string.Empty;

        public string ExceptionType = string.Empty;

        public Exception BaseException;

        public SException(string errorcode, Exception ex)
        {
            ErrorCode = errorcode;
            BaseException = ex;
        }
    }
}
