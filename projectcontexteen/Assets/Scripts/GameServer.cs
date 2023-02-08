using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;

public class GameServer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<UnityTransport>().ConnectionData.Address = PlayerPrefs.GetString("GameIP");

        switch (PlayerPrefs.GetInt("Mode"))
        {
            case 1: NetworkManager.Singleton.StartHost();
                break;
            case 2: NetworkManager.Singleton.StartClient();
                break;
        }
    }
}
