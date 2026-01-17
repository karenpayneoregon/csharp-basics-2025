

using MenuSampleApp.Models;
using Spectre.Console;

namespace MenuSampleApp.Classes;

class MenuOperations
{
    
    public static SelectionPrompt<MenuItem> MainSelectionPrompt()
    {
        SelectionPrompt<MenuItem> menu = new()
        {
            HighlightStyle = new Style(Color.White, Color.Blue, Decoration.None)
        };

        menu.Title("[cyan]Select[/]");
        menu.AddChoices(new List<MenuItem>()
        {
            new () 
            {
                Id = 1, 
                Text = "Table count for NorthWind2024",
                Action = Operations.NorthWindTableCount 
            },
            new () 
            {
                Id = 2, 
                Text = "View categories", 
                Action = Operations.ViewCategories
            },
            new ()
            {
                Id = -1,
                Text = "Exit",
                Action = Operations.ExitApplication
            },
        });

        return menu;

    }

}