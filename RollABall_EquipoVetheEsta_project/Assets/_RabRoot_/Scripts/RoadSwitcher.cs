using UnityEngine;

public class RoadSwitcher : MonoBehaviour
{
    public float displacement = 200f;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.CompareTag("Player"))
        {
            transform.parent.position += new Vector3(transform.parent.position.x, transform.parent.position.y, displacement);
        }
    }
}
