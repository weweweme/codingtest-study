class Program
{
    private static string[] _inputString;
    private static int vertexCount, edgeCount, startNode;
    private static List<int>[] _graph;
    private static bool[] _isVisited;
    private static int[] _visitedOrder;
    private static int checkNum = 1;

    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        
        _inputString = sr.ReadLine().Split(" ");
        vertexCount = int.Parse(_inputString[0]);
        edgeCount = int.Parse(_inputString[1]);
        startNode = int.Parse(_inputString[2]);

        _graph = new List<int>[vertexCount + 1];
        _isVisited = new bool[vertexCount + 1];
        _visitedOrder = new int[vertexCount + 1];
        for (int i = 0; i < vertexCount + 1; ++i)
        {
            _graph[i] = new List<int>();
        }

        for (int i = 0; i < edgeCount; ++i)
        {
            string[] edges = sr.ReadLine().Split(" ");
            int u = int.Parse(edges[0]);
            int v = int.Parse(edges[1]);

            _graph[u].Add(v);
            _graph[v].Add(u);
        }

        for (int i = 1; i < vertexCount + 1; ++i)
        {
            if (_graph[i] != null)
                _graph[i].Sort(); 
        }

        DFS(startNode);

        for (int i = 1; i < vertexCount + 1; ++i)
        {
            sw.WriteLine(_visitedOrder[i]);
        }
    }

    // 깊이 우선 탐색 수행.
    private static void DFS(int node)
    {
        // 이미 방문한 장소라면 종료.
        if (_isVisited[node])
            return;
        
        // 방문한 노드에 대한 로직 수행.
        _isVisited[node] = true;
        _visitedOrder[node] = checkNum;
        ++checkNum;

        // 해당 정점과 인접해있는 모든 노드들에 대해 DFS 수행.
        foreach (int nextNode in _graph[node])
        {
            DFS(nextNode);
        }
    }
}