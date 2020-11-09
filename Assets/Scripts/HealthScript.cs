using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HealthScript : NetworkBehaviour
{
	public PlayerManager PlayerManager;
	public NetworkIdentity networkIdentity;
	
    private int Health = 100;
	private int InitialHealth = 100;
	
	public override void OnStartClient()
    {
        base.OnStartClient();
		
		NetworkIdentity networkIdentity = NetworkClient.connection.identity;
		PlayerManager = networkIdentity.GetComponent<PlayerManager>();	
	}
	
	public void setHealthTone()
	{
		float percent = (float)Health / (float)InitialHealth;
		float R = (float)(170 - percent * 120) / 255;
		float G = (float)(30 + percent * 120) / 255;
		float B = (float)(30 + percent * 25) / 255;
		gameObject.GetComponent<Image>().color = new Color(R,G,B, 255);
		Debug.Log("Color " + R + "," + G + "," + B);
		//gameObject.color = new Color(50, 150, 55);
		//gameObject.color = new Color(170, 30, 30);
		//(120, -120, -25)
		//gameObject.Color = new Color(R,G,B);
	}
	
	public void setHealth(int newHealth)
	{
		Health = newHealth;
		setHealthTone();
	}
	
	public int getHealth()
	{
		return Health;
	}
}
