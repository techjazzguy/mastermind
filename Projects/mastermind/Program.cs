using System;
using MastermindNamespace;
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Mastermind. Press the enter key to start playing.");
            Console.Read();
            Mastermind mastermind = new Mastermind();
            Console.WriteLine(mastermind.GenerateCode());
        }
    }
