using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteractions : MonoBehaviour
{
    [Header("Respawn System")]
    public Transform respawnPoint;
    public Rigidbody playerRB;
    public int points;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("PickUp"))
        {
            points++;
            collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Respawn();
        }
    }

    void Respawn()
    {
        int escenaActual = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(escenaActual);
    }
}
