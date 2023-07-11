using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private PlayerData selfData = new PlayerData();

    void AWake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        
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
