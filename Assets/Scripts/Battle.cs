using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Battle : NetworkBehaviour
{
	public GameManager GameManager;
	public PlayerManager PlayerManager;
	public NetworkIdentity networkIdentity;

	public List<GameObject> PlayerSlots = new List<GameObject>();
	public List<GameObject> EnemySlots = new List<GameObject>();
	

	public int PlayerHealth;
	public int OpponentHealth;
	
    // Start is called before the first frame update
	// Doesnt seem to work when called here
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
		GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		NetworkIdentity networkIdentity = NetworkClient.connection.identity;
		PlayerManager = networkIdentity.GetComponent<PlayerManager>();
		
		for (int i = 0; i < PlayerManager.PlayerSockets.Count; i++)
		{
			// Determine if BOTH sockets are full
			if(PlayerManager.PlayerSockets[i].gameObject.tag == "FullSlot" && PlayerManager.EnemySockets[i].gameObject.tag == "FullSlot")
			{
				//Debug.Log("Child count for Player Slots " + i + "  " + PlayerManager.PlayerSockets[i].transform.childCount + " before the fight " + PlayerManager.PlayerSockets[i].gameObject.tag);
				//Debug.Log("Child count for Enemy Slots " + i + "  " + PlayerManager.EnemySockets[i].transform.childCount + " before the fight " + PlayerManager.EnemySockets[i].gameObject.tag);
				
				//Debug.Log("The Player Slots Are Full in Slots : " + i);
				//Debug.Log(PlayerManager.PlayerSockets[i].transform.GetChild(0).gameObject.GetComponent<CardStats>().CardHealth);
				
				// retrieve player stats as local variables
				int playerCardPower = PlayerManager.PlayerSockets[i].transform.GetChild(0).gameObject.GetComponent<CardStats>().CardPower;
				int enemyCardPower = PlayerManager.EnemySockets[i].transform.GetChild(0).gameObject.GetComponent<CardStats>().CardPower;
				int playerCardHealth = PlayerManager.PlayerSockets[i].transform.GetChild(0).gameObject.GetComponent<CardStats>().CardHealth;
				int enemyCardHealth = PlayerManager.EnemySockets[i].transform.GetChild(0).gameObject.GetComponent<CardStats>().CardHealth;
				
				Debug.Log("Slot " + i + " playerCardPower " + playerCardPower + " before fight");
				Debug.Log("Slot " + i + " playerCardHealth " + playerCardHealth + " before fight");
				Debug.Log("Slot " + i + " enemyCardPower " + enemyCardPower + " before fight");
				Debug.Log("Slot " + i + " enemyCardHealth " + enemyCardHealth + " before fight");
				
				// reduce each cards life along side the others attack (local variables) until at least one is dead 
				while(playerCardHealth > 0 && enemyCardHealth > 0)
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
				
				Debug.Log("Slot " + i + " playerCardPower " + playerCardPower + " after fight");
				Debug.Log("Slot " + i + " playerCardHealth " + playerCardHealth + " after fight");
				Debug.Log("Slot " + i + " enemyCardPower " + enemyCardPower + " after fight");
				Debug.Log("Slot " + i + " enemyCardHealth " + enemyCardHealth + " after fight");
				
				// Determine which or if both cards died and remove those cards, and modify the other cards life appropriately
				if(playerCardHealth == 0 && enemyCardHealth != 0)
				{
					PlayerManager.DestroyCard(PlayerManager.PlayerSockets[i].transform.GetChild(0).gameObject, PlayerManager.PlayerSockets[i].gameObject);
					// I think this needs to move to Rpc
					//PlayerManager.EnemySockets[i].transform.GetChild(0).gameObject.GetComponent<CardStats>().CardHealth = enemyCardHealth;
					//CmdSetCardHealth("Enemy", i, enemyCardHealth);
					PlayerManager.SetCardHealth("Enemy", i, enemyCardHealth);
					PlayerManager.SetOCS(PlayerManager.EnemySockets[i].transform.GetChild(0).gameObject);
				}
				if(enemyCardHealth == 0 && playerCardHealth != 0)
				{
					PlayerManager.DestroyCard(PlayerManager.EnemySockets[i].transform.GetChild(0).gameObject, PlayerManager.EnemySockets[i].gameObject);
					// I think this needs to move to Rpc
					//PlayerManager.PlayerSockets[i].transform.GetChild(0).gameObject.GetComponent<CardStats>().CardHealth = playerCardHealth;
					//CmdSetCardHealth("Player", i, playerCardHealth);
					PlayerManager.SetCardHealth("Player", i, playerCardHealth);
					PlayerManager.SetOCS(PlayerManager.PlayerSockets[i].transform.GetChild(0).gameObject);
				}
				// Add this to handle both cards dying.  Think not having this was causing bugs with single conditionals above (enemyCardHealth == 0)
				if(enemyCardHealth == 0 && playerCardHealth == 0)
				{
					PlayerManager.DestroyCard(PlayerManager.PlayerSockets[i].transform.GetChild(0).gameObject, PlayerManager.PlayerSockets[i].gameObject);
					PlayerManager.DestroyCard(PlayerManager.EnemySockets[i].transform.GetChild(0).gameObject, PlayerManager.EnemySockets[i].gameObject);
				}

				//Debug.Log("Child count for Player Slots " + i + "  " + PlayerManager.PlayerSockets[i].transform.childCount + "after the fight " + PlayerManager.PlayerSockets[i].gameObject.tag);
				//Debug.Log("Child count for Enemy Slots " + i + "  " + PlayerManager.EnemySockets[i].transform.childCount + "after the fight " + PlayerManager.EnemySockets[i].gameObject.tag);				
			}
			else // attack the other players health
			{
				//Debug.Log("The Player Slots Are Empty in Slots : " + i);
				//Debug.Log("Child count for Player Slots " + i + "  " + PlayerManager.PlayerSockets[i].transform.childCount + "When empty tag = " + PlayerManager.PlayerSockets[i].gameObject.tag);
				//Debug.Log("Child count for Enemy Slots " + i + "  " + PlayerManager.EnemySockets[i].transform.childCount + "When empty tag = " + PlayerManager.EnemySockets[i].gameObject.tag);				
				
				
				// Determine if only one socket is full - Player attack
				if(PlayerManager.PlayerSockets[i].gameObject.tag == "FullSlot" && PlayerManager.EnemySockets[i].gameObject.tag == "EmptySlot")
				{
					int health = PlayerManager.EnemyHealth.gameObject.GetComponent<HealthScript>().getHealth();
					health = health - PlayerManager.PlayerSockets[i].transform.GetChild(0).gameObject.GetComponent<CardStats>().CardPower;
					// I think this needs to move to Rpc
					PlayerManager.EnemyHealth.gameObject.GetComponent<HealthScript>().setHealth(health);
					PlayerManager.SetHealth(health, "EnemyHit");
					//PlayerManager.PlayerSockets[i].transform.GetChild(0).gameObject.GetComponent<HealthScript>().setPlayerHealth(health);
				}
				// Determine if only one socket is full - Player attack
				if(PlayerManager.PlayerSockets[i].gameObject.tag == "EmptySlot" && PlayerManager.EnemySockets[i].gameObject.tag == "FullSlot")
				{
					int health = PlayerManager.PlayerHealth.gameObject.GetComponent<HealthScript>().getHealth();
					health = health - PlayerManager.EnemySockets[i].transform.GetChild(0).gameObject.GetComponent<CardStats>().CardPower;
					// I think this needs to move to Rpc
					PlayerManager.PlayerHealth.gameObject.GetComponent<HealthScript>().setHealth(health);
					PlayerManager.SetHealth(health, "PlayerHit");
				}					
			}
		}
        GameManager.ChangeGameState("Deal");
    }
	
	// Moved to PlayerManager
	/*
	// Added networking methods to apply changes accross all players
	[Command]
	public void CmdSetCardHealth(string who, int cardIndex, int health)
	{
		RpcSetCardHealth(who, cardIndex, health);
	}
	
	[ClientRpc]
	public void RpcSetCardHealth(string who, int cardIndex, int health)
	{
		if(who == "Player")
		{
			PlayerManager.PlayerSockets[cardIndex].transform.GetChild(0).gameObject.GetComponent<CardStats>().CardHealth = health;
		}
		if(who == "Enemy")
		{
			PlayerManager.EnemySockets[cardIndex].transform.GetChild(0).gameObject.GetComponent<CardStats>().CardHealth = health;
		}
	}
	*/
}
