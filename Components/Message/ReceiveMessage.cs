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
            // 将接收到的数据分流到HandleMessage中
            HandleMessage.Instance.OperateReceiveMessage(receiveMessage);
            receiveMessage = null;
        }
    }

    // 接收收到的数据
    public void ReceiveMessage_(MessageData receive_message)
    {
        receiveMessage = receive_message;
    }
}
