using FactoryPattern.Enums;
using FactoryPattern.Interfaces;
using FactoryPattern.Models;

namespace FactoryPattern;

public class NotifyFactory : INotifyFactory
{
    public INotification CreateNotification(NotifyType notificationType)
    {
        return notificationType switch
        {
            NotifyType.Sms => new SmsNotification(),
            NotifyType.Email => new EmailNotification(),
            NotifyType.Slack => new SlackNotification(),
            _ => throw new ArgumentException("Invalid notification type", nameof(notificationType))
        };
    }
}