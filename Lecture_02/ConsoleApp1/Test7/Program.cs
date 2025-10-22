namespace Test7
{
    internal class Program
    {
        // 다음 코드의 출력 결과를 작성하고, 왜 그렇게 되는지 이유를 설명해주세요.

        public class Unit
        {
            public virtual void Move()
            {
                Console.WriteLine("두발로 걷기");
            }

            public void Attack()
            {
                Console.WriteLine("Unit 공격");
            }
        }

        public class Marine : Unit
        {

        }

        public class Zergling : Unit
        {
            public override void Move()
            {
                Console.WriteLine("네발로 걷기");
            }
        }

        static void Main(string[] args)
        {
            Zergling zerg = new Zergling();
            zerg.Move();
        }

        // 출력 결과: 네발로 걷기
        // Zergling 생성 -> zerg.Move() 호출 : Zergling은 Unit을 상속하고 있음
        // Unit에는 두발로 걷기가 Move에 쓰여 있지만 override 시 다형성 기능으로 인해
        // 상속 받은 자식 클래스에서 해당 메서드를 재정의 할 수 있음
        // override 상속 받은 메서드 재정의, 오버로드 -> 메서드에 파라미터 개수 다르게 하여 호출 다르게 
    }
}
