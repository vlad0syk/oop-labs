using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Task.Models
{
    public class AnimalCollection : IEnumerable<Animal>
    {
        private Animal[] _animals;

        public AnimalCollection(Animal[] animals)
        {
            _animals = animals;
        }

        public int Count => _animals.Length;

        public Animal this[int index] => _animals[index];

        public IEnumerator<Animal> GetEnumerator()
        {
            Animal[] sorted = (Animal[])_animals.Clone();
            Array.Sort(sorted);
            foreach (var animal in sorted)
            {
                yield return animal;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void PrintAll()
        {
            Console.WriteLine("Animals sorted by weight:");
            int i = 1;
            foreach (var animal in this)
            {
                Console.WriteLine($"  {i}. {animal}");
                i++;
            }
        }
    }
}
