using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using PdfiumViewer;

namespace Bps.Core.Utilities.Converters
{
	public static class Convert
	{
		public static DataTable ListToDataTable<T>(List<T> items)
		{
			DataTable dataTable = new DataTable(typeof(T).Name);

			PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
			foreach (PropertyInfo prop in Props)
			{
				Type type = prop.PropertyType.GenericTypeArguments.Length > 0
					? prop.PropertyType.GenericTypeArguments[0]
					: prop.PropertyType;
				dataTable.Columns.Add(prop.Name, type);
			}

			foreach (T item in items)
			{
				var values = new object[Props.Length];
				for (int i = 0; i < Props.Length; i++)
				{
					values[i] = Props[i].GetValue(item, null);
				}
				dataTable.Rows.Add(values);
			}

			return dataTable;
		}

		public static byte[] Serialize(Object objectToSerialize)
		{
			if (objectToSerialize == null) return null;

			BinaryFormatter bf = new BinaryFormatter();
			MemoryStream ms = new MemoryStream();
			bf.Serialize(ms, objectToSerialize);
			return ms.ToArray();
		}

		public static Object Deserialize(byte[] arrBytes)
		{
			MemoryStream memStream = new MemoryStream();
			BinaryFormatter binForm = new BinaryFormatter();
			memStream.Write(arrBytes, 0, arrBytes.Length);
			memStream.Seek(0, SeekOrigin.Begin);
			return binForm.Deserialize(memStream);
		}

		public static Dictionary<string, object> ObjectToDictionary(object source)
		{
			return source.GetType()
				.GetProperties(BindingFlags.Instance | BindingFlags.Public)
				.ToDictionary(prop => prop.Name, prop => prop.GetValue(source, null));
		}

		public static List<Image> ConvertPdfToImage(string pdfFilePath)
		{
			List<Image> images = new List<Image>();

			using (var document = PdfDocument.Load(pdfFilePath))
			{
				for (int i = 0; i < document.PageCount; i++)
				{
					using (var image = document.Render(i, 600, 600, false))
					{
						images.Add(image.Clone() as Image);
					}
				}
			}

			return images;
		}
	}
}
