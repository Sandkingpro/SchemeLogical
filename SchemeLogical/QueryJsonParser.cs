using System.Text.Json.Nodes;
using System.Text.Json;
namespace SchemeLogical
{
    public class QueryJsonParser
    {
        
        public static string Serialize(Element element)
        {
            Item item = new Item();
            item.op = element.operandValue;
            item.operands = new();
            if (element.operands == null)
            {
                Item item1 = new Item();
                Item item2 = new Item();
                switch (element.type)
                {
                    case "field-string":
                        item1.field_string = element.key;
                        item2.value_string = element.value;
                        item.operands.Add(item1);
                        item.operands.Add(item2);
                        break;
                    case "field-float":
                        item1.field_float = element.key;
                        item2.value_float = element.value;
                        item.operands.Add(item1);
                        item.operands.Add(item2);
                        break;
                    case "field-varchar":
                        item1.field_varchar = element.key;
                        item2.value_varchar = element.value;
                        item.operands.Add(item1);
                        item.operands.Add(item2);
                        break;
                    case "field-double":
                        item1.field_double = element.key;
                        item2.value_double = element.value;
                        item.operands.Add(item1);
                        item.operands.Add(item2);
                        break;
                    case "field-datetime":
                        item1.field_datetime = element.key;
                        item2.value_datetime = element.value;
                        item.operands.Add(item1);
                        item.operands.Add(item2);
                        break;

                }
            }
            else
            {
                foreach(var elem in element.operands)
                {
                    if (elem.operands == null)
                    {
                        Serialize(elem);
                    }
                   
                }
            }
            
        
        }
        
        public static Element Deserialize(String json)
        {
            Element element = new Element();
            string json2 = json?.Replace(" ", "");
            string json3 = json2?.Replace("'", "\"");
            JsonNode jsonNode = JsonNode.Parse(json3);
            JsonNode root = jsonNode.Root;
            JsonObject keyValuePairs = root.AsObject();
            String js = "";
            foreach (var value in keyValuePairs)
            {
                if (!value.Key.Equals("operands"))
                {
                    Console.WriteLine(value.Value + ";level:0");
                }

                var k = value.Value;
                if (value.Key.Equals("op"))
                {
                    element.operandValue = value.Value.ToString();
                    element.operands = new List<Element>();
                }
                js = k.ToJsonString();

            }
            parseJson(js, jsonNode, root, element.operands);
            return element;
        }
        static void parseJson(string js, JsonNode jsonNode, JsonNode root, List<Element> elements)
        {
            string new_js = "";
            jsonNode = JsonNode.Parse(js);
            root = jsonNode.Root;
            JsonArray o = root.AsArray();
            foreach (var t in o)
            {
                Element _element = new Element();
                foreach (var m in t.AsObject())
                {

                    if (!m.Key.Equals("operands"))
                    {
                        Console.WriteLine(m.Value.ToString());
                        if (m.Key.Equals("op"))
                        {

                            _element.operandValue = m.Value.ToString();
                            if (m.Value.ToString().Equals("or") | m.Value.ToString().Equals("and") | m.Value.ToString().Equals("not"))
                            {
                                _element.operands = new();
                                elements.Add(_element);
                            }


                        }

                    }

                    else
                    {
                        new_js = m.Value.ToJsonString();
                        if (_element.operands != null)
                        {
                            parseJson(new_js, jsonNode, root, _element.operands);
                        }
                        else
                        {
                            ParseSimpleElement(new_js, jsonNode, root, _element);
                            elements.Add(_element);
                        }

                    }
                }
            }

        }
        static void ParseSimpleElement(string js, JsonNode jsonNode, JsonNode root, Element element)
        {
            string new_js = "";
            jsonNode = JsonNode.Parse(js);
            root = jsonNode.Root;
            JsonArray o = root.AsArray();
            foreach (var t in o)
            {
                foreach (var m in t.AsObject())
                {
                    if (m.Key.ToString().Contains("field"))
                    {
                        element.key = m.Value.ToString();
                        element.type = m.Key;


                    }
                    if (m.Key.Contains("value"))
                    {
                        element.value = m.Value.ToString();
                    }
                }
            }
        }
    }
}
