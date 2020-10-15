using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Battle : NetworkBehaviour
{
	public GameManager GameManager;
	public PlayerManager PlayerManager;
	public NetworkIdentity networkIdentity;
	
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
	public List<GameObject> PlayerSlots = new List<GameObject>();
	public List<GameObject> EnemySlots = new List<GameObject>();
	
	private bool slotsLoaded = false;
	//Probably not. Better to group by Player/Enemy slots
	/*
	private List<GameObject> Slots3 = new List<GameObject>();
	private List<GameObject> Slots4 = new List<GameObject>();
	private List<GameObject> Slots5 = new List<GameObject>();
	*/
	
    // Start is called before the first frame update
    void Start()
    {	/*	
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		NetworkIdentity networkIdentity = NetworkClient.connection.identity;
		PlayerManager = networkIdentity.GetComponent<PlayerManager>();
		
		
		PlayerSlot1 = GameObject.Find("PlayerSlot1");
		PlayerSlot2 = GameObject.Find("PlayerSlot2");
		PlayerSlot3 = GameObject.Find("PlayerSlot3");
		PlayerSlot4= GameObject.Find("PlayerSlot4");
		PlayerSlot5 = GameObject.Find("PlayerSlot5");
		EnemySlot1 = GameObject.Find("EnemySlot1");
		EnemySlot2 = GameObject.Find("EnemySlot2");
		EnemySlot3 = GameObject.Find("EnemySlot3");
		EnemySlot4 = GameObject.Find("EnemySlot4");
		EnemySlot5 = GameObject.Find("EnemySlot5");	
		*/
		
		//Probably not. Better to group by Player/Enemy slots
		/*
		Slots1.Add(PlayerSlot1);
		Slots1.Add(EnemySlot1);
		Slots2.Add(PlayerSlot2);
		Slots2.Add(EnemySlot2);
		Slots3.Add(PlayerSlot3);
		Slots3.Add(EnemySlot3);
		Slots4.Add(PlayerSlot4);
		Slots4.Add(EnemySlot4);
		Slots5.Add(PlayerSlot5);
		Slots5.Add(EnemySlot5);
		*/
		
		/*
		Slots1.Add(PlayerSlot1);
		*/
    }
	
	//Copy from Start() method.
	// may need to be in here to find things after the game has launched
	
	public override void OnStartClient()
	{
		base.OnStartClient();
		
		//GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		//NetworkIdentity networkIdentity = NetworkClient.connection.identity;
		//PlayerManager = networkIdentity.GetComponent<PlayerManager>();
		
		// Weird -- needed to be in the Fight function.  Maybe not initilized yet??
		/*
		PlayerSlot1 = GameObject.Find("PlayerSlot1");
		PlayerSlot2 = GameObject.Find("PlayerSlot2");
		PlayerSlot3 = GameObject.Find("PlayerSlot3");
		PlayerSlot4= GameObject.Find("PlayerSlot4");
		PlayerSlot5 = GameObject.Find("PlayerSlot5");
		EnemySlot1 = GameObject.Find("EnemySlot1");
		EnemySlot2 = GameObject.Find("EnemySlot2");
		EnemySlot3 = GameObject.Find("EnemySlot3");
		EnemySlot4 = GameObject.Find("EnemySlot4");
		EnemySlot5 = GameObject.Find("EnemySlot5");	
		*/
		
		//Probably not. Better to group by Player/Enemy slots
		/*
		Slots1.Add(PlayerSlot1);
		Slots1.Add(EnemySlot1);
		Slots2.Add(PlayerSlot2);
		Slots2.Add(EnemySlot2);
		Slots3.Add(PlayerSlot3);
		Slots3.Add(EnemySlot3);
		Slots4.Add(PlayerSlot4);
		Slots4.Add(EnemySlot4);
		Slots5.Add(PlayerSlot5);
		Slots5.Add(EnemySlot5);
		
		
		//Slots1.Add(PlayerSlot1);
		//Slots2.Add(EnemySlot1);
	}
	
    // Update is called once per frame
	// Not Needed???
    void Update()
    {
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
		/*
		PlayerSlots.Add(PlayerSlot1);
		PlayerSlots.Add(PlayerSlot2);
		PlayerSlots.Add(PlayerSlot3);
		PlayerSlots.Add(PlayerSlot4);
		PlayerSlots.Add(PlayerSlot5);
		EnemySlots.Add(EnemySlot1);
		EnemySlots.Add(EnemySlot2);
		EnemySlots.Add(EnemySlot3);
		EnemySlots.Add(EnemySlot4);
		EnemySlots.Add(EnemySlot5);
		
		GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		networkIdentity = NetworkClient.connection.identity;
		PlayerManager = networkIdentity.GetComponent<PlayerManager>();
		*/
    }
	
	public void loadSlots()
	{
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
		
		PlayerSlots.Add(PlayerSlot1);
		PlayerSlots.Add(PlayerSlot2);
		PlayerSlots.Add(PlayerSlot3);
		PlayerSlots.Add(PlayerSlot4);
		PlayerSlots.Add(PlayerSlot5);
		EnemySlots.Add(EnemySlot1);
		EnemySlots.Add(EnemySlot2);
		EnemySlots.Add(EnemySlot3);
		EnemySlots.Add(EnemySlot4);
		EnemySlots.Add(EnemySlot5);
	
		
		slotsLoaded = true;
	}
	
	public void Fight()
	{
		if(!slotsLoaded)
		{
			loadSlots();
		}
		
		GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		NetworkIdentity networkIdentity = NetworkClient.connection.identity;
		PlayerManager = networkIdentity.GetComponent<PlayerManager>();
		
		for (int i = 0; i < PlayerSlots.Count; i++)
		{
			
			if(PlayerSlots[i].gameObject.tag == "FullSlot" && EnemySlots[i].gameObject.tag == "FullSlot")
			{
				Debug.Log("Child count for Player Slots " + i + "  " + PlayerSlots[i].transform.childCount + " before the fight " + PlayerSlots[i].gameObject.tag);
				Debug.Log("Child count for Enemy Slots " + i + "  " + EnemySlots[i].transform.childCount + " before the fight " + EnemySlots[i].gameObject.tag);
				
				Debug.Log("The Player Slots Are Full in Slots : " + i);
				Debug.Log(PlayerSlots[i].transform.GetChild(0).gameObject.GetComponent<CardStats>().CardHealth);
				
				int playerCardPower = PlayerSlots[i].transform.GetChild(0).gameObject.GetComponent<CardStats>().CardPower;
				int enemyCardPower = EnemySlots[i].transform.GetChild(0).gameObject.GetComponent<CardStats>().CardPower;
				int playerCardHealth = PlayerSlots[i].transform.GetChild(0).gameObject.GetComponent<CardStats>().CardHealth;
				int enemyCardHealth = EnemySlots[i].transform.GetChild(0).gameObject.GetComponent<CardStats>().CardHealth;
				
				Debug.Log("Slot " + i + " playerCardPower " + playerCardPower + " before fight");
				Debug.Log("Slot " + i + " playerCardHealth " + playerCardHealth + " before fight");
				Debug.Log("Slot " + i + " enemyCardPower " + enemyCardPower + " before fight");
				Debug.Log("Slot " + i + " enemyCardHealth " + enemyCardHealth + " before fight");
				
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
				
				if(playerCardHealth == 0)
				{
					PlayerManager.DestroyCard(PlayerSlots[i].transform.GetChild(0).gameObject, PlayerSlots[i].gameObject);
					EnemySlots[i].transform.GetChild(0).gameObject.GetComponent<CardStats>().CardHealth = enemyCardHealth;
				}
				if(enemyCardHealth == 0)
				{
					PlayerManager.DestroyCard(EnemySlots[i].transform.GetChild(0).gameObject, EnemySlots[i].gameObject);
					PlayerSlots[i].transform.GetChild(0).gameObject.GetComponent<CardStats>().CardHealth = playerCardHealth;
				}

				Debug.Log("Child count for Player Slots " + i + "  " + PlayerSlots[i].transform.childCount + "after the fight " + PlayerSlots[i].gameObject.tag);
				Debug.Log("Child count for Enemy Slots " + i + "  " + EnemySlots[i].transform.childCount + "after the fight " + EnemySlots[i].gameObject.tag);				
			}
			else // probably add some code to attack the other players health
			{
				Debug.Log("The Player Slots Are Empty in Slots : " + i);
				Debug.Log("Child count for Player Slots " + i + "  " + PlayerSlots[i].transform.childCount + "When empty tag = " + PlayerSlots[i].gameObject.tag);
				Debug.Log("Child count for Enemy Slots " + i + "  " + EnemySlots[i].transform.childCount + "When empty tag = " + EnemySlots[i].gameObject.tag);
				
			}
		}	
	}
	
}
