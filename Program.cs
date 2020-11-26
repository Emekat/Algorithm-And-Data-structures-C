 using System;

namespace AlgoAndDs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            if(new StackSolution().IsValidBracket("(()))"))
                Console.WriteLine("valid");
            else
            {
                Console.WriteLine("Not valid");
            }
        }
    }
}
