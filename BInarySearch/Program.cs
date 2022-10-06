int BinarySearch(int[] array, int item)
{
    int low = 0;
    int high = array.Length - 1;

    while (low <= high)
    {
        int guess = (low + high) / 2;

        if (array[guess] == item)
            return guess;

        if (array[guess] < item)
            low = guess + 1;

        if (array[guess] > item)
            high = guess - 1;
    }
    return -1;
}

/*********************************
            Test zone
*********************************/
int[] arr = new int[101];
int i = 0;
foreach (int j in arr)
{
    arr[i] = i;
    i++;
}
Console.Write("[" + string.Join(" ", arr) + "]");
Console.WriteLine();

Console.WriteLine(BinarySearch(arr, 5));
