# Mediator Tasarım Deseni
Mediator tasarım deseni, nesneler arasındaki iletişimi düzenlemek ve merkezi bir noktada kontrol etmek amacıyla kullanılan bir tasarım desenidir. Bu desen, karmaşık ilişkilerin ve iletişimin olduğu durumlarda kullanışlıdır.

## Ne İşimize Yarar?
Bir yazılım uygulamasında, farklı sınıfların birbirleriyle sıkı sıkıya bağlı olduğu durumlar meydana gelebilir. Bu durum, kodun bakımını zorlaştırabilir ve genişletilebilirliği azaltabilir. Mediator tasarım deseni, bu sınıflar arasındaki iletişimi merkezi bir noktada toplar ve bu iletişimi yönetir. Bu sayede, sınıflar arasındaki bağımlılık azalır ve kodun bakımı kolaylaşır. Aşağıdaki durumlarda Mediator tasarım desenini kullanmak faydalı olabilir:

- **Birçok sınıf arasında karmaşık iletişim**: Nesneler arasındaki iletişim çok karmaşık hale geldiğinde, bu iletişimi merkezi bir noktada yönetmek daha mantıklı olabilir.

- **Bağımlılığı azaltmak**: Nesneler arasındaki doğrudan bağımlılığı azaltarak, bir nesnenin değişmesinin diğerlerini etkileme olasılığını azaltır.

- **Esneklik ve genişletilebilirlik**: Yeni bir nesne eklemek veya varolan bir nesneyi değiştirmek, genellikle sadece Mediator sınıfını etkiler, diğer nesneleri etkilemez.

## Avantajları
- **Bağımlılığı azaltır**: Nesneler arasındaki sıkı bağımlılığı azaltır ve bu da sistemin bakımını ve genişletilmesini kolaylaştırır.

- **Kodun düzenlenmesini sağlar**: İletişim kodunu merkezi bir yerde toplamak, kodun daha düzenli ve anlaşılır olmasını sağlar.

- **Esneklik sağlar**: Yeni bileşenler eklemek veya varolanları değiştirmek, genellikle sadece Mediator sınıfını etkiler, diğer nesneleri etkilemez.

- **Tek bir noktada kontrol**: İletişim ve koordinasyon merkezi bir noktada olduğu için hataların tespiti ve düzeltilmesi daha kolaydır.

## Örnek Senaryo: Uçuş Rezervasyon Sistemi

Bir uçuş rezervasyon sistemi düşünelim. Bu sistemin içinde uçuşlar, yolcular ve bir rezervasyon merkezi bulunacak. Uçuşlar, yolcuların rezervasyonlarını kabul edecek ve rezervasyon merkezi, yolcuların uçuşlara rezervasyon yapmasını sağlayacak. Bu sistemi tasarlarken, uçuşlar ve yolcular arasındaki iletişimi merkezi bir noktada toplamak isteyebiliriz. Bu durumda Mediator tasarım desenini kullanabiliriz.

### Örnek Kod

Öncelikle, `IFlightMediator` interface'ini oluşturalım. Bu interface, uçuşlar ve yolcular arasındaki iletişimi yönetecek.

```C#
public interface IFlightMediator
{
    void AddFlight(Flight flight);
    void RegisterPassenger(Passenger passenger);
    void MakeReservation(Passenger passenger, Flight flight);
}
```

Ardından, `Flight` ve `Passenger` sınıflarını oluşturalım.

```C#
public class Flight
{
    public string FlightNumber { get; private set; }
    
    public Flight(string flightNumber)
    {
        FlightNumber = flightNumber;
    }
}

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
```

`Flight` sınıfı, uçuş numarası bilgisini tutuyor. `Passenger` sınıfı ise yolcu ismi bilgisini tutuyor. Ayrıca, `MakeReservation` metoduyla rezervasyon yapabiliyor. Bu metot, yolcunun rezervasyon yapması için `IFlightMediator` interface'ini kullanıyor.

Son olarak, `ReservationCenter` sınıfını oluşturalım.

```C#
public class ReservationCenter : IFlightMediator
{
    private List<Flight> _flights;
    private List<Passenger> _passengers;
    
    public ReservationCenter()
    {
        _flights = new List<Flight>();
        _passengers = new List<Passenger>();
    }
    
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
        if (_flights.Contains(flight) && _passengers.Contains(passenger))
        {
            Console.WriteLine($"Reservation for flight {flight.FlightNumber} is completed for {passenger.Name}");
        }
        else
        {
            Console.WriteLine($"Reservation for flight {flight.FlightNumber} is failed for {passenger.Name}");
        }
    }
}
```

`ReservationCenter` sınıfı, `IFlightMediator` interface'ini implemente ediyor. Bu sınıf, uçuşları ve yolcuları tutuyor. Ayrıca, `MakeReservation` metoduyla yolcuların rezervasyon yapmasını sağlıyor.

### Örnek Kullanım

```C#

var reservationCenter = new ReservationCenter();

var flight1 = new Flight("TK1234");
var flight2 = new Flight("TK5678");

var passenger1 = new Passenger("John", reservationCenter);
var passenger2 = new Passenger("Jane", reservationCenter);

reservationCenter.AddFlight(flight1);
reservationCenter.AddFlight(flight2);

reservationCenter.RegisterPassenger(passenger1);
reservationCenter.RegisterPassenger(passenger2);

passenger1.MakeReservation(flight1);
passenger2.MakeReservation(flight2);

```

### Örnek Çıktı

```
John is making a reservation for flight TK1234
Reservation for flight TK1234 is completed for John
Jane is making a reservation for flight TK5678
Reservation for flight TK5678 is completed for Jane
```

Örnekte de görüldüğü gibi, Mediator tasarım deseni, nesneler arasındaki iletişimi merkezi bir noktada toplamamızı sağlıyor. Bu sayede, nesneler arasındaki bağımlılığı azaltıyor ve sistemin bakımını ve genişletilmesini kolaylaştırıyor.
