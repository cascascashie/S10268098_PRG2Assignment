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
    abstract class Flight // CANNOT BE INSTANTIATED 
    {
        public string FlightNumber { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime ExpectedTime { get; set; }
        public string Status { get; set; }

        public BoardingGate BoardingGate { get; set; } // ADDED FOR THE ADVANCED METHOD, DO NOT USE FOR BASIC METHODS!

        public Flight() { }

        public Flight(string flightNumber, string origin, string destination, DateTime expectedTime, string status)
        {
            FlightNumber = flightNumber;
            Origin = origin;
            Destination = destination;
            ExpectedTime = expectedTime;
            Status = status;
        }

        public virtual double CalculateFees()
        {
            double fee = 0; 
            double arrivefee = 500;
            double departfee = 800;
            double boardgatebasefee = 300;

            if (Origin != "Singapore(SIN)") // IF ORIGIN IS NOT SINGAPORE, MEANS COMES FROM OTHER COUNTRIES/COMING TO SINGAPORE)
            {
                fee = fee + arrivefee;
            }
            else // DEPARTING FROM SINGPORE 
            {
                fee = fee + departfee + boardgatebasefee;
            }
            return fee;
        }

        public override string ToString() // NEED TO CHECK THE SAMPLE IF CORRECT
        {
            string str = $"Flight Number : {FlightNumber}     Origin : {Origin}     Destination : {Destination}     Expected Time : {ExpectedTime}     Status : {Status}";
            return str;
        }
    }
}
