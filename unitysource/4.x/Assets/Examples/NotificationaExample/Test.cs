using HammercLib.Notification;
using System;
using UnityEngine;

public class Test : MonoBehaviour
{
    void Start()
    {
        Notifier n = new Notifier();
        n.Execute(this, EventArgs.Empty);

        NotificationCenter.GetInstance().SendNotification("GameStart");
        Debug.Log("Send 'GameStart' but is not any hanlder!");


    }
    
    void Update()
    {
    }
}
