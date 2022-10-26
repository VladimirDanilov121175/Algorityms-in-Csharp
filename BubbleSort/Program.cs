// Bubble sort algorithm 
// Пузырьковая сортировка

// Creating array
System.Console.WriteLine("Input array length: ");
int n = Convert.ToInt32(Console.ReadLine());
int[] array = new int[n];

Console.WriteLine($"Input {n} elements of array:");
for (int i = 0; i < n; i++)
    array[i] = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Initial array: [" + string.Join(", ", array) + "]");

// Bubble sort
for (int i = 0; i < n - 1; i++)
{
    for (int j = 0; j < n - 1; j++)
        if (array[j] > array[j + 1])
        {
            int temp = array[j + 1];
            array[j + 1] = array[j];
            array[j] = temp;
        }
}

Console.WriteLine("Sorted array: [" + string.Join(", ", array) + "]");
