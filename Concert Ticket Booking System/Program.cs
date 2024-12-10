// See https://aka.ms/new-console-template for more information

class Concert
{
    string name {get; set;}
    string date {get; set;}
    string location {get; set;}
    string availableSeats {get; set;}

    public Concert(string name, string date, string location, string availableSeats)
    {
        this.name = name;
        this.date = date;
        this.location = location;
        this.availableSeats = availableSeats;
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
