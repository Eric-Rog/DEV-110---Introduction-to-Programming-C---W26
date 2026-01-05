# 🧪 Testing Quick Reference

## Run Tests - Simple Command Line

### From Project Root (Recommended) ⭐

From the **top-level project directory** (`dev-110-setup/`):

```bash
./test 1        # Test Week 1
./test 2        # Test Week 2
./test 3        # Test Week 3
./test all      # Test everything
```

**What you get:**

-   ✅/❌ Clear pass/fail indicators
-   🎨 Color-coded output
-   💡 Helpful tips for fixing failures
-   Clean output with no confusing build messages
-   Blank lines between each test for easy reading

**Flexible syntax:**

```bash
./test 1           # Short form
./test week-1      # With 'week-'
./test week-01     # Padded numbers
```

---

## From Within a Module Directory

### If You're in a Starter Folder

From `modules/week-XX-assignment/starter/`:

```bash
# Using the test script (beginner-friendly output)
../../../test 1

# Or using dotnet directly
dotnet test ../tests
```

### If You're in a Module Folder

From `modules/week-XX-assignment/`:

```bash
# Using the test script (beginner-friendly output)
../../test 1

# Or using dotnet directly
dotnet test tests
```

---

## Using VS Code Terminal

Open the integrated terminal in VS Code:

-   Press `` Ctrl+` `` (backtick) or select `View` → `Terminal`
-   **Make sure you're in the project root directory** (`dev-110-setup/`)
-   Run the test commands:

```bash
./test 1        # Test Week 1
./test 2        # Test Week 2
./test all      # Test all weeks
```

**If your terminal opens in a subdirectory:**

```bash
# Navigate to project root first
cd /Users/your-username/dev-110-setup

# Then run tests
./test 1
```

---

## Understanding Test Output

### ✅ Green Checkmark = PASSED

Your code works correctly for this test!

### ❌ Red X = FAILED

Read the message below it for hints on what to fix:

```
❌ TEST 2: Program Outputs Hello Git Hub
  Error Message:
   ❌ Expected: 'Hello, GitHub!'
   ✏️ Your output: ''
   💡 Tip: Use Console.WriteLine("Hello, GitHub!");
```

**How to fix:**

1. Look at "Your output" - what did your code print?
2. Compare to "Expected" - what should it print?
3. Read the 💡 Tip - specific code to try

---

## Common Test Commands

**From project root (`dev-110-setup/`):**

```bash
# See help and available options
./test

# Test your current week's assignment
./test 1

# Test a different week
./test 2

# Check all your completed work
./test all
```

**From a starter folder (`modules/week-XX-assignment/starter/`):**

```bash
# Using test script
../../../test 1

# Using dotnet
dotnet test ../tests

# Run your program (without tests)
dotnet run
```

**From a module folder (`modules/week-XX-assignment/`):**

```bash
# Using test script
../../test 1

# Using dotnet
dotnet test tests
```

---

## Tips for Success

1. **Run tests often** - Don't wait until you think you're done
2. **Read the tips** - They contain actual code you can use
3. **Fix one test at a time** - Start with Test 1, then Test 2, etc.
4. **Check your spelling** - Tests look for exact matches
5. **Watch for capitalization** - "hello" ≠ "Hello"

---

## Still Stuck?

1. Read the error message completely
2. Check [docs/FAQ.md](FAQ.md) for common issues
3. Look at the assignment README in the module folder
4. Ask on Canvas discussion board
5. Come to office hours
