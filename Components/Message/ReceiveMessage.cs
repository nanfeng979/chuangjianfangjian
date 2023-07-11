using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveMessage : MonoBehaviour
{
    public static ReceiveMessage Instance;

    private PlayerData receiveMessage;

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

    private void OperateReceiveData(PlayerData message)
    {
        
    }

    public void ReceiveMessage_(PlayerData message)
    {
        receiveMessage = message;
    }
}
