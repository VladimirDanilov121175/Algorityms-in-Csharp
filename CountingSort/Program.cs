// Counting sort algorithm.
// Working only with integers, not for doubles!

/* **********************
Algorithm for digits only, i.e. 0-9
************************/
int[] array = { 1, 2, 5, 1, 0, 3, 7, 5, 3, 1, 1, 0, 6, 3, 8, 0, 3, 4, 1, 4, 4, 9 };

Console.WriteLine("[" + string.Join(", ", array) + "]");
CountingSort(array);
Console.WriteLine("[" + string.Join(", ", array) + "]");

void CountingSort(int[] inputArray)
{
    int[] counters = new int[10];

    for (int i = 0; i < inputArray.Length; i++)
    {
        counters[inputArray[i]]++;
    }

    int index = 0;
    for (int i = 0; i < counters.Length; i++)
        for (int j = 0; j < counters[i]; j++)
        {
            array[index] = i;
            index++;
        }
}

Console.WriteLine();

/* **********************
Algorithm for any integers, inclusive negative ones
************************/
int[] array2 = { 3, -100, 5, 10, -5, -6, 12, 315, 0, 1, -5, 3, 0, -10 };

Console.WriteLine("[" + string.Join(", ", array2) + "]");
CountingSortExtended(array2);
Console.WriteLine("[" + string.Join(", ", array2) + "]");


void CountingSortExtended(int[] inputArray)
{
    int min = inputArray.Min();
    int max = inputArray.Max();
    int offset = -min;

    int[] counters = new int[max + offset + 1];

    for (int i = 0; i < inputArray.Length; i++)
    {
        counters[inputArray[i] + offset]++;
    }

    int index = 0;
    for (int i = 0; i < counters.Length; i++)
        for (int j = 0; j < counters[i]; j++)
        {
            array2[index] = i - offset;
            index++;
        }
}
