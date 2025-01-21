﻿using System;
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
    internal class BoardingGate
    {
        public string GateName { get; private set; }
        public bool SupportsCFFT { get; set; }
        public bool SupportsDDJB { get; set; }
        public bool SupportsLWTT { get; set; }
        public string? AssignedFlightNumber { get; private set; }
        public BoardingGate(string gateName)
        {
            GateName = gateName;
        }
        
        public double CalculateFees()
        {
            if (AssignedFlightNumber == null)
                return 0;

            double fees = 300;
            if (SupportsDDJB) fees += 300;
            if (SupportsCFFT) fees += 150;
            if (SupportsLWTT) fees += 500;
            return fees;
        }
        public override string ToString()
        {
            string flightInfo = AssignedFlightNumber != null ? $", Assigned to {AssignedFlightNumber}" : ", Unassigned";
            return $"Gate {GateName}{flightInfo}";
        }
    }
}