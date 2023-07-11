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
            OperateReceiveData(receiveMessage);
            receiveMessage = null;
        }
    }

    // 主要操作接收到的数据
    private void OperateReceiveData(MessageData message)
    {
        HandleMessage.Instance.DebugMessageData(message);
    }

    public void ReceiveMessage_(MessageData message)
    {
        receiveMessage = message;
    }
}
