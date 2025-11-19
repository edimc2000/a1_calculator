namespace Calculator;

/// <summary>
/// Provides mathematical operations including addition, subtraction, multiplication,
/// division, and exponentiation with user input handling and error management.
/// </summary>
/// <remarks>
/// <para>Author: Eddie C.</para>
/// <para>Version: 1.0</para>
/// <para>Since: 2025-11-09</para>
/// </remarks>

public static class Calculate
{
    /// <summary>Performs addition of two numbers</summary>
    public static void Add()
    {
        const string title = "Addition";
        const string operatorSymbol = "+";
        const string formula = "  Formula: sum = a + b ";

        Run(title, formula, operatorSymbol);
    }

    /// <summary>Performs subtraction of two numbers</summary>
    public static void Subtract()
    {
        const string title = "Subtraction";
        const string operatorSymbol = "-";
        const string formula = "Formula: difference = a - b";

        Run(title, formula, operatorSymbol);
    }

    /// <summary>Performs multiplication of two numbers</summary>
    public static void Multiply()
    {
        const string title = "Multiplication";
        const string operatorSymbol = "*";
        const string formula = "Formula: product = a * b";


        Run(title, formula, operatorSymbol);
    }

    /// <summary>Performs division of two numbers with zero-division protection</summary>
    public static void Divide()
    {
        const string title = "Division";
        const string operatorSymbol = "/";
        const string formula = "Formula: quotient = a / b";

        Run(title, formula, operatorSymbol);
    }

    /// <summary>Performs exponentiation (a raised to the power of b)</summary>
    public static void Power()
    {
        const string title = "Exponentiation";
        const string operatorSymbol = "^";
        const string formula = "Formula: result = a ^ b";
        Run(title, formula, operatorSymbol);
    }

    /// <summary>Captures two inputs from the user via console</summary>
    /// <returns>Array containing two input values as strings</returns>
    private static string[] CaptureInputs()
    {
        Write("\n  Enter value for a\t:  ");
        string firstNumber = ReadLine() ?? " ";

        Write("  Enter value for b\t:  ");
        string secondNumber = ReadLine() ?? " ";

        return [firstNumber, secondNumber];
    }


    /// <summary>Calculates and displays the result of a mathematical operation</summary>
    /// <param name="title">The operation title</param>
    /// <param name="sign">The operator symbol (+, -, *, /, ^)</param>
    /// <param name="firstOperand">The first operand as string</param>
    /// <param name="secondOperand">The second operand as string</param>
    private static void PrintResult
        (string title, string sign, string firstOperand, string secondOperand)
    {
        double result = 0;
        const int resultLeftAlignment = -22;

        switch (sign)
        {
            case "+":
                result = double.Parse(firstOperand) + double.Parse(secondOperand);
                break;
            case "-":
                result = double.Parse(firstOperand) - double.Parse(secondOperand);
                break;
            case "*":
                result = double.Parse(firstOperand) * double.Parse(secondOperand);

                break;
            case "/":
                result = double.Parse(firstOperand) / double.Parse(secondOperand);
                break;
            case "^":
                result = Math.Pow(double.Parse(firstOperand), double.Parse(secondOperand));
                break;

            default:
                break;
        }


        WriteLine(string.Format(
            " {0} {1, " + resultLeftAlignment + "}:  {2} {3} {4} = {5} {6}\n",
            AnsiColorCodes.Result,
            title,
            double.Parse(firstOperand),
            sign,
            double.Parse(secondOperand),
            Utility.FormatNumber(result),
            AnsiColorCodes.Reset
        ));
    }

    /// <summary> Executes a mathematical operation with comprehensive error handling</summary>
    /// <param name="title">The operation title</param>
    /// <param name="formula">The mathematical formula description</param>
    /// <param name="operatorSymbol">The operator symbol</param>
    private static void Run(string title, string formula, string operatorSymbol)
    {
        Utility.DisplayTitleAndFormula(title, formula);

        string[] userInputs = CaptureInputs();

        switch (operatorSymbol)
        {
            case "/":
                try
                {
                    if (userInputs[1].Equals("0"))
                        WriteLine(
                            $" {AnsiColorCodes.Error} Error: Value for b (divisor) should not " +
                            $"be zero {AnsiColorCodes.Reset}\n");

                    else
                        PrintResult(title, operatorSymbol, userInputs[0], userInputs[1]);
                    
                }
                catch
                {
                    Utility.DisplayInputError(userInputs[0], userInputs[1], "operate");
                }

                break;

            default:
                try
                {
                    PrintResult(title, operatorSymbol, userInputs[0], userInputs[1]);
                }
                catch
                {
                    Utility.DisplayInputError(userInputs[0], userInputs[1], "operate");
                }

                break;
        }
    }
}