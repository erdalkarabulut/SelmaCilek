using Microsoft.VisualBasic.FileIO;
using System.IO;
using System.Text.Json;

namespace Bps.Core.Utilities.Generators
{
	public static class JsonClassGenerator
	{
		public static void GenerateClassFromJson(string fileName, string className)
		{
			string classCode = "";
			string jsonPath = SpecialDirectories.Desktop +  "\\" + fileName;
			using (StreamReader r = new StreamReader(jsonPath))
			{
				string json = r.ReadToEnd();
				var jsonDoc = JsonDocument.Parse(json);
				classCode = GenerateCSharpClass(className, jsonDoc.RootElement);
			}

			string classPath = SpecialDirectories.Desktop + "\\" + className + ".cs";
			File.WriteAllText(classPath, classCode);
		}

		private static string GenerateCSharpClass(string className, JsonElement element)
		{
			var classBuilder = new System.Text.StringBuilder();
			classBuilder.AppendLine($"public class {className}");
			classBuilder.AppendLine("{");

			foreach (JsonProperty property in element.EnumerateObject())
			{
				string propertyName = property.Name;
				JsonValueKind propertyKind = property.Value.ValueKind;
				string csharpType = GetCSharpType(propertyKind);

				if (csharpType == "class")
				{
					string nestedClassName = propertyName[0].ToString().ToUpper() + propertyName.Substring(1);
					classBuilder.AppendLine($"    public {nestedClassName} {propertyName} {{ get; set; }}");
					string nestedClassCode = GenerateCSharpClass(nestedClassName, property.Value);
					classBuilder.AppendLine(nestedClassCode);
				}
				else
				{
					classBuilder.AppendLine($"    public {csharpType} {propertyName} {{ get; set; }}");
				}
			}

			classBuilder.AppendLine("}");
			return classBuilder.ToString();
		}

		private static string GetCSharpType(JsonValueKind kind)
		{
			switch (kind)
			{
				case JsonValueKind.String: return "string";
				case JsonValueKind.Number: return "int";
				case JsonValueKind.True: return "bool";
				case JsonValueKind.False: return "bool";
				case JsonValueKind.Object: return "class";
				case JsonValueKind.Array: return "List<object>";
				default: return "object";
			}
		}
	}
}
