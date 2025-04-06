using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json;
using System.Threading.Tasks;

namespace NOCPP
{
    public static class Utility
    {
        public static Dictionary<string, string> dict_ocppVersion { get {
                return new Dictionary<string, string>
                {
                    {"1.6", "ocpp1.6" },
                    {"2.0.1", "ocpp2.0.1" },
                };
        } }
        public static string str_DatetimeUTCNow { get { return DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ"); } }
        public static DateTimeOffset dtOffset_UTCNow { get { return DateTimeOffset.UtcNow; } }

        public static readonly JsonSerializerOptions jsonSerOptions = _CreateJsonSerializerOptions();

        private static JsonSerializerOptions _CreateJsonSerializerOptions()
        {
            var options = new JsonSerializerOptions();

            options.PropertyNamingPolicy = null; 
            options.WriteIndented = false; 

            return options;
        }

        public static string JsonSer(object callResult)
        {
            return JsonSerializer.Serialize(callResult, jsonSerOptions);
        }

        public static JsonElement CalssToJsonElement(object payload)
        {
            string str_json = JsonSerializer.Serialize(payload, jsonSerOptions);

            JsonDocument jDoc_json = JsonDocument.Parse(str_json);

            JsonElement jEle = jDoc_json.RootElement.Clone();

            return jEle;
        }
        public static string ClassToJsonArray(MessageType message)
        {
            string str_jsonArray = "";
            if (message is Call call)
            {
                str_jsonArray = JsonSerializer.Serialize(call, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = null,
                    WriteIndented = false, 
                    //DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull 
                });
            }
            else if (message is CallResult callResult)
            {
                str_jsonArray = JsonSerializer.Serialize(callResult, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = null,
                    WriteIndented = false,
                    //DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull 
                });
            }
            else if (message is CallError callError)
            {
                str_jsonArray = JsonSerializer.Serialize(callError, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = null,
                    WriteIndented = false, 
                    //DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull 
                });
            }
            else
            {
                throw new Exception("The \"message\" must be one of the types Call, CallResult or CallError");
            }

            JsonDocument jDoc_jsonArray = JsonDocument.Parse(str_jsonArray);
            JsonElement jEle_root = jDoc_jsonArray.RootElement;

            JsonArray jArr_result = new JsonArray();
            foreach (var property in jEle_root.EnumerateObject())
            {
                jArr_result.Add(property.Value);
            }
            return JsonSerializer.Serialize(jArr_result, new JsonSerializerOptions
            {
                WriteIndented = false 
            });
        }
        
    }
}
