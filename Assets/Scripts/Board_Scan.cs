using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TickTackToe_Game
{

    public static class Board_Scan
    {
        private static int board_Size;

        public static void SetUp(int size)
        {
            board_Size = size;
        }

        public static BlockType Horizontal(Block[,] blocks, BlockType currentType)
        {
            for (int i = 0; i < board_Size; i++)
            {
                for (int j = 0; j < board_Size; j++)
                {
                    if (blocks[i, j].GetBlockType() != currentType) { break; }
                    if (j == board_Size - 1)
                    {
                        return currentType;
                    }
                }
            }

            return BlockType.Neither;
        }

        public static BlockType Vertical(Block[,] blocks, BlockType currentType)
        {
            for (int j = 0; j < board_Size; j++)
            {
                for (int i = 0; i < board_Size; i++)
                {
                    if (blocks[i, j].GetBlockType() != currentType) { break; }
                    if (i == board_Size - 1)
                    {
                        return currentType;
                    }
                }
            }

            return BlockType.Neither;
        }

        public static BlockType Diagnoal(Block[,] blocks, BlockType currentType)
        {
            if (Forward_Diagonal(blocks, currentType) == currentType || Backward_Diagonal(blocks, currentType) == currentType)
            {
                return currentType;
            }
            else
            {
                return BlockType.Neither;
            }
        }

        private static BlockType Forward_Diagonal(Block[,] blocks, BlockType currentType)
        {
            if (blocks[2, 0].GetBlockType() == currentType && blocks[1, 1].GetBlockType() == currentType && blocks[0, 2].GetBlockType() == currentType)
            {
                return currentType;
            }
            else
            {
                return BlockType.Neither;
            }
        }

        private static BlockType Backward_Diagonal(Block[,] blocks, BlockType currentType)
        {
            if (blocks[0, 0].GetBlockType() == currentType && blocks[1, 1].GetBlockType() == currentType && blocks[2, 2].GetBlockType() == currentType)
            {
                return currentType;
            }
            else
            {
                return BlockType.Neither;
            }
        }




    }

    /*
    public class Block_Scan : MonoBehaviour
    {
        public static Block_Scan Instance { get; private set; }

        private void Awake()
        {
            if(Instance != null && Instance != this)
            {
                Destroy(Instance);
            }
            else
            {
                Instance = this;
                Debug.Log("Instance made");
            }
        }


        private Block_Board board;
        private int board_Size;

        public bool IsSetUp()
        {
            return board != null;
        }

        public void SetUp(Block_Board board)
        {
            this.board = board;
            board_Size = this.board.board_Size;
        }

        public BlockType Horizontal_Scan(BlockType currentType)
        {
            for(int i = 0; i < board_Size; i++)
            {
                for(int j = 0; j < board_Size; j++)
                {
                    if(board.blocks[i, j].GetBlockType() != currentType) { break; }
                    if(j == board_Size - 1)
                    {
                        Debug.Log("the " + currentType + "'s win!");
                        return currentType;
                    }
                }
            }

            Debug.Log("no win");
            return BlockType.Neither;
        }

        void Vertical_Scan()
        {

        }

        void Diagnoal_Scans()
        {
            Forward_Diagonal_Scan();
            Backward_Diagonal_Scan();
        }

        void Forward_Diagonal_Scan()
        {

        }

        void Backward_Diagonal_Scan()
        {

        }
    }
    */
}