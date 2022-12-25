using FluentAssertions;
using Todoer.Api.Domain;
// ReSharper disable ClassNeverInstantiated.Global

namespace Todoer.Spec.Steps;

public class TodosContext
{
    public string CurrentTitle { get; set; } = string.Empty;
    public string CurrentContent { get; set; } = string.Empty;
    public Todo? CurrentTodo { get; set; }
    public Exception? CurrentException { get; set; }
}

[Binding]
public class TodosStepDefinitions
{
    private readonly TodosContext _context;

    public TodosStepDefinitions(TodosContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }


    [Given(@"""(.*)"" as a title")]
    public void GivenAsATitle(string title)
    {
        _context.CurrentTitle = title;
    }

    [Given(@"""(.*)"" as content")]
    public void GivenAsContent(string content)
    {
        _context.CurrentContent = content;
    }

    [When(@"new Todo item is created")]
    public void WhenNewTodoItemIsCreated()
    {
        try
        {
            _context.CurrentTodo = new Todo(_context.CurrentTitle)
            {
                Content = _context.CurrentContent
            };
        }
        catch (Exception e)
        {
            _context.CurrentException = e;
        }
    }

    [Then(@"its title should read ""(.*)""")]
    public void ThenItsTitleShouldRead(string title)
    {
        _context.CurrentTodo?.Title.Should().BeEquivalentTo(title);
    }

    [Then(@"its content should read ""(.*)""")]
    public void ThenItsContentShouldRead(string content)
    {
        _context.CurrentTodo?.Content.Should().BeEquivalentTo(content);
    }

    [Then(@"its timestamp should be less than now")]
    public void ThenItsTimestampShouldBeLessThanNow()
    {
        _context.CurrentTodo?.Timestamp.Should().BeBefore(DateTimeOffset.Now);
    }

    [Then(@"an ArgumentNullException should be thrown")]
    public void ThenAnArgumentNullExceptionShouldBeThrown()
    {
        _context.CurrentException.Should().BeOfType<ArgumentNullException>();
    }

    [Then(@"it should be null")]
    public void ThenItShouldBeNull()
    {
        _context.CurrentTodo.Should().BeNull();
    }
}