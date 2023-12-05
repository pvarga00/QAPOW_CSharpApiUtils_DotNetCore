using System.Collections.Generic;
using System.Xml.Serialization;

namespace QAPOW_DotNetCoreApiTesting.Utils
{
	[XmlRoot("XmlTestDataModel")]
	public class XmlTestDataModel<T>
	{
		[XmlElement("TestDataModel")]
		public List<TestDataModel<T>> Models { get; set; }
	}
}
