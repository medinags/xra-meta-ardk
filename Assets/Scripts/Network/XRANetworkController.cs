using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class XRANetworkController : NetworkBehaviour
{
    public XRAPlatformManager PlatformManager;

    private void Awake()
    {

    }

    private void NetworkManager_OnClientDisconnectCallback(ulong obj)
    {
        Debug.Log("Client Disconnected: " + PlatformManager.CurrentPlatfromType.ToString());
    }

    private void NetworkManager_OnClientConnectedCallback(ulong obj)
    {
        Debug.Log("Client Connected: " + PlatformManager.CurrentPlatfromType.ToString());
    }

    void Start()
    {
        NetworkManager.OnClientConnectedCallback += NetworkManager_OnClientConnectedCallback;
        NetworkManager.OnClientDisconnectCallback += NetworkManager_OnClientDisconnectCallback;
        StartNetwork(PlatformManager.CurrentPlatfromType);
    }

    private void StartNetwork(PlatfromType platfromType)
    {
        switch (platfromType)
        {
            case PlatfromType.None:
                break;
            case PlatfromType.iPhone:
                NetworkManager.Singleton.StartClient();
                break;
            case PlatfromType.MetaQuest:
                NetworkManager.Singleton.StartHost();
                break;
        }
    }
}