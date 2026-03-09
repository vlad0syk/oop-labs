using System;
using System.Collections.Generic;

namespace Task.Models
{
    public class AnimalHeightComparer : IComparer<Animal>
    {
        public int Compare(Animal? x, Animal? y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            int result = x.Height.CompareTo(y.Height);
            if (result == 0)
                result = x.Weight.CompareTo(y.Weight);
            return result;
        }
    }
}
