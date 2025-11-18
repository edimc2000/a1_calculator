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

            int operationToPerform = Utility.MathOperation(validInput, attemptCounter, maxAttempt);

            if (operationToPerform == 0) return;

            CallCalculate(operationToPerform);
            string anotherRound = Utility.TryAgain();

            if (anotherRound == "N") return;
        }
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
}