using Unity.Cinemachine;
using UnityEngine;

public class CameraFoVController : MonoBehaviour
{
    public CinemachineCamera cam;
    public float fovInicial = 50f;
    public float fovFinal = 70f;
    public float duracion = 20f;
    void Start()
    {
        cam.Lens.FieldOfView = fovInicial;
    }

    void Update()
    {
        float ritmo = (fovFinal - fovInicial) / duracion;

        cam.Lens.FieldOfView = Mathf.MoveTowards(
            cam.Lens.FieldOfView,
            fovFinal,
            ritmo * Time.deltaTime
        );
    }
}
