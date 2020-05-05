using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace pangu
{
    [RequireComponent(typeof(PlayerControl))]
    public class PlayerInput : MonoBehaviour
    {
        private PlayerControl control;
        private PlayerInputActions inputActions;

        void Awake()
        {
            inputActions = new PlayerInputActions();
            control = GetComponent<PlayerControl>();
        }
        
        void OnMovement(InputAction.CallbackContext context)
        {
            control.MoveHorizontal = context.ReadValue<float>();
        }

        void OnJump(InputAction.CallbackContext context)
        {
            control.Jump = context.ReadValue<float>() != 0f;
        }

        void OnCrouch(InputAction.CallbackContext context)
        {
            control.Crouch = context.ReadValue<float>() != 0f;
        }


        void OnEnable()
        {
            inputActions.Enable();
            inputActions.PlayerControls.Move.performed += OnMovement;
            inputActions.PlayerControls.Jump.performed += OnJump;
            inputActions.PlayerControls.Jump.canceled += OnJump;
            inputActions.PlayerControls.Crouch.performed += OnCrouch;
            inputActions.PlayerControls.Crouch.canceled += OnCrouch;
        }

        void OnDisable()
        {
            inputActions.PlayerControls.Move.performed -= OnMovement;
            inputActions.PlayerControls.Jump.performed -= OnJump;
            inputActions.PlayerControls.Jump.canceled -= OnJump;
            inputActions.PlayerControls.Crouch.performed -= OnCrouch;
            inputActions.PlayerControls.Crouch.canceled -= OnCrouch;
            inputActions.Disable();
        }
    }
}
