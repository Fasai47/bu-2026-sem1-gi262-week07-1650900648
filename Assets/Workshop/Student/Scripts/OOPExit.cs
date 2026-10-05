using Searching;
using UnityEngine;

namespace Solution
{
    public class OOPExit : Identity
    {
        public Leaderboard leaderboard;
        public string ItemToOpen = "Key";
        public int ItemAmountToOpen = 2;
        
        public override bool Hit()
        {
            bool IsHasItemAmount = mapGenerator.player.inventory.HasItem(ItemToOpen, ItemAmountToOpen);
            if (IsHasItemAmount)
            {
                mapGenerator.player.inventory.UseItem(ItemToOpen, ItemAmountToOpen);
                leaderboard.gameObject.SetActive(true);

                Debug.Log("You win");
                
                // 1. คำนวณคะแนนของผู้เล่น
                int score = CalculateScore();

                // 2. บันทึกคะแนนลงใน Leaderboard
                string playerName = mapGenerator.player.name; // หรือ mapGenerator.player.playerName ตามที่มีในคลาส Player
                leaderboard.RecordScore(new PlayerScore(playerName, score));

                // 3. แสดงผลตาราง Leaderboard บน UI
                leaderboard.ShowleaderBoard();
    
                return true;
            }
            else {
                Debug.Log("Need Item " + ItemToOpen + " to Open");
                return false;
            }
        }

        // Logic CalculateScore
        int CalculateScore() {
            int score = (int)((mapGenerator.player.energy * 100) / Time.time);
            return score;
        }
    }
}