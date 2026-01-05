using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorLite.Tests;

[SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1118:ParameterMustNotSpanMultipleLines", Justification = "Test strings require multiple lines for readability")]
[TestClass]
public class CalculatorLiteTests
{
    private StringWriter _output;
    private TextWriter _originalOutput;

    [TestInitialize]
    public void Setup()
    {
        _output = new StringWriter();
        _originalOutput = Console.Out;
        Console.SetOut(_output);
    }

    [TestCleanup]
    public void Cleanup()
    {
        Console.SetOut(_originalOutput);
        _output.Dispose();
    }

    private void ProvideInput(params string[] inputs)
    {
        var input = new StringReader(string.Join(Environment.NewLine, inputs));
        Console.SetIn(input);
    }

    [TestMethod]
    public void Test01_ProgramCompiles()
    {
        Assert.IsTrue(true, "✅ Project compiled successfully");
    }

    [TestMethod]
    public void Test02_UserInteraction()
    {
        ProvideInput("Alice", "yes", "10", "5");
        Program.Main(new string[] { });
        string output = _output.ToString();
        string outputLower = output.ToLower();

        // Check for name prompt
        bool asksForName = outputLower.Contains("name");

        // Check for greeting with name
        bool greetsUser = output.Contains("Alice") &&
                         (outputLower.Contains("hello") || outputLower.Contains("hi"));

        // Check for decimal preference prompt
        bool asksDecimalPreference = outputLower.Contains("decimal") ||
                                    outputLower.Contains("precision") ||
                                    outputLower.Contains("yes/no");

        // Check for number prompts
        bool asksForFirstNumber = outputLower.Contains("first") ||
                                 (outputLower.Contains("enter") && outputLower.Contains("number"));
        bool asksForSecondNumber = outputLower.Contains("second");

        Assert.IsTrue(
            asksForName && greetsUser && asksDecimalPreference && asksForFirstNumber && asksForSecondNumber,
            $"❌ User interaction incomplete:\n" +
            $"   {(asksForName ? "✓" : "✗")} Asks for user's name (string)\n" +
            $"   {(greetsUser ? "✓" : "✗")} Greets user by name\n" +
            $"   {(asksDecimalPreference ? "✓" : "✗")} Asks about decimal preference (bool)\n" +
            $"   {(asksForFirstNumber ? "✓" : "✗")} Prompts for first number\n" +
            $"   {(asksForSecondNumber ? "✓" : "✗")} Prompts for second number\n" +
            $"   💡 Tip: Use Console.ReadLine() for input and store in appropriate types");
    }

    [TestMethod]
    public void Test03_BasicArithmeticOperations()
    {
        ProvideInput("Bob", "yes", "20", "10");
        Program.Main(new string[] { });
        string output = _output.ToString();

        // Addition: 20 + 10 = 30
        bool hasAddition = output.Contains("30");

        // Subtraction: 20 - 10 = 10
        bool hasSubtraction = output.Contains("10");

        // Multiplication: 20 * 10 = 200
        bool hasMultiplication = output.Contains("200");

        // Division: 20 / 10 = 2
        bool hasDivision = output.Contains("2");

        Assert.IsTrue(
            hasAddition && hasSubtraction && hasMultiplication && hasDivision,
            $"❌ Basic arithmetic operations incomplete:\n" +
            $"   {(hasAddition ? "✓" : "✗")} Addition: 20 + 10 = 30\n" +
            $"   {(hasSubtraction ? "✓" : "✗")} Subtraction: 20 - 10 = 10\n" +
            $"   {(hasMultiplication ? "✓" : "✗")} Multiplication: 20 * 10 = 200\n" +
            $"   {(hasDivision ? "✓" : "✗")} Division: 20 / 10 = 2\n" +
            $"   💡 Tip: double sum = num1 + num2; (and similar for -, *, /)");
    }

    [TestMethod]
    public void Test04_ModulusOperation()
    {
        ProvideInput("Charlie", "no", "17", "5");
        Program.Main(new string[] { });
        string output = _output.ToString();
        string outputLower = output.ToLower();

        bool hasModulusResult = output.Contains("2");
        bool hasModulusLabel = outputLower.Contains("remainder") || outputLower.Contains("modulus");

        Assert.IsTrue(
            hasModulusResult && hasModulusLabel,
            "❌ Modulus operation missing or incorrect\n" +
            "   Expected: 17 % 5 = 2\n" +
            "   💡 Tip: double remainder = num1 % num2;");
    }

    [TestMethod]
    public void Test05_AverageCalculation()
    {
        ProvideInput("Diana", "yes", "10", "20");
        Program.Main(new string[] { });
        string output = _output.ToString();
        string outputLower = output.ToLower();

        bool hasAverageResult = output.Contains("15");
        bool hasAverageLabel = outputLower.Contains("average");

        Assert.IsTrue(
            hasAverageResult && hasAverageLabel,
            "❌ Average calculation missing or incorrect\n" +
            "   Expected: (10 + 20) / 2 = 15\n" +
            "   💡 Tip: double average = (num1 + num2) / 2;");
    }

    [TestMethod]
    public void Test06_DivisionByZeroHandling()
    {
        ProvideInput("Eve", "yes", "10", "0");
        Program.Main(new string[] { });
        string output = _output.ToString().ToLower();

        bool handlesZero = output.Contains("cannot") ||
                          output.Contains("zero") ||
                          output.Contains("error") ||
                          output.Contains("invalid");

        Assert.IsTrue(
            handlesZero,
            "❌ Your program must handle division by zero!\n" +
            "   💡 Tip: if (num2 == 0) { Console.WriteLine(\"Cannot divide by zero\"); }");
    }

    [TestMethod]
    public void Test07_PercentageDifference()
    {
        ProvideInput("Frank", "yes", "50", "25");
        Program.Main(new string[] { });
        string output = _output.ToString();

        // (50 - 25) / 50 * 100 = 50%
        bool hasPercentageResult = output.Contains("50") && output.Contains("%");

        Assert.IsTrue(
            hasPercentageResult,
            "❌ Percentage difference calculation missing or incorrect\n" +
            "   Expected: (50 - 25) / 50 * 100 = 50%\n" +
            "   💡 Tip: double percent = ((num1 - num2) / num1) * 100;");
    }

    [TestMethod]
    public void Test08_UsesMultipleDataTypes()
    {
        ProvideInput("Grace", "yes", "100", "50");
        Program.Main(new string[] { });
        string output = _output.ToString();

        // Check for evidence of all 4 data types:
        // - string (name appears in output)
        // - bool (responds to yes/no)
        // - int (counting - implicit in having multiple operations)
        // - double (calculations with results)
        bool hasStringUsage = output.Contains("Grace");
        bool hasCalculations = output.Contains("150") || output.Contains("50");

        Assert.IsTrue(
            hasStringUsage && hasCalculations,
            "❌ Program should demonstrate multiple C# types\n" +
            "   💡 Required: string (name), bool (yes/no), int (count), double (calculations)");
    }

    [TestMethod]
    public void Test09_StudyNotesFileExists()
    {
        string testDir = Path.GetDirectoryName(typeof(CalculatorLiteTests).Assembly.Location);
        string starterPath = Path.Combine(testDir, "..", "..", "..", "..", "starter", "STUDY_NOTES.md");
        string studyNotesPath = Path.GetFullPath(starterPath);
        bool exists = File.Exists(studyNotesPath);

        Assert.IsTrue(
            exists,
            "\n❌ Missing STUDY_NOTES.md file!\n" +
            "📝 The file should exist in the starter folder\n" +
            "💡 Location: modules/week-02-calculator-lite/starter/STUDY_NOTES.md");
    }

    [TestMethod]
    public void Test10_StudyNotesAllSectionsCompleted()
    {
        string testDir = Path.GetDirectoryName(typeof(CalculatorLiteTests).Assembly.Location);
        string starterPath = Path.Combine(testDir, "..", "..", "..", "..", "starter", "STUDY_NOTES.md");
        string studyNotesPath = Path.GetFullPath(starterPath);

        if (File.Exists(studyNotesPath))
        {
            string content = File.ReadAllText(studyNotesPath);

            // Check 1: Student name is filled in
            Assert.IsFalse(
                string.IsNullOrWhiteSpace(content.Split(new[] { "**Name:**" }, StringSplitOptions.None)[1].Split('\n')[0].Trim()),
                "\n❌ Please fill in your name at the top of STUDY_NOTES.md\n" +
                "💡 Tip: Edit the first line: **Name:** Your Actual Name");

            // Check 2: Count all "Answer:" sections and verify they're filled
            string[] sections = content.Split("Answer:");
            int totalAnswerSections = sections.Length - 1;
            int filledAnswers = 0;

            for (int i = 1; i < sections.Length; i++)
            {
                string afterAnswer = sections[i].Trim();
                int nextSectionIndex = afterAnswer.IndexOf("**");
                if (nextSectionIndex > 0)
                {
                    afterAnswer = afterAnswer.Substring(0, nextSectionIndex).Trim();
                }

                if (!string.IsNullOrWhiteSpace(afterAnswer) && afterAnswer.Length > 5)
                {
                    filledAnswers++;
                }
            }

            Assert.IsTrue(
                filledAnswers >= totalAnswerSections - 2,
                $"\n❌ STUDY_NOTES.md has incomplete answers! (Completed: {filledAnswers}/{totalAnswerSections})\n" +
                "💡 Tip: Fill in all 'Answer:' sections with your thoughtful responses");

            // Check 3: Key takeaways list is filled
            bool hasTakeaway1 = Regex.IsMatch(content, @"1\.\s+\w{3,}");
            bool hasTakeaway2 = Regex.IsMatch(content, @"2\.\s+\w{3,}");
            bool hasTakeaway3 = Regex.IsMatch(content, @"3\.\s+\w{3,}");

            Assert.IsTrue(
                hasTakeaway1 && hasTakeaway2 && hasTakeaway3,
                "\n❌ Please complete the 'Key takeaways from this week' list (items 1, 2, and 3)\n" +
                "💡 Tip: List at least 3 important things you learned this week");

            // Check 4: Time tracking is filled in
            bool hasTimeTotal = content.Contains("**Total time:**") &&
                               Regex.IsMatch(content, @"\*\*Total time:\*\*\s+\d+");

            Assert.IsTrue(
                hasTimeTotal,
                "\n❌ Please fill in the 'Total time' section with hours spent\n" +
                "💡 Tip: Example: **Total time:** 3 hours");
        }
        else
        {
            Assert.Inconclusive("STUDY_NOTES.md file does not exist yet");
        }
    }

    [TestMethod]
    public void Test11_StudyNotesContainsRequiredSections()
    {
        string testDir = Path.GetDirectoryName(typeof(CalculatorLiteTests).Assembly.Location);
        string starterPath = Path.Combine(testDir, "..", "..", "..", "..", "starter", "STUDY_NOTES.md");
        string studyNotesPath = Path.GetFullPath(starterPath);

        if (File.Exists(studyNotesPath))
        {
            string content = File.ReadAllText(studyNotesPath);

            Assert.IsTrue(
                content.Contains("Understanding Data Types"),
                "❌ STUDY_NOTES.md should contain 'Understanding Data Types' section");
            Assert.IsTrue(
                content.Contains("Understanding Arithmetic Operations"),
                "❌ STUDY_NOTES.md should contain 'Understanding Arithmetic Operations' section");
            Assert.IsTrue(
                content.Contains("Input and Output"),
                "❌ STUDY_NOTES.md should contain 'Input and Output' section");
            Assert.IsTrue(
                content.Contains("Conditional Logic"),
                "❌ STUDY_NOTES.md should contain 'Conditional Logic' section");
            Assert.IsTrue(
                content.Contains("What I Learned"),
                "❌ STUDY_NOTES.md should contain 'What I Learned' section");
            Assert.IsTrue(
                content.Contains("Time Spent"),
                "❌ STUDY_NOTES.md should contain 'Time Spent' section");
        }
        else
        {
            Assert.Inconclusive("STUDY_NOTES.md file does not exist yet");
        }
    }
}
