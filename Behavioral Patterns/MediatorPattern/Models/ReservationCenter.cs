using MediatorPattern.Interfaces;

namespace MediatorPattern.Models;

public class ReservationCenter : IFlightMediator
{
    private List<Flight> _flights = new();
    private List<Passenger> _passengers = new();
    
    public void AddFlight(Flight flight)
    {
        _flights.Add(flight);
    }

    public void RegisterPassenger(Passenger passenger)
    {
        _passengers.Add(passenger);
    }

    public void MakeReservation(Passenger passenger, Flight flight)
    {
        if (_passengers.Contains(passenger) && _flights.Contains(flight))
            Console.WriteLine($"Reservation for {passenger.Name} on flight {flight.FlightNumber} confirmed.");
        else
            Console.WriteLine($"Reservation for {passenger.Name} on flight {flight.FlightNumber} failed.");
    }
}