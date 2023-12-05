//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using QL.Highlander.Property.Tax.Messages;
//using System;
//using System.Threading.Tasks;
//using QL.Highlander.Common.WebApi;
//using QL.Highlander.Quqe.Messages;
//using RockLib.Serialization;
//using System.Collections.Generic;
//using Newtonsoft.Json;
//using QL.Highlander.Common.Web;
//using QAPOW_DotNetCoreApiTesting.Utils;

//namespace QAPOW_DotNetCoreApiTesting.Tests
//{
//    [TestClass]
//    public class SmokeTests
//    {
//		private static string _propertyTaxUrl;
//		private static string _quqeUrl;
//		private static string _odsUrl;
//		private static string _testEmptyUrl;
//		private static Dictionary<string, TestDataModel<GatherPropertyTaxCommand>> _taxSmokeTestCases;
//		private static Dictionary<string, TestDataModel<GatherQuqeCommand>> _quqeSmokeTestCases;

//		[ClassInitialize]
//		public static void TestClassInitialize(TestContext context)
//		{
//			_propertyTaxUrl = context.Properties["TaxUrl"].ToString();
//			_quqeUrl = context.Properties["QuqeUrl"].ToString();
//			_odsUrl = context.Properties["ODSUrl"].ToString();

//			_taxSmokeTestCases = TestDataHelper.GetTestData<GatherPropertyTaxCommand>("\\TestData.json", true);
//			_quqeSmokeTestCases = TestDataHelper.GetTestData<GatherQuqeCommand>("\\TestData.xml", false);
//		}

//		[TestMethod]
//		[Priority(2)]
//		public async Task PostJsonTest()
//		{
//			const string testCaseName = "PostJsonSmokeTest";
//			Console.WriteLine("Retrieving PropertyTax test data");

//			//Get Test Data
//			TestDataModel<GatherPropertyTaxCommand> testCase;
//			_taxSmokeTestCases.TryGetValue(testCaseName, out testCase);

//			Assert.IsNotNull(testCase, "TestCase is Null");
//			Console.WriteLine("Successfully retrieved PropertyTax test data");

//			//Make Http call
//			var httpResponse = await ApiHelper.PostJsonApiRequest(_propertyTaxUrl, testCase.Data.ToJson());

//			//Validate Http Response
//			Assert.IsNotNull(httpResponse, "Http Response is Null");
//			Assert.AreEqual(int.Parse(testCase.ExpectedHTTPStatusCode), (int)httpResponse.StatusCode, "Status Code returned is not expected");
//			Console.WriteLine("Status Code: " + (int)httpResponse.StatusCode + " is returned as expected");
//			Assert.AreEqual(testCase.ExpectedHTTPStatusMessage, httpResponse.ReasonPhrase, "Status Message returned is not expected");
//			Console.WriteLine("Status Message: " + httpResponse.ReasonPhrase + " is returned as expected");
			
//			// Deserialize to Response model
//			var responseData = await ApiHelper.DeserializeJsonResponse<LoanEngineResponse<PropertyTaxGatheredEvent>>(httpResponse);

			
//			//Validate Responses
//			Assert.IsNotNull(responseData, "Response Data is Null");
//			Console.WriteLine($"Correlation ID: {responseData.Data.CorrelationId}");
//		}

//		[TestMethod]
//		[Priority(1)]
//		public async Task PostXmlTest()
//		{
//			const string testCaseName = "PostXmlSmokeTest";
//			Console.WriteLine("Retrieving Quqe test data");

//			TestDataModel<GatherQuqeCommand> testCase;
//			_quqeSmokeTestCases.TryGetValue(testCaseName, out testCase);

//			Assert.IsNotNull(testCase, "TestCase is Null");
//			Console.WriteLine("Successfully retrieved Quqe test data");

//			var httpResponse = await ApiHelper.PostXmlApiRequest(_quqeUrl, testCase.Data.ToXml());

//			Assert.IsNotNull(httpResponse, "Http Response is Null");
//			Assert.AreEqual(int.Parse(testCase.ExpectedHTTPStatusCode), (int)httpResponse.StatusCode, "Status Code returned is not expected");
//			Console.WriteLine("Status Code: " + (int)httpResponse.StatusCode + " is returned as expected");

//			Assert.AreEqual(testCase.ExpectedHTTPStatusMessage, httpResponse.ReasonPhrase, "Status Message returned is not expected");
//			Console.WriteLine("Status Message: " + httpResponse.ReasonPhrase + " is returned as expected");

//			var responseData =
//				await ApiHelper.DeserializeXmlResponse<LoanEngineResponse<QuqeGatheredEvent>>(httpResponse);

//			Assert.IsNotNull(responseData, "Response Data is Null");
//			Console.WriteLine($"Correlation ID: {responseData.Data.CorrelationId}");
//		}

//		[TestMethod]
//		[Priority(4)]
//		public async Task GetSmokeTest()
//		{
//			var httpResponse = await ApiHelper.GetApiRequest(_odsUrl);
//			Assert.IsNotNull(httpResponse, "Http Response is Null");
//			Assert.AreEqual(int.Parse("200"), (int)httpResponse.StatusCode, "Status Code returned is not expected");
//			Console.WriteLine("Status Code: " + (int)httpResponse.StatusCode + " is returned as expected");

//			Assert.AreEqual("OK", httpResponse.ReasonPhrase, "Status Message returned is not expected");
//			Console.WriteLine("Status Message: " + httpResponse.ReasonPhrase + " is returned as expected");
//			dynamic result = JsonConvert.DeserializeObject(httpResponse.AsString());

//			Assert.IsNotNull(result, "Response Data is Null");
//			Console.WriteLine($"Message Code: {result.Code}");
//		}

//		[TestMethod]
//		[Priority(5)]
//		public async Task ValidateEmptyUrl()
//		{
//			_testEmptyUrl = null;
//			const string testCaseName = "PostJsonSmokeTest";
//			Console.WriteLine("Retrieving PropertyTax test data");

//			TestDataModel<GatherPropertyTaxCommand> testCase;
//			_taxSmokeTestCases.TryGetValue(testCaseName, out testCase);

//			Assert.IsNotNull(testCase, "TestCase is Null");
//			Console.WriteLine("Successfully retrieved PropertyTax test data");

//			var testJsonHttpResponse = await ApiHelper.PostJsonApiRequest(_testEmptyUrl, testCase.Data.ToJson());
//			Assert.IsNull(testJsonHttpResponse, "Test Failed on validating empty url on Post Json Utility");

//			var testXmlHttpResponse = await ApiHelper.PostXmlApiRequest(_testEmptyUrl, testCase.Data.ToXml());
//			Assert.IsNull(testXmlHttpResponse, "Test Failed on validating empty url on Post Xml Utility");

//			var testGetHttpResponse = await ApiHelper.GetApiRequest(_testEmptyUrl);
//			Assert.IsNull(testGetHttpResponse, "Test Failed on validating empty url on Get Api Utility");
//		}
//	}
//}
