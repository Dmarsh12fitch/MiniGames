using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_Scan : MonoBehaviour
{
    private static Block_Scan _instance;

    public static Block_Scan Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("Block_Scan is null");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    private Block_Board board;
    private int board_Size;

    public void SetUp(Block_Board board)
    {
        this.board = board;
        board_Size = board.board_Size;
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
