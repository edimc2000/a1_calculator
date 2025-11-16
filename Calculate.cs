using System;


namespace Calculator
{
  public class Calculate()
  {
    public static void Add(string number1, string number2)
    {

      Console.WriteLine($"Add {number1} + {number2} = { Double.Parse(number1) + Double.Parse(number2)}"); 

    }

  }
}
