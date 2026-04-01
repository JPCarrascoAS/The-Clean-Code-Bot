using System;
using System.Collections.Generic;
using System.IO;

// Violates Single Responsibility: Handles logic, database (simulated), and notifications
// Violates Open/Closed: Hardcoded shipping types
public class OrderService
{
    public void ProcessOrder(string item, int quantity, string type)
    {
        // Failure: Business logic mixed with data access
        decimal price = 100.00m;
        decimal total = price * quantity;

        if (type == "Domestic")
        {
            total += 5.00m;
        }
        else if (type == "International")
        {
            total += 50.00m;
        }

        // Failure: Rigid dependency on File I/O (Hard to test)
        File.WriteAllText("orders.txt", $"Order: {item}, Total: {total}");

        // Failure: Hardcoded console notification
        Console.WriteLine("Sending Email: Your order for " + item + " is complete!");
    }
}