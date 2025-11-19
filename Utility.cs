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
        try
        {
            int result = Convert.ToInt32(input);
            if (result is >= 1 and <= 5)
                return result;

            DisplayInputError(choiceStart.ToString(),
                choiceEnd.ToString(),
                "menu");
            return 0;
        }

        catch
        {
            DisplayInputError(choiceStart.ToString(),
                choiceEnd.ToString(),
                "menu");
            return 0;
        }
    }


    public static string TryAgain()
    {
        while (true)
        {
            Write("  Try Again (Y/N)\t: ");
            string response = (ReadLine() ?? "").Trim().ToUpper();

            switch (response)
            {
                case "Y":
                case "N":
                    return response;
                default:
                    DisplayInputError("", "", "tryAgain");
                    break;
            }
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
        text = AnsiColorCodes.Background + AnsiColorCodes.Foreground + text + AnsiColorCodes.Reset;
        WriteLine(text);
    }

    public static bool IsDouble(string input)
    {
        double result;
        return double.TryParse(input, out result);
    }


    public static void DisplayInputError(string number1, string number2, string errorType)
    {
        switch (errorType)
        {
            case "menu":
            {
                WriteLine($"{AnsiColorCodes.Error} Please enter a valid choice between " +
                          $"{number1} and {number2}. {AnsiColorCodes.Reset}\n");
                break;
            }

            case "tryAgain":
            {
                WriteLine(
                    $"{AnsiColorCodes.Error} Error: Enter choice between 'Y' and 'N'  {AnsiColorCodes.Reset}\n");
                break;
            }

            case "operate":
            {
                const string errorLine1 =
                    "Error: Unable to perform operation with the given inputs: ";
                const string errorLine2 =
                    "Expected: Both inputs should be of the same type - numbers.";

                WriteLine(
                    $"\n{AnsiColorCodes.Error} {errorLine1} `{number1}` and `{number2}`. {AnsiColorCodes.Reset}");
                WriteLine($"{AnsiColorCodes.Error} {errorLine2} {AnsiColorCodes.Reset}\n");
                break;
            }

            default:
            {
                break;
            }
        }
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


    public static int MathOperation(bool isValidInput, int attemptCounter, int maxAttempt)
    {
        while (!isValidInput)
        {
            string choice = OperationChoice();
            int operation = ValidateInput(choice, 1, 5);
            attemptCounter++;

            if (operation != 0)
            {
                isValidInput = true;
                return operation;
            }

            if (attemptCounter >= maxAttempt)
            {
                isValidInput = true;
                //SetCursorPosition(29, CursorTop);
                WriteLine(
                    $"{AnsiColorCodes.Error} Maximum number of attempts has been reached. " +
                    $"{attemptCounter} / {maxAttempt} {AnsiColorCodes.Reset}");
            }
        }

        return 0;
    }
}