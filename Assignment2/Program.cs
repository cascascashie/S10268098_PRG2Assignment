// See https://aka.ms/new-console-template for more information

// BASIC FEATURES [50% INDIVIDUAL]

// METHOD 1 - Load files (airlines and boarding gates) [CASANDRA] 

using Assignment2;

void LoadAirlinesAndBoardingGates()
{
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
            Airline airline = new Airline(data[0], data[1]);
            Airline.Flights.Add(data[0], airline);
        }
    }

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
            Console.WriteLine(data);
            Console.WriteLine("");

            string[] boardingGatesDetails = data.Split(",");

            // NOTE
            // DATA[0] REPRESENTS BOARDING GATE 
            // DATA[1] REPRESENTS DDJB
            // DATA[2] REPRESENTS CFFT
            // DATA[3] REPRESENTS LWTT

            // MAKING NEW BOARDINGGATE OBJECTS 
            BoardingGate boardinggate = new BoardingGate(boardingGatesDetails[0], boardingGatesDetails[1], boardingGatesDetails[2], boardingGatesDetails[3]); 

            Terminal.BoardingGates.Add(data[0], boardinggate); 
    }
}


    // METHOD 2 - Load files (flights) [HNIN THAW]

    void LoadFlights()
    {
        // CAN ADJUST TO HOWEVER YOU WANT 
    }




    // METHOD 3 - List all flights with basic information [HNIN THAW]

    void ListFlightDetails()
    {
        // CAN ADJUST TO HOWEVER YOU WANT 
    }




    // METHOD 4 - List all boarding gates [CASANDRA] 

    void ListBoardingGates()
    {
        // CAN ADJUST TO HOWEVER YOU WANT 
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
        // CAN ADJUST TO HOWEVER YOU WANT 
    }




    // METHOD 8 - Modify flight details [CASANDRA] 

    void ModifyFlightDetails()
    {
        // CAN ADJUST TO HOWEVER YOU WANT 
    }




    // METHOD 9 - Display scheduled flights in chronological order, where boarding gates are applicable [HNIN THAW]

    void DisplayFlights()
    {
        // CAN ADJUST TO HOWEVER YOU WANT 
    }





    // ADVANCED FEATURES [20% INDIVIDUAL]

    // METHOD (a) - Process all unassigned flights to boarding gates in bulk

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
        Console.WriteLine("1. List All Flights");
        Console.WriteLine("2. List Boarding Gates");
        Console.WriteLine("3. Assign a Boarding Gate to a Flight");
        Console.WriteLine("4. Create Flight");
        Console.WriteLine("5. Display Airline Flights");
        Console.WriteLine("6. Modify Flight Details");
        Console.WriteLine("7. Display Flight Schedule");
        Console.WriteLine("0. Exit");
        Console.WriteLine("Please select your option: ");
    }




    // MAIN LOOP 

    // NOTE FOR FUTURE REFERENCE : 
    // WHEN LOADING THE FILES, NEED TO PUT "FINISHED LOADING AND DISPLAY QUANTITY OF THINGS LOADED, THEN HAVE A GAP
    // BEFORE THE MAIN MENU 


