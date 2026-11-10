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

    public float duracionColor = 20f;

    private Color colorInicial;
    private Color colorFinal = new Color32(195, 43, 55, 255);
    private float tiempoColor;

    void Start()
    {
        tiempoInicial = tiempoRestante;
        colorInicial = textoTemporizador.color;
    }

    void Update()
    {
        tiempoColor += Time.deltaTime;
        float t = Mathf.Clamp01(tiempoColor / duracionColor);
        textoTemporizador.color = Color.Lerp(colorInicial, colorFinal, t);

        if (tiempoRestante > 0)
        {
            tiempoRestante -= Time.deltaTime;
            if (tiempoRestante < 0)
            {
                tiempoRestante = 0;
            }
            if (textoTemporizador != null)
            {
                textoTemporizador.text = "Survive:" + tiempoRestante.ToString("F1") + "s";
            }
        }

        else
        {
            TeletransportarAlSpawn();
        }

        if (tiempoRestante <= 10)
        {
            textoTemporizador.color = new Color(0.7647f, 0.1686f, 0.2157f, 1f);
        }

/*        if (tiempoRestante <= 25)
        {
            Color lastcolor = new Color(0.7647f, 0.1686f, 0.2157f, 1f);
            Color lerpedColor = Color.Lerp(textoTemporizador.color, lastcolor, 15f);
        }*/
    }

    void TeletransportarAlSpawn()
    {
        // Si usas CharacterController, desactívalo antes de esta línea y actívalo después
        jugador.position = puntoSpawn.position;

        tiempoRestante = tiempoInicial;
    }
}