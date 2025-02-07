using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        int Vertical_Offset = -4;

        GameObject tempBlock;

        for (int i = 0; i < board_Size; i++)
        {
            for (int j = 0; j < board_Size; j++)
            {
                tempBlock = Instantiate(blockPrefab, this.transform);
                blocks[i, j] = tempBlock.GetComponent<Block>();
                blocks[i, j].SetUp(this, new Vector2(Horizontal_Offset + Mathf.Abs(Horizontal_Offset * i), Vertical_Offset + Mathf.Abs(Vertical_Offset * j)));
            }
        }

        Block_Scan.Instance.SetUp(this.GetComponent<Block_Board>());
    }


    public void CheckBoardState()
    {
        //only has to check for current turn type!
        //Check horizontally
        Block_Scan.Instance.Horizontal_Scan(currentTurn);  //returns something
        //check vertically
        //check diagonals


        //switch current turn and reset button pressed
        ChangeCurrentTurn();
        buttonPressed = false;
    }

    public bool AttemptButtonPress()
    {
        if (buttonPressed) { return true; }

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
    }

}
