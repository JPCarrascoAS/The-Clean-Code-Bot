using System;
using System.Collections.Generic;
using System.IO;

/// <summary>
/// Handles order processing, including calculating totals and persisting orders.
/// </summary>
public class OrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly INotificationService _notificationService;
    private readonly IShippingCalculator _shippingCalculator;

    /// <summary>
    /// Initializes a new instance of the OrderService class.
    /// </summary>
    /// <param name="orderRepository">The order repository to use for persisting orders.</param>
    /// <param name="notificationService">The notification service to use for sending notifications.</param>
    /// <param name="shippingCalculator">The shipping calculator to use for calculating shipping costs.</param>
    public OrderService(IOrderRepository orderRepository, INotificationService notificationService, IShippingCalculator shippingCalculator)
    {
        _orderRepository = orderRepository;
        _notificationService = notificationService;
        _shippingCalculator = shippingCalculator;
    }

    /// <summary>
    /// Processes an order, including calculating the total and persisting the order.
    /// </summary>
    /// <param name="item">The item being ordered.</param>
    /// <param name="quantity">The quantity of the item being ordered.</param>
    /// <param name="shippingType">The type of shipping to use.</param>
    public void ProcessOrder(string item, int quantity, string shippingType)
    {
        // Calculate the total cost of the order
        decimal price = 100.00m;
        decimal total = price * quantity;
        total += _shippingCalculator.CalculateShippingCost(shippingType);

        // Persist the order
        _orderRepository.SaveOrder(item, total);

        // Send a notification
        _notificationService.SendNotification($"Your order for {item} is complete!");
    }
}

/// <summary>
/// Defines a repository for orders.
/// </summary>
public interface IOrderRepository
{
    /// <summary>
    /// Saves an order to the repository.
    /// </summary>
    /// <param name="item">The item being ordered.</param>
    /// <param name="total">The total cost of the order.</param>
    void SaveOrder(string item, decimal total);
}

/// <summary>
/// A file-based order repository.
/// </summary>
public class FileOrderRepository : IOrderRepository
{
    /// <summary>
    /// Saves an order to the file.
    /// </summary>
    /// <param name="item">The item being ordered.</param>
    /// <param name="total">The total cost of the order.</param>
    public void SaveOrder(string item, decimal total)
    {
        // 💡 Using a file-based repository for simplicity, but this could be replaced with a database or other data store
        File.WriteAllText("orders.txt", $"Order: {item}, Total: {total}");
    }
}

/// <summary>
/// Defines a service for sending notifications.
/// </summary>
public interface INotificationService
{
    /// <summary>
    /// Sends a notification.
    /// </summary>
    /// <param name="message">The message to send.</param>
    void SendNotification(string message);
}

/// <summary>
/// A console-based notification service.
/// </summary>
public class ConsoleNotificationService : INotificationService
{
    /// <summary>
    /// Sends a notification to the console.
    /// </summary>
    /// <param name="message">The message to send.</param>
    public void SendNotification(string message)
    {
        // 💡 Using a console-based notification service for simplicity, but this could be replaced with an email or other notification service
        Console.WriteLine(message);
    }
}

/// <summary>
/// Defines a calculator for shipping costs.
/// </summary>
public interface IShippingCalculator
{
    /// <summary>
    /// Calculates the shipping cost for an order.
    /// </summary>
    /// <param name="shippingType">The type of shipping to use.</param>
    /// <returns>The shipping cost.</returns>
    decimal CalculateShippingCost(string shippingType);
}

/// <summary>
/// A simple shipping calculator.
/// </summary>
public class SimpleShippingCalculator : IShippingCalculator
{
    /// <summary>
    /// Calculates the shipping cost for an order.
    /// </summary>
    /// <param name="shippingType">The type of shipping to use.</param>
    /// <returns>The shipping cost.</returns>
    public decimal CalculateShippingCost(string shippingType)
    {
        // 💡 Using a simple shipping calculator for simplicity, but this could be replaced with a more complex calculator
        if (shippingType == "Domestic")
        {
            return 5.00m;
        }
        else if (shippingType == "International")
        {
            return 50.00m;
        }
        else
        {
            // 🚨 POTENTIAL ISSUE: Unknown shipping type, may need to add error handling or support for additional shipping types
            throw new ArgumentException("Unknown shipping type", nameof(shippingType));
        }
    }
}