using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//==========================================================
// Student Number : S10268098
// Student Name : Dinglasan Casandra Antonia Sarmiento 
// Partner Name : Khin Hnin Thaw
//==========================================================

namespace Assignment2
{
    class LWTTFlight : Flight
    {
        // attribute 
        public double RequestFee { get; set; }

        // constructor 
        public LWTTFlight() { }
        public LWTTFlight(string flightNumber, string origin, string destination, DateTime expectedTime, string status, double requestfee) : base(flightNumber, origin, destination, expectedTime, status)
        {
            FlightNumber = flightNumber;
            Origin = origin;
            Destination = destination;
            ExpectedTime = expectedTime;
            Status = status;
            RequestFee = requestfee;
        }

        // method 
        public override double CalculateFees() // YET TO DO, MUST DO THE QN 
        {
            double fee = 0;
            return fee;
        }

        public override string ToString()
        {
            string str = base.ToString() + $"     Request Fee : {RequestFee}";
            return str;

        }
    }
}