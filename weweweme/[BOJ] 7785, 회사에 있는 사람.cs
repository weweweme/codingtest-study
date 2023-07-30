class Program
{
    private static int N;
    private static string[] InputString;
    private static HashSet<string> EnteredNames = new HashSet<string>();

    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        
        N = int.Parse(sr.ReadLine());

        for (int i = 0; i < N; ++i)
        {
            InputString = sr.ReadLine().Split(" ");
            string name = InputString[0];
            string commuteRecord = InputString[1];

            switch (commuteRecord)
            {
                case "enter":
                    EnteredNames.Add(name);
                    break;

                case "leave":
                    EnteredNames.Remove(name);
                    break;
            }
        }

        List<string> checkedInNames = EnteredNames.OrderByDescending(name => name).ToList();
        foreach (string name in checkedInNames)
        {
            sw.WriteLine(name);
        }
    }
}
