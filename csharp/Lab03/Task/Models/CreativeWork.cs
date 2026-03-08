using System;

namespace Task.Models;

public static class CreativeWork
{
    public static void PrintArray(int[] arr)
    {
        if (arr == null || arr.Length == 0) Console.WriteLine("Array is empty.");
        else Console.WriteLine(string.Join(", ", arr));
    }

    public static void QuickSortDescending(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int pivot = Partition(arr, left, right);
            QuickSortDescending(arr, left, pivot - 1);
            QuickSortDescending(arr, pivot + 1, right);
        }
    }

    private static int Partition(int[] arr, int left, int right)
    {
        int pivotValue = arr[right];
        int i = left - 1;
        for (int j = left; j < right; j++)
        {
            if (arr[j] >= pivotValue)
            {
                i++;
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }
        int t = arr[i + 1];
        arr[i + 1] = arr[right];
        arr[right] = t;
        return i + 1;
    }
}
