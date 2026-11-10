using UnityEngine;

public class Manteiner : MonoBehaviour
{

    private static Manteiner instancia;

    private void Awake()
    {
        if (instancia != null)
        {
            Destroy(gameObject);   // ya existe uno: este sobra
            return;
        }

        instancia = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
