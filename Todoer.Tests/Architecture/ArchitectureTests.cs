using ArchUnitNET.Domain;
using ArchUnitNET.Loader;
using Assembly = System.Reflection.Assembly;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace Todoer.Tests.Architecture;

/// <summary>
/// ArchitectureTests defines the layers and architecture of the 
/// </summary>
public abstract class ArchitectureTests
{
    /// <summary>
    /// Reference to the API's assembly.
    /// </summary>
    protected readonly ArchUnitNET.Domain.Architecture _apiArchitecture = new ArchLoader()
        .LoadAssembly(Assembly.Load("Todoer.Api"))
        .Build();
    
    /// <summary>
    /// API Controller namespace.
    /// </summary>
    protected readonly IObjectProvider<IType> _controllerLayer =
        Types().That().ResideInNamespace("Todoer.Api.Controllers").As("Controllers");
}