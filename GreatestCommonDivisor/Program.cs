// Алгоритмы нахождения наибольшего общего делителя двух чисел (НОД)
// Greatest common divisor (GCD)

// # 1 - upward
int GcdUp(int x, int y)
{
    int min = x < y ? x : y;
    int gcd = 1;  // initial gcd
    int count = 0;  // counter for number of operations needed

    for (int i = 2; i <= min; i++)
    {
        count++;

        if (x % i == 0 && y % i == 0)
            gcd = i;
    }
    Console.WriteLine($"Count of operations (GcdUp): {count}");
    return gcd;
}

// # 2 - downward
int GcdDown(int x, int y)
{
    int min = x < y ? x : y;
    int gcd = 1;
    int count = 0;

    for (int i = min; i >= 2; i--)
    {
        count++;

        if (x % i == 0 && y % i == 0)
        {
            gcd = i;
            break;  // no need to continue because gcd found
        }
    }
    Console.WriteLine($"Count of operations (GcdDown): {count}");
    return gcd;
}

// # 3 GCD Euclidean algorithm - Алгоритм Евклида
int GcdEuclidean(int x, int y)
{
    int count = 0;

    while (x != y)
    {
        count++;

        if (x > y)
            x -= y;
        else
            y -= x;
    }
    Console.WriteLine($"Count of operations (GcdEuclidean): {count}");
    return x;
}

// # 4 Quick Euclidean algorithm - the quickest of all 4
int QuickEuclidean(int x, int y)
{
    int count = 0;
    int temp = 0;
    if (y > x) (x, y) = (y, x);  // x has to be always greater, if not - swap

    while (y != 0)
    {
        count++;

        temp = x % y;
        x = y;
        y = temp;
    }
    Console.WriteLine($"Count of operations (QuickEuclidean): {count}");
    return x;
}


int x = 32, y = 156;

Console.WriteLine(GcdUp(x, y));
Console.WriteLine(GcdDown(x, y));
Console.WriteLine(GcdEuclidean(x, y));
Console.WriteLine(QuickEuclidean(x, y));
