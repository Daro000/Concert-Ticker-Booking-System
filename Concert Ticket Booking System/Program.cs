// See https://aka.ms/new-console-template for more information
using Concert_Ticket_Booking_System;

public interface IConcert
{
    string Name { get; set; }
    DateTime Date { get; set; }
    string Location { get; set; }
    int AvailableSeats { get; set; }
}

public class Concert : IConcert
{
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public string Location { get; set; }
    public int AvailableSeats { get; set; }

    public Concert(string name, DateTime date, string location, int availableSeats)
    {
        Name = name;
        Date = date;
        Location = location;
        AvailableSeats = availableSeats;
    }
}

class Ticket
{
    string ConcertName {get; set;}
    int Price {get; set;}
    int SeatNumber {get; set;}

    public Ticket(string ConcertName, int Price, int SeatNumber)
    {
        this.ConcertName = ConcertName;
        this.Price = Price;
        this.SeatNumber = SeatNumber;
    }
    
}

class BookingSystem
{
    
    private List<Concert> concerts = new List<Concert>();
    private List<Ticket> tickets = new List<Ticket>();
    
    public void AddNewConcert(Concert concert)
    {
    concerts.Add(concert);

    if (concert is VIPConcert vipConcert)
    {
        Console.WriteLine($"Dodano Koncert Vipowski: {vipConcert.Name}, Lokalizacja: {vipConcert.Location}, Data: {vipConcert.Date.ToShortDateString()}, Wolne miejsca: {vipConcert.AvailableSeats}, Meet&Greet: {vipConcert.HasMeetAndGreet}");;
    }
    else if (concert is OnLineConcert onlineConcert)
    {
        Console.WriteLine($"Dodano Online Koncert: {onlineConcert.Name}, Platforma: {onlineConcert.StreamingPlatform}, Data: {onlineConcert.Date.ToShortDateString()}, Wolne miejsca: {onlineConcert.AvailableSeats}");
    }
    else if (concert is PrivateConcert privateConcert)
    {
        Console.WriteLine($"Dodano Prywatny Koncert: {privateConcert.Name}, Lokalizacja: {privateConcert.Location}, Data: {privateConcert.Date.ToShortDateString()}, Na zaproszenie: {privateConcert.IsInvitation}");
    }
    else if (concert is RegularConcert)
    {
        Console.WriteLine($"Dodano Regularny Koncert: {concert.Name}, Lokalizacja: {concert.Location}, Data: {concert.Date.ToShortDateString()}, Wolne miejsca: {concert.AvailableSeats}");
    }
    
    }

    public void TicketReservation(string concertName, int seatNumber, int price)
    {
        var concert = concerts.FirstOrDefault(c => c.Name == concertName);

        if (concert == null)
        {
            Console.WriteLine($"Koncert o nazwie '{concertName}' nie istnieje.");
            return;
        }

        if (concert.AvailableSeats > 0)
        {
            concert.AvailableSeats--;
            Ticket ticket = new Ticket(concertName, price, seatNumber);
            tickets.Add(ticket);
            Console.WriteLine(
                $"Zarezerwowano bilet na koncert {concertName}, miejsce: {seatNumber}, cena: {price} zł.");
        }
        else
        {
            Console.WriteLine($"Brak wolnych miejsc na koncert {concertName}.");
        }
    }

    public void ShowConcert()
    {
        if (concerts.Count == 0)
        {
            Console.WriteLine("Nie ma koncertów");
            return;
        }

        foreach (var concert in concerts)
        {
            if (concert is VIPConcert vipConcert)
            {
                Console.WriteLine($"VIP Koncert: {vipConcert.Name}, Data: {vipConcert.Date.ToShortDateString()}, Lokalizacja: {vipConcert.Location}, Wolne miejsca: {vipConcert.AvailableSeats}, Meet&Greet: {vipConcert.HasMeetAndGreet}");
            }
            else if (concert is OnLineConcert onlineConcert)
            {
                Console.WriteLine($"Online Koncert: {onlineConcert.Name}, Data: {onlineConcert.Date.ToShortDateString()}, Platforma: {onlineConcert.StreamingPlatform}");
            }
            else if (concert is PrivateConcert privateConcert)
            {
                Console.WriteLine($"Prywatny Koncert: {privateConcert.Name}, Data: {privateConcert.Date.ToShortDateString()}, Lokalizacja: {privateConcert.Location}, Na zaproszenie: {privateConcert.IsInvitation}");
            }
            else
            {
                Console.WriteLine($"Regularny Koncert: {concert.Name}, Data: {concert.Date.ToShortDateString()}, Lokalizacja: {concert.Location}, Wolne miejsca: {concert.AvailableSeats}");
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        BookingSystem bookingSystem = new BookingSystem();
        
        bookingSystem.AddNewConcert(new RegularConcert("Disco noc", new DateTime(2024, 5, 20), "Warszawa", 100));
        bookingSystem.AddNewConcert(new VIPConcert("Jaca", new DateTime(2024, 6, 15), "Kraków", 50, true));
        bookingSystem.AddNewConcert(new OnLineConcert("Trwam", new DateTime(2024, 7, 10), "YouTube", int.MaxValue));
        bookingSystem.AddNewConcert(new PrivateConcert("Klasyczna muzyka", new DateTime(2024, 8, 5), "Gdańsk", 20, true));
        
        Console.WriteLine("\nDostępne koncerty:");
        bookingSystem.ShowConcert();
        
        Console.WriteLine("\nRezerwacja biletów:");
        bookingSystem.TicketReservation("Disco noc", 1, 200);
        bookingSystem.TicketReservation("Trwam", 5, 500);
        
    }
    
}
