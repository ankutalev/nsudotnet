using System;

namespace BooknoteLogic.Exceptions
{
    [Serializable]
    public class BooknoteLogicException : Exception
    {
        public BooknoteLogicException()
        {
        }

        public BooknoteLogicException(string message)
            : base(message)
        {
        }

        public BooknoteLogicException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}