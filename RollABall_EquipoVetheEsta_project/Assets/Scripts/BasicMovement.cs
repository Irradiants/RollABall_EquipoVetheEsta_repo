using UnityEngine;
using UnityEngine.InputSystem;

public class BasicMovement : MonoBehaviour
{
    [Header("Editor References")]
    public Rigidbody playerRB;

    [Header("Movement Parameter")]
    public float velocidad = 10;
    public Vector2 movementInput;

    [Header("Jump Parameters")]
    public float jumpForce = 6;
    public bool isGrounded = true;

    void Start()
    {
        PermanentMovement();
    }

    void Update()
    {
        
    }

    void PermanentMovement()
    {
        playerRB.AddForce(Vector3.forward * velocidad);
    }

    void inputMovement()
    {

    }

    void Jump()
    {
        playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    #region Input Methods
    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded == true)
        {
            isGrounded = false;
            Jump();
        }
    }


    #endregion
}
