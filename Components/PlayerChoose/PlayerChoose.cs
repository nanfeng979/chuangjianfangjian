using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerChoose : MonoBehaviour
{
    public string playerName;
    public string sceneName;
    private Button button;

    void Start()
    {
        button = gameObject.AddComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    void Update()
    {
        
    }

    private void OnClick() {
        if(playerName == null) {
            return;
        }
        SetPlayerName(playerName);
        NextScene(sceneName);
    }

    private void SetPlayerName(string name) {
        PlayerManager playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        playerManager.SetPlayerName(name);
    }

    private void NextScene(string sceneName) {
        if(sceneName == null) {
            return;
        }
        SceneManager.LoadScene(sceneName);
    }
}
