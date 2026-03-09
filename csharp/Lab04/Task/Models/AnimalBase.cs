using System;

namespace Task.Models
{
    public class AnimalBase : IAnimal
    {
        private string _breed;
        private string _name;
        private string _characteristics;
        private double _weight;
        private double _height;

        public AnimalBase(string breed, string name, string characteristics,
                          double weight, double height)
        {
            _breed = breed;
            _name = name;
            _characteristics = characteristics;
            _weight = weight;
            _height = height;
        }

        public string Breed { get => _breed; set => _breed = value; }
        public string Name { get => _name; set => _name = value; }
        public string Characteristics { get => _characteristics; set => _characteristics = value; }
        public double Weight { get => _weight; set => _weight = value; }
        public double Height { get => _height; set => _height = value; }

        public virtual void WriteToConsole()
        {
            Console.WriteLine($"  Name:            {Name}");
            Console.WriteLine($"  Breed:           {Breed}");
            Console.WriteLine($"  Characteristics: {Characteristics}");
            Console.WriteLine($"  Weight:          {Weight} kg");
            Console.WriteLine($"  Height:          {Height} cm");
        }

        public virtual string MakeSound()
        {
            return "...";
        }
    }
}
