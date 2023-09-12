using System;
using System.Collections.Generic;
using System.Linq;
namespace Exercise_13
{
    public static class ExtClass
    {

        public delegate bool Condition<T>(T n);

        // 1. CustomAll - Should work as All operation of Linq, with custom logic passed as delegate
        public static bool CustomAll<T>(this IEnumerable<T> list, Func<T, bool> condition)
        {
            return list.All(condition);
        }

        // 2. CustomAny - Should work as Any operation of Linq, with custom logic passed as delegate
        public static bool CustomAny<T>(this IEnumerable<T> list, Func<T, bool> condition)
        {
            return list.Any(condition);
        }

        // 3. CustomMax - Should work as Max operation of Linq, with custom logic passed as delegate
        public static TResult CustomMax<T, TResult>(this IEnumerable<T> list, Func<T, TResult> function)
        {
            return list.Max(function);
        }

        // 4. CustomMin - Should work as Min operation of Linq, with custom logic passed as delegate
        public static TResult CustomMin<T, TResult>(this IEnumerable<T> list, Func<T, TResult> function)
        {
            return list.Min(function);
        }

        // 5. CustomWhere - Should work as Where operation of Linq, with custom logic passed as delegate
        public static IEnumerable<T> CustomWhere<T>(this IEnumerable<T> list, Func<T, bool> condition)
        {
            return list.Where(condition);
        }

        // 6. CustomSelect - Should work as Select operation of Linq, with custom logic passed as delegate
        public static IEnumerable<TResult> CustomSelect<T, TResult>(this IEnumerable<T> list, Func<T, TResult> function)
        {
            return list.Select(function);
        }
    }
   public class Exercise13
    {

        public static void Out<T>(IEnumerable<T> list)
        {
            foreach (T el in list)
                Console.Write(el + "  ");
            Console.WriteLine();
        }
        public Exercise13()
        {
            IEnumerable<int> list = new List<int>() { 3, 2, 1, 2, 3, 4, 5, 4, 3 };
            Console.WriteLine("all are > 0 or Not");
            Console.WriteLine(list.CustomAll(n => n > 0));
            Console.WriteLine("3 is present or not");
            Console.WriteLine(list.CustomAny(n => n == 3));
            Console.WriteLine("max element *2");
            Console.WriteLine(list.CustomMax(n => 2 * n));
            Console.WriteLine("min element *2");
            Console.WriteLine(list.CustomMin(n => 2 * n));

            Console.WriteLine("all odd numbers");
            IEnumerable<int> Enum = list.CustomWhere(n => n % 2 == 1);
            Out(Enum);
            Console.WriteLine("* with all elements");
            IEnumerable<double> select = list.CustomSelect(n => 0.5 * n);
            Out(select);
        }
    }
}
