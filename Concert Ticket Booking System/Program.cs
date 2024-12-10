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

    public void bookTicket()
    {
        
    }
}

class BookingSystem
{
    public void AddNewConcert()
    {

    }

    public void TicketReservation()
    {

    }

    public void ShowConcert()
    {

    }
}
