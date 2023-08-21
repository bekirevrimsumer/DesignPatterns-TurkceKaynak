using DecoratorPattern.Interfaces;

namespace DecoratorPattern.Decorators;

public class SMSNotificationDecorator : NotificationDecorator
{
    public SMSNotificationDecorator(INotification notification) : base(notification)
    {
    }
    
    public override void Send(string message)
    {
        base.Send(message);
        Console.WriteLine($"Sending SMS Notification: {message}");
    }
}