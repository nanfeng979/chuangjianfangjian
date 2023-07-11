using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class RoomManager : MonoBehaviour
{

    void Start()
    {
        SetCurrentPlayerStatus(PlayerStatus.Ready);
    }

    void Update()
    {
        
    }

    private void SetCurrentPlayerStatus(PlayerStatus status) {
        GameObject.Find("PlayerManager").GetComponent<PlayerManager>().SetPlayerStatus(status);
    }
    
}
