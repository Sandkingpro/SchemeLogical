using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchemeLogical
{
    public class Item
    {
        public String op { get; set; }
        public String field_string { get; set; }
        public String value_string { get; set; }
        public String field_float { get; set; }
        public float value_float { get; set; }
        public String field_varchar { get; set; }
        public String value_varchar { get; set; }
        public List<Item> operands { get; set; }
        public int level { get; set; }
        public Item() { }
        public Item(String op, List<Item> items)
        {
            this.op = op;
            this.operands = items;
        }
    }
}
