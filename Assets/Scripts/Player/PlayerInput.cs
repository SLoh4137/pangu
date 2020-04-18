using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace pangu
{
    [RequireComponent(typeof(CharacterControl))]
    public class PlayerInput : MonoBehaviour
    {
        private CharacterControl characterControl;
        private PlayerInputActions inputActions;

        void Awake()
        {
            inputActions = new PlayerInputActions();
            characterControl = GetComponent<CharacterControl>();
        }

        void OnMovement(InputAction.CallbackContext context)
        {
            characterControl.MoveHorizontal = context.ReadValue<float>();
        }

        void OnJump(InputAction.CallbackContext context)
        {
            characterControl.Jump = context.ReadValue<float>() != 0f;
        }

        void OnCrouch(InputAction.CallbackContext context)
        {
            characterControl.Crouch = context.ReadValue<float>() != 0f;
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
