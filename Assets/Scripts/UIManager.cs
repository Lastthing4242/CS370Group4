using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class UIManager : NetworkBehaviour
{
    // Start is called before the first frame update
    public PlayerManager PlayerManager;
    public GameObject PlayerLibraryText;
    public GameObject OpponentLibraryText;

    public void UpdatePlayerText(int CardCount, int OpponentCount)
    {
        PlayerLibraryText.GetComponent<Text>().text = "Cards left: " + CardCount;
        OpponentLibraryText.GetComponent<Text>().text = "Cards left: " + OpponentCount;
    }


}
