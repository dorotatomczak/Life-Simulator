using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class NetworkManager_Custom : NetworkManager {


    void OnEnable()
    {
        //Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Lobby")
        {
            SetupMenuButtons();
            Debug.Log(0);
        }
        else
        {
            SetupSceneButtons();
            Debug.Log(1);
        }
    }
    /*private void OnSceneLoaded(int level)
    {
        if (level == 0)
        {
            SetupMenuButtons();
            Debug.Log(0);
        }
        else
        {
            SetupSceneButtons();
            Debug.Log(1);
        }
    }*/

    public void StartupHost()
    {
        
        SetPort();
        NetworkManager.singleton.StartHost();

    }

    public void JoinGame()
    {
        SetIPAddress();
        SetPort();
        NetworkManager.singleton.StartClient();
    }


    void SetPort()
    {
        NetworkManager.singleton.networkPort = 7778;
    }
    void SetIPAddress()
    {
        string ipAddress = GameObject.Find("InputFieldIP").transform.Find("Text").GetComponent<Text>().text;
        NetworkManager.singleton.networkAddress = ipAddress;
    }
    public void Disconnect() {
    }

   
    void SetupMenuButtons()
    {
        GameObject.Find("CreateGameButton").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("CreateGameButton").GetComponent<Button>().onClick.AddListener(StartupHost);

        GameObject.Find("JoinButton").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("JoinButton").GetComponent<Button>().onClick.AddListener(JoinGame);

    }

    void SetupSceneButtons()
    {
        GameObject.Find("DisconnectButton").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("DisconnectButton").GetComponent<Button>().onClick.AddListener(NetworkManager.singleton.StopHost);

    }
}
