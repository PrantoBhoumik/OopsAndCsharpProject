using System;

namespace Exercise_4
{
    public enum type { immobile, mobile}
    public class Exercise4
    {
        static void show ()
        {
            Console.WriteLine("Enter the choice of equipment or exit");
        }
       public abstract class Equipments
        {
            protected  String name;
            protected string description;
            protected int distanceMoved=0 ;
            protected int maintainCost =0;
            protected type EquType;
            protected virtual void moveBy(int distanceMoved){ }
        }
        class mobile : Equipments
        {
            int whiles;
            protected  override void moveBy(int distanceMoved)
            {
                maintainCost = whiles * distanceMoved;
             
            }
            
            public void createMobile()
            {
                Console.WriteLine("Enter the name of mobile");
                name=Console.ReadLine();
                Console.WriteLine("enter the Description");
                description = Console.ReadLine();
                Console.WriteLine("Enter number of wheels");
                whiles = int.Parse(Console.ReadLine());
            repeat:
                try
                {
                    Console.WriteLine("Enter the distance that moved");
                   distanceMoved +=int.Parse(Console.ReadLine());

                }
                catch
                {
                    Console.WriteLine("enter valid intiger input of distacne");
                    goto repeat;
                }
              moveBy(distanceMoved);
                EquType = type.mobile;
             
            }
            public void showdetailsMobile()
            {
                Console.WriteLine("---:The equipment description are :---");
                Console.WriteLine("Equipment name  :"+name); 
                Console.WriteLine("Type of equipment "+EquType);
                Console.WriteLine("The mobile description are :" +description);
                Console.WriteLine("The mobile description are :"+distanceMoved );
                Console.WriteLine("Maintain Cost is :"+maintainCost);
            }
           
        }
        class immobile : Equipments
        {
            int weight;
            protected override void  moveBy(int distanceMoved)
            {
                maintainCost = weight* distanceMoved;
               
            }

            public void createImmobile()
            {
                Console.WriteLine("Enter the name of immobile");
                name = Console.ReadLine();
                Console.WriteLine("Enter the Description");
                description = Console.ReadLine();
                Console.WriteLine("Enter the weight");
                weight = int.Parse(Console.ReadLine());
            repeat:
                try
                {
                    Console.WriteLine("Enter the distance that moved");
                    distanceMoved += int.Parse(Console.ReadLine());

                }
                catch
                {
                    Console.WriteLine("enter valid intiger input of distance");
                    goto repeat;
                }
                moveBy(distanceMoved);
                EquType = type.immobile;

            }
            public void showdetailsImmobile()
            {
                Console.WriteLine("---:The equipment description are :---");
                Console.WriteLine("Equipment name  :" + name);
                Console.WriteLine("Type of equipment " + EquType);
                Console.WriteLine("The immobile description are :" + description);
                Console.WriteLine("The immobile description are :" + distanceMoved);
                Console.WriteLine("Maintain Cost is :" + maintainCost);
            }
        }
        
       
       
        public Exercise4()
        {
            immobile immobile1 = new immobile();
            mobile mobile1 = new mobile();
            Console.WriteLine(" ---:Here are the equlipments:---");
            Console.WriteLine(" Press 1. for create immobile equipmen");
            Console.WriteLine(" Press 2. for create mobile equipment");
            Console.WriteLine(" Press 3.  for Exit ");
            int ch;
            do
            {  ch =int.Parse( Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        immobile1.createImmobile();
                        immobile1.showdetailsImmobile();
                        show();
                        break;
                    case 2:
                        mobile1.createMobile();
                        mobile1.showdetailsMobile();
                        show();
                        break;
                    case 3:
                        break;
                    default:
                        Console.WriteLine("enter right choice");
                        show();
                        break;
                }

            } while (ch != 3);
        }
    }
}
