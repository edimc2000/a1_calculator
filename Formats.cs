using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator;

    internal class Formats ()
    {
        // reset background and foreground console colors
        public const string ResetColor = "\e[0m";

        // set white background and red foreground
        public const string ErrorColor = "\e[48;2;255;255;255;38;2;255;0;0m";

        // set white background and red foreground
        public const string ResultColor = "\e[48;2;255;255;255;38;2;0;128;0m";

        // light blue
        public const string BackgroundColor = "\e[48;2;26;132;184m";

        // white
        public const string ForegroundColor = "\e[37m";

}

