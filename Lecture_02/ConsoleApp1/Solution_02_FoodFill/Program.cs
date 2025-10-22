using System.Drawing;
using static System.Net.Mime.MediaTypeNames;

namespace Solution_02_FloodFill
{
    public class Program
    {
        public static int[][] FloodFill(int[][] image, int sr, int sc, int color)
        {
            int originalColor = image[sr][sc];
            if (originalColor == color)
                return image; // 이미 같은 색이면 바로 반환

            Fill(image, sr, sc, originalColor, color);
            return image;
        }

        private static void Fill(int[][] image, int r, int c, int original, int newColor)
        {
            // 범위 체크
            if (r < 0 || r >= image.Length || c < 0 || c >= image[0].Length)
                return;

            // 색이 다르면 종료
            if (image[r][c] != original)
                return;

            // 색 변경
            image[r][c] = newColor;

            // 상하좌우로 탐색
            Fill(image, r + 1, c, original, newColor);
            Fill(image, r - 1, c, original, newColor);
            Fill(image, r, c + 1, original, newColor);
            Fill(image, r, c - 1, original, newColor);
        }

        static void Main(string[] args)
        {
            int[][] images = [[1, 1, 1], [1, 1, 0], [1, 0, 1]];
            int sr = 1, sc = 1, color = 2;

            images = FloodFill(images, sr, sc, color);

            foreach(var image in images)
            {
                foreach(var c in image)
                {
                    Console.Write($"{c} ");
                }
                Console.WriteLine();
            }
        }
    }
}
