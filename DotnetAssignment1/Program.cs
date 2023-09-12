using Exercise_3;
using Exercise_1;
using Exercise_2;
using Exercise_4;
using Exercise_5;
using Exercise_6;
using Exercise_7;
using Exercise_8;
using Exercise_9;
using Exercise_10;
using Exercise_11;
using Exercise_12;
using Exercise_13;
using Exercise_14;
using Exercise_15;
using Exercise_16;
using Exercise_17;
using System;



namespace DotnetAssignment1
{
    class Program
    {   
        static void show()
        {
            Console.WriteLine("Enter the Choice of Exercise");
        }
        static void Main(string[] args)
        {
            Console.WriteLine(" Program By PRANTO BHOUMIK");
            Console.WriteLine("********************************");
            Console.WriteLine("     TITLE OF ALL EXERCISE      ");
            Console.WriteLine("     1.   Input from user and Convert it into int,float,double");
            Console.WriteLine("     2.   Differnce of == operation,Equals() && ReferenceEquals() Methods");
            Console.WriteLine("     3.   Print Prime Numbers Bitween Two ranges");
            Console.WriteLine("     4.   Our client is an equipment owner company");
            Console.WriteLine("     5.   DUCK ");
            Console.WriteLine("     6.   Maintain a list of equipment");
            Console.WriteLine("     7.   Maintain a list of ducks");
            Console.WriteLine("     8.   Implementation 1 for Priority Queue");
            Console.WriteLine("     9.   Implementation 2 of Priority Queue");
            Console.WriteLine("     10.  Implementation 3 of Priority Queue");
            Console.WriteLine("     11.  Create IsOdd IsEven IsPrime IsDivisibleBy extension");
            Console.WriteLine("     12.  Lambda and delegates");
            Console.WriteLine("     13.  Create extension methods on IEnumerable<T>");
            Console.WriteLine("     14.  Create a Product-Inventory software ");
            Console.WriteLine("     15.  Listen to its Collection Changed Event and display message on UI for each operation");
            Console.WriteLine("     16.  Get all the files from a given directory and perform the following actions");
            Console.WriteLine("     17.  Mathematics Game");
            Console.WriteLine("     Enter -1 to exit");
            int Choice;
            do
            {
                Choice = int.Parse(Console.ReadLine());

                switch (Choice)
                {
                    case -1:
                        break;
                    case 1:
                        Exercise1 Object1 = new Exercise1();
                        show();
                        break;
                   case 2:
                        Exercise2 Object2 = new Exercise2();
                        show();
                        break;
                   case 3:
                        Exercise3 Object3 = new Exercise3();
                        show();
                        break;
                  case 4:
                        Exercise4 Object4 = new Exercise4();
                        show();
                        break;
                   case 5:
                        Exercise5 Object5 = new Exercise5();
                        show();
                        break;
                    case 6:
                        Exercise6 Object6 = new Exercise6();
                        show();
                        break;
                    case 7:
                        Exercise7 Object7 = new Exercise7();
                        show();
                        break;
                     case 8:
                        Exercise8 Object8 = new Exercise8();
                        show();
                        break;
                    case 9:
                        Exercise9 Object9 = new Exercise9();
                        show();
                        break;
                   case 10:
                        Exercise10 Object10 = new Exercise10();
                        show();
                        break;
                   
                   case 11:
                        Exercise11 Object11 = new Exercise11();
                        show();
                        break;
                   case 12:
                        Exercise12 Object12 = new Exercise12();
                        show();
                        break;
                    case 13:
                        Exercise13 Object13 = new Exercise13();
                        show();
                        break;
                    case 14:
                        Exercise14 Object14 = new Exercise14();
                        show();
                        break;
                    case 15:
                        Exercise15 Object15 = new Exercise15();
                        show();
                        break;
                    case 16:
                        Exercise16 Object16 = new Exercise16();
                        show();
                        break;
                    case 17:
                        Exercise17 Object17 = new Exercise17();
                        show();
                        break;
                  
                    default:
                        Console.WriteLine("Plz Enter enter a valid key");
                        show();
                        break;
                }

            } while (Choice != -1);
            Console.WriteLine("Thanks !! Bye !!");

        }
    }
       
}   

