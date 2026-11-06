using UnityEngine;

public class Agacharse : MonoBehaviour
{
    public KeyCode teclaAgacharse = KeyCode.S;
    public float escalaAgachadaY = 0.5f;
    public float velocidadCambio = 10f;

    private Vector3 escalaNormal;
    private Vector3 escalaAgachada;

    void Start()
    {
        escalaNormal = transform.localScale;
        escalaAgachada = new Vector3(
            escalaNormal.x,
            escalaNormal.y * escalaAgachadaY,
            escalaNormal.z
        );
    }

    void Update()
    {
        Vector3 escalaObjetivo = Input.GetKey(teclaAgacharse)
            ? escalaAgachada
            : escalaNormal;

        transform.localScale = Vector3.Lerp(
            transform.localScale,
            escalaObjetivo,
            velocidadCambio * Time.deltaTime
        );
    }
}
