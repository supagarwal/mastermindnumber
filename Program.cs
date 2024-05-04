using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Mastermindnumeral
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            
            int numberOfAttempts = 10;

            // Get a random 4 digit number, with digits 1,2,3,4,5,6
            int ResultToGuess = GenerateRandomNo();
            // Prompt the user for input
            Console.WriteLine("Welcome!");
            Console.WriteLine("This is a MasterMind game, you need to guess the computer generated 4 digit number with digits 1,2,3,4,5,6");
            Console.WriteLine("You have 10 attempts to reach to the correct answer.");
            Console.WriteLine("For every correct digit in correct place, a + sign will be shown");
            Console.WriteLine("For every correct digit in a wrong place, a - sign will be shown");
            int[] matchNonmatch = new int[2];
            int[] userInput = new int[4];
            for (int i = 0; i < numberOfAttempts; i++)
            {
                Console.WriteLine("\nPlease enter your guess");
                string input = Console.ReadLine();
                int userChoice;
                for (int j = 0; j < 4; j++)
                {
                    if (int.TryParse(input[j].ToString(), out int digit) && digit >= 1 && digit <= 6)
                    {
                        userInput[j] = digit;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a 4-digit number with digits 1,2,3,4,5,6");
                        continue;
                    }
                }
                while (!Int32.TryParse(input, out userChoice))
                {
                    Console.WriteLine("Please enter only digits!");
                    continue;
                }
                if (input.Length != 4)
                {
                    Console.WriteLine("Please enter a 4-digit number.");
                    continue;
                }
                
                matchNonmatch = CalculateResult(ResultToGuess, userChoice);

                if (matchNonmatch[0] == 4)
                {
                   Console.WriteLine("You won! Your answer is correct!");
                   Console.ReadKey();
                  return;
                }

                Console.WriteLine("hint:");

                for (int plusses = 0; plusses < matchNonmatch[0]; plusses++)
                {
                    Console.Write("+");
                }
                for (int minuses = 0; minuses < matchNonmatch[1]; minuses++)
                {
                    Console.Write("-");
                }
                int arrDigits = matchNonmatch[0] + matchNonmatch[1];
                    while(arrDigits != 4)
                    {
                        Console.Write(" ");
                    arrDigits++;
                    }            
                }
                Console.WriteLine("your number of attempts are exhausted! You lost!");
                Console.WriteLine("The Correct answer is:" + ResultToGuess);


            
        }

        private static int[] CalculateResult(int resultToGuess, int userChoice)
        {
            var dupResultToGuess = resultToGuess.ToString().Select(t => int.Parse(t.ToString())).ToArray();
            var dupUserChoice = userChoice.ToString().Select(t => int.Parse(t.ToString())).ToArray();

            int noOfPlusSigns = 0;
            int noOfMinusSigns = 0;
            for (int i = 0; i < dupResultToGuess.Length; i++)
            {
                if (dupResultToGuess[i].Equals(dupUserChoice[i]))
                {
                    noOfPlusSigns++;
                }
                else if (Array.IndexOf(dupResultToGuess, dupUserChoice[i])!=-1)
                {
                    noOfMinusSigns++;
                }
            
            }

            return new int[] { noOfPlusSigns, noOfMinusSigns};

        }

        private static int GenerateRandomNo()
        {            
            Random r = new Random();
            int[] allowedDigits = { 1, 2, 3, 4, 5, 6 };
            int result = 0;

            for (int i = 0; i < 4; i++)
            {
                 int nextIndex = r.Next(0, allowedDigits.Length);

                result = result * 10 + allowedDigits[nextIndex];
            }
            return result;
        }

    }
}    
