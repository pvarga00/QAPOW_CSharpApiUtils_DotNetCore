namespace QAPOW_DotNetCoreApiTesting.Utils
{
	public class TestDataModel<T>
	{
		public string TestCaseName { get; set; }
		public string ApiName { get; set; }
		public string ExpectedHTTPStatusCode { get; set; }
		public string ExpectedHTTPStatusMessage { get; set; }
		public string ExpectedErrorMessage { get; set; }
		public T Data { get; set; }
	}
}
