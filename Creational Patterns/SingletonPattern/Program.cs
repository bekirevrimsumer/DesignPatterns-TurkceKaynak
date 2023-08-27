
using SingletonPattern;

Singleton instance1 = Singleton.Instance;
instance1.PrintMessage("Hello from instance 1");

Singleton instance2 = Singleton.Instance;
instance2.PrintMessage("Hello from instance 2");

Console.WriteLine($"instance1 == instance2: {instance1 == instance2}");