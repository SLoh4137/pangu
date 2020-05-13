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
        private PlayerCombat combat;

        void Awake()
        {
            inputActions = new PlayerInputActions();
            control = GetComponent<PlayerControl>();
            combat = GetComponent<PlayerCombat>();
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

        void OnAttack(InputAction.CallbackContext context)
        {
            control.Attacking = context.ReadValue<float>() != 0f;
        }

        void OnMousePosition(InputAction.CallbackContext context)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
            if (mousePos.x < transform.position.x && control.FacingRight)
            {
                control.Flip();
            }
            else if (mousePos.x > transform.position.x && !control.FacingRight)
            {
                control.Flip();
            }
        }

        void OnEnable()
        {
            inputActions.Enable();
            inputActions.PlayerControls.Move.performed += OnMovement;
            inputActions.PlayerControls.Jump.performed += OnJump;
            inputActions.PlayerControls.Jump.canceled += OnJump;
            inputActions.PlayerControls.Crouch.performed += OnCrouch;
            inputActions.PlayerControls.Crouch.canceled += OnCrouch;
            inputActions.PlayerControls.Attack.performed += OnAttack;
            inputActions.PlayerControls.Attack.canceled += OnAttack;
            inputActions.PlayerControls.Mouse.performed += OnMousePosition;
        }

        void OnDisable()
        {
            inputActions.PlayerControls.Move.performed -= OnMovement;
            inputActions.PlayerControls.Jump.performed -= OnJump;
            inputActions.PlayerControls.Jump.canceled -= OnJump;
            inputActions.PlayerControls.Crouch.performed -= OnCrouch;
            inputActions.PlayerControls.Crouch.canceled -= OnCrouch;
            inputActions.PlayerControls.Attack.performed -= OnAttack;
            inputActions.PlayerControls.Attack.canceled -= OnAttack;
            inputActions.PlayerControls.Mouse.performed -= OnMousePosition;
            inputActions.Disable();
        }
    }
}
