using System;

namespace Exercise_11
{
    public static class ExtensionMethods
    {
        public static bool IsOdd(this AboutNumber obj, int number)
        {
            
            return (number % 2 == 0) ? false : true;
        }
        public static bool IsEven(this AboutNumber obj, int number)
        {
            return (number % 2 == 0) ? true : false;
        }
        public static bool IsPrime(this AboutNumber obj, int number)
        {
            int i;
            for (i = 2; i < number; i++)
            {
                if (number % i == 0)
                {
                    break;
                }
            }
            return (i == number) ? true : false;
        }
     
    }
    public class AboutNumber
    {
        public  bool IsDivisibleBy( int number, int divisible)
        {
            return (number % divisible == 0) ? true : false;
        }

    }
   

  public  class Exercise11
  {



      
      


        public Exercise11()
        {
            Console.WriteLine("Enter a integer Number");
            int number = int.Parse(Console.ReadLine());

            AboutNumber obj = new AboutNumber();
            bool oddnum = obj.IsOdd(number);
            Console.WriteLine("Odd Number - " + oddnum);
         
               
            bool evennum = obj.IsEven(number);
            Console.WriteLine("Even Number - " + evennum);
            
         
            bool primenum = obj.IsPrime(number);
            Console.WriteLine("Prime Number - " + primenum);
            
          
            Console.WriteLine("Enter a integer Number by which You want to divid");
            int divisible = int.Parse(Console.ReadLine());
            bool divisiblenum = obj.IsDivisibleBy(number,divisible);
            Console.WriteLine("Is Divisible By " + divisible + " : " + divisiblenum);
            

     

        }
  }
}
