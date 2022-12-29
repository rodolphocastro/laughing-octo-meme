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

    [Fact]
    public void ControllersShouldNotBeDependedOnByOtherNamespaces()
    {
        Classes().That().AreNot(_controllerLayer)
            .Should().NotDependOnAny(_controllerLayer)
            .Check(_apiArchitecture);
    }

    [Fact]
    public void ControllersConstructorsShouldOnlyUseInterfacesOrThemselves()
    {
        MethodMembers().That()
            .AreDeclaredIn(_controllerLayer)
            .And().AreConstructors()
            .And().ArePublic()
            .Should().OnlyDependOnTypesThat().Are(_controllerLayer).As("should depend only on themselves")
            .OrShould().OnlyDependOnTypesThat().Are(Interfaces()).As("should depend only on Interfaces")
            .Check(_apiArchitecture);
    }
}