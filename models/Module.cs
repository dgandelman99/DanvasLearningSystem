using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Danvas.models
{
    public class Module : Item
    {
        //        public string Name { get; set; }
        //        public string Description { get; set; }

        public List<Item> Content = new List<Item>();
    }
}
