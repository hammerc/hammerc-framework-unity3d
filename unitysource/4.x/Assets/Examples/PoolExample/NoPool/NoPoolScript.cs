using UnityEngine;

public class NoPoolScript : MonoBehaviour
{
    public GameObject prefab;

    void Start ()
    {

    }

    void Update ()
    {
        GameObject go = GameObject.Instantiate(prefab) as GameObject;
        go.transform.position = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f));
        go.transform.eulerAngles = new Vector3(Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f));
    }
}
