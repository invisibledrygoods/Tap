using UnityEngine;
using System.Collections;
using Tap;
using Shouldly;

public class TapTest : TestBehaviour {
    string it;
    string passedIn;
    string ret;
    bool toUpperCalled = false;

    public override void Spec()
    {
        Scenario("uses Tap");

        Given("it is the string 'hi'")
            .When("it is tapped")
            .Then("the string 'hi' should be passed into the tap")
            .Because("tap passes the instance it is called on into the function it is given");

        Given("it is the string 'hi'")
            .When("it is tapped")
            .Then("the tap should return the string 'hi'")
            .Because("tap returns the instance it was called on");

        Given("it is the string 'hi'")
            .When("ToUpper is passed to AndAnd")
            .Then("AndAnd should return 'HI'")
            .Because("AndAnd passes the instance it is called on into the function it is given and returns the result");

        Given("it is a null string")
            .When("ToUpper is passed to AndAnd")
            .Then("ToUpper should not be called")
            .And("AndAnd should return null")
            .Because("AndAnd does not call the function if it is called on null");
    }

    public void ItIsTheString__(string str)
    {
        it = str;
    }

    public void ItIsANullString()
    {
        it = null;
    }

    public void ItIsTapped()
    {
        ret = it.Tap(_ => passedIn = _);
    }

    public void ToUpperIsPassedToAndAnd()
    {
        ret = it.AndAnd(_ => {
            toUpperCalled = true;
            return _.ToUpper();
        });
    }

    public void TheString__ShouldBePassedIntoTheTap(string expected)
    {
        passedIn.ShouldBe(expected);
    }

    public void TheTapShouldReturnTheString__(string expected)
    {
        ret.ShouldBe(expected);
    }

    public void AndAndShouldReturn__(string expected)
    {
        ret.ShouldBe(expected);
    }

    public void ToUpperShouldNotBeCalled()
    {
        toUpperCalled.ShouldBe(false);
    }

    public void AndAndShouldReturnNull()
    {
        ret.ShouldBe(null);
    }
}
