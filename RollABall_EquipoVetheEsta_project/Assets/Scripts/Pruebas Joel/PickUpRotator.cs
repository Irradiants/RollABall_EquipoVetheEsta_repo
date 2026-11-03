using System.Collections;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float ySpeed = 1.0f;
    public float yDistance = 0.2f;
    public int rotationSpeed = 60;
    private Transform visual;
    void Start()
    {
        visual = transform.GetChild(0).transform;
        StartCoroutine(PickupFloating());
    }

    void Update()
    {
    }

    private IEnumerator PickupFloating()
    {
        while(true)
        {
            visual.Rotate(Vector3.up, rotationSpeed *  Time.deltaTime, Space.World);
            visual.position = new Vector3(0, Mathf.Sin(Time.time * ySpeed) * yDistance + 0.5f, 0);
            yield return null;
        }
    }
}
