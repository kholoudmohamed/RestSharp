using System;
using System.Net;
using NUnit.Framework;
using RestSharp;
using SpecFlowRestAPITest.Utilities;
using SpecFlowRestAPITest.Objects;
using RestSharp.Serialization.Json;

namespace SpecFlowRestAPITest.Tests
{
    [TestFixture]
    public class Weather
    {
        [Test]
        public void GetWeatherInfo()
        {
            //Create client connection
            RestClient restClient = new RestClient(Data.WeatherBaseURL);

            //Create request to get data from server
            //RestRequest supports creating Request of different HTTP method types(GET, POST, PUT, PATH, DELETE, UPDATE, HEAD and OPTIONS)
            RestRequest restRequest = new RestRequest("Cairo", Method.GET);

            //Execute request and get the response
            IRestResponse restResponse = restClient.Execute(restRequest);

            //Extract output from response
            string response = restResponse.Content;

            //Extract response code from response
            int responseCode = (int)restResponse.StatusCode;
            Console.WriteLine("Response code is: "+responseCode);

            //Extract status Description from response
            string statusDescription = restResponse.StatusDescription;
            Console.WriteLine("Status Description is: " + statusDescription);

            //Extract protocol Version from response
            string protocolVersion = restResponse.ProtocolVersion.ToString();
            Console.WriteLine("protocol Version is: " + protocolVersion);

            Assert.IsTrue(response.Contains("Cairo"), "Weather info returned is not correct");
            Assert.AreEqual(200, responseCode, "Response code is "+ responseCode);
            Assert.AreEqual(HttpStatusCode.OK, restResponse.StatusCode, "Response code is " + responseCode);
            Assert.AreEqual("application/json", restResponse.ContentType, "Response content type is " + restResponse.ContentType);
        }

        // Negative test scenario
        [Test]
        public void NegativeTest()
        {
            RestClient restClient = new RestClient(Data.WeatherBaseURL);

            RestRequest restRequest = new RestRequest("blabla", Method.GET);

            IRestResponse restResponse = restClient.Execute(restRequest);

            Assert.AreEqual(HttpStatusCode.BadRequest, restResponse.StatusCode, "Response code is " + restResponse.StatusCode);

        }

        // Data driven test scenario
        [TestCase("Cairo", HttpStatusCode.OK)]
        [TestCase("Amsterdam", HttpStatusCode.OK)]
        [TestCase("blabla", HttpStatusCode.BadRequest)]
        public void StatusCodeTest(String city,HttpStatusCode expectedStatusCode)
        {
            RestClient restClient = new RestClient(Data.WeatherBaseURL);

            RestRequest restRequest = new RestRequest(city, Method.GET);

            IRestResponse restResponse = restClient.Execute(restRequest);

            Assert.AreEqual(expectedStatusCode, restResponse.StatusCode, "Response code is " + restResponse.StatusCode);
        }


    }
}
