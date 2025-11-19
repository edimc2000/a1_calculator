using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator;

/**
 * AnsiColorCodes.cs
 * Provides ANSI escape code constants for console text formatting and coloring.
 *
 * @author Eddie C.
 * @version 1.0
 * @since 2025-11-09
 */

internal static class AnsiColorCodes
{
    /* Reset the background and foreground console colors to default */
    public const string Reset = "\e[0m";

    /* Red font and white background for error messages */
    public const string Error = "\e[48;2;255;255;255;38;2;255;0;0m";

    /* Green font and white background for results */
    public const string Result = "\e[48;2;255;255;255;38;2;0;128;0m";

    /* Light blue background color */
    public const string Background = "\e[48;2;26;132;184m";

    /* White foreground color */
    public const string Foreground = "\e[37m";
}