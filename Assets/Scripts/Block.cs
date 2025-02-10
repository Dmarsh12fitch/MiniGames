using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace TickTackToe_Game
{
    public class Block : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;
        private BlockType type;
        private Block_Board board;

        public void SetUp(Block_Board board, Vector2 location)
        {
            this.type = BlockType.Neither;
            this.board = board;
            UpdateBlockText();
            this.transform.position = new Vector3(location.x, this.transform.position.y, location.y);
        }

        private void SetBlockType(BlockType type)
        {
            this.type = type;
            UpdateBlockText();
        }

        public BlockType GetBlockType()
        {
            return type;
        }

        private void UpdateBlockText()
        {
            switch (type)
            {
                case BlockType.Neither:
                    text.text = "-";
                    break;
                case BlockType.X:
                    text.text = "X";
                    break;
                case BlockType.O:
                    text.text = "O";
                    break;
                default:
                    text.text = "&";
                    break;
            }
        }

        public void ButtonPress()
        {
            //Debug.Log("Button Pressed?");
            if (board.tickTackToe.AttemptButtonPress(type)) { return; }

            //Debug.Log("Yes Button Pressed");

            SetBlockType(board.tickTackToe.GetCurrentTurn());
            board.CheckBoardState();
        }

    }

}