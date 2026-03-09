using System;

namespace Task.Models
{
    public class DogV2 : AnimalBase
    {
        private bool _isGuardDog;

        public DogV2(string breed, string name, string characteristics, double weight, double height, bool isGuardDog) : base(breed, name, characteristics, weight, height)
        {
            _isGuardDog = isGuardDog;
        }

        public bool IsGuardDog
        {
            get => _isGuardDog;
            set => _isGuardDog = value;
        }

        public override void WriteToConsole()
        {
            Console.WriteLine("[DogV2 — interface-based]");
            base.WriteToConsole();
            Console.WriteLine($"  Guard dog:       {(IsGuardDog ? "Yes" : "No")}");
        }

        public override string MakeSound()
        {
            return $"{Name} says: Woof!";
        }

        public void Guard()
        {
            if (IsGuardDog)
                Console.WriteLine($"  {Name} is on guard duty!");
            else
                Console.WriteLine($"  {Name} prefers napping to guarding.");
        }
    }
}
