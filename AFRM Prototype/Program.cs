// Get flight parameters from the user
double distance = GetValidInput("Enter the distance (NM): ");
double airspeed = GetValidInput("Enter the airspeed (knots): ");

// Get fuel parameters from the user
double fuelBurnRate = GetValidInput("Enter the fuel burn rate (kg/hr): ");
double reserveMinutes = GetValidInput("Enter the reserve fuel duration (minutes): ");
double currentFuel = GetValidInput("Enter the current fuel on board (kg): ");

// Get wind speed from the user
double windSpeed;

while (true)
{   
    Console.Write("Enter wind speed (knots): ");

    if (double.TryParse(Console.ReadLine(), out windSpeed) && windSpeed >= 0)
    {
        break;
    }
    else
    {
        Console.WriteLine("Invalid input. Please enter a number greater than or equal to 0.");
    }
}

// Get wind direction from the user
double windDirection;

while (true) 
{
    Console.Write("Enter relative wind direction (degrees): ");

    if (double.TryParse(Console.ReadLine(), out windDirection) && windDirection >= 0 && windDirection <= 360)
    {
        break;
    }
    else
    {
        Console.WriteLine("Invalid input. Please enter a number between 0 and 360.");
    }
}

// Calculate wind components   
double headwindComponent = windSpeed * Math.Cos(windDirection * Math.PI / 180);
double crosswindComponent = windSpeed * Math.Sin(windDirection * Math.PI / 180);


// Calculate ground speed 

double forwardSpeed = airspeed - headwindComponent;
double groundSpeed = Math.Sqrt(forwardSpeed * forwardSpeed + crosswindComponent * crosswindComponent);

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
    fuelStatus = "SUFFICIENT fuel";
}
else
{
    fuelStatus = "INSUFFICIENT fuel";
}

// Display required fuel to the user
Console.WriteLine();    
Console.WriteLine("------------------------------------");  
Console.WriteLine($"Required fuel: {requiredFuel:F2} kg");
Console.WriteLine($"Current fuel: {currentFuel:F2} kg");
Console.WriteLine($"Fuel difference: {fuelDifference:F2} kg");
Console.WriteLine();
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
