using System;
using Task.Models;

namespace Task
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Greeting();

            Console.WriteLine("\n=== Constructors (default, parameters, copy) ===\n");

            Cat catDefault = new Cat();
            Cat catParams = new Cat("Siamese", "Luna", 3, 4.2, 130, true, 7, 8);
            Cat catCopy = new Cat(catParams);

            Dog dogDefault = new Dog();
            Dog dogParams = new Dog("Labrador", "Buddy", 5, 28.0, 210, false, 4, 7);
            Dog dogCopy = new Dog(dogParams);

            Parrot parrotDefault = new Parrot();
            Parrot parrotParams = new Parrot("Ara", "Rio", 2, 1.3, 80, 35, true, 9);
            Parrot parrotCopy = new Parrot(parrotParams);

            Console.WriteLine("--- Cat copy ---");
            catCopy.WriteToConsole();
            Console.WriteLine("\n--- Dog copy ---");
            dogCopy.WriteToConsole();
            Console.WriteLine("\n--- Parrot copy ---");
            parrotCopy.WriteToConsole();

            Console.WriteLine("\n=== Happiness methods (override) ===\n");
            Console.WriteLine($"Cat happy (basic): {catParams.IsHappy()}");
            Console.WriteLine($"Cat happy (activity): {catParams.IsHappy(13, 20, true)}");
            Console.WriteLine($"Dog happy (basic): {dogParams.IsHappy()}");
            Console.WriteLine($"Dog happy (activity): {dogParams.IsHappy(9, 45, true)}");
            Console.WriteLine($"Parrot happy (basic): {parrotParams.IsHappy()}");
            Console.WriteLine($"Parrot happy (activity): {parrotParams.IsHappy(11, 30, true)}");

            Console.WriteLine("\n=== Character by owner temperament (override) ===\n");
            Console.WriteLine(catParams.DescribeCharacter(OwnerCharacter.Playful));
            Console.WriteLine(dogParams.DescribeCharacter(OwnerCharacter.Strict));
            Console.WriteLine(parrotParams.DescribeCharacter(OwnerCharacter.Active));

            Console.WriteLine("\n=== Binary operators (+, -, ==, !=, >, <) ===\n");
            Cat catMoreFood = catParams + 20;
            Cat catLessFood = catParams - 15;
            Console.WriteLine($"Cat + food: {catMoreFood.FoodPortion} g/day");
            Console.WriteLine($"Cat - food: {catLessFood.FoodPortion} g/day");
            Console.WriteLine($"catParams == catCopy: {catParams == catCopy}");
            Console.WriteLine($"catParams != catDefault: {catParams != catDefault}");
            Console.WriteLine($"catParams > catDefault: {catParams > catDefault}");
            Console.WriteLine($"catParams < catDefault: {catParams < catDefault}");

            Dog dogMoreFood = dogParams + 30;
            Dog dogLessFood = dogParams - 25;
            Console.WriteLine($"Dog + food: {dogMoreFood.FoodPortion} g/day");
            Console.WriteLine($"Dog - food: {dogLessFood.FoodPortion} g/day");
            Console.WriteLine($"dogParams == dogCopy: {dogParams == dogCopy}");
            Console.WriteLine($"dogParams != dogDefault: {dogParams != dogDefault}");
            Console.WriteLine($"dogParams > dogDefault: {dogParams > dogDefault}");
            Console.WriteLine($"dogParams < dogDefault: {dogParams < dogDefault}");

            Parrot parrotMoreFood = parrotParams + 10;
            Parrot parrotLessFood = parrotParams - 7;
            Console.WriteLine($"Parrot + food: {parrotMoreFood.FoodPortion} g/day");
            Console.WriteLine($"Parrot - food: {parrotLessFood.FoodPortion} g/day");
            Console.WriteLine($"parrotParams == parrotCopy: {parrotParams == parrotCopy}");
            Console.WriteLine($"parrotParams != parrotDefault: {parrotParams != parrotDefault}");
            Console.WriteLine($"parrotParams > parrotDefault: {parrotParams > parrotDefault}");
            Console.WriteLine($"parrotParams < parrotDefault: {parrotParams < parrotDefault}");

            Console.WriteLine("\n=== Unary operators (++, -, --) ===\n");
            Cat catInc = ++catParams;
            Cat catUnaryMinus = -catParams;
            Cat catDec = --catParams;
            Console.WriteLine($"Cat ++ : {catInc.FoodPortion} g/day");
            Console.WriteLine($"Cat unary - : {catUnaryMinus.FoodPortion} g/day");
            Console.WriteLine($"Cat -- : {catDec.FoodPortion} g/day");

            Dog dogInc = ++dogParams;
            Dog dogUnaryMinus = -dogParams;
            Dog dogDec = --dogParams;
            Console.WriteLine($"Dog ++ : {dogInc.FoodPortion} g/day");
            Console.WriteLine($"Dog unary - : {dogUnaryMinus.FoodPortion} g/day");
            Console.WriteLine($"Dog -- : {dogDec.FoodPortion} g/day");

            Parrot parrotInc = ++parrotParams;
            Parrot parrotUnaryMinus = -parrotParams;
            Parrot parrotDec = --parrotParams;
            Console.WriteLine($"Parrot ++ : {parrotInc.FoodPortion} g/day");
            Console.WriteLine($"Parrot unary - : {parrotUnaryMinus.FoodPortion} g/day");
            Console.WriteLine($"Parrot -- : {parrotDec.FoodPortion} g/day");

            Console.WriteLine("\n=== Array of Cat objects with indexer ===\n");
            CatArray catArray = new CatArray(3);

            catArray[0] = new Cat("British Shorthair", "Misty", 4, 4.8, 125, true, 4, 6);
            catArray[1] = new Cat("Maine Coon", "Thor", 2, 6.1, 150, true, 2, 9);
            catArray[2] = new Cat("Bengal", "Leo", 3, 5.0, 140, false, 10, 8);

            Console.WriteLine("All cats from indexed array:");
            catArray.PrintAll();

            Console.WriteLine("Access object by index (catArray[1]):");
            catArray[1].WriteToConsole();

            Console.WriteLine("\n=== Lab 05 completed ===");
        }

        static void Greeting()
        {
            Console.WriteLine("===========================================");
            Console.WriteLine("     Laboratory Work No. 5");
            Console.WriteLine("===========================================");
            Console.WriteLine("Performed by: Vlad Sapozhnyk (8)");
            Console.WriteLine("Taras Shevchenko National University of Kyiv");
            Console.WriteLine("Group: IPZ-13, Subgroup: 6");
            Console.WriteLine("===========================================");
        }
    }
}
