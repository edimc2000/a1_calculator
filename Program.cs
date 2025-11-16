namespace Calculator
{
    internal class Program
    {

        static void Main(string[] args)
        {
            bool validInput = false;
            int attemptCounter = 0;
            int maxAttempt = 5;
            Utility.DisplayTitle("Calculator", "all");
            Utility.OperationMenu();

            while (!validInput)
            {
                String choice = Utility.OperationChoice();
                int operation = Utility.ValidateInput(choice);
                attemptCounter++;

                if (operation != 0) 
                {
                    validInput = true; 
                }
                                
                if (attemptCounter >= maxAttempt)
                {
                    validInput = true;
                    Console.SetCursorPosition(29, Console.CursorTop);
                    Console.WriteLine($"{Utility.ErrorColor} The maximum number of attempts has been reached. " +
                        $"{attemptCounter} / {maxAttempt} {Utility.ResetColor}");
                }

            }

        }

    }



}
