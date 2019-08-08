using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Rbac
{
    public class MenuEqualityComparer : IEqualityComparer<Menus>
    {
        public bool Equals(Menus x, Menus y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(Menus obj)
        {
            return this.GetHashCode();
        }
    }
}
