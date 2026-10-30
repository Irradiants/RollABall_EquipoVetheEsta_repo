using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class RoadGenerator : MonoBehaviour
{
    public int roadSize = 10;

    public GameObject[] prefabCollection;

    void Start()
    {
        RoadInstance();
    }

    void Update()
    {
        
    }

    void RoadInstance()
    {
        int roadInstance = 1;
        Vector3 roadPosition = Vector3.zero;

        while (roadInstance <= roadSize)
        {
            GameObject rndObject = prefabCollection[Random.Range(0,prefabCollection.Length)];
            Debug.Log(rndObject);
            Instantiate(rndObject, roadPosition, Quaternion.identity);
            roadInstance++;
            roadPosition.z += 10f;
        }
    }
}
