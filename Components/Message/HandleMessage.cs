using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class HandleMessage : MonoBehaviour
{
    public static HandleMessage Instance;

    void Start()
    {
        if(Instance == null) {
            Instance = this;
        }
    }

    // 主要操作接收到的数据
    public void OperateReceiveMessage(ref MessageData receive_message)
    {
        DebugMessageMessage(receive_message);
        if(receive_message.playerData.playerName == GameObject.Find("PlayerManager").GetComponent<PlayerManager>().GetPlayerName()) {
            Debug.Log("收到自己广播的消息");
        } else {
            // 如果当前是在开房间的状态,则发送给RoomManager
            GameObject.Find("RoomManager").GetComponent<RoomManager>().OperateReceiveMessage(receive_message);
        }
    }

    private void DebugMessageMessage(MessageData receive_message)
    {
        Debug.Log("打印收到后台的消息" + JsonConvert.SerializeObject(receive_message));
    }
    
}
