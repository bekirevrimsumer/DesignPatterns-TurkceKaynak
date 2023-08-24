using MediatorPattern.Models;

namespace MediatorPattern.Interfaces;

public interface IFlightMediator
{
    void AddFlight(Flight flight);
    void RegisterPassenger(Passenger passenger);
    void MakeReservation(Passenger passenger, Flight flight);
}