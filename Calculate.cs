namespace Calculator;

public class Calculate()
{
    public static void Add()
    {
        const string title = "Addition";
        const string operatorSign = "+";
        const string formula = "  Formula: sum = a + b ";
        Utility.DisplayTitleAndFormula(title, formula);

        string[] inputs = CaptureInputs();


        try
        {
            PrintResult(title, operatorSign, inputs[0], inputs[1]);
        }
        catch
        {
            Utility.DisplayInputError(inputs[0], inputs[1], "operate");
        }
    }

    public static void Subtract()
    {
        const string title = "Subtraction";
        const string operatorSign = "-";
        const string formula = "Formula: difference = a - b";
        Utility.DisplayTitleAndFormula(title, formula);

        string[] inputs = CaptureInputs();


        try
        {
            PrintResult(title, operatorSign, inputs[0], inputs[1]);
        }
        catch
        {
            Utility.DisplayInputError(inputs[0], inputs[1], "operate");
        }
    }

    public static void Multiply()
    {
        const string title = "Multiplication";
        const string operatorSign = "*";
        const string formula = "Formula: product = a * b";
        Utility.DisplayTitleAndFormula(title, formula);

        string[] inputs = CaptureInputs();


        try
        {
            PrintResult(title, operatorSign, inputs[0], inputs[1]);
        }
        catch
        {
            Utility.DisplayInputError(inputs[0], inputs[1], "operate");
        }
    }

    public static void Divide()
    {
        const string title = "Division";
        const string operatorSign = "/";
        const string formula = "Formula: quotient = a / b";
        Utility.DisplayTitleAndFormula(title, formula);

        string[] inputs = CaptureInputs();

        try
        {
            if (inputs[1].Equals("0"))
                WriteLine(
                    $" {AnsiColorCodes.Error} Error: Value for b (divisor) should not " +
                    $"be zero {AnsiColorCodes.Reset}\n");

            else
                PrintResult(title, operatorSign, inputs[0], inputs[1]);
        }
        catch
        {
            Utility.DisplayInputError(inputs[0], inputs[1], "operate");
        }
    }


    public static void Power()
    {
        const string title = "Exponentiation";
        const string operatorSign = "^";
        const string formula = "Formula: result = a ^ b";
        Utility.DisplayTitleAndFormula(title, formula);

        string[] inputs = CaptureInputs();

        try
        {
            PrintResult(title, operatorSign, inputs[0], inputs[1]);
        }
        catch
        {
            Utility.DisplayInputError(inputs[0], inputs[1], "operate");
        }
    }


    private static void PrintResult(string title, string sign, string num1, string num2)
    {
        double result = 0;
        const int LEFT_ALIGN = -22;

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
            " {0} {1, " + LEFT_ALIGN + "}: {2} {3} {4} = {5} {6}\n",
            AnsiColorCodes.Result,
            title,
            double.Parse(num1),
            sign,
            double.Parse(num2),
            Utility.FormatNumber(result),
            "",
            AnsiColorCodes.Reset
        ));
    }

    private static string[] CaptureInputs()
    {
        Write("\n  Enter value for a\t:  ");
        string firstNumber = ReadLine() ?? " ";

        Write("  Enter value for b\t:  ");
        string secondNumber = ReadLine() ?? " ";

        return [firstNumber, secondNumber];
    }
}