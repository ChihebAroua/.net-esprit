using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace AM.ApplicationCore.Services
{
    public class ServicePlane : Service<Plane>,IServicePlane
    {
        public ServicePlane(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<Passenger> GetPassenger(Plane plane)
        {

            return GetById(plane.PlaneId).Flights.SelectMany(f => f.Tickets).Select(t => t.PassengerP);
        }
        public IEnumerable<Flight> GetFlights(int n )
        {


            return GetAll().OrderByDescending(p => p.PlaneId).Take(n).SelectMany(t => t.Flights).OrderBy(f => f.FlightDate);
        }

        public Boolean IsAvailablePlane(Flight flight, int n)
        {
            return GetById(flight.PlaneFk).Capacity - flight.Tickets.Count() > n;

        }


        public void DeletePlanes(string date )

        {
            DateTime date1 = DateTime.Parse(date);
            Delete(p=>p.ManufactureDate.Year - date1.Year > 10);

        }
        


















    }
}

