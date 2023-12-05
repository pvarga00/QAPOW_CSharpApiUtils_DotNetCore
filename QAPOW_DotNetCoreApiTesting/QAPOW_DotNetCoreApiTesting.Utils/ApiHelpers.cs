using Newtonsoft.Json;
using RockLib.Serialization;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QAPOW_DotNetCoreApiTesting.Utils
{
	public class ApiHelper
	{
		public static async Task<HttpResponseMessage> PostJsonApiRequest(string url, string content, List<KeyValuePair<string, string>> headers = null, int maxRetryCounts = 3, int retryTimeIntervalInSeconds = 1)
		{
			int initialRetryCount = 0;
			HttpResponseMessage response = null;

			if ((!String.IsNullOrEmpty(url)) && (!String.IsNullOrEmpty(content)))
			{
				try
				{
					while (initialRetryCount < maxRetryCounts)
					{
						Console.WriteLine("Post JSON call initiated");
						Console.WriteLine($"API Url: {url}");

						using (var client = new HttpClient())
						{
							if (headers != null)
							{
								foreach (var header in headers)
								{
									client.DefaultRequestHeaders.Add(header.Key, header.Value);
								}
							}

							response = await client.PostAsync(
								url,
								new StringContent(content, Encoding.UTF8, "application/json"));

							if (response != null)
							{
								if (response.StatusCode == HttpStatusCode.OK ||
									response.StatusCode == HttpStatusCode.Accepted ||
									response.StatusCode == HttpStatusCode.Created ||
									response.StatusCode == HttpStatusCode.BadRequest ||
									response.StatusCode == HttpStatusCode.Unauthorized ||
									response.StatusCode == HttpStatusCode.Forbidden)
								{
									break;
								}
							}

							initialRetryCount++;
							Thread.Sleep(TimeSpan.FromSeconds(retryTimeIntervalInSeconds));
						}
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine($"Exception occured in Post Json call {ex.Message}");
				}
			}
			else
			{
				Console.WriteLine("Error: Url or Body Request is empty");
			}

			return response;
		}

		public static async Task<HttpResponseMessage> PostXmlApiRequest(string url, string content, List<KeyValuePair<string, string>> headers = null, int maxRetryCounts = 3, int retryTimeIntervalInSeconds = 1)
		{
			int initialRetryCount = 0;
			HttpResponseMessage response = null;

			if ((!String.IsNullOrEmpty(url)) && (!String.IsNullOrEmpty(content)))
			{
				try
				{
					while (initialRetryCount < maxRetryCounts)
					{
						Console.WriteLine("Post XML call initiated");
						Console.WriteLine($"API Url: {url}");

						using (var client = new HttpClient())
						{
							if (headers != null)
							{
								foreach (var header in headers)
								{
									client.DefaultRequestHeaders.Add(header.Key, header.Value);
								}
							}

							response = await client.PostAsync(
								url,
								new StringContent(content, Encoding.UTF8, "application/xml"));
							if (response != null)
							{
								if (response.StatusCode == HttpStatusCode.OK ||
									response.StatusCode == HttpStatusCode.Accepted ||
									response.StatusCode == HttpStatusCode.Created ||
									response.StatusCode == HttpStatusCode.BadRequest ||
									response.StatusCode == HttpStatusCode.Unauthorized ||
									response.StatusCode == HttpStatusCode.Forbidden)
								{
									break;
								}
							}

							initialRetryCount++;
							Thread.Sleep(TimeSpan.FromSeconds(retryTimeIntervalInSeconds));
						}
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine($"Exception occured in Post Xml call {ex.Message}");
				}
			}
			else
			{
				Console.WriteLine("Error: Url or Body Request is empty");
			}

			return response;
		}

		public static async Task<HttpResponseMessage> GetApiRequest(string url, List<KeyValuePair<string, string>> headers = null, int maxRetryCounts = 3, int retryTimeIntervalInSeconds = 1)
		{
			int initialRetryCount = 0;
			HttpResponseMessage response = null;

			if (!String.IsNullOrEmpty(url))
			{
				try
				{
					while (initialRetryCount < maxRetryCounts)
					{
						Console.WriteLine("Get Json call initiated");
						Console.WriteLine($"API Url: {url}");
						using (var client = new HttpClient())
						{
							if (headers != null)
							{
								foreach (var header in headers)
								{
									client.DefaultRequestHeaders.Add(header.Key, header.Value);
								}
							}

							response = await client.GetAsync(url);
							if (response != null)
							{
								if (response.StatusCode == HttpStatusCode.OK ||
									response.StatusCode == HttpStatusCode.Accepted ||
									response.StatusCode == HttpStatusCode.Created ||
									response.StatusCode == HttpStatusCode.BadRequest ||
									response.StatusCode == HttpStatusCode.Unauthorized ||
									response.StatusCode == HttpStatusCode.Forbidden)
								{
									break;
								}
							}

							initialRetryCount++;
							Thread.Sleep(TimeSpan.FromSeconds(retryTimeIntervalInSeconds));
						}
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine($"Exception occured in Get call {ex.Message}");
				}
			}
			else
			{
				Console.WriteLine("Error: Url is empty");
			}
			return response;
		}

		public static async Task<HttpResponseMessage> PutJsonApiRequest(string url, string content, List<KeyValuePair<string, string>> headers = null)
		{
			HttpResponseMessage response = null;

			if ((!String.IsNullOrEmpty(url)) && (!String.IsNullOrEmpty(content)))
			{
				try
				{
					Console.WriteLine("Put JSON call initiated");
					Console.WriteLine($"API Url: {url}");

					using (var client = new HttpClient())
					{
						if (headers != null)
						{
							foreach (var header in headers)
							{
								client.DefaultRequestHeaders.Add(header.Key, header.Value);
							}
						}

						response = await client.PutAsync(
							url,
							new StringContent(content, Encoding.UTF8, "application/json"));
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine($"Exception occured in Post Json call {ex.Message}");
				}
			}
			else
			{
				Console.WriteLine("Error: Url or Body Request is empty");
			}

			return response;
		}

		public static async Task<T> DeserializeJsonResponse<T>(HttpResponseMessage httpResponse)
		{
			T jsonResponse = default(T);

			if (httpResponse != null)
			{
				jsonResponse = JsonConvert.DeserializeObject<T>(await httpResponse.Content.ReadAsStringAsync());
			}
			else
			{
				Console.WriteLine("HttpResponse is null, JSON deserialization is unsuccessful");
			}

			return jsonResponse;
		}

		public static async Task<T> DeserializeXmlResponse<T>(HttpResponseMessage httpResponse)
			where T : class
		{
			T xmlResponse = default(T);

			if (httpResponse != null)
			{
				var response = await httpResponse.Content.ReadAsStringAsync();
				xmlResponse = response.FromXml<T>();
			}
			else
			{
				Console.WriteLine("HttpResponse is null, XML deserialization is unsuccessful");
			}

			return xmlResponse;
		}
	}
}
