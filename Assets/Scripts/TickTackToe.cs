using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace TickTackToe_Game
{
    public class TickTackToe : MonoBehaviour
    {
        [SerializeField] private GameObject block_Prefab;
        [SerializeField] private GameObject board_Prefab;
        [SerializeField] private int board_Size;

        private Block_Board myBoard;

        private bool buttonPressed;
        private BlockType currentTurn;
        [SerializeField] private TextMeshProUGUI currentTurnDisplay;
        [SerializeField] private TextMeshProUGUI currentTurnText;

        // Start is called before the first frame update
        void Start()
        {
            SetUpGame();
        }

        private void SetUpGame()
        {
            currentTurn = BlockType.X;
            UpdateCurrentTurnDisplay();
            buttonPressed = false;
            var tempBoard = Instantiate(board_Prefab);
            myBoard = tempBoard.GetComponent<Block_Board>();
            myBoard.SetUp(block_Prefab, board_Size, this);
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
            UpdateCurrentTurnDisplay();
            buttonPressed = false;
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

        public void FinishGame()
        {
            //declare winner (current turn)
            Debug.Log(currentTurn + " WON!");

            currentTurnText.text = "Winner is:";

            //bring up buttons to replay or to go to main menu
        }

        private void UpdateCurrentTurnDisplay()
        {
            switch (currentTurn)
            {
                case BlockType.Neither:
                    currentTurnDisplay.text = "-";
                    break;
                case BlockType.X:
                    currentTurnDisplay.text = "X";
                    break;
                case BlockType.O:
                    currentTurnDisplay.text = "O";
                    break;
                default:
                    currentTurnDisplay.text = "&";
                    break;
            }
        }

    }
}