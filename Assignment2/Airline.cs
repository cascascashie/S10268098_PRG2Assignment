using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//==========================================================
// Student Number : S10268085
// Student Name : Khin Hnin Thaw 
// Partner Name : Dinglasan Casandra Antonia Sarmiento 
//==========================================================

namespace Assignment2
{
    internal class Airline
    {
        public string Name { get; private set; }
        public string Code { get; private set; }
        public Dictionary<string, string> FlightNumbers { get; set; }
        public Airline(string name, string code)
        {
            Name = name;
            Code = code;
            FlightNumbers = new Dictionary<string, string>();
        }
        public bool AddFlight(string flightNumber)
        {
            if (!FlightNumbers.ContainsKey(flightNumber))
            {
                FlightNumbers[flightNumber] = flightNumber;
                return true;
            }
            return false;
        }
        public bool RemoveFlight(string flightNumber)
        {
            return FlightNumbers.Remove(flightNumber);
        }
        public double CalculateFees()
        {
            double totalFees = FlightNumbers.Count * 500;
            int flightCount = FlightNumbers.Count;
            if (flightCount > 5)
            {
                totalFees *= 0.97;
            }
            int groupDiscount = (flightCount / 3) * 350;
            totalFees -= groupDiscount;
            return totalFees;
        }
        public override string ToString()
        {
            return $"Airline: {Name} ({Code}), Flights: {FlightNumbers.Count}";
        }
    }
}
