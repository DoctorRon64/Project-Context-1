using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;

public class GameInterface : MonoBehaviour
{
    GameObject manager;
    public GameObject CopyButton;

    private void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("NetworkManager");

        //CopyButton.SetActive(manager.GetComponent<NetworkManager>().IsHost);
    }

    public void CopyIP()
    {
        ClipboardExtension.CopyToClipboard(manager.GetComponent<UnityTransport>().ConnectionData.Address);
    }
}

public static class ClipboardExtension
{
    /// <summary>
    /// Puts the string into the Clipboard.
    /// </summary>
    public static void CopyToClipboard(this string str)
    {
        GUIUtility.systemCopyBuffer = str;
    }
}