using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    private string playerName;

    void Start()
    {
        
    }

    void Update()
    {
        if(playerName == null) {
            playerName = GameObject.Find("PlayerManager").GetComponent<PlayerManager>().GetPlayerName();
        }
    }
}
