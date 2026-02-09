//Git actually works, we're actually so back bro :)
using System.Security.Cryptography;

namespace ProfileCard;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("╔════════════════════════════════════════════╗");
        Console.WriteLine("║         STUDENT PROFILE BUILDER            ║");
        Console.WriteLine("╚════════════════════════════════════════════╝\n");

        // TODO: Collect PERSONAL INFORMATION (strings)
        Console.WriteLine("Please enter the following information:");

        // - Full name
        Console.WriteLine("\nWhat is your full name?");
        string fullName = Console.ReadLine();

        // - Hometown (city, state)
        Console.WriteLine("\nWhat is hometown? (city, state)");
        string homeTown = Console.ReadLine();

        // - Favorite color
        Console.WriteLine("\nWhat is your favorite color?");
        string faveColor = Console.ReadLine();

        // - Dream job
        Console.WriteLine("\nWhat is your dream job?");
        string dreamJob = Console.ReadLine();

        // Hint: string variableName = Console.ReadLine();

        // TODO: Collect ACADEMIC INFORMATION

        // - Major (string)
        Console.WriteLine("\nWhat is your major?");
        string major = Console.ReadLine();

        // - GPA (double, 0.0-4.0)
        Console.WriteLine("\nWhat is your current GPA?");
        double gpa = double.Parse(Console.ReadLine());

        // - Graduation year (int)
        Console.WriteLine("\nWhat is your graduation year? [year]");
        int gradYear = int.Parse(Console.ReadLine());

        // - Is full-time student? (bool from yes/no)
        Console.WriteLine("\nAre you a full time student? [Yes/No]?");
        string response = Console.ReadLine().ToLower();
        bool isFullTime = false;
        if (response == "yes" || response == "y") { isFullTime = true; }

        // Hint: double gpa = double.Parse(Console.ReadLine());
        // Hint: bool isFullTime = answer.ToLower() == "yes";

        // TODO: Collect ADDITIONAL DETAILS
        // - Age (int)
        Console.WriteLine("\nWhat is your age?");
        int age = int.Parse(Console.ReadLine());

        // - Height in inches (double)
        Console.WriteLine("\nWhat is your height?");
        double rawHeight = double.Parse(Console.ReadLine());

        // - Favorite number (int)
        Console.WriteLine("\nWhat is your favorite number?");
        int faveNum = int.Parse(Console.ReadLine());

        // TODO: CALCULATE derived information
        // - Birth year = 2026 - age
        int birthYear = 2026 - age;

        // - Years to graduation = graduationYear - 2026
        int yearsToGrad = gradYear - 2026;

        // - Height in feet and inches: feet = heightInches / 12, inches = heightInches % 12
        double feetHeight = rawHeight / 12;
        double inchHeight = rawHeight % 12;

        // - Is honor student? = gpa >= 3.5
        bool honorStudent = false;
        if (gpa >= 3.5) { honorStudent = true; }

        // - Age in months = age * 12
        int ageInMonths = age * 12;

        // TODO: DISPLAY formatted profile card
        // Use sections with headers:
        Console.WriteLine("\n╔════════════════════════════════════════════╗");
        Console.WriteLine("║           STUDENT PROFILE CARD             ║");
        Console.WriteLine("╚════════════════════════════════════════════╝\n");

        // - PERSONAL INFORMATION
        Console.WriteLine("  Personal Information");
        Console.WriteLine("═════════════════════════════════════════════\n");
        Console.WriteLine("  Full Name       - " + fullName);
        Console.WriteLine("  Home town       - " + homeTown);
        Console.WriteLine("  Favorite Color  - " + faveColor);
        Console.WriteLine("  Favorite Num    - " + faveNum);
        Console.WriteLine("  Dream Job       - " + dreamJob);

        // - ACADEMIC DETAILS
        Console.WriteLine("\n  Academic Details");
        Console.WriteLine("═════════════════════════════════════════════\n");
        Console.WriteLine("  Major           - " + major);
        Console.WriteLine("  GPA             - " + gpa);
        Console.WriteLine("  Graduation Year - " + gradYear);

        // - CALCULATED STATISTICS
        Console.WriteLine("\n  Calculated Information");
        Console.WriteLine("═════════════════════════════════════════════\n");
        if (honorStudent == true) { Console.WriteLine("  Honors Roll"); }
        if (isFullTime == true) { Console.WriteLine("  Full Time Student"); }
        else { Console.WriteLine("  Part Time Student"); }
        Console.WriteLine("  Years to Grad   - " + yearsToGrad);
        Console.WriteLine("  Height          - " + feetHeight.ToString("F2") + " feet and " + inchHeight + " inches");
        Console.WriteLine("  Birth Year      - " + birthYear);
        Console.WriteLine("  Age In Months   - " + ageInMonths);


        // Use proper alignment and formatting
        Console.WriteLine("\n═════════════════════════════════════════════");
        Console.WriteLine("Profile complete! Good luck with your studies!");
    }
}
