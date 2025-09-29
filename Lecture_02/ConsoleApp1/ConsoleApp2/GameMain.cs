namespace ConsoleApp2
{
    internal class GameMain 
     {
       
        static void Main(string[] args)
        {
            // 플레이어 추가
            Player player1 = new Player("전사", 100);
            player1.TakeDamage(30);

            // 몬스터 추가
            Monster slime = new Monster("슬라임", 50, 1);
            Monster goblin = new Monster("고블린", 100, 3);

            slime.DisplayInfo();
            goblin.DisplayInfo();

            // 아이템 추가
            Item potion = new Item("HP포션", 50, ItemType.Potion);
            Item sword = new Item("철검", 150, ItemType.Weapon);

            potion.DisplayInfo();
            sword.DisplayInfo();

            sword.price = 200;
            sword.DisplayInfo();

            // 스킬 추가
            Skill fireball = new Skill("파이어볼", 50, 20);
            Skill heal = new Skill("힐", -30, 15);

            fireball.Activate();
            heal.Activate();

            // 상점 추가
            Shop shop = new Shop();
            shop.AddItem(new Item("HP포션", 50, ItemType.Potion)); 
            shop.AddItem(new Item("MP포션", 70, ItemType.Potion)); 
            shop.AddItem(new Item("철검", 150, ItemType.Weapon));

            shop.DisplayItems();

            // 플레이어 상태 변경
            player1.CurrentState = PlayerState.Attack;

            if(player1.CurrentState == PlayerState.Attack)
            {
                Console.WriteLine("플레이어는 공격 중입니다");
            }

            if(potion.Type == ItemType.Potion)
            {
                Console.WriteLine("이 아이템은 포션입니다.");
            }

            // 인터페이스 활용
            IAttackable playerAttack = new Player("아무개", 100);
            playerAttack.Attack(slime);

            List<IAttackable> attackers = new List<IAttackable>();
            attackers.Add(playerAttack);
            attackers.Add(fireball);
            attackers.Add(goblin);

            // IAttackable 구현한 객체들의 모임 Attack 밖에 못함

            // 추상 클래스
            //Character c = new Character("유령", 10);

            Character player = new Player("아무개2", 100);
            Character monster = new Monster("몬스터1", 150, 10);
            player.ShowInfo();
            monster.ShowInfo();
        }
    }
}
