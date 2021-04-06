using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventura.ApplicationCore.Exceptions
{
    public class ModelStateInvalidException : Exception
    {
        public ModelStateInvalidException(string message, string name) :base($"Invalid Model State for {name}: {message}")
        {
            
        }
    }
}
