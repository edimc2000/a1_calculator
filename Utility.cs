using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Calculator;

internal enum Operation
{
    Add,
    Subtract,
    Multiply,
    Divide,
    Power
}

public static class Utility
{
    // reset background and foreground console colors
    public const string ResetColor = "\e[0m";

    // set white background and red foreground
    public const string ErrorColor = "\e[48;2;255;255;255;38;2;255;0;0m";


    // light blue
    public const string BackgroundColor = "\e[48;2;26;132;184m"; 
    
    // white
    public const string ForegroundColor = "\e[37m"; 

    public static void OperationMenu()
    {
        Operation[] operations = Enum.GetValues<Operation>();
        string[] symbols = ["(+)", "(-)", "(*)", "(/)", "(^)"];

        DisplayTitle("", "top");

        for (int i = 0; i < operations.Length; i++)
        {
            string tabStops = i > 0 ? new string(' ', 14) : "   Type\t";
            string centerThis = $"{tabStops}{i + 1}   - to {operations[i]}     \t{symbols[i]}    ";
            Console.WriteLine(PrintCenteredTitle(centerThis, 29));
        }

        DisplayTitle("", "bottom");
    }


    public static string OperationChoice()
    {
        Console.Write("  Enter your choice \t: ");
        string response = Console.ReadLine() ?? "100";
        return response;
    }


    public static int ValidateInput(string input, int choiceStart, int choiceEnd)
    {
        const int errorPosition = 29;

        try
        {
            int result = Convert.ToInt32(input);
            if (result is >= 1 and  <= 5) return result;

            Console.SetCursorPosition(errorPosition, Console.CursorTop - 1);
            Console.WriteLine($"{ErrorColor} Error: Enter choice between {choiceStart} " +
                              $"and {choiceEnd}  {ResetColor}");
            return 0;
        }

        catch
        {
            Console.SetCursorPosition(errorPosition, Console.CursorTop - 1);
            Console.WriteLine(
                $"{ErrorColor} Please enter a valid choice between {choiceStart}" +
                $" and  {choiceEnd} . {ResetColor}");
            return 0;
        }
    }

    public static void DisplayTitle(string title, string cover)
    {
        string lineBoxTop = new('─', 45);
        const string cornerLeftTop = " ┌";
        const string cornerRightTop = "┐ ";
        const string cornerLeftBottom = " └";
        const string cornerRightBottom = "┘ ";

        string top = cornerLeftTop + lineBoxTop + cornerRightTop;
        string bottom = cornerLeftBottom + lineBoxTop + cornerRightBottom;



        switch (cover)
        {

            case "all":
                string middle = PrintCenteredTitle(title, 45);
                ApplyHighlighter(top);
                ApplyHighlighter(middle);
                ApplyHighlighter(bottom);
                break;

            case "botton":
                break;

            case "top":
                Console.WriteLine(top);
                break;

            default:
                Console.WriteLine(bottom);
                break;

        }


    }


    public static string PrintCenteredTitle(string title, int width)
    {
        int availableWidth = width;

        string centeredTitle = string.Format(" │{0,-" + availableWidth + "}│ ",
            title.PadLeft((availableWidth + title.Length) / 2).PadRight(availableWidth));
        return centeredTitle;
    }


    public static void ApplyHighlighter(string text)
    {
        text = BackgroundColor + ForegroundColor + text + ResetColor;
        Console.WriteLine(text);
    }

    public static bool IsDouble(string input)
    {
        double result;
        return double.TryParse(input, out result);
    }

    public static string[] CaptureInputs()
    {
        Console.Write("  Enter value for a\t:  ");
        string firstNumber = Console.ReadLine() ?? " ";
        Console.Write("  Enter value for b\t:  ");
        string secondNumber = Console.ReadLine() ?? " ";

        return [firstNumber, secondNumber];
    }


    public static void DisplayInputError(string number1, string number2)
    {
        string errorLine1 = "Error: Unable to perform operation with the given inputs: ";
        string errorLine2 = "Expected: Both inputs should be of the same type - numbers.";

        Console.WriteLine($"\n{ErrorColor} {errorLine1} `{number1}` and `{number2}`. {ResetColor}");
        Console.WriteLine($"{ErrorColor} {errorLine2} {ResetColor}");
    }


    public static void TitleAndFormula(string title, string formula)
    {
        Console.WriteLine();
        DisplayTitle("", "top");
        Console.WriteLine(PrintCenteredTitle(title, 45));
        Console.WriteLine(PrintCenteredTitle("", 45));
        Console.WriteLine(PrintCenteredTitle("", 45));
        Console.WriteLine(PrintCenteredTitle(formula, 45));
        DisplayTitle("", "bottom");
    }
}