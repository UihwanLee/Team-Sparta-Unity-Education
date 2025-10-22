namespace Test3
{
    class Square
    {
        float width;
        float height;

        public Square(float width, float height)
        {
            this.width = width;
            this.height = height;
        }

        public float Area() { return width * height; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Square box = new Square(10, 20);
            Console.WriteLine(box.Area());

            // 기본적으로 class를 객체로 만들때 생성자가 없으며
            // 따라서 width, height가 초기화 되지 않고 있습니다.
            // 접근 지정자 또한 외부에서 호출 할 수 있도록 public으로 설정하고
            // 생성할때 초기화한 width, height 값으로 Area를 구할 수 있습니다.
        }
    }
}
