using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class RoadGenerator : MonoBehaviour
{
    public int prefabsInstances = 20;
    public float instancesDistance = 10f;

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
        Vector3 roadPosition = new Vector3(0,0,40);

        while (roadInstance <= prefabsInstances)
        {
            GameObject rndObject = prefabCollection[Random.Range(0,prefabCollection.Length)];
            Debug.Log(rndObject);
            Instantiate(rndObject, roadPosition, Quaternion.identity);
            roadInstance++;
            roadPosition.z += instancesDistance;
        }
    }
}
