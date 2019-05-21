using System;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using SpecFlowRestAPITest.Objects;
using SpecFlowRestAPITest.Utilities;

namespace SpecFlowRestAPITest.Tests
{
    [TestFixture]
    public class ZipCode
    {
        // Serilization test
        [Test]
        public void SerilizationTest()
        {
            //Arrange
            RestClient restClient = new RestClient(Data.ZipCodeBaseURL);
            RestRequest restRequest = new RestRequest("us/90210", Method.GET);

            //Act
            IRestResponse restResponse = restClient.Execute(restRequest);

            LocationResponse locationResponse = new JsonDeserializer().Deserialize<LocationResponse>(restResponse);

            //Assert
            Assert.AreEqual("90210", locationResponse.PostCode, "Post Code is not correct");
            Assert.AreEqual("United States", locationResponse.Country, "Country is not correct");
            Assert.AreEqual("US", locationResponse.CountryAbbreviation, "Country Abbreviation is not correct");
            Assert.AreEqual("Beverly Hills", locationResponse.Places[0].PlaceName, "Place Name is not correct");
        }
    }
}
