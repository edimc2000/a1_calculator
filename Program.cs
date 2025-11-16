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

            int operationToPerform = MathOperation(validInput, attemptCounter, maxAttempt);
            
            if (operationToPerform == 0)
            {
                Environment.Exit(0);
            }
            Console.WriteLine($"operationToPerform \t: {operationToPerform}");
            Console.WriteLine($"Chosen operator \t: {(Operation)operationToPerform - 1}");
            Calculate.Add("1", "2");

        }

        static int MathOperation(bool isLooping, int attemptCounter, int maxAttempt)
        {

            while (!isLooping)
            {

                //Utility.IsNumber("25");
                //Utility.IsNumber("a");
                //Utility.IsNumber("25.0");
                //Utility.IsNumber("c");

                string choice = Utility.OperationChoice();
                int operation = Utility.ValidateInput(choice);
                attemptCounter++;

                if (operation != 0)
                {
                    isLooping = true;
                    //Console.WriteLine($" ---this is fn math operation ValidateInput result is  : {operation}");
                    //Console.WriteLine($" ---enum  : {(Operation)operation-1}");
                    return operation;
                }

                if (attemptCounter >= maxAttempt)
                {
                    isLooping = true;
                    Console.SetCursorPosition(29, Console.CursorTop);
                    Console.WriteLine($"{Utility.ErrorColor} Maximum number of attempts has been reached. " +
                                      $"{attemptCounter} / {maxAttempt} {Utility.ResetColor}");
                }


            }



            return 0;
        }

    }



}
