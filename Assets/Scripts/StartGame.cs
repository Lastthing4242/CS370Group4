using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class StartGame : NetworkBehaviour
{

    public PlayerManager PlayerManager;

    public void Onclick()
    {
        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        PlayerManager = networkIdentity.GetComponent<PlayerManager>();
        PlayerManager.CmdStartGame();
    }
}

