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

            Console.Write("\n\tType");
            for (int i = 0; i < operations.Length; i++)
            {
                string tabStops = i > 0 ? "\t\t" : "\t";
                Console.Write($"{tabStops}{i + 1}   - to {operations[i]}     \t{symbols[i]} \n");
            }


        }





        public static void DisplayTitle(string title)
        {
            string lineBoxTop = new string('─', 45);
            string cornerLeftTop = " ┌";
            string cornerRightTop = "┐";
            string cornerLeftBottom = " └";
            string cornerRightBottom = "┘";

            Console.WriteLine(cornerLeftTop + lineBoxTop + cornerRightTop);
            PrintCenteredTitle(title);
            Console.WriteLine(cornerLeftBottom + lineBoxTop + cornerRightBottom);
        }


        static void PrintCenteredTitle(string title)
        {
            int availableWidth = 45;
            string centeredTitle = string.Format(" │{0,-" + availableWidth + "}│",
                title.PadLeft((availableWidth + title.Length) / 2).PadRight(availableWidth));
            Console.WriteLine(centeredTitle);
        }
    }



}