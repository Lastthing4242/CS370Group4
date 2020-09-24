using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Mirror;
using System;

public class PlayerManager : NetworkBehaviour
{
    public GameManager GameManager;
    public GameObject PlayerLibraryText;
    public GameObject OpponentLibraryText;
    public GameObject Card1;
    public GameObject Card2;
    public GameObject Card3;
    public GameObject Card4;
    public GameObject Card5;
    public GameObject Card6;
    public GameObject Card7;
    public GameObject Card8;
    public GameObject Card9;
    public GameObject Card10;
    public GameObject Card11;
    public GameObject Card12;
    public GameObject Card13;
    public GameObject Card14;
    public GameObject Card15;
    public GameObject Card16;
    public GameObject Card17;
    public GameObject Card18;
    public GameObject Card19;
    public GameObject Card20;
    public GameObject Card21;
    public GameObject Card22;
    public GameObject Card23;
    public GameObject Card24;
    public GameObject Card25;
    public GameObject Card26;
    public GameObject Card27;
    public GameObject Card28;
    public GameObject Card29;
    public GameObject Card30;
    public GameObject Card31;
    public GameObject Card32;
    public GameObject Card33;
    public GameObject Card34;
    public GameObject Card35;
    public GameObject Card36;
    public GameObject Card37;
    public GameObject Card38;
    public GameObject Card39;
    public GameObject Card40;
    public GameObject Card41;
    public GameObject Card42;
    public GameObject Card43;
    public GameObject Card44;
    public GameObject Card45;
    public GameObject Card46;
    public GameObject Card47;
    public GameObject Card48;
    public GameObject Card49;
    public GameObject Card50;
    public GameObject Card51;
    public GameObject Card52;
    public GameObject Card53;
    public GameObject Card54;
    public GameObject PlayerArea;
    public GameObject OpponentArea;
    public GameObject PlayerLibrary;
    public GameObject OpponentLibrary;
    public GameObject DropZone;
    public string Name;
    int CardsLeftInLibrary = 0;

    [SyncVar]
    int CardsPlayed = 0;



    public override void OnStartClient()
    {
        base.OnStartClient();

        PlayerArea = GameObject.Find("PlayerArea");
        OpponentArea = GameObject.Find("OpponentArea");
        DropZone = GameObject.Find("DropZone");
        Card1 = GameObject.Find("Card1");
        Card2 = GameObject.Find("Card2");
        Card3 = GameObject.Find("Card3");
        Card4 = GameObject.Find("Card4");
        Card5 = GameObject.Find("Card5");
        Card6 = GameObject.Find("Card6");
        Card7 = GameObject.Find("Card7");
        Card8 = GameObject.Find("Card8");
        Card9 = GameObject.Find("Card9");
        Card10 = GameObject.Find("Card10");
        Card11 = GameObject.Find("Card11");
        Card12 = GameObject.Find("Card12");
        Card13 = GameObject.Find("Card13");
        Card14 = GameObject.Find("Card14");
        Card15 = GameObject.Find("Card15");
        Card16 = GameObject.Find("Card16");
        Card17 = GameObject.Find("Card17");
        Card18 = GameObject.Find("Card18");
        Card19 = GameObject.Find("Card19");
        Card20 = GameObject.Find("Card20");
        Card21 = GameObject.Find("Card21");
        Card22 = GameObject.Find("Card22");
        Card23 = GameObject.Find("Card23");
        Card24 = GameObject.Find("Card24");
        Card25 = GameObject.Find("Card25");
        Card26 = GameObject.Find("Card26");
        Card27 = GameObject.Find("Card27");
        Card28 = GameObject.Find("Card28");
        Card29 = GameObject.Find("Card29");
        Card30 = GameObject.Find("Card30");
        Card31 = GameObject.Find("Card31");
        Card32 = GameObject.Find("Card32");
        Card33 = GameObject.Find("Card33");
        Card34 = GameObject.Find("Card34");
        Card35 = GameObject.Find("Card35");
        Card36 = GameObject.Find("Card36");
        Card37 = GameObject.Find("Card37");
        Card38 = GameObject.Find("Card38");
        Card39 = GameObject.Find("Card39");
        Card40 = GameObject.Find("Card40");
        Card41 = GameObject.Find("Card41");
        Card42 = GameObject.Find("Card42");
        Card43 = GameObject.Find("Card43");
        Card44 = GameObject.Find("Card44");
        Card45 = GameObject.Find("Card45");
        Card46 = GameObject.Find("Card46");
        Card47 = GameObject.Find("Card47");
        Card48 = GameObject.Find("Card48");
        Card49 = GameObject.Find("Card49");
        Card50 = GameObject.Find("Card50");
        Card51 = GameObject.Find("Card51");
        Card52 = GameObject.Find("Card52");
        Card53 = GameObject.Find("Card53");
        Card54 = GameObject.Find("Card54");
    }


    public void Awake()
    {
        Debug.Log("Name Check: ");
        Debug.Log(Name);
        Name = GameManager.NameGenerator();
        Debug.Log(Name);
    }

    [Server]
    public override void OnStartServer()
    {

    }


        [Command]
    public void CmdDealCards()
    {
        if ((CardsLeftInLibrary == 0))
        {
            GameManager.Shuffler<GameObject>();
            Debug.Log("We survived the grand shuffle");
            if (Name == "Bob")
            {
                CardsLeftInLibrary = GameManager.BobCards.Count;
                Debug.Log("Bob's if statement");
            }
            else if (Name == "Karen")
            {
                CardsLeftInLibrary = GameManager.KarenCards.Count;
                Debug.Log("Karen's if statement");
            }
        }
        if (Name == "Bob")
        {
            CardsLeftInLibrary = CardsLeftInLibrary - 1;
            GameObject Card = Instantiate(GameManager.BobCards[CardsLeftInLibrary], new Vector2(0, 0), Quaternion.identity);
            NetworkServer.Spawn(Card, connectionToClient);
            RpcShowCard(Card, "Dealt Hand");
            GameManager.UpdatePlayerText(CardsLeftInLibrary, Name);
        }
        else if (Name == "Karen")
        {
            CardsLeftInLibrary = CardsLeftInLibrary - 1;
            GameObject Card = Instantiate(GameManager.KarenCards[CardsLeftInLibrary], new Vector2(0, 0), Quaternion.identity);
            NetworkServer.Spawn(Card, connectionToClient);
            RpcShowCard(Card, "Dealt Hand");
            GameManager.UpdatePlayerText(CardsLeftInLibrary, Name);
        }
    }


    public void PlayCard(GameObject Card)
    {
        CmdPlayCard(Card);
        CardsPlayed++;
        Debug.Log(CardsPlayed);
    }


    [Command]
    void CmdPlayCard(GameObject Card)
    {
        RpcShowCard(Card, "Played");
    }


    [ClientRpc]
    void RpcShowCard(GameObject Card, string type)
    {
        if (type == "Dealt Hand")
        {
            if (hasAuthority)
            {
                Card.transform.SetParent(PlayerArea.transform, false);
            }
            else
            {
                Card.transform.SetParent(OpponentArea.transform, false);
                Card.GetComponent<FlipCard>().Flip();
            }
        }
        else if (type == "Played")
        {
            Card.transform.SetParent(DropZone.transform, false);
            if (!hasAuthority)
            {
                Card.GetComponent<FlipCard>().Flip();
            }
        }
    }
}
