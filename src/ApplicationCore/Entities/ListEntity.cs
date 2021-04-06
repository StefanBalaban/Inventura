using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventura.ApplicationCore.Entities
{
    public class ListEntity<T>
    {
        public IReadOnlyList<T> List = new List<T>();
        public int Count;
    }
}