using System;

namespace Task.Models
{
    public class DogV3 : AbstractAnimal
    {
        private int _loyaltyLevel;

        public DogV3(string breed, string name, string characteristics,
                     double weight, double height, int loyaltyLevel = 5)
            : base(breed, name, characteristics, weight, height)
        {
            _loyaltyLevel = Math.Clamp(loyaltyLevel, 1, 10);
        }

        public int LoyaltyLevel { get => _loyaltyLevel; set => _loyaltyLevel = Math.Clamp(value, 1, 10); }

        public override string MakeSound()
        {
            return $"{Name} says: Woof-woof!";
        }

        public override void WriteToConsole()
        {
            Console.WriteLine("[DogV3 — abstract class-based]");
            base.WriteToConsole();
            Console.WriteLine($"  Loyalty level:   {LoyaltyLevel}/10");
        }

        public void IncreaseLoyalty()
        {
            LoyaltyLevel++;
            Console.WriteLine($"  {Name}'s loyalty increased to {LoyaltyLevel}/10!");
        }
    }
}
