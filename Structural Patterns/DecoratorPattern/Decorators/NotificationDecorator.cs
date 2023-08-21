using DecoratorPattern.Interfaces;

namespace DecoratorPattern.Decorators;

public class NotificationDecorator : INotification
{
    public INotification Notification;
    
    public NotificationDecorator(INotification notification)
    {
        Notification = notification;
    }
    
    public virtual void Send(string message)
    {
        Notification.Send(message);
    }
}