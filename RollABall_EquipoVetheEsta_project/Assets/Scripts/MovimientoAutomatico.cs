using UnityEngine;

public class MovimientoAutomatico : MonoBehaviour
{
    public float playerSpeed = 5f;
    public float cambioCarrilSpeed = 10f;
    public float distanciaCarril = 3f;

    private int carrilActual = 0;

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
}
