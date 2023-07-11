using System.Collections;
using System.Collections.Generic;
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

    public void DebugLog(PlayerData playerData)
    {
        Debug.Log(playerData.playerName);
    }
    
}
