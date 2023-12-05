//using Microsoft.Extensions.Configuration;
//using QAPOW_DotNetCoreApiTesting.Utils;
//using QL.Highlander.Common.WebApi;
//using QL.Highlander.Property.Tax.Messages;
//using RockLib.Serialization;
//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using Xunit;

//namespace QAPOW_DotNetCoreXUnitApiTesting.Tests
//{
//    public class UnitTest1
//    {
//	    private static Dictionary<string, TestDataModel<GatherPropertyTaxCommand>> _taxSmokeTestCases;
//	    public string url;

//		[Fact]
//		public async Task PostJsonTest()
//		{
//			const string testCaseName = "PostJsonSmokeTest";

//			var config = new ConfigurationBuilder()
//				.AddJsonFile("config.json")
//				.Build();
			
//			Console.WriteLine("Retrieving PropertyTax test data");
//			_taxSmokeTestCases = TestDataHelper.GetTestData<GatherPropertyTaxCommand>("\\XUnitTestData.json", true);
//			//Get Test Data
//			TestDataModel<GatherPropertyTaxCommand> testCase;
//			_taxSmokeTestCases.TryGetValue(testCaseName, out testCase);

//			Assert.NotNull(testCase);
//			Console.WriteLine("Successfully retrieved PropertyTax test data");

//			//Make Http call
//			var httpResponse = await ApiHelper.PostJsonApiRequest(config["url"], testCase.Data.ToJson());

//			//Validate Http Response
//			Assert.NotNull(httpResponse);
//			Assert.Equal(int.Parse(testCase.ExpectedHTTPStatusCode), (int)httpResponse.StatusCode);
//			Console.WriteLine("Status Code: " + (int)httpResponse.StatusCode + " is returned as expected");
//			Assert.Equal(testCase.ExpectedHTTPStatusMessage, httpResponse.ReasonPhrase);
//			Console.WriteLine("Status Message: " + httpResponse.ReasonPhrase + " is returned as expected");

//			// Deserialize to Response model
//			var responseData = await ApiHelper.DeserializeJsonResponse<LoanEngineResponse<PropertyTaxGatheredEvent>>(httpResponse);

//			//Validate Responses
//			Assert.NotNull(responseData);
//			Console.WriteLine($"Correlation ID: {responseData.Data.CorrelationId}");
//		}
//	}
//}
