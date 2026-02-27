using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AssignmentSystem.Services;
using Unity.VisualScripting.YamlDotNet.Core.Tokens;
using UnityEngine;
using Debug = AssignmentSystem.Services.AssignmentDebugConsole;

namespace Assignment03
{
    public class StudentSolution : MonoBehaviour, IAssignment
    {
        #region Lecture

        public void LCT01_SyntaxLinkedList()
        {
           // 1. สร้าง LinkedList ของประเภท string
            LinkedList<string> linkedList = new LinkedList<string>();

            // 2. เพิ่มข้อมูลที่ท้ายของ LinkedList
            linkedList.AddLast("Node 1");
            linkedList.AddLast("Node 2");

            // 3. เพิ่มข้อมูลที่ต้นของ LinkedList
            linkedList.AddFirst("Node 0");

            // 4. แสดงเนื้อหาใน LinkedList
            LCT01_PrintLinkedList(linkedList);

            // 5. เช้าถึงข้อมูลใน LinkedList
            LinkedListNode<string> firstNode = linkedList.First;
            Debug.Log("first", firstNode.Value);
            LinkedListNode<string> lastNode = linkedList.Last;
            Debug.Log("last", lastNode.Value);
            LinkedListNode<string> node1 = linkedList.Find("Node 1");
            Debug.Log(node1.Previous.Value);
            Debug.Log(node1.Next.Value);
            if (firstNode.Previous == null)
            {
                Debug.Log("firstNode.Previous is null");
            }
            if (lastNode.Next == null)
            {
                Debug.Log("lastNode.Next is null");
            }

            // 6. add node ก่อน หรือ หลัง node ที่กำหนด
            linkedList.AddAfter(node1, "Node 1.5");
            linkedList.AddBefore(node1, "Node 0.5");
            LCT01_PrintLinkedList(linkedList);

            // 6. ลบ Node แรก
            linkedList.RemoveFirst();
            LCT01_PrintLinkedList(linkedList);

            // 7. ลบ Node ตามค่าที่กำหนด
            linkedList.Remove("Node 2");
            LCT01_PrintLinkedList(linkedList);
        }

        private void LCT01_PrintLinkedList(LinkedList<string> linkedList)
        {
            Debug.Log("LinkedList...");
            foreach(var node in linkedList)
            {
                Debug.Log(node);
            }
        }

        public void LCT02_SyntaxHashTable()
        {
            
            Hashtable hashtable = new Hashtable();
            //Key Value
            hashtable.Add(1,"Apple");
            hashtable.Add(2,"Banana");
            hashtable.Add("bad-fruit","Rotten Tomato");

            string fruit1 = (string)hashtable[1];
            string fruit2 = (string)hashtable[2];
            string badFruit = (string)hashtable["bad-fruit"];

            Debug.Log($"fruit1: {fruit1}");
            Debug.Log($"fruit2: {fruit2}");
            Debug.Log($"badFruit: {badFruit}");

            LCT02_PrintHashTable(hashtable);

            int key = 2;
            if (hashtable.ContainsKey(key))
            {
                Debug.Log($"found {key}");
            }
            else
            {
                Debug.Log($"not found {key}");
            }

            int keyToRemove = 1;
            hashtable.Remove(keyToRemove);
            LCT02_PrintHashTable(hashtable);
        }
        public void LCT02_PrintHashTable(Hashtable hashtable)
        {
            Debug.Log("table ...");
            foreach(DictionaryEntry entry in hashtable)
            {
                Debug.Log($"Key: {entry.Key}, Value: {entry.Value}");
            }
        }

        public void LCT03_SyntaxDictionary()
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region Assignment

        public void AS01_CountWords(string[] words)
        {
            Dictionary<string, int> wordCount = new Dictionary<string, int>();

            for (int i = 0; i < words.Length; i++)
            {
                if (wordCount.ContainsKey(words[i]))
                {
                    wordCount[words[i]]++;
                }
                else
                {
                    wordCount.Add(words[i], 1);
                }
            }

            foreach (KeyValuePair<string, int> entry in wordCount)
            {
                Debug.Log($"word: '{entry.Key}' count: {entry.Value}");
            }
        }

        public void AS02_CountNumber(int[] numbers)
        {
            Dictionary<int, int> numCount = new Dictionary<int, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numCount.ContainsKey(numbers[i]))
                {
                    numCount[numbers[i]]++;
                }
                else
                {
                    numCount.Add(numbers[i], 1);
                }
            }

            foreach (KeyValuePair<int, int> entry in numCount)
            {
                Debug.Log($"number: {entry.Key} count: {entry.Value}");
            }
        }

        public void AS03_CheckValidBrackets(string input)
        {
            Dictionary<char, char> bracketMap = new Dictionary<char, char>() {{ '(', ')' },{ '[', ']' },{ '{', '}' }};
            LinkedList<char> stack = new LinkedList<char>();

            foreach (char c in input)
            {
                if (bracketMap.ContainsKey(c)) 
                {
                    stack.AddLast(c);
                }
                else if (bracketMap.ContainsValue(c)) 
                {
                    if (stack.Count == 0 || bracketMap[stack.Last.Value] != c)
                    {
                        Debug.Log("Invalid");
                        return;
                    }
                    stack.RemoveLast();
                }
            }

            if (stack.Count == 0)
            {
                Debug.Log("Valid");
            }
            else
            {
                Debug.Log("Invalid");
            }
        }

        public void AS04_PrintReverseLinkedList(LinkedList<int> list)
        {
            if (list == null || list.Count == 0)
            {
                Debug.Log("List is empty");
            }

            LinkedListNode<int> current = list.Last;

            while (current != null)
            {
                Debug.Log(current.Value);
                current = current.Previous;
            }
        }

        public void AS05_FindMiddleElement(LinkedList<string> list)
        {
            if (list == null || list.Count == 0)
            {
                Debug.Log("List is empty");
                return;
            }

            LinkedListNode<string> slow = list.First;
            LinkedListNode<string> fast = list.First;

            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }

            Debug.Log(slow.Value);
        }

        public void AS06_MergeDictionaries(Dictionary<string, int> dict1, Dictionary<string, int> dict2)
        {
            Dictionary<string, int> mergedDict = new Dictionary<string, int>(dict1);

            foreach (KeyValuePair<string, int> entry in dict2)
            {
                if (mergedDict.ContainsKey(entry.Key))
                    mergedDict[entry.Key] += entry.Value;
                else
                    mergedDict.Add(entry.Key, entry.Value);
            }

            foreach (KeyValuePair<string, int> entry in mergedDict)
            {
                Debug.Log($"key: {entry.Key}, value: {entry.Value}");
            }
        }

        public void AS07_RemoveDuplicatesFromLinkedList(LinkedList<int> list)
        {
            if (list == null || list.Count <= 1)
            {
                if (list != null && list.Count == 1)
                    Debug.Log(list.First.Value);
                return;
            }

            Dictionary<int, bool> seen = new Dictionary<int, bool>();
            LinkedListNode<int> current = list.First;

            while (current != null)
            {
                LinkedListNode<int> next = current.Next;
                if (seen.ContainsKey(current.Value))
                {
                    list.Remove(current);
                }
                else
                {
                    seen.Add(current.Value, true);
                }
                current = next;
            }

            foreach (int entry in list)
            {
                Debug.Log(entry);
            }
        }

        public void AS08_TopFrequentNumber(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                Debug.Log("Input array is empty");
                return;
            }

            Dictionary<int, int> counts = new Dictionary<int, int>();
            int topNumber = numbers[0];
            int maxCount = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                int num = numbers[i];
                if (counts.ContainsKey(num))
                {
                    counts[num]++;
                }
                else
                {
                    counts.Add(num, 1);
                }

                if (counts[num] > maxCount)
                {
                    maxCount = counts[num];
                    topNumber = num;
                }
            }

            Debug.Log($"{topNumber} count: {maxCount}");
        }

        public void AS09_PlayerInventory(Dictionary<string, int> inventory, string itemName, int quantity)
        {
            if (inventory == null)
            {
                Debug.Log("Inventory is null");
                return;
            }

            if (inventory.ContainsKey(itemName))
            {
                inventory[itemName] += quantity;
            }
            else
            {
                inventory.Add(itemName, quantity);
            }

            foreach (KeyValuePair<string, int> entry in inventory)
            {
                Debug.Log($"{entry.Key}: {entry.Value}");
            }
        }

        #endregion

        #region Extra

        public void EX01_GameEventQueue(LinkedList<GameEvent> eventQueue)
        {
            throw new System.NotImplementedException();
        }

        public void EX02_PlayerStatsTracker(Dictionary<string, int> playerStats, string statName, int value)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
