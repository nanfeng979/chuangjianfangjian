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
        DebugMessageMessage(ref receive_message);

    }

    private void DebugMessageMessage(ref MessageData receive_message)
    {
        Debug.Log("打印收到后台的消息" + JsonConvert.SerializeObject(receive_message));
    }
    
}
