// Get flight parameters from the user
double distance = GetValidInput("Enter the distance (NM): ");
double airspeed = GetValidInput("Enter the speed (knots): ");

// Get fuel parameters from user
double fuelBurnRate = GetValidInput("Enter the fuel burn rate (kg/hr): ");
double reserveMinutes = GetValidInput("Enter the reserve fuel duration (minutes): ");

// Get wind parameters from the user
Console.WriteLine("Enter wind direction (H = headwind, T = tailwind, N = None):");
string windDirection = Console.ReadLine() ?? "";

Console.WriteLine("Enter wind speed (knots):");
double windSpeed = GetValidInput("");

// Calculate ground speed based on wind direction
double groundSpeed;

if (windDirection == "H")
{
    groundSpeed = airspeed - windSpeed;
}
else if (windDirection == "T")
{
    groundSpeed = airspeed + windSpeed;
}
else
{
    groundSpeed = airspeed;
}

// Calculate flight time and required fuel
double flightTime = distance / groundSpeed;
double reserveHours = reserveMinutes / 60.0; 
double requiredFuel = flightTime * fuelBurnRate + reserveHours * fuelBurnRate;

// Display required fuel to the user
Console.WriteLine($"Required fuel: {requiredFuel:F2} kg");

// Validate user input
static double GetValidInput(string prompt)
{
    double input;

    while (true)
    {
        Console.Write(prompt);

        if (double.TryParse(Console.ReadLine(), out input) && input > 0)
        {
            return input;
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number greater than 0.");
        }
    }
}
