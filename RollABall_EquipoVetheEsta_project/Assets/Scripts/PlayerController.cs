using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Editor References")]
    public Rigidbody playerRB;

    [Header("Player Movement Parameters")]
    public float playerSpeed = 5f;
    public float extraSpeed = 2.5f;
    public float accelerationTime = 20f;
    public float escalaAgachadaY = 0.5f;
    public float escalaAgachadaXZ = 1.5f;

    private float velocidadMaxima;

    [Header("Lanes Parameters")]
    public float cambioCarrilSpeed = 10f;
    public float distanciaCarril = 1.5f;
    private int carrilActual = 0;
    private float objetivoX;


    [Header("Jump Parameters")]
    public float jumpForce = 6;
    public bool isGrounded = true;

    void Start()
    {
        velocidadMaxima = playerSpeed + extraSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        float acceleration = extraSpeed / accelerationTime;   // 0.125 u/s²
        playerSpeed = Mathf.MoveTowards(playerSpeed, velocidadMaxima, acceleration * Time.deltaTime);
        transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime, Space.World);

        Vector3 pos = transform.position;
        pos.x = Mathf.MoveTowards(pos.x, objetivoX, cambioCarrilSpeed * Time.deltaTime);
        transform.position = pos;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void CambiarCarril(int direccion)
    {
        carrilActual = Mathf.Clamp(carrilActual + direccion, -1, 1);
        objetivoX = carrilActual * distanciaCarril;
    }

    void Jump()
    {
        playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    #region Input Methods

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded == true)
        {
            isGrounded = false;
            Jump();
        }
    }

    public void RightMovement(InputAction.CallbackContext context)
    {
        if (context.started || context.performed) CambiarCarril(1);
    }

    public void LefttMovement(InputAction.CallbackContext context)
    {
        if (context.started || context.performed) CambiarCarril(-1);
    }

    #endregion
}
