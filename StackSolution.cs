using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoAndDs
{
    public class StackSolution
    {
       private readonly Dictionary<char, char> _reverseBrackets;
       private static readonly string _leftBracket = "{[(<";
       public StackSolution()
       {
           _reverseBrackets = new Dictionary<char, char>()
           {
               {'}','{'},
               {']','['},
               {')','('},
               {'>','<'}
           };
        }
        public bool IsValidBracket(string bracketString)
        {
            var brackets = new Stack<char>();
           
            foreach (var bracket in bracketString)
            {
                if (IsLeftBracket(bracket))
                {
                    brackets.Push(bracket);
                }
                else if (brackets.Count == 0 || (brackets.Pop() != GetReversedBrackets(bracket)))
                    return false;
            }
            return brackets.Count == 0;
        }

        public char GetReversedBrackets(char bracket)
        {
            return _reverseBrackets[bracket];
        }
        public bool IsLeftBracket(char bracketString)
        {
            return _leftBracket.Contains(bracketString);
        }

      
    }
}
