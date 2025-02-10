using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TickTackToe_Game
{
    public class InputManager : MonoBehaviour
    {
        public ControlScheme control;

        private Camera main_Camera;

        private void Awake()
        {
            main_Camera = Camera.main;
            if (main_Camera == null) { Debug.Log("cemera not connected"); }
        }

        private void OnEnable()
        {
            if (control == null) control = new ControlScheme();

            control.ClickMap.MouseClick.performed += Click;

            control.Enable();
        }

        private void OnDisable()
        {
            control.Disable();

            control.ClickMap.MouseClick.performed -= Click;

            control = null;
        }

        void Click(InputAction.CallbackContext ctx)
        {
            if (!ctx.performed) return;

            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

            if (Physics.Raycast(ray, out RaycastHit hit, 100))
            {
                //Debug.Log(hit.transform.name);
                if (hit.collider.gameObject.GetComponent<Block>())
                {
                    hit.collider.gameObject.GetComponent<Block>().ButtonPress();
                }
            }
        }



    }

}