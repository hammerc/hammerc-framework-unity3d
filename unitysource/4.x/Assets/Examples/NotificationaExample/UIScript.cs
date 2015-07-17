using HammercLib.Notification;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    void Start()
    {
    }
    
    void Update()
    {
    }

    public void SendMoveY()
    {
        NotificationCenter.GetInstance().SendNotification("MoveY", this, new MoveYEventArgs(1.5f));
    }
}
