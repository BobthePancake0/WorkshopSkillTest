using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    private CharacterController controller;
    private Vector3 playerVelocity = Vector3.zero;

    [SerializeField] private float speed = 5f;

    private bool isGrounded;
    [SerializeField] private float gravity = -9.8f;

    [SerializeField] private float jumpHeight = 3f;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Grabs the first character controller component attached to the player
        controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {

        ProcessGravity();

        // Moves the character controller based on the playerVelocity dictated from the context function
        controller.Move(transform.TransformDirection(playerVelocity) * speed * Time.deltaTime);
        
        // Checks if the character controller is on the ground
        isGrounded = controller.isGrounded;
        
    

    }

    /*  
    /   Whenever the buttons binded to MOVE are pressed
    /   Gets the Vector2 value tied to them and applies that to
    /   to the players x and z velocity accordingly
    / 
    /   When the button is released, stops any momentum
    /   On the X and/or Z axis. 
    */
    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Vector2 input = context.ReadValue<Vector2>();
            
            playerVelocity.x = input.x;
            playerVelocity.z = input.y;

        }

        if (context.canceled)
            playerVelocity =  new Vector3(0f, playerVelocity.y, 0f);


    }

    
    /*
    /   TOO BE CALLED EVERY FRAME IN UPDATE
    /   
    /   Applies the gravity variable to the players y velocity
    /   This creates a constant downward force on the player
    /
    /   If the player is grounded, sets the y-velocity to -2
    /   Instead to not have the downward "force" accumulating
    */
    private void ProcessGravity()
    {

        playerVelocity.y += gravity * Time.deltaTime;

        if (isGrounded && playerVelocity.y < 0)
            playerVelocity.y = -2f;

        controller.Move(playerVelocity * Time.deltaTime);

        //Debug.Log(playerVelocity.y);
    }

    /*
    /   Whenever the player presses the button binded to the Jump command
    /
    /   Applies an upward force to their vertical (y) velocity
    /
    /   Whenever the button is released, splits their vertical velocity in half, 
    /   as to adapt
    */
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
        
        if (context.canceled && !isGrounded)
        {
            playerVelocity.y *= 0.5f;
        }
    }


}
