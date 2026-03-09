using System;
using System.Collections.Generic;
using Task.Models;

namespace Task
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Greeting();

            Console.WriteLine("\n=== VERSION 1 — Basic Inheritance ===\n");

            Cat cat = new Cat("British Shorthair", "Whiskers", "Calm, fluffy, round face", 5.2, 30, true, 0);
            Dog dog = new Dog("German Shepherd", "Rex", "Loyal, intelligent, strong", 35.0, 65, true);

            Console.WriteLine("--- Cat Info ---");
            cat.WriteToConsole();

            Console.WriteLine("\n--- Dog Info ---");
            dog.WriteToConsole();

            Console.WriteLine("\n--- Cat Behaviour ---");
            cat.Purr();
            cat.CatchMice(3);
            cat.Train("jump through hoop");

            Console.WriteLine("\n--- Dog Behaviour ---");
            dog.Bark();
            dog.Train("Sit");
            dog.Train("Paw");
            dog.Train("Lie down");
            dog.Guard();

            Console.WriteLine("\n--- Confrontation & Friendship ---");
            cat.Confront(dog);
            dog.Confront(cat);
            cat.BeFriendsWith(dog);

            Console.WriteLine("\n\n=== VERSION 2 — Interface-based Hierarchy ===\n");

            IAnimal animal1 = new CatV2("Siamese", "Luna", "Elegant, vocal, affectionate", 4.0, 25, true);
            IAnimal animal2 = new DogV2("Labrador", "Buddy", "Friendly, energetic, loves water", 30.0, 60, false);

            Console.WriteLine("--- Accessing through IAnimal interface ---");
            Console.WriteLine($"\nanimal1 (CatV2):");
            animal1.WriteToConsole();
            Console.WriteLine($"  Sound: {animal1.MakeSound()}");

            Console.WriteLine($"\nanimal2 (DogV2):");
            animal2.WriteToConsole();
            Console.WriteLine($"  Sound: {animal2.MakeSound()}");

            Console.WriteLine("\n--- Polymorphism via IAnimal ---");
            IAnimal[] animals = { animal1, animal2 };
            foreach (IAnimal a in animals)
            {
                Console.WriteLine($"  {a.Name} ({a.Breed}): {a.MakeSound()}");
            }

            Console.WriteLine("\n--- Accessing specific methods via casting ---");
            if (animal1 is CatV2 catV2)
                catV2.Purr();
            if (animal2 is DogV2 dogV2)
                dogV2.Guard();

            Console.WriteLine("\n\n=== VERSION 3 — Abstract Base Class ===\n");

            CatV3 catV3 = new CatV3("Maine Coon", "Shadow", "Large, gentle, playful", 8.0, 40, 9);
            DogV3 dogV3 = new DogV3("Husky", "Storm", "Energetic, howling, pack-oriented", 25.0, 55, 7);

            Console.WriteLine("--- CatV3 Info ---");
            catV3.WriteToConsole();

            Console.WriteLine("\n--- DogV3 Info ---");
            dogV3.WriteToConsole();

            Console.WriteLine("\n--- Abstract method MakeSound() ---");
            AbstractAnimal[] absAnimals = { catV3, dogV3 };
            foreach (AbstractAnimal a in absAnimals)
            {
                Console.WriteLine($"  {a.MakeSound()}");
            }

            Console.WriteLine("\n--- Concrete method Sleep() from abstract class ---");
            catV3.Sleep();
            dogV3.Sleep();

            Console.WriteLine("\n--- Specific methods ---");
            catV3.LoseLife();
            catV3.LoseLife();
            dogV3.IncreaseLoyalty();

            Console.WriteLine("\n--- Interface vs Abstract Class Comparison ---");
            Console.WriteLine("  Interface (IAnimal):");
            Console.WriteLine("    - Only defines contracts (method signatures, properties)");
            Console.WriteLine("    - A class can implement multiple interfaces");
            Console.WriteLine("    - No state (fields) — only property signatures");
            Console.WriteLine("  Abstract class (AbstractAnimal):");
            Console.WriteLine("    - Can have concrete methods (e.g., Sleep())");
            Console.WriteLine("    - Can have fields and state");
            Console.WriteLine("    - A class can inherit only one abstract class");
            Console.WriteLine("    - Can define constructors");

            Console.WriteLine("\n\n=== VERSION 4 — Collection Interfaces ===\n");

            Animal[] animalArray = new Animal[]
            {
                new Cat("Persian",          "Fluffy",  "Long-haired, calm",        6.5,  28, true,  5),
                new Dog("Bulldog",          "Tank",    "Stocky, muscular",        25.0,  40, true),
                new Cat("Sphynx",           "Sphinx",  "Hairless, curious",        3.5,  22, true,  0),
                new Dog("Chihuahua",        "Tiny",    "Small, loud, brave",       2.0,  15, false),
                new Cat("Bengal",           "Tiger",   "Spotted, athletic",        5.0,  30, false, 12),
                new Dog("Great Dane",       "Zeus",    "Giant, gentle, noble",    55.0,  80, true),
                new Dog("Golden Retriever", "Goldie",  "Friendly, fluffy, smart", 30.0,  58, false),
            };

            Console.WriteLine("--- Sorting with IComparable<Animal> (by weight) ---");
            Animal[] sortedByWeight = (Animal[])animalArray.Clone();
            Array.Sort(sortedByWeight);
            Console.WriteLine("Animals sorted by weight (ascending):");
            for (int i = 0; i < sortedByWeight.Length; i++)
                Console.WriteLine($"  {i + 1}. {sortedByWeight[i]}");

            Console.WriteLine("\n--- Sorting with IComparer<Animal> (by height) ---");
            Animal[] sortedByHeight = (Animal[])animalArray.Clone();
            Array.Sort(sortedByHeight, new AnimalHeightComparer());
            Console.WriteLine("Animals sorted by height (ascending):");
            for (int i = 0; i < sortedByHeight.Length; i++)
                Console.WriteLine($"  {i + 1}. {sortedByHeight[i]}");

            Console.WriteLine("\n--- IEnumerable<Animal> (AnimalCollection) ---");
            AnimalCollection collection = new AnimalCollection(animalArray);
            collection.PrintAll();

            Console.WriteLine("\nUsing foreach on AnimalCollection:");
            foreach (Animal animal in collection)
            {
                Console.WriteLine($"  - {animal.Name} weighs {animal.Weight} kg");
            }

            Console.WriteLine("\n=== All Versions Completed! ===");
        }

        static void Greeting()
        {
            Console.WriteLine("===========================================");
            Console.WriteLine("     Laboratory Work No. 4");
            Console.WriteLine("===========================================");
            Console.WriteLine("Performed by: Vlad Sapozhnyk (8)");
            Console.WriteLine("Taras Shevchenko National University of Kyiv");
            Console.WriteLine("Group: IPZ-13, Subgroup: 6");
            Console.WriteLine("===========================================");
        }
    }
}
