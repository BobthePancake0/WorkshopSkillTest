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
        
        controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {

        ProcessGravity();

        controller.Move(transform.TransformDirection(playerVelocity) * speed * Time.deltaTime);
        
        isGrounded = controller.isGrounded;
        
    

    }

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

    private void ProcessGravity()
    {
        playerVelocity.y += gravity * Time.deltaTime;
        if (isGrounded && playerVelocity.y < 0)
            playerVelocity.y = -2f;
        controller.Move(playerVelocity * Time.deltaTime);

        Debug.Log(playerVelocity.y);
    }

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
