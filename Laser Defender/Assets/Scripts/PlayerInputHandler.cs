using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private InputActions inputActions;
    private PlayerMovement playerMovement;
    private void Awake()
    {


    }

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        if (playerMovement == null)
        {
            playerMovement = gameObject.AddComponent<PlayerMovement>();
        }
        inputActions = new InputActions();
        inputActions.Player.Move.performed += OnMove;
        inputActions.Player.Move.canceled += OnMove;
        inputActions.Enable();
    }

    private void OnEnable()
    {
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        Vector2 movement = context.ReadValue<Vector2>();
        playerMovement.GetMoveInput(movement);
    }
}