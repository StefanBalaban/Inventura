using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventura.ApplicationCore.Filters
{
    class GetAttribute : Attribute
    {
        public GetAttribute(params string[] param)
        {
            
        }
    }
}
