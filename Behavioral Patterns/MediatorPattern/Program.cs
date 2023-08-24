using MediatorPattern.Models;

ReservationCenter reservationCenter = new ReservationCenter();

Flight flight1 = new Flight("FL123");
Flight flight2 = new Flight("FL456");

reservationCenter.AddFlight(flight1);
reservationCenter.AddFlight(flight2);

Passenger passenger1 = new Passenger("Alice", reservationCenter);
Passenger passenger2 = new Passenger("Bob", reservationCenter);

reservationCenter.RegisterPassenger(passenger1);
reservationCenter.RegisterPassenger(passenger2);

passenger1.MakeReservation(flight1);
passenger2.MakeReservation(flight2);
