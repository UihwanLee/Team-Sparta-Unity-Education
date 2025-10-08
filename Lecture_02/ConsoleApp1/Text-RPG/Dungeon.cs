using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG
{
    public class Dungeon
    {
        /*
         * Dungeon: 던전 스크립트
         * 
         * [던전 속성]
         * - 난이도
         * - 몬스터 리스트
         * 
         */

        private string name;            // 던전 이름
        private int level;              // 던전 레벨
        public float duration { get; }  // 던전 탐험 시간

        private float recommended_def;    // 권장 방어력

        private int loseHpMin = 20;     // 소모 체력 (Min)
        private int loseHpMax = 35;     // 소모 체력 (Max)
        private int lose_hp;            // 소모 체력

        private int reward_gold;        // 보상 - 골드
        private int reward_exp;         // 보상 - 경험치

        public Dungeon(string name, int level, float recommended_def, float duration, int reward_gold, int reward_exp) 
        {
            this.name = name;
            this.level = level;
            this.recommended_def = recommended_def;

            this.duration = duration;

            this.reward_gold = reward_gold;
            this.reward_exp = reward_exp;

            InitDungeon();
        }

        // Dungeon 초기화: Player 소모 체력 결정, Player 공격력에 따른 추가 보상
        private void InitDungeon()
        {
            Player player = GameManager.Instance.GetPlayer();
            Random random = new Random();

            // 기본 체력 소모: 20 ~ 35까지 랜덤 값
            this.lose_hp = random.Next(loseHpMin, loseHpMax + 1);

            // 소모 체력 차감: 내 방어력 - 권장 방어력 
            int benefit = (player.Def < recommended_def) ? 0 : (int)(player.Def - recommended_def);

            // 최종 소모 체력: 기본 체력 소모 - 소모 체력 차감 값
            this.lose_hp = (benefit > this.lose_hp) ? 0 : this.lose_hp - benefit;

            // Player 공격력에 따른 추가 보상
            float benefit_reward = (float)(random.Next((int)player.Atk, (int)((player.Atk*2)+1))/100);
            this.reward_gold += (int)(this.reward_gold* benefit_reward);
            this.reward_exp += (int)(this.reward_exp * benefit_reward);
        }

        // 던전 입장 시도
        public bool TryEnter()
        {
            Player player = GameManager.Instance.GetPlayer();

            // 던전에 입장 할 체력이 충분한지 체크
            if(player.Hp <= lose_hp)
            {
                Console.WriteLine(UIManager.Instance.Dugeon_Not_Enough_Hp);
                return false;
            }

            return true;
        }

        // 던전 클리어
        public void Clear(Player player)
        {
            // 던전 클리어 시 Player 체력 소모
            player.Hp -= lose_hp;

            // 던전 클리어 보상 흭득 : 골드, 경험치
            player.Gold += reward_gold;
            player.Exp += reward_exp;
        }

        // 프로퍼티
        public string Name { get { return name; } }
        public float RecommendedDef { get { return recommended_def; } }
        public int GetLoseHp() { return this.lose_hp; }
        public int GetRewardGold() { return this.reward_gold; }
        public int GetRewardExp() { return this.reward_exp; }

    }
}
