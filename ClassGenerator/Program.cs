
using NJsonSchema;
using NJsonSchema.CodeGeneration.CSharp;

namespace ClassGenerator
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Let's generate C# class from json schemas!");
            await Generator("1.6");
            await Generator("2.0.1");
        }

        static async Task Generator(string str_version)
        {
            Console.WriteLine($"\nStart generate OCPP v{str_version} class...");
            string str_InputFolderVersion = str_version;
            string str_OutputFolderVersion = str_version.Replace(".", "");
            string str_NamespaceVersion = str_version.Replace(".", "");

            string str_basePath = AppContext.BaseDirectory;
            string str_schemaFolder = Path.Combine(str_basePath, $"schemas\\{str_InputFolderVersion}");
            string str_outputFolder = Path.Combine(str_basePath, $"class_result\\v{str_OutputFolderVersion}");

            if (!Directory.Exists(str_schemaFolder))
            {
                Console.WriteLine($"Error: Folder not found {str_schemaFolder}");
                return;
            }
            if (!Directory.Exists(str_outputFolder))
            {
                Directory.CreateDirectory(str_outputFolder);
            }

            string[] strArr_jsonFiles = Directory.GetFiles(str_schemaFolder, "*.json");
            if (strArr_jsonFiles.Length == 0)
            {
                throw new Exception("No JSON Schema files were found!");
            }
            #region Read one file then process once
            foreach (string str_jsonFile in strArr_jsonFiles)
            {
                string str_fileName = Path.GetFileNameWithoutExtension(str_jsonFile);

                string str_fileNameFinal = "";
                str_fileNameFinal = str_fileName;
                if ((!str_fileName.Contains("Request")) && (!str_fileName.Contains("Response"))) { str_fileNameFinal = $"{str_fileName}Request"; }
                string str_outputPath = Path.Combine(str_outputFolder, $"{str_fileNameFinal}.cs");

                try
                {
                    string schemaJson = await File.ReadAllTextAsync(str_jsonFile);
                    var schema = await JsonSchema.FromJsonAsync(schemaJson);
                    var settings = new CSharpGeneratorSettings { };
                    switch (str_InputFolderVersion)
                    {
                        case "1.6":
                            settings = new CSharpGeneratorSettings
                            {
                                Namespace = $"NOCPP.Schemas.v{str_NamespaceVersion}",
                                JsonLibrary = CSharpJsonLibrary.SystemTextJson,
                                ClassStyle = CSharpClassStyle.Poco, 
                                GenerateJsonMethods = false, 
                                GenerateNullableReferenceTypes = true,  
                                GenerateDataAnnotations = true, 
                                TypeNameGenerator = new CustomTypeNameGenerator_v16(),
                            };
                            break;
                        case "2.0.1":
                            settings = new CSharpGeneratorSettings
                            {
                                Namespace = $"NOCPP.Schemas.v{str_NamespaceVersion}",
                                JsonLibrary = CSharpJsonLibrary.SystemTextJson,
                                ClassStyle = CSharpClassStyle.Poco, 
                                GenerateJsonMethods = false, 
                                GenerateNullableReferenceTypes = true, 
                                GenerateDataAnnotations = true, 
                                TypeNameGenerator = new CustomTypeNameGenerator_v201(),
                            };
                            break;
                        default:
                            break;
                    }

                    var generator = new CSharpGenerator(schema, settings);

                    string generatedCode = generator.GenerateFile();
                    string str_finalCode = "";
                    string[] strArr_lines = generatedCode.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
                    str_finalCode = string.Join(Environment.NewLine, strArr_lines); 

                    string str_nullClass = "namespace NOCPP.Schemas.v16\r\n{\r\n    #pragma warning disable // Disable all warnings\r\n\r\n    \r\n}";
                    if (str_finalCode.Contains(str_nullClass))
                    {
                        strArr_lines = generatedCode.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
                        for (int i = 0; i < strArr_lines.Length; i++)
                        {
                            if (strArr_lines[i] == $"    #pragma warning disable // Disable all warnings") 
                            {
                                strArr_lines[i + 1] += $"\r\n    [System.CodeDom.Compiler.GeneratedCode(\"NJsonSchema\", \"11.0.0.0 (Newtonsoft.Json v13.0.0.0)\")]\r\n    public partial class {str_fileNameFinal} \r\n    {{\r\n\r\n\r\n    }}";
                                }
                        }
                        str_finalCode = string.Join(Environment.NewLine, strArr_lines); 
                    }

                    await File.WriteAllTextAsync(str_outputPath, str_finalCode);

                    Console.WriteLine($"Conversion successful, {str_fileNameFinal}.cs file generated");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Conversion failed：{str_fileNameFinal}.json, error：{ex.Message}");
                }
            }
            #endregion

            Console.WriteLine("End of JSON Schema Conversion.");
        }
        public class CustomTypeNameGenerator_v16 : ITypeNameGenerator
        {
            public string Generate(JsonSchema schema, string typeName, IEnumerable<string> reservedTypeNames)
            {
                string str_fullName = "";
                if (reservedTypeNames.Count() > 0)
                {
                    if (string.IsNullOrEmpty(typeName))
                    {
                        str_fullName = schema.Id?.Split('/').LastOrDefault() ?? schema.Reference?.Title
                            ?? schema.ExtensionData?["$id"].ToString().Split(':').LastOrDefault()
                            ?? "UnknownType";

                        str_fullName = typeName;
                    }

                    List<string> list_reservedTypeNames = new List<string>(reservedTypeNames);
                    if (!typeName.Contains(list_reservedTypeNames[0]))
                    { str_fullName = $"{list_reservedTypeNames[0]}_{typeName}"; }
                    else
                    { str_fullName = $"{typeName}"; }

                    return str_fullName;
                }
                else
                {
                    return $"{typeName}";
                }

            }
        }

        public class CustomTypeNameGenerator_v201 : ITypeNameGenerator
        {
            public string Generate(JsonSchema schema, string typeName, IEnumerable<string> reservedTypeNames)
            {
                string str_fullName = "";
                string str_className = "";
                JsonSchema jSchema_temp = schema.ParentSchema;
                if (schema.ParentSchema != null) { jSchema_temp = schema.ParentSchema; }
                else { jSchema_temp = schema; }
                str_className = jSchema_temp.ExtensionData?["$id"].ToString().Split(':').Last() ?? "UnknownType";
                if (reservedTypeNames.Count() > 0)
                {
                    if (string.IsNullOrEmpty(typeName))
                    {
                        List<string> list_reservedTypeNames = new List<string>(reservedTypeNames);

                        str_fullName = $"{str_className}";
                    }
                    else
                    {
                        List<string> list_reservedTypeNames = new List<string>(reservedTypeNames);
                        if ((!typeName.Contains(list_reservedTypeNames[0])))
                        { str_fullName = $"{str_className}_{typeName}"; }
                        else
                        { str_fullName = $"{typeName}"; }
                    }

                    return str_fullName;
                }
                else
                {
                    return str_className + "_" + typeName;
                }

            }
        }
    }
}
