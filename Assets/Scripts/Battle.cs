﻿using System.Collections;
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
				
				// retrieve player stats
				int playerCardPower = PlayerManager.PlayerSockets[i].transform.GetChild(0).gameObject.GetComponent<CardStats>().CardPower;
				int enemyCardPower = PlayerManager.EnemySockets[i].transform.GetChild(0).gameObject.GetComponent<CardStats>().CardPower;
				int playerCardHealth = PlayerManager.PlayerSockets[i].transform.GetChild(0).gameObject.GetComponent<CardStats>().CardHealth;
				int enemyCardHealth = PlayerManager.EnemySockets[i].transform.GetChild(0).gameObject.GetComponent<CardStats>().CardHealth;
				
				Debug.Log("Slot " + i + " playerCardPower " + playerCardPower + " before fight");
				Debug.Log("Slot " + i + " playerCardHealth " + playerCardHealth + " before fight");
				Debug.Log("Slot " + i + " enemyCardPower " + enemyCardPower + " before fight");
				Debug.Log("Slot " + i + " enemyCardHealth " + enemyCardHealth + " before fight");
				
				// reduce each cards life along side the others attack (temp variables) until at least one is dead 
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
				if(playerCardHealth == 0)
				{
					PlayerManager.DestroyCard(PlayerManager.PlayerSockets[i].transform.GetChild(0).gameObject, PlayerManager.PlayerSockets[i].gameObject);
					PlayerManager.EnemySockets[i].transform.GetChild(0).gameObject.GetComponent<CardStats>().CardHealth = enemyCardHealth;
				}
				if(enemyCardHealth == 0)
				{
					PlayerManager.DestroyCard(PlayerManager.EnemySockets[i].transform.GetChild(0).gameObject, PlayerManager.EnemySockets[i].gameObject);
					PlayerManager.PlayerSockets[i].transform.GetChild(0).gameObject.GetComponent<CardStats>().CardHealth = playerCardHealth;
				}

				//Debug.Log("Child count for Player Slots " + i + "  " + PlayerManager.PlayerSockets[i].transform.childCount + "after the fight " + PlayerManager.PlayerSockets[i].gameObject.tag);
				//Debug.Log("Child count for Enemy Slots " + i + "  " + PlayerManager.EnemySockets[i].transform.childCount + "after the fight " + PlayerManager.EnemySockets[i].gameObject.tag);				
			}
			else // probably add some code to attack the other players health
			{
				//Debug.Log("The Player Slots Are Empty in Slots : " + i);
				//Debug.Log("Child count for Player Slots " + i + "  " + PlayerManager.PlayerSockets[i].transform.childCount + "When empty tag = " + PlayerManager.PlayerSockets[i].gameObject.tag);
				//Debug.Log("Child count for Enemy Slots " + i + "  " + PlayerManager.EnemySockets[i].transform.childCount + "When empty tag = " + PlayerManager.EnemySockets[i].gameObject.tag);				
			}
		}	
	}	
}
