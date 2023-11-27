using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torti
{
    internal class Cake
    {
        internal class Characteristic
        {
            public string Name;
            public List<Kakoytort> Options;
        }
        internal class Kakoytort
        {
            public string Name;
            public int Price;

            public Kakoytort(string name, int price)
            {
                Name = name;
                Price = price;
            }
        }
    }
}

