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
	//Remove because original DropZone no longer exists
    //public GameObject DropZone;
    public string Name;
	
	//probably need to find these at runtime rather than dragging prefabs
	public GameObject PlayerSlot1;
	public GameObject PlayerSlot2;
	public GameObject PlayerSlot3;
	public GameObject PlayerSlot4;
	public GameObject PlayerSlot5;
	public GameObject EnemySlot1;
	public GameObject EnemySlot2;
	public GameObject EnemySlot3;
	public GameObject EnemySlot4;
	public GameObject EnemySlot5;
	public List<GameObject> PlayerSockets = new List<GameObject>();
	public List<GameObject> EnemySockets = new List<GameObject>();

    [SyncVar]
    public int CardsLeftInLibrary = 0;

    [SyncVar]
    int CardsPlayed = 0;

    //[SyncVar]  // Make someCooldown sync
    //public SyncListInt CardIds = new SyncListInt();
	
	//Pasted from JJ code 
	static public List<int> CardIds = new List<int> { };


    public override void OnStartClient()
    {
        base.OnStartClient();

        PlayerArea = GameObject.Find("PlayerArea");
        OpponentArea = GameObject.Find("OpponentArea");
		//Removed because original DropZone no longer exists.
        //DropZone = GameObject.Find("DropZone");
		
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
		
		PlayerSlot1 = GameObject.Find("PlayerSlot1");
		PlayerSlot2 = GameObject.Find("PlayerSlot2");
		PlayerSlot3 = GameObject.Find("PlayerSlot3");
		PlayerSlot4 = GameObject.Find("PlayerSlot4");
		PlayerSlot5 = GameObject.Find("PlayerSlot5");
		EnemySlot1 = GameObject.Find("EnemySlot1");
		EnemySlot2 = GameObject.Find("EnemySlot2");
		EnemySlot3 = GameObject.Find("EnemySlot3");
		EnemySlot4 = GameObject.Find("EnemySlot4");
		EnemySlot5 = GameObject.Find("EnemySlot5");
		
		
        for (int i = 1; i < 55; i++)
        {
            CardIds.Add(i);
        }
	
		//not sure we need this if individual slots can be identified
		PlayerSockets.Add(PlayerSlot1);
		PlayerSockets.Add(PlayerSlot2);
		PlayerSockets.Add(PlayerSlot3);
		PlayerSockets.Add(PlayerSlot4);
		PlayerSockets.Add(PlayerSlot5);
		EnemySockets.Add(EnemySlot1);
		EnemySockets.Add(EnemySlot2);
		EnemySockets.Add(EnemySlot3);
		EnemySockets.Add(EnemySlot4);
		EnemySockets.Add(EnemySlot5);
		
		// Reset slots to Empty state when disconnecting / reconnecting host client
		for (int i = 0; i < PlayerSockets.Count; i++)
		{
			PlayerSockets[i].gameObject.tag = "EmptySlot";
			EnemySockets[i].gameObject.tag = "EmptySlot";
		}
    }     

    public void Awake()
    {
        Name = GameManager.NameGenerator();
    }

    [Server]
    public override void OnStartServer()
    {
        
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
			// added PlayerArea as placeholder since no slots needed
            RpcShowCard(Card, "Dealt Hand", PlayerArea);
            GameManager.UpdatePlayerText(CardsLeftInLibrary, Name);
    }


    public void PlayCard(GameObject Card, GameObject dropZone)
    {
        CmdPlayCard(Card, dropZone);
        CardsPlayed++;
        Debug.Log(CardsPlayed);
    }


    [Command]
    void CmdPlayCard(GameObject Card, GameObject dropZone)
    {
        RpcShowCard(Card, "Played", dropZone);
    }

	
	// Added parameter dropzone to facilitate showing enemy cards JRV20201013
    [ClientRpc]
    void RpcShowCard(GameObject Card, string type, GameObject dropZone)
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
			if(hasAuthority)
			{
				Debug.Log("slotNumber = " + dropZone + "PlayerSockets num = " + PlayerSockets.Count);
				Card.transform.SetParent(dropZone.transform, false);
				// added tag set
				dropZone.tag = "FullSlot";
			}
			// moved into if statement above
            //Card.transform.SetParent(DropZone.transform, false);
            if (!hasAuthority)
            {
				if(dropZone == PlayerSlot1)
				{
					Card.transform.SetParent(EnemySlot1.transform, false);
					EnemySlot1.tag = "FullSlot";
				}
				if(dropZone == PlayerSlot2)
				{
					Card.transform.SetParent(EnemySlot2.transform, false);
					EnemySlot2.tag = "FullSlot";
				}
				if(dropZone == PlayerSlot3)
				{
					Card.transform.SetParent(EnemySlot3.transform, false);
					EnemySlot3.tag = "FullSlot";
				}
				if(dropZone == PlayerSlot4)
				{
					Card.transform.SetParent(EnemySlot4.transform, false);
					EnemySlot4.tag = "FullSlot";
				}
				if(dropZone == PlayerSlot5)
				{
					Card.transform.SetParent(EnemySlot5.transform, false);
					EnemySlot5.tag = "FullSlot";
				}
				
				/*
				*****Switch doesn't appear to work with non-constants***********
				
				switch (dropZone)
				{
					case GameObject.Find("PlayerSlot1"):
						Card.transform.SetParent(EnemySlot1.transform, false);
						break;
					case PlayerSlot2:
						Card.transform.SetParent(EnemySlot2.transform, false);
						break;
					case PlayerSlot3:
						Card.transform.SetParent(EnemySlot3.transform, false);
						break;
					case PlayerSlot4:
						Card.transform.SetParent(EnemySlot4.transform, false);
						break;
					case PlayerSlot5:
						Card.transform.SetParent(EnemySlot5.transform, false);
						break;
				}
				*/
				
                Card.GetComponent<FlipCard>().Flip();
            }
        }
    }
	
	//Added public method for destroying card JRV20201014
	public void DestroyCard(GameObject card, GameObject dropZone)
	{
		CmdDestroyCard(card, dropZone);
	}
	
	//Added Cmd method for destroying card JRV20201014
	[Command]
	public void CmdDestroyCard(GameObject card, GameObject dropZone)
	{
		RpcDestroyCard(card, dropZone);
	}
	
	// Added Rpc method for destroying card JRV20201014
	// Maybe we don't want to do this and insetad move card to graveyard??
	// Fixed by checking for authority and clearing the corrected slots JRV20201016
	[ClientRpc]
    void RpcDestroyCard(GameObject card, GameObject dropZone)
    {
		GameObject.Destroy(card.gameObject);
	   
		if(hasAuthority)
		{
		   dropZone.tag = "EmptySlot";
		}
		if (!hasAuthority)
		{
			for(int i = 0; i < PlayerSockets.Count; i++)
			{
				if(dropZone == PlayerSockets[i].gameObject)
				{
					EnemySockets[i].gameObject.tag = "EmptySlot";
				}
				if(dropZone == EnemySockets[i].gameObject)
				{
					PlayerSockets[i].gameObject.tag = "EmptySlot";
				}					
			}
	   
		}
    }
}
