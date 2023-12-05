using System.IO;
using System.Text;
using System.Xml;

namespace QAPOW_DotNetCoreApiTesting.Utils
{
	public class TextFileHelper
	{
		public static string ReadAllTextFromFile(string path)
		{
			using (StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + "\\" + path))
			{
				// Read the stream to a string, and write the string to the console.
				return sr.ReadToEnd();
			}
		}

		public static string WriteToTextFile(string fileName, string text)
		{
			if (!File.Exists(fileName))
			{
				using (StreamWriter sw = File.CreateText(fileName))
				{
					sw.WriteLine(text);
				}
			}
			return fileName;
		}

		public static string PrettifyXml(string xmlString)
		{
			var prettyXmlString = new StringBuilder();

			var xmlDoc = new XmlDocument();
			xmlDoc.LoadXml(xmlString);

			var xmlSettings = new XmlWriterSettings()
			{
				Indent = true,
				IndentChars = "    ",
				NewLineChars = "\r\n",
				NewLineHandling = NewLineHandling.Replace,
				NewLineOnAttributes = true
			};

			using (XmlWriter writer = XmlWriter.Create(prettyXmlString, xmlSettings))
			{
				xmlDoc.Save(writer);
			}

			return prettyXmlString.ToString();
		}
	}
}
