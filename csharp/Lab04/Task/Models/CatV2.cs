using System;

namespace Task.Models
{
    public class CatV2 : AnimalBase
    {
        private bool _isIndoor;

        public CatV2(string breed, string name, string characteristics, double weight, double height, bool isIndoor) : base(breed, name, characteristics, weight, height)
        {
            _isIndoor = isIndoor;
        }

        public bool IsIndoor { get => _isIndoor; set => _isIndoor = value; }

        public override void WriteToConsole()
        {
            Console.WriteLine("[CatV2 — interface-based]");
            base.WriteToConsole();
            Console.WriteLine($"  Indoor:          {(IsIndoor ? "Yes" : "No")}");
        }

        public override string MakeSound()
        {
            return $"{Name} says: Meow!";
        }

        public void Purr()
        {
            Console.WriteLine($"  {Name} purrs: purrr...");
        }
    }
}
