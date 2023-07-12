using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class SalesOrder
{
    public string OrderNumber { get; set; }
    public List<FinishedGood> FinishedGoods { get; set; }

    public SalesOrder()
    {
        FinishedGoods = new List<FinishedGood>();
    }
}

public class FinishedGoods
{
    public string ProductCode { get; set; }
    public int Quantity { get; set; }
}

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
