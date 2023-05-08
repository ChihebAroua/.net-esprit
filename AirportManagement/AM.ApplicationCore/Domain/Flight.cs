using System.ComponentModel.DataAnnotations.Schema;

namespace AM.ApplicationCore.Domain
{
    public class Flight
    {
        public int FlightId { get; set; }
        public DateTime FlightDate { get; set; }
        public int EstimatedDuration { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public string Departure { get; set; }
        public string Destination { get; set; }
        public virtual List<Passenger> passengers { get; set; }
        public string pilote { get; set; }
        public Flight()
        {
        }

        public Flight(DateTime flightDate, string departure)
        {
            FlightDate = flightDate;
            Departure = departure;
        }

        // public virtual List<Passenger> Passengers { get; set; }
        public virtual IList<Ticket> Tickets { get; set; }
        //[ForeignKey("Plane")]

        public int PlaneFk { get; set; }
        [ForeignKey("PlaneFk")]
        public virtual Plane Plane { get; set; }

        public override string ToString()
        {
            return "FlightDate: " + FlightDate + " Destination: " + Destination + " EstimatedDuration: " + EstimatedDuration;
        }
    }
}