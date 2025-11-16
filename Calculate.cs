using System;
using System.Xml.Schema;


namespace Calculator
{
    public class Calculate()
    {
        public static void Add(string number1, string number2)
        {
            try
            {
                Console.WriteLine($" Addition :\t{Double.Parse(number1)} + {Double.Parse(number2)} = {Double.Parse(number1) + Double.Parse(number2)}");
            }
            catch
            {
                Utility.DisplayInputError(number1, number2);
            }

        }
        public static void Add()
        {

            Utility.DisplayTitle("", "top");
            Console.WriteLine(Utility.PrintCenteredTitle("Addition", 45));
            Console.WriteLine(Utility.PrintCenteredTitle("", 45));
            Console.WriteLine(Utility.PrintCenteredTitle("  Formula: sum = a + b ", 45));
            Utility.DisplayTitle("", "bottom");



            string[] inputs = Utility.CaptureInputs();
            string number1 = inputs[0];
            string number2 = inputs[1];

            try
            {
                Console.WriteLine($" Addition :\t{Double.Parse(number1)} + {Double.Parse(number2)} = {Double.Parse(number1) + Double.Parse(number2)}");
            }
            catch
            {
                Utility.DisplayInputError(number1, number2);
            }

        }

        public static void Subtract(string number1, string number2)
        {
            try
            {
                Console.WriteLine($" Subtraction :\t{Double.Parse(number1)} - {Double.Parse(number2)} = {Double.Parse(number1) - Double.Parse(number2)}");
            }
            catch
            {
                Utility.DisplayInputError(number1, number2);
            }

        }

        public static void Subtract()
        {

        }
    }
}
