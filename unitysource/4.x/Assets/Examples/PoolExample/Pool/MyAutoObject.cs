using HammercLib.Pool;
using UnityEngine;

public class MyAutoObject : UnityAutoObject
{
    public float time = 5;

    void Start ()
    {
    }

    void Update ()
    {
    }

    /// <summary>
    /// 该方法会每帧循环调用.
    /// </summary>
    public override void CheckRestore()
    {
        time -= Time.deltaTime;

        //赋值给 _restore 即可表示本对象是否会被回收
        _restore = time <= 0;
    }

    public override void ResetObject()
    {
        base.ResetObject();
        time = 5;
    }
}
