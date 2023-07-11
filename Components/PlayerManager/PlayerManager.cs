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
            case PlayerStatus.Ready:
                ReadyStatus();
                break;
            case PlayerStatus.Play:
                break;
        }
    }

    private void ReadyStatus() {
        MessageData send_message = new MessageData();
        send_message.messageType = EMessageType.JoinRoom.ToString();
        send_message.playerData = selfData;
        OperateSendMessage.Instance.SendMessage_(JsonConvert.SerializeObject(send_message));
    }

    public void SetPlayerStatus(PlayerStatus status)
    {
        currentPlayerStatus = status;
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
