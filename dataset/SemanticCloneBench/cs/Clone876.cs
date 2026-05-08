/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:7537398
*  Stack Overflow answer #:7606637
*  And Stack Overflow answer#:27276685
*/
static void Main (string [] args) {
    var input = @"
              { ""store"": {
                    ""book"": [ 
                      { ""category"": ""reference"",
                            ""author"": ""Nigel Rees"",
                            ""title"": ""Sayings of the Century"",
                            ""price"": 8.95
                      },
                      { ""category"": ""fiction"",
                            ""author"": ""Evelyn Waugh"",
                            ""title"": ""Sword of Honour"",
                            ""price"": 12.99
                      },
                      { ""category"": ""fiction"",
                            ""author"": ""Herman Melville"",
                            ""title"": ""Moby Dick"",
                            ""isbn"": ""0-553-21311-3"",
                            ""price"": 8.99
                      },
                      { ""category"": ""fiction"",
                            ""author"": ""J. R. R. Tolkien"",
                            ""title"": ""The Lord of the Rings"",
                            ""isbn"": ""0-395-19395-8"",
                            ""price"": 22.99
                      }
                    ],
                    ""bicycle"": {
                      ""color"": ""red"",
                      ""price"": 19.95
                    }
              }
            }
        ";
    var json = JObject.Parse (input);
    var context = new JsonPathContext {ValueSystem = new JsonNetValueSystem ()};
    var values = context.SelectNodes (json, "$.store.book[*].author").Select (node = > node.Value);
    Console.WriteLine (JsonConvert.SerializeObject (values));
    Console.ReadKey ();
}

public bool HasMember (object value, string member) {
    if (value is Newtonsoft.Json.Linq.JObject) {
        foreach (Newtonsoft.Json.Linq.JProperty property in (value as Newtonsoft.Json.Linq.JObject).Properties ()) {
            if (property.Name == member)
                return true;
        }
        return false;
    }
    if (value is Newtonsoft.Json.Linq.JArray) {
        int index = ParseInt (member, - 1);
        return index >= 0 && index < (value as Newtonsoft.Json.Linq.JArray).Count;
    }
    return false;
}

