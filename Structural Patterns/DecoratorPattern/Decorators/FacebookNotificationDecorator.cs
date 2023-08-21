using DecoratorPattern.Interfaces;

namespace DecoratorPattern.Decorators;

public class FacebookNotificationDecorator : NotificationDecorator
{
    public FacebookNotificationDecorator(INotification notification) : base(notification)
    {
    }
    
    public override void Send(string message)
    {
        base.Send(message);
        Console.WriteLine($"Sending Facebook Notification: {message}");
    }
}