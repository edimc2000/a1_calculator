namespace Calculator;

public class Calculate()
{
    public static void Add()
    {
        const string title = "Addition";
        const string operatorSign = "+";
        const string formula = "  Formula: sum = a + b ";
        Utility.DisplayTitleAndFormula(title, formula);

        string[] inputs = Utility.CaptureInputs();
        string number1 = inputs[0];
        string number2 = inputs[1];

        try
        {
            Utility.PrintResult(title, operatorSign, number1, number2);
        }
        catch
        {
            Utility.DisplayInputError(number1, number2);
        }
    }

    public static void Subtract()
    {
        const string title = "Subtraction";
        const string operatorSign = "-";
        const string formula = "Formula: difference = a - b";
        Utility.DisplayTitleAndFormula(title, formula);

        string[] inputs = Utility.CaptureInputs();
        string number1 = inputs[0];
        string number2 = inputs[1];

        try
        {
            Utility.PrintResult(title, operatorSign, number1, number2);
        }
        catch
        {
            Utility.DisplayInputError(number1, number2);
        }
    }

    public static void Multiply()
    {
        const string title = "Multiplication";
        const string operatorSign = "*";
        const string formula = "Formula: product = a * b";
        Utility.DisplayTitleAndFormula(title, formula);

        string[] inputs = Utility.CaptureInputs();
        string number1 = inputs[0];
        string number2 = inputs[1];

        try
        {
            Utility.PrintResult(title, operatorSign, number1, number2);
        }
        catch
        {
            Utility.DisplayInputError(number1, number2);
        }
    }

    public static void Divide()
    {
        const string title = "Division";
        const string operatorSign = "/";
        const string formula = "Formula: quotient = a / b";
        Utility.DisplayTitleAndFormula(title, formula);

        string[] inputs = Utility.CaptureInputs();
        string number1 = inputs[0];
        string number2 = inputs[1];

        try
        {
            if (number2.Equals("0"))
                WriteLine(
                    $" {Utility.ErrorColor} Error: Value for b (divisor) should not " +
                    $"be zero {Utility.ResetColor}\n");

            else
                Utility.PrintResult(title, operatorSign, number1, number2);
        }
        catch
        {
            Utility.DisplayInputError(number1, number2);
        }
    }


    public static void Power()
    {
        const string title = "Exponentiation";
        const string operatorSign = "^";
        const string formula = "Formula: result = a ^ b";
        Utility.DisplayTitleAndFormula(title, formula);

        string[] inputs = Utility.CaptureInputs();
        string number1 = inputs[0];
        string number2 = inputs[1];

        try
        {
            Utility.PrintResult(title, operatorSign, number1, number2);
        }
        catch
        {
            Utility.DisplayInputError(number1, number2);
        }
    }
}