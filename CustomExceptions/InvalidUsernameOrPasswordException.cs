﻿using System.Runtime.Serialization;

namespace YanislavOnlineShopBackEnd.CustomExceptions
{
    public class InvalidUsernameOrPasswordException : Exception
    {
        public InvalidUsernameOrPasswordException()
        {
        }

        public InvalidUsernameOrPasswordException(string? message) : base(message)
        {
        }

        public InvalidUsernameOrPasswordException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidUsernameOrPasswordException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
