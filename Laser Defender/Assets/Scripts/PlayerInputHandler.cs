using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private InputActions inputActions;
    private PlayerMovement playerMovement;
    private ShootingScript shootingScript;

    private void Awake()
    {
        shootingScript = GetComponent<ShootingScript>();
    }

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        shootingScript = GetComponent<ShootingScript>();
        if (playerMovement == null)
        {
            playerMovement = gameObject.AddComponent<PlayerMovement>();
        }
        inputActions = new InputActions();
        inputActions.Player.Move.performed += OnMove;
        inputActions.Player.Move.canceled += OnMove;
        inputActions.Player.Fire.performed += OnFire;
        inputActions.Player.Fire.canceled += OnFire;
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

    private void OnFire(InputAction.CallbackContext context)
    {
        if (shootingScript != null)
        {
            if (context.performed)
            {
                shootingScript.StartShooting();
            }
            else if (context.canceled)
            {
                shootingScript.StopShooting();
            }
        }
    }
}
