namespace CalculatorLite;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("=== Calculator Lite ===\n");

        // TODO: Declare variables for storing user input (use descriptive names)
        // Hint: You'll need variables for two numbers, user name, and calculation choice

        // TODO: Ask for user's name (string) and greet them
        // Example: "Enter your name: " then "Hello, [name]!"

        // TODO: Ask if they want to use decimals (bool)
        // Example: "Use decimal precision? (yes/no): "
        // Store as boolean (true for yes, false for no)

        // TODO: Prompt user for first number (double or int based on choice)
        // If decimals: use double.Parse()
        // If no decimals: use int.Parse() then cast to double

        // TODO: Prompt user for second number (same type as first)

        // TODO: Calculate ALL arithmetic operations:
        // - sum (addition: +)
        // - difference (subtraction: -)
        // - product (multiplication: *)
        // - quotient (division: /)
        // - remainder (modulus: %)
        // - average ((num1 + num2) / 2)

        // TODO: Display results with proper formatting
        // Show 2 decimal places: {value:F2}
        // Include descriptive labels for each operation

        // TODO: Check if second number is zero BEFORE dividing
        // Use if statement: if (num2 == 0) { show error } else { calculate }

        // TODO: Count total calculations performed (int)
        // Display: "Performed [count] calculations for [name]!"

        // TODO: Calculate percentage difference
        // Formula: ((num1 - num2) / num1) * 100
        // Display with % symbol
        Console.WriteLine("\nThank you for using Calculator Lite!");
    }
}
