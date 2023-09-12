using System;


using System.Text;
using System.Collections.Generic;

namespace Exercise_7
{
    public enum DuckType { Rubber = 1, Mallard = 2, Redhead = 3, All = 4 };
   public class Exercise7
    {
        public Exercise7()
        {
            List<Duck2> ducks = new List<Duck2>();
            int choise = -1;
            while (choise != 7)
            {
                Console.WriteLine("----------------------------------------------------------------------");
                Console.WriteLine("                              Ducks                                   ");
                Console.WriteLine("----------------------------------------------------------------------");
                Console.WriteLine("\n     1. Create Duck");
                Console.WriteLine("\n     2. Show Ducks");
                Console.WriteLine("\n     3. Delete Duck");
                Console.WriteLine("\n     4. Delete All Ducks");
                Console.WriteLine("\n     5. Sort Ducks in increasing order of their weights");
                Console.WriteLine("\n     6. Sort Ducks in increasing order of number of wings");
                Console.WriteLine("\n     7. Exit");
                Console.WriteLine("----------------------------------------------------------------------");
                Console.Write("\n      Enter Your Choice : ");
                if (!int.TryParse(Console.ReadLine(), out choise))
                {
                    Console.WriteLine("\n Invalid Input! Try Agian...");
                }
                else
                {
                    switch (choise)
                    {
                        case 1:
                            creatDuck(ducks);
                            break;
                        case 2:
                            Console.WriteLine("\nSelect Type of Duck \n 1. Rubber \n 2. Mallard \n 3. RedHead \n 4. ALL Ducks ");
                            Console.Write(" Choose duck Type to show: ");
                            int duckType = Convert.ToInt32(Console.ReadLine());

                            if (duckType.Equals((int)DuckType.Rubber))
                            {
                                listDucks(ducks, DuckType.Rubber);
                            }
                            else if (duckType.Equals((int)DuckType.Mallard))
                            {
                                listDucks(ducks, DuckType.Mallard);
                            }
                            else if (duckType.Equals((int)DuckType.Redhead))
                            {
                                listDucks(ducks, DuckType.Redhead);
                            }
                            else if (duckType.Equals((int)DuckType.All))
                            {
                                listDucks(ducks, DuckType.All);
                            }
                            else
                            {
                                Console.WriteLine(" Invalid duck type selected...");
                            }
                            break;
                        case 3:
                            deleteDuck(ducks);
                            break;
                        case 4:
                            ducks.Clear();
                            Console.WriteLine("\nvAll Ducks have been deleted.\n");
                            break;
                        case 5:
                            sortByWeight(ducks);
                            break;
                        case 6:
                            sortByNoOfWings(ducks);
                            break;
                        case 7:
                            break;
                        default:
                            Console.WriteLine(" Invalid Option Selected! Try Agian...");
                            break;
                    }
                }
            }

        }
        static void creatDuck(List<Duck2> ducks)
        {
            int duckType;
            Duck2 d = new Duck2();
            Console.WriteLine("\nSelect Type of Duck \n 1. Rubber \n 2. Mallard \n 3. RedHead ");
            Console.Write(" Choose duck Type: ");
            duckType = Convert.ToInt32(Console.ReadLine());

            if (duckType.Equals((int)DuckType.Rubber))
            {
                ducks.Add(new Rubber(d.noOfWings, d.weight2));
                Console.WriteLine("\n Duck created successfully...");
            }
            else if (duckType.Equals((int)DuckType.Mallard))
            {
                ducks.Add(new Mallard(d.noOfWings, d.weight2));
                Console.WriteLine("\n Duck created successfully...");
            }
            else if (duckType.Equals((int)DuckType.Redhead))
            {
                ducks.Add(new RedHead(d.noOfWings, d.weight2));
                Console.WriteLine("\n Duck created successfully...");
            }
            else
            {
                Console.WriteLine(" Invalid duck type selected...");
            }
        }

        static void deleteDuck(List<Duck2> ducks)
        {
            listDucks(ducks);
            int selectedDuck = -1;
            Console.Write(" Select the Duck you want to delete: ");
            if (!int.TryParse(Console.ReadLine(), out selectedDuck) || selectedDuck < 0 || selectedDuck > ducks.Count)
            {
                Console.WriteLine("\n Invalid Input! try agian... \n");
            }
            else
            {
                ducks.RemoveAt(selectedDuck - 1);
                Console.WriteLine("\n The Duck has been deleted.\n");
            }
            Console.WriteLine();
        }

        static void sortByWeight(List<Duck2> ducks)
        {
            List<Duck2> duckList = ducks.GetRange(0, ducks.Count);
            Duck2 minDuck = duckList[0];
            for (int i = 0; i < duckList.Count - 1; i++)
            {
                for (int j = i + 1; j < duckList.Count; j++)
                {
                    if (duckList[i].weight2 > duckList[j].weight2)
                    {
                        minDuck = duckList[i];
                        duckList[i] = duckList[j];
                        duckList[j] = minDuck;
                    }
                }
            }
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("             Ducks Sorted in increasing order of weights              ");
            listDucks(duckList);
        }
       static void sortByNoOfWings(List<Duck2> ducks)
        {
            List<Duck2> duckList = ducks.GetRange(0, ducks.Count);
            Duck2 minDuck = duckList[0];
            for (int i = 0; i < duckList.Count - 1; i++)
            {
                for (int j = i + 1; j < duckList.Count; j++)
                {
                    if (duckList[i].noOfWings > duckList[j].noOfWings)
                    {
                        minDuck = duckList[i];
                        duckList[i] = duckList[j];
                        duckList[j] = minDuck;
                    }
                }
            }
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("         Ducks Sorted in increasing order of number of wings          ");
            listDucks(duckList);
        }

       public static void listDucks(List<Duck2> duck, DuckType filter = DuckType.All)
        {
            if (filter != DuckType.All)
                duck = duck.FindAll(d => d.type == filter);
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("                  Showing {0} Type of Ducks                            ", filter);
            Console.WriteLine("----------------------------------------------------------------------");
            if (duck.Count > 0)
            {
                for (int i = 0; i < duck.Count; i++)
                {
                    Console.WriteLine(" No. " + (i + 1));
                    duck[i].showDetails();
                    Console.WriteLine(" Details of Duck : ");
                    duck[i].fly();
                    duck[i].quack();
                    Console.WriteLine("----------------------------------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine(" You have not added equipments yet.");
                Console.WriteLine("----------------------------------------------------------------------");
            }
        }
    }

   public class Duck2
    {
        public int noOfWings, weight2;
        public DuckType type;
        public Duck2(int noWing = 0, int duckweight = 0)
        {
            noOfWings = noWing;
            weight2 = duckweight;

            if (noWing == 0)
            {
                getDetails();
            }
        }
        public virtual void fly() { }
        public virtual void quack() { }

        public virtual void getDetails()
        {
            Console.Write("\n Enter Weight of Duck : ");
            weight2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("\n Enter No. of wings : ");
            noOfWings = Convert.ToInt32(Console.ReadLine());
        }
        public virtual void showDetails() { }

    }

    class Rubber : Duck2
    {
        public Rubber(int nowings, int duckweight)
            : base(nowings, duckweight)
        {
            type = DuckType.Rubber;
        }

        public override void fly()
        {
            Console.WriteLine(" Duck Can't Fly");
        }
        public override void quack()
        {
            Console.WriteLine(" Duck Can't Quack");
        }
        public override void showDetails()
        {
            Console.WriteLine(" Type of Duck is : " + type);
            Console.WriteLine(" Duck has " + base.noOfWings + " wings");
            Console.WriteLine(" Duck has " + base.weight2 + " weight");
        }
    }
    class Mallard : Duck2
    {
        public Mallard(int nowings, int duckweight)
            : base(nowings, duckweight)
        {
            type = DuckType.Mallard;
        }

        public override void fly()
        {
            Console.WriteLine(" Duck Flies Fast");
        }
        public override void quack()
        {
            Console.WriteLine(" Duck Quack Loud");
        }
        public override void showDetails()
        {
            Console.WriteLine(" Type of Duck is : " + type);
            Console.WriteLine(" Duck has " + base.noOfWings + " wings");
            Console.WriteLine(" Duck has " + base.weight2 + " weight");
        }
    }
    class RedHead : Duck2
    {
        public RedHead(int nowings, int duckweight)
            : base(nowings, duckweight)
        {
            type = DuckType.Redhead;
        }

        public override void fly()
        {
            Console.WriteLine(" Duck Flies Slow");
        }
        public override void quack()
        {
            Console.WriteLine(" Duck Quack Mild");
        }
        public override void showDetails()
        {
            Console.WriteLine(" Type of Duck is : " + type);
            Console.WriteLine(" Duck has " + base.noOfWings + " wings");
            Console.WriteLine(" Duck has " + base.weight2 + " weight");
        }
    }

}
