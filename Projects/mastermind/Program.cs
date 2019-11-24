using System;
using MastermindNamespace;
class Program
{

    static void Main(string[] args)
    {
        // Start the game. Prompt the user to start.
        Console.WriteLine("Welcome to Mastermind. Press the enter key to start playing.");
        Console.Read();
        //Initialize new instance of the Mastermind game and generate a code to guess.
        Mastermind mastermind = new Mastermind();
        //Console.WriteLine(mastermind.GenerateCode());
        Console.WriteLine("A " + mastermind.maxCodeNumbers + 
        " digit code was generated with each digit between " 
        + mastermind.minNumber + " and " + mastermind.maxNumber + ". Guess the code!");
        int numGuesses = 0;
        for (int i = numGuesses; i <= mastermind.maxGuesses; i++)
        {
            string guess = Console.ReadLine();
            Console.WriteLine(mastermind.GuessAnswer(guess));
            if (mastermind.isCorrectAnswer)
            {
                break;
            }
        }
        // If the correct answer was not guessed after the maximum number of tries, then end the game.
        if (!mastermind.isCorrectAnswer)
        {
            Console.WriteLine("Sorry, the code was not correctly guessed! Game over.");
        }
    }
}
