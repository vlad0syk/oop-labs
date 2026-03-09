using System;
using System.Collections.Generic;

namespace Task.Models
{
    public class Dog : Animal
    {
        private bool _isGuardDog;
        private List<string> _commandsKnown;

        public Dog(string breed, string name, string characteristics,
                   double weight, double height,
                   bool isGuardDog)
            : base(breed, name, characteristics, weight, height)
        {
            _isGuardDog = isGuardDog;
            _commandsKnown = new List<string>();
        }

        public bool IsGuardDog
        {
            get => _isGuardDog;
            set => _isGuardDog = value;
        }

        public IReadOnlyList<string> CommandsKnown => _commandsKnown;

        public override void WriteToConsole()
        {
            Console.WriteLine($"[Dog]");
            base.WriteToConsole();
            Console.WriteLine($"  Guard dog:       {(IsGuardDog ? "Yes" : "No")}");
            Console.WriteLine($"  Commands known:  {(_commandsKnown.Count > 0 ? string.Join(", ", _commandsKnown) : "none")}");
        }

        public void Bark()
        {
            Console.WriteLine($"  {Name} barks: Woof-woof!");
        }

        public void Train(string command)
        {
            if (_commandsKnown.Contains(command))
            {
                Console.WriteLine($"  {Name} already knows \"{command}\".");
            }
            else
            {
                _commandsKnown.Add(command);
                Console.WriteLine($"  {Name} learned a new command: \"{command}\"! (Total: {_commandsKnown.Count})");
            }
        }

        public void Confront(Cat cat)
        {
            Console.WriteLine($"\n  {Name} (dog) vs {cat.Name} (cat) — CONFRONTATION!");
            if (Weight > cat.Weight * 3)
                Console.WriteLine($"  {Name} chases {cat.Name} across the yard!");
            else
                Console.WriteLine($"  {cat.Name} stands its ground and {Name} backs off!");
        }

        public void BeFriendsWith(Cat cat)
        {
            Console.WriteLine($"\n  {Name} (dog) and {cat.Name} (cat) — FRIENDSHIP!");
            Console.WriteLine($"  {Name} offers a paw to {cat.Name}.");
            Console.WriteLine($"  They share a bowl of water and nap together.");
        }

        public void Guard()
        {
            if (IsGuardDog)
                Console.WriteLine($"  {Name} is guarding the house! Nobody gets in.");
            else
                Console.WriteLine($"  {Name} tried to guard but got distracted by a butterfly.");
        }
    }
}
