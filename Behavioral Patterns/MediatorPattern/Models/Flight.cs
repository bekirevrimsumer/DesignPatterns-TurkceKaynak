namespace MediatorPattern.Models;

public class Flight
{
    public string FlightNumber { get; private set; }
    
    public Flight(string flightNumber)
    {
        FlightNumber = flightNumber;
    }
}