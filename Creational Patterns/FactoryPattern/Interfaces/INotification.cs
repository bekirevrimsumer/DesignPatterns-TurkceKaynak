using FactoryPattern.Enums;
using FactoryPattern.Models;

namespace FactoryPattern.Interfaces;

public interface INotification
{
    void Notify(User user, string message);
}