using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;

namespace Text_RPG
{
    [Serializable]
    public class SaveData
    {
        /*
         * [저장 데이터]
         * Player 정보
         * Shop 정보
         */

        // Player 정보
        public int playerLevel;         // Player 레벨
        public string playerName;       // Player 이름
        public float playerAtk;         // Player 공격력 (Origin)
        public float playerDef;         // PLayer 방어력 (Origin)
        public int playerHp;            // Player 체력
        public string playerJob;        // Player 직업
        public int playerGold;          // Player 골드
        public int playerStamina;       // Player 스태미나
        public int playerExp;           // Player 경험치

        public List<Item> playerItems;  // Player 아이템

        public Weapon playerWeapon;     // Player 장착 무기
        public Armor playerArmor;       // Player 장착 방어구

        // Shop 정보
        public List<Item> shopProductList;  // Shop 상품 리스트
    }

    public static class SaveManager
    {
        /*
          * SaveManager 스크립트
          * 
          * 게임을 저장하는 기능을 가지고 있다.
          * 
          * SaveData 클래스를 저장하고 로드하는 기능을 가지고 있다.
          * 
          */

        // SaveData
        private static SaveData saveData = new SaveData();

        // SaveData 경로 설정
        private static string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "SaveData");
        private static string saveDataPath = Path.Combine(folderPath, "SaveData.json"); 

        // Json을 이용하여 객체 정보 저장
        public static void Save()
        {
            // 폴더 예외처리
            if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);

            // SaveData 저장
            saveData = GameManager.Instance.GetPlayer().ToSaveData(saveData);
            saveData = GameManager.Instance.GetShop().ToSaveData(saveData);

            // JSON 옵션 지정
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                IncludeFields = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.Never,  
            };

            // JSON 직렬화
            string json = JsonSerializer.Serialize(saveData, options);
            File.WriteAllText(saveDataPath, json);

            Console.WriteLine($"저장 완료: {saveDataPath}");
        }

        // 저장된 Json 파일을 이용하여 로드
        public static void Load()
        {
            if(!File.Exists(saveDataPath))
            {
                Console.WriteLine("[ERROR] 저장 파일이 없습니다.");
                return;
            }

            // JSON 옵션 지정
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                IncludeFields = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.Never,
            };

            // JSON 역직렬화
            string json = File.ReadAllText(saveDataPath);
            SaveData saveData = JsonSerializer.Deserialize<SaveData>(json, options);

            GameManager.Instance.GetPlayer().LoadFromSaveData(saveData);
            GameManager.Instance.GetShop().LoadFromSaveData(saveData);

            Console.WriteLine($"로드 완료: {saveDataPath}");
        }

        // 현재 SaveData가 존재하는지 반환
        public static bool SaveFileExists()
        {
            return File.Exists(saveDataPath);
        }
    }
}
