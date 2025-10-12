

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
- update(float elapsed)를 통해 다양한 상호작용을 하고 위해 elapsed, deltaTime, localElapsed 등 따로 관리하는 클래스를 만들었습니다.
- localElapsed를 이용하여 duration 동안 이벤트를 수행하고 시간 차로 Text를 출력하는 애니메이션을 연출하였습니다.

5. SaveManager
- SaveData 클래스에 모든 정보를 저장하고 있으며 JSON 형태로 관리합니다.

6. Player - Inventory - Item 구조
- Player 객체 내 Inventory를 가지고 있으며 Inveontory는 List<Item>을 통해 아이템을 관리합니다.

7. Item
- Item을 상속하는 Weapon, Armor 클래스를 만들었으며 override를 통해 각 다른 기능을 구현하도록 설계하였습니다.
- ItemDatabase를 통해 원조 Item 객체를 관리하며 Clone()을 통해 복제하여 아이템을 생성하도록 설계하였습니다.
- ItemSorter은 Inventory 정렬 시 도움을 주는 클래스입니다.

8. Dungeon
- 던전은 3가지 난이도가 있으며, 이를 위해 Dungeon 클래스를 따로 만들어 다양한 기능을 관리하도록 하였습니다.

9. Map
- 각 Scene 상황에 맞는 Map을 제공하며, 조건에 맞는 애니메이션을 연출합니다.
- DrawMap(), DisplayMap()을 오버라이드하며 공통 메서드를 두었습니다.
- 각 Map마다 연출이 다르기 때문에 string[,] map을 사용하거나 SetCursorPosition()을 사용하여 텍스트로 최대한 표현하였습니다.



