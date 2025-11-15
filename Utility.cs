using System;


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
        public static string OperationMenu()
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

            Console.Write("Enter your choice \t: ");

            return Console.ReadLine();
        }



        public static bool ValidateInput(string input)
        {

            Console.WriteLine(input);

            try
            {
                int result = Convert.ToInt32(input);

                if (result >= 1 && result <= 5)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine($" Error: Enter choice between 1 and 5");
                    return false;

                }

            }

            catch (Exception err)
            {
                Console.WriteLine($" Error: {err.Message}");
                Console.WriteLine(" Please enter a valid integer. Try again.");
                return false;
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


        static string PrintCenteredTitle(string title, int width)
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

    }



}