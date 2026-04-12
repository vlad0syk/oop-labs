using System;

namespace Task.Models
{
    public class Dog : Animal
    {
        private bool _isGuardDog;
        private int _commandsKnown;
        private int _temperamentLevel;

        public Dog() : base()
        {
            _isGuardDog = false;
            _commandsKnown = 0;
            _temperamentLevel = 6;
        }

        public Dog(
            string breed,
            string name,
            int age,
            double weight,
            double foodPortion,
            bool isGuardDog,
            int commandsKnown,
            int temperamentLevel) : base(breed, name, age, weight, foodPortion)
        {
            _isGuardDog = isGuardDog;
            _commandsKnown = Math.Max(0, commandsKnown);
            _temperamentLevel = ClampTemperament(temperamentLevel);
        }

        public Dog(Dog other) : base(other)
        {
            _isGuardDog = other.IsGuardDog;
            _commandsKnown = other.CommandsKnown;
            _temperamentLevel = other.TemperamentLevel;
        }

        public bool IsGuardDog
        {
            get => _isGuardDog;
            set => _isGuardDog = value;
        }

        public int CommandsKnown
        {
            get => _commandsKnown;
            set => _commandsKnown = Math.Max(0, value);
        }

        public int TemperamentLevel
        {
            get => _temperamentLevel;
            set => _temperamentLevel = ClampTemperament(value);
        }

        public void Bark()
        {
            Console.WriteLine($"  {Name} barks loudly.");
        }

        public override bool IsHappy()
        {
            return FoodPortion >= 180 && CommandsKnown >= 3 && TemperamentLevel >= 5;
        }

        public override bool IsHappy(int sleepHours, int playMinutes, bool ateWell)
        {
            return sleepHours >= 9 && playMinutes >= 40 && ateWell;
        }

        public override string DescribeCharacter(OwnerCharacter ownerCharacter)
        {
            return ownerCharacter switch
            {
                OwnerCharacter.Calm => $"{Name} is loyal and steady.",
                OwnerCharacter.Active => $"{Name} is energetic and ready for walks.",
                OwnerCharacter.Strict => $"{Name} is obedient and focused.",
                OwnerCharacter.Playful => $"{Name} is very social and joyful.",
                _ => $"{Name} is protective."
            };
        }

        public override void WriteToConsole()
        {
            Console.WriteLine("[Dog]");
            base.WriteToConsole();
            Console.WriteLine($"  Guard dog:    {(IsGuardDog ? "Yes" : "No")}");
            Console.WriteLine($"  Commands:     {CommandsKnown}");
            Console.WriteLine($"  Temperament:  {TemperamentLevel}/10");
        }

        public static Dog operator +(Dog dog, double extraFood)
        {
            Dog copy = new Dog(dog);
            copy.FoodPortion += Math.Max(0, extraFood);
            return copy;
        }

        public static Dog operator -(Dog dog, double lessFood)
        {
            Dog copy = new Dog(dog);
            copy.FoodPortion = Math.Max(0, copy.FoodPortion - Math.Max(0, lessFood));
            return copy;
        }

        public static Dog operator ++(Dog dog)
        {
            Dog copy = new Dog(dog);
            copy.FoodPortion += 20;
            return copy;
        }

        public static Dog operator --(Dog dog)
        {
            Dog copy = new Dog(dog);
            copy.FoodPortion = Math.Max(0, copy.FoodPortion - 20);
            return copy;
        }

        public static Dog operator -(Dog dog)
        {
            Dog copy = new Dog(dog);
            copy.FoodPortion = Math.Max(0, copy.FoodPortion - 10);
            return copy;
        }

        public static bool operator >(Dog left, Dog right)
        {
            return left.TemperamentLevel > right.TemperamentLevel;
        }

        public static bool operator <(Dog left, Dog right)
        {
            return left.TemperamentLevel < right.TemperamentLevel;
        }

        public static bool operator ==(Dog? left, Dog? right)
        {
            if (ReferenceEquals(left, right)) return true;
            if (left is null || right is null) return false;
            return left.Name == right.Name && left.TemperamentLevel == right.TemperamentLevel;
        }

        public static bool operator !=(Dog? left, Dog? right)
        {
            return !(left == right);
        }

        public override bool Equals(object? obj)
        {
            return obj is Dog other && this == other;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, TemperamentLevel);
        }
    }
}
