using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal class Terminal
    {
        public string TerminalName { get; private set; }
        private Dictionary<string, Airline> Airlines { get; set; }
        private Dictionary<string, string> FlightNumbers { get; set; }
        private Dictionary<string, BoardingGate> BoardingGates { get; set; }
        private Dictionary<string, double> GateFees { get; set; }
        public Terminal(string terminalName)
        {
            TerminalName = terminalName;
            Airlines = new Dictionary<string, Airline>();
            FlightNumbers = new Dictionary<string, string>();
            BoardingGates = new Dictionary<string, BoardingGate>();
            GateFees = new Dictionary<string, double>();
        }
        public bool AddAirline(Airline airline)
        {
            if (!Airlines.ContainsKey(airline.Code))
            {
                Airlines[airline.Code] = airline;
                return true;
            }
            return false;
        }
        public bool AddBoardingGate(BoardingGate boardingGate)
        {
            if (!BoardingGates.ContainsKey(boardingGate.GateName))
            {
                BoardingGates[boardingGate.GateName] = boardingGate;
                return true;
            }
            return false;
        }
        public bool AddFlight(string flightNumber, string airlineCode)
        {
            if (!FlightNumbers.ContainsKey(flightNumber) && Airlines.ContainsKey(airlineCode))
            {
                FlightNumbers[flightNumber] = airlineCode;
                Airlines[airlineCode].AddFlight(flightNumber);
                return true;
            }
            return false;
        }
        public Airline? GetAirlineFromFlight(string flightNumber)
        {
            if (FlightNumbers.TryGetValue(flightNumber, out string? airlineCode))
            {
                return Airlines.GetValueOrDefault(airlineCode);
            }
            return null;
        }
        public void PrintAirlineFees()
        {
            foreach (var airline in Airlines.Values)
            {
                double fees = airline.CalculateFees();
                Console.WriteLine($"{airline.Name} Total Fees: ${fees:N2}");
            }
        }
        public override string ToString()
        {
            return $"Terminal {TerminalName}\n" +
                   $"Airlines: {Airlines.Count}\n" +
                   $"Flights: {FlightNumbers.Count}\n" +
                   $"Boarding Gates: {BoardingGates.Count}";
        }
    }   
}
