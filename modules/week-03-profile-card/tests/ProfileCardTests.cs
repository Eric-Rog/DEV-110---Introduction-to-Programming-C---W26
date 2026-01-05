using System;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProfileCard.Tests;

[TestClass]
public class ProfileCardTests
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
    public void Test02_CollectsAllRequiredInputs()
    {
        ProvideInput("Alex Johnson", "Seattle, WA", "Blue", "Software Engineer",
                     "Computer Science", "3.85", "2026", "yes",
                     "20", "69", "42");
        Program.Main(new string[] { });
        string output = _output.ToString().ToLower();

        bool asksName = output.Contains("name");
        bool asksHometown = output.Contains("hometown") || output.Contains("city");
        bool asksColor = output.Contains("color");
        bool asksDreamJob = output.Contains("job") || output.Contains("career");
        bool asksMajor = output.Contains("major") || output.Contains("field");
        bool asksGPA = output.Contains("gpa");
        bool asksGradYear = output.Contains("graduation") && output.Contains("year");
        bool asksFullTime = output.Contains("full") || output.Contains("time");
        bool asksAge = output.Contains("age");
        bool asksHeight = output.Contains("height");
        bool asksNumber = output.Contains("number");

        Assert.IsTrue(
            asksName && asksHometown && asksColor && asksDreamJob && asksMajor &&
            asksGPA && asksGradYear && asksFullTime && asksAge && asksHeight && asksNumber,
            $"❌ Missing required input prompts:\n" +
            $"   {(asksName ? "✓" : "✗")} Full name\n" +
            $"   {(asksHometown ? "✓" : "✗")} Hometown\n" +
            $"   {(asksColor ? "✓" : "✗")} Favorite color\n" +
            $"   {(asksDreamJob ? "✓" : "✗")} Dream job\n" +
            $"   {(asksMajor ? "✓" : "✗")} Major/field\n" +
            $"   {(asksGPA ? "✓" : "✗")} GPA\n" +
            $"   {(asksGradYear ? "✓" : "✗")} Graduation year\n" +
            $"   {(asksFullTime ? "✓" : "✗")} Full-time status\n" +
            $"   {(asksAge ? "✓" : "✗")} Age\n" +
            $"   {(asksHeight ? "✓" : "✗")} Height\n" +
            $"   {(asksNumber ? "✓" : "✗")} Favorite number\n" +
            $"   💡 Tip: Use Console.Write() for prompts and Console.ReadLine() for input");
    }

    [TestMethod]
    public void Test03_UsesAppropriateDataTypes()
    {
        ProvideInput("Taylor Smith", "Portland, OR", "Green", "Data Scientist",
                     "Mathematics", "3.92", "2027", "yes",
                     "21", "66.5", "7");
        Program.Main(new string[] { });
        string output = _output.ToString();

        // Check for GPA with decimal (double)
        bool hasGPADecimal = output.Contains("3.92") || output.Contains("3.9");

        // Check for graduation year (int)
        bool hasGradYear = output.Contains("2027");

        // Check for age (int)
        bool hasAge = output.Contains("21");

        // Check for height with decimal (double)
        bool hasHeightDecimal = output.Contains("66.5") || output.Contains("66") || (output.Contains("5") && output.Contains("6"));

        Assert.IsTrue(
            hasGPADecimal && hasGradYear && hasAge && hasHeightDecimal,
            $"❌ Data types not used correctly:\n" +
            $"   {(hasGPADecimal ? "✓" : "✗")} GPA as double (should show decimals)\n" +
            $"   {(hasGradYear ? "✓" : "✗")} Graduation year as int\n" +
            $"   {(hasAge ? "✓" : "✗")} Age as int\n" +
            $"   {(hasHeightDecimal ? "✓" : "✗")} Height as double\n" +
            $"   💡 Tip: Use double.Parse() for GPA and height, int.Parse() for years and age");
    }

    [TestMethod]
    public void Test04_CalculatesBirthYear()
    {
        ProvideInput("Jordan Lee", "Austin, TX", "Red", "Teacher",
                     "Education", "3.45", "2025", "no",
                     "22", "70", "13");
        Program.Main(new string[] { });
        string output = _output.ToString();

        // Birth year should be 2026 - 22 = 2004
        bool hasBirthYear = output.Contains("2004");

        Assert.IsTrue(
            hasBirthYear,
            "❌ Birth year calculation incorrect or missing\n" +
            "   Expected: 2026 - 22 = 2004\n" +
            "   💡 Tip: int birthYear = 2026 - age;");
    }

    [TestMethod]
    public void Test05_CalculatesYearsToGraduation()
    {
        ProvideInput("Morgan Davis", "Denver, CO", "Purple", "Engineer",
                     "Engineering", "3.67", "2028", "yes",
                     "19", "68", "25");
        Program.Main(new string[] { });
        string output = _output.ToString();

        // Years to grad should be 2028 - 2026 = 2
        bool hasYearsToGrad = output.Contains("2") && (output.ToLower().Contains("year") || output.ToLower().Contains("graduation"));

        Assert.IsTrue(
            hasYearsToGrad,
            "❌ Years to graduation calculation incorrect or missing\n" +
            "   Expected: 2028 - 2026 = 2 years\n" +
            "   💡 Tip: int yearsToGrad = graduationYear - 2026;");
    }

    [TestMethod]
    public void Test06_ConvertsHeightToFeetAndInches()
    {
        ProvideInput("Casey Brown", "Miami, FL", "Yellow", "Artist",
                     "Art", "3.20", "2026", "yes",
                     "20", "72", "100");
        Program.Main(new string[] { });
        string output = _output.ToString();

        // 72 inches = 6 feet 0 inches
        bool hasFeet = output.Contains("6") && (output.ToLower().Contains("feet") || output.ToLower().Contains("ft"));
        bool hasInches = (output.Contains("0") || output.Contains("72")) && output.ToLower().Contains("inch");

        Assert.IsTrue(
            hasFeet && hasInches,
            "❌ Height conversion to feet and inches incorrect or missing\n" +
            "   Expected: 72 inches = 6 feet 0 inches\n" +
            "   💡 Tip: int feet = (int)(heightInches / 12); double inches = heightInches % 12;");
    }

    [TestMethod]
    public void Test07_DeterminesHonorStudent()
    {
        ProvideInput("Riley Johnson", "Boston, MA", "Orange", "Doctor",
                     "Biology", "3.85", "2027", "yes",
                     "20", "65", "8");
        Program.Main(new string[] { });
        string output = _output.ToString().ToLower();

        // GPA 3.85 >= 3.5, so should be honor student
        bool showsHonorStatus = output.Contains("honor") && (output.Contains("yes") || output.Contains("⭐") || output.Contains("true"));

        Assert.IsTrue(
            showsHonorStatus,
            "❌ Honor student determination incorrect or missing\n" +
            "   Expected: GPA 3.85 >= 3.5 means honor student = Yes\n" +
            "   💡 Tip: bool isHonorStudent = gpa >= 3.5;");
    }

    [TestMethod]
    public void Test08_DisplaysAllInformation()
    {
        ProvideInput("Sam Wilson", "Chicago, IL", "Black", "Architect",
                     "Architecture", "3.50", "2026", "no",
                     "23", "70.5", "42");
        Program.Main(new string[] { });
        string output = _output.ToString();

        // Check all input data appears in output
        bool hasName = output.Contains("Sam Wilson");
        bool hasHometown = output.Contains("Chicago");
        bool hasColor = output.Contains("Black");
        bool hasJob = output.Contains("Architect");
        bool hasMajor = output.Contains("Architecture");
        bool hasGPA = output.Contains("3.50") || output.Contains("3.5");
        bool hasGradYear = output.Contains("2026");
        bool hasAge = output.Contains("23");
        bool hasFavoriteNum = output.Contains("42");

        Assert.IsTrue(
            hasName && hasHometown && hasColor && hasJob && hasMajor &&
            hasGPA && hasGradYear && hasAge && hasFavoriteNum,
            $"❌ Not all information is displayed in output:\n" +
            $"   {(hasName ? "✓" : "✗")} Name\n" +
            $"   {(hasHometown ? "✓" : "✗")} Hometown\n" +
            $"   {(hasColor ? "✓" : "✗")} Favorite color\n" +
            $"   {(hasJob ? "✓" : "✗")} Dream job\n" +
            $"   {(hasMajor ? "✓" : "✗")} Major\n" +
            $"   {(hasGPA ? "✓" : "✗")} GPA\n" +
            $"   {(hasGradYear ? "✓" : "✗")} Graduation year\n" +
            $"   {(hasAge ? "✓" : "✗")} Age\n" +
            $"   {(hasFavoriteNum ? "✓" : "✗")} Favorite number\n" +
            $"   💡 Tip: Use Console.WriteLine() to display all collected data");
    }

    [TestMethod]
    public void Test09_HasProperSectionsAndLabels()
    {
        ProvideInput("Pat Garcia", "Phoenix, AZ", "White", "Lawyer",
                     "Law", "3.75", "2025", "yes",
                     "24", "68", "17");
        Program.Main(new string[] { });
        string output = _output.ToString().ToLower();

        bool hasPersonalSection = output.Contains("personal");
        bool hasAcademicSection = output.Contains("academic") || output.Contains("education");
        bool hasCalculatedSection = output.Contains("calculated") || output.Contains("statistics") || output.Contains("derived");

        Assert.IsTrue(
            hasPersonalSection && hasAcademicSection && hasCalculatedSection,
            $"❌ Missing required sections:\n" +
            $"   {(hasPersonalSection ? "✓" : "✗")} Personal Information section\n" +
            $"   {(hasAcademicSection ? "✓" : "✗")} Academic Details section\n" +
            $"   {(hasCalculatedSection ? "✓" : "✗")} Calculated Statistics section\n" +
            $"   💡 Tip: Organize output with clear section headers");
    }

    [TestMethod]
    public void Test10_StudyNotesFileExists()
    {
        string testDir = Path.GetDirectoryName(typeof(ProfileCardTests).Assembly.Location);
        string starterPath = Path.Combine(testDir, "..", "..", "..", "..", "starter", "STUDY_NOTES.md");
        string studyNotesPath = Path.GetFullPath(starterPath);
        bool exists = File.Exists(studyNotesPath);

        Assert.IsTrue(
            exists,
            "\n❌ Missing STUDY_NOTES.md file!\n" +
            "📝 The file should exist in the starter folder\n" +
            "💡 Location: modules/week-03-profile-card/starter/STUDY_NOTES.md");
    }

    [TestMethod]
    public void Test11_StudyNotesAllSectionsCompleted()
    {
        string testDir = Path.GetDirectoryName(typeof(ProfileCardTests).Assembly.Location);
        string starterPath = Path.Combine(testDir, "..", "..", "..", "..", "starter", "STUDY_NOTES.md");
        string studyNotesPath = Path.GetFullPath(starterPath);

        if (File.Exists(studyNotesPath))
        {
            string content = File.ReadAllText(studyNotesPath);

            // Check student name is filled in
            Assert.IsFalse(
                string.IsNullOrWhiteSpace(content.Split(new[] { "**Name:**" }, StringSplitOptions.None)[1].Split('\n')[0].Trim()),
                "\n❌ Please fill in your name at the top of STUDY_NOTES.md");

            // Count filled answers
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
                "💡 Tip: Fill in all 'Answer:' sections with thoughtful responses");

            // Check key takeaways
            bool hasTakeaway1 = Regex.IsMatch(content, @"1\.\s+\w{3,}");
            bool hasTakeaway2 = Regex.IsMatch(content, @"2\.\s+\w{3,}");
            bool hasTakeaway3 = Regex.IsMatch(content, @"3\.\s+\w{3,}");

            Assert.IsTrue(
                hasTakeaway1 && hasTakeaway2 && hasTakeaway3,
                "\n❌ Please complete the 'Key takeaways' list (items 1, 2, and 3)");

            // Check time tracking
            bool hasTimeTotal = content.Contains("**Total time:**") &&
                               Regex.IsMatch(content, @"\*\*Total time:\*\*\s+\d+");

            Assert.IsTrue(
                hasTimeTotal,
                "\n❌ Please fill in the 'Total time' section\n" +
                "💡 Tip: Example: **Total time:** 3 hours");
        }
        else
        {
            Assert.Inconclusive("STUDY_NOTES.md file does not exist yet");
        }
    }
}
