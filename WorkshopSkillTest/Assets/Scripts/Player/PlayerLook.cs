using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{

    [SerializeField] private CinemachineCamera cam;
    private float xRotation = 0f;
    private Vector2 lookInput;

    [Header("Sensitivity")]
    [SerializeField] private float xSensitivity = 30f;
    [SerializeField] private float ySensitivity = 30f;


    public void LateUpdate()
    {
        processLook();
    }

    /*
    /   The Mouse is tied to the input context
    /   Gathers the x and y context of the mouse whenever moved
    */
    public void OnLook(InputAction.CallbackContext context)
    {
        if (!GameManager.Instance.isGameOver())
        {
            lookInput = context.ReadValue<Vector2>();
        }
    }

    /*
    /   Rotates the player and the camera according to the
    /   mouses location
    */
    private void processLook()
    {
        xRotation -= (lookInput.y * Time.deltaTime) * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        transform.Rotate(Vector3.up * (lookInput.x * Time.deltaTime) * xSensitivity);
    }

}
