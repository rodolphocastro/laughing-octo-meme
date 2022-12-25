Feature: Managing Todos
Creating and managing todos is core to this sample!

    Scenario Outline: Defining a Todo item
        Given "<title>" as a title
        And "<content>" as content
        When new Todo item is created
        Then its title should read "<title>"
        And its content should read "<content>"
        And its timestamp should be less than now
        
    Examples: 
        | title        | content                    |
        | amazingNotes | lorem ipsum dolor sit amet |
        | -128391      | cowabunga                  |
        | h4s numbers  |                            |