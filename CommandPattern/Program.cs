Chef chef = new Chef();
Waiter waiter = new Waiter();

ICommand beefOrder = new BeefOrderCommand(chef);
ICommand soupOrder = new SoupOrderCommand(chef);

waiter.TakeOrder(beefOrder);
waiter.TakeOrder(soupOrder);

waiter.PlaceOrders();

#region Interfaces

interface ICommand
{
    void Execute();
    void Undo();
}

#endregion

#region Models

class Chef
{
    public void PrepareBeef()
    {
        Console.WriteLine("Et hazırlanıyor...");
    }

    public void PrepareSoup()
    {
        Console.WriteLine("Çorba hazırlanıyor...");
    }
}

class Waiter
{
    private List<ICommand> _orders = new();

    public void TakeOrder(ICommand order)
    {
        _orders.Add(order);
    }

    public void PlaceOrders()
    {
        foreach (var order in _orders)
        {
            order.Execute();
        }
        _orders.Clear();
    }
}


#endregion

#region Commands

class BeefOrderCommand : ICommand
{
    private Chef _chef;

    public BeefOrderCommand(Chef chef)
    {
        _chef = chef;
    }

    public void Execute()
    {
        _chef.PrepareBeef();
    }

    public void Undo()
    {
        // Pasta siparişi geri alınamaz
    }
}

// Çorba siparişi komutu
class SoupOrderCommand : ICommand
{
    private Chef _chef;

    public SoupOrderCommand(Chef chef)
    {
        _chef = chef;
    }

    public void Execute()
    {
        _chef.PrepareSoup();
    }

    public void Undo()
    {
        // Çorba siparişi geri alınamaz
    }
}

#endregion

