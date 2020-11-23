using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Mirror;
using System;
using UnityEngine.SceneManagement;


public class PlayerManager : NetworkBehaviour
{
    public TurnOrder TurnOrder; //Not used
    public Battle battle;
    public GameManager GameManager;
    public GameObject PlayerLibraryText;
    public GameObject OpponentLibraryText;
	public GameObject PlayerHealth;
	public GameObject EnemyHealth;
    public bool HavePlayedCard = false;  //Not used
	public PlayerManager playerManager;  
	
	public GameObject CardHealth;
	public GameObject CardAttack;
    public bool CardPlayed = false;

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
    public static int gameStarting = 0;//when this hits 2 the game can start
    public static bool readyp1 = false;//player one has clicked start turn button
    public static bool readyp2 = false;//player two has clicked start turn button
    public GameObject NA;
	
	
	public bool played = false;
	
	//[SyncVar]
	static string gameState = "Playing";
	

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

	static public bool AlreadyMadeDeck = false;
    static public int CardsLeftInLibrary = 0;
	//static public int CardsLeftInOpponentLibrary = 0;
	static public List<int> CardIds = new List<int> { };

	
    [SyncVar]
    int CardsPlayed = 0;

    public override void OnStartClient()
    {
        base.OnStartClient();

        NA = GameObject.Find("NA");
        battle = NA.GetComponent<Battle>();
        TurnText = GameObject.Find("TurnText").GetComponent<Text>();
        PlayerArea = GameObject.Find("PlayerArea");
        OpponentArea = GameObject.Find("OpponentArea");
		PlayerLibraryText = GameObject.Find("PlayerLibraryText");
		OpponentLibraryText = GameObject.Find("OpponentLibraryText");		
		PlayerHealth = GameObject.Find("PlayerHealth");
		EnemyHealth = GameObject.Find("OpponentHealth");
        endTurn = GameObject.Find("endTurn");
        //TurnTimer = GameObject.Find("TurnTimer").GetComponent<Text>();

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
        if(AlreadyMadeDeck == false)
        {
            FillList();
        }
        for (int i = 0; i < 54; i++)
        {
			//This line was throwing error that was terminating the rest of this method
            //Debug.Log(CardIds[i]);
        }
		
		// Set initial health to 100 for both players in HealthScript and on Health gameObjects on screen
		// Should eventually get this value from some input?
		PlayerHealth.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Health\n100";
		PlayerHealth.gameObject.GetComponent<HealthScript>().setInitialHealth(100);
		EnemyHealth.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Health\n100";
		EnemyHealth.gameObject.GetComponent<HealthScript>().setInitialHealth(100);
		
		// Set initial cards left text to 27.
		// must be done on start client to update upon re-connect.
		// The number(27) is erroneous atm since cards appear to be comming out of single deck.
		PlayerLibraryText.GetComponent<Text>().text = "Cards Left\n27";
		OpponentLibraryText.GetComponent<Text>().text = "Cards Left\n27";
		
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
		
		// Reset Button text and played variable when disconnecting / reconnecting host client
		played = false;
		TurnText.text = "Start";
    }

    [Server]
    public void FillList()
    {
        for (int i = 1; i < 55; i++)
        {
            CardIds.Add(i);
        }
        AlreadyMadeDeck = true;
    }
	
    public void Awake()
    {
		Name = GameManager.NameGenerator();
    }

	
	// Couldn't get this code to work without the dead slot bug.  I think something to do with not reseting the played variable
    void Update()//this runs the timer in real time and controls card effects
    {
		/*
		if(GameManager.gameState == "Reset" && played == true)
		{
			played = false;
			GameManager.ChangeGameState();
		}
		*/
		
       
	   /*
        if (PlayerTwoClick || PlayerOneClick)
        {
			Debug.Log("PlayerOneClick : " + PlayerOneClick);
			Debug.Log("PlayerTwoClick : " + PlayerTwoClick);
            //decreases current time and displays it
            CurrentTime -= 1 * Time.deltaTime;
            if (CurrentTime > 0)
            {
                //TurnTimer.text = "Time remaining:" + CurrentTime.ToString("f0");
				TurnText.text = "" + CurrentTime.ToString("f0");
            }


            if (AttackPhase == 1 && CurrentTime <= 0f && CurrentTime >= -30f)
            {
                AttackPhase = 2;
            }


            if (AttackPhase == 2)//checks that both players have hade a turn to play then plays the combat step
            {
                //faux start function inside of the update that sets the timer for combat,
                //the timer is more just for show until we have things happening in 
                //attack phase to show we do have multiple phases
                if (CombatTimer)
                {
                    CurrentTime = TurnTime / 2f;
                    CombatTimer = false;
                }

                CurrentTime -= 1 * Time.deltaTime;

                if (TurnText.text != "ETB Triggers")
                {
                    TurnText.text = "ETB Triggers";
                }

                if (CurrentTime <= 0)//exits combat
                {
                    for (int i = 0; i < EnemySockets.Count; i++)//flips the cards so they can fight it out
                    {
                        //Debug.Log("Hit the loop");
                        if (EnemySockets[i].transform.childCount !=0)
                        {
							GameObject Card = EnemySockets[i].transform.GetChild(0).gameObject;
							
							// Flip and add OnCardStats only if card back is showing (i.e. first round on board);
							if(Card.GetComponent<Image>().sprite == Card.GetComponent<FlipCard>().CardRear)
							{
								Card.GetComponent<FlipCard>().Flip();
								
								//Add to create cardHealth and cardAttack on card
								GameObject CH = Instantiate(CardHealth, new Vector2(-30, -60), Quaternion.identity);
								CH.transform.SetParent(Card.transform, false);
								GameObject CA = Instantiate(CardAttack, new Vector2(30, 60), Quaternion.identity);
								CA.transform.SetParent(Card.transform, false);
								
								// Call for initial set of card stats on card.
								Card.gameObject.GetComponent<CardStats>().SetFullHealth();
								Card.gameObject.GetComponent<CardStats>().SetOnCardStats(); 
							}  
                        }
                    }
                    battle.Fight();// makes the fight script activate in player manager
                    CombatTimer = true;//rests the combat timer for further combat
                    AttackPhase = 0;//sets up for next attack phase
                    TurnText.text = " End Turn ";//changes button text back
                    TurnTimer.text = "...";
                    CurrentTime = -100f;
                    PlayerOneClick = false;
                    PlayerTwoClick = false;
                    CardPlayed = false;//makes sure the player can play a card
					Debug.Log("CardPlayed set to " + CardPlayed);
					assignAuthorityObj.GetComponent<NetworkIdentity>().AssignClientAuthority(this.GetComponent<NetworkIdentity>().connectionToClient);
                    DealCards();//draws each player a card
					assignAuthorityObj.GetComponent<NetworkIdentity>().RemoveClientAuthority(this.GetComponent<NetworkIdentity>().connectionToClient);
                }
            }
        }
		*/
    }
	
	//  New Game control methods---------------------------------------------------------------------------START
	
	public void ProgressTurn()
	{
		if(TurnText.text == "Start")
		{
			for(int i = 0; i < 3; i++)
			{
				DealCards();
			}
			TurnText.text = "End Turn";
		}
		else if(TurnText.text == "End Turn" && played)
		{
			TurnText.text = "Pressed";
			
			if(gameState == "Battle")
			{
				CmdProgressTurn();
				battle.Fight();		
				CmdResetPlayed();
				CmdChangeGameState();
			}
			else
			{
				CmdChangeGameState();
			}
		}	
	}
	
	[Command]
	void CmdChangeGameState()
	{
		if(gameState == "Playing")
		{
			RpcChangeGameState("Battle");
		}
		else if(gameState == "Battle")
		{
			RpcChangeGameState("Playing");
		}
	}
	
	[ClientRpc]
	void RpcChangeGameState(string newState)
	{
		gameState = newState;
	}

    [Command]
    public void CmdProgressTurn()
    {
		RpcFlipAndShow();
    }
	
	[ClientRpc]
	void RpcFlipAndShow()
	{
		for (int i = 0; i < EnemySockets.Count; i++)//flips the cards so they can fight it out
		{
			//Debug.Log("Hit the loop");
			if (EnemySockets[i].transform.childCount !=0)
			{
				GameObject Card = EnemySockets[i].transform.GetChild(0).gameObject;
				
				// Flip and add OnCardStats only if card back is showing (i.e. first round on board);
				if(Card.GetComponent<Image>().sprite == Card.GetComponent<FlipCard>().CardRear)
				{
					Card.GetComponent<FlipCard>().Flip();
					
					//Add to create cardHealth and cardAttack on card
					GameObject CH = Instantiate(CardHealth, new Vector2(-30, -60), Quaternion.identity);
					CH.transform.SetParent(Card.transform, false);
					GameObject CA = Instantiate(CardAttack, new Vector2(30, 60), Quaternion.identity);
					CA.transform.SetParent(Card.transform, false);
					
					// Call for initial set of card stats on card.
					Card.gameObject.GetComponent<CardStats>().SetFullHealth();
					Card.gameObject.GetComponent<CardStats>().SetOnCardStats(); 
				}  
			}
		}
	}
	
	[Command]
	void CmdResetPlayed()
	{
		RpcResetPlayed();
	}
	
	[ClientRpc]
	void RpcResetPlayed()
	{
		NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        playerManager = networkIdentity.GetComponent<PlayerManager>();
		playerManager.played = false;
		TurnText.text = "End Turn";
		playerManager.DealCards();	
	}
	
	//  New Game control methods----------------------------------------------------------------------------END
	
	   void DealCards()
    {
        CmdDealCards();
    }

    [Server]
    public override void OnStartServer()
    {
        
    }

    [Command]//helps comminicate on click to server
    public void CmdStartGame()
    {
        rpcStartGame();
    }

    [ClientRpc]//don't know why but this be working like this;
    void rpcStartGame()
    {

        if (hasAuthority)
        {
            if (!readyp1)
            {
                gameStarting++;
                readyp1 = true;
                //Debug.Log("Player one has pushed the button");
            }
        }

        else if (!hasAuthority)
        {
            if (!readyp2)
            {
                gameStarting++;
                readyp2 = true;
                //Debug.Log("Player two has pushed the button");
            }
        }
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

    public void CmdShuffler()
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
            CmdShuffler();
            CardsLeftInLibrary = GameManager.cards.Count;
        }
        do//Here's to hope.
        {
            CardsLeftInLibrary = CardsLeftInLibrary - 1;
        //There was a line that prevented errors in a worst case scenario. It's gone now, because it stopped the while loop from working.
		//It was there to prevent players from drawing from the library while all cards were in play.
        } while (!(Fetch(CardIds[CardsLeftInLibrary]).GetComponent<CardStats>().getInDeck()));
            //Debug.Log(CardsLeftInLibrary);
            GameObject Card = Instantiate(Fetch(CardIds[CardsLeftInLibrary]), new Vector2(0, 0), Quaternion.identity);
            NetworkServer.Spawn(Card, connectionToClient);
			Fetch(CardIds[CardsLeftInLibrary]).GetComponent<CardStats>().setInDeck(false);
			
			// REMOVED ONCARDSTATS() call
			
            // added PlayerArea as placeholder since no slots needed
            // should probably overload this function instead
            RpcShowCard(Card, "Dealt Hand", PlayerArea);
			
			// Removing this line since GameManager cannot make Remote Procedure Calls (the way its written)
            //GameManager.UpdatePlayerText(CardsLeftInLibrary, Name);
			
			//Make Rpc call instead...
			//Don't need Name - use Authority instead.
			RpcUpdateLibraryText(CardsLeftInLibrary);
    }
	
	[ClientRpc]
	void RpcUpdateLibraryText(int CardsLeft)
	{
		if(hasAuthority)
		{
			PlayerLibraryText.GetComponent<Text>().text = "Cards Left\n" + CardsLeft;
		}
		if (!hasAuthority)
		{
			OpponentLibraryText.GetComponent<Text>().text = "Cards Left\n" + CardsLeft;
		}
	}

	/*
    public void PlayCard(GameObject Card, GameObject dropZone)
    {
		Debug.Log("ARE WE GETTING HERE?");
		Debug.Log("Why is CardPlayed " + CardPlayed);
        if (CardPlayed == false)
        {
            CardPlayed = true;
            CmdPlayCard(Card, dropZone);
            CardsPlayed++;

            Debug.Log("CARDSPLAYED" + CardPlayed);
        }
        else
        {
			Debug.Log("NOTCARDSPLAYED?????????");
            Card.gameObject.GetComponent<DragDrop>().isDraggable = true;
            Card.transform.SetParent(PlayerArea.transform, false);

        }
    }
	*/
	
	// Modified conditional variable to played
	 public void PlayCard(GameObject Card, GameObject dropZone)
    {
        if (played == false)
        {
            CmdPlayCard(Card, dropZone);
			played = true;
        }
        else
        {
            Card.gameObject.GetComponent<DragDrop>().isDraggable = true;
            Card.transform.SetParent(PlayerArea.transform, false);
        }
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
				
				//Add to create cardHealth and cardAttack on card
				GameObject CH = Instantiate(CardHealth, new Vector2(-30, -60), Quaternion.identity);
				CH.transform.SetParent(Card.transform, false);
				GameObject CA = Instantiate(CardAttack, new Vector2(30, 60), Quaternion.identity);
				CA.transform.SetParent(Card.transform, false);
				
				// Call for initial set of card stats on card.
				Card.gameObject.GetComponent<CardStats>().SetFullHealth();
				Card.gameObject.GetComponent<CardStats>().SetOnCardStats();
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
				//Debug.Log("slotNumber = " + dropZone + "PlayerSockets num = " + PlayerSockets.Count);
				Card.transform.SetParent(dropZone.transform, false);
				// added tag set
				dropZone.tag = "FullSlot";
                
				
				// What is the point of this??
				
                if (dropZone.transform.childCount != 1)
                {
                    Destroy(dropZone.transform.GetChild(0).gameObject);
                    dropZone.tag = "EmptySlot";
                    dropZone.tag = "FullSlot";
                }
				
				//played = true;
                //CardPlayed = true;
            }
					
			if (!hasAuthority)
            {
				for(int i = 0; i < PlayerSockets.Count; i++)
				{
					if(dropZone == PlayerSockets[i].gameObject)
					{
						Card.transform.SetParent(EnemySockets[i].gameObject.transform, false);
						
						// Removed call to add OnCardStats
						// Moved to card flipper loop in Update() method
				
						// What is the point of this??
						
						EnemySockets[i].gameObject.tag = "FullSlot";
                        if (EnemySockets[i].transform.childCount != 1)
                        {
                            Destroy(EnemySockets[i].transform.GetChild(0).gameObject);
                        }
						
					}
                    //CardPlayed = true;
                }
		
                //Card.GetComponent<FlipCard>().Flip();
            }
        }
    }
	
	//Added public method for destroying card JRV20201014
	public void DestroyCard(GameObject card, GameObject dropZone)
	{
		CmdDestroyCard(card, dropZone);
        for(int i = 0; i < 54; i++)
        {
            if(card.GetComponent<CardStats>().getId() == GameManager.cards[i].GetComponent<CardStats>().getId())
            {
                GameManager.cards[i].GetComponent<CardStats>().setInDeck(true);
            }
        }
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
		if(card != null)
		{
			GameObject.Destroy(card.gameObject);
		}
		
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
	
    //changes health
	public void SetHealth(int newHealth, string whoHit)
	{
		CmdSetHealth(newHealth, whoHit);
	}
	
	[Command]
	public void CmdSetHealth(int newHealth, string whoHit)
	{
		RpcSetHealth(newHealth, whoHit);
	}
	

	[ClientRpc]
	public void RpcSetHealth(int newHealth, string whoHit)
    {
		// We need a case for a tie
        if (newHealth < 0)
        {
            newHealth = 0;
        }
        if (hasAuthority)
        {
            if (whoHit == "PlayerHit")
            {
                if (newHealth == 0)
                {
                    PlayerHealth.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Lose";
                    SceneManager.LoadScene("loseScreen");
                }
                else
                    PlayerHealth.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Health\n" + newHealth;
					PlayerHealth.gameObject.GetComponent<HealthScript>().setHealth(newHealth);
            }
            if (whoHit == "EnemyHit")
            {
                if (newHealth == 0)
                {
                    EnemyHealth.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Win";
                    SceneManager.LoadScene("winScreen");
                }
                else
                    EnemyHealth.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Health\n" + newHealth;
					EnemyHealth.gameObject.GetComponent<HealthScript>().setHealth(newHealth);
            }
        }
        if (!hasAuthority)
        {
            if (whoHit == "PlayerHit")
            {
                if (newHealth == 0)
                {
                    EnemyHealth.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Lose";
                    SceneManager.LoadScene("winScreen");
                }
                else
                    EnemyHealth.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Health\n" + newHealth;
					EnemyHealth.gameObject.GetComponent<HealthScript>().setHealth(newHealth);
            }
            if (whoHit == "EnemyHit")
            {
                if (newHealth == 0)
                {
                    PlayerHealth.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Lose";
                    SceneManager.LoadScene("loseScreen");
                }
                else
                    PlayerHealth.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Health\n" + newHealth;
					PlayerHealth.gameObject.GetComponent<HealthScript>().setHealth(newHealth);				
            }
        }
    }


    public void SetCardHealth(string who, int cardIndex, int health)
	{
		CmdSetCardHealth(who, cardIndex, health);
	}
	
		[Command]
	void CmdSetCardHealth(string who, int cardIndex, int health)
	{
		RpcSetCardHealth(who, cardIndex, health);
	}
	
	[ClientRpc]
	void RpcSetCardHealth(string who, int cardIndex, int health)
	{
		// check who called, then who was hit.
		// double check that card is present to avoid exceptions thrown.
		// Changed set dirrectly to setter method call with update SetOnCardStats() call included in cardStats().
		if(hasAuthority)
		{
			if(who == "Player")
			{
				if(PlayerSockets[cardIndex].transform.childCount != 0)
				{
					PlayerSockets[cardIndex].transform.GetChild(0).gameObject.GetComponent<CardStats>().setHealth(health);
				}
			}
			if(who == "Enemy")
			{
				if(EnemySockets[cardIndex].transform.childCount != 0)
				{
					EnemySockets[cardIndex].transform.GetChild(0).gameObject.GetComponent<CardStats>().setHealth(health);
				}			
			}
		}
		if(!hasAuthority)
		{
			if(who == "Player")
			{
				if(EnemySockets[cardIndex].transform.childCount != 0)
				{
					EnemySockets[cardIndex].transform.GetChild(0).gameObject.GetComponent<CardStats>().setHealth(health);
				}					
			}
			if(who == "Enemy")
			{		
				if(PlayerSockets[cardIndex].transform.childCount != 0)
				{
					PlayerSockets[cardIndex].transform.GetChild(0).gameObject.GetComponent<CardStats>().setHealth(health);
				}					
			}
		}		
	}
	
	
}
