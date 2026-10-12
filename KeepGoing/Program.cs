using System;
using System.Collections.Generic;

public class Item
{
    public string Name { get; private set; }
    public int Weight { get; private set; }
    public int Value { get; private set; }

    public Item(string name, int weight, int value)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name must not be empty.", nameof(name));
        }
        if (weight < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(weight), "Weight must not be negative.");
        }
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(value), "Value must not be negative.");
        }

        Name = name;
        Weight = weight;
        Value = value;
    }
}

public class Inventory
{
    public const int MaxWeight = 20;                    // const needs a type; PascalCase by convention
    private readonly List<Item> _items = new List<Item>(); // create the list!

    public int TotalWeight()
    {
        int total = 0;
        foreach (Item item in _items)
        {
            total += item.Weight;
        }
        return total;
    }

    public int TotalValue()
    {
        int total = 0;
        foreach (Item item in _items)
        {
            total += item.Value;
        }
        return total;
    }

    public bool AddItem(Item item)
    {
        int newWeight = TotalWeight() + item.Weight;    // current total + new item

        if (newWeight > MaxWeight)
        {
            Console.WriteLine($"Cannot add {item.Name}: too heavy ({newWeight}/{MaxWeight} kg).");
            return false;
        }

        _items.Add(item);
        Console.WriteLine($"Added {item.Name} ({item.Weight} kg).");
        return true;
    }

    public void PrintInventory()
    {
        Console.WriteLine("--- Inventory ---");
        foreach (Item item in _items)
        {
            Console.WriteLine($"{item.Name} - {item.Weight} kg - {item.Value} gold");
        }
        Console.WriteLine($"Total weight: {TotalWeight()}/{MaxWeight} kg");
        Console.WriteLine($"Total value: {TotalValue()} gold");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Exercise 1
        int countdown = 3;
        for (int i = countdown; i > 0; i--)
        {
            Console.WriteLine($"Wave 1 starts in {i}...");
        }
        Console.WriteLine("Go!");

        // Exercise 2
        int[] hits = { 12, 7, 25, 3, 18 };
        int enemyHp = 60;
        int total = TotalDamage(hits);                  // calculate once

        Console.WriteLine($"Hits: {string.Join(", ", hits)}");
        Console.WriteLine($"Total damage: {total}");
        Console.WriteLine($"Highest hit: {HighestHit(hits)}");
        Console.WriteLine($"Enemy HP: {enemyHp}");
        Console.WriteLine(total >= enemyHp ? "Enemy defeated!" : "Enemy survived!");

        // Exercise 3
        Inventory inventory = new Inventory();
        inventory.AddItem(new Item("Sword", 8, 50));
        inventory.AddItem(new Item("Shield", 10, 40));
        inventory.AddItem(new Item("Potion", 1, 15));
        inventory.AddItem(new Item("Armor", 6, 80));
        inventory.PrintInventory();
    }

    public static int TotalDamage(int[] hits)
    {
        int total = 0;
        foreach (int h in hits)
        {
            total += h;
        }
        return total;
    }

    public static int HighestHit(int[] hits)
    {
        int highest = hits[0];
        foreach (int h in hits)
        {
            if (h > highest)
            {
                highest = h;
            }
        }
        return highest;
    }
}
