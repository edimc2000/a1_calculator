namespace Calculator;

public class Program
{
    public static void Main(string[] args)
    {
        bool runApp = true;

        while (runApp)
        {
            bool validInput = false;
            int attemptCounter = 0;
            int maxAttempt = 5;
            Utility.DisplayTitle("Calculator", "all");
            Utility.OperationMenu();

            int operationToPerform = MathOperation(validInput, attemptCounter, maxAttempt);

            if (operationToPerform == 0)
            {
                WriteLine("x");
                //Environment.Exit(0);
                return;
            }

            //WriteLine($"operationToPerform \t: {operationToPerform}");
            //WriteLine($"Chosen operator \t: {(Operation)operationToPerform - 1}");

            CallCalculate(operationToPerform);
            string anotherRound = Utility.TryAgain();

            if (anotherRound == "N") return;

            if (anotherRound == "Y") WriteLine("y0y0");
        }
    }

    private static int MathOperation(bool isLooping, int attemptCounter, int maxAttempt)
    {
        while (!isLooping)
        {
            string choice = Utility.OperationChoice();
            int operation = Utility.ValidateInput(choice, 1, 5);
            attemptCounter++;

            if (operation != 0)
            {
                isLooping = true;
                return operation;
            }

            if (attemptCounter >= maxAttempt)
            {
                isLooping = true;
                SetCursorPosition(29, CursorTop);
                WriteLine(
                    $"{Utility.ErrorColor} Maximum number of attempts has been reached. " +
                    $"{attemptCounter} / {maxAttempt} {Utility.ResetColor}");
            }
        }

        return 0;
    }

    private static void CallCalculate(int operationToPerform)
    {
        switch (operationToPerform)
        {
            case 1:
                Calculate.Add();
                break;
            case 2:
                Calculate.Subtract();
                break;
            case 3:
                Calculate.Multiply();
                break;
            case 4:
                Calculate.Divide();
                break;
            case 5:
                Calculate.Power();
                break;
            default:
                break;
        }
    }


    // Add this method for testing purposes only
    public static string RunWithInputs(params string[] inputs)
    {
        var originalIn = Console.In;
        try
        {
            Console.SetIn(new StringReader(string.Join(Environment.NewLine, inputs)));
            var originalOut = Console.Out;
            using var writer = new StringWriter();
            Console.SetOut(writer);

            Main(Array.Empty<string>());

            return writer.ToString();
        }
        finally
        {
            Console.SetIn(originalIn);
        }
    }
}