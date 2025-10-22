namespace Solution_01_Largest_Rectangle_in_Histogram
{
    public class Program
    {
        static int LargeRectangleArea(List<int> heights)
        {
            Stack<int> s = new Stack<int>();
            int maxArea = 0;

            for(int i = 0; i <= heights.Count; i++)
            {
                int h = (i==heights.Count) ? 0 : heights[i];
                if(s.Count == 0 || h > heights[s.Peek()])
                {
                    // stack에는 항상 이전보다 큰 막대의 인덱스(i)가 들어감
                    s.Push(i);
                }
                else
                {
                    // 이전 막대보다 낮으면 직사각형 완성이므로 Pop해서 크기 비교
                    int top = s.Peek();
                    s.Pop();

                    // 현재 막대에서 마지막 막대까지의 가로 길이 계산
                    int width = (s.Count == 0) ? i : i - 1 - s.Peek();
                    int area = heights[top] * width;
                    maxArea = Math.Max(maxArea, area);

                    // Pop 하였으니 다시 낮은 막대부터 계산
                    i--;
                }
            }

            return maxArea;
        }

        static void Main(string[] args)
        {
            List<int> heights = new List<int>() { 2, 1, 5, 6, 3 };

            int maxArea = LargeRectangleArea(heights);

            Console.WriteLine(maxArea);
        }
    }
}
