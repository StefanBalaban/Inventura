using System;

namespace Inventura.ApplicationCore.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string name) : base($"Entity {name} not found")
        {
        }
    }
}