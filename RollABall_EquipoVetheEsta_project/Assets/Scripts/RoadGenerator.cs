using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class RoadGenerator : MonoBehaviour
{
    public int prefabsInstances = 20;
    public float instancesDistance = 10f;
    public float factorSeparacion = 1.75f;

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
            GameObject instance = Instantiate(rndObject, roadPosition, Quaternion.identity);
            roadInstance++;
            SepararHijos(instance);
            roadPosition.z += instancesDistance * factorSeparacion;

        }
    }

    void SepararHijos(GameObject instancia)
    {
        foreach (Transform hijo in instancia.transform)
        {
            Vector3 p = hijo.localPosition;
            p.z *= factorSeparacion;
            hijo.localPosition = p;
        }
    }
}
