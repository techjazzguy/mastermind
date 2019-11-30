using System;
using System.Text;

namespace MastermindNamespace
{
    public class Mastermind
    {
        public string Code = String.Empty;
        public int maxCodeNumbers = 4;
        public int maxGuesses = 10;
        public int minNumber = 1;
        public int maxNumber = 6;
        public bool isCorrectAnswer = false;

        public bool Play()
        {
            Console.Clear();
            // Start the game. Prompt the user to start.
            Console.WriteLine("Welcome to Mastermind! Press the enter key to start playing.");
            Console.Read();
            //Generate a code to guess.
            this.GenerateCode();
            Console.WriteLine("A " + this.maxCodeNumbers +
            " digit code was generated with each digit between "
            + this.minNumber + " and " + this.maxNumber +
            ". Guess the code!");
            int numGuesses = 0;
            //Loop through the allowed number of guesses until max guesses are reached or the correct answer is given.
            for (int i = numGuesses; i <= this.maxGuesses; i++)
            {
                //Prompt for guess.
                if (!i.Equals(this.maxGuesses))
                {
                    Console.WriteLine("Enter guess:");
                }
                //Read the guess submitted.
                string guess = Console.ReadLine();

                //Process guess results.
                Console.WriteLine(this.GuessAnswer(guess));

                if (this.isCorrectAnswer)
                {
                    //Correct answer was submitted.
                    break;
                }

            }
            // If the correct answer was not guessed after the maximum number of tries, then end the game.
            if (!this.isCorrectAnswer)
            {
                Console.WriteLine("Sorry, the code was not correctly guessed! Game over. The answer is " + this.Code);
            }

            //Prompt to continue playing. Return true or false back to Main.
            Console.Write("Continue Playing? Y/N:");
            char continueKey = Console.ReadKey().KeyChar;
            
            if (char.ToUpperInvariant(continueKey) == 'Y')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GenerateCode()
        {
            Code = String.Empty;
            // Generate a string a random numbers by looping thru each number until max number of digits is reached.
            for (int i = 1; i <= maxCodeNumbers; i++)
            {
                Random randomNum = new Random();
                Code += randomNum.Next(this.minNumber, this.maxNumber).ToString();
            }
            return Code;
        }

        public string GuessAnswer(string guess)
        {
            string result = String.Empty;
            //Simple check for something submitted as an answer.
            if (String.IsNullOrEmpty(guess))
            {
                this.isCorrectAnswer = false;
                return "Invalid guess.";
            }
            //Code and guess need to have the same number of characters.
            if (guess.Length != Code.Length)
            {
                return "Guess entered needs to have the same number of characters as the code.";
            }
            if (String.Equals(guess, Code))
            {
                // Set correct answer flag to true.
                this.isCorrectAnswer = true;
                return "You guessed the code correctly! Good job.";
            }

            StringBuilder sb = new StringBuilder(Code);
            //Find all matches.
            for (int i = 0; i < sb.Length; i++)
            {
                if (char.IsNumber(sb[i]))
                {
                    if (guess[i].Equals(sb[i]))
                    {
                        sb = sb.Replace(sb[i], '+', i, 1);
                    }
                }
            }

            //Find all partial matches. Answer has a number that is in the guess but in a different position.
            for (int i = 0; i < sb.Length; i++)
            {
                if (char.IsNumber(sb[i]))
                {
                    if (!guess[i].Equals(sb[i]) && (sb.ToString().Contains(guess[i])))
                    {
                        sb = sb.Replace(sb[i], '-', i, 1);
                    }
                }
            }

            //Find all guess numbers that do not have any type of match.
            for (int i = 0; i < sb.Length; i++)
            {
                if (char.IsNumber(sb[i]))
                {
                    if (!guess[i].Equals(sb[i]))
                    {
                        //Replace with placeholder characters which will be emptied upon displaying feedback to the guesser.
                        sb = sb.Replace(sb[i], 'R', i, 1);
                    }
                }
            }

            //Empty any placeholder characters for no matches.
            sb.Replace("R", "");
            return sb.ToString();
        }

    }
}
