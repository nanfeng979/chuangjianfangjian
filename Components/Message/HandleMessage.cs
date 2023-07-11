using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class HandleMessage : MonoBehaviour
{
    public static HandleMessage Instance;

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
    public void OperateReceiveMessage(MessageData receive_message)
    {
        DebugMessageMessage(receive_message);
        // 如果当前是在开房间的状态,则发送给RoomManager
        GameObject.Find("RoomManager").GetComponent<RoomManager>().SetReceiveMessage(receive_message);
    }

    private void DebugMessageMessage(MessageData receive_message)
    {
        Debug.Log("打印收到后台的消息" + JsonConvert.SerializeObject(receive_message));
    }
    
}
