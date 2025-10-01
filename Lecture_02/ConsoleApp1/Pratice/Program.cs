namespace Pratice
{
    public class Graph
    {
        public int V;
        public List<int>[] adj;

        public Graph(int v)
        {
            V = v;
            adj = new List<int>[V];

            for (int i = 0; i < V; i++)
            {
                adj[i] = new List<int>();
            }
        }

        public void AddEdge(int v, int w)
        {
            adj[v].Add(w);
        }

        public void DFS(int v)
        {
            bool[] visited = new bool[V];
            DFSUtil(v, visited);
        }

        private void DFSUtil(int v, bool[] visited)
        {
            visited[v] = true;
            Console.Write($"{v} ");

            foreach(int n in adj[v])
            {
                if (!visited[n])
                {
                    DFSUtil(n, visited);
                }
            }
        }

        public void BFS(int v)
        {
            bool[] visited = new bool[V];
            Queue<int> queue = new Queue<int>();

            visited[v] = true;
            queue.Enqueue(v);

            while( queue.Count > 0 )
            {
                int n = queue.Dequeue();
                Console.Write($"{n} ");

                foreach(int m in adj[n])
                {
                    if (!visited[m])
                    {
                        visited[m] = true;
                        queue.Enqueue(m);
                    }
                }
            }
        }
    }

    // Genral Type
    class Stack<T>
    {
        public List<T> Shuffle(List<T> list)
        {
            Random random = new Random();

            for(int i=list.Count-1; i>=0; i--)
            {
                // 셔플은 뒤에서부터 돌아야 안정성이 높음
                int j = random.Next(0, i-1);
                (list[i], list[j]) = (list[i], list[j]); // 튜플 스왑
            }

            return list;
        }
    }

    internal class Program
    {
        // 델리게이트 사용
        delegate void MyDelegate(string message);

        delegate int MyDelegate2(int x, int y);

        static int Add(int x, int y) => (x+y);

        static void Method1(string message)
        {
            Console.WriteLine("Method1: " + message); 
        }

        static void Method2(string message)
        {
            Console.WriteLine("Method2: " + message);
        }

        static void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        static int Add2(int a, int b) => a + b;

        static void Main(string[] args)
        {
            MyDelegate2 myDelegate2 = Add;
            myDelegate2(1, 2);

            MyDelegate myDelegate = Method1;
            myDelegate += Method2;

            // 여러 함수가 있는데 연결만 시켜서 하는거
            myDelegate("Hello");

            Func<int, int, int> addFunc = Add;
            int result = addFunc(3, 5);

            Action<string> printAction = PrintMessage;
            printAction("Hello, World");

            QuickSortClass quickSort = new QuickSortClass();

            int[] arr = new int[5] { 4, 2, 3, 6, 11 };
            quickSort.QuickSort(arr, 0, arr.Length - 1);
            foreach(int i in arr) { Console.WriteLine(i); }

            Graph graph = new Graph(6);

            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(1, 3);
            graph.AddEdge(2, 3);
            graph.AddEdge(2, 4);
            graph.AddEdge(3, 4);
            graph.AddEdge(4, 5);

            Console.WriteLine("DFS travelsal: ");
            graph.DFS(0);
            Console.WriteLine();

            Console.WriteLine("BFS travelsal: ");
            graph.BFS(0);
            Console.WriteLine();

            Stack<int> stack = new Stack<int>();
        }


        // 어떤 행위가 이뤄질때 다른 행위가 처리가 필요한 애들을 다 예약을 걸어놓자
    }

    class QuickSortClass()
    {
        public int Particion(int[] arr, int left, int right)
        {
            // Particion은 배열을 돌면서 pivot 기준으로 크기 비교
            int pivot = arr[right];
            int i = left - 1;

            for(int j=left; j<=right; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;

                    // 튜플 스왑
                    (arr[i], arr[j]) = (arr[j], arr[i]);
                }
            }

            (arr[i + 1], arr[right]) = (arr[right], arr[i + 1]);
            return i + 1;
        }

        public void QuickSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivot = Particion(arr, left, right);

                QuickSort(arr, left, pivot - 1);
                QuickSort(arr, pivot + 1, right);
            }
        }
    }
}
