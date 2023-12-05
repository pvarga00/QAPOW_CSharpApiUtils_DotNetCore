using System;
using System.Collections.Generic;
using System.Linq;

namespace QAPOW_DotNetCoreApiTesting.Utils
{
	public class TestDataHelper
    {
	    public static Dictionary<string, TestDataModel<T>> GetTestData<T>(string fileName, bool isJson)
	    {
		    try
		    {
			    var data = TextFileHelper.ReadAllTextFromFile(fileName);
			    if (!String.IsNullOrEmpty(data))
			    {
				    IEnumerable<TestDataModel<T>> list = isJson
					    ? SerializationHelper.DeserializeJson<T>(data)
					    : SerializationHelper.DeserializeXml<T>(data);
				    return list.ToDictionary(tc => tc.TestCaseName);
			    }
			    else
			    {
				    Console.WriteLine("Test Data is null");
			    }
		    }
		    catch (Exception e)
		    {
			    Console.WriteLine($"Exception occured getting test data {e.Message}");
		    }
		    return null;
	    }
	}
}
