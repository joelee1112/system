using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Rbac.Bindings
{
    public class LayoutAttribute : Attribute
    {
        public string name { get; set; }

        public LayoutAttribute(string name)
        {
            this.name = name;
        }

        public LayoutAttribute()
        {
        }
    }
}
