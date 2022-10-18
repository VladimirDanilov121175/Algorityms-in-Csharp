/* Grokking algorithms, p. 85, exercise 4.4
Рекурсивная функция бинарного поиска */

int Binary(int[] array, int value, int low, int high)
{
    if (high == low)
    {
        if (array[low] == value)
            return value;
        else return -1;
    }

    int mid = (low + high) / 2;
    if (array[mid] == value)
        return value;
    if (array[mid] > value)
        return Binary(array, value, low, mid - 1);
    else
        return Binary(array, value, mid + 1, high);
}

// Test zone
int[] array = { 1, 2, 3, 4, 5, 10, 21, 56 };
Console.WriteLine(Binary(array, 10, 0, array.Length - 1));  // -> 10
Console.WriteLine(Binary(array, 7, 0, array.Length - 1));   // -> -1
