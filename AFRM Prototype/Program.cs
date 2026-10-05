// Get flight parameters from the user
double distance = GetValidInput("Enter the distance (NM): ");
double speed = GetValidInput("Enter the speed (knots): ");
double fuelBurnRate = GetValidInput("Enter the fuel burn rate (kg/hr): ");

// Calculate flight time and required fuel
double flightTime = distance / speed;
double requiredFuel = flightTime * fuelBurnRate;

Console.WriteLine($"Flight time: {flightTime} hours");
Console.WriteLine($"Required fuel: {requiredFuel} kg");

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
