using System;

namespace Exercise_5

{
    public enum type { Rubber,Mallerd,Readhead}
    interface IDuck
    {

        public void fly();
        public void Quack();
         

        public static  void CreateDuckAndShowDetails()
        {
            int ch = -1;

            while(ch != 4)
            {
            
                Console.WriteLine(" 1. cerate a A Rubber ");
                Console.WriteLine(" 2. create a Mallerd");
                Console.WriteLine(" 3. create a Readhead");
                Console.WriteLine(" 4. exit");

                if (!int.TryParse(Console.ReadLine(), out ch))
                {
                    Console.WriteLine("enter right choice");
                }

                else
                {
                    switch (ch)
                    {
                        case 1:
                            Rubber.CreateRubber();
                          
                            break;
                        case 2:
                            Mallerd.CreateMallerd();
                            break;
                        case 3:
                            RedHead.CreateReadHead();
                            break;
                        case 4:
                            break;
                        default:
                            Console.WriteLine("Enter write choice");
                            break;

                    }
                }
            }
        }
       

    }
    class Rubber : IDuck
    {
        protected type typeOfDuck = type.Rubber ;
        protected int weight;
        protected int noOfWings;
        public static void CreateRubber()
        {
            Rubber obj = new Rubber();
            obj.buildRubber();
            obj.showRubber();

        }


        public  void buildRubber()
        
        {
       
            Console.WriteLine("Enter the weight of Rubber");
            int w; 
           if( !int.TryParse(Console.ReadLine(), out w))
            {
                Console.WriteLine("Enter intiger value of weight");
            }
            weight = w; 
            Console.WriteLine("Enter the wings of Rubber");
            
            if (!int.TryParse(Console.ReadLine(), out w))
            {
                Console.WriteLine("Enter intiger value of wings");
            }
             noOfWings = w;
          
           
            
           

        }
       public void fly()
        {
            Console.WriteLine("Rubber duck dont fly");
        }
       public void  Quack()
        {
            Console.WriteLine(" Rubber duck dont Squeak");
        }
       public void showRubber()
        {
            Console.WriteLine(" :Details of Rubber:  ");
            Console.WriteLine(" DUCK type :" + typeOfDuck);
            Console.WriteLine("Rubber weight:", +weight);
            Console.WriteLine("Rubber number of wings ", +noOfWings);
            Quack();
            fly();

        }


    }
    class Mallerd : IDuck
    {
        protected type typeOfDuck = type.Mallerd;
        protected int weight;
        protected int noOfWings;
        public static void CreateMallerd()
        {
            Mallerd obj = new Mallerd();
            obj.buildMallerd();
            obj.showMallerd();
        }

        public void buildMallerd()

        {

            Console.WriteLine("Enter the weight of Mallerd");
            int w;
            if (!int.TryParse(Console.ReadLine(), out w))
            {
                Console.WriteLine("Enter intiger value of weight");
            }
            weight = w;
            Console.WriteLine("Enter the wings of Mallerd");

            if (!int.TryParse(Console.ReadLine(), out w))
            {
                Console.WriteLine("Enter intiger value of wings");
            }
            noOfWings = w;
            
           

        }
       public void Quack()
        {
            Console.WriteLine(" Mallerd Qaack loud");
        }
       public void fly()
        {
            Console.WriteLine("Mallred duck fly fast");
        }
        void showMallerd()
        {
            Console.WriteLine(":Details of Mallerd:");
            Console.WriteLine(" DUCK type :" + typeOfDuck);
            Console.WriteLine($"Mallred weight:{weight}");
            Console.WriteLine($"Mallred number of wings :{noOfWings}");
            Quack();
            fly();

        }




    }
    class RedHead : IDuck
    {
        protected type typeOfDuck = type.Readhead;
        protected int weight;
        protected int noOfWings;
        public static void CreateReadHead()
        {
            RedHead obj = new RedHead();
            obj.buildReadHead();
            obj.showRedHead();

        }


        public void buildReadHead()

        {

            Console.WriteLine("Enter the weight of ReadHead");
            int w;
            if (!int.TryParse(Console.ReadLine(), out w))
            {
                Console.WriteLine("Enter intiger value of weight");
            }
            weight = w;
            Console.WriteLine("Enter the wings of ReadHead");

            if (!int.TryParse(Console.ReadLine(), out w))
            {
                Console.WriteLine("Enter intiger value of wings");
            }
            noOfWings = w;





        }
       public void fly()
        {
            Console.WriteLine("RedHead duck  fly slow");
        }
       public void Quack()
        {
            Console.WriteLine(" ReadHead duck Qack mild");
        }
       public void showRedHead()
        {
            Console.WriteLine(":Details of Redhead:");
            Console.WriteLine(" DUCK type :" + typeOfDuck);
            Console.WriteLine($"RedHead weight:{ weight}");
            Console.WriteLine($"RedHead number of wings {noOfWings}");
            Quack();
            fly();

        }


    }


    public class Exercise5
    {

        public Exercise5()
        {
            int ch;
            do
            {
          
                Console.WriteLine(" Here are the manu");
                Console.WriteLine(" 1. Create a duck and show deatils of a duck");
                Console.WriteLine(" 2. exit");
                Console.WriteLine(" Enter your Choice");
                
                ch = int.Parse(Console.ReadLine());




                switch (ch)
                {
                    case 1:
                        IDuck.CreateDuckAndShowDetails();
                        break;

                    case 2:
                        break;
                    default:
                        Console.WriteLine("Enter write choice");
                       
                        break;

                }

            } while (ch != 2);
           




        }
    }
}
