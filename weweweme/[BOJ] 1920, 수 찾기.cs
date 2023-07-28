class Program
{
    private static int N, M;
    private static int[] NArr, MArr;

    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        
        N = int.Parse(sr.ReadLine());
        NArr = Array.ConvertAll(sr.ReadLine().Split(" "), int.Parse);
        Array.Sort(NArr);
        M = int.Parse(sr.ReadLine());
        MArr = Array.ConvertAll(sr.ReadLine().Split(" "), int.Parse);

        foreach (int elem in MArr)
        {
            sw.WriteLine(BinarySearch(NArr, elem));
        }
    }

    // 이진 탐색.
    private static int BinarySearch(int[] arr, int targetValue)
    {
        int startIndex = 0;
        int endIndex = arr.Length - 1;

        while (startIndex <= endIndex)
        {
            int middleIndex =  (startIndex + endIndex) / 2;

            if (arr[middleIndex] == targetValue)
            {
                return 1;
            }
            else if (arr[middleIndex] < targetValue)
            {
                startIndex = middleIndex + 1;
            }
            else
            {
                endIndex = middleIndex - 1;
            }
        }

        return 0;
    }
}
