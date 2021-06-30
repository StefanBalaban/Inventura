using System;

namespace Inventura.ApplicationCore.Exceptions
{
    internal class DuplicateContactInfoException : Exception
    {
        public DuplicateContactInfoException() : base("User cannot have duplicate contact information")
        {
        }
    }
}