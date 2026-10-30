using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    [Header("Editor References")]
    public Rigidbody playerRB;

    [Header("Movement Parameter")]
    public float velocidad = 10;
    void Start()
    {
        Movement();
    }

    void Update()
    {
        
    }

    void Movement()
    {
        playerRB.AddForce(Vector3.forward * velocidad);
    }
}
