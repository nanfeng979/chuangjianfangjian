using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private PlayerData selfData = new PlayerData();
    private PlayerStatus currentPlayerStatus;

    void AWake()
    {
        
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);

        currentPlayerStatus = PlayerStatus.None;
    }

    void Update()
    {
        switch (currentPlayerStatus)
        {
            case PlayerStatus.None:
                break;
            case PlayerStatus.JoinRoom:
                JoinRoomStatus();
                break;
            case PlayerStatus.WaitToSit:
                WaitToSitStatus();
                break;
            case PlayerStatus.Ready:
                break;
            case PlayerStatus.Play:
                break;
        }
    }

    private void JoinRoomStatus() {
        SendMessageWithSelfStatus(EMessageType.JoinRoom);
    }

    private void WaitToSitStatus() {
        SendMessageWithSelfStatus(EMessageType.WaitToSit);
    }

    private void SendMessageWithSelfStatus(EMessageType self_status) {
        MessageData send_message = new MessageData();
        send_message.messageType = self_status.ToString();
        send_message.playerData = selfData;
        OperateSendMessage.Instance.SendMessage_(JsonConvert.SerializeObject(send_message));
    }

    public void SetPlayerStatus(PlayerStatus status)
    {
        currentPlayerStatus = status;
        selfData.playerStatus = status.ToString();
    }

    public void SetPlayerName(string name)
    {
        selfData.playerName = name;
    }

    public string GetPlayerName()
    {
        return selfData.playerName;
    }
}
