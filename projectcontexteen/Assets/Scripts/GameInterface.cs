using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using TMPro;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;

public class GameInterface : MonoBehaviour
{
    GameObject manager;
    public GameObject CopyButton;
    public TMP_InputField ipInput;

    private void Awake()
    {
        //manager = GameObject.FindGameObjectWithTag("NetworkManager");

        //CopyButton.SetActive(manager.GetComponent<NetworkManager>().IsHost);
    }

    public void CopyIP()
    {
        ClipboardExtension.CopyToClipboard(ClipboardExtension.GetLocalIPAddress());
        ipInput.text = ClipboardExtension.GetLocalIPAddress();
    }


}




public static class ClipboardExtension
{
    /// <summary>
    /// Puts the string into the Clipboard.
    /// </summary>
    /// 

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

    public static void CopyToClipboard(this string str)
    {
        GUIUtility.systemCopyBuffer = str;
        Debug.Log(str);
    }
}