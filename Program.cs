namespace Calculator
{
    internal class Program
    {

        enum Operation
        {
            Add, 
            Subtract,
            Multiply, 
            Divide, 
            Power
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Calculator App ");
            OperationMenu();



        }

        static void OperationMenu() {
            Operation[] operations = (Operation[])Enum.GetValues(typeof(Operation));
            String[] symbols = { "(+)", "(-)", "(*)", "(/)", "(^)" };

            Console.Write("\nType");
            for (int i = 0; i < operations.Length; i++)
            {
                Console.Write($"\t{i+1}   - to {operations[i]}     \t{symbols[i]} \n");
            }


        }
    }


}
