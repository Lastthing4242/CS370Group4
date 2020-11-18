using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Battle : NetworkBehaviour
{
	public GameManager GameManager;
	public PlayerManager PlayerManager;
	public NetworkIdentity networkIdentity;
	
    // Start is called before the first frame update
	// Finding references doesnt seem to work when called here
    void Start()
    {	
		//GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		//NetworkIdentity networkIdentity = NetworkClient.connection.identity;
		//PlayerManager = networkIdentity.GetComponent<PlayerManager>();
    }

	// Updated this method to use the already defined slots and Lists from PlayerManager so as to not duplicate code.
	// Method compares cards that are across from one another and deal damage to one another concurrently.
	public void Fight()
	{	
		// declare here or error occurs.
		if(PlayerManager == null)
		{
			GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
			NetworkIdentity networkIdentity = NetworkClient.connection.identity;
			PlayerManager = networkIdentity.GetComponent<PlayerManager>();
		}
		//GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		//NetworkIdentity networkIdentity = NetworkClient.connection.identity;
		//PlayerManager = networkIdentity.GetComponent<PlayerManager>();
		
		for (int i = 0; i < PlayerManager.PlayerSockets.Count; i++)
		{
			// Determine if BOTH sockets are full
			if(PlayerManager.PlayerSockets[i].gameObject.tag == "FullSlot" && PlayerManager.EnemySockets[i].gameObject.tag == "FullSlot")
			{
				// retrieve player stats as local variables
				int playerCardPower = PlayerManager.PlayerSockets[i].transform.GetChild(0).gameObject.GetComponent<CardStats>().CardPower;
				int enemyCardPower = PlayerManager.EnemySockets[i].transform.GetChild(0).gameObject.GetComponent<CardStats>().CardPower;
				int playerCardHealth = PlayerManager.PlayerSockets[i].transform.GetChild(0).gameObject.GetComponent<CardStats>().CardHealth;
				int enemyCardHealth = PlayerManager.EnemySockets[i].transform.GetChild(0).gameObject.GetComponent<CardStats>().CardHealth;
				
				/*
				
				int playerCardId = PlayerManager.PlayerSockets[i].transform.GetChild(0).gameObject.GetComponent<CardStats>().Id;
				int enemyCardId = PlayerManager.EnemySockets[i].transform.GetChild(0).gameObject.GetComponent<CardStats>().Id;

				// Doesn't seem like we need these?
				//int PCBattlePower = playerCardPower;//these are here to not mess with the actual powers of the cards
				//int ECBattlePower = enemyCardPower;//they can be used instead of card health to determine when to end combat

				
				// ----------------------------------------3 CARD ABILITY--------------------------------------------------------
				// How does this differ from normal battle??
				if (playerCardId >= 5 && playerCardId <= 8)//this is the 3 card's ability to strike first, checking the player's side first.
                {
					if(enemyCardId >=5 && enemyCardId <= 8)
                    {
						break;
                    }
					else
                    {
						enemyCardHealth = enemyCardHealth - playerCardPower ;
						playerCardPower  = 0;
                    }
                }
				if (enemyCardId >= 5 && enemyCardId <= 8)//this is the 3 card's ability to strike first, now checking the enemy's side.
				{
					if (playerCardId >= 5 && playerCardId <= 8)
					{
						break;
					}
					else
					{
						playerCardHealth = playerCardHealth - enemyCardPower ;
						enemyCardPower  = 0;
					}
				}
				
				// -------------------------------------5 CARD ABILITY---------------------------------------------------------
				// This is the 5 cards ability to enhance attack power by 1 for each friendly face card
				//  These variables need to be used during battle - they are not currently now
				if(playerCardId >= 13 && playerCardId <= 16) // for player cards
				{
					for(int j = 0; j < PlayerManager.PlayerSockets.Count; j++)
					{
						if(PlayerManager.PlayerSockets[j].gameObject.tag == "FullSlot")
						{
							int otherCard = PlayerManager.PlayerSockets[j].transform.GetChild(0).gameObject.GetComponent<CardStats>().Id;
							if(otherCard >= 37 && otherCard <= 48)
							{
								playerCardPower++;
							}
						}
					}					
				}
				if(playerCardId >= 13 && playerCardId <= 16) // for opponent cards
				{
					for(int j = 0; j < PlayerManager.EnemySockets.Count; j++)
					{
						if(PlayerManager.EnemySockets[j].gameObject.tag == "FullSlot")
						{
							int otherCard = PlayerManager.EnemySockets[j].transform.GetChild(0).gameObject.GetComponent<CardStats>().Id;
							if(otherCard >= 37 && otherCard <= 48)
							{
								enemyCardPower++;
							}
						}
					}
				}
				
				
				
				// ---------------------------------------6 CARD ABILITY--------------------------------------------------
				if (playerCardId >= 17 && playerCardId <= 20)//This is the 6's ability to deal and recieve 2 less damage
				{
					playerCardPower  = playerCardPower  - 2;
					enemyCardPower  = enemyCardPower  - 2;
				}
				if (enemyCardId >= 17 && enemyCardId <= 20)//This is the 6's ability to deal and recieve 2 less damage
				{
					playerCardPower  = playerCardPower  - 2;
					enemyCardPower  = enemyCardPower  - 2;
				}
				
				
				
				
				// ---------------------------------------7 CARD ABILITY???----------------------------------------------
				// reduce each cards life along side the others attack (local variables) until at least one is dead
				// commented out for following battle exchange, but will probably come in handy (implementation of 7 cards).
				/*
				while (playerCardHealth > 0 && enemyCardHealth > 0)
				{
					if(playerCardPower > 0)
					{
						playerCardPower--;
						enemyCardHealth--;
					}
					if(enemyCardPower > 0)
					{
						enemyCardPower--;
						playerCardHealth--;
					}
				}
				*/
				
				
				
				// Alternate general battle exchange - (I thing more in line with what was intended)
				{
					playerCardHealth -= enemyCardPower;
					if(playerCardHealth < 0) playerCardHealth = 0;
					
					enemyCardHealth -= playerCardPower;
					if(enemyCardHealth < 0) enemyCardHealth = 0;
				}
				
				
				
				
				
				
				
				// -----------------------------------------AfterBattle------------------------------------------------------------------------------
				AfterBattle:
				
				// Determine which or if both cards died and remove those cards, and modify the other cards life appropriately
				if(playerCardHealth == 0 && enemyCardHealth != 0)
				{
					PlayerManager.DestroyCard(PlayerManager.PlayerSockets[i].transform.GetChild(0).gameObject, PlayerManager.PlayerSockets[i].gameObject);
					PlayerManager.SetCardHealth("Enemy", i, enemyCardHealth);
				}
				if(enemyCardHealth == 0 && playerCardHealth != 0)
				{
					PlayerManager.DestroyCard(PlayerManager.EnemySockets[i].transform.GetChild(0).gameObject, PlayerManager.EnemySockets[i].gameObject);
					PlayerManager.SetCardHealth("Player", i, playerCardHealth);
				}
				// Add this to handle both cards dying.  Think not having this was causing bugs with single conditionals above (enemyCardHealth == 0)
				if(enemyCardHealth == 0 && playerCardHealth == 0)
				{
					PlayerManager.DestroyCard(PlayerManager.PlayerSockets[i].transform.GetChild(0).gameObject, PlayerManager.PlayerSockets[i].gameObject);
					PlayerManager.DestroyCard(PlayerManager.EnemySockets[i].transform.GetChild(0).gameObject, PlayerManager.EnemySockets[i].gameObject);
				}
			}
			else // attack the other players health
			{				
				// Determine if only one socket is full - Player attack
				if(PlayerManager.PlayerSockets[i].gameObject.tag == "FullSlot" && PlayerManager.EnemySockets[i].gameObject.tag == "EmptySlot")
				{
					
					int health = PlayerManager.EnemyHealth.gameObject.GetComponent<HealthScript>().getHealth();
					Debug.Log("Get Health at " + health);
					health = health - PlayerManager.PlayerSockets[i].transform.GetChild(0).gameObject.GetComponent<CardStats>().CardPower;
					// Need to call this here, since Rpc calls don't happen until after client side calls are completed (it seems)
					PlayerManager.EnemyHealth.gameObject.GetComponent<HealthScript>().setHealth(health);
					Debug.Log("Call SetHealth()");
					PlayerManager.SetHealth(health, "EnemyHit");
					Debug.Log("Return from Call SetHealth()");
				}
				// Determine if only one socket is full - Enemy attack
				if(PlayerManager.PlayerSockets[i].gameObject.tag == "EmptySlot" && PlayerManager.EnemySockets[i].gameObject.tag == "FullSlot")
				{
					int health = PlayerManager.PlayerHealth.gameObject.GetComponent<HealthScript>().getHealth();
					health = health - PlayerManager.EnemySockets[i].transform.GetChild(0).gameObject.GetComponent<CardStats>().CardPower;
					// Need to call this here, since Rpc calls don't happen until after client side calls are completed (it seems)
					PlayerManager.PlayerHealth.gameObject.GetComponent<HealthScript>().setHealth(health);
					PlayerManager.SetHealth(health, "PlayerHit");
				}					
			}
		}
        GameManager.ChangeGameState("Deal");
    }
}
