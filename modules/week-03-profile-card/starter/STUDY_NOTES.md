# Week 3: Personal Profile Card - Study Notes

**Name: Eric Rogers**

## Understanding Variables and Data Types

**What are the four main data types you used in this assignment?**
[List string, int, double, and bool - explain what each stores and give examples from your profile card]

Answer:
string: stores the name of the student as an array of characters
int: stores the year they will gradiate. Int is used because years are whole numbers
double: stores the gpa because it is a decimal
bool: stores whether they are full time or not because that is a binary answer

**Why did you use `double` for GPA instead of `int`?**
[Explain the difference and why decimal precision matters for GPA]

Answer: Becasue that is how gpa is calculated. If it was an int it would not be as percise. If this program worked with real school systems, then the data would also be altered transfering from double to int.

**How did you convert the yes/no input into a boolean?**
[Explain the comparison operation you used]

Answer: I start with the input as false, and then check if yes is given through a readline within an if statement that changes it to true.

## Data Modeling Decisions

**How did you organize the information into logical groups?**
[Explain why you grouped certain pieces of information together (personal, academic, etc.)]

Answer: Because the assignment told us to do it that way. This is likely because each respective variable fits into those categories. I had also considered altering the format to group some of the calculated responses (isHonor and height/birthday) into personal and academic respectivley, as while they were calculated they fit within those catagories too.

**Which pieces of information did you calculate rather than ask for?**
[List the derived data: birth year, years to graduation, height conversion, honor status, age in months]

Answer: I calculated all of these internally without aditional user input.

**Why is it better to calculate birth year from age rather than ask for both?**
[Explain data consistency and reducing redundant input]

Answer: Because the user can put in redundant or contradictory inputs which may make downstream programming and use of the variables return inacurate results.

## Challenges and Solutions

**Biggest challenge with this assignment:**
[What was the hardest part? Type conversion, calculations, formatting, choosing data types?]

Answer: Git, its always git, so far at least.

**How you solved it:**
[Explain your approach to overcoming the challenge]

Answer: na

**Most confusing concept:**
[What was hardest to understand? Type casting, modulus for height, boolean logic, or formatting?]

Answer: I felt comfortable with all of these, though a deeper understanding of how the casting works would be helpful. Maybe it would allow me to be even more efficient using it moving forward.

## Type Conversion and Calculations

**How do you convert string input to a number?**
[Explain Parse methods: int.Parse(), double.Parse()]

Answer: Converts the string (if chars are valid) into int or double respectivley

**What calculation did you use to convert height from inches to feet and inches?**
[Explain: feet = inches / 12, remaining = inches % 12]

Answer: This calculation above, then print them as feet + inches in a writeline. Though I did do a f2 on the feet to reduce the decimals to 2.

**How did you determine if someone is an honor student?**
[Explain the boolean comparison: gpa >= 3.5]

Answer: If the GPA is greater or equal to 3.5 then i set isHonors to true. It was set false by default.

## Output Formatting

**How did you format the GPA to show exactly 2 decimal places?**
[Explain the :F2 format specifier]

Answer: f2 formatting rounds a decimal to the nearest 2 decimal places.

**How did you display different text based on whether someone is full-time or part-time?**
[Explain the conditional/ternary operator you used]

Answer: I had an if else statement that displayed both text options depending on the users response to a readline question.

**What techniques did you use to make the output look organized?**
[Discuss alignment, spacing, section headers, borders]

Answer: Copy pasted the ========= for each section header. Standardized the spacing columns for answers so they lined up vertically.

## Real-World Data Modeling

**What other calculated fields could you add to a profile?**
[Think of other derived data: BMI from height/weight, time to birthday, etc.]

Answer: With the current data, there isnt too much else useful that can be calculated. However, if multiple people answered and all the data was stored you could use an if else to see who has the highest/lowest of x varlaible within the group.

**Why is choosing the right data type important in real applications?**
[Explain memory, precision, and type safety]

Answer: Having the right data type ensures efficient memory usage and ensures that the variable container is flexible and can respond to a variety of apropriate inputs without breaking through errors or inacurate values.

**How does this profile card relate to real-world applications?**
[Think about social media profiles, job applications, student records systems]

Answer: The profile card style of data set is used tons of record systems, namely those mentioned above, as it allows for efficient storage of information. As i kinda hinted at earlier if all this data was kept in an array then it would be very usefull to reference.

## What I Learned

**Key takeaways from this week:**
[What are the 3-5 most important things you learned about variables and data modeling?]

1. Readline is very efficient and can return directly into if statements
2. double is more flexible than int, but needs guardrails from things like F2
3. bool is very niche and takes a lot of structure to accept (it needs an if else whereas double, int, string can be take directly from readline)
4.
5.

**Which data type was most challenging to work with and why?**
[Reflect on your experience with string, int, double, or bool]

Answer: string because it has many variables that it can convert or be converted into depending on the context.

**How does understanding data types help you write better programs?**
[Explain the benefits of type safety and appropriate data representation]

Answer: using incorrect types can lead to errors or simplify complex data leading to inaccuracies.

## Testing and Debugging

**What test cases did you use to verify your calculations?**
[List different inputs you tested - edge cases, typical values, etc.]

Answer: I didnt really test crazy cases because i assumed they would just break the whole program instead of giving a weird result. Ex: i didnt feel the need to put a string when prompted for a dobule.

**What bugs or errors did you encounter and fix?**
[Describe any type conversion errors, calculation mistakes, or formatting issues]

Answer: I encountered one calculation error for the true height (feet + inches) where the feed decimal exceeded 2 digits. I patched this by using (F2)

**How did you validate that your data types were correct?**
[Explain how you checked that GPA, heights, ages worked correctly]

Answer: Inputted cases on either side of the limit and verified the asociated results were correct.

## Time Spent

**Total time:** [3 hours + 0.5 hours git setup and pushing]

**Breakdown:**

-   Understanding data types and planning variables: [0.2 hours]
-   Collecting user input with correct types: [0.5 hours]
-   Implementing calculations: [1.5 hours]
-   Formatting output: [0.5 hours]
-   Testing and debugging: [0.2 hours]
-   Writing documentation: [1 hours]

**Most time-consuming part:** [Which aspect took the longest and why?]

Answer: The study notes, because there is alot of writing and deep explenation, and some questions i feel are somehat redundant or have heavy overlap with answers.

## Reflection

**What would you do differently if you started over?**
[Consider variable names, calculation order, organization, etc.]

Answer: Simplify some variable names and maybe think of ways to be more lean with if/else statements

**How does proper data modeling make programs easier to maintain?**
[Think about readability, consistency, and reducing errors]

Answer: It enables you or others to quickly identify errors and implement solutions.

**What real-world system would you like to model next?**
[Shopping cart, game character, recipe calculator, etc.]

Answer: Game character because game stats have more interaction with each other than I feel like the other 2 would.
