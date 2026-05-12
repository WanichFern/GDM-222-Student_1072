using System.Collections;
using System.Collections.Generic;
using System.Text;
using AssignmentSystem.Services;
using UnityEngine;
using Debug = AssignmentSystem.Services.AssignmentDebugConsole;

namespace Assignment01
{
    public class StudentSolution : MonoBehaviour, IAssignment
    {

        #region Lecture

        public void LCT01_SyntaxArray()
        {
            throw new System.NotImplementedException();
        }

        public void LCT02_ArrayInitialize()
        {
            throw new System.NotImplementedException();
        }

        public void LCT03_SyntaxLoop()
        {
            throw new System.NotImplementedException();
        }

        public void LCT04_LoopAndArray(string[] ironManSuitNames)
        {
            throw new System.NotImplementedException();
        }

        public void LCT05_Syntax2DArray()
        {
            throw new System.NotImplementedException();
        }

        public void LCT06_SizeOf2DArray(int[,] my2DArray)
        {
            throw new System.NotImplementedException();
        }

        public void LCT07_SyntaxNestedLoop(int columns, int rows)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region Assignment

        public void AS01_RandomItemDrop(GameObject[] items)
        {
            int randomIndex = Random.Range(0, items.Length);
            GameObject selectedItem = items[randomIndex];

            Instantiate(selectedItem);

            Debug.Log($"Got item: {selectedItem.name}");
        }

        public void AS02_NestedLoopForCreate2DMap(GameObject[] floorTiles, int columns, int rows)
        {
            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    int randomIndex = Random.Range(0, floorTiles.Length);
                    
                    GameObject tile = Instantiate(floorTiles[randomIndex], new Vector2(x, y), Quaternion.identity);
                    
                    tile.name = $"[{x}:{y}]";
                    Debug.Log(tile.name);
                }
            }
        }

        public void AS03_NestedLoopForMakingWallAround(GameObject wall, int columns, int rows)
        {
            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    if (x == 0 || x == columns - 1 || y == 0 || y == rows - 1)
                    {
                        GameObject wallObj = Instantiate(wall, new Vector2(x, y), Quaternion.identity);
                        wallObj.name = $"[{x}:{y}]";
                    }
                }
            }
        }

        public void AS04_AttackEnemy(int[] enemyHP, int damage, int target)
        {
            enemyHP[0] = Mathf.Max(0, enemyHP[0] - damage);
            enemyHP[enemyHP.Length - 1] = Mathf.Max(0, enemyHP[enemyHP.Length - 1] - damage);
            
            if (target >= 0 && target < enemyHP.Length)
            {
                enemyHP[target] = Mathf.Max(0, enemyHP[target] - damage);
            }

            Debug.Log($"FirstEnemy hp :{enemyHP[0]}");
            Debug.Log($"LastEnemy hp :{enemyHP[enemyHP.Length - 1]}");
            Debug.Log($"TargetEnemy {target} hp :{enemyHP[target]}");
        }

        public void AS05_DynamicIterationLoop(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Debug.Log(i);
            }
        }

        public void AS06_WhileLoopAndArray(string[] ironManSuitNames)
        {
            int i = 0;
            while (i < ironManSuitNames.Length)
            {
                Debug.Log(ironManSuitNames[i]);
                i++;
            }

            Debug.Log("===");

            int j = 0;
            while (j < ironManSuitNames.Length)
            {
                Debug.Log(ironManSuitNames[j]);
                j += 2;
            }
        }

        public void AS07_HealTargetAtIndex(int[] heroHPs, int heal, int targetIndex)
        {
            heroHPs[0] += heal;
            heroHPs[heroHPs.Length - 1] += heal;
            
            if (targetIndex >= 0 && targetIndex < heroHPs.Length)
            {
                heroHPs[targetIndex] += heal;
            }

            Debug.Log($"FirstHero hp :{heroHPs[0]}");
            Debug.Log($"LastHero hp :{heroHPs[heroHPs.Length - 1]}");
            Debug.Log($"TargetHero {targetIndex} hp :{heroHPs[targetIndex]}");
        }

        public void AS08_RandomPickingDialogue(string[] dialogues)
        {
            if (dialogues.Length > 0)
            {
                int randomIndex = UnityEngine.Random.Range(0, dialogues.Length);
                Debug.Log(dialogues[randomIndex]);
            }
        }

        public void AS09_MultiplicationTable(int n)
        {
            for (int i = 1; i <= 12; i++)
            {
                Debug.Log($"{n}x{i}={n * i}");
            }
        }

        public void AS10_FindSummationFromZeroToNUsingWhileLoop(int n)
        {
            int sum = 0;
            int i = 0;

            while (i <= n)
            {
                sum += i;
                i++;
            }

            Debug.Log($"ผลรวมของ n จาก 0 ถึง {n} คือ {sum}");
        }

        public void AS11_SpawnEnemies(int[] enemyHPs, GameObject enemyPrefab)
        {
            for (int i = 0; i < enemyHPs.Length; i++)
            {
                float xPos = i + 1;
                Vector2 spawnPosition = new Vector2(xPos, 0);

                Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

                Debug.Log($"new enemy at position x = {xPos}");
            }
        }

        public IEnumerator AS12_CountTime(float CountTime)
        {
            float timer = 0f;
            if (CountTime <= 0)
            {
                Debug.Log("End timer : 0");
                yield break;
            }

            while (timer < CountTime)
            {
                timer += Time.deltaTime;

                if (timer > CountTime)
                {
                    timer = CountTime;
                }

                Debug.Log($"timer : {timer.ToString("F2")}");

                yield return null;
            }
            Debug.Log($"End timer : {CountTime}");
        }

        public void AS13_SumOfNumbersInRow(int[,] matrix, int row)
        {
            int sum = 0;
            int columnsCount = matrix.GetLength(1);

            for (int col = 0; col < columnsCount; col++)
            {
                sum += matrix[row, col];
            }

            Debug.Log(sum);
        }

        public void AS14_SumOfNumbersInColumn(int[,] matrix, int column)
        {
            int sum = 0;
            int rowsCount = matrix.GetLength(0);

            for (int row = 0; row < rowsCount; row++)
            {
                sum += matrix[row, column];
            }

            Debug.Log(sum);
        }

        public void AS15_MakeTheTriangle(int size)
        {
            for (int i = 1; i <= size; i++)
            {
                string rowText = "";
                for (int j = 1; j <= i; j++)
                {
                    rowText += "*";
                }
                Debug.Log(rowText);
            }
        }

        public void AS16_MultiplicationTableOf_2_3_and_4()
        {
            for (int i = 1; i <= 12; i++)
            {
                string line = $"2 x {i} = {2 * i}\t" + 
                            $"3 x {i} = {3 * i}\t" + 
                            $"4 x {i} = {4 * i}";
                
                Debug.Log(line);
            }
        }

        #endregion

        #region Extra assignment

        public void EX_01_TicTacToeGame_TurnPlay(string[,] board, string playerTurn, int row, int column)
        {
            if (row < 0 || row > 2 || column < 0 || column > 2 || board[row, column] != " ")
            {
                PrintBoard(board);
                Debug.Log(">> Invalid move");
                return;
            }

            board[row, column] = playerTurn;
            PrintBoard(board);

            bool isWin = false;
            for (int i = 0; i < 3; i++)
                if (board[i, 0] == playerTurn && board[i, 1] == playerTurn && board[i, 2] == playerTurn) isWin = true;
            for (int i = 0; i < 3; i++)
                if (board[0, i] == playerTurn && board[1, i] == playerTurn && board[2, i] == playerTurn) isWin = true;

            if (board[0, 0] == playerTurn && board[1, 1] == playerTurn && board[2, 2] == playerTurn) isWin = true;
            if (board[0, 2] == playerTurn && board[1, 1] == playerTurn && board[2, 0] == playerTurn) isWin = true;

            if (isWin)
            {
                Debug.Log($">> {playerTurn} wins!");
                return;
            }

            bool isFull = true;
            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                {
                    if (board[r, c] == " ")
                    {
                        isFull = false;
                        break;
                    }
                }
            }

            if (isFull) Debug.Log(">> Draw");
            else Debug.Log(">> Continue");
        }

        private void PrintBoard(string[,] board)
        {
            StringBuilder sb = new();
            for (int i = 0; i < 3; i++)
            {
                sb.AppendLine("-------------");
                sb.AppendLine("| " + board[i, 0] + " | " + board[i, 1] + " | " + board[i, 2] + " |");
            }
            sb.AppendLine("-------------");
            Debug.Log(sb.ToString());
        }
        #endregion
    }

}
