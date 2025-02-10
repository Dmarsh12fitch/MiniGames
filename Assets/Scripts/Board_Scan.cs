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
}