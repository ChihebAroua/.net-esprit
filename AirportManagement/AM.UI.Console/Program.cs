using AM.ApplicationCore;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;
Plane plane = new Plane();
plane.PlaneType = PlaneType.Airbus;
plane.Capacity = 200;
plane.ManufactureDate = new DateTime(2018, 11, 10);

Plane plane3 = new Plane
{
    PlaneType = PlaneType.Airbus,
    Capacity = 150,
    ManufactureDate = new DateTime(2015, 02, 03)
};

//Passenger passenger = new Passenger();
//passenger.BirthDate = DateTime.Now;
//passenger.FirstName = "Emna";
//passenger.LastName = "Khanfir";
//passenger.EmailAddress = "eman.khanfir@esprit.tn";

Passenger passenger1 = new Passenger("123456789", "Amal", "Amal", new DateTime(2022, 12, 5), "amal.amal@gmail.com", "25896347");


//Passenger passenger2 = new Passenger()
//{
//    PassportNumber = "45464654",
//    FirstName = "FistName",
//    LastName = "LastName",
//    BirthDate = new DateTime(1955, 2, 4),
//    TelNumber = "5657542"
//};

//Passenger passenger3 = new Passenger("123456789", "Amal", "Amal", new DateTime(2022, 12, 5), "amal.amal@gmail.com", "25896347")
//{
//    PassportNumber = "45464654",
//    FirstName = "FistName",
//    LastName = "LastName",
//    BirthDate = new DateTime(1955, 2, 4),
//    TelNumber = "5657542"
//};

Passenger traveller = new Traveller("123456789", "med", "med", new DateTime(2022, 11, 5), "med.ned@gmail.com", "8956347", "", "Tunisienne");


//passenger3.PassengerType();
Console.WriteLine("----------------------------");
traveller.PassengerType();

//Console.WriteLine(passenger);
//Console.WriteLine(passenger1);
//Console.WriteLine( passenger2);
//ServiceFlight serviceFlight = new ServiceFlight();
//serviceFlight.Flights = TestData.listFlights;
//int x = 2;
//Console.WriteLine(x.Ajouter(5));
    