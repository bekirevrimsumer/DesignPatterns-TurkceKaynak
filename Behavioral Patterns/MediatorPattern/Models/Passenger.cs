using MediatorPattern.Interfaces;

namespace MediatorPattern.Models;

public class Passenger
{
    public string Name { get; private set; }
    private IFlightMediator _flightMediator;
    
    public Passenger(string name, IFlightMediator flightMediator)
    {
        Name = name;
        _flightMediator = flightMediator;
    }
    
    public void MakeReservation(Flight flight)
    {
        Console.WriteLine($"{Name} is making a reservation for flight {flight.FlightNumber}");
        _flightMediator.MakeReservation(this, flight);
    }
}