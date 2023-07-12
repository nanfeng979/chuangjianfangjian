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

    public void OperateReceiveMessage(MessageData receive_message)
    {
        if(receive_message.messageType == EMessageType.JoinRoom.ToString()) {
            if(!playerNameList.Contains(receive_message.playerData.playerName)) {
                SetPlayerJoinRoom(receive_message.playerData);
            } else {
                SetPlayerWaitToSit();
            }
        }

        if(receive_message.messageType == EMessageType.WaitToSit.ToString()) {
            for(int i = 0; i < 4; i++) {
                if(seats[i].transform.Find("PlayerName").GetComponent<Text>().text == receive_message.playerData.playerName) {
                    return;
                }
                
                if(seats[i].transform.Find("PlayerName").GetComponent<Text>().text == "PlayerName: ") {
                    seats[i].transform.Find("PlayerName").GetComponent<Text>().text = receive_message.playerData.playerName;
                    SetCurrentPlayerStatus(PlayerStatus.None);
                    break;
                }
            }
        }
    }

    private void SetPlayerJoinRoom(PlayerData player_data) {
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
