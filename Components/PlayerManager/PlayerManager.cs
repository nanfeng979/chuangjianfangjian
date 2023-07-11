using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private PlayerData selfData = new PlayerData();

    void AWake()
    {
        
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        
    }

    private void Test() {
        MessageData message = new MessageData();
        message.type = EMessageType.JoinRoom.ToString();
        message.playerData = selfData;
        OperateSendMessage.Instance.SendMessage_(JsonConvert.SerializeObject(message));
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
