using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    public PlayerInput.WalkingActions Walk;
    private PlayerMovement Move;
    private PlayerLook look;
    
    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        Walk = playerInput.Walking;
        Move = GetComponent<PlayerMovement>();
        look = GetComponent<PlayerLook>();
        Walk.Jump.performed += ctx => Move.Jump();
        Walk.Crouch.performed += ctx => Move.Crouch();
        Walk.Sprint.performed += ctx => Move.Sprint();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // telling playermovement to move using value from actions
        Move.ProcessMove(Walk.Movement.ReadValue<Vector2>());
    }
    void LateUpdate()
    {
        // telling playermovement to move using value from actions
        look.ProcessLook(Walk.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        Walk.Enable();
    }
    private void OnDisable()
    {
        Walk.Disable();
    }
}
