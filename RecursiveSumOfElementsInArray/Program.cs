/*
Рекурсивный метод поиска суммы всех элементов в массиве.
Используется принцип бинарного поиска - деление диапазона индексов пополам, пока 
рекурсия не дойдет до единичных индексов, которые и будет складывать.
 */
 int RecursiveSumOfElements(int[] array, int low, int high)
{
    if (low == high) return array[low];   // or array[high] - базовая часть рекурсии

    int mid = low + (high - low) / 2;

    // Разбивка на 2 диапазона с определением новых low и high для передачи в следующую рекурсию
    return RecursiveSumOfElements(array, low, mid) + RecursiveSumOfElements(array, mid + 1, high); 
}

// Test zone
int[] array = new int[] { -2, 7, 3, 77, 8, 33 };
int sum = RecursiveSumOfElements(array, 0, array.Length - 1);
Console.WriteLine(sum);