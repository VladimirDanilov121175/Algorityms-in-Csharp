/* Grokking algorithms, p. 85, exercise 4.2
Рекурсивная функция нахождения максимального числа в списке */

int Max(int[] array, int low, int high)
{
    if (high == low + 1)
    {
        if (array[high] > array[low])
            return array[high];
        else return array[low];
    }

    int mid = (high + low) / 2;

    if (Max(array, low, mid) > Max(array, mid + 1, high))
        return Max(array, low, mid);
    else return Max(array, mid + 1, high);
}

// Test zone
int[] array = {10, 7, 34, 5, -5, 13, 98, 11};
Console.WriteLine(Max(array, 0, array.Length - 1));   // -> 98
