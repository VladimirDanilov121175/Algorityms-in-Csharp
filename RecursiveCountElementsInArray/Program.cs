// Grokking algorithms, p. 85, exercise 4.2
// Рекурсивная функция подсчета элементов в списке

int CountElements(int[] array, int low, int high)
{
    if (array[low] == array[high])
        return 1;

    int mid = (high + low) / 2;
    return CountElements(array, low, mid) + CountElements(array, mid + 1, high);
}

// Test zone
int[] array = new int[] { 1, 2, 11, 4, 6, 10 };
Console.WriteLine(CountElements(array, 0, array.Length - 1));
