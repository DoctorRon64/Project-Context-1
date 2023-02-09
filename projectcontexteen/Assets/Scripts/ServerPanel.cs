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

    bool JoinButtonState;
    public string myIpField = "";

    private void Awake()
    {
        JoinButtonState = false;
    }

    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));

        if (GUI.Button(new Rect((Screen.width / 2) - 150, (Screen.height / 2) - 50, 300, 30), "Host"))
        {
            HostGame();
        }

        if (JoinButtonState)
        {
            if (GUI.Button(new Rect((Screen.width / 2) - 150, (Screen.height / 2), 300, 30), "Join"))
            {
                JoinGame();
            }
        }

        myIpField = GUI.TextField(new Rect((Screen.width / 2) - 150, (Screen.height / 2) + 50, 300, 30), myIpField);


        GUILayout.EndArea();
    }

    private void Update()
    {
        SetIp();
    }

    public void SetIp()
    {
        if (myIpField != "")
        {
            PlayerPrefs.SetString("GameIP", myIpField);
            JoinButtonState = true;
            Debug.Log("you can join");
        }
        else
        {
            JoinButtonState = false;
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
