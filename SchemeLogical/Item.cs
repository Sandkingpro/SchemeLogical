using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
namespace SchemeLogical
{
    public class Item : ICloneable
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public String op { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("field-string")]
        public String field_string { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("value-string")]
        public String value_string { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("field-float")]
        public String field_float { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("value-float")]
        public String value_float { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("field-varchar")]
        public String field_varchar { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("value-varchar")]
        public String value_varchar { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public List<Item> operands { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public int level { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("field-double")]
        public String field_double { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("value-double")]
        public String value_double { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("field-datetime")]
        public String field_datetime { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("value-datetime")]
        public String value_datetime { get; set; }
        public Item() { }
        public Item(String op, List<Item> items)
        {
            this.op = op;
            this.operands = items;
        }

        public Item(String op, List<Item> items, int level)
        {
            this.op = op;
            this.operands = items;
            this.level = level;
        }
        public object Clone()
        {
            return MemberwiseClone();
        }
        public Item DeepCopy()
        {
            Item item = (Item)MemberwiseClone();
            List<Item> operands = item.operands;
            item.operands = new();
            foreach (var operand in operands)
            {
                item.operands.Add(operand);
            }
            return item;
        }
    }
}
