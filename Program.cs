namespace Calculator
{
    internal class Program
    {
        bool validInput = false;
        int attemptCounter = 0;
        int maxAttempt = 5;
        Utility.DisplayTitle("Calculator", "all");
        Utility.OperationMenu();

        int operationToPerform = MathOperation(validInput, attemptCounter, maxAttempt);

        if (operationToPerform == 0) Environment.Exit(0);
        Console.WriteLine($"operationToPerform \t: {operationToPerform}");
        Console.WriteLine($"Chosen operator \t: {(Operation)operationToPerform - 1}");

        CallCalculate(operationToPerform);
    }

    private static int MathOperation(bool isLooping, int attemptCounter, int maxAttempt)
    {
        while (!isLooping)
        {
            string choice = Utility.OperationChoice();
            int operation = Utility.ValidateInput(choice, 1, 5);
            attemptCounter++;

            bool validInput = false;


            while (!validInput) 
            {

               String choice = Utility.OperationMenu();
               validInput =  Utility.ValidateInput(choice);

            }

            if (attemptCounter >= maxAttempt)
            {
                isLooping = true;
                Console.SetCursorPosition(29, Console.CursorTop);
                Console.WriteLine(
                    $"{Utility.ErrorColor} Maximum number of attempts has been reached. " +
                    $"{attemptCounter} / {maxAttempt} {Utility.ResetColor}");
            }
        }

    }



}
