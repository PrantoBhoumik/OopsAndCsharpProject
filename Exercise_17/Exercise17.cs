using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_17
{
    class InvalidNumberException : Exception
    {
        public InvalidNumberException(string msg) : base(msg) { }
    }
   public class Exercise17
    {
        static void UserAnswer(string msg, int selectedMethod)
        {
            const int minNumber = int.MinValue;
            const int maxNumber = int.MaxValue;
            Console.Write(msg);
            string inputString = Console.ReadLine();
            if (isCorrectAnswer(inputString, minNumber, maxNumber, 0, false))
            {
                if (isCorrectAnswer(inputString, minNumber, maxNumber, selectedMethod, true))
                {
                    Console.WriteLine("correct answer.");
                }
            }
        }

        static bool isCorrectAnswer(string msg, int minNumber, int maxNumber, int selectedMethod, bool hasNextFunctions)
        {
            if (!hasNextFunctions)
            {
                int number = -1;
                if (!int.TryParse(msg, out number))
                {
                    throw new InvalidNumberException(string.Format("Enter any integer number from {0}-{1}.", minNumber, maxNumber));
                }
                else
                {
                    if (number < minNumber || number > maxNumber)
                    {
                        throw new InvalidNumberException(string.Format("Enter any number from {0}-{1}.", minNumber, maxNumber));
                    }
                    return true;
                }
            }
            else
            {
                int number = -1;
                int.TryParse(msg, out number);
                if (selectedMethod == 1)
                {
                    if (number % 2 == 0)
                    {
                        return true;
                    }
                    else
                    {
                        throw new InvalidNumberException("not an even number.\n");
                    }


                }
                if (selectedMethod == 2)
                {
                    if (number % 2 == 1)
                    {
                        return true;
                    }
                    else
                    {
                        throw new InvalidNumberException("not a odd number.\n");
                    }


                }
                if (selectedMethod == 3)
                {
                    if (IsPrime(number))
                    {
                        return true;
                    }
                    else
                    {
                        throw new InvalidNumberException("not a prime number.\n");
                    }


                }
                if (selectedMethod == 4)
                {
                    if (number < 0)
                    {
                        return true;
                    }
                    else
                    {
                        throw new InvalidNumberException("not a negative number.\n");
                    }
                }
                if (selectedMethod == 5)
                {
                    if (number == 0)
                    {
                        return true;
                    }
                    else
                    {
                        throw new InvalidNumberException("not a zero number.\n");
                    }
                }
                return false;
            }
        }

        static bool IsPrime(int n)
        {
            if (n == 1) return false;
            if (n == 2) return true;

            for (int i = 2; i <= Math.Ceiling(Math.Sqrt(n)); i++)
                if (n % i == 0)
                    return false;
            return true;
        }
        public Exercise17()
        {
            int userNumber = -1;
            int nTimesPlayed = 0;
            while (nTimesPlayed < 5)
            {
                try
                {
                    Console.Write("Enter any number from 1-5: ");
                    string answer = Console.ReadLine();
                    if (!isCorrectAnswer(answer, 1, 5, 0, false))
                    {
                        userNumber = -1;
                    }
                    else
                    {
                        int.TryParse(answer, out userNumber);
                        nTimesPlayed++;
                        if (userNumber == 1)
                        {
                            UserAnswer("Enter even number: ", userNumber);
                        }
                        else if (userNumber == 2)
                        {
                            UserAnswer("Enter odd number: ", userNumber);
                        }
                        else if (userNumber == 3)
                        {
                            UserAnswer("Enter prime number: ", userNumber);
                        }
                        else if (userNumber == 4)
                        {
                            UserAnswer("Enter negative number: ", userNumber);
                        }
                        else if (userNumber == 5)
                        {
                            UserAnswer("Enter zero number: ", userNumber);
                        }
                    }

                }
                catch (InvalidNumberException ex)
                {
                    Console.WriteLine("Enter a valid NUmber");

                    userNumber = -1;
                }
            }
            Console.WriteLine("You completed 5 times.\n");
        }
    }
}
