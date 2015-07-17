using UnityEngine;

public class PoolScript : MonoBehaviour
{
    private MyAutoObjectPool _pool;

    void Start ()
    {
        _pool = GameObject.Find("PoolManager").GetComponent<MyAutoObjectPool>();
    }

    void Update ()
    {
        //注意取出的类型是绑定到预制件的脚本类型
        MyAutoObject obj = _pool.Take() as MyAutoObject;

        GameObject go = obj.GetObject();
        go.transform.position = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f));
        go.transform.eulerAngles = new Vector3(Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f));
    }
}
