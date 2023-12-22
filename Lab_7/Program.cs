using Lab_7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.Json;


namespace Lab_7
{
    public class Program
    {
        public static List<Product> productsList = new List<Product>();
        public static int N;

        public static void Main()
        {
            N = CheckN();

            int choice;

            do
            {
                DisplayMenu();
                choice = GetUserChoice();

                switch (choice)
                {
                    case 1:
                        AddObject();
                        break;
                    case 2:
                        Console.WriteLine(DisplayInformation());
                        break;
                    case 3:
                        FindObject();
                        break;
                    case 4:
                        DeleteObject();
                        break;
                    case 5:
                        BehaviorDemonstration();
                        break;
                    case 6:
                        DemonstrateStaticMethods();
                        break;
                    case 7:
                        SaveToFilesMenu();
                        break;
                    case 8:
                        LoadFromFilesMenu();
                        break;
                    case 9:
                        ClearObjects();
                        break;
                    case 0:
                        Console.WriteLine("Exit");
                        break;
                    default:
                        Console.WriteLine("\r\nWrong choice. Try again.");
                        break;
                }

            } while (choice != 0);
        }

        public static void DisplayMenu()
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Add object");
            Console.WriteLine("2. Display information");
            Console.WriteLine("3. Find an object");
            Console.WriteLine("4. Delete the object");
            Console.WriteLine("5. Behavior demonstration");
            Console.WriteLine("6. Demonstration of static methods");
            Console.WriteLine("7. Save to file");
            Console.WriteLine("8. Load from files");
            Console.WriteLine("9. Clear objects");
            Console.WriteLine("0. Exit");
        }

        public static int GetUserChoice()
        {
            Console.Write("\r\nYour choice: ");
            return Convert.ToInt32(Console.ReadLine());
        }


        public static void SaveToFilesMenu()
        {
            Console.WriteLine("\nSave collection to a file:");
            Console.WriteLine("1. Save to CSV file");
            Console.WriteLine("2. Save to JSON file");
            int saveChoice = GetUserChoice();

            switch (saveChoice)
            {
                case 1:
                    SaveToCSVOrTextFile();
                    break;
                case 2:
                    SaveToJSONFile();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        public static void LoadFromFilesMenu()
        {
            Console.WriteLine("\nLoad collection from a file:");
            Console.WriteLine("1. Load from CSV/Text file");
            Console.WriteLine("2. Load from JSON file");
            int loadChoice = GetUserChoice();

            switch (loadChoice)
            {
                case 1:
                    LoadFromCSVOrTextFile();
                    break;
                case 2:
                    LoadFromJSONFile();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        public static void SaveToCSVOrTextFile()
        {
            using (StreamWriter file = new StreamWriter("products.csv"))
            {
                foreach (Product product in productsList)
                {
                    string line = $"{product.Name}\t{product.Price}\t{product.StockQuantity}\t{product.Category}";
                    file.WriteLine(line);
                }
            }
            Console.WriteLine("Collection saved to CSV file.");
        }

        public static void LoadFromCSVOrTextFile()
        {
            if (File.Exists("products.csv"))
            {
                using (StreamReader file = new StreamReader("products.csv"))
                {
                    string line;
                    while ((line = file.ReadLine()) != null)
                    {
                        string[] values = line.Split('\t');
                        if (values.Length == 4)
                        {
                            string name = values[0];
                            double price = double.Parse(values[1]);
                            int stockQuantity = int.Parse(values[2]);
                            Category category = (Category)Enum.Parse(typeof(Category), values[3]);
                            Product loadedProduct = new Product(name, price, stockQuantity, category);
                            productsList.Add(loadedProduct);
                        }
                    }
                    Console.WriteLine("Collection loaded from CSV file.");
                }
            }
            else
            {
                Console.WriteLine("TSV file not found.");
            }
        }

        public static void SaveToJSONFile()
        {
            string json = JsonSerializer.Serialize(productsList);
            File.WriteAllText("products.json", json);
            Console.WriteLine("Collection saved to JSON file.");
        }

        public static void LoadFromJSONFile()
        {
            if (File.Exists("products.json"))
            {
                string json = File.ReadAllText("products.json");
                List<Product> loadedProducts = JsonSerializer.Deserialize<List<Product>>(json);

                if (loadedProducts != null)
                {
                    productsList.AddRange(loadedProducts);
                    Console.WriteLine("Collection loaded from JSON file.");
                }
                else
                {
                    Console.WriteLine("Error loading from JSON file.");
                }
            }
            else
            {
                Console.WriteLine("JSON file not found.");
            }
        }

        public static void ClearObjects()
        {
            productsList.Clear();
            Console.WriteLine("Collection cleared.");
        }

        public static void AddObject()
        {
            if (productsList.Count < N)
            {
                Console.WriteLine("Choose a constructor for creating a product:");
                Console.WriteLine("1) Default Constructor");
                Console.WriteLine("2) Constructor with name and price");
                Console.WriteLine("3) Constructor with name, price, stock quantity, and category");
                int choice = Convert.ToInt32(Console.ReadLine());
                Product newProduct;

                switch (choice)
                {
                    case 1:
                        newProduct = new Product();
                        break;
                    case 2:
                        Console.Write("Enter product name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter price: ");
                        double price = double.Parse(Console.ReadLine());
                        newProduct = new Product(name, price);
                        break;
                    case 3:
                        Console.Write("Enter product name: ");
                        string nameWithCategory = Console.ReadLine();
                        Console.Write("Enter price: ");
                        double priceWithCategory = double.Parse(Console.ReadLine());
                        Console.Write("Enter stock quantity: ");
                        int stockQuantityWithCategory = int.Parse(Console.ReadLine());
                        Console.WriteLine("Choose category (0 for Electronics, 1 for Clothing, 2 for Food): ");
                        int categoryChoice = int.Parse(Console.ReadLine());
                        Category category = (Category)categoryChoice;
                        newProduct = new Product(nameWithCategory, priceWithCategory, stockQuantityWithCategory, category);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Using the default constructor.");
                        newProduct = new Product();
                        break;
                }

                Product.AddProduct(productsList, newProduct);
            }
            else
            {
                Console.WriteLine("Maximum number of N.");
            }
        }

        public static string DisplayInformation()
        {
            string result = "\nProduct information:\n";

            if (productsList.Count > 0)
            {
                foreach (Product product in productsList)
                {
                    result += product.ToString() + "\n";
                }
            }
            else
            {
                result += "No products added.\n";
            }

            return result;
        }
        public static void FindObject()
        {
            Console.WriteLine("Select a characteristic to search for (price/stock quantity): ");
            string choice = Console.ReadLine();

            switch (choice.ToLower())
            {
                case "price":
                    Console.Write("Enter price: ");
                    double price = CheckPrice();
                    var foundProductsByPrice = Product.FindProductsByPrice(productsList, price);
                    Console.WriteLine(DisplayFoundProducts(foundProductsByPrice));

                    break;
                case "stock quantity":
                    Console.Write("Enter stock quantity: ");
                    int stockQuantity = CheckStockQuantity();
                    var foundProductsByStockQuantity = Product.FindProductsByStockQuantity(productsList, stockQuantity);
                    Console.WriteLine(DisplayFoundProducts(foundProductsByStockQuantity));
                    break;
                default:
                    Console.WriteLine("The search option is not selected correctly.");
                    break;
            }
        }

        public static void DeleteObject()
        {
            Console.Write("Enter the index of the product you want to delete (1, 2, 3, ...): ");
            int index = Convert.ToInt32(Console.ReadLine()) - 1;
            if (Product.DeleteProduct(productsList, index))
            {
                Console.WriteLine("Product removed!");
            }
            else
            {
                Console.WriteLine("Invalid index. Product not removed.");
            }
        }

        public static void BehaviorDemonstration()
        {
            AddObject();
            DisplayInformation();
            FindObject();
            FindObject();
            DeleteObject();
        }

        public static void DemonstrateStaticMethods()
        {
            foreach (Product product in productsList)
            {
                Console.WriteLine(product.ToString());
            }
            Product.CalculateTotalValue(productsList);
            Console.WriteLine($"\nTotal value of products: {Product.TotalValue}");
        }


        public static string DisplayFoundProducts(List<Product> foundProducts)
        {
            if (foundProducts.Count > 0)
            {
                string result = "Found products:\n";
                foreach (Product product in foundProducts)
                {
                    result += product.ToString() + "\n";
                }
                return result;
            }
            else
            {
                return "No products found.";
            }
        }

        public static int CheckN()
        {
            int n;

            do
            {
                Console.Write("Enter the value of N (N > 0): ");
                n = int.Parse(Console.ReadLine());
            } while (n <= 0);

            return n;
        }
        //коміт 1
        public static double CheckPrice()
        {
            double price;
            bool validInput = false;

            do
            {
                Console.Write("Enter price (1-1000): ");
                string input = Console.ReadLine();

                if (double.TryParse(input, out price) && price >= 1 && price <= 1000)
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }
            } while (!validInput);

            return price;
        }

        public static int CheckStockQuantity()
        {
            int stockQuantity;
            bool validInput = false;

            do
            {
                Console.Write("Enter stock quantity (0-1000): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out stockQuantity) && stockQuantity >= 0 && stockQuantity <= 1000)
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }
            } while (!validInput);

            return stockQuantity;
        }
    }
}
