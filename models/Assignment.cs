using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Danvas.models
{
    public class Assignment: Item
    {
        //        public string Name { get; set; }
        //        public string Description { get; set; }
        public int TotalAvailablePoints { get; set; }
        public DateTime DueDate { get; set; }

        public override string ToString()
        {
            return $"{Name} ({TotalAvailablePoints} pts.): {Description}";
        }
    }
}
