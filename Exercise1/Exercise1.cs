using System;

namespace Exercise_1
{
    public class Exercise1
    {  
        static  void show()
        {
            Console.WriteLine("enter your choice of 1.int / 2.float /3.boolean/-1.exit");
        }
        public Exercise1()
        {
            Console.WriteLine("enter the choice that you want to convert");
            Console.WriteLine(" 1. convert to int");
            Console.WriteLine(" 2. convert to float");
            Console.WriteLine(" 3. convert to boolean");
            Console.WriteLine("-1. exit.");
            int ch;
            do
            {
                ch = int.Parse(Console.ReadLine());
                switch (ch)
                {
                    case -1:
                        break;

                    case 1:
                        converToInt();
                        show();
                        break;
                    case 2:
                        converToFloat();
                        show();
                        break;
                    case 3:
                        converToBool();
                        show();
                        break;
                    default:
                        Console.WriteLine("enter right choice");
                        break;
                }
                


            } while (ch !=-1);
        }
        static void  converToInt()
        {
            try
            {
                Console.WriteLine(" enter an integer");
                 string input = Console.ReadLine();
                int v;
                if( int.TryParse(input,out v))
                {
                    Console.WriteLine(" the intiger number convertd using int.tryParse is:{0}" , v);
                }
                //int num = Convert.ToInt32(input);
                int num = int.Parse(input);
                Console.WriteLine(" the intiger number using parse is: {0}", num);
            }
            catch
            {
                Console.WriteLine("invalid input .please enter integer");
            }
           
        }
        static void converToFloat()
        {
            try
            {
                Console.WriteLine(" enter an float");
                string input = Console.ReadLine();
                //Float num = Convert.ToIntFloat(input);
                float num = float.Parse(input);
                Console.WriteLine(" the number using parse is {0} ", num);
                float w;
               if ( float.TryParse(input,out w))
                {
                    Console.WriteLine("the float number using try.parse :{0}", w);
                }
            }
            catch
            {
                Console.WriteLine("invalid input .please enter float");
            }
        }
        static void  converToBool()
        {
            try
            {
                Console.WriteLine(" enter true /false ");
                string input = Console.ReadLine();
                bool num = bool.Parse(input);
                Console.WriteLine(" the boolean value converted using bool.Parse is: {0} ", num);
            }
            catch
            {
                Console.WriteLine("invalid input .please enter Bool(true/false)");
            }

        }
    }
}
