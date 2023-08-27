using FactoryPattern;
using FactoryPattern.Enums;
using FactoryPattern.Models;
using FactoryPattern.Services;

var notificationService = new NotificationService(new NotifyFactory());

var user = new User { Email = "test@test.com ", PhoneNumber = "123456789", SlackId = "1234" };

notificationService.SendNotification(user, "Hello World!", NotifyType.Email);
notificationService.SendNotification(user, "Hello World!", NotifyType.Sms);
notificationService.SendNotification(user, "Hello World!", NotifyType.Slack);
