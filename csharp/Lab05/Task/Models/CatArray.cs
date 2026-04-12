using System;

namespace Task.Models
{
    public class CatArray
    {
        private readonly Cat[] _cats;

        public CatArray(int size)
        {
            _cats = new Cat[size];
        }

        public int Length => _cats.Length;

        public Cat this[int index]
        {
            get
            {
                if (index < 0 || index >= _cats.Length)
                    throw new IndexOutOfRangeException("Invalid cat index.");

                return _cats[index];
            }
            set
            {
                if (index < 0 || index >= _cats.Length)
                    throw new IndexOutOfRangeException("Invalid cat index.");

                _cats[index] = value;
            }
        }

        public void PrintAll()
        {
            for (int i = 0; i < _cats.Length; i++)
            {
                Console.WriteLine($"Cat #{i + 1}");
                _cats[i].WriteToConsole();
                Console.WriteLine();
            }
        }
    }
}
