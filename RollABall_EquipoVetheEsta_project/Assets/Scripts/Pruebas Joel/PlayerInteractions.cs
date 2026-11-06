using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    public int points;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider pickup)
    {
        if (pickup.gameObject.CompareTag("PickUp"))
        {
            points++;
            pickup.gameObject.SetActive(false);
        }
    }
}
