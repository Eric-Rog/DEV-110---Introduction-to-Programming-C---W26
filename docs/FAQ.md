# Frequently Asked Questions

## Setup & Installation

### Q: Do I need to install Visual Studio?

**A:** No! Visual Studio Code (VS Code) is different from Visual Studio. You only need VS Code (the lightweight editor) and the .NET SDK.

### Q: Which version of .NET should I install?

**A:** Install .NET 9.0 SDK. You can check your version with `dotnet --version`.

### Q: My terminal doesn't recognize the `dotnet` command

**A:** After installing .NET, you must restart your terminal completely. On Mac, quit and reopen Terminal. On Windows, close and reopen Command Prompt or PowerShell.

### Q: Can I use a different IDE like Rider or Visual Studio?

**A:** Yes, but the course instructions are optimized for VS Code. If you use a different IDE, you're responsible for translating instructions.

---

## Git & GitHub

### Q: What's the difference between Git and GitHub?

**A:** Git is the version control tool that runs on your computer. GitHub is a website that hosts your Git repositories online.

### Q: I forgot to create my assignment branch. What should I do?

**A:**

```bash
# Create the branch now
git checkout -b assignment/week-01

# If you already have commits on main
git branch assignment/week-01
git checkout assignment/week-01
git push origin assignment/week-01
```

### Q: How do I undo my last commit?

**A:**

```bash
# Undo but keep changes
git reset --soft HEAD~1

# Undo and discard changes (careful!)
git reset --hard HEAD~1
```

### Q: I accidentally committed to main instead of my assignment branch

**A:**

```bash
# Create your assignment branch from current position
git checkout -b assignment/week-01

# Go back to main and reset it
git checkout main
git reset --hard HEAD~1

# Switch back to your assignment branch to continue working
git checkout assignment/week-01
```

### Q: How do I get updates from the instructor's repository?

**A:**

```bash
# Make sure you've added the upstream remote (only needed once)
git remote add upstream <instructor-repo-url>

# Fetch and merge updates
git checkout main
git fetch upstream
git merge upstream/main
git push origin main

# Now update your assignment branch if needed
git checkout assignment/week-01
git merge main
```

---

## Running & Testing Code

### Q: What's the difference between `dotnet run` and `dotnet test`?

**A:**

-   `dotnet run` - Runs your main program (the one you write)
-   `dotnet test` - Runs the automated tests that check your work

### Q: My tests pass locally but fail on GitHub

**A:** Common causes:

-   You have a file on your computer that wasn't committed to Git
-   Your code uses an absolute path specific to your machine
-   There's a difference in line endings (Windows vs Mac/Linux)

### Q: How do I run just one test?

**A:**

```bash
dotnet test --filter "Test01_ProgramCompiles"
```

### Q: What does "inconclusive" mean in test results?

**A:** The test couldn't fully run, usually because a required file is missing (like SUBMISSION.md). It's not a failure, but you need to create the missing item.

---

## Code & Syntax

### Q: What's the difference between `WriteLine` and `Write`?

**A:**

-   `Console.WriteLine()` - Outputs text and moves to a new line
-   `Console.Write()` - Outputs text on the same line

### Q: Why do I get "CS1002: ; expected"?

**A:** You forgot a semicolon at the end of a statement. Every statement in C# must end with `;`.

### Q: What's the difference between `int` and `double`?

**A:**

-   `int` - Whole numbers only (1, 2, 100, -5)
-   `double` - Decimal numbers (1.5, 3.14, -0.5)

### Q: Why does `10 / 3` give me `3` instead of `3.33`?

**A:** Integer division! When both numbers are integers, C# gives an integer result. Use `10.0 / 3.0` or convert to `double`.

---

## Assignments

### Q: Can I turn in my assignment late?

**A:** Check the course syllabus for the late policy. GitHub shows exact submission times.

### Q: My code works on my machine. Why does it fail tests?

**A:**

-   Check that you're following the exact specifications
-   Make sure output matches exactly (including capitalization and punctuation)
-   Run `dotnet format` to fix formatting issues
-   Read test failure messages carefully - they tell you what's expected

### Q: Can I work with a partner?

**A:** Check the course policy. Generally, you can discuss approaches but must write your own code.

### Q: How much code do I need to comment?

**A:** Comment the "why," not the "what." Explain your logic, not obvious statements like `// This adds two numbers`.

---

## Debugging

### Q: My program crashes immediately. How do I debug?

**A:**

1. Read the error message carefully
2. Look at the line number in the error
3. Use `Console.WriteLine()` to print variable values
4. Run the debugger (F5 in VS Code)

### Q: I get a "NullReferenceException"

**A:** You're trying to use a variable that doesn't have a value yet. Make sure you've initialized all variables before using them.

### Q: How do I use the debugger?

**A:**

1. Click in the gutter (left of line numbers) to set a breakpoint
2. Press F5 to start debugging
3. Use F10 to step through code line by line
4. Hover over variables to see their values

---

## Getting Help

### Q: Where can I ask questions?

**A:**

1. Canvas Discussion Board (other students might have the same question!)
2. Office Hours
3. Email the instructor
4. GitHub Issues (for technical problems with the repository)

### Q: How do I ask a good question?

**A:** Include:

-   What you're trying to do
-   What you expected to happen
-   What actually happened
-   Error messages (full text)
-   What you've already tried

### Q: Is it OK to use Google/ChatGPT?

**A:** Check the course policy. Generally:

-   ✅ OK: Looking up syntax, understanding concepts
-   ❌ Not OK: Copying complete solutions, having AI write your assignments

---

## GitHub Actions

### Q: What are GitHub Actions?

**A:** Automated workflows that run when you push code. They compile your code, run tests, and check formatting automatically.

### Q: Where do I see the results?

**A:** On your Pull Request, or go to the "Actions" tab in your GitHub repository.

### Q: Why did my workflow fail?

**A:** Click on the failed workflow to see details. Common reasons:

-   Code doesn't compile
-   Tests failed
-   Formatting issues

### Q: Can I re-run a failed workflow?

**A:** Yes! Fix the issues, commit, and push again. The workflow runs automatically on each push.
