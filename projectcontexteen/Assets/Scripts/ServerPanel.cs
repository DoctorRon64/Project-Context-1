using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ServerPanel : MonoBehaviour
{
    public Button joinButton;
    public TMP_InputField ipInput;

    public void SetIp()
    {
        if (ipInput.text != "")
        {
            PlayerPrefs.SetString("GameIP", ipInput.text);
            joinButton.interactable = true;
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
        SceneManager.LoadScene("Game");
    }

    public void JoinGame()
    {
        PlayerPrefs.SetInt("Mode", 2);
        SceneManager.LoadScene("Game");
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
        }

        throw new System.Exception("No network adapters with an IPv4 address in the system!");
    }
}
