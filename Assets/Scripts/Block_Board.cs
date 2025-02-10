using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TickTackToe_Game
{

    public class Block_Board : MonoBehaviour
    {
        private int board_Size;
        private GameObject blockPrefab;
        internal Block[,] blocks;
        internal TickTackToe tickTackToe;

        public void SetUp(GameObject blockPrefab, int board_size, TickTackToe tickTackToe)
        {
            this.blockPrefab = blockPrefab;
            this.board_Size = board_size;
            this.tickTackToe = tickTackToe;
            this.blocks = new Block[board_size, board_size];

            int Vertical_Offset = 4;
            int Horizontal_Offset = -4;

            GameObject tempBlock;

            for (int i = 0; i < board_size; i++)
            {
                for (int j = 0; j < board_size; j++)
                {
                    tempBlock = Instantiate(blockPrefab, this.transform);
                    blocks[i, j] = tempBlock.GetComponent<Block>();
                    blocks[i, j].SetUp(this, new Vector2(Horizontal_Offset + Mathf.Abs(Horizontal_Offset * i), Vertical_Offset - Mathf.Abs(Vertical_Offset * j)));
                }
            }
            Board_Scan.SetUp(board_Size);
        }

        public void CheckBoardState()
        {
            //Only has to check for current turn type!
            if (Board_Scan.Horizontal(blocks, tickTackToe.GetCurrentTurn()) == tickTackToe.GetCurrentTurn()
                || Board_Scan.Vertical(blocks, tickTackToe.GetCurrentTurn()) == tickTackToe.GetCurrentTurn()
                || Board_Scan.Diagnoal(blocks, tickTackToe.GetCurrentTurn()) == tickTackToe.GetCurrentTurn())
            {
                //turn won
                tickTackToe.FinishGame();
            }
            else
            {
                tickTackToe.ChangeCurrentTurn();
            }
        }
    }

}