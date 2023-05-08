using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Ticket
    {
        [ForeignKey("FlightP")]
        public int FlightFK { get; set; }
        [ForeignKey("PassengerP")]
        public string PassengerFK { get; set; }
        public virtual Flight FlightP { get; set; }
        public virtual Passenger PassengerP { get; set; }
        public double Prix { get; set; }
        public bool Vip { get; set; }
        public string Siege { get; set; }
    }
}
