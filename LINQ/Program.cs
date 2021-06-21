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
                int choice = UserInput.GetIntFromUser(ListExercises() + "\nEnter a number 1 to 31 for the matching exercize above. 0 to quit: ", true, false, 0, 31, true);

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
            Console.WriteLine("Print all products that are out of stock.\n");
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
            Console.WriteLine("Print all products that are in stock and cost more than 3.00 per unit.\n");
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
            Console.WriteLine("Print all customer and their order information for the Washington (WA) region.\n");
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
            Console.WriteLine("Create and print an anonymous type with just the ProductName\n");
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
            Console.WriteLine("Create and print an anonymous type of all product information but increase the unit price by 25%\n");
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
            Console.WriteLine("Create and print an anonymous type of only ProductName and Category with all the letters in upper case\n");
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
            Console.WriteLine("Create and print an anonymous type of all Product information with an extra bool property ReOrder which should ");
            Console.WriteLine("be set to true if the Units in Stock is less than 3\n");
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
            Console.WriteLine("Create and print an anonymous type of all Product information with an extra decimal called");
            Console.WriteLine("StockValue which should be the product of unit price and units in stock\n");
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
            Console.Clear();
            Console.WriteLine("Print only the even numbers in NumbersA");
            Console.WriteLine("NumbersA = 0, 2, 4, 5, 6, 8, 9\n");

            int[] filtered = DataLoader.NumbersA.Where(x => x % 2 == 0).ToArray();

            // Print filtered list
            foreach(int x in filtered)
            {
                Console.WriteLine(x);
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Print only customers that have an order whos total is less than $500
        /// </summary>
        static void Exercise10()
        {
            Console.Clear();
            Console.WriteLine("Print only customers that have an order whos total is less than $500");
            List<Customer> customers = DataLoader.LoadCustomers();

            var filtered = customers.Where(x => x.Orders.Sum(y => y.Total) < 500.0M);

            // Print filtered list
            PrintCustomerInformation(filtered);
            Console.ReadKey();
        }

        /// <summary>
        /// Print only the first 3 odd numbers from NumbersC
        /// </summary>
        static void Exercise11()
        {
            Console.Clear();
            Console.WriteLine("Print only the first 3 odd numbers from NumbersC");
            Console.WriteLine("NumbersC = 5, 4, 1, 3, 9, 8, 6, 7, 2, 0\n");
            List<int> filtered = DataLoader.NumbersC.Where(x => x % 2 != 0).ToList().GetRange(0, 3);

            // Print filtered list
            foreach (int x in filtered)
            {
                Console.WriteLine(x);
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Print the numbers from NumbersB except the first 3
        /// </summary>
        static void Exercise12()
        {
            Console.Clear();
            Console.WriteLine("Print the numbers from NumbersB except the first 3");
            Console.WriteLine("NumbersB = 1, 3, 5, 7, 8\n");
            List<int> filtered = DataLoader.NumbersB.ToList().GetRange(3, DataLoader.NumbersB.Length - 3);

            // Print filtered list
            foreach (int x in filtered)
            {
                Console.WriteLine(x);
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Print the Company Name and most recent order for each customer in Washington
        /// </summary>
        static void Exercise13()
        {
            Console.Clear();
            List<Customer> customers = DataLoader.LoadCustomers();
            Console.WriteLine("Print the Company Name and most recent order for each customer in Washington\n");
            var filtered = customers.Where(x => x.Region == "WA");
            // Loop through each customer in filter
            foreach (Customer x in filtered)
            {
                Console.WriteLine($"Company: {x.CompanyName}\n\nMost Recent Order:\n");
                // Print detail if they have existing orders
                if (x.Orders.Length > 0)
                {
                    Order recent = x.Orders.Last();
                    Console.WriteLine($"Order ID: {recent.OrderID}\nOrder Date: {recent.OrderDate}\nOrder Total: ${recent.Total.ToString("#.##")}");
                }
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Print all the numbers in NumbersC until a number is >= 6
        /// </summary>
        static void Exercise14()
        {
            Console.Clear();
            Console.WriteLine("Print all the numbers in NumbersC until a number is >= 6");
            Console.WriteLine("NumbersC = 5, 4, 1, 3, 9, 8, 6, 7, 2, 0\n");
            List<int> filtered = DataLoader.NumbersC.Where(x => x >= 6).ToList();

            // Print filtered list
            foreach (int x in filtered)
            {
                Console.WriteLine(x);
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Print all the numbers in NumbersC that come after the first number divisible by 3
        /// </summary>
        static void Exercise15()
        {
            Console.Clear();
            Console.WriteLine("Print all the numbers in NumbersC that come after the first number divisible by 3");
            Console.WriteLine("NumbersC = 5, 4, 1, 3, 9, 8, 6, 7, 2, 0\n");

            List<int> filtered = DataLoader.NumbersC.ToList();
            bool indexFound = false;
            int index = 0;

            // Find first diivisible index
            while (!indexFound)
            {
                if (filtered[index] % 3 == 0)
                {
                    indexFound = true;
                    break;
                }              
                index++;
            }

            // use Linq to remove unwanted indexes
            filtered = filtered.GetRange(index, filtered.Count - index);

            // Print filtered list
            foreach (int x in filtered)
            {
                Console.WriteLine(x);
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Print the products alphabetically by name
        /// </summary>
        static void Exercise16()
        {
            Console.Clear();
            Console.WriteLine("Print the products alphabetically by name\n");
            List<Product> products = DataLoader.LoadProducts();

            var filtered = products.OrderBy(x => x.ProductName);

            PrintProductInformation(filtered);
            Console.ReadKey();
        }

        /// <summary>
        /// Print the products in descending order by units in stock
        /// </summary>
        static void Exercise17()
        {
            Console.Clear();
            Console.WriteLine("Print the products in descending order by units in stock");
            List<Product> products = DataLoader.LoadProducts();

            var filtered = products.OrderByDescending(x => x.UnitsInStock);

            PrintProductInformation(filtered);
            Console.ReadKey();
        }

        /// <summary>
        /// Print the list of products ordered first by category, then by unit price, from highest to lowest.
        /// </summary>
        static void Exercise18()
        {
            Console.Clear();
            Console.WriteLine("Print the list of products ordered first by category, then by unit price, from highest to lowest.");
            List<Product> products = DataLoader.LoadProducts();

            var filtered = products.OrderByDescending(x => x.UnitPrice).OrderBy(y => y.Category);

            PrintProductInformation(filtered);
            Console.ReadKey();
        }

        /// <summary>
        /// Print NumbersB in reverse order
        /// </summary>
        static void Exercise19()
        {
            Console.Clear();
            Console.WriteLine("Print NumbersB in reverse order");
            Console.WriteLine("NumbersB = 1, 3, 5, 7, 8\n");
            List<int> filtered = DataLoader.NumbersB.Reverse().ToList();

            // Print filtered list
            foreach (int x in filtered)
            {
                Console.WriteLine(x);
            }
            Console.ReadKey();
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
            Console.Clear();
            List<Product> products = DataLoader.LoadProducts();
            Console.WriteLine("Group products by category, then print each category name and its products\n");

            var groups = products.GroupBy(x => x.Category);
            
            foreach(var x in groups)
            {
                Console.WriteLine(x.Key + ":");
                PrintProductInformation(x);
                Console.WriteLine("\n");
            }
            Console.ReadKey();
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
            Console.Clear();
            List<Customer> customers = DataLoader.LoadCustomers();

            Console.WriteLine("Print all Customers with their orders by Year then Month\n");

            foreach (Customer x in customers)
            {
                Console.WriteLine(x.CustomerID + ", " + x.CompanyName);
                var orderList = x.Orders.ToList();

                var orderGroups = orderList.GroupBy(y => y.OrderDate.Year);

                foreach (var year in orderGroups)
                {
                    year.OrderBy(z => z.OrderDate);
                    Console.WriteLine(year.Key);

                    foreach (var printme in year)
                    {
                        Console.WriteLine($"\t {printme.OrderDate.Month} - {printme.Total}");
                    }
                }


                Console.WriteLine("\n");
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Print the unique list of product categories
        /// </summary>
        static void Exercise22()
        {
            Console.Clear();
            Console.WriteLine("Print the unique list of product categories\n");
            List<Product> products = DataLoader.LoadProducts();

            // Create new list to house categories
            List<string> categories =new List<string>();


            // products.Select(x => x.Category).Distinct(); // Why doesn't this work? (prints all, not distinct)

            // Populate
            foreach (var x in products)
            {
                categories.Add(x.Category);
            }

            // Filter for uniques
            // categories.Distinct(); // This also doesn't work? Only if I use Distinct() in the foreach expression

            foreach (var x in categories.Distinct())
            {
                Console.WriteLine(x);
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Write code to check to see if Product 789 exists
        /// </summary>
        static void Exercise23()
        {
            Console.Clear();
            Console.WriteLine("Write code to check to see if Product 789 exists\n");
            List<Product> products = DataLoader.LoadProducts();

            if (products.Any(x => x.ProductID == 789))
            {
                Console.WriteLine("789 exists");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("789 does not exist");
            Console.ReadKey();


        }

        /// <summary>
        /// Print a list of categories that have at least one product out of stock
        /// </summary>
        static void Exercise24()
        {
            Console.Clear();
            List<Product> products = DataLoader.LoadProducts();
            Console.WriteLine("Print a list of categories that have at least one product out of stock\n");

            // Create new list to house categories
            List<string> categories = new List<string>();

            // Populate categories only for items out of stock
            foreach (var x in products)
            {
                if (x.UnitsInStock <= 0)
                    categories.Add(x.Category);
            }

            // Make distinct
            categories = categories.Distinct().ToList();

            // print
            foreach (var x in categories)
            {
                Console.WriteLine(x);
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Print a list of categories that have no products out of stock
        /// </summary>
        static void Exercise25()
        {
            Console.Clear();
            Console.WriteLine("Print a list of categories that have no products out of stock\n");
            List<Product> products = DataLoader.LoadProducts();

            // Create new list to house categories
            List<string> categories = new List<string>();
            List<string> oosCategories = new List<string>();

            // Populate categories only for items out of stock
            foreach (var x in products)
            {
                // populate master list
                categories.Add(x.Category);
                // populate out of stock list
                if (x.UnitsInStock <= 0)
                    oosCategories.Add(x.Category);              
            }

            // Make distinct
            categories = categories.Distinct().ToList();
            oosCategories = oosCategories.Distinct().ToList();

            // Remove oos from master list

            foreach (var x in oosCategories)
            {
                categories.Remove(x);
            }

            // print
            foreach (var x in categories)
            {
                Console.WriteLine(x);
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Count the number of odd numbers in NumbersA
        /// </summary>
        static void Exercise26()
        {
            Console.Clear();
            Console.WriteLine("Count the number of odd numbers in NumbersA");
            Console.WriteLine("NumbersA = 0, 2, 4, 5, 6, 8, 9\n");

            int oddCount = DataLoader.NumbersA.Where(x => x % 2 != 0).Count();
            Console.WriteLine(oddCount);
            Console.ReadKey();
        }

        /// <summary>
        /// Create and print an anonymous type containing CustomerId and the count of their orders
        /// </summary>
        static void Exercise27()
        {
            Console.Clear();
            Console.WriteLine("Create and print an anonymous type containing CustomerId and the count of their orders\n");

            List<Customer> customers = DataLoader.LoadCustomers();

            var filtered =
                from item in customers
                select new
                {
                    custID = item.CustomerID,
                    orderCount = item.Orders.Length
                };

            foreach(var x in filtered)
            {
                Console.WriteLine($"Customer: {x.custID}\n Orders: {x.orderCount}");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Print a distinct list of product categories and the count of the products they contain
        /// </summary>
        static void Exercise28()
        {
            Console.Clear();
            Console.WriteLine("Print a distinct list of product categories and the count of the products they contain\n");

            List<Product> products = DataLoader.LoadProducts();

            // Create new list to house categories
            List<string> categories = new List<string>();

            // Populate categories
            foreach (var x in products)
            {
                    categories.Add(x.Category);
            }

            // Make distinct
            categories = categories.Distinct().ToList();

            // print
            foreach (var x in categories)
            {
                int prodCount = products.Where(y => y.Category == x).Count();
                Console.WriteLine($"{x} contains {prodCount} products.");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Print a distinct list of product categories and the total units in stock
        /// </summary>
        static void Exercise29()
        {
            Console.Clear();
            Console.WriteLine("Print a distinct list of product categories and the total units in stock\n");

            List<Product> products = DataLoader.LoadProducts();

            // Create new list to house categories
            List<string> categories = new List<string>();

            // Populate categories
            foreach (var x in products)
            {
                categories.Add(x.Category);
            }

            // Make distinct
            categories = categories.Distinct().ToList();

            // print
            foreach (var x in categories)
            {
                int prodCount = products.Where(y => y.Category == x).Sum(z => z.UnitsInStock);
                Console.WriteLine($"{x} contains {prodCount} total product units in stock.");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Print a distinct list of product categories and the lowest priced product in that category
        /// </summary>
        static void Exercise30()
        {
            Console.Clear();
            Console.WriteLine("Print a distinct list of product categories and the lowest priced product in that category\n");

            List<Product> products = DataLoader.LoadProducts();

            // Create new list to house categories
            List<string> categories = new List<string>();

            // Populate categories
            foreach (var x in products)
            {
                categories.Add(x.Category);
            }

            // Make distinct
            categories = categories.Distinct().ToList();

            // Sort products by ascending price
            products = products.OrderBy(x => x.UnitPrice).ToList();

            // print the first item matching category which will be the lowest in price due to sorting
            foreach (var x in categories)
            {
                Product lowProd = products.First(y => y.Category == x);
                Console.WriteLine($"{x} category's lowerst priced item is: {lowProd.ProductName}");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Print the top 3 categories by the average unit price of their products
        /// </summary>
        static void Exercise31()
        {
            Console.Clear();
            Console.WriteLine("Print the top 3 categories by the average unit price of their products\n");

            List<Product> products = DataLoader.LoadProducts();

            // Create new list to house categories
            List<string> categories = new List<string>();

            // Populate categories
            foreach (var x in products)
            {
                categories.Add(x.Category);
            }

            // Make distinct
            categories = categories.Distinct().ToList();

            // Order categories by their matching product list aggregated and averaged unit price, descending
            categories = categories.OrderByDescending(x => products.Where(y => y.Category == x).Average(z => z.UnitPrice)).ToList();

            // print 3
            for (int i = 0; i < 3; i++)
            {
                var x = categories[i];
                Console.WriteLine($"{x} has an average unit price of {products.Where(y => y.Category == x).Average(z => z.UnitPrice).ToString("#.##")}");
            }

            Console.ReadKey();
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
