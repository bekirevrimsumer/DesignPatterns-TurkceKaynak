using FactoryPattern.Enums;
using FactoryPattern.Interfaces;

namespace FactoryPattern.Models;

public class SlackNotification : INotification
{
    public void Notify(User user, string message)
    {
        Console.WriteLine($"Sending Slack message to Slack ID:{user.SlackId} with message: {message}");
    }
}