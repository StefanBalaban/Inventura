using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventura.ApplicationCore.Entities
{
    public class UnitOfMeasure : BaseEntity
    {
        public string Measure { get; private set; }

        public UnitOfMeasure(int id)
        {
            Id = id;
        }
    }
}