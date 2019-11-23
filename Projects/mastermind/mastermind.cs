using System;

namespace MastermindNamespace
{
    public class Mastermind
    {
        string Code = String.Empty;
        const int maxCodeNumbers = 4;
        
        public string GenerateCode()
        {
            Code = String.Empty;
            const int minNumber = 1;
            const int maxNumber = 6;
            for (int i = 1; i <= maxCodeNumbers; i++)
            {
                Random randomNum = new Random();
                Code += randomNum.Next(minNumber, maxNumber).ToString();
            }
            return Code;
        }

    }
}
