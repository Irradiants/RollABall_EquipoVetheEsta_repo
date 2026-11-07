using UnityEngine;
using TMPro;

public class Reinicio : MonoBehaviour
{
    [Header("configuracion del tiempo")]
    public float tiempoRestante = 30f;

    [Header("componentes visuales")]
    public TextMeshProUGUI textoTemporizador;

    [Header("configuracion del spawn")]
    public Transform jugador;
    public Transform puntoSpawn;

    private float tiempoInicial;

    void Start()
    {
        tiempoInicial = tiempoRestante;
    }

    void Update()
    {
        if (tiempoRestante > 0)
        {
            tiempoRestante -= Time.deltaTime;
            if (tiempoRestante < 0)
            {
                tiempoRestante = 0;
            }
            if (textoTemporizador != null)
            {
                textoTemporizador.text = "tiempo:" + tiempoRestante.ToString("F1") + "S";
            }
        }
        else
        {
            TeletransportarAlSpawn();
        }
    }

    void TeletransportarAlSpawn()
    {
        // Si usas CharacterController, desactívalo antes de esta línea y actívalo después
        jugador.position = puntoSpawn.position;

        tiempoRestante = tiempoInicial;
    }
}