using System;

namespace Task.Models
{
    public class Cat : Animal
    {
        private bool _isIndoor;
        private int _miceCaught;

        public Cat(string breed, string name, string characteristics, double weight, double height, bool isIndoor, int miceCaught)
            : base(breed, name, characteristics, weight, height)
        {
            _isIndoor = isIndoor;
            _miceCaught = miceCaught;
        }

        public bool IsIndoor
        {
            get => _isIndoor;
            set => _isIndoor = value;
        }

        public int MiceCaught
        {
            get => _miceCaught;
            set => _miceCaught = value;
        }

        public override void WriteToConsole()
        {
            Console.WriteLine($"[Cat]");
            base.WriteToConsole();
            Console.WriteLine($"  Indoor:          {(IsIndoor ? "Yes" : "No")}");
            Console.WriteLine($"  Mice caught:     {MiceCaught}");
        }

        public void Purr()
        {
            Console.WriteLine($"  {Name} purrs softly: purrr-purrr...");
        }

        public void CatchMice(int count)
        {
            _miceCaught += count;
            Console.WriteLine($"  {Name} caught {count} mice! Total: {MiceCaught}");
        }

        public void Train(string trick)
        {
            Console.WriteLine($"  Training {Name} to do \"{trick}\"...");
            if (new Random().Next(0, 2) == 0)
                Console.WriteLine($"  {Name} ignores you completely. Typical cat.");
            else
                Console.WriteLine($"  {Name} learned \"{trick}\"! Surprising for a cat.");
        }

        public void Confront(Dog dog)
        {
            Console.WriteLine($"\n  {Name} (cat) vs {dog.Name} (dog) — CONFRONTATION!");
            if (Weight * 3 > dog.Weight)
                Console.WriteLine($"  {Name} hisses loudly and scares {dog.Name} away!");
            else
                Console.WriteLine($"  {Name} climbs up a tree to escape {dog.Name}!");
        }

        public void BeFriendsWith(Dog dog)
        {
            Console.WriteLine($"\n  {Name} (cat) and {dog.Name} (dog) — FRIENDSHIP!");
            Console.WriteLine($"  {Name} rubs against {dog.Name}'s leg.");
            Console.WriteLine($"  {dog.Name} wags tail happily. They curl up together.");
        }
    }
}
