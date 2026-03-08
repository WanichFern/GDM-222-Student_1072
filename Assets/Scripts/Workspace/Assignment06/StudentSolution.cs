using System;
using System.Collections.Generic;
using Debug = AssignmentSystem.Services.AssignmentDebugConsole;

namespace Assignment06
{
    public class StudentSolution : IAssignment
    {
        #region Lecture

        public void LCT01_SequentialSearch1DArray()
        {
            int[] array = new int[] { 34, 21, 56, 12, 78, 90, 11, 23 };
            int target = 90;
            int index = -1;

            // Your code here ...
            // ...


            Debug.Log(index);
        }

        public void LCT02_SequentialSearch2DArray()
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

            // Your code here ...
            // ...

            Debug.Log($"({row}, {col})");
        }

        public void LCT03_BinarySearch()
        {
            int[] array = new int[] { 11, 12, 21, 23, 34, 45, 56, 78, 90 };
            int target = 23;
            int index = -1;

            // Your code here ...
            // ...

            Debug.Log(index);
        }

        #endregion

        #region Assignment

        public void AS01_FindFirstAndLastElementOfArray(int[] array, int target)
        {
            int firstIndex = -1;
            int lastIndex = -1;

            if (array != null)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == target)
                    {
                        if (firstIndex == -1)
                        {
                            firstIndex = i;
                        }
                        lastIndex = i;
                    }
                }
            }

            if (firstIndex == -1)
            { Debug.Log("-1"); }
            else
            {
                Debug.Log(firstIndex);
                Debug.Log(lastIndex);
            }
        }

        public void AS02_FindMaxLessThan(int[] array, int target)
        {
            int result = -1;

            if (array != null && array.Length > 0)
            {
                Array.Sort(array);
                for (int i = array.Length - 1; i >= 0; i--)
                {
                    if (array[i] < target)
                    {
                        result = array[i];
                        break;
                    }
                }
            }

            Debug.Log(result);
        }

        public void AS03_FindRange(int[] array, int min, int max)
        {
            if (array == null || array.Length == 0)
            {
                Debug.Log("Empty");
                return;
            }

            bool found = false;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] >= min && array[i] <= max)
                {
                    Debug.Log(array[i]);
                    found = true;
                }
            }

            if (!found) {Debug.Log("Empty");}
        }

        #endregion

        #region Extra

        public void EX01_FindTargetEnemies(int[] enemyHPs, int mana)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
