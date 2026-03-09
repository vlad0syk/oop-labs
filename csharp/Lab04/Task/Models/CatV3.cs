using System;

namespace Task.Models
{
    public class CatV3 : AbstractAnimal
    {
        private int _livesLeft;

        public CatV3(string breed, string name, string characteristics, double weight, double height, int livesLeft = 9) : base(breed, name, characteristics, weight, height)
        {
            _livesLeft = livesLeft;
        }

        public int LivesLeft
        {
            get => _livesLeft;
            set => _livesLeft = value;
        }

        public override string MakeSound()
        {
            return $"{Name} says: Meow-meow!";
        }

        public override void WriteToConsole()
        {
            Console.WriteLine("[CatV3 — abstract class-based]");
            base.WriteToConsole();
            Console.WriteLine($"  Lives left:      {LivesLeft}");
        }

        public void LoseLife()
        {
            if (_livesLeft > 0)
            {
                _livesLeft--;
                Console.WriteLine($"  {Name} lost a life! Lives remaining: {_livesLeft}");
            }
            else
            {
                Console.WriteLine($"  {Name} has no more lives!");
            }
        }
    }
}
