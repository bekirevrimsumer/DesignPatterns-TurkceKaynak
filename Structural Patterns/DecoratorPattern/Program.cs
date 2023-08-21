
using DecoratorPattern.Decorators;
using DecoratorPattern.Interfaces;
using DecoratorPattern.Models;

bool isFacebookNotification = true, isEmailNotification = true;

INotification notification = new BaseNotification();
notification = new SMSNotificationDecorator(notification);

if (isFacebookNotification)
{
    notification = new FacebookNotificationDecorator(notification);
}

if (isEmailNotification)
{
    notification = new EmailNotificationDecorator(notification);
}

notification.Send("Hello World!");
