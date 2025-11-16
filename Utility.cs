using System;
using System.Xml.Linq;


namespace Calculator
{
    enum Operation
    {
        Add,
        Subtract,
        Multiply,
        Divide,
        Power
    }


    public static class Utility
    {
        public const string ResetColor = "\u001b[39m\u001b[49m"; // reset background and foreground console colors
        public const string ErrorColor = "\u001b[48;2;255;255;255;38;2;255;0;0m"; // set white background and red foreground

        public static void OperationMenu()
        {
            Operation[] operations = (Operation[])Enum.GetValues(typeof(Operation));
            String[] symbols = { "(+)", "(-)", "(*)", "(/)", "(^)" };

            DisplayTitle("", "top");

            for (int i = 0; i < operations.Length; i++)
            {
                string tabStops = i > 0 ? new string(' ', 14) : "   Type\t";
                string centerThis = $"{tabStops}{i + 1}   - to {operations[i]}     \t{symbols[i]}    ";
                Console.WriteLine(PrintCenteredTitle(centerThis, 29));

            }
            DisplayTitle("", "bottom");


        }


        public static string OperationChoice()
        {

            Console.Write("  Enter your choice \t: ");
            string response = Console.ReadLine() ?? "100";
            return response;
        }



        public static int ValidateInput(string input)
        {

            int position = 29;

            try
            {
                //Console.WriteLine($" {input} yy -this is fn ValidateInput input  : \n\n");
                int result = Convert.ToInt32(input);

                if (result >= 1 && result <= 5)
                {
                    //Console.WriteLine($" ---this is fn ValidateInput utility  : {result}");
                    return result;
                }
                else
                {
                    Console.SetCursorPosition(position, Console.CursorTop - 1);
                    Console.WriteLine($"{ErrorColor} Error: Enter choice between 1 and 5  {ResetColor}");
                    return 0;

                }

            }

            catch
            {
                Console.SetCursorPosition(position, Console.CursorTop - 1);
                Console.WriteLine($"{ErrorColor} Please enter a valid choice between 1 and 5. {ResetColor}");
                return 0;
            }


            //return true;
        }

        public static void DisplayTitle(string title, string cover)
        {
            string lineBoxTop = new string('─', 45);
            string cornerLeftTop = " ┌";
            string cornerRightTop = "┐ ";
            string cornerLeftBottom = " └";
            string cornerRightBottom = "┘ ";

            string top = cornerLeftTop + lineBoxTop + cornerRightTop;
            string bottom = cornerLeftBottom + lineBoxTop + cornerRightBottom;



            if (cover == "all")
            {
                string middle = PrintCenteredTitle(title, 45);
                ApplyHighlighter(top);
                ApplyHighlighter(middle);
                ApplyHighlighter(bottom);
            }

            if (cover == "top")
            {
                Console.WriteLine(top);
            }

            if (cover == "bottom")
            {
                Console.WriteLine(bottom);
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
            string backgroundColor = "\u001B[48;2;26;132;184m";  // light blue
            string foregroundColor = "\u001b[37m";  // white
            string reset = "\u001b[39m\u001b[49m";
            text = backgroundColor + foregroundColor + text + reset;
            Console.WriteLine(text);
        }

        public static bool IsDouble(string input)
        {
            double result;
            //Console.WriteLine(">>> " + Double.TryParse(input, out result));
            return Double.TryParse(input, out result);
        }

        public static string[] CaptureInputs()
        {
            Console.Write($"  Enter value for a\t:  ");
            string firstNumber = Console.ReadLine() ?? " ";
            Console.Write($"  Enter value for b\t:  ");
            string secondNumber = Console.ReadLine() ?? " ";

            return [firstNumber, secondNumber];
        }


        public static void DisplayInputError(string number1, string number2)
        {
            Console.WriteLine($"\n{ErrorColor} Error: Unable to perform operation with the given inputs: `{number1}` and `{number2}`. {ResetColor}");
            Console.WriteLine($"{ErrorColor} Expected: Both inputs should be of the same type - numbers. {ResetColor}");
        }


        public static void TitleAndFormula(string title, string formula)
        {
            Console.WriteLine();
            Utility.DisplayTitle("", "top");
            Console.WriteLine(Utility.PrintCenteredTitle(title, 45));
            Console.WriteLine(Utility.PrintCenteredTitle("", 45));
            Console.WriteLine(Utility.PrintCenteredTitle(formula, 45));
            Utility.DisplayTitle("", "bottom");
        }
    }



}