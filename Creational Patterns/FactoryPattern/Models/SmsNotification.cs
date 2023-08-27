using FactoryPattern.Enums;
using FactoryPattern.Interfaces;

namespace FactoryPattern.Models;

public class SmsNotification : INotification
{
    public void Notify(User user, string message)
    {
        Console.WriteLine($"Sending SMS to {user.PhoneNumber} with message: {message}");
    }
}