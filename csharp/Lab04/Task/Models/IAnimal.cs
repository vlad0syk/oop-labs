using System;

namespace Task.Models
{
    public interface IAnimal
    {
        string Breed { get; set; }
        string Name { get; set; }
        string Characteristics { get; set; }
        double Weight { get; set; }
        double Height { get; set; }

        void WriteToConsole();
        string MakeSound();
    }
}
