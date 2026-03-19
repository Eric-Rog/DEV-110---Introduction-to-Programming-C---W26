# Week 10: Habit Tracker (File I/O) — Study Notes

**Name:**

## File I/O — Reading

**What does `File.ReadAllLines` return, and how did you use it?**
[Think about the return type and what you did with each element]

Answer: it returns each line as a string into an array, this data can then be split up with the .Split function to break up the individual bits of data

**Why is it important to skip blank lines when reading a CSV file?**
[What would happen if you tried to split an empty string on `','`?]

Answer: It would mess up the data reading process for futher steps. This would make the data 'dirty' and give us blank lines with useless data when trying to print the whole list or modify and make changes to certian lines.

## File I/O — Writing

**What does `File.WriteAllLines` do, and what arguments does it take?**
[Describe the path argument and what goes in the string array]

Answer: It finds the file at the given path and then writes in each line from the string array it recieved. It completely rewrites the file with the new data, simmilar to a variable being changed to a new value.

**What is `Select(...).ToArray()` doing in `SaveHabits`?**
[Break down the two steps: what does `Select` produce, and why call `ToArray()`?]

Answer: Select grabs the asociated variables from the habit class, and the to array puts each one into its respective index spot.

## Exception Handling

**What is a `FileNotFoundException` and when does it occur?**
[Describe the scenario where C# throws this specific exception]

Answer: If the try fails when trying to find the file path the file not found exception is thrown to prevent the program from crashing completely

**Why do we catch `FileNotFoundException` specifically instead of using `catch (Exception)`?**
[Think about what catching all exceptions can hide from you]

Answer: Because the file not found for that case is the most common exception to catch.

## What I Learned

**Key takeaways from this week:**
[List 3 main things you learned]

1. How to read and write data from files
2. How to read and write data from classes, in this case the habit class
3. Learned how to manage exceptions and throw cases

**What was the trickiest part of this assignment and how did you work through it?**

Answer: The update habit was the most tricky because it had so many effects in one it was a little challenging trying to juggle how to implement all of them.

## Time Spent

**Total time:** 9.5 hours

**Breakdown:**

- Understanding the starter code and CSV formats: 2 hours
- Implementing LoadHabits: 2 hours
- Implementing PrintHabits / PrintSummary: 2 hours
- Implementing AddHabit / UpdateHabit / SaveHabits: 2 hours
- Testing and debugging: 1 hours
- Writing study notes: 0.5 hours

**Most time-consuming part:**

Answer: Understanding the starter code and CSV formats
