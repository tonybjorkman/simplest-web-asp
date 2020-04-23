using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tony.SimpleDB
{
    public class SubItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Section { get; set; }

        public ICollection<Item> Items { get; set; }
    }
}