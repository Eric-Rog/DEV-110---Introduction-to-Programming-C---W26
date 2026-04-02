# Week 7: Class Roster Builder (Arrays) - Study Notes

**Name: Eric Rogers**

## Arrays and `count`

**What are “parallel arrays” and how did you use them in this assignment?**
[Explain how rosterNames and rosterCredits stay lined up by index]

Answer: Because the arrays are the same length, and because data is added at the same index the paired values stay 'parallel' as they both share an identical index. This means you can call both from their respective arrays using the same index.

**What is the purpose of the `count` variable?**
[Explain how it tracks how many roster slots are “in use”]

Answer: Because the array size is fixed count helps keep track of the full and empty slots. If we extended or removed array slots we would instead be able to use array.length or something simmilar.

**Where did you use `count` in loops and why?**
[Explain why you loop 0..count-1 instead of using the full array length]

Answer: Because the full array length is fixed at 3. This means each spot could contain a real value or an empty value.

## Printing and Sorting

**How did you print the class roster using a `foreach` loop?**
[Describe building an array of roster lines and then printing each line]

Answer: I used the output roster to merge the 2 arrays into a function, and then used the for each element to run for the length of the output roster. Count was also used to ensure that no empty values were passed into the output roster.

**How did you sort the roster while keeping names and credits aligned?**
[Describe copying the used roster into new arrays and using Array.Sort on parallel arrays]

Answer: The copy used roster returns a duplicate set of arrays to maintain the integrity of the main array. This duplicate is then sorted and printed out.

## What I Learned

**Key takeaways from this week:**
[3-5 main things you learned]

1. Foreach is actually useful
2. Arrays are deeper and more complex than i thought in the past
3. Parallel arrays are neat and have their use cases.
4.
5.

**Which loop felt most natural to use and why?**

Answer: for loops and arrays work so well because of the easy increments. But 'foreach' and the element is something new I learned that is growing on me after using them.

## Time Spent

**Total time:** [6.5 hours]

**Breakdown:**

- Planning the arrays/menu: [3 hours]
- Input validation: [1 hours]
- Add + print roster features: [1 hours]
- Sorting feature: [2 hours]
- Testing and debugging: [0.25 hours]
- Writing documentation: [0.25 hours]

**Most time-consuming part:** [Which aspect took the longest and why?]

Answer: Understanding the array functions CopyUsedRoster and BuildRosterLines was confusing at first

## Reflection

**What would you do differently next time?**

Answer: Start a little earlier so I have time to do the midterm at a reasonable hour that isn't 9pm at night before it's due.

**How did using `for` and `foreach` improve your understanding of arrays?**

Answer: 'for' didnt help much as i am confident with that. 'Foreach' and using the {element} of an array was a new tool i learned however.
