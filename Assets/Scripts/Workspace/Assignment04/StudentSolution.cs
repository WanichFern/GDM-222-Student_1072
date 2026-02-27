using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AssignmentSystem.Services;
using UnityEngine;
using Debug = AssignmentSystem.Services.AssignmentDebugConsole;
using System;

namespace Assignment05
{
    public class StudentSolution : MonoBehaviour, IAssignment
    {
        #region Lecture
        public void LCT01_SelectionSortAscending(int[] numbers)
        {
            throw new System.NotImplementedException();
        }

        public void LCT02_BubbleSortAscending(int[] numbers)
        {
            throw new System.NotImplementedException();
        }

        public void LCT03_InsertionSortAscending(int[] numbers)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region Assignment

        public void AS01_SelectionSortDescending(int[] numbers)
        {
            int n = numbers.Length;

            for (int i = 0; i < n - 1; i++)
            {
                int maxIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (numbers[j] > numbers[maxIndex])
                    {
                        maxIndex = j;
                    }
                }
                int temp = numbers[maxIndex];
                numbers[maxIndex] = numbers[i];
                numbers[i] = temp;
            }

            for (int i = 0; i < n; i++)
            {
                Debug.Log(numbers[i]); 
            }
        }

        public void AS02_BubbleSortDescending(int[] numbers)
        {
            int n = numbers.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (numbers[j] < numbers[j+1])
                    {
                        int temp = numbers[j];
                        numbers[j] = numbers[j+1];
                        numbers[j+1] = temp;
                    }
                }
            }
            for (int i = 0; i < n; i++)
            {
                Debug.Log(numbers[i]);
            }
        }

        public void AS03_InsertionSortDescending(int[] numbers)
        {
            int n = numbers.Length;
            for (int i = 1; i < n; i++)
            {
                int key = numbers[i];
                int j = i - 1;
                while (j >= 0 && numbers[j] < key)
                {
                    numbers[j + 1] = numbers[j];
                    j = j - 1;
                }
                numbers[j + 1] = key;
            }
            for (int i = 0; i < n; i++)
            {
                Debug.Log(numbers[i]);
            }
        }

        public void AS04_FindTheSecondLargestNumber(int[] numbers)
        {
            Array.Sort(numbers);
            Array.Reverse(numbers);
            int max = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] < max)
                {
                    Debug.Log(numbers[i]);
                    return;
                }
            }
        }

        #endregion

        #region Extra

        public void EX01_FindLongestConsecutiveSequence(int[] numbers)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
