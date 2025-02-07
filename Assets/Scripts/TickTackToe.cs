using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TickTackToe : MonoBehaviour
{
    [SerializeField] private GameObject block_Prefab;
    [SerializeField] private GameObject board_Prefab;
    [SerializeField] private int board_Size;

    private Block_Board myBoard;


    // Start is called before the first frame update
    void Start()
    {
        SetUpGame();
    }

    private void SetUpGame()
    {
        Debug.Log("setupgame");
        var tempBoard = Instantiate(board_Prefab);
        myBoard = tempBoard.GetComponent<Block_Board>();
        myBoard.SetUp(block_Prefab, board_Size, this);
    }

}