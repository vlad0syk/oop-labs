using System;

namespace Task.Models
{
    public class Parrot : Animal
    {
        private int _vocabularySize;
        private bool _canFlyFreely;
        private int _temperamentLevel;

        public Parrot() : base()
        {
            _vocabularySize = 0;
            _canFlyFreely = false;
            _temperamentLevel = 7;
        }

        public Parrot(
            string breed,
            string name,
            int age,
            double weight,
            double foodPortion,
            int vocabularySize,
            bool canFlyFreely,
            int temperamentLevel) : base(breed, name, age, weight, foodPortion)
        {
            _vocabularySize = Math.Max(0, vocabularySize);
            _canFlyFreely = canFlyFreely;
            _temperamentLevel = ClampTemperament(temperamentLevel);
        }

        public Parrot(Parrot other) : base(other)
        {
            _vocabularySize = other.VocabularySize;
            _canFlyFreely = other.CanFlyFreely;
            _temperamentLevel = other.TemperamentLevel;
        }

        public int VocabularySize
        {
            get => _vocabularySize;
            set => _vocabularySize = Math.Max(0, value);
        }

        public bool CanFlyFreely
        {
            get => _canFlyFreely;
            set => _canFlyFreely = value;
        }

        public int TemperamentLevel
        {
            get => _temperamentLevel;
            set => _temperamentLevel = ClampTemperament(value);
        }

        public void Speak(string phrase)
        {
            Console.WriteLine($"  {Name} says: \"{phrase}\"");
        }

        public override bool IsHappy()
        {
            return FoodPortion >= 70 && VocabularySize >= 10 && CanFlyFreely;
        }

        public override bool IsHappy(int sleepHours, int playMinutes, bool ateWell)
        {
            return sleepHours >= 10 && playMinutes >= 25 && ateWell;
        }

        public override string DescribeCharacter(OwnerCharacter ownerCharacter)
        {
            return ownerCharacter switch
            {
                OwnerCharacter.Calm => $"{Name} is attentive and observant.",
                OwnerCharacter.Active => $"{Name} is noisy and adventurous.",
                OwnerCharacter.Strict => $"{Name} follows routine and repeats commands.",
                OwnerCharacter.Playful => $"{Name} is talkative and friendly.",
                _ => $"{Name} is expressive."
            };
        }

        public override void WriteToConsole()
        {
            Console.WriteLine("[Parrot]");
            base.WriteToConsole();
            Console.WriteLine($"  Vocabulary:   {VocabularySize} words");
            Console.WriteLine($"  Free flight:  {(CanFlyFreely ? "Yes" : "No")}");
            Console.WriteLine($"  Temperament:  {TemperamentLevel}/10");
        }

        public static Parrot operator +(Parrot parrot, double extraFood)
        {
            Parrot copy = new Parrot(parrot);
            copy.FoodPortion += Math.Max(0, extraFood);
            return copy;
        }

        public static Parrot operator -(Parrot parrot, double lessFood)
        {
            Parrot copy = new Parrot(parrot);
            copy.FoodPortion = Math.Max(0, copy.FoodPortion - Math.Max(0, lessFood));
            return copy;
        }

        public static Parrot operator ++(Parrot parrot)
        {
            Parrot copy = new Parrot(parrot);
            copy.FoodPortion += 5;
            return copy;
        }

        public static Parrot operator --(Parrot parrot)
        {
            Parrot copy = new Parrot(parrot);
            copy.FoodPortion = Math.Max(0, copy.FoodPortion - 5);
            return copy;
        }

        public static Parrot operator -(Parrot parrot)
        {
            Parrot copy = new Parrot(parrot);
            copy.FoodPortion = Math.Max(0, copy.FoodPortion - 3);
            return copy;
        }

        public static bool operator >(Parrot left, Parrot right)
        {
            return left.TemperamentLevel > right.TemperamentLevel;
        }

        public static bool operator <(Parrot left, Parrot right)
        {
            return left.TemperamentLevel < right.TemperamentLevel;
        }

        public static bool operator ==(Parrot? left, Parrot? right)
        {
            if (ReferenceEquals(left, right)) return true;
            if (left is null || right is null) return false;
            return left.Name == right.Name && left.TemperamentLevel == right.TemperamentLevel;
        }

        public static bool operator !=(Parrot? left, Parrot? right)
        {
            return !(left == right);
        }

        public override bool Equals(object? obj)
        {
            return obj is Parrot other && this == other;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, TemperamentLevel);
        }
    }
}
