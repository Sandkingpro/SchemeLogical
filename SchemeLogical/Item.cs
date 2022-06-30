using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
namespace SchemeLogical
{
    public class Item
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
        public float value_float { get; set; }
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
        public Item() { }
        public Item(String op, List<Item> items)
        {
            this.op = op;
            this.operands = items;
        }
    }
}
