using System;

namespace Task.Models
{
    public class Animal
    {
        private string _breed;
        private string _name;
        private int _age;
        private double _weight;
        private double _foodPortion;

        public Animal()
        {
            _breed = "Unknown";
            _name = "Unnamed";
            _age = 0;
            _weight = 0;
            _foodPortion = 100;
        }

        public Animal(string breed, string name, int age, double weight, double foodPortion)
        {
            _breed = breed;
            _name = name;
            _age = Math.Max(0, age);
            _weight = Math.Max(0, weight);
            _foodPortion = Math.Max(0, foodPortion);
        }

        public Animal(Animal other)
        {
            _breed = other.Breed;
            _name = other.Name;
            _age = other.Age;
            _weight = other.Weight;
            _foodPortion = other.FoodPortion;
        }

        public string Breed
        {
            get => _breed;
            set => _breed = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public int Age
        {
            get => _age;
            set => _age = Math.Max(0, value);
        }

        public double Weight
        {
            get => _weight;
            set => _weight = Math.Max(0, value);
        }

        public double FoodPortion
        {
            get => _foodPortion;
            set => _foodPortion = Math.Max(0, value);
        }

        protected static int ClampTemperament(int value)
        {
            return Math.Clamp(value, 1, 10);
        }

        public virtual bool IsHappy()
        {
            return FoodPortion >= 150 && Weight > 0;
        }

        public virtual bool IsHappy(int sleepHours, int playMinutes, bool ateWell)
        {
            return sleepHours >= 7 && playMinutes >= 20 && ateWell;
        }

        public virtual string DescribeCharacter(OwnerCharacter ownerCharacter)
        {
            return ownerCharacter switch
            {
                OwnerCharacter.Calm => $"{Name} is calm and balanced.",
                OwnerCharacter.Active => $"{Name} is active and curious.",
                OwnerCharacter.Strict => $"{Name} is disciplined but cautious.",
                OwnerCharacter.Playful => $"{Name} is playful and social.",
                _ => $"{Name} has a neutral temperament."
            };
        }

        public virtual string DescribeCharacter()
        {
            return DescribeCharacter(OwnerCharacter.Calm);
        }

        public virtual void WriteToConsole()
        {
            Console.WriteLine($"  Name:         {Name}");
            Console.WriteLine($"  Breed:        {Breed}");
            Console.WriteLine($"  Age:          {Age}");
            Console.WriteLine($"  Weight:       {Weight} kg");
            Console.WriteLine($"  Food portion: {FoodPortion} g/day");
        }
    }
}
