using System;
using System.Collections.Generic;

namespace Assignment
{
    public class StudentSolution : IAssignment
    {
        #region Lecture

        public int LCT01_SequentialSearch1DArray()
        {
            int[] array = new int[] { 34, 21, 56, 12, 78, 90, 11, 23 };
            int target = 90;
            int index = -1;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == target)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        public int[] LCT02_SequentialSearch2DArray()
        {
            int[,] array = new int[,]
            {
                { 34, 21, 56 },
                { 12, 78, 90 },
                { 11, 23, 45 }
            };
            int target = 23;
            int row = -1;
            int col = -1;

            for (int r = 0; r < array.GetLength(0); r++)
            {
                for (int c = 0; c < array.GetLength(1); c++)
                {
                    if (array[r, c] == target)
                    {
                        row = r;
                        col = c;
                        break;
                    }
                }
                if (row != -1) break;
            }

            return new[] { row, col };
        }

        public int LCT03_BinarySearch()
        {
            int[] array = new int[] { 11, 12, 21, 23, 34, 45, 56, 78, 90 };
            int target = 23;
            int index = -1;

            int low = 0;
            int high = array.Length - 1;

            while (low <= high)
            {
                int mid = low + (high - low) / 2;

                if (array[mid] == target)
                {
                    index = mid;
                    break;
                }
                else if (array[mid] < target)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            return index;
        }

        #endregion

        #region Assignment

        public int[] AS01_FindFirstAndLastElementOfArray(int[] array, int target)
        {
            if (array == null || array.Length == 0) return new int[] { -1 };

            int first = -1;
            int last = -1;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == target)
                {
                    if (first == -1)
                    {
                        first = i;
                    }
                    last = i;
                }
            }

            // ถ้าไม่พบ target คืนค่า new int[] { -1 } ตรงตามตัวอย่างใน XML Doc
            if (first == -1) return new int[] { -1 };

            return new int[] { first, last };
        }

        public int AS02_FindMaxLessThan(int[] array, int target)
        {
            if (array == null || array.Length == 0) return -1;

            int maxVal = int.MinValue;
            bool found = false;

            foreach (int num in array)
            {
                if (num < target && num > maxVal)
                {
                    maxVal = num;
                    found = true;
                }
            }

            return found ? maxVal : -1;
        }

        public int[] AS03_FindRange(int[] array, int min, int max)
        {
            if (array == null || array.Length == 0) return new int[0];

            List<int> result = new List<int>();

            foreach (int num in array)
            {
                if (num >= min && num <= max)
                {
                    result.Add(num);
                }
            }

            // คืนค่า Array ของตัวเลขที่อยู่ในช่วง หากไม่มีจะคืน Array ว่าง (ขนาด 0)
            return result.ToArray();
        }

        #endregion

        #region Extra

        public int[] EX01_FindTargetEnemies(int[] enemyHPs, int mana)
        {
            if (enemyHPs == null || enemyHPs.Length == 0) return new int[0];

            // เรียงลำดับ HP จากน้อยไปมาก เพื่อเลือกทำลายศัตรูตัวที่ใช้ Mana น้อยที่สุดก่อน (Greedy Algorithm)
            // ทำให้ได้จำนวนศัตรูที่ถูกกำจัดมากที่สุด
            int[] sortedHPs = (int[])enemyHPs.Clone();
            Array.Sort(sortedHPs);

            List<int> targetEnemies = new List<int>();
            int currentMana = mana;

            foreach (int hp in sortedHPs)
            {
                if (hp <= currentMana)
                {
                    targetEnemies.Add(hp);
                    currentMana -= hp;
                }
            }

            return targetEnemies.ToArray();
        }

        #endregion
    }
}