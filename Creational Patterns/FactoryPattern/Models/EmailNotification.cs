using FactoryPattern.Enums;
using FactoryPattern.Interfaces;

namespace FactoryPattern.Models;

public class EmailNotification : INotification
{
    public void Notify(User user, string message)
    {
        Console.WriteLine($"Sending email to {user.Email} with message: {message}");
    }
}