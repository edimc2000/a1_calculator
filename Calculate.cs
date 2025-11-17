using System;


namespace Calculator;

public class Calculate()
{
    public static void Add()
    {
        string title = "Addition";
        string formula = "  Formula: sum = a + b ";
        Utility.DisplayTitleAndFormula(title, formula);

        string[] inputs = Utility.CaptureInputs();
        string number1 = inputs[0];
        string number2 = inputs[1];

        try
        {
            WriteLine(
                $" Addition :\t{double.Parse(number1)} + {double.Parse(number2)} = " +
                $"{double.Parse(number1) + double.Parse(number2)}");
        }
        catch
        {
            Utility.DisplayInputError(number1, number2);
        }

        
    }

    public static void Subtract() 
    {
        string title = "Subtraction";
        string formula = "Formula: difference = a - b";
        Utility.DisplayTitleAndFormula(title, formula);

        string[] inputs = Utility.CaptureInputs();
        string number1 = inputs[0];
        string number2 = inputs[1];

        try
        {
            WriteLine(
                $" Subtraction :\t{double.Parse(number1)} - {double.Parse(number2)} = " +
                $"{double.Parse(number1) - double.Parse(number2)}");
        }
        catch
        {
            Utility.DisplayInputError(number1, number2);
        }
    }

    public static void Multiply()
    {
        string title = "Multiplication";
        string formula = "Formula: product = a * b";
        Utility.DisplayTitleAndFormula(title, formula);

        string[] inputs = Utility.CaptureInputs();
        string number1 = inputs[0];
        string number2 = inputs[1];

        try
        {
            WriteLine(
                $" Subtraction :\t{double.Parse(number1)} * {double.Parse(number2)} = " +
                $"{double.Parse(number1) * double.Parse(number2)}");
        }
        catch
        {
            Utility.DisplayInputError(number1, number2);
        }
    }

    public static void Divide()
    {
        string title = "Division";
        string formula = "Formula: quotient = a / b";
        Utility.DisplayTitleAndFormula(title, formula);

        string[] inputs = Utility.CaptureInputs();
        string number1 = inputs[0];
        string number2 = inputs[1];

        try
        {
            WriteLine(
                $" Subtraction :\t{double.Parse(number1)} / {double.Parse(number2)} = " +
                $"{double.Parse(number1) / double.Parse(number2)}");
        }
        catch
        {
            Utility.DisplayInputError(number1, number2);
        }
    }


    public static void Power()
    {
        string title = "Exponentiation";
        string formula = "Formula: result = a ^ b";
        Utility.DisplayTitleAndFormula(title, formula);

        string[] inputs = Utility.CaptureInputs();
        string number1 = inputs[0];
        string number2 = inputs[1];

        try
        {
            WriteLine($" Power :\t{Double.Parse(number1)} ^ {Double.Parse(number2)} = " +
                              $"{Math.Pow(Double.Parse(number1), Double.Parse(number2))}");
        }
        catch
        {
            Utility.DisplayInputError(number1, number2);
        }
    }
}