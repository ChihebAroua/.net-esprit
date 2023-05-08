using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Plane = AM.ApplicationCore.Domain.Plane;

namespace AM.ApplicationCore.Services
{
    public class ServiceFlight : Service<Flight>,IServiceFlight
    {

        //public List<Flight> Flights { get; set; } = new List<Flight>();
        public List<Flight> Flights { get { return GetAll().ToList(); } } 
        //public Action<Plane> FlightDetailsDel ;
        //public Func<string, double> DurationAverageDel;

        //public Func<string, double> DurationAverageDel = destination  =>
        //{
        //    var query = from f in Flights
        //                where (f.Destination.Equals(destination))
        //                select f;
        //    return query.Average(f => f.EstimatedDuration);
        //};
        public ServiceFlight(IUnitOfWork uof):base(uof)
        {

        }

      

      
        public IEnumerable<DateTime> GetFlightDates(string destination)
        {
            List<DateTime> ls = new List<DateTime>();
            //With for structure
            //for (int j = 0; j < Flights.Count; j++)
            //    if (Flights[j].Destination.Equals(destination))
            //        ls.Add(Flights[j].FlightDate);

            //With foreach structure
            //foreach (Flight f in Flights)
            //    if (f.Destination.Equals(destination))
            //        ls.Add(f.FlightDate);
            //return ls;
            //var query = from f in Flights 
            //            where f.Destination.Equals(destination)
            //            select f.FlightDate;

            var query = Flights.Where(f => f.Destination.Equals(destination)).Select(f=>f.FlightDate);
            return query;
        }
        public void ShowFlightDetails(Plane plane)
        {
            //var query = from f in Flights
            //            where f.Plane.Equals(plane)
            //            select new { f.Destination, f.FlightDate };

            var query = Flights.Where(f => f.Plane.Equals(plane)).Select(f => new { f.Destination, f.FlightDate });

            foreach (var item in query)
            {
                Console.WriteLine(" destination : {0} , flightDate : {1} ", item.Destination, item.FlightDate);
            }


        }

        public void GetFlights(string filterType, string filterValue)
        {
            switch (filterType)
            {
                case "Destination":
                    foreach (Flight f in Flights)
                    {
                        if (f.Destination.Equals(filterValue))
                            Console.WriteLine(f);
                    }
                    break;
                case "FlightDate":
                    foreach (Flight f in Flights)
                    {
                        if (f.FlightDate == DateTime.Parse(filterValue))

                            Console.WriteLine(f);

                    }
                    break;
                case "EffectiveArrival":
                    foreach (Flight f in Flights)
                    {
                        if (f.EffectiveArrival == DateTime.Parse(filterValue))
                            Console.WriteLine(f);
                    }
                    break;
            }
        }




        public int ProgrammedFlightNumber(DateTime startDate)
        {
            var query = Flights.Count(flight => (flight.FlightDate - startDate).TotalDays < 7 && (flight.FlightDate - startDate).TotalDays > 0 && flight.FlightDate.CompareTo(startDate)>=0);
              
            return query;


        }
       // public double DurationAverage
        public IEnumerable<Flight> OrderedDurationFlights()
        {
            //var query = from f in Flights
            //            orderby f.EstimatedDuration descending
            //            select f;
            //return query;
            return Flights.OrderByDescending(f => f.EstimatedDuration);
        }
        /* public IEnumerable<Passenger> SeniorTravellers(Flight flight)
         {
             var query = from passenger in flight.Passengers
                         where passenger is Traveller
                         orderby ((Traveller)passenger).BirthDate
                         select passenger;
             return query.Take(3);
             var query = from passenger in flight.Passengers.OfType<Traveller>()

                         orderby (passenger).BirthDate
                         select passenger;
             return query.Take(3);
             return flight.passengers.OfType<Traveller>().OrderBy(f => f.BirthDate).Select(p=>p.Nationality);



         }*/
        public void DestinationGroupedFlights()
        {

            //var query = from f in Flights
            //            group f by f.Destination;
            var query = Flights.GroupBy(f => f.Destination);
            foreach (var group in query)
            {
                System.Console.WriteLine(group.Key + ":");
                foreach (var p in group)
                {
                    System.Console.WriteLine("\t Décollage" + p.FlightDate);
                }
            }

        }

        //public void ShowFlightDetails(Plane plane)
        //{
           // throw new NotImplementedException();
        //}
    }







}
