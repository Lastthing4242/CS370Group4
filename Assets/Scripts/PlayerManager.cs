﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Mirror;
using System;

public class PlayerManager : NetworkBehaviour
{
    public TurnOrder TurnOrder;
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
    public GameObject endTurn;
    public Text TurnText;
    public static float CurrentTime = 0f;//this will be the dynamic time variable
    public Text TurnTimer;

    public string Name;
    public static bool PlayerOneClick = false;
    public static bool PlayerTwoClick = false;
    public static bool CombatTimer = true;//this sets a short timer for combat
    static float TurnTime = 10f;//this sets all of the timers for the code, chaging this number changes all the timers
    public static int AttackPhase = 0;// this manages how many phases have been played, if it reaches two it will iniate the attack phase

    [SyncVar]
    int CardsPlayed = 0;

    [SyncVar]
    public int CardsLeftInLibrary = 0;

    [SyncVar]  // Make someCooldown sync
    public SyncListInt CardIds = new SyncListInt();

    public override void OnStartClient()
    {
        base.OnStartClient();


        TurnText = GameObject.Find("TurnText").GetComponent<Text>();
        PlayerArea = GameObject.Find("PlayerArea");
        OpponentArea = GameObject.Find("OpponentArea");
        DropZone = GameObject.Find("DropZone");
        endTurn = GameObject.Find("endTurn");
        TurnTimer = GameObject.Find("TurnTimer").GetComponent<Text>();
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
        for (int i = 1; i < 55; i++)
        {
            CardIds.Add(i);
        }
    }

    void Update()//this runs the timer in real time
    {
        if (PlayerTwoClick || PlayerOneClick)
        {
            //decreases current time and displays it
            CurrentTime -= 1 * Time.deltaTime;
            if (CurrentTime > 0)
            {
                TurnTimer.text = "Time remaining:" + CurrentTime.ToString("f0");
            }


            if (AttackPhase == 1 && CurrentTime <= 0f && CurrentTime >= -30f)
            {
                AttackPhase = 2;
            }


            if (AttackPhase == 2)//checks that both players have hade a turn to play then plays the combat step
            {
                /*faux start function inside of the update that sets the timer for combat,
                the timer is more just for show until we have things happening in 
                attack phase to show we do have multiple phases*/
                if (CombatTimer)
                {
                    CurrentTime = TurnTime / 2f;
                    CombatTimer = false;
                }

                CurrentTime -= 1 * Time.deltaTime;

                if (TurnText.text != " Combat ocurring... ")
                {
                    TurnText.text = " Combat ocurring... ";
                }

                if (CurrentTime <= 0)//exits combat
                {
                    CombatTimer = true;//rests the combat timer for further combat
                    AttackPhase = 0;
                    TurnText.text = " End Turn ";
                    TurnTimer.text = "...";
                    CurrentTime = -100f;
                    PlayerOneClick = false;
                    PlayerTwoClick = false;
                }

            }

        }



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


    [Command]//helps comminicate on click to server
    public void CmdProgressTurn()
    {
        rpcRunTurn();
    }

    [ClientRpc]//don't know why but this be working like this;
    void rpcRunTurn()
    {
        if (hasAuthority)
        {
            if (!PlayerOneClick)
            {
                AttackPhase++;
                PlayerOneClick = true;
                CurrentTime = TurnTime;

            }
        }


        else if (!hasAuthority)
        {
            if (!PlayerTwoClick)
            {
                AttackPhase++;
                PlayerTwoClick = true;
                CurrentTime = TurnTime;

            }
        }

    }



    public void Shuffler<GameObject>()
    {
        System.Random random = new System.Random();
        int n = CardIds.Count;
        while (n > 1)
        {
            int k = random.Next(n);
            n--;
            int temp = CardIds[k];
            CardIds[k] = CardIds[n];
            CardIds[n] = temp;
        }
    }

    public GameObject Fetch(int num)
    {
        GameObject card = GameManager.cards[num - 1].GetComponent<CardStats>().getCard();
        return card;
    }


    [Command]
    public void CmdDealCards()
    {
        if ((CardsLeftInLibrary == 0))
        {
            Shuffler<GameObject>();
            if (Name == "Bob")
            {
                CardsLeftInLibrary = GameManager.cards.Count;
            }
            else if (Name == "Karen")
            {
                CardsLeftInLibrary = GameManager.cards.Count;
            }
        }
        CardsLeftInLibrary = CardsLeftInLibrary - 1;
        GameObject Card = Instantiate(Fetch(CardIds[CardsLeftInLibrary]), new Vector2(0, 0), Quaternion.identity);
        NetworkServer.Spawn(Card, connectionToClient);
        RpcShowCard(Card, "Dealt Hand");
        GameManager.UpdatePlayerText(CardsLeftInLibrary, Name);
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

