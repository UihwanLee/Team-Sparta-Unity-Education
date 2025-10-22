using System.Security.Cryptography.X509Certificates;

namespace Test8
{
    public class Graph
    {
        public int V;  // 정점 개수
        public List<int>[] nodeList; // 리스트의 배열

        public Graph(int v)
        {
            V = v;
            nodeList = new List<int>[v]; // 정점 개수만큼 배열 길이 지정

            for(int i=0; i<v; i++)
            {
                nodeList[i] = new List<int>(); // 정점 개수만큼 리스트 생성
            }
        }

        // 노드 추가
        public void AddNode(int v, int d)
        {
            nodeList[v].Add(d);
        }

        // 깊이 우선 탐색 : 정점에서 리스트에 깊이만큼 방문하고 다 방문하면 다음 옆 노드부터 확인
        public void DFS(int v)
        {
            // 방문한 정점은 true체크할 배열 생성
            bool[] visited = new bool[V];
            DFSUtil(v, visited);
        }

        public void DFSUtil(int v, bool[] visited)
        {
            // 정점 방문 -> 방문하면 true로 표시
            visited[v] = true;
            Console.Write(v + " ");

            // 이 정점에 저장되어 있는 노드들을 돌면서 깊이만큼 체크
            foreach(int n  in nodeList[v])
            {
                if (!visited[n])
                {
                    DFSUtil(n, visited);
                }
            }
        }

        public void BFS(int v)
        {
            // 너비 우선 탐색 
            bool[] visited = new bool[V];
            Queue<int> queue = new Queue<int>();

            // V부터 시작해서 V와 연결된 노드들을 탐색 -> V 너비 만큼 탐색 후 출력
            // 출력 순서 -> V [ 0, 1, 2, 3 ] -> 0 -> 1 -> 2 -> 3
            visited[v] = true;
            queue.Enqueue(v);

            while (queue.Count > 0)
            {
                int m = queue.Dequeue();
                Console.Write(m + " ");

                // V에 들어있는 노드 출력
                foreach (int n in nodeList[m])
                {
                    if (!visited[n])
                    {
                        visited[n] = true;
                        queue.Enqueue(n);
                    }
                }
            }
        }
    }


    internal class Program
    {
        /*
         * 그림과 같은 트리가 있습니다.
            이 트리를
            깊이우선탐색(DFS, Depth-First Search)으로 검색했을 때의 방문하는 순서와
            너비우선탐색(BFS, Breadth-First Search)으로 검색했을 때 방문하는 순서를 적어주세요.
        */


        static void Main(string[] args)
        {
            // 1, 2, 3, 4, 5, 6, 7, 8, 9

            Graph graph = new Graph(10);

            graph.AddNode(0, 1);
            graph.AddNode(1, 2);
            graph.AddNode(1, 3);
            graph.AddNode(1, 4);
            graph.AddNode(1, 5);
            graph.AddNode(3, 6);
            graph.AddNode(3, 7);
            graph.AddNode(4, 8);

            // DFS 출력 예상 값
            // 1, 2, 3, 6, 9, 7, 4, 8, 5

            // BFS 출력 예상 값
            // 1, 2, 3, 4, 5, 6, 7, 8, 9


            graph.DFS(0);
            Console.WriteLine();
            graph.BFS(0);
        }
    }
}
