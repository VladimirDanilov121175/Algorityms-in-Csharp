/* 
Сортировка выбором / Selection sort
from the book "Grokking algorithms"
 */

int[] SelectionSort(int[] array)
{

    for (int i = 0; i < array.Length - 1; i++)
    {
        int minIndex = i;
        for (int j = i + 1; j < array.Length; j++)
            if (array[j] < array[minIndex])
            {
                minIndex = j;
            }
        int temp = array[minIndex];
        array[minIndex] = array[i];
        array[i] = temp;
    }
    return array;
}

// Test zone
int[] arr = { 12, 1, 9, 34, 25, 7, 138, 11, 46, 99 };
Console.Write(string.Join(" ", SelectionSort(arr)));
