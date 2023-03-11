using System.Collections;
using System.Collections.Generic;
using System.Net;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ServerPanel : MonoBehaviour
{  
    private string currentScene = "StartScene";

    public Button joinButton;
    public TMP_InputField ipInput;

    private void Update()
    {
        SetIp();
    }

    public void SetIp()
    {
        if (ipInput.text != "")
        {
            joinButton.interactable = true;
            PlayerPrefs.SetString("GameIP", ipInput.text);
        }
        else
        {
            joinButton.interactable = false;
        }
    }

    public void HostGame()
    {
        PlayerPrefs.SetInt("Mode", 1);
        PlayerPrefs.SetString("GameIP", GetLocalIPAddress());
        SceneManager.LoadScene(currentScene);
    }

    public void JoinGame()
    {
        PlayerPrefs.SetInt("Mode", 2);
        SceneManager.LoadScene(currentScene);
    }

    public static string GetLocalIPAddress()
    {
        var host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            {
                return ip.ToString();
            }
            Debug.Log(ip);
        }
       
        throw new System.Exception("No network adapters with an IPv4 address in the system!");
    }
}
