using DecoratorPattern.Interfaces;

namespace DecoratorPattern.Decorators;

public class EmailNotificationDecorator : NotificationDecorator
{
    public EmailNotificationDecorator(INotification notification) : base(notification)
    {
    }
    
    public override void Send(string message)
    {
        base.Send(message);
        Console.WriteLine($"Sending Email Notification: {message}");
    }
}