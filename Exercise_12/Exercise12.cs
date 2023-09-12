using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise_12
{
  public  class Exercise12
    {
        public static bool GreaterThanFive(int x)
        {
            return x > 5;
        }

        public static bool LessThanFive(int x)
        {
            return x < 5;
        }
        public static bool AnythingMethod(int x)
        {
            return x != 0;
        }
        public static void Out(string message, IEnumerable<int> list)
        {
            Console.Write(message + " :   ");
            foreach (int num in list)
                Console.Write(num + "  ");
            Console.WriteLine();
            Console.WriteLine();
        }
        public Exercise12()
        {
            // Create a list 
            //List<int> list = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            // call where method on it and pass delegate to it in the following ways:
            List<int> list = new List<int>();
            Console.WriteLine("Enter tha list size");
            int sz = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < sz; i++)
            {
                Console.WriteLine("Enter List Number");
                list.Add(Convert.ToInt32(Console.ReadLine()));
            }
            // Find odd - Lambda Expression – without curly brackets
            IEnumerable<int> odd = list.Where(x => x % 2 == 1);
            Out("Odd", odd);

            // Find Even - Lambda Expression – with curly brackets
            IEnumerable<int> even = list.Where(x => { return x % 2 == 0; });
            Out("Even", even);

            // Find Prime – Anonymous Method
            IEnumerable<int> primes = list.Where(delegate (int x) {
                if (x <= 1)
                    return false;
                for (int i = 2; i <= x; i++)
                    if (x % i == 0)
                        return false;
                return true;
            });
            Out("Primes Anonymous", primes);

            // Find Prime Another – Lambda Expression
            IEnumerable<int> primesAnother = list.Where(x => {
                if (x <= 1)
                    return false;
                for (int i = 2; i <= x / 2; i++)
                    if (x % i == 0)
                        return false;
                return true;
            });
            Out("Primes Lambda", primesAnother);

            // Elements Greater Than Five – Method Group Conversion Syntax
            // use method group conversion (assigns a method to a delegate)
            Func<int, bool> ConditionMore = GreaterThanFive;   // Func<T,TResult> is a delegate
            IEnumerable<int> greaterThanFive = list.Where(ConditionMore);
            Out("Greater Than Five", greaterThanFive);

            // Less than Five – Delegate Object in Where – Method Group Conversion Syntax in Constructor of Object
            Func<int, bool> ConditionLess = new Func<int, bool>(LessThanFive);
            IEnumerable<int> lessThanFive = list.Where(ConditionLess);
            Out("Less Than Five", lessThanFive);

            // Find 3k – Delegate Object in Where – Lambda Expression in Constructor of Object
            Func<int, bool> Condition3k = new Func<int, bool>(x => x % 3 == 0);
            IEnumerable<int> list3k = list.Where(Condition3k);
            Out("3k", list3k);

            // Find 3k + 1 - Delegate Object in Where – Anonymous Method in Constructor of Object
            Func<int, bool> Condition3kplus1 = new Func<int, bool>(delegate (int x) {
                return x % 3 == 1;
            });
            IEnumerable<int> list3kplus1 = list.Where(Condition3kplus1);
            Out("3k + 1", list3kplus1);

            // Find 3k + 2 - Delegate Object in Where – Lambda Expression Assignment
            Func<int, bool> Condition3kplus2 = x => x % 3 == 2;
            IEnumerable<int> list3kplus2 = list.Where(Condition3kplus2);
            Out("3k + 2", list3kplus2);

            // Find anything - Delegate Object in Where – Anonymous Method Assignment
            Func<int, bool> Anything = delegate (int x) {
                return x != 0;
            };
            IEnumerable<int> anything = list.Where(Anything);
            Out("Anything", anything);

            // Find anything - Delegate Object in Where – Method Group Conversion Assignment
            Func<int, bool> AnythingAnother = AnythingMethod;
            IEnumerable<int> anythingAnother = list.Where(AnythingAnother);
            Out("Anything", anythingAnother);
        }
    }
}
