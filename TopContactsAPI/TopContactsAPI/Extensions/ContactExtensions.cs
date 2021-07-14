using System;

namespace TopContactsAPI.Extensions
{
    public static class ContactExtensions
    {
        public static Guid GenerateNewId()
        {
            return Guid.NewGuid();
        }
    }
}
