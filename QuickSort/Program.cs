/* Quick sort algorithm */

void QuickSort(int[] array, int start, int end)
{
    if (start >= end) return;

    int pivot = GetPivot(array, start, end);
    QuickSort(array, start, pivot - 1);
    QuickSort(array, pivot + 1, end);
    return;
}


int GetPivot(int[] array, int start, int end)
{
    int pivot = start - 1;
    for (int i = start; i <= end; i++)
        if (array[i] < array[end])
        {
            pivot++;
            Swap(ref array[pivot], ref array[i]);
        }
    pivot++;
    Swap(ref array[pivot], ref array[end]);
    return pivot;
}

void Swap(ref int leftValue, ref int rightValue)
{
    int temp = leftValue;
    leftValue = rightValue;
    rightValue = temp;
}

// Test zone

int[] array = { 10, 3, 25, -13, 45, 7, 0, 15 };
Console.WriteLine("Initial array: [" + string.Join(", ", array) + "]");
QuickSort(array, 0, array.Length - 1);
Console.WriteLine("Sorted array: [" + string.Join(", ", array) + "]");
