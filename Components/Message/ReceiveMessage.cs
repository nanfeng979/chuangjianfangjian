using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveMessage : MonoBehaviour
{
    public static ReceiveMessage Instance;

    private MessageData receiveMessage;

    void Start()
    {
        if(Instance == null) {
            Instance = this;
        }
    }

    void Update()
    {
        if(receiveMessage != null) {
            OperateReceiveMessage(receiveMessage);
            receiveMessage = null;
        }
    }

    // 主要操作接收到的数据
    private void OperateReceiveMessage(MessageData receive_message)
    {
        HandleMessage.Instance.DebugMessageMessage(receive_message);
        GameObject.Find("RoomManager").GetComponent<RoomManager>().SetReceiveMessage(receive_message);
    }

    // 接收收到的数据
    public void ReceiveMessage_(MessageData receive_message)
    {
        receiveMessage = receive_message;
    }
}
