using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float mouseSensitivity = 2f; 
    [SerializeField] private Camera _playerCamera;
    [SerializeField] private float maxLookUpAngel = 45f;
    [SerializeField] private float minLookDownAngel = -45f;

    private float rotationY; 
    private float rotationX;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 move = transform.right * moveHorizontal + transform.forward * moveVertical;
        transform.position += move * moveSpeed * Time.deltaTime;
    }

    private void Rotate()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        rotationY += mouseX * mouseSensitivity;
        rotationX -= mouseY * mouseSensitivity;
        rotationX = Mathf.Clamp(rotationX, minLookDownAngel, maxLookUpAngel);

        _playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation = Quaternion.Euler(0, rotationY, 0);
    }
}
