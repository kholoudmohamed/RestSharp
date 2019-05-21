using System;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using SpecFlowRestAPITest.Objects;
using SpecFlowRestAPITest.Utilities;
using TechTalk.SpecFlow;

namespace SpecFlowRestAPITest.StepDefinitions
{
    [Binding]
    public class LocationsStepDef
    {
        private RestClient restClient;
        private RestRequest restRequest;
        private IRestResponse restResponse;


        [Given("I want to know the info of (.*) with (.*)")]
        public void GivenIWantToKnowTheInfoOf(string countryAbb, string zipCode)
        {
            restClient = new RestClient(Data.ZipCodeBaseURL);
            restRequest = new RestRequest("{country}/{zipcode}", Method.GET);

            restRequest.AddUrlSegment("country", countryAbb);
            restRequest.AddUrlSegment("zipcode", zipCode);
        }

        [When("I retrieve the data of that location")]
        public void WhenIretrieveTheDataOfThatLocation()
        {
            restResponse = restClient.Execute(restRequest);
        }

        [Then("Country name should be (.*)")]
        public void ThenCountryNameShouldBe(string countryName)
        {
            LocationResponse locationResponse = new JsonDeserializer().Deserialize<LocationResponse>(restResponse);
            Assert.AreEqual(countryName, locationResponse.Country, "Country is not correct");

        }

        [Then(@"Place name should be (.*)")]
        public void ThenPlaceNameShouldBe(string placeName)
        {
            LocationResponse locationResponse = new JsonDeserializer().Deserialize<LocationResponse>(restResponse);
            Assert.AreEqual(placeName, locationResponse.Places[0].PlaceName, "Place Name is not correct");
        }

        [Then(@"State should be (.*)")]
        public void ThenStateShouldBe(string state)
        {
            LocationResponse locationResponse = new JsonDeserializer().Deserialize<LocationResponse>(restResponse);
            Assert.AreEqual(state, locationResponse.Places[0].State, "State is not correct");
        }

    }
}
