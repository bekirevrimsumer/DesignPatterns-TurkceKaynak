namespace FlyweightPattern.Models;

public class Position
{
    public int X { get; set; }
    public int Y { get; set; }
    
    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }
}