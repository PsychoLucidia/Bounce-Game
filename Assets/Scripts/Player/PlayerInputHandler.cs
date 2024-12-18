using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerMovementRB))]
public class PlayerInputHandler : MonoBehaviour
{
    public GameInput gameInput;
    public SetFramerate framerate;

    [SerializeField] private Vector2 direction; 

    // Non-Serialized
    private PlayerMovementRB playerMovementRB;


    void Awake()
    {
        playerMovementRB = GetComponent<PlayerMovementRB>();

        gameInput = new GameInput();
    }

    void OnEnable()
    {
        EnableInGameInput();
    }

    void EnableInGameInput()
    {
        gameInput.InGame.Enable();

        gameInput.InGame.Move.performed += HandleMovement;
        gameInput.InGame.Move.canceled += HandleMovement;

        gameInput.InGame.Jump.performed += HandleJump;
        gameInput.InGame.Jump.canceled += HandleJump;

        gameInput.InGame.SetFramerate.started += HandleFramerate;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void HandleMovement(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();

        if (context.started) { Debug.Log("Movement started"); }

        playerMovementRB.moveDirection = new Vector3(direction.x, 0, direction.y);

    }

    void HandleJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            playerMovementRB.Jump();
        }
    }

    void HandleFramerate(InputAction.CallbackContext context)
    {
        framerate.SetFramerateMethod();
    }
}
