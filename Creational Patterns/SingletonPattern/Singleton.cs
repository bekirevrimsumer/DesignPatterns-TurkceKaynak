namespace SingletonPattern;

sealed class Singleton
{
    private static Singleton _instance;
    private static readonly object _lock = new object();
    
    private Singleton()
    {
    }
    
    public static Singleton Instance
    {
        get
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new Singleton();
                }
            }
            return _instance;
        }
    }
    
    public void PrintMessage(string message)
    {
        Console.WriteLine(message);
    }
}