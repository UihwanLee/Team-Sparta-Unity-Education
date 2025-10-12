

[Text-RPG] 프로그램

[기능 구현]
- 필수 과제 구현

5. Player 스탯 추가하기
5-1. 랜덤 모험
5-2. 마을 순찰하기
5-3. 훈련하기
6. 인벤토리 크기 맞춤			
7. 장착 개선					
8. 인벤토리 정렬하기
9. 상점 - 아이템 구매
9-1. 상점 - 아이템 판매
10. 던전입장
11. 휴식 기능
12. 레벨업 기능
13. 게임 저장하기

[추가 기능]
- 각 Scene마다 Map을 추가하였습니다.

[프로그램 구조]

이 Text-RPG 프로그램은 Unity의 구조를 참고하여, 모든 게임 오브젝트가 Start()와 Update(float elapsed) 메서드를 가지고 있습니다. 
게임 시작 시 Start()를 호출하고, 매 프레임마다 Update(elapsed)를 호출하여 각 오브젝트를 갱신하는 방식으로 동작합니다.

1. GameManager
- 각 Scene을 관리하며 Scene끼리 공유할 객체 (Player 정보나 Shop 같은 Scene끼리 공유해야할 객체)를 가지고 있습니다.
- LoadScene()을 통하여 Dictonary 구조로 Scene 이름이나 인덱스로 Scene을 로드합니다.

2. Scene
- 메인화면과 모험, 순찰, 인벤토리 등 모든 화면은 Scene 객체로 관리되고 각각의 고유한 Scene은 기본 Scene을 상속하고 있습니다.
- GameMain에서 Scene 객체를 생성하고 currentScene을 통해 각 Scene에 진입 시 init(), start(), update()를 수행합니다.
- 각 Scene은 View라는 별도 UI창을 가지고 있으며 델리게이트 Action을 이용하여 UI를 변환하고 있습니다.

3. UIManager
- Scene에서 각 View마다 보여줄 UI는 UIManager에서 관리합니다.

4. TimeManager
- update(float elapsed)를 이용하여 다양한 상호작용을 하기 위해 elapsed, deltaTime, localElapsed 등 따로 관리하는 클래스를 만들었습니다.
- localElapsed를 이용하여 게임 전체 누적 시간이 아닌 Scene에 들어오고 나서 경과 시간을 통해 event duration을 지정하여 사용하였습니다.

5. SaveManager
- SaveData 클래스에 모든 정보를 저장하고 있으며 JSON 형태로 관리합니다.
- Save 파일 대상은 공유 객체인 Player, Shop 입니다.
- List<Item>에 들어가 있는 Item, Weapon, Armor 클래스를 구별하기 위해 JsonDerivedType을 이용하였습니다.

6. Player - Inventory - Item 구조
- Player 객체 내 Inventory를 가지고 있으며 Inveontory는 List<Item>을 통해 아이템을 관리합니다.

7. Item
- Item을 상속하는 Weapon, Armor 클래스를 만들었으며 override를 통해 각 다른 기능을 구현하도록 설계하였습니다.
- ItemDatabase를 통해 원조 Item 객체를 관리하며 Clone()을 통해 복제하여 아이템을 생성하도록 설계하였습니다.
- ItemSorter은 Inventory 정렬 시 도움을 주는 클래스입니다.

8. Inventory
- 인벤토리 내에서 아이템 추가/삭제, 아이템 검색(Id), 아이템 착용/해제, 아이템 정렬, 아이템 표시 등을 사용할 수 있습니다.
- 다만 인벤토리 보기와 상점에서 인벤토리 정보를 불러올 때 가격(price) 정보가 달라 Display 인벤토리용, 상점용 2개 만들었습니다.

9. Player
- Player은 Character을 상속하고 직업, 골드, 스태미나, 경험치를 고유한 속성으로 가지고 있습니다.
- Player는 Weapon, Armor를 1개씩 가지고 있으며 장비 장착/해제 시 업데이트 합니다.
- Player 경험치는 set을 이용하여 변할 시 CheckLevelUp() 메서드를 통해 레벨을 관리합니다.

10. Dungeon
- 던전은 3가지 난이도가 있으며, 이를 위해 Dungeon 클래스를 따로 만들어 다양한 기능을 관리하도록 하였습니다.

11. Map
- 각 Scene 상황에 맞는 Map을 제공하며, 조건에 맞는 애니메이션을 연출합니다.
- DrawMap(), DisplayMap()을 오버라이드하며 공통 메서드를 두었습니다.
- 각 Map마다 연출이 다르기 때문에 string[,] map을 사용하거나 SetCursorPosition()을 사용하여 텍스트로 최대한 표현하였습니다.


[코드를 구현하며 아쉬운 점, 어려웠던 점]

1. update 구조
- 우선 게임 구현 시 꼭 start, update 구조로 만들고 싶었습니다. 
시간 개념을 꼭 넣고 싶었기 때문에 update(float elapsed)를 사용하고 싶었고 그 부분은 성공하였습니다.
하지만 Scene을 만들려고 할때 update 안에 Scene 안 View가 계속 호출되는 구조라 Console을 출력할 때 많이 주의해야 했습니다.
Action을 이용하여 ui 만 변경하고 있기 때문에 ui 속 애니메이션을 구현하기 위해서는 메인 루프 안에 넣는게 필수였습니다. 
따라서 hasExecutedList이라는 Dictionary를 만들어 ui 등 한번만 호출해야하는 부분을 따로 관리하였는데 이 구조가 깔끔한 것 같지 않아서 아쉽습니다.

2. Manager 클래스
- 보통 Manager 클래스를 만드려고 할때는 Audio, Time 등 전역 변수 처럼 많은 곳에서 참조하려고 할때 Manager를 붙이는 습관이 있습니다.
그래서 대부분은 싱글톤을 만들어서 상태 관리를 하려고 하는데 TextManager처럼 그냥 출력만 하는 클래스는 굳이 싱글톤 패턴이 의미가 없는거 같아서
staic으로 구현하였습니다. 이 과정에서 싱글톤과 static을 활용을 이렇게 하는게 맞는가? 고민을 많이 하였습니다.

또한 클래스는 한 가지 기능(목적)만 수행하도록 하는 것이 유지 보수, 가독성 면에서 좋고 OOP 개념에서도 중요한 사항이라고 알고 있습니다.
그래서 어디까지 기능을 확장할지에 대한 고민이 많았고, UIManager가 원래 UI 관리, Text 관리, Console 관리에서 TextManager, ConsoleHelper를 추가해
분리하는 작업까지 진행하였습니다. 이렇게 컴포넌트화 시키는 범위를 어떤식으로 진행하면 좋을지 고민이 많습니다.

3. Monster 클래스 구현 실패
- 원래 Character를 상속하는 Player와 Monster 클래스를 만들어 던전 내 몬스터 전투를 구현하지 못해 아쉽습니다.





