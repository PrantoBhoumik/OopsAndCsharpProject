using System;
using System.Collections.Generic;


namespace Exercise_6
{
   public class Equipment2
    {

        private string name;
        private string description;
        private double maintenanceCost;
        public Equipment2(string name, string description, double maintenanceCost)
        {
            this.name = name;
            this.description = description;
            this.maintenanceCost = maintenanceCost;
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }


        public double MaintenanceCost
        {
            get { return maintenanceCost; }
            set { maintenanceCost = value; }
        }


    }

    class Mobile2 : Equipment2
    {
        private int distanceMoved;
        public Mobile2(string name, string description, double maintenanceCost)
            : base(name, description, maintenanceCost)
        {
            this.distanceMoved = 0;
        }

        public int DistanceMoved
        {
            get { return distanceMoved; }
            set { distanceMoved = value; }
        }


    }

    class Immobile2 : Equipment2
    {
        public Immobile2(string name, string description, double maintenanceCost)
            : base(name, description, maintenanceCost)
        {


        }
    }
    public class Exercise6
    {
        public static void CreateEquipment(List<Equipment2> equipments)
        {
            string name;
            string description;
            double maintenanceCost;
            int choice;
            Console.WriteLine("1. Create mobile equipment");
            Console.WriteLine("2. Create immobile equipment");
            Console.Write("Your choice: ");
            if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 2)
            {
                Console.WriteLine("\nSelect correct menu item.\n");
            }
            else
            {
                Console.Write("Enter the name: ");
                name = Console.ReadLine();
                Console.Write("Enter the description: ");
                description = Console.ReadLine();
                Console.Write("Enter the maintenance cost: ");
                if (!double.TryParse(Console.ReadLine(), out maintenanceCost) || maintenanceCost < 0)
                {
                    Console.WriteLine("\nEnter correct the maintenance cost>0.\n");
                }
                if (choice == 1)
                {
                    equipments.Add(new Mobile2(name, description, maintenanceCost));
                }
                if (choice == 2)
                {
                    equipments.Add(new Immobile2(name, description, maintenanceCost));
                }
                Console.WriteLine("\nA new equipment has been added.\n");
            }


        }

        public static void Showdetails(List<Equipment2> equipments)
        {


            if (equipments.Count > 0)
            {
                Console.WriteLine("\n{0,-15}{1,-15}{2,-25}{3,-35}{4,-15}", "No", "Type", "Name", "Description", "Cost");
                for (int i = 0; i < equipments.Count; i++)
                {
                    string type = "Immobile";
                    if (equipments[i] is Mobile2)
                    {
                        type = "Mobile";
                    }
                    Console.WriteLine("{0,-15}{1,-15}{2,-25}{3,-35}{4,-15}", (i + 1), type, equipments[i].Name, equipments[i].Description, equipments[i].MaintenanceCost);
                }
            }
            else
            {
                Console.WriteLine("\nYou have not added equipments yet.");
            }
            Console.WriteLine();
        }

        public static void ListAllMobileEquipment(List<Equipment2> equipments)
        {


            if (equipments.Count > 0)
            {
                int i = 0;
                Console.WriteLine("\n{0,-15}{1,-15}{2,-25}{3,-35}{4,-15}{5,-15}", "No", "Type", "Name", "Description", "Cost", "Distance moved");
                foreach (Equipment2 equipment in equipments.FindAll(e => e is Mobile2))
                {
                    Console.WriteLine("{0,-15}{1,-15}{2,-25}{3,-35}{4,-15}{5,-15}", (i + 1), "Mobile", equipment.Name, equipment.Description, equipment.MaintenanceCost, (((Mobile2)equipment).MaintenanceCost));
                    i++;
                }
            }
            else
            {
                Console.WriteLine("\nYou have not added equipments yet.");
            }
            Console.WriteLine();
        }

        public static void ListAllEquipmentNotBeenMovedTillNow(List<Equipment2> equipments)
        {


            if (equipments.Count > 0)
            {
                int i = 0;
                Console.WriteLine("\n{0,-10}{1,-10}{2,-20}{3,-30}{4,-10}", "No", "Type", "Name", "Description", "Cost");
                foreach (Equipment2 equipment in equipments.FindAll(e => e is Mobile2 && (((Mobile2)e).DistanceMoved) == 0))
                {
                    Console.WriteLine("{0,-10}{1,-10}{2,-20}{3,-30}{4,-10}", (i + 1), "Mobile", equipment.Name, equipment.Description, equipment.MaintenanceCost);
                    i++;
                }
            }
            else
            {
                Console.WriteLine("\nYou have not added equipments yet.");
            }
            Console.WriteLine();
        }
        public static void MoveEquipment(List<Equipment2> equipments)
        {
            if (equipments.Count > 0)
            {
                ListAllEquipment(equipments);
                int selectedMobileEquipment = -1;
                Console.Write("Select the mobile equipment: ");
                if (!int.TryParse(Console.ReadLine(), out selectedMobileEquipment) || selectedMobileEquipment < 0 || selectedMobileEquipment > equipments.Count)
                {
                    Console.WriteLine("\nSelect correct mobile equipment.\n");
                }
                else
                {
                    if (equipments[selectedMobileEquipment - 1] is Mobile2)
                    {
                        int distanceMoved;
                        Console.Write("Enter the distance to move mobile equipment: ");
                        if (!int.TryParse(Console.ReadLine(), out distanceMoved) || distanceMoved < 0)
                        {
                            Console.WriteLine("\nEnter correct the distance to move>0.\n");
                        }
                        else
                        {
                            ((Mobile2)equipments[selectedMobileEquipment - 1]).DistanceMoved = distanceMoved;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nSelect mobile equipment.\n");
                    }
                }
            }
            else
            {
                Console.WriteLine("\nYou have not added equipments yet.");
            }
            Console.WriteLine();


        }

        public static void ListAllEquipment(List<Equipment2> equipments)
        {
            if (equipments.Count > 0)
            {
                Console.WriteLine("\n{0,-10}{1,-20}{2,-10}", "No", "Name", "Description");
                for (int i = 0; i < equipments.Count; i++)
                {
                    Console.WriteLine("{0,-10}{1,-20}{2,-10}", (i + 1), equipments[i].Name, equipments[i].Description);
                }
            }
            else
            {
                Console.WriteLine("\nYou have not added equipments yet.");
            }
            Console.WriteLine();
        }
        public static void ListAllImmobileEquipment(List<Equipment2> equipments)
        {
            if (equipments.Count > 0)
            {
                int i = 0;
                Console.WriteLine("\n{0,-10}{1,-10}{2,-20}{3,-30}{4,-10}", "Number", "Type", "Name", "Description", "Cost");
                foreach (Equipment2 equipment in equipments.FindAll(e => e is Immobile2))
                {
                    Console.WriteLine("{0,-10}{1,-10}{2,-20}{3,-30}{4,-10}", (i + 1), "Immobile", equipment.Name, equipment.Description, equipment.MaintenanceCost);
                    i++;
                }
            }
            else
            {
                Console.WriteLine("\nYou have not added equipments yet.");
            }
            Console.WriteLine();
        }

        public static void DeleteEquipment(List<Equipment2> equipments)
        {
            if (equipments.Count > 0)
            {
                ListAllEquipment(equipments);
                int selectedMobileEquipment = -1;
                Console.Write("Select the equipment: ");
                if (!int.TryParse(Console.ReadLine(), out selectedMobileEquipment) || selectedMobileEquipment < 0 || selectedMobileEquipment > equipments.Count)
                {
                    Console.WriteLine("\nSelect correct equipment.\n");
                }
                else
                {
                    equipments.RemoveAt(selectedMobileEquipment - 1);
                    Console.WriteLine("\nThe equipment has been deleted.\n");
                }
            }
            else
            {
                Console.WriteLine("\nYou have not added equipments.");
            }
            Console.WriteLine();
        }

        public Exercise6()
        {
            List<Equipment2> equipments = new List<Equipment2>();

            int choice = -1;
            while (choice != 12)
            {
                Console.WriteLine("1. Create an equipment – mobile and immobile");
                Console.WriteLine("2.  Delete an equipment");
                Console.WriteLine("3. Move – mobile");
                Console.WriteLine("4. List all equipment");
                Console.WriteLine("5. Show details");
                Console.WriteLine("6. List all mobile equipment");
                Console.WriteLine("7. List all Immobile equipment");
                Console.WriteLine("8. List all equipment that have not been moved till now");
                Console.WriteLine("9. Delete all equipment");
                Console.WriteLine("10. Delete all immobile equipment");
                Console.WriteLine("11. Delete all mobile equipment");
                Console.WriteLine("12. Exit");
                Console.Write("Your choice: ");
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Plz Select correct item.\n");
                }
                else
                {
                    switch (choice)
                    {
                        case 1://Create an equipment -> mobile and immobile
                            CreateEquipment(equipments);
                            break;
                        case 2:
                            DeleteEquipment(equipments);
                            break;
                        case 3:
                            MoveEquipment(equipments);
                            break;
                        case 4:
                            ListAllEquipment(equipments);
                            break;
                        case 5:
                            Showdetails(equipments);
                            break;
                        case 6:
                            ListAllMobileEquipment(equipments);
                            break;
                        case 7:
                            ListAllImmobileEquipment(equipments);
                            break;
                        case 8:
                            ListAllEquipmentNotBeenMovedTillNow(equipments);
                            break;
                        case 9:
                            //Delete all equipment
                            equipments.Clear();
                            Console.WriteLine("All equipments have been deleted.\n");
                            break;
                        case 10:
                            equipments.RemoveAll(e => e is Immobile2);
                            Console.WriteLine("All Immobile equipments have been deleted.\n");
                            break;
                        case 11:
                            equipments.RemoveAll(e => e is Mobile2);
                            Console.WriteLine("All Mobile equipments have been deleted.\n");
                            break;
                        case 12:
                            //exit
                            break;
                        default:
                            Console.WriteLine("\nSelect correct option.\n");
                            break;
                    }
                }
            }
        }
    }

}
