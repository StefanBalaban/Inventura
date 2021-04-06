using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventura.ApplicationCore.Exceptions
{
    internal class DuplicateContactInfoException : Exception
    {
        public DuplicateContactInfoException() : base("User cannot have duplicate contact information")
        {
        }
    }
}