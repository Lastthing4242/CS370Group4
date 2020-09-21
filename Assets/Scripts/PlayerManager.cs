using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerManager : NetworkBehaviour
{
    public UIManager UIManager;
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
    //public int ClientIdentifier = 0;

    List<GameObject> cards = new List<GameObject>();
    List<GameObject> PlayerDeck = new List<GameObject>();
    List<GameObject> OpponentDeck = new List<GameObject>();

    [SyncVar]
    int CardsPlayed = 0;

    [SyncVar]
    int CardsLeftInLibrary = 0;

    [SyncVar]
    int OpponentLibraryCount = 0;



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

    [Server]
    public override void OnStartServer()
    {
        cards.Add(Card1);
        cards.Add(Card2); 
        cards.Add(Card3);
        cards.Add(Card4);
        cards.Add(Card5);
        cards.Add(Card6);
        cards.Add(Card7);
        cards.Add(Card8);
        cards.Add(Card9);
        cards.Add(Card10);
        cards.Add(Card11);
        cards.Add(Card12);
        cards.Add(Card13);
        cards.Add(Card14);
        cards.Add(Card15);
        cards.Add(Card16);
        cards.Add(Card17);
        cards.Add(Card18);
        cards.Add(Card19);
        cards.Add(Card20);
        cards.Add(Card21);
        cards.Add(Card22);
        cards.Add(Card23);
        cards.Add(Card24);
        cards.Add(Card25);
        cards.Add(Card26);
        cards.Add(Card27);
        cards.Add(Card28);
        cards.Add(Card29);
        cards.Add(Card30);
        cards.Add(Card31);
        cards.Add(Card32);
        cards.Add(Card33);
        cards.Add(Card34);
        cards.Add(Card35);
        cards.Add(Card36);
        cards.Add(Card37);
        cards.Add(Card38);
        cards.Add(Card39);
        cards.Add(Card40);
        cards.Add(Card41);
        cards.Add(Card42);
        cards.Add(Card43);
        cards.Add(Card44);
        cards.Add(Card45);
        cards.Add(Card46);
        cards.Add(Card47);
        cards.Add(Card48);
        cards.Add(Card49);
        cards.Add(Card50);
        cards.Add(Card51);
        cards.Add(Card52);
        cards.Add(Card53);
        cards.Add(Card54);

        PlayerDeck.Add(Card1);
        PlayerDeck.Add(Card2);
        PlayerDeck.Add(Card3);
        PlayerDeck.Add(Card4);
        PlayerDeck.Add(Card5);
        PlayerDeck.Add(Card6);
        PlayerDeck.Add(Card7);
        PlayerDeck.Add(Card8);
        PlayerDeck.Add(Card9);
        PlayerDeck.Add(Card10);
        PlayerDeck.Add(Card11);
        PlayerDeck.Add(Card12);
        PlayerDeck.Add(Card13);
        PlayerDeck.Add(Card14);
        PlayerDeck.Add(Card15);
        PlayerDeck.Add(Card16);
        PlayerDeck.Add(Card17);
        PlayerDeck.Add(Card18);
        PlayerDeck.Add(Card19);
        PlayerDeck.Add(Card20);
        PlayerDeck.Add(Card21);
        PlayerDeck.Add(Card22);
        PlayerDeck.Add(Card23);
        PlayerDeck.Add(Card24);
        PlayerDeck.Add(Card25);
        PlayerDeck.Add(Card26);
        PlayerDeck.Add(Card27);

        OpponentDeck.Add(Card1);
        OpponentDeck.Add(Card2);
        OpponentDeck.Add(Card3);
        OpponentDeck.Add(Card4);
        OpponentDeck.Add(Card5);
        OpponentDeck.Add(Card6);
        OpponentDeck.Add(Card7);
        OpponentDeck.Add(Card8);
        OpponentDeck.Add(Card9);
        OpponentDeck.Add(Card10);
        OpponentDeck.Add(Card11);
        OpponentDeck.Add(Card12);
        OpponentDeck.Add(Card13);
        OpponentDeck.Add(Card14);
        OpponentDeck.Add(Card15);
        OpponentDeck.Add(Card16);
        OpponentDeck.Add(Card17);
        OpponentDeck.Add(Card18);
        OpponentDeck.Add(Card19);
        OpponentDeck.Add(Card20);
        OpponentDeck.Add(Card21);
        OpponentDeck.Add(Card22);
        OpponentDeck.Add(Card23);
        OpponentDeck.Add(Card24);
        OpponentDeck.Add(Card25);
        OpponentDeck.Add(Card26);
        OpponentDeck.Add(Card27);
    }


    [Command]
    public void CmdDealCards()
    {
        if ((CardsLeftInLibrary == 0) || (OpponentLibraryCount == 0))
        {
            Shuffler(cards, PlayerDeck, OpponentDeck); // Shuffles the deck, creates two smaller deck lists, each should have what the other does not.
            CardsLeftInLibrary = PlayerDeck.Count;
            OpponentLibraryCount = OpponentDeck.Count;
            Debug.Log("finishing this if statemnt by changing cards left in library value.");
        }
        if (hasAuthority)//isLocalPlayer)
        {
            CardsLeftInLibrary = CardsLeftInLibrary - 1;
            GameObject Card = Instantiate(PlayerDeck[CardsLeftInLibrary], new Vector2(0, 0), Quaternion.identity);
            NetworkServer.Spawn(Card, connectionToClient);
            RpcShowCard(Card, "Dealt Hand");
        }
        else if (!hasAuthority)//isClient)
        {
            OpponentLibraryCount = OpponentLibraryCount - 1;
            GameObject Card = Instantiate(OpponentDeck[OpponentLibraryCount], new Vector2(0, 0), Quaternion.identity);
            NetworkServer.Spawn(Card, connectionToClient);
            RpcShowCard(Card, "Dealt Hand");
        }
        UIManager.UpdatePlayerText(CardsLeftInLibrary, OpponentLibraryCount);
    }

    public void Shuffler<T>(List<T> list, List<T> playerList, List<T> OpponentList)//this is imperfect for some reason
    {
        System.Random random = new System.Random();
        int n = list.Count;
        while (n>1)
        {
            int k = random.Next(n);
            n--;
            T temp = list[k];
            list[k] = list[n];
            list[n] = temp;
            Debug.Log(list[n]);
        }
        for (int i = 0; i < list.Count; i++)
        {
            if (i < 27)
            {
                playerList[i] = list[i];
                //Debug.Log("PLAYERLIST: ");
                //Debug.Log(playerList[i]);
            }
            else
            {
                OpponentList[i - 27] = list[i];
                //Debug.Log("ENEMYLIST: ");
                //Debug.Log(OpponentList[i-27]);
            }
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
