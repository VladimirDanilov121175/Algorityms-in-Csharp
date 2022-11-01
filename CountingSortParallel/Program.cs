/* Counting sort algorithm with threads for parallel calculations */

const int THREADS_NUMBER = 8;   // number of threads
const int N = 100000;              // size of array
object locker = new object();  // locker for preventing conflicts of threads


Random rand = new Random();
int[] arraySerial = new int[N].Select(r => rand.Next(0, 5)).ToArray();   // filling array with random in one string

int[] arrayParallel = new int[N];
Array.Copy(arraySerial, arrayParallel, N); // copy arraySerial to arrayParallel


CountingSort(arraySerial);
PrepareParallelCountingSort(arrayParallel);
Console.WriteLine(EqualityMatrix(arraySerial, arrayParallel));


void PrepareParallelCountingSort(int[] inputArray)
{
    int calcNum = N / THREADS_NUMBER;
    var threads = new List<Thread>();

    int min = inputArray.Min();
    int max = inputArray.Max();
    int offset = -min;

    int[] counters = new int[max + offset + 1];

    for (int i = 0; i < THREADS_NUMBER; i++)
    {
        int startPos = i * calcNum;
        int endPos = (i + 1) * calcNum;
        if (i == N) endPos = N;

        threads.Add(new Thread(() => ParallelCountingSort(inputArray, counters, startPos, endPos, offset)));
        threads[i].Start();
    }

    foreach (var thread in threads)
        thread.Join();   // waiting until all threads finished their work

    int index = 0;
    for (int i = 0; i < counters.Length; i++)
        for (int j = 0; j < counters[i]; j++)
        {
            inputArray[index] = i - offset;
            index++;
        }
}


void ParallelCountingSort(int[] inputArray, int[] counters, int startPos, int endPos, int offset)
{

    for (int i = startPos; i < endPos; i++)
    {
        lock (locker)  // locking the access for other threads until occupied by the current one
        {
            counters[inputArray[i] + offset]++;
        }
    }

}

void CountingSort(int[] inputArray)
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
            inputArray[index] = i - offset;
            index++;
        }
}


// Checking two matrixes for equality
bool EqualityMatrix(int[] a, int[] b)
{
    bool flag = true;

    for (int i = 0; i < a.GetLength(0); i++)
        flag = flag && (a[i] == b[i]);
    return flag;
}
