using System.ComponentModel.DataAnnotations;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        public Passenger()
        {
        }

        //public int Id { get; set; }
        [Key, StringLength(7)]
        public string PassportNumber { get; set; }

        [MinLength(3, ErrorMessage = "Name length can't be less than 8."), MaxLength(25, ErrorMessage = "Name length can't be more than 8.")]
        //public string FirstName { get; set; }

        //public string LastName { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [RegularExpression(@"^[0-9]{8}$")]
        public string TelNumber { get; set; }
        public Fullname Fullname { get; set; }
        [EmailAddress]
        public string EmailAddress { get; set; }

        // public virtual List<Flight> Flights { get; set; }
        public virtual IList<Ticket> Tickets { get; set; }

        public Passenger(string passportNumber, string firstName, string lastName, DateTime birthDate, string telNumber, string emailAddress)
        {
            PassportNumber = passportNumber;
            //FirstName = firstName;
            //LastName = lastName;
            BirthDate = birthDate;
            TelNumber = telNumber;
            EmailAddress = emailAddress;
        }

        //public bool CheckProfile(string firstName, string lastName, string email = null)
        //{
        //    //if (email != null)
        //    //    return FirstName == firstName && LastName == lastName &&
        //    //    EmailAddress == email;
        //    //else
        //    //    return FirstName == firstName && LastName == lastName;
        //}

        //public override string ToString()
        //{
        //    return "FirstName: " + FirstName + " LastName: " + LastName + " date of Birth: " + BirthDate;
        //}

        public virtual void PassengerType()
        {
            Console.WriteLine("I am a Passenger");
        }
    }
}