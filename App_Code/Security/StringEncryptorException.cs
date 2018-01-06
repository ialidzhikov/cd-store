namespace ECommerce.CdShop.Security
{
    using System;

    /// <summary>
    /// Summary description for StringEncryptorException
    /// </summary>
    public class StringEncryptorException : Exception
    {
        public StringEncryptorException(string message) : base(message)
        {
        }
    }
}