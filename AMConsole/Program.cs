// See https://aka.ms/new-console-template for more information


using AM.applicationcore.Domain;
using AM.applicationcore.Services;
using AM_Application_Core.Domain;

Console.WriteLine("Hello, World!");
Plane plane = new Plane();
plane.Capacity = 5;
//Plane plane1 = new Plane(10,new DateTime(2025/05/25) );
//initializateur d'objet 
Plane plane2 = new Plane
{
    Capacity = 10,
    PlaneType = PlaneType.BOING
};
Passenger passenger = new Passenger()
{
    LastName = "Abdo",
    FirstName = "abdo",
    EmailAddress = "abdessalem@gmail.com"
};
Staff staff = new Staff()
{
    FirstName = "lasswed"
};
Traveller traveller = new Traveller()
{
    FirstName = "abdessalem"
};
Console.WriteLine("***************POLY PAR SIGNATURE***********");
Console.WriteLine(passenger.CheckProfile("Abdo", "Abdo"));
Console.WriteLine(passenger.CheckProfile("abdo","jobs", "abdo@gmail.com"));
Console.WriteLine("***************POLY PAR HERIAGE***********");
passenger.PassengerType();
staff.PassengerType();
traveller.PassengerType();

FlightMethod fm = new FlightMethod();
fm.flights = Data.listFlights;
Console.WriteLine("show flight details");
fm.ShowFlightDetails(Data.Airbusplane);
Console.WriteLine("get flight datails");
foreach(var item in fm.GetFlightDates("Madrid"))
{
    Console.WriteLine(item);
}
Console.WriteLine("destination grouped");
fm.DestinationGroupedFlights();