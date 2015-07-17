using HammercLib.Notification;
using System;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    void Start()
    {
        NotificationCenter.GetInstance().AddNotificationHandler("MoveY", MoveYHandler);
    }
    
    void Update()
    {
    }

    void OnDestroy()
    {
        NotificationCenter.GetInstance().RemoveNotificationHandler("MoveY", MoveYHandler);
    }

    private void MoveYHandler(object sender, EventArgs eventArgs)
    {
        MoveYEventArgs e = (MoveYEventArgs)eventArgs;

        Debug.Log("sender: " + sender.ToString() + ", y: " + e.y);

        Vector3 pos = this.transform.position;
        pos.y = e.y;
        this.transform.position = pos;
    }
}
