// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
using Assignment2;

// DICTIONARY'S
// AIRLINES
Dictionary<string, Airline> AirlineDict = new Dictionary<string, Airline>();

// BOARDING GATE
Dictionary<string, BoardingGate> BoardingGateDict = new Dictionary<string, BoardingGate>();

// FLIGHTS
Dictionary<string, Flight> FlightDict = new Dictionary<string, Flight>();


// BASIC FEATURES [50% INDIVIDUAL]

// METHOD 1 - Load files (airlines and boarding gates) [CASANDRA] 
void LoadAirlinesAndBoardingGates()
{

    Console.WriteLine("Loading Airlines...");

    // LOADING AIRLINES
    string[] airlinesData = File.ReadAllLines("airlines.csv"); // ALL OF THE AIRLINES (AIRLINE, AIRLINES CODE)

    foreach (string data in airlinesData)
    {
        if (data == airlinesData[0])
        {
            continue;
        }

        else
        {
            string[] airlinesDetails = data.Split(','); // SPECIFIC DETAILS FOR ONE AIRLINES (SPECIFIC AIRLINE, AIRLINES CODE}

            // NOTE 
            // DATA [0] REPRESENTS THE AIRLINES NAME
            // DATA [1] REPRESENTS THE AIRLINES CODE 
            
            // MAKING THE NEW AIRLINES OBJECTS 
            Airline airline = new Airline(airlinesDetails[0], airlinesDetails[1]);

            AirlineDict.Add(airlinesDetails[0], airline);
        }
    }

    Console.WriteLine($"{AirlineDict.Count()} Airlines Loaded!");

    Console.WriteLine("Loading Boarding Gates...");

    // LOADING BOARDING GATES 
    string[] boardingGatesData = File.ReadAllLines("boardinggates.csv");

    foreach (string data in boardingGatesData)
    {
        if (data == boardingGatesData[0])
        {
            continue;
        }
        else
        {
            //Console.WriteLine(data);
            //Console.WriteLine("");

            string[] boardingGatesDetails = data.Split(",");

            // NOTE
            // DATA[0] REPRESENTS BOARDING GATE 
            // DATA[1] REPRESENTS DDJB
            // DATA[2] REPRESENTS CFFT
            // DATA[3] REPRESENTS LWTT

            // MAKING NEW BOARDINGGATE OBJECTS 
            BoardingGate boardinggate = new BoardingGate(boardingGatesDetails[0], Convert.ToBoolean(boardingGatesDetails[1]), Convert.ToBoolean(boardingGatesDetails[2]), Convert.ToBoolean(boardingGatesDetails[3]));

            BoardingGateDict.Add(boardingGatesDetails[0], boardinggate);
        }
    }

    Console.WriteLine($"{BoardingGateDict.Count()} Boarding Gates Loaded!");

}


// METHOD 2 - Load files (flights) [HNIN THAW]
void LoadFlights()
{

    Console.WriteLine("Loading Flights...");

    string[] flightsData = File.ReadAllLines("flights.csv");

    foreach (string data in flightsData)
    {
        if (data == flightsData[0])
        {
            continue;
        }

        string[] flightDetails = data.Split(",");

        Flight flight = new NORMFlight(
            flightDetails[0],  // flight no.
            flightDetails[1],  // origin
            flightDetails[2],  // destination
            DateTime.Parse(flightDetails[3]),  // expected time
            flightDetails[4]   // status, scheduled etc 
        );

        FlightDict.Add(flightDetails[0], flight);

        // Obtaining the airline code from the flight 
        string[] flight_code = flightDetails[0].Split(" ");

        // flight_code[0] is the code 
        // flight_code[1] is the number

        foreach (Airline airline in AirlineDict.Values)
        {
            if (flight_code[0] == airline.Code)
            {
                airline.Flights.Add(flightDetails[0], flight);
            }
            else
            {
                continue;
            }
        }
    }

    Console.WriteLine($"{FlightDict.Count()} Flights Loaded!");

}


// METHOD 3 - List all flights with basic information [HNIN THAW]

void ListFlightDetails()
{
    // CAN ADJUST TO HOWEVER YOU WANT 
}




// METHOD 4 - List all boarding gates [CASANDRA] 

void ListBoardingGates()
{
    // TITLE
    Console.WriteLine("=============================================");
    Console.WriteLine("List of Boarding Gates for Changi Airport Terminal 5");
    Console.WriteLine("=============================================");

    // HEADER 
    Console.WriteLine($"{"Gate Name",-16}{"DDJB",-23}{"CFFT",-23}{"LWTT",-6}");

    // LISTING THE ACTUAL BOARDING GATES INFORMATION 
    foreach (BoardingGate BoardingGateInfo in BoardingGateDict.Values)
    {
        Console.WriteLine($"{BoardingGateInfo.GateName,-16}{BoardingGateInfo.SupportsDDJB,-23}{BoardingGateInfo.SupportsCFFT,-23}{BoardingGateInfo.SupportsLWTT,-6}");
    }

}




// METHOD 5 - Assign a boarding gate to a flight [HNIN THAW]

void AssignBoardingGateToFlight()
{
    // CAN ADJUST TO HOWEVER YOU WANT 
}




// METHOD 6 - Create a new flight [HNIN THAW]

void CreateFlight()
{
    // CAN ADJUST TO HOWEVER YOU WANT 
}




// METHOD 7 - Display full flight details from an airline [CASANDRA] 

void FullFlightDetail()
{
    // TITLE
    Console.WriteLine("=============================================");
    Console.WriteLine("List of Airlines for Changi Airport Terminal 5");
    Console.WriteLine("=============================================");

    // HEADER
    Console.WriteLine($"{"Airline Code",-16}{"Airline Name",-18}");

    // INFO ABOUT THE AIRLINES 
    foreach (Airline AirlineInfo in AirlineDict.Values)
    {
        Console.WriteLine($"{AirlineInfo.Code,-16}{AirlineInfo.Name,-18}");
    }

    Console.Write("Enter Airline Code: ");
    string chosen_code = Console.ReadLine();

    // VARIABLE FOR THE CHOSEN AIRLINE
    Airline chosen_airline = null;

    foreach (Airline airline in AirlineDict.Values)
    {
        if (airline.Code == chosen_code)
        {
            chosen_airline = airline;
        }
    }

    // THE NAME ADJUSTS ACCORDING TO THE CHOSEN AIRLINE CODE 
    Console.WriteLine("=============================================");
    Console.WriteLine($"List of Flights for {chosen_airline.Name}");
    Console.WriteLine("=============================================");

    // HEADER 
    Console.WriteLine($"{"Flight Number",-18}{"Airline Name",-23}{"Origin",-23}{"Destination",-23}{"Expected Departure/Arrival Time"}");

    // FLIGHT DETAILS. NEED TO FIX SO THAT AIRLINE DICTIONARY CONTAINS THE SPECIFIC FLIGHTS FOR EACH AIRLINE !!!! NEED FIX 
    foreach (Airline airline in AirlineDict.Values)
    {
        if (airline.Name == chosen_airline.Name)
        {
            foreach (Flight flight in airline.Flights.Values)
            {
                Console.WriteLine($"{flight.FlightNumber,-18}{chosen_airline.Name,-23}{flight.Origin,-23}{flight.Destination,-23}{flight.ExpectedTime}");
            }

        }
        else { continue; }
    }


}




// METHOD 8 - Modify flight details [CASANDRA] 

void ModifyFlightDetails()
{
    // TITLE
    Console.WriteLine("=============================================");
    Console.WriteLine("List of Airlines for Changi Airport Terminal 5");
    Console.WriteLine("=============================================");

    // HEADER
    Console.WriteLine($"{"Airline Code",-16}{"Airline Name",-18}");

    // INFO ABOUT THE AIRLINES 
    foreach (Airline AirlineInfo in AirlineDict.Values)
    {
        Console.WriteLine($"{AirlineInfo.Code,-16}{AirlineInfo.Name,-18}");
    }

    Console.WriteLine("Enter Airline Code: ");
    string chosen_code = Console.ReadLine();

    // VARIABLE FOR THE CHOSEN AIRLINE
    Airline chosen_airline = null;

    foreach (Airline airline in AirlineDict.Values)
    {
        if (airline.Code == chosen_code)
        {
            chosen_airline = airline;
        }
    }

    Console.WriteLine($"List of Flights for {chosen_airline.Name}");

    // HEADER 
    Console.WriteLine($"{"Flight Number",-18}{"Airline Name",-23}{"Origin",-23}{"Destination",-23}{"Expected Departure/Arrival Time"}");

    // FLIGHT DETAILS

    // obtaining the specific airline object
    Airline specific_airline = null;

    foreach (Airline airline in AirlineDict.Values)
    {
        if (airline.Name == chosen_airline.Name)
        {
            specific_airline = airline; // obtaining the chosen airline object 
            foreach (Flight flight in airline.Flights.Values)
            {
                Console.WriteLine($"{flight.FlightNumber,-18}{chosen_airline.Name,-23}{flight.Origin,-23}{flight.Destination,-23}{flight.ExpectedTime}");
            }

        }
        else { continue; }
    }

    // LETTING USER CHOOSE THE FLIGHT TO CHANGE
    Console.WriteLine("Choose an existing Flight to modify or delete: ");
    string chosen_flight = Console.ReadLine();

    // need to obtain the specific flight object 
    Flight chosen_flight_number = null;
    foreach (Flight flight_object in specific_airline.Flights.Values)
    {
        if (flight_object.FlightNumber == chosen_flight)
        {
            chosen_flight_number = flight_object;
        }
    }


    // OPTIONS AFTER PICKING THE FLIGHT
    void OptionsAfterPickingFlight()
    {
        Console.WriteLine("1. Modify Flight");
        Console.WriteLine("2. Delete Flight");
    }

    // Console.WriteLine(chosen_flight_number.ToString()); DEBUG, TO SEE IF CAN OBTAIN THE FLIGHT OBJECT 

    OptionsAfterPickingFlight();
    Console.WriteLine("Choose an option:");
    int user_option = Convert.ToInt32(Console.ReadLine());

    // OPTION 1, MODIFYING THE FLIGHT 
    void ModifyingFlight()
    {
        Console.WriteLine("1. Modify Basic Information");
        Console.WriteLine("2. Modify Status");
        Console.WriteLine("3. Modify Special Request Code");
        Console.WriteLine("4. Modify Boarding Gate");
    }

    //ModifyingFlight(); // TO TEST ONLY

    // -> OPT 1
    void ChangingFlightDetails()
    {
        Console.Write("Enter new Origin: ");
        string new_origin = Console.ReadLine();
        chosen_flight_number.Origin = new_origin;

        Console.Write("Enter new Destination: ");
        string new_destination = Console.ReadLine();
        chosen_flight_number.Destination = new_destination;


        Console.Write("Enter new Expected Departure/Arrival Time (dd/mm/yyyy hh:mm): ");
        DateTime new_time = Convert.ToDateTime(Console.ReadLine());
        chosen_flight_number.ExpectedTime = new_time;

        Console.WriteLine("Flight updated!");

        Console.WriteLine($"Flight Number: {chosen_flight_number.FlightNumber}");
        Console.WriteLine($"Airline Name: {specific_airline.Name}");
        Console.WriteLine($"Origin: {chosen_flight_number.Origin}");
        Console.WriteLine($"Destination: {chosen_flight_number.Destination}");
        Console.WriteLine($"Expected Departure/Arrival Time: {chosen_flight_number.ExpectedTime}");
        Console.WriteLine($"Status: {chosen_flight_number.Status}");
        //Console.WriteLine($"Special Request Code: {chosen_flight_number.}"); NEED TO OBTAIN SPECIAL REQUEST CODE
        //Console.WriteLine($"Boarding Gate: {chosen_flight_number.}"); NEED TO OBTAIN BOARDING GATE 
    }

    //ChangingFlightDetails(); // TESTING ONLY

    // OPTION 2, DELETING A FLIGHT 
    void DeletingAFlight()
    {
        Console.WriteLine($"Are you sure you want to delete {chosen_flight_number.FlightNumber}? [Y/N]: ");
        string user_confirmation = Console.ReadLine(); // EITHER YES OR NO

        // IF YES, NEED TO REMOVE FLIGHT FROM THE DICTIONARY
        // IF NO, GET OUT OF THIS FUNCTION LOOP 
    }

    //DeletingAFlight(); // TESTING ONLY

    // LETTING USER PICK EITHER TO MODIFY OR TO DELETE
    if (user_option == 1)
    {
        ModifyingFlight();
        Console.WriteLine("Choose an option: ");
        int next_user_option = Convert.ToInt32(Console.ReadLine());

        // OPTION 1
        if (next_user_option == 1)
        {
            ChangingFlightDetails();
        }
        // OPTION 2
        else if (next_user_option == 2)
        { }

        // OPTION 3
        else if (next_user_option == 3)
        {

        }
        // OPTION 4
        else if (next_user_option == 4)
        {

        }
        else
        {
            Console.WriteLine("Invalid option!");
        }


    }
    else if (user_option==2)
    {
        DeletingAFlight();
    }
}




// METHOD 9 - Display scheduled flights in chronological order, where boarding gates are applicable [HNIN THAW]

void DisplayFlights()
{
    // CAN ADJUST TO HOWEVER YOU WANT 
}





// ADVANCED FEATURES [20% INDIVIDUAL]

// METHOD (a) - Process all unassigned flights to boarding gates in bulk
// CAS 

void ProcessUnassignedFlights() 
{
    // CAN ADJUST TO HOWEVER YOU WANT 
}




// METHOD (b) - Display the total fee per airline for the day

void DisplayTotalFee()
{
    // CAN ADJUST TO HOWEVER YOU WANT 
}




// OTHER METHODS




// MAIN MENU METHOD 
void MainMenu()
{
    Console.WriteLine("=============================================");
    Console.WriteLine("Welcome to Changi Airport Terminal 5");
    Console.WriteLine("=============================================");
    Console.WriteLine("1. List All Flights"); // HT
    Console.WriteLine("2. List Boarding Gates"); // CAS
    Console.WriteLine("3. Assign a Boarding Gate to a Flight"); // HT 
    Console.WriteLine("4. Create Flight"); // HT 
    Console.WriteLine("5. Display Airline Flights"); // CAS
    Console.WriteLine("6. Modify Flight Details"); // CAS 
    Console.WriteLine("7. Display Flight Schedule"); // HT
    Console.WriteLine("0. Exit");
    Console.WriteLine();
}


// MAIN LOOP 

// LOADING EVERYTHING, ONLY SHOWS UP ONCE
LoadAirlinesAndBoardingGates();
LoadFlights();

// THE BLANK SPACE 
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();

while (true)
{

    MainMenu();
    Console.WriteLine("Please select your option:"); // correct that it is writeLINE
    int user_option = Convert.ToInt32( Console.ReadLine() );

    if (user_option == 0)
    {
        Console.WriteLine("Goodbye!");
        break;
    }
    else if (user_option == 1)
    {
        // HT'S FUNCTION
    }
    else if (user_option == 2)
    {
        ListBoardingGates();
    }
    else if (user_option == 3)
    {
        // HT'S FUNCTION
    }
    else if (user_option == 4)
    {
        // HT'S FUNCTION
    }
    else if (user_option == 5)
    {
        FullFlightDetail();    
    }
    else if (user_option == 6)
    {
        ModifyFlightDetails();
    }
    else if (user_option == 7)
    {
        // HT'S FUNCTION
    }
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine();
}



