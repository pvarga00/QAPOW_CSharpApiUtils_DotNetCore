using System;
using RockLib.Serialization;
using System.Collections.Generic;

namespace QAPOW_DotNetCoreApiTesting.Utils
{
	public class SerializationHelper
	{
		public static string SerializeXml<T>(IEnumerable<TestDataModel<T>> models)
		{
			if (models != null)
			{
				try
				{
					return new XmlTestDataModel<T>
					{
						Models = new List<TestDataModel<T>>(models)
					}.ToXml();
				}
				catch (Exception ex)
				{
					Console.WriteLine($"Exception occured while serializing xml: {ex.Message}");
					return null;
				}
			}
			return null;
		}

		public static IEnumerable<TestDataModel<T>> DeserializeXml<T>(string xml)
		{
			if (xml != null)
			{
				try
				{
					return xml.FromXml<XmlTestDataModel<T>>().Models;
				}
				catch (Exception ex)
				{
					Console.WriteLine($"Exception occured while deserializing xml: {ex.Message}");
					return null;
				}
			}
			return null;
		}

		public static string SerializeJson<T>(IEnumerable<TestDataModel<T>> models)
		{
			if (models != null)
			{
				try
				{
					return models.ToJson();
				}
				catch (Exception ex)
				{
					Console.WriteLine($"Exception occured while serializing Json: {ex.Message}");
					return null;
				}
			}
			return null;
		}

		public static IEnumerable<TestDataModel<T>> DeserializeJson<T>(string json)
		{
			if (json != null)
			{
				try
				{
					return json.FromJson<List<TestDataModel<T>>>();
				}
				catch (Exception ex)
				{
					Console.WriteLine($"Exception occured while deserializing Json: {ex.Message}");
					return null;
				}
			}
			return null;
			//	return JsonConvert.DeserializeObject<List<TestDataModel<T>>>(json); 
		}
	}
}
