using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HelloGitHub.Tests;

[TestClass]
public class HelloGitHubTests
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

    [TestMethod]
    public void Test01_ProgramCompiles()
    {
        // This test passes if the project compiles successfully
        Assert.IsTrue(true, "✅ Program compiled successfully");
    }

    [TestMethod]
    public void Test02_ProgramOutputsHelloGitHub()
    {
        // Arrange & Act
        Program.Main(new string[] { });
        string output = _output.ToString().Trim();

        // Assert
        Assert.AreEqual("Hello, GitHub!", output,
            $"\n❌ Expected: 'Hello, GitHub!'\n✏️ Your output: '{output}'\n💡 Tip: Use Console.WriteLine(\"Hello, GitHub!\"); - check spelling and punctuation!");
    }

    [TestMethod]
    public void Test03_OutputIsNotEmpty()
    {
        // Arrange & Act
        Program.Main(new string[] { });
        string output = _output.ToString();

        // Assert
        Assert.IsFalse(
            string.IsNullOrWhiteSpace(output),
            "\n❌ Your program doesn't produce any output!\n💡 Tip: Add Console.WriteLine() to print something to the screen");
    }

    [TestMethod]
    public void Test04_OutputContainsHello()
    {
        // Arrange & Act
        Program.Main(new string[] { });
        string output = _output.ToString();

        // Assert
        Assert.IsTrue(
            output.Contains("Hello"),
            $"\n❌ Your output is missing the word 'Hello'\n✏️ Your output: '{output.Trim()}'\n💡 Tip: Make sure to include 'Hello' with capital H");
    }

    [TestMethod]
    public void Test05_OutputContainsGitHub()
    {
        // Arrange & Act
        Program.Main(new string[] { });
        string output = _output.ToString();

        // Assert
        Assert.IsTrue(
            output.Contains("GitHub"),
            $"\n❌ Your output is missing the word 'GitHub'\n✏️ Your output: '{output.Trim()}'\n💡 Tip: Make sure to spell 'GitHub' with capital G and capital H");
    }

    [TestMethod]
    public void Test06_StudyNotesFileExists()
    {
        // Check if STUDY_NOTES.md exists
        string testDir = Path.GetDirectoryName(typeof(HelloGitHubTests).Assembly.Location);
        string starterPath = Path.Combine(testDir, "..", "..", "..", "..", "starter", "STUDY_NOTES.md");
        string studyNotesPath = Path.GetFullPath(starterPath);
        bool exists = File.Exists(studyNotesPath);

        Assert.IsTrue(
            exists,
            $"\n❌ Missing STUDY_NOTES.md file!\n📝 The file should already exist in the starter folder\n💡 Location: modules/week-01-hello-github/starter/STUDY_NOTES.md");
    }

    [TestMethod]
    public void Test07_StudyNotesAllSectionsCompleted()
    {
        string testDir = Path.GetDirectoryName(typeof(HelloGitHubTests).Assembly.Location);
        string starterPath = Path.Combine(testDir, "..", "..", "..", "..", "starter", "STUDY_NOTES.md");
        string studyNotesPath = Path.GetFullPath(starterPath);

        if (File.Exists(studyNotesPath))
        {
            string content = File.ReadAllText(studyNotesPath);

            // Check 1: Student name is filled in
            Assert.IsFalse(
                content.Contains("[Your Name]"),
                "\n❌ Please replace '[Your Name]' with your actual name at the top of STUDY_NOTES.md\n💡 Tip: Edit the first line: **Name:** Your Actual Name");

            // Check 2: Count all "Answer:" sections and verify they're filled
            string[] sections = content.Split("Answer:");
            int totalAnswerSections = sections.Length - 1;
            int filledAnswers = 0;
            var emptyAnswers = new System.Collections.Generic.List<int>();

            for (int i = 1; i < sections.Length; i++)
            {
                // Get content after "Answer:" up to next section or end
                string afterAnswer = sections[i].Trim();
                int nextSectionIndex = afterAnswer.IndexOf("**");
                if (nextSectionIndex > 0)
                {
                    afterAnswer = afterAnswer.Substring(0, nextSectionIndex).Trim();
                }

                // Check if this answer has meaningful content
                if (!string.IsNullOrWhiteSpace(afterAnswer) && afterAnswer.Length > 5)
                {
                    filledAnswers++;
                }
                else
                {
                    emptyAnswers.Add(i);
                }
            }

            Assert.IsTrue(
                filledAnswers >= totalAnswerSections - 1,
                $"\n❌ STUDY_NOTES.md has incomplete answers! (Completed: {filledAnswers}/{totalAnswerSections})\n💡 Tip: Fill in all 'Answer:' sections with your thoughtful responses");

            // Check 3: Key takeaways list is filled (1. 2. 3.)
            bool hasTakeaway1 = System.Text.RegularExpressions.Regex.IsMatch(content, @"1\.\s+\w{3,}");
            bool hasTakeaway2 = System.Text.RegularExpressions.Regex.IsMatch(content, @"2\.\s+\w{3,}");
            bool hasTakeaway3 = System.Text.RegularExpressions.Regex.IsMatch(content, @"3\.\s+\w{3,}");

            Assert.IsTrue(
                hasTakeaway1 && hasTakeaway2 && hasTakeaway3,
                "\n❌ Please complete the 'Key takeaways from this week' list (items 1, 2, and 3)\n💡 Tip: List 3 important things you learned this week");

            // Check 4: Time tracking is filled in
            bool hasTimeTotal = content.Contains("**Total time:**") &&
                               System.Text.RegularExpressions.Regex.IsMatch(content, @"\*\*Total time:\*\*\s+\d+");

            Assert.IsTrue(
                hasTimeTotal,
                "\n❌ Please fill in the 'Total time' section with the number of hours you spent\n💡 Tip: Example: **Total time:** 3 hours");
        }
        else
        {
            Assert.Inconclusive("STUDY_NOTES.md file does not exist yet");
        }
    }

    [TestMethod]
    public void Test08_StudyNotesContainsRequiredSections()
    {
        string testDir = Path.GetDirectoryName(typeof(HelloGitHubTests).Assembly.Location);
        string starterPath = Path.Combine(testDir, "..", "..", "..", "..", "starter", "STUDY_NOTES.md");
        string studyNotesPath = Path.GetFullPath(starterPath);

        if (File.Exists(studyNotesPath))
        {
            string content = File.ReadAllText(studyNotesPath);

            Assert.IsTrue(
                content.Contains("Development Environment Setup"),
                "❌ STUDY_NOTES.md should contain the 'Development Environment Setup' section");
            Assert.IsTrue(
                content.Contains("Challenges and Solutions"),
                "❌ STUDY_NOTES.md should contain the 'Challenges and Solutions' section");
            Assert.IsTrue(
                content.Contains("Understanding C# Basics"),
                "❌ STUDY_NOTES.md should contain the 'Understanding C# Basics' section");
            Assert.IsTrue(
                content.Contains("Git Workflow Understanding"),
                "❌ STUDY_NOTES.md should contain the 'Git Workflow Understanding' section");
            Assert.IsTrue(
                content.Contains("What I Learned"),
                "❌ STUDY_NOTES.md should contain the 'What I Learned' section");
            Assert.IsTrue(
                content.Contains("Time Spent"),
                "❌ STUDY_NOTES.md should contain the 'Time Spent' section");
        }
        else
        {
            Assert.Inconclusive("STUDY_NOTES.md file does not exist yet");
        }
    }
}
