using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tony.SimpleDB
{
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Height { get; set; }
        public float Weight { get; set; }

        public SubItem Grade { get; set; }

    }

}
