using FluentAssertions;

namespace Todoer.Spec.Steps;

public class CalculatorContext
{
    public int LeftHandSideOperator { get; set; }
    public int RightHandSideOperator { get; set; }
}

[Binding]
public sealed class CalculatorStepDefinitions
{
    // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

    private readonly ScenarioContext _scenarioContext;
    private readonly CalculatorContext _calculatorContext;

    public CalculatorStepDefinitions(ScenarioContext scenarioContext, CalculatorContext calculatorContext)
    {
        _scenarioContext = scenarioContext;
        _calculatorContext = calculatorContext ?? throw new ArgumentNullException(nameof(calculatorContext));
    }

    [Given("the first number is (.*)")]
    public void GivenTheFirstNumberIs(int number)
    {
        _calculatorContext.LeftHandSideOperator = number;
    }

    [Given("the second number is (.*)")]
    public void GivenTheSecondNumberIs(int number)
    {
        _calculatorContext.RightHandSideOperator = number;
    }

    [When("the two numbers are added")]
    public void WhenTheTwoNumbersAreAdded()
    {
        _scenarioContext["result"] = _calculatorContext.LeftHandSideOperator + _calculatorContext.RightHandSideOperator;
    }

    [Then("the result should be (.*)")]
    public void ThenTheResultShouldBe(int result)
    {
        _scenarioContext["result"].Should().BeEquivalentTo(result);
    }
}