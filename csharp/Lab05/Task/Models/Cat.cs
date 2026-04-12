using System;

namespace Task.Models
{
    public class Cat : Animal
    {
        private bool _isIndoor;
        private int _miceCaught;
        private int _temperamentLevel;

        public Cat() : base()
        {
            _isIndoor = true;
            _miceCaught = 0;
            _temperamentLevel = 5;
        }

        public Cat(
            string breed,
            string name,
            int age,
            double weight,
            double foodPortion,
            bool isIndoor,
            int miceCaught,
            int temperamentLevel) : base(breed, name, age, weight, foodPortion)
        {
            _isIndoor = isIndoor;
            _miceCaught = Math.Max(0, miceCaught);
            _temperamentLevel = ClampTemperament(temperamentLevel);
        }

        public Cat(Cat other) : base(other)
        {
            _isIndoor = other.IsIndoor;
            _miceCaught = other.MiceCaught;
            _temperamentLevel = other.TemperamentLevel;
        }

        public bool IsIndoor
        {
            get => _isIndoor;
            set => _isIndoor = value;
        }

        public int MiceCaught
        {
            get => _miceCaught;
            set => _miceCaught = Math.Max(0, value);
        }

        public int TemperamentLevel
        {
            get => _temperamentLevel;
            set => _temperamentLevel = ClampTemperament(value);
        }

        public void Purr()
        {
            Console.WriteLine($"  {Name} purrs softly.");
        }

        public override bool IsHappy()
        {
            return FoodPortion >= 120 && IsIndoor && TemperamentLevel >= 4;
        }

        public override bool IsHappy(int sleepHours, int playMinutes, bool ateWell)
        {
            return sleepHours >= 12 && playMinutes >= 15 && ateWell;
        }

        public override string DescribeCharacter(OwnerCharacter ownerCharacter)
        {
            return ownerCharacter switch
            {
                OwnerCharacter.Calm => $"{Name} is gentle and cuddly.",
                OwnerCharacter.Active => $"{Name} is curious and always exploring.",
                OwnerCharacter.Strict => $"{Name} behaves but keeps independence.",
                OwnerCharacter.Playful => $"{Name} is energetic and playful.",
                _ => $"{Name} is independent."
            };
        }

        public override void WriteToConsole()
        {
            Console.WriteLine("[Cat]");
            base.WriteToConsole();
            Console.WriteLine($"  Indoor:       {(IsIndoor ? "Yes" : "No")}");
            Console.WriteLine($"  Mice caught:  {MiceCaught}");
            Console.WriteLine($"  Temperament:  {TemperamentLevel}/10");
        }

        public static Cat operator +(Cat cat, double extraFood)
        {
            Cat copy = new Cat(cat);
            copy.FoodPortion += Math.Max(0, extraFood);
            return copy;
        }

        public static Cat operator -(Cat cat, double lessFood)
        {
            Cat copy = new Cat(cat);
            copy.FoodPortion = Math.Max(0, copy.FoodPortion - Math.Max(0, lessFood));
            return copy;
        }

        public static Cat operator ++(Cat cat)
        {
            Cat copy = new Cat(cat);
            copy.FoodPortion += 10;
            return copy;
        }

        public static Cat operator --(Cat cat)
        {
            Cat copy = new Cat(cat);
            copy.FoodPortion = Math.Max(0, copy.FoodPortion - 10);
            return copy;
        }

        public static Cat operator -(Cat cat)
        {
            Cat copy = new Cat(cat);
            copy.FoodPortion = Math.Max(0, copy.FoodPortion - 5);
            return copy;
        }

        public static bool operator >(Cat left, Cat right)
        {
            return left.TemperamentLevel > right.TemperamentLevel;
        }

        public static bool operator <(Cat left, Cat right)
        {
            return left.TemperamentLevel < right.TemperamentLevel;
        }

        public static bool operator ==(Cat? left, Cat? right)
        {
            if (ReferenceEquals(left, right)) return true;
            if (left is null || right is null) return false;
            return left.Name == right.Name && left.TemperamentLevel == right.TemperamentLevel;
        }

        public static bool operator !=(Cat? left, Cat? right)
        {
            return !(left == right);
        }

        public override bool Equals(object? obj)
        {
            return obj is Cat other && this == other;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, TemperamentLevel);
        }
    }
}
