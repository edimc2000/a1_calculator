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

            DisplayTitle("", "top");

            for (int i = 0; i < operations.Length; i++)
            {
                string tabStops = i > 0 ? new string(' ', 14) : "   Type\t";
                string centerThis = $"{tabStops}{i + 1}   - to {operations[i]}     \t{symbols[i]}    ";
                Console.WriteLine(PrintCenteredTitle(centerThis, 29));
                //applyHighlighter(PrintCenteredTitle(centerThis, 29));
            }

            DisplayTitle("", "bottom");


        }





        public static void DisplayTitle(string title, string cover)
        {
            string lineBoxTop = new string('─', 45);
            string cornerLeftTop = " ┌";
            string cornerRightTop = "┐ ";
            string cornerLeftBottom = " └";
            string cornerRightBottom = "┘ ";
            
            string top = cornerLeftTop + lineBoxTop + cornerRightTop;
            string bottom = cornerLeftBottom + lineBoxTop + cornerRightBottom ;

 

            if (cover == "all")
            {
                string middle = PrintCenteredTitle(title, 45);

                applyHighlighter(top);
                applyHighlighter(middle);
                applyHighlighter(bottom);

            }

            if (cover == "top")
            {
                //applyHighlighter(top);
                Console.WriteLine(top);
            }

            if (cover == "bottom")
            {
                //applyHighlighter(bottom);
                Console.WriteLine(bottom);
            }

        }


        static string PrintCenteredTitle(string title, int width)
        {
            int availableWidth = width;
            //Console.WriteLine(availableWidth);
            string centeredTitle = string.Format(" │{0,-" + availableWidth + "}│ ",
                title.PadLeft((availableWidth + title.Length) / 2).PadRight(availableWidth));
            //Console.WriteLine(centeredTitle);

            return centeredTitle;
        }


        public static void applyHighlighter(string text)
        {
            string backgroundColor = "\u001B[48;2;26;132;184m";  // light blue
            string foregroundColor = "\u001b[37m";  // white
            string reset = "\u001b[39m\u001b[49m";
            text = backgroundColor + foregroundColor + text + reset;
            Console.WriteLine(text);
        }

    }



}