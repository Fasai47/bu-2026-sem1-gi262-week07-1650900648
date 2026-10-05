using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Searching
{
    public class Leaderboard : MonoBehaviour
    {
        private List<PlayerScore> scores = new List<PlayerScore>();
        public GameObject UIScore;
        public Transform UiParent;

        void Awake()
        {
            // Add initial scores in unsorted order
            RecordScore(new PlayerScore("Alice", 100));
            RecordScore(new PlayerScore("Bob", 50));
            RecordScore(new PlayerScore("Charlie", 75));
            RecordScore(new PlayerScore("David", 25));
            RecordScore(new PlayerScore("Eve", 125));
            RecordScore(new PlayerScore("Frank", 150));
            RecordScore(new PlayerScore("Lily", 300));
            RecordScore(new PlayerScore("Grace", 175));
            RecordScore(new PlayerScore("Oscar", 375));
            RecordScore(new PlayerScore("Ivan", 225));
            RecordScore(new PlayerScore("Heidi", 200));
            RecordScore(new PlayerScore("Judy", 250));
            RecordScore(new PlayerScore("Kevin", 275));
            RecordScore(new PlayerScore("Nina", 350));
            RecordScore(new PlayerScore("Mona", 325));
        }

        public void RecordScore(PlayerScore score)
        {
            // [1] Sequential search if the player is already in the list
            int existingIndex = -1;
            for (int i = 0; i < scores.Count; i++)
            {
                // หมายเหตุ: หากในคลาส PlayerScore ใช้ชื่อตัวแปรเป็น playerName ให้เปลี่ยน score.name เป็น score.playerName
                if (scores[i].name == score.name)
                {
                    existingIndex = i;
                    break;
                }
            }

            // หากพบผู้เล่นในตารางอยู่แล้ว ให้ลบข้อมูลเก่าออกเพื่อเตรียมแทรกคะแนนใหม่ในตำแหน่งที่ถูกต้อง
            if (existingIndex != -1)
            {
                scores.RemoveAt(existingIndex);
            }

            // [2] Find index to insert that makes the scores list sorted with binary search (เรียงจากมากไปน้อย - Descending)
            int low = 0;
            int high = scores.Count - 1;
            int insertIndex = scores.Count; // ค่าเริ่มต้นถ้าคะแนนน้อยที่สุด แทรกท้ายสุด

            while (low <= high)
            {
                int mid = low + (high - low) / 2;

                if (scores[mid].score < score.score)
                {
                    insertIndex = mid;
                    high = mid - 1; // ขยับไปหาฝั่งซ้าย (ฝั่งที่คะแนนสูงกว่า)
                }
                else
                {
                    low = mid + 1;  // ขยับไปหาฝั่งขวา (ฝั่งที่คะแนนน้อยกว่า)
                }
            }

            // [3] Insert the score at the appropriate index
            scores.Insert(insertIndex, score);
        }

        public void PrintScores()
        {
            // join all score as string and print it
            string allScores = scores.Aggregate("", (acc, score) => acc + score.score.ToString() + ",");
            Debug.Log(allScores);
        }

        public void ShowleaderBoard()
        {
            foreach (var score in scores)
            {
                UIPlayerScore uIScore = Instantiate(UIScore, UiParent).GetComponent<UIPlayerScore>();
                uIScore.SetUpTextScore(score);
            }
        }
    }
}