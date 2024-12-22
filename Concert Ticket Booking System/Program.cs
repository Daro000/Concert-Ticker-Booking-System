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
    string concert {get; set;}
    int price {get; set;}
    int seatNumber {get; set;}

    public Ticket(string concert, int price, int seatNumber)
    {
        this.concert = concert;
        this.price = price;
        this.seatNumber = seatNumber;
    }

    public bool bookTicket()
    {
        if (Concert.AvailableSeats > 0)
        {
            Concert.AvailableSeats--;
            Console.WriteLine($"Bilet zarezerowany na koncert : {Concert.Name}, miejsce {seatNumber} , cena: {price}.");
            return true;
        }
        else
        {
            Console.WriteLine($"Brak dostepnych miejsc na koncert: {Concert.Name}");
            return false;
        }
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
    else
    {
        Console.WriteLine($"Dodano Regularny Koncert: {concert.Name}, Lokalizacja: {concert.Location}, Data: {concert.Date.ToShortDateString()}, Wolne miejsca: {concert.AvailableSeats}");
    }
    
    }

    public void TicketReservation(string concertName, int seatNumber, int price)
    {
        foreach (var concert in concerts)
        {
            if (concert.Name == concertName && concert.AvailableSeats > 0)
            {
                concert.AvailableSeats--;
                Ticket ticket = new Ticket(concertName, price, seatNumber);
                tickets.Add(ticket);
                Console.WriteLine($"Zarezerwowano bilet na koncert {concertName}, miejsce {seatNumber} , cena: {price}.");
                return;
            }
        }
        
        Console.WriteLine($"Brak wolnych miejsc na koncert lub nie istnieje");
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

