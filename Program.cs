using System;

namespace Calculator
{
    class Calculator
    {
        public static double DoOperation(double num1, double num2, string op)
        {
            double result = double.NaN; //Default value is "not-a-number" if an operation, such as division, could result in an error.
            //use a switch
            switch (op)
            {
                case "a":
                    result = num1 + num2;
                    break;
                case "s":
                    result = num1 - num2;
                    break;
                case "m":
                    result = num1 * num2;
                    break;
                case "d":
                    //ask to a non-zero divisor
                    if (num2 !=0)
                    {
                        result = num1 / num2;
                    }
                    break;
                //return text for an incorrect entry
                default:
                    break; 
            }
            return result;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;
            //display title
            Console.WriteLine("Console Calculator in C#");
            Console.WriteLine("------------------------");

            while (!endApp)
            {
                //declare variables
                string numInput1 = "";
                string numInput2 = "";
                double result = 0;

                //ask to the first number
                Console.Write("Type the first number and press Enter: ");
                numInput1 = Console.ReadLine();

                double cleanNum1 = 0;
                while (!double.TryParse(numInput1, out cleanNum1))
                {
                    Console.Write("This is not valid input. Please enter an integer value: ");
                    numInput1 = Console.ReadLine();
                }

                //ask for the second number
                Console.Write("Type the second number and press Enter: ");
                numInput2 = Console.ReadLine();

                double cleanNum2 = 0;
                while (!double.TryParse(numInput2, out cleanNum2))
                {
                    Console.Write("This is not valid input. Please enter an integer value: ");
                    numInput2 = Console.ReadLine();
                }

                //ask for an operator
                Console.WriteLine("Choose an operator from the list: ");
                Console.WriteLine("\ta - Add");
                Console.WriteLine("\ts - Substract");
                Console.WriteLine("\tm - Multiply");
                Console.WriteLine("\td - Divide");
                Console.Write("Your choise? ");

                string op = Console.ReadLine();

                try
                {
                    result = Calculator.DoOperation(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("This operation will result in a mathematical error.\n");
                    }
                    else Console.WriteLine("Your result: {0:0.##}\n", result);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
                }

                Console.WriteLine("------------------------\n");

                Console.Write("Press 'n' and Enter to close the app, or press any key and Enter to continue: ");
                if (Console.ReadLine() == "n") endApp = true;
                Console.WriteLine("\n");

            }
            return;
        }
    }
}