using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountDownSystem : MonoBehaviour
{
    [Header("Coutdown Settings")]
    public float tiempoRestante = 30f;

    [Header("Text References")]
    public TextMeshProUGUI textoTemporizador;
    private float tiempoInicial;

    private Color colorInicial;
    private Color colorFinal = new Color32(195, 43, 55, 255);
    private float tiempoColor;
    private float duracionColor;

    [Header("Pulso final")]
    public int segundosAnimados = 10;
    public float escalaPulso = 1.4f;
    public float velocidadRetorno = 8f;

    private Vector3 escalaNormal;
    private int segundoAnterior;
    public float f;

    void Start()
    {
        tiempoInicial = tiempoRestante;
        colorInicial = textoTemporizador.color;

        escalaNormal = textoTemporizador.transform.localScale;
        segundoAnterior = Mathf.CeilToInt(tiempoRestante);

        duracionColor = tiempoInicial - 10f;
    }

    void Update()
    {
        tiempoRestante -= Time.deltaTime;
        int segundoActual = Mathf.CeilToInt(tiempoRestante);

        if (segundoActual != segundoAnterior)
        {
            segundoAnterior = segundoActual;

            if (segundoActual <= segundosAnimados && segundoActual >= 0)
                textoTemporizador.transform.localScale = escalaNormal * escalaPulso;
        }

        textoTemporizador.transform.localScale = Vector3.Lerp(
            textoTemporizador.transform.localScale,
            escalaNormal,
            velocidadRetorno * Time.deltaTime
        );

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
            NextLevel();
        }

    }

    void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
