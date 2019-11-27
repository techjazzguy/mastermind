using System;
using MastermindNamespace;
class Program
{

    static void Main(string[] args)
    {
        Mastermind mastermind = new Mastermind();
        //Flag which will track if the user wants to continue playing.
        bool continuePlaying = true;
        
        while (continuePlaying)
        {
           continuePlaying = mastermind.Play();
        }
       
    }

}
