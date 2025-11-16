using System;


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
                //Console.WriteLine(Utility.IsDouble(number1));
                //Console.WriteLine(Utility.IsDouble(number2));
                Console.WriteLine($" Error: Unable to perform operation with the given inputs: `{number1}` and `{number2}`");
                Console.WriteLine(" Expected: Both inputs should be of the same type.");
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
                //Console.WriteLine(Utility.IsDouble(number1));
                //Console.WriteLine(Utility.IsDouble(number2));
                Console.WriteLine($" Error: Unable to perform operation with the given inputs: `{number1}` and `{number2}`");
                Console.WriteLine(" Expected: Both inputs should be of the same type.");
            }

        }

    }
}
