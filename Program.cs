namespace Calculator
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Utility.DisplayTitle("Calculator", "all");
            
            
            
            

            bool validInput = false;


            while (!validInput) 
            {

               String choice = Utility.OperationMenu();
               validInput =  Utility.ValidateInput(choice);

            }

        }

    }



}
