using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;

public class RoomManager : MonoBehaviour
{
    // 接收广播消息
    private MessageData receiveMessage;

    // 当前座位列表
    [SerializeField]
    private GameObject[] seats;

    // 管理当前房间的玩家
    // public List<PlayerData> players = new List<PlayerData>();
    public List<string> playerNameList;

    void Start()
    {
        SetCurrentPlayerStatus(PlayerStatus.JoinRoom);
    }

    void Update()
    {
        // 打印成员数据
        DebugPlayers();
    }

    public void OperateReceiveMessage(ref MessageData receive_message)
    {
        
    }

    private void SetPlayerJoinRoom(ref PlayerData player_data) {
        if(player_data != null) {
            playerNameList.Add(player_data.playerName);
        }
    }

    private void SetPlayerWaitToSit() {
        SetCurrentPlayerStatus(PlayerStatus.WaitToSit);
    }

    private void DebugPlayers() {
        string a = "";
        for(int i = 0; i < playerNameList.Count; i++) {
            a += playerNameList[i] + ", ";
        }
        Debug.Log("Room 成员有: " + a);
    }

    private void SetCurrentPlayerStatus(PlayerStatus status) {
        GameObject.Find("PlayerManager").GetComponent<PlayerManager>().SetPlayerStatus(status);
    }
    
}
