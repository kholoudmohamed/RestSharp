﻿using System;

using TechTalk.SpecFlow;

namespace SpecFlowRestAPITest
{
    [Binding]
    public class TestSteps
    {
        [Given("I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredSomethingIntoTheCalculator(int number)
        {
            // TODO: implement arrange (recondition) logic
            // For storing and retrieving scenario-specific data, 
            // the instance fields of the class or the
            //     ScenarioContext.Current
            // collection can be used.
            // To use the multiline text or the table argument of the scenario,
            // additional string/Table parameters can be defined on the step definition
            // method. 

            ScenarioContext.Current.Pending();
        }

        [When("I press add")]
        public void WhenIPressAdd()
        {
            // TODO: implement act (action) logic

            ScenarioContext.Current.Pending();
        }

        [Then("the result should be (.*) on the screen")]
        public void ThenTheResultShouldBe(int result)
        {
            // TODO: implement assert (verification) logic

            ScenarioContext.Current.Pending();
        }
    }
}
