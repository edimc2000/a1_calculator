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



        public static void OperationMenu()
        {
            Operation[] operations = (Operation[])Enum.GetValues(typeof(Operation));
            String[] symbols = { "(+)", "(-)", "(*)", "(/)", "(^)" };

            DisplayTitle("Calculator", "top");

            for (int i = 0; i < operations.Length; i++)
            {
                //string tabStops = i > 0 ? "              " : "   Type\t";
                string tabStops = i > 0 ? new string(' ', 14): "   Type\t";
                string centerThis = $"{tabStops}{i + 1}   - to {operations[i]}     \t{symbols[i]}    ";
                PrintCenteredTitle(centerThis, 29);
            }
            DisplayTitle("Calculator", "bottom");

        }





        public static void DisplayTitle(string title, string cover)
        {
            string lineBoxTop = new string('─', 45);
            string cornerLeftTop = " ┌";
            string cornerRightTop = "┐";
            string cornerLeftBottom = " └";
            string cornerRightBottom = "┘";

            if (cover == "all")
            {
                Console.WriteLine(cornerLeftTop + lineBoxTop + cornerRightTop);
                PrintCenteredTitle(title, 45);
                Console.WriteLine(cornerLeftBottom + lineBoxTop + cornerRightBottom);
            }

            if (cover == "top")
            {
                Console.WriteLine(cornerLeftTop + lineBoxTop + cornerRightTop);
            }

            if (cover == "bottom")
            {
                Console.WriteLine(cornerLeftBottom + lineBoxTop + cornerRightBottom);
            }


        }


        static void PrintCenteredTitle(string title, int width)
        {
            int availableWidth = width;
            //Console.WriteLine(availableWidth);
            string centeredTitle = string.Format(" │{0,-" + availableWidth + "}│",
                title.PadLeft((availableWidth + title.Length) / 2).PadRight(availableWidth));
            Console.WriteLine(centeredTitle);
        }
    }



}