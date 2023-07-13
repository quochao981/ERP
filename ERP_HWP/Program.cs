using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    private static List<SalesOrder> salesOrders = new List<SalesOrder>();
    private static int soNumberCounter = 1;

    public static void Main()
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("1. Create a new sales order");
            Console.WriteLine("2. View existing sales orders");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    CreateSalesOrder();
                    break;
                case "2":
                    ViewSalesOrders();
                    break;
                case "3":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    public static void CreateSalesOrder()
    {
        SalesOrder salesOrder = new SalesOrder();
        salesOrder.OrderNumber = GenerateSalesOrderNumber();

        Console.WriteLine("Enter finished goods information for the sales order (press Enter to finish):");

        bool addFinishedGoods = true;
        while (addFinishedGoods)
        {
            FinishedGood finishedGood = new FinishedGood();

            Console.Write("Product Code: ");
            finishedGood.ProductCode = Console.ReadLine();

            Console.Write("Quantity: ");
            int quantity;
            if (int.TryParse(Console.ReadLine(), out quantity))
            {
                finishedGood.Quantity = quantity;
            }
            else
            {
                Console.WriteLine("Invalid quantity. The finished good will not be added.");
                continue;
            }

            salesOrder.FinishedGoods.Add(finishedGood);

            Console.Write("Add another finished good? (Y/N): ");
            string choice = Console.ReadLine();
            addFinishedGoods = (choice.Equals("Y", StringComparison.OrdinalIgnoreCase));
            Console.WriteLine();
        }

        salesOrders.Add(salesOrder);
        Console.WriteLine("Sales order created successfully. Order number: " + salesOrder.OrderNumber);
    }

    public static void ViewSalesOrders()
    {
        if (salesOrders.Count == 0)
        {
            Console.WriteLine("No sales orders found.");
            return;
        }

        Console.WriteLine("Existing Sales Orders:");
        foreach (var salesOrder in salesOrders)
        {
            Console.WriteLine("Order Number: " + salesOrder.OrderNumber);
            Console.WriteLine("Finished Goods:");
            foreach (var finishedGood in salesOrder.FinishedGoods)
            {
                Console.WriteLine("- Product Code: " + finishedGood.ProductCode);
                Console.WriteLine("  Quantity: " + finishedGood.Quantity);
            }
            Console.WriteLine();
        }
    }

    public static string GenerateSalesOrderNumber()
    {
        string orderNumber = soNumberCounter.ToString("D5");
        soNumberCounter++;
        return orderNumber;
    }
}

*****************************************************************************************************************************
using System;
using System.Collections.Generic;

public class Programs
{
    private static List<SaleOrder> saleOrders = new List<SaleOrder>();
    private static int currentSONumber = 1;

    public static void Main(string[] args)
    {
        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("1. Create Sales Order");
            Console.WriteLine("2. View Sales Order");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateSalesOrder();
                    break;
                case "2":
                    ViewSalesOrder();
                    break;
                case "3":
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    private static void CreateSalesOrder()
    {
        SaleOrder saleOrder = new SaleOrder();
        saleOrder.SONumber = currentSONumber++;

        Console.Write("Enter Customer ID: ");
        saleOrder.CustomerID = Console.ReadLine();

        Console.Write("Enter Order Status: ");
        saleOrder.OrderStatus = int.Parse(Console.ReadLine());

        Console.Write("Enter Deadline (yyyy-mm-dd): ");
        saleOrder.Deadline = DateTime.Parse(Console.ReadLine());

        Console.Write("Enter the number of Finished Goods: ");
        int numFinishedGoods = int.Parse(Console.ReadLine());

        saleOrder.FinishedGoods = new List<FinishedGood>();

        for (int i = 0; i < numFinishedGoods; i++)
        {
            FinishedGood finishedGood = new FinishedGood();

            Console.Write("Enter Good ID: ");
            finishedGood.GoodID = int.Parse(Console.ReadLine());

            Console.Write("Enter Status: ");
            finishedGood.Status = int.Parse(Console.ReadLine());

            Console.Write("Enter Created Date (yyyy-mm-dd): ");
            finishedGood.CreatedDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter Deadline (yyyy-mm-dd): ");
            finishedGood.DeadLine = DateTime.Parse(Console.ReadLine());

            Console.Write("Is it Bulk? (true/false): ");
            finishedGood.IsBulk = bool.Parse(Console.ReadLine());

            Console.Write("Enter Quality: ");
            finishedGood.Quality = int.Parse(Console.ReadLine());

            saleOrder.FinishedGoods.Add(finishedGood);
        }

        saleOrders.Add(saleOrder);

        Console.WriteLine("Sales Order created successfully!");
    }

    private static void ViewSalesOrder()
    {
        Console.Write("Enter the Sales Order Number: ");
        int soNumber = int.Parse(Console.ReadLine());

        SaleOrder saleOrder = saleOrders.Find(so => so.SONumber == soNumber);

        if (saleOrder != null)
        {
            Console.WriteLine("Sales Order Number: {0}", saleOrder.SONumber);
            Console.WriteLine("Customer ID: {0}", saleOrder.CustomerID);
            Console.WriteLine("Order Status: {0}", saleOrder.OrderStatus);
            Console.WriteLine("Deadline: {0}", saleOrder.Deadline);

            Console.WriteLine("Finished Goods:");
            foreach (FinishedGood finishedGood in saleOrder.FinishedGoods)
            {
                Console.WriteLine("Good ID: {0}", finishedGood.GoodID);
                Console.WriteLine("Status: {0}", finishedGood.Status);
                Console.WriteLine("Created Date: {0}", finishedGood.CreatedDate);
                Console.WriteLine("Deadline: {0}", finishedGood.DeadLine);
                Console.WriteLine("Is Bulk: {0}", finishedGood.IsBulk);
                Console.WriteLine("Quality: {0}", finishedGood.Quality);
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("Sales Order not found!");
        }
    }
}
