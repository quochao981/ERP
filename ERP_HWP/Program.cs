using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class SaleOrder : FinishedGood
{
    public string OrderID { get; set; }
    public string CustomerID { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public int OrderStatus { get; set; }
    public DateTime Deadline { get; set; }
    public List<FinishedGood> FinishedGood { get; set; }
}

public class FinishedGood
{
    public int GoodID { get; set; }
    public int Status { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime DeadLine { get; set; }
    public string ProductCode { get; set; }
    public int Quantity { get; set; }

}

public class Programs
{
    private static List<SaleOrder> salesOrders = new List<SaleOrder>();
    private static int soNumberCounter = 1;

    public static void Main()
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("1. Please input Finsihed Goods information!");
            Console.WriteLine("2. View other existing sales orders");
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
                    Console.WriteLine("Invalid choice. Please choose another number.");
                    break;
            }

            Console.WriteLine();
        }
    }



    public static void CreateSalesOrder()
    {
        SaleOrder salesOrder = new SaleOrder();
        salesOrder.OrderID = GenerateSalesOrderNumber();    
        Console.WriteLine("Enter finished goods information for the sales order (press Enter to finish):");

        bool addFinishedGoods = true;
        while (addFinishedGoods)
        {
            FinishedGood finishedGood = new FinishedGood();

            Console.WriteLine("Product Code: ");
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

            salesOrder.FinishedGood.Add(finishedGood);

            Console.Write("Choose another finished good? (Y/N): ");
            string choice = Console.ReadLine();
            addFinishedGoods = (choice.Equals("Y", StringComparison.OrdinalIgnoreCase));
            Console.WriteLine();
        }
        salesOrders.Add(salesOrder);


        Console.WriteLine("Sales order created successfully. Order number: " + salesOrder.OrderID);
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
            Console.WriteLine("Order Number: " + salesOrder.OrderID);
            Console.WriteLine("Finished Goods:");
            foreach (var finishedGood in salesOrder.FinishedGood)
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

/**#region connection string
string connectionString_Users = "Data Source=192.168.88.8;Initial Catalog=ERPTest1;User ID=erptestAdmin;Password=!@#QWEasd";
SqlConnection connection = new SqlConnection(connectionString_Users);
#endregion*/
