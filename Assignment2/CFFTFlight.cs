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
    class CFFTFlight : Flight
    {
        // new attribute 
        public double RequestFee { get; set; }

        // constructors 
        public CFFTFlight() { }
        public CFFTFlight(string flightNumber, string origin, string destination, DateTime expectedTime, string status, double requestfee) : base(flightNumber, origin, destination, expectedTime, status)
        {
            FlightNumber = flightNumber;
            Origin = origin;
            Destination = destination;
            ExpectedTime = expectedTime;
            Status = status;
            RequestFee = requestfee;
        }

        // methods 
        public override double CalculateFees() // YET TO DO, MUST DO THE QN 
        {
            double fee = 150; // cfft fee
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

        public override string ToString()
        {
            string str = base.ToString() + $"     Request Fee : {RequestFee}";
            return str;
        }

    }
}
