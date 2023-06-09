﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Traveller : Passenger
    {
        public string HealthInformation { get; set; }
        public string Nationality { get; set; }
        public Traveller()
        {

        }
        public Traveller(string passportNumber, string firstName, string lastName, DateTime birthDate, string telNumber, string emailAddress, string heathInformation, string nationality)
            : base(passportNumber, firstName, lastName, birthDate,telNumber,emailAddress)
        {
            HealthInformation = heathInformation;
            Nationality = nationality;
        }

        public override void PassengerType()
        {
            base.PassengerType();
            Console.WriteLine("and I'm a traveller");
        }

    }
}
