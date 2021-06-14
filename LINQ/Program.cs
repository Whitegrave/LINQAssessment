using LINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Input_View;

namespace LINQ
{
    class Program
    {
        static void Main()
        {
            //PrintAllProducts();
            //PrintAllCustomers();
            bool bKeepRunning = true;
            while (bKeepRunning)
            {
                Console.Clear();
                int choice = UserInput.GetIntFromUser(ListExercises() + "\nEnter a number 1 to 31 for the matching exercize above. 0 to quit.", true, false, 0, 31, true);

                switch (choice)
                {
                    case 0:
                        bKeepRunning = false;
                        break;
                    case 1:
                        Exercise1();
                        break;
                    case 2:
                        Exercise2();
                        break;
                    case 3:
                        Exercise3();
                        break;
                    case 4:
                        Exercise4();
                        break;
                    case 5:
                        Exercise5();
                        break;
                    case 6:
                        Exercise6();
                        break;
                    case 7:
                        Exercise7();
                        break;
                    case 8:
                        Exercise8();
                        break;
                    case 9:
                        Exercise9();
                        break;
                    case 10:
                        Exercise10();
                        break;
                    case 11:
                        Exercise11();
                        break;
                    case 12:
                        Exercise12();
                        break;
                    case 13:
                        Exercise13();
                        break;
                    case 14:
                        Exercise14();
                        break;
                    case 15:
                        Exercise15();
                        break;
                    case 16:
                        Exercise16();
                        break;
                    case 17:
                        Exercise17();
                        break;
                    case 18:
                        Exercise18();
                        break;
                    case 19:
                        Exercise19();
                        break;
                    case 20:
                        Exercise20();
                        break;
                    case 21:
                        Exercise21();
                        break;
                    case 22:
                        Exercise22();
                        break;
                    case 23:
                        Exercise23();
                        break;
                    case 24:
                        Exercise24();
                        break;
                    case 25:
                        Exercise25();
                        break;
                    case 26:
                        Exercise26();
                        break;
                    case 27:
                        Exercise27();
                        break;
                    case 28:
                        Exercise28();
                        break;
                    case 29:
                        Exercise29();
                        break;
                    case 30:
                        Exercise30();
                        break;
                    case 31:
                        Exercise31();
                        break;
                    default:
                        throw new ArgumentException("Invalid menu choice");
                        bKeepRunning = false;
                        break;
                }
            }
        }

        #region "Sample Code"
        /// <summary>
        /// Sample, load and print all the product objects
        /// </summary>
        static void PrintAllProducts()
        {
            List<Product> products = DataLoader.LoadProducts();
            PrintProductInformation(products);
        }

        /// <summary>
        /// This will print a nicely formatted list of products
        /// </summary>
        /// <param name="products">The collection of products to print</param>
        static void PrintProductInformation(IEnumerable<Product> products)
        {
            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("==============================================================================");

            foreach (var product in products)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
                    product.UnitPrice, product.UnitsInStock);
            }

        }

        /// <summary>
        /// Sample, load and print all the customer objects and their orders
        /// </summary>
        static void PrintAllCustomers()
        {
            var customers = DataLoader.LoadCustomers();
            PrintCustomerInformation(customers);
        }

        /// <summary>
        /// This will print a nicely formated list of customers
        /// </summary>
        /// <param name="customers">The collection of customer objects to print</param>
        static void PrintCustomerInformation(IEnumerable<Customer> customers)
        {
            foreach (var customer in customers)
            {
                Console.WriteLine("==============================================================================");
                Console.WriteLine(customer.CompanyName);
                Console.WriteLine(customer.Address);
                Console.WriteLine("{0}, {1} {2} {3}", customer.City, customer.Region, customer.PostalCode, customer.Country);
                Console.WriteLine("p:{0} f:{1}", customer.Phone, customer.Fax);
                Console.WriteLine();
                Console.WriteLine("\tOrders");
                foreach (var order in customer.Orders)
                {
                    Console.WriteLine("\t{0} {1:MM-dd-yyyy} {2,10:c}", order.OrderID, order.OrderDate, order.Total);
                }
                Console.WriteLine("==============================================================================");
                Console.WriteLine();
            }
        }
        #endregion

        /// <summary>
        /// Print all products that are out of stock.
        /// </summary>
        static void Exercise1()
        {
            Console.Clear();
            List<Product> products = DataLoader.LoadProducts();
            var filtered = products.Where(x => x.UnitsInStock <= 0);
            PrintProductInformation(filtered);
            Console.ReadKey();
        }

        /// <summary>
        /// Print all products that are in stock and cost more than 3.00 per unit.
        /// </summary>
        static void Exercise2()
        {
            Console.Clear();
            List<Product> products = DataLoader.LoadProducts();
            var filtered = products.Where(x => x.UnitsInStock > 0 && x.UnitPrice > 3.0M);
            PrintProductInformation(filtered);
            Console.ReadKey();
        }

        /// <summary>
        /// Print all customer and their order information for the Washington (WA) region.
        /// </summary>
        static void Exercise3()
        {
            Console.Clear();
            List<Customer> customers = DataLoader.LoadCustomers();
            var filtered = customers.Where(x => x.Region == "WA");
            PrintCustomerInformation(filtered);
            Console.ReadKey();
        }

        /// <summary>
        /// Create and print an anonymous type with just the ProductName
        /// </summary>
        static void Exercise4()
        {
            Console.Clear();
            List<Product> products = DataLoader.LoadProducts();
            var filtered =
                from item in products
                select new { ProdName = item.ProductName };

            foreach (var x in filtered)
            {
                Console.WriteLine(x.ProdName);
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Create and print an anonymous type of all product information but increase the unit price by 25%
        /// </summary>
        static void Exercise5()
        {
            Console.Clear();
            List<Product> products = DataLoader.LoadProducts();
            var filtered =
                from item in products
                select new {
                    ProductID = item.ProductID,
                    ProductName = item.ProductName,
                    Category = item.Category,
                    UnitPrice = Decimal.Multiply(item.UnitPrice, 1.25M),
                    UnitsInStock = item.UnitsInStock
                    };

            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("==============================================================================");

            foreach (var product in filtered)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
                    product.UnitPrice, product.UnitsInStock);
            }
            Console.ReadKey();
    }

        /// <summary>
        /// Create and print an anonymous type of only ProductName and Category with all the letters in upper case
        /// </summary>
        static void Exercise6()
        {
            Console.Clear();
            List<Product> products = DataLoader.LoadProducts();
            var filtered =
                from item in products
                select new { 
                    ProdName = item.ProductName.ToUpper(),
                    Category = item.Category.ToUpper() };

            foreach (var x in filtered)
            {
                Console.WriteLine(x.ProdName + ", " + x.Category);
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra bool property ReOrder which should 
        /// be set to true if the Units in Stock is less than 3
        /// 
        /// Hint: use a ternary expression
        /// </summary>
        static void Exercise7()
        {
            Console.Clear();
            List<Product> products = DataLoader.LoadProducts();
            var filtered =
                from item in products
                select new
                {
                    ProductID = item.ProductID,
                    ProductName = item.ProductName,
                    Category = item.Category,
                    UnitPrice = item.UnitPrice,
                    UnitsInStock = item.UnitsInStock,
                    ReOrder = item.UnitsInStock < 3 ? true : false 
                };

            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6} {5, 6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock", "ReOrder?");
            Console.WriteLine("==============================================================================");

            foreach (var product in filtered)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
                    product.UnitPrice, product.UnitsInStock, product.ReOrder);
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra decimal called 
        /// StockValue which should be the product of unit price and units in stock
        /// </summary>
        static void Exercise8()
        {
            Console.Clear();
            List<Product> products = DataLoader.LoadProducts();
            var filtered =
                from item in products
                select new
                {
                    ProductID = item.ProductID,
                    ProductName = item.ProductName,
                    Category = item.Category,
                    UnitPrice = item.UnitPrice,
                    UnitsInStock = item.UnitsInStock,
                    StockValue = Decimal.Multiply(item.UnitPrice, item.UnitsInStock).ToString("0.00")
                };

            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6} {5, 6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock", "StockValue");
            Console.WriteLine("==============================================================================");

            foreach (var product in filtered)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
                    product.UnitPrice, product.UnitsInStock, product.StockValue);
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Print only the even numbers in NumbersA
        /// </summary>
        static void Exercise9()
        {

        }

        /// <summary>
        /// Print only customers that have an order whos total is less than $500
        /// </summary>
        static void Exercise10()
        {

        }

        /// <summary>
        /// Print only the first 3 odd numbers from NumbersC
        /// </summary>
        static void Exercise11()
        {

        }

        /// <summary>
        /// Print the numbers from NumbersB except the first 3
        /// </summary>
        static void Exercise12()
        {

        }

        /// <summary>
        /// Print the Company Name and most recent order for each customer in Washington
        /// </summary>
        static void Exercise13()
        {

        }

        /// <summary>
        /// Print all the numbers in NumbersC until a number is >= 6
        /// </summary>
        static void Exercise14()
        {

        }

        /// <summary>
        /// Print all the numbers in NumbersC that come after the first number divisible by 3
        /// </summary>
        static void Exercise15()
        {

        }

        /// <summary>
        /// Print the products alphabetically by name
        /// </summary>
        static void Exercise16()
        {

        }

        /// <summary>
        /// Print the products in descending order by units in stock
        /// </summary>
        static void Exercise17()
        {

        }

        /// <summary>
        /// Print the list of products ordered first by category, then by unit price, from highest to lowest.
        /// </summary>
        static void Exercise18()
        {

        }

        /// <summary>
        /// Print NumbersB in reverse order
        /// </summary>
        static void Exercise19()
        {

        }

        /// <summary>
        /// Group products by category, then print each category name and its products
        /// ex:
        /// 
        /// Beverages
        /// Tea
        /// Coffee
        /// 
        /// Sandwiches
        /// Turkey
        /// Ham
        /// </summary>
        static void Exercise20()
        {

        }

        /// <summary>
        /// Print all Customers with their orders by Year then Month
        /// ex:
        /// 
        /// Joe's Diner
        /// 2015
        ///     1 -  $500.00
        ///     3 -  $750.00
        /// 2016
        ///     2 - $1000.00
        /// </summary>
        static void Exercise21()
        {

        }

        /// <summary>
        /// Print the unique list of product categories
        /// </summary>
        static void Exercise22()
        {

        }

        /// <summary>
        /// Write code to check to see if Product 789 exists
        /// </summary>
        static void Exercise23()
        {

        }

        /// <summary>
        /// Print a list of categories that have at least one product out of stock
        /// </summary>
        static void Exercise24()
        {

        }

        /// <summary>
        /// Print a list of categories that have no products out of stock
        /// </summary>
        static void Exercise25()
        {

        }

        /// <summary>
        /// Count the number of odd numbers in NumbersA
        /// </summary>
        static void Exercise26()
        {

        }

        /// <summary>
        /// Create and print an anonymous type containing CustomerId and the count of their orders
        /// </summary>
        static void Exercise27()
        {

        }

        /// <summary>
        /// Print a distinct list of product categories and the count of the products they contain
        /// </summary>
        static void Exercise28()
        {

        }

        /// <summary>
        /// Print a distinct list of product categories and the total units in stock
        /// </summary>
        static void Exercise29()
        {

        }

        /// <summary>
        /// Print a distinct list of product categories and the lowest priced product in that category
        /// </summary>
        static void Exercise30()
        {

        }

        /// <summary>
        /// Print the top 3 categories by the average unit price of their products
        /// </summary>
        static void Exercise31()
        {

        }

        static string ListExercises()
        {

            return  "1 : Print all products that are out of stock.\n" +
                    "2 : Print all products that are in stock and cost more than 3.00 per unit.\n" +
                    "3 : Print all customer and their order information for the Washington (WA) region.\n" +
                    "4 : Create and print an anonymous type with just the ProductName\n" +
                    "5 : Create and print an anonymous type of all product information but increase the unit price by 25%\n" +
                    "6 : Create and print an anonymous type of only ProductName and Category with all the letters in upper case\n" +
                    "7 : Create and print an anonymous type of all Product information with an extra bool property ReOrder which should be set to true if the Units in Stock is less than 3\n" +
                    "8 : Create and print an anonymous type of all Product information with an extra decimal called StockValue which should be the product of unit price and units in stock\n" +
                    "9 : Print only the even numbers in NumbersA\n" +
                    "10: Print only customers that have an order whos total is less than $500\n" +
                    "11: Print only the first 3 odd numbers from NumbersC\n" +
                    "12: Print the numbers from NumbersB except the first 3\n" +
                    "13: Print the Company Name and most recent order for each customer in Washington\n" +
                    "14: Print all the numbers in NumbersC until a number is >= 6\n" +
                    "15: Print all the numbers in NumbersC that come after the first number divisible by 3\n" +
                    "16: Print the products alphabetically by name\n" +
                    "17: Print the products in descending order by units in stock\n" +
                    "18: Print the list of products ordered first by category, then by unit price, from highest to lowest.\n" +
                    "19: Print NumbersB in reverse order\n" +
                    "20: Group products by category, then print each category name and its products\n" +
                    "21: Print all Customers with their orders by Year then Month\n" +
                    "22: Print the unique list of product categories\n" +
                    "23: Write code to check to see if Product 789 exists\n" +
                    "24: Print a list of categories that have at least one product out of stock\n" +
                    "25: Print a list of categories that have no products out of stock\n" +
                    "26: Count the number of odd numbers in NumbersA\n" +
                    "27: Create and print an anonymous type containing CustomerId and the count of their orders\n" +
                    "28: Print a distinct list of product categories and the count of the products they contain\n" +
                    "29: Print a distinct list of product categories and the total units in stock\n" +
                    "30: Print a distinct list of product categories and the lowest priced product in that category\n" +
                    "31: Print the top 3 categories by the average unit price of their products";
        }
    }
}
