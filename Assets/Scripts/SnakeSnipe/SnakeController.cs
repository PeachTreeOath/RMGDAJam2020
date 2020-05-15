using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FiveXT.SnakeSnipe
{
    public class SnakeController : MonoBehaviour
    {
        private PlayerInputActions inputAction;
        private Vector2 movementInput;
        private Vector2 lookPosition;

        private void Awake()
        {
            inputAction = new PlayerInputActions();
            inputAction.PlayerControls.Move.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
            inputAction.PlayerControls.FireDirection.performed += ctx => lookPosition = ctx.ReadValue<Vector2>();
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void FixedUpdate()
        {
            float h = movementInput.x;
            float v = movementInput.y;

            transform.position += new Vector3(h, v) * Time.fixedDeltaTime;
        }

        private void OnEnable()
        {
            inputAction.Enable();
        }

        private void OnDisable()
        {
            inputAction.Disable();
        }
    }
}
