using System;

namespace Exercise_3
{
    public class Exercise3
    {   
        static void primeNumbers( int n1,int n2)
        {
            int i,j,current_prime=0,f;

           for(i=n1; i<=n2 && current_prime<=n2 ;i++)
           {
                f = 0;
                for (j = 2; j < i / 2; j++)
                {
                    if (i % j == 0)
                    {
                        f++;
                        break;
                    }

                }
                if (f == 0)
                {
                    current_prime = i;
                    Console.WriteLine("\n"+current_prime);
                }
               
           }


        }
        public Exercise3()
        {   
            repeat:
            Console.WriteLine("Enter the Frist Number");
            int num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Second Number and less than 1000");
            int num2 = int.Parse(Console.ReadLine());
            if( num1 >= num2 && num1<=999 && num2<= 1000)
            {
                Console.WriteLine("Enter frist nubmer which is less than second one");
                goto repeat;
            }
            else
            {
                Console.WriteLine("the prime numbers are:");
                primeNumbers( num1,num2);
            }
        }
    }
}
