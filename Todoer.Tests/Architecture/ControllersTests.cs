using ArchUnitNET.xUnit;
using Microsoft.AspNetCore.Mvc;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace Todoer.Tests.Architecture;

/// <summary>
/// ControllerTests contain test cases for API Controllers.
/// </summary>
public class ControllersTests : ArchitectureTests
{
    [Fact]
    public void ClassesInControllerLayerShouldEndWithController()
    {
        // Assert
        Classes().That().Are(_controllerLayer)
            .Should()
            .HaveNameEndingWith("Controller")
            .Check(_apiArchitecture);
    }

    [Fact]
    public void ControllersShouldBeAnnotatedWithApiControllerAndRoutes()
    {
        Classes().That().Are(_controllerLayer)
            .Should().HaveAnyAttributesThat().Are(typeof(RouteAttribute))
            .AndShould().HaveAnyAttributesThat().Are(typeof(ApiControllerAttribute))
            .Check(_apiArchitecture);
    }
}