using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7
{
    public class Product
    {
        private string _name;
        private double _price;
        private int _stockQuantity;
        private Category _category;

        private static int _objectCount;
        private static double _totalValue;

        public static void CalculateTotalValue(List<Product> productList)
        {
            _totalValue = 0;
            foreach (Product product in productList)
            {
                _totalValue += product.Price * product.StockQuantity * 1.2;
            }
        }

        public string ToStringCSV()
        {
            return $"{Name},{Price},{StockQuantity},{(int)Category}";
        }

        public static bool TryParseCSV(string s, out Product obj)
        {
            obj = null;

            string[] parts = s.Split(',');
            if (parts.Length != 4)
                return false;

            string name = parts[0];
            double price = double.Parse(parts[1]);
            int stockQuantity = int.Parse(parts[2]);
            Category category = (Category)int.Parse(parts[3]);

            obj = new Product(name, price, stockQuantity, category);
            return true;
        }

        public static Product Parse(string s)
        {
            string[] parts = s.Split(';');

            if (parts.Length != 4)
            {
                throw new ArgumentException("The string must contain 4 parts separated by the character ';'.");
            }

            string name = parts[0];
            double price = double.Parse(parts[1]);
            int stockQuantity = int.Parse(parts[2]);
            Category category = (Category)Enum.Parse(typeof(Category), parts[3]);

            return new Product(name, price, stockQuantity, category);

        }


        public static bool TryParse(string s, out Product obj)
        {
            obj = null;

            try
            {
                obj = Parse(s);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public override string ToString()
        {
            return $"Product's name: {Name}, Price: {Price}, Stock quantity: {StockQuantity}, Category: {(int)Category}";
        }


        public static int ObjectCount
        {
            get { return _objectCount; }
        }
        public static double TotalValue
        {
            get { return _totalValue; }
            private set { _totalValue = value; }
        }






        public Category Category
        {
            get { return _category; }
            set { _category = value; }
        }
        public Product(string name = "Product1", double price = 100, int stockQuantity = 1, Category category = default)
        {
            _name = name;
            _price = price;
            _stockQuantity = stockQuantity;
            _category = category;
            _objectCount++;
        }
        public Product() : this("Name", 1, 12, default)
        { }
        public Product(string name, double price) : this(name, price, 10, default)
        { }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    _name = value;
                else
                    _name = "Name";
            }
        }

        public double Price
        {
            get { return _price; }
            set
            {
                if (value >= 1 && value <= 1000)
                    _price = value;
                else
                    _price = 1.1;
            }
        }
        public int StockQuantity
        {
            get { return _stockQuantity; }
            set
            {
                if (value >= 0 && value <= 1000)
                    _stockQuantity = value;
                else _stockQuantity = 0;
            }
        }
        public double TotalValueWithTax
        {
            get { return Price * 1.2; }
        }
        public int SoldQuantity { get; private set; } = 0;


        //public void findProduct(List<Product> productList, double price)
        //{
        //    foreach (Product product in productList)
        //    {
        //        if (product._price == price)
        //        {
        //            Console.WriteLine($"Product's name: {product.Name}, Price: {product.Price}, Stock quantity: {product.StockQuantity}, Category: {product.Category}");
        //            return;
        //        }
        //    }
        //    Console.WriteLine("Product wasn't found");

        //}

        //public void findProduct(List<Product> productList, int stockQuantity)
        //{
        //    foreach (Product product in productList)
        //    {
        //        if (product._stockQuantity == stockQuantity)
        //        {
        //            Console.WriteLine($"Product's name: {product.Name}, Price: {product.Price}, Stock quantity: {product.StockQuantity}, Category: {product.Category}");
        //            return;
        //        }
        //    }
        //    Console.WriteLine("Product wasn't found");

        //}




        //public void productInf(List<Product> productList)
        //{
        //    foreach (Product product in productList)
        //    {
        //        Console.WriteLine($"Product' name: {product.Name}, Price: {product.Price}, Stock quantity: {product.StockQuantity}, Category: {product.Category}");
        //        Console.WriteLine($"Price with tax: {product.TotalValueWithTax} " + $"Sold quantity: {product.SoldQuantity}");
        //    }
        //}


        //public void deleteProduct(List<Product> productList, int index, string attribute)
        //{
        //    if (index >= 0 && index < productList.Count)
        //    {
        //        if (MatchesAttribute(productList[index], attribute))
        //        {
        //            productList.RemoveAt(index);
        //            Console.WriteLine("Product removed!");
        //        }
        //        else
        //        {
        //            Console.WriteLine("Product found at the specified index but does not match the attribute.");
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("Invalid index. Product not removed.");
        //    }
        //}
        private bool MatchesAttribute(Product product, string attribute)
        {
            if (attribute.Equals("name", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            else if (attribute.Equals("price", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            else if (attribute.Equals("stock quantity", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            else if (attribute.Equals("category", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            return false;
        }

        public static void AddProduct(List<Product> productList, Product product)
        {
            productList.Add(product);
            Console.WriteLine("Product added!");
        }

        public static bool DeleteProduct(List<Product> productList, int index)
        {
            if (index >= 0 && index < productList.Count)
            {
                productList.RemoveAt(index);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static List<Product> FindProductsByPrice(List<Product> productList, double price)
        {
            return productList.Where(p => p.Price == price).ToList();
        }

        public static List<Product> FindProductsByStockQuantity(List<Product> productList, int stockQuantity)
        {
            return productList.Where(p => p.StockQuantity == stockQuantity).ToList();
        }


    }
}
