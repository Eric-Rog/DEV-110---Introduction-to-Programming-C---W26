# Week 5: Guess the Number - Study Notes

**Name:**

## Loop Types

**How is a `do-while` loop different from a `while` loop?**
[Explain when each loop is best used]

Answer: do while is better if you want to ensure the code inside is run. And while is for the alternative simpler case

**Where did you use a `do-while` loop in this assignment and why?**
[Describe the input validation use]

Answer: Do while was used when asking for input because you want to guarentee that the ask is made so feedback can be recieved.

**Where did you use a `while` loop and why?**
[Describe the guessing loop]

Answer: While was used during the guess check phase. This allows the phase to run so long as the guess is not correct. And the loop exists when the correct guess is made.

**Where did you use a `for` loop and why?**
[Describe the rounds loop]

Answer: For is used because it offers a strict count on rounds, unlike while or do-while which loop based on other conditions. For explicitly tracks each round and runs only for the num of rounds specified by the user.

## Input Validation

**Why did you create a helper method for input validation?**
[Explain how it avoids repeating code for max value and rounds]

Answer: It provides a template to prompt, accept, and then return user feedback. I honestly missed the chance to use it for rounds.

**How did you make sure the max value was between 10 and 100?**
[Explain your range check logic]

Answer: The user input is checked to see if it exceeds the bounds (< 10 or > 100) and so long as it does the loop keeps running. I was also too tired to understand how the tryParse worked so i just did try and if it breaks its the users problem.

**How did you make sure the number of rounds was between 1 and 3?**
[Explain your range check logic]

Answer: The same method as the max value, but instead of reusing the method i just did it by hand (by adding new lines) and added redundance code unknowingly.

**How did you handle invalid input (non-numbers)?**
[Explain how int.TryParse works]

Answer: I didnt. But in theory i think int.parse returns false if the string it accepts is not a valid input

## Guessing Logic

**How did you compare the guess to the secret number?**
[Explain the if/else logic for too low, too high, and correct]

Answer: I made a seperate if and else if condition for high and low respectivley. and the else case would catch if it was spot on.

**How did you count the number of guesses?**
[Explain where you incremented the counter]

Answer: the guess counter was incremented in the loop before the guess was compared to the secretNum

## Random Numbers

**How did you generate the secret number?**
[Explain Random and Next(min, max)]

Answer: Ramdon generates a random number using the noise or something from inside the computer. The min is inclusive, but the max is exclusive, which is why i did (min, max + 1)

**Why does `Random.Next(1, max + 1)` include the max value?**
[Explain why +1 is needed]

Answer: Because a comment i saw on stack overflow said max is exclusive (hence the +1 needed to make it 'inclusive')

## Testing and Debugging

**What inputs did you test to confirm your loops worked correctly?**
[List several test cases]

Answer: I didnt

**What bugs or errors did you encounter and fix?**
[Describe any logic or loop errors]

Answer: one error i did was placing the 'you guessed (secret num) in x rounds' inside the while loop. This resulted in it spoiling the secret num and also showing the text after every guess.

## What I Learned

**Key takeaways from this week:**
[3-5 main things you learned]

1. Git is easy and im dum
2. do while loops are something new i learned
3. int.tryparse() returns bool instead of int (i thought it worked like parse())
4.
5.

**Which loop felt most natural to use and why?**

Answer:

## Time Spent

**Total time:** [5 hours]

**Breakdown:**

- Planning the loops: [1 hours]
- Input validation: [1 hours]
- Guessing logic: [2 hours]
- Testing and debugging: [0.5 hours]
- Writing documentation: [0.5 hours]

**Most time-consuming part:** [Which aspect took the longest and why?]

Answer: The writing and debugging the testing logic, because i struggled with the syntax at first, particularly arround tryParse and the errors it was giving (because i only passed 1 string into it and was using it incorrectly)

## Reflection

**What would you do differently next time?**

Answer: Start earlier so i have time to understand all the functions and methods being used by the program.

**How did using three different loop types improve your understanding of repetition?**

Answer: They were a nice way of implementing and experimenting with loops. its nice to learn and use them in a hands on way where you can deeply understand how they work.
