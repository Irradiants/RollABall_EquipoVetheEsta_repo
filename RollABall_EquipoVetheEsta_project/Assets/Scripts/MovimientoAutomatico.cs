using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoAutomatico : MonoBehaviour
{
    [Header("Editor References")]
    public Rigidbody playerRB;
    public float playerSpeed = 5f;
    public float cambioCarrilSpeed = 10f;
    public float distanciaCarril = 1.5f;

    private int carrilActual = 0;

    [Header("Jump Parameters")]
    public float jumpForce = 6;
    public bool isGrounded = true;

    void Update()
    {
        // Avanzar automáticamente
        transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime, Space.World);

        // Cambiar un carril a la izquierda
        if (Input.GetKeyDown(KeyCode.A))
        {
            carrilActual--;
            carrilActual = Mathf.Clamp(carrilActual, -1, 1);
        }

        // Cambiar un carril a la derecha
        if (Input.GetKeyDown(KeyCode.D))
        {
            carrilActual++;
            carrilActual = Mathf.Clamp(carrilActual, -1, 1);
        }

        // Calcular la posición X del carril seleccionado
        float posicionObjetivoX = carrilActual * distanciaCarril;

        // Desplazarse suavemente hacia el carril
        Vector3 posicionObjetivo = new Vector3(
            posicionObjetivoX,
            transform.position.y,
            transform.position.z
        );

        transform.position = Vector3.MoveTowards(transform.position, posicionObjetivo, cambioCarrilSpeed * Time.deltaTime);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
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


    #endregion
}
