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

    void Update()
    {
        
    }

    public void DebugMessageData(MessageData receive_message)
    {
        Debug.Log(JsonConvert.SerializeObject(receive_message));
    }
    
}
