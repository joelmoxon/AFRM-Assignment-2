// Get flight parameters from the user
double distance = GetValidInput("Enter the distance (NM): ");
double airspeed = GetValidInput("Enter the airspeed (knots): ");

// Get fuel parameters from the user
double fuelBurnRate = GetValidInput("Enter the fuel burn rate (kg/hr): ");
double reserveMinutes = GetValidInput("Enter the reserve fuel duration (minutes): ");
double currentFuel = GetValidInput("Enter the current fuel on board (kg): ");

// Get wind parameters from the user
Console.Write("Enter wind direction (H = headwind, T = tailwind, N = None): ");
string windDirection = Console.ReadLine() ?? "";

Console.Write("Enter wind speed (knots): ");
double windSpeed = GetValidInput("");

// Calculate ground speed based on wind direction
double groundSpeed;

if (windDirection == "H" || windDirection == "h")
{
    groundSpeed = airspeed - windSpeed;
}
else if (windDirection == "T" || windDirection == "t")
{
    groundSpeed = airspeed + windSpeed;
}
else
{
    groundSpeed = airspeed;
}

// Ensure ground speed is greater than zero
if (groundSpeed <= 0)
{
    Console.WriteLine("Error: Ground speed must be greater than 0. Check wind conditions.");
    return;
}

// Calculate flight time and required fuel
double flightTime = distance / groundSpeed;
double reserveHours = reserveMinutes / 60.0; 
double requiredFuel = flightTime * fuelBurnRate + reserveHours * fuelBurnRate;

// Calculate fuel difference and status
double fuelDifference = currentFuel - requiredFuel;

string fuelStatus;

if (fuelDifference >= 0)
{
    fuelStatus = "Sufficient fuel";
}
else
{
    fuelStatus = "Insufficient fuel";
}

// Display required fuel to the user
Console.WriteLine();    
Console.WriteLine("------------------------------------");  
Console.WriteLine($"Required fuel: {requiredFuel:F2} kg");
Console.WriteLine($"Current fuel: {currentFuel:F2} kg");
Console.WriteLine($"Fuel difference: {fuelDifference:F2} kg");
Console.WriteLine($"Fuel status: {fuelStatus}");
Console.WriteLine("------------------------------------");

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
