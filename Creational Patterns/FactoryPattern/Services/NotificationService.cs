using FactoryPattern.Enums;
using FactoryPattern.Interfaces;
using FactoryPattern.Models;

namespace FactoryPattern.Services;

public class NotificationService
{
    private readonly INotifyFactory _notificationFactory;

    public NotificationService(INotifyFactory notificationFactory)
    {
        _notificationFactory = notificationFactory;
    }

    public void SendNotification(User user, string message, NotifyType notifyType)
    {
        var notification = _notificationFactory.CreateNotification(notifyType);
        notification.Notify(user, message);
    }
}