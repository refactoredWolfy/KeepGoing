# C# Practice: Game-Themed Exercises

A small collection of C# exercises I'm working through as part of my journey into programming and game development. Each exercise is game-themed and focuses on core C# fundamentals. No LINQ and no async yet, just loops, methods, arrays, lists and classes.

## Exercises

### 1. Wave Countdown (Beginner)
Counts down before an enemy wave starts, using a `for` loop that runs backwards.

```
Wave 1 starts in 3...
Wave 1 starts in 2...
Wave 1 starts in 1...
Go!
```

**Concepts:** variables, `for` loops, string interpolation

### 2. Damage Report (Beginner+)
Takes an array of hits, calculates the total damage and the highest hit with my own methods, and checks whether the enemy is defeated.

```
Hits: 12, 7, 25, 3, 18
Total damage: 65
Highest hit: 25
Enemy HP: 60
Enemy defeated!
```

**Concepts:** arrays, `foreach`, static methods with return values, finding a maximum by hand, the ternary operator, `string.Join`

### 3. Weight-Limited Inventory (Intermediate)
A simple RPG-style inventory with a carry limit. Items that would push the total weight over the limit are refused.

```
Added Sword (8 kg).
Added Shield (10 kg).
Added Potion (1 kg).
Cannot add Armor: too heavy (25/20 kg).
--- Inventory ---
Sword - 8 kg - 50 gold
Shield - 10 kg - 40 gold
Potion - 1 kg - 15 gold
Total weight: 19/20 kg
Total value: 105 gold
```

**Concepts:** classes, constructors, properties with `private set`, input validation with exceptions, encapsulation (private `List<T>`), constants, methods that depend on an object's state

## What I Learned

- **Compare output word for word.** Correct logic isn't enough if the output doesn't match the spec exactly. Capital letters, commas and spaces all count.
- **A `const` needs a type:** `public const int MaxWeight = 20;`
- **Initialise collections before using them.** A declared `List<Item>` is `null` until you write `new List<Item>()`.
- **Check the whole state, not just one piece.** An inventory limit has to compare *current total + new item* against the maximum, not the new item on its own.
- **Calculate once, reuse the result.** Store a method's result in a variable instead of calling it several times.
- **Validate in the constructor** so an object can never exist in an invalid state.
