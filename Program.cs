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

            //Console.Write($"  Enter first number\t:  ");
            //string firstNumber = Console.ReadLine() ?? " ";
            //Console.Write($"  Enter second number\t:  ");
            //string secondNumber = Console.ReadLine() ?? " ";
            

            //Calculate.Add(firstNumber, secondNumber);

            //Calculate.Add("01", "200000.33");
            //Calculate.Add("1", "z");
            CallCalculate(operationToPerform);





        }

        static int MathOperation(bool isLooping, int attemptCounter, int maxAttempt)
        {

            while (!isLooping)
            {
                string choice = Utility.OperationChoice();
                int operation = Utility.ValidateInput(choice);
                attemptCounter++;

                if (operation != 0)
                {
                    isLooping = true;
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

        static void CallCalculate(int operationToPerform)
        {
            switch (operationToPerform)
            {

                case 1:
                    
                    Calculate.Add();
                    break;
                case 2:
                    Console.WriteLine("--- Subtract --- ");
                    Calculate.Subtract();
                    break;

                default:
                    break;


            }

        }

    }



}
