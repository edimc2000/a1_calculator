namespace Calculator;

/**
 * Calculate.cs
 * Provides static methods for mathematical operations including addition,
 * subtraction, multiplication, division, and exponentiation with comprehensive
 * user input handling and error management.
 *
 * @author Eddie C.
 * @version 1.1
 * @since 2025-11-09
 */

public static class Calculate
{
    public static void Add()
    {
        const string title = "Addition";
        const string operatorSymbol = "+";
        const string formula = "  Formula: sum = a + b ";

        Run(title, formula, operatorSymbol);
    }

    public static void Subtract()
    {
        const string title = "Subtraction";
        const string operatorSymbol = "-";
        const string formula = "Formula: difference = a - b";

        Run(title, formula, operatorSymbol);
    }

    public static void Multiply()
    {
        const string title = "Multiplication";
        const string operatorSymbol = "*";
        const string formula = "Formula: product = a * b";


        Run(title, formula, operatorSymbol);
    }

    public static void Divide()
    {
        const string title = "Division";
        const string operatorSymbol = "/";
        const string formula = "Formula: quotient = a / b";

        Run(title, formula, operatorSymbol);
    }


    public static void Power()
    {
        const string title = "Exponentiation";
        const string operatorSymbol = "^";
        const string formula = "Formula: result = a ^ b";
        Run(title, formula, operatorSymbol);
    }


    private static string[] CaptureInputs()
    {
        Write("\n  Enter value for a\t:  ");
        string firstNumber = ReadLine() ?? " ";

        Write("  Enter value for b\t:  ");
        string secondNumber = ReadLine() ?? " ";

        return [firstNumber, secondNumber];
    }

    private static void PrintResult(string title, string sign, string firstOperand, string secondOperand)
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