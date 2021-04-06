using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventura.ApplicationCore.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string name) : base($"Entity {name} not found")
        {
        }
    }
}