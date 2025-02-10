using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TickTackToe_Game
{

    public class Block_Board : MonoBehaviour
    {
        internal int board_Size;
        private GameObject blockPrefab;
        internal Block[,] blocks;
        private TickTackToe tickTackToe;
        private BlockType currentTurn;
        private bool buttonPressed;

        public void SetUp(GameObject blockPrefab, int board_size, TickTackToe tickTackToe)
        {
            this.blockPrefab = blockPrefab;
            this.board_Size = board_size;
            this.tickTackToe = tickTackToe;
            this.blocks = new Block[board_size, board_size];
            currentTurn = BlockType.X;
            buttonPressed = false;

            int Horizontal_Offset = -4;
            int Vertical_Offset = 4;

            GameObject tempBlock;

            for (int i = 0; i < board_size; i++)
            {
                for (int j = 0; j < board_size; j++)
                {
                    tempBlock = Instantiate(blockPrefab, this.transform);
                    blocks[i, j] = tempBlock.GetComponent<Block>();
                    blocks[i, j].SetUp(this, new Vector2(Horizontal_Offset + Mathf.Abs(Horizontal_Offset * j), Vertical_Offset - Mathf.Abs(Vertical_Offset * i)));
                }
            }

            Board_Scan.SetUp(board_Size);
        }


        public void CheckBoardState()
        {
            //Only has to check for current turn type!
            if (Board_Scan.Horizontal(blocks, currentTurn) == currentTurn || Board_Scan.Vertical(blocks, currentTurn) == currentTurn || Board_Scan.Diagnoal(blocks, currentTurn) == currentTurn)
            {
                //you won
                Debug.Log(currentTurn + " WON!");
            }
            else
            {
                ChangeCurrentTurn();
            }
        }

        public bool AttemptButtonPress(BlockType attemptedBlock)
        {
            if (buttonPressed || attemptedBlock != BlockType.Neither) { return true; }

            buttonPressed = true;

            return false;
        }

        public BlockType GetCurrentTurn()
        {
            return currentTurn;
        }

        public void ChangeCurrentTurn()
        {
            switch (currentTurn)
            {
                case BlockType.X:
                    currentTurn = BlockType.O;
                    break;
                case BlockType.O:
                    currentTurn = BlockType.X;
                    break;
                default:
                    Debug.LogWarning("The current turn is " + currentTurn + " and should not be.");
                    break;
            }
            buttonPressed = false;
        }

    }

}