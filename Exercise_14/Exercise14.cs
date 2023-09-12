using System;
using System.Collections.Generic;


namespace Exercise_14
{
    class Product : IEquatable<int>
    {
        private int id;
        private float price;
        private bool isDefective;

        //public Product() { }

        public Product(int id, float price, bool isDefective)
        {
            this.id = id;
            this.price = price;
            this.isDefective = isDefective;
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public float Price
        {
            get { return price; }
            set { price = value; }
        }
        public bool IsDefective
        {
            get { return isDefective; }
            set { isDefective = value; }
        }
        public bool Equals(int id)
        {
            return this.id == id;
        }
    }
   public class Exercise14
    {
        public Exercise14()
        {
            Dictionary<Product, int> products = new Dictionary<Product, int>();

            int ch = -1;
            while (ch != 6)
            {
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Remove Product");
                Console.WriteLine("3. Update Product Quantity");
                Console.WriteLine("4. Display total value of the inventory");
                Console.WriteLine("5. Display all Product Details");
                Console.WriteLine("6. Exit");
                Console.WriteLine("Enter Your choice : ");
                ch = int.Parse(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        AddProduct();
                        break;
                    case 2:
                        listAllProduct(products);
                        RemoveProduct();
                        break;
                    case 3:
                        listAllProduct(products);
                        UpdateProductQuantity();
                        break;
                    case 4:
                        TotalValue();
                        break;
                    case 5:
                        listAllProduct(products);
                        break;
                    case 6:
                        //exit
                        products.Clear();
                        break;
                }
            }

            int id, quantities;
            Product selectedProduct;
            // add Product
            void AddProduct()
            {
                try
                {
                    id = (new Random()).Next(1000, 10000);
                    Console.WriteLine("The product ID: {0}", id);
                    Console.Write("Enter the product price: ");
                    float price = float.Parse(Console.ReadLine());
                    Console.Write("Enter the product quantities: ");
                    quantities = int.Parse(Console.ReadLine());
                    Console.Write("Is this product defective? YES-press (y) else press (any key): ");
                    string answer = Console.ReadLine();
                    bool isDefective = false;
                    if (answer.ToLower().CompareTo("y") == 0)
                    {
                        isDefective = true;
                        Console.WriteLine("Defective Product are not Added in the inventory\n");
                    }
                    Product p = new Product(id, price, isDefective);
                    if (!p.IsDefective)
                    {
                        products.Add(p, quantities);
                        Console.WriteLine("A new product has been added.\n");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("plz Enter valid input");
                }

            }

            // Remove
            void RemoveProduct()
            {
                try
                {
                    Console.Write("Enter the product ID to remove: ");
                    id = int.Parse(Console.ReadLine());
                    selectedProduct = null;
                    foreach (var product in products)
                    {
                        if (product.Key.Id == id)
                        {
                            selectedProduct = product.Key;
                            break;
                        }
                    }
                    if (selectedProduct != null)
                    {
                        products.Remove(selectedProduct);
                        Console.WriteLine("The product is removed.\n");
                    }
                    else
                    {
                        Console.WriteLine("the product does not exist.\n");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("plz Enter valid input");
                }
            }

            // update
            void UpdateProductQuantity()
            {
                try
                {
                    Console.Write("Enter the product ID to update product quantity: ");
                    id = int.Parse(Console.ReadLine());
                    selectedProduct = null;
                    foreach (var product in products)
                    {
                        if (product.Key.Id == id)
                        {
                            selectedProduct = product.Key;
                            break;
                        }
                    }
                    if (selectedProduct != null)
                    {
                        Console.Write("Enter a new product quantities: ");
                        quantities = int.Parse(Console.ReadLine());
                        products[selectedProduct] = quantities;
                        Console.WriteLine("\nThe product quantity has been updated.\n");
                    }
                    else
                    {
                        Console.WriteLine("\nA product does not exist.\n");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Oops!! Enter valid input");
                }
            }

            // calculate total value of inventory
            void TotalValue()
            {
                float total = 0;
                foreach (var product in products)
                {
                    total += product.Key.Price * product.Value;
                }
                Console.WriteLine("\nThe total value of the inventory: {0}", total.ToString("N2"));
            }

            // detail list of all product present in the inventory
            static void listAllProduct(Dictionary<Product, int> products)
            {
                if (products.Count > 0)
                {
                    Console.WriteLine("\n{0,-15}{1,-15}{2,-25}", "Prodict ID", "Price", "Quantity");
                    Console.WriteLine("{0,-15}{1,-15}{2,-25}", "*********", "*****", "*******");

                    foreach (var product in products)
                    {
                        Console.WriteLine("{0,-15}{1,-15}{2,-25}", product.Key.Id, product.Key.Price, product.Value);
                    }
                }
                else
                {
                    Console.WriteLine("\nYou have not added any Product yet.");
                }
                Console.WriteLine();
            }
        }
    }
}
