using UnityEngine;

public class GOScript : MonoBehaviour
{
    public float time = 5;

    void Start ()
    {

    }

    void Update ()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
