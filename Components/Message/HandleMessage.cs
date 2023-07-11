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

    public void DebugMessageData(MessageData data)
    {
        Debug.Log(JsonConvert.SerializeObject(data));
    }
    
}
