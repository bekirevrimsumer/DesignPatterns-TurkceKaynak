using DecoratorPattern.Interfaces;

namespace DecoratorPattern.Models;

public class BaseNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"Sending Notification: {message}");
    }
}