using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const string KeyboardHorizontalAxis = "Horizontal";
    private const string KeyboardVerticalAxis = "Vertical";
    private const string MouseHorizontalAxis = "Mouse X";
    private const string MouseVerticalAxis = "Mouse Y";

    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _mouseSensitivity = 2f; 
    [SerializeField] private Camera _playerCamera;
    [SerializeField] private float _maxLookUpAngel = 45f;
    [SerializeField] private float _minLookDownAngel = -45f;

    private float _rotationY; 
    private float _rotationX;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        float moveHorizontal = Input.GetAxis(KeyboardHorizontalAxis);
        float moveVertical = Input.GetAxis(KeyboardVerticalAxis);
        Vector3 move = transform.right * moveHorizontal + transform.forward * moveVertical;
        transform.position += move * _moveSpeed * Time.deltaTime;
    }

    private void Rotate()
    {
        float mouseX = Input.GetAxis(MouseHorizontalAxis);
        float mouseY = Input.GetAxis(MouseVerticalAxis);

        _rotationY += mouseX * _mouseSensitivity;
        _rotationX -= mouseY * _mouseSensitivity;
        _rotationX = Mathf.Clamp(_rotationX, _minLookDownAngel, _maxLookUpAngel);

        _playerCamera.transform.localRotation = Quaternion.Euler(_rotationX, 0, 0);
        transform.rotation = Quaternion.Euler(0, _rotationY, 0);
    }
}
