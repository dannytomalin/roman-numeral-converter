using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Roman_Numberal_Converter
{
    class Program
    {
        public const int I = 1;
        public const int V = 5;
        public const int X = 10;
        public const int L = 50;
        public const int C = 100;
        public const int D = 500;
        public const int M = 1000;

        public static string UsersInput;
        public static List<int> Result;
        public static int Answer;

        static void Main(string[] args)
        {
            PromptUserForValue();
            var validator = "^M{0,4}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$";
            Match isValid = Regex.Match(UsersInput, validator);
          
            if (isValid.Success)
            {
                ConvertNumeralToNumberConverter(UsersInput);
                PerformCalculation();
                Console.WriteLine(Answer);
            }
            else
            {
                Console.WriteLine("Nice try ;). That's doesn't look like a roman numeral.");
            }
        }

        private static void PromptUserForValue()
        {
            Console.WriteLine("Enter a roman numberal");
            UsersInput = Console.ReadLine();
            UsersInput = UsersInput.ToUpper();
            ConvertNumeralToNumberConverter(UsersInput);

        }

        private static void ConvertNumeralToNumberConverter(string value)
        {
            Result = new List<int>();
            foreach (var i in value)
            {
                switch (i.ToString())
                {
                    case "I":
                        Result.Add(I);
                        break;
                    case "V":
                        Result.Add(V);
                        break;
                    case "X":
                        Result.Add(X);
                        break;
                    case "L":
                        Result.Add(L);
                        break;
                    case "C":
                        Result.Add(C);
                        break;
                    case "D":
                        Result.Add(D);
                        break;
                    case "M":
                        Result.Add(M);
                        break;
                    default:
                        break;
                }
            }
        }
        private static void PerformCalculation()
        {
            int previousValue = 0;
            int currentValue = Result[0];

            foreach (var i in Result)
            {
                previousValue = currentValue;
                currentValue = i;
                if (previousValue < currentValue)
                {
                    var difference  = currentValue - previousValue;
                    Answer = Answer + difference - previousValue;
                }
                else
                {
                    Answer = Answer + currentValue;
                }

            }
        }
    }
}
