namespace Concert_Ticket_Booking_System;



public class RegularConcert : Concert
{
    public RegularConcert(string name, DateTime date, string location, int avaibleSeats)
        : base(name, date, location, avaibleSeats)
    {
    }
}

public class VIPConcert : Concert
{
    public bool HasMeetAndGreet { get; set; }

    public VIPConcert(string name, DateTime date, string location, int availableSeats, bool hasMeetAndGreet)
        : base(name, date, location, availableSeats)
    {
        HasMeetAndGreet = hasMeetAndGreet;
    }
}


public class OnLineConcert : Concert
{
    public string StreamingPlatform { get; set; }

    public OnLineConcert(string name, DateTime date, string streamingPlatform, int avaibleSeats)
        : base(name, date, "onilne", avaibleSeats)
    {
        StreamingPlatform = streamingPlatform;
    }
}

public class PrivateConcert : Concert
{
    public bool IsInvitation { get; set; }

    public PrivateConcert(string name, DateTime date, string location, int avaibleSeats, bool isInvitation)
        : base(name, date, location, avaibleSeats)
    {
        IsInvitation = isInvitation;
    }
}
