namespace Calculator
{
   public  class Program
    {

      public   static void Main(string[] args)
        {
            Utility.DisplayTitle("Calculator", "all");
            
            
            
            

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
}