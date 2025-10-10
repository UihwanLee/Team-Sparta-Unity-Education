using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG
{
    public static class TextManager
    {
        /*
          * TextManager 스크립트
          * 
          * 게임에 나오는 Text를 관리하는 스크립트이다.
          * 단순 string 값을 출력, 입력하는 형태라 static으로 관리
          * 
          */

        // 오류 메세지
        public static string MessageError = "잘못된 입력입니다";

        // Text 관리 : 공통
        public static string NoStamina = "스태미나가 부족합니다.";
        public static string NoGold = "골드가 부족합니다.";
        public static string UseStamin(int stamina) { return $"스태미나 {stamina} 소모되었습니다."; }
        public static string NothingHappen = "아무 일도 일어나지 않았다";
        public static string Entering = "입장중...";

        public static string ERROR_INDEX = "인덱스 에러";

        public static string LevelUp = "레벨이 상승했습니다!";

        public static string GainGold(int gold) { return (gold >= 0) ? $"{gold}G 흭득" : $"{gold}G 소모"; }
        public static string GainExp(int exp) { return $"{exp}exp 흭득"; }


        // Text 관리 : 모험
        public static string MatchMonster = "몬스터 조우!";

        // Text 관리 : 마을 순찰
        public static string PatrolTown_FindChild = "마을 아이들이 모여있다. 간식을 사줘볼까?";
        public static string PatrolTown_FindHeadMan = "촌장님을 만나서 심부름을 했다.";
        public static string PatrolTown_LostMan = "길 읽은 사람을 안내해주었다.";
        public static string PatrolTown_FindPeople = "마을 주민과 인사를 나눴다. 선물을 받았다.";

        // Text 관리 : 훈련
        public static string Training_GreatSuccess = "훈련이 잘 되었습니다!";
        public static string Training_Success = "오늘하루 열심히 훈련했습니다.";
        public static string Training_Fail = "하기 싫다... 훈련이...";

        // Text 관리 : 상점
        public static string Shop_Already_Purchase = "이미 구매한 아이템입니다.";
        public static string Shop_Success_Purchase = "구매를 완료했습니다.";
        public static string Not_Enough_Gold = "Gold가 부족합니다.";

        public static string Shop_Success_Sale(Item item) { return $"{item.name} 판매 완료. {item.price}G 흭득!"; }

        // Text 관리 : 던전
        public static string Dugeon_Not_Enough_Hp = "체력이 부족합니다!";

        // Text 관리 : 휴식
        public static string Restore_Hp(int hp) { return $"체력이 {hp} 회복했습니다."; }
        public static string Restore_Stamina(int stamina) { return $"스태미나가 {stamina} 회복했습니다."; }
    }
}
