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

    // set white background and red foreground
    public const string ResultColor = "\e[48;2;255;255;255;38;2;0;128;0m";

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
            WriteLine(PrintCenteredTitle(centerThis, 29));
        }

        DisplayTitle("", "bottom");
    }


    public static string OperationChoice()
    {
        Write("  Enter your choice \t: ");
        string response = ReadLine() ?? "100";
        return response;
    }


    public static int ValidateInput(string input, int choiceStart, int choiceEnd)
    {
        const int errorPosition = 29;

        try
        {
            int result = Convert.ToInt32(input);
            if (result is >= 1 and <= 5)
                return result;

            //SetCursorPosition(errorPosition, CursorTop);
            WriteLine($"{ErrorColor} Error: fffEnter choice between {choiceStart} " +
                      $"and {choiceEnd}  {ResetColor}");
            return 0;
        }

        catch
        {
            //SetCursorPosition(errorPosition, CursorTop);
            WriteLine($"{ErrorColor} Please e'''nter a valid choice between " +
                      $"{choiceStart} and {choiceEnd}. {ResetColor}");
            return 0;
        }
    }


    public static string TryAgain()
    {
        bool isLooping = true;
        string response = "";
        while (isLooping)
        {
            Write("  Try Again (Y/N)\t: ");
            response = (ReadLine() ?? "100").ToUpper();
            if (ValidateInput(response) == "false")
            {
            }
            else
            {
                WriteLine("****" + isLooping);

                WriteLine("****" + response);
                isLooping = false;
                WriteLine("****" + isLooping);
                break;
            }
        }


        return response;
    }


    // overload 
    public static string ValidateInput(string input)
    {
        const int errorPosition = 29;

        WriteLine("----" + input);
        //try
        //{
        string result = input;
        if (result is "Y" or "N")
        {
            WriteLine("----" + result);
            return result;
        }

        //SetCursorPosition(errorPosition, CursorTop - 1);
        WriteLine($"{ErrorColor} Error: Enter choice between 'Y' " +
                  $"and 'N'  {ResetColor}");
        return "false";
        //}

        //catch
        //{
        //    Console.SetCursorPosition(errorPosition, Console.CursorTop - 1);
        //    WriteLine($"{ErrorColor} Please enter a valid choice between " +
        //              $"'Y and 'N' . {ResetColor}");
        //    return input;
        //}
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
                WriteLine(top);
                break;

            default:
                WriteLine(bottom);
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
        WriteLine(text);
    }

    public static bool IsDouble(string input)
    {
        double result;
        return double.TryParse(input, out result);
    }

    public static string[] CaptureInputs()
    {
        Write("\n  Enter value for a\t:  ");
        string firstNumber = ReadLine() ?? " ";
        Write("  Enter value for b\t:  ");
        string secondNumber = ReadLine() ?? " ";

        return [firstNumber, secondNumber];
    }


    public static void DisplayInputError(string number1, string number2)
    {
        const string errorLine1 = "Error: Unable to perform operation with the given inputs: ";
        const string errorLine2 = "Expected: Both inputs should be of the same type - numbers.";

        WriteLine($"\n{ErrorColor} {errorLine1} `{number1}` and `{number2}`. {ResetColor}");
        WriteLine($"{ErrorColor} {errorLine2} {ResetColor}");
    }


    public static void DisplayTitleAndFormula(string title, string formula)
    {
        WriteLine();
        DisplayTitle("", "top");
        WriteLine(PrintCenteredTitle(title, 45));
        WriteLine(PrintCenteredTitle("", 45));
        WriteLine(PrintCenteredTitle("", 45));
        WriteLine(PrintCenteredTitle(formula, 45));
        DisplayTitle("", "bottom");
    }

    public static string FormatNumber(double result)
    {
        if (result % 1 == 0)
            return result.ToString("0");
        else
            return result.ToString("0.0000");
    }


    public static int MathOperation(bool isLooping, int attemptCounter, int maxAttempt)
    {
        while (!isLooping)
        {
            string choice = Utility.OperationChoice();
            int operation = Utility.ValidateInput(choice, 1, 5);
            attemptCounter++;

            if (operation != 0)
            {
                isLooping = true;
                return operation;
            }

            if (attemptCounter >= maxAttempt)
            {
                isLooping = true;
                //SetCursorPosition(29, CursorTop);
                WriteLine(
                    $"{Utility.ErrorColor} Maximum number of attempts has been reached. " +
                    $"{attemptCounter} / {maxAttempt} {Utility.ResetColor}");
            }
        }

        return 0;
    }


    public static void PrintResult(string title, string sign, string num1, string num2)
    {
        double result = 0;
        const int ALIGN = -22;

        switch (sign)
        {
            case "+":
                result = double.Parse(num1) + double.Parse(num2);
                break;
            case "-":
                result = double.Parse(num1) - double.Parse(num2);
                break;
            case "*":
                result = double.Parse(num1) * double.Parse(num2);

                break;
            case "/":
                result = double.Parse(num1) / double.Parse(num2);
                break;
            case "^":
                result = Math.Pow(double.Parse(num1), double.Parse(num2));
                break;

            default:
                break;
        }


        WriteLine(string.Format(
            " {0} {1, " + ALIGN + "}: {2} {3} {4} = {5} {6}\n",
            ResultColor,
            title,
            double.Parse(num1),
            sign,
            double.Parse(num2),
            FormatNumber(result),
            ResetColor
        ));
    }
}