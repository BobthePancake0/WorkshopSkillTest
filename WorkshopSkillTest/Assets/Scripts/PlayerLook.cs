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
        xRotation -= (lookInput.y * Time.deltaTime) * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        transform.Rotate(Vector3.up * (lookInput.x * Time.deltaTime) * xSensitivity);
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }

}
