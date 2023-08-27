using FactoryPattern.Enums;

namespace FactoryPattern.Interfaces;

public interface INotifyFactory
{
    INotification CreateNotification(NotifyType notifyType);
}