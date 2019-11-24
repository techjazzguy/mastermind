using System;

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

        public string GenerateCode()
        {
            Code = String.Empty;
            const int minNumber = 1;
            const int maxNumber = 6;
            // Generate a string a random numbers by looping thru each number until max number of digits is reached.
            for (int i = 1; i <= maxCodeNumbers; i++)
            {
                Random randomNum = new Random();
                Code += randomNum.Next(minNumber, maxNumber).ToString();
            }
            return Code;
        }

        public string GuessAnswer(string guess)
        {
            if (guess == Code)
            {
                // Set correct answer flag to true.
                this.isCorrectAnswer = true;
                return "You guessed the code correctly! Good job.";
            }
            if (String.IsNullOrEmpty(guess))
            {
                return "Invalid guess";
            }
            // Ensure correct answer flag is true.
            this.isCorrectAnswer = false;
            return "Invalid guess";
        }
    }
}
