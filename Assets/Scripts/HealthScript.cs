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
    private int Health;
	private int InitialHealth;
	
	public void setHealthTone()
	{	
		float percent = (float)Health / (float)InitialHealth;
		//float R = (float)(170 - percent * 120) / 255;
		//float G = (float)(30 + percent * 120) / 255;
		//float B = (float)(30 + percent * 25) / 255;
		float R = (float)(160 - percent * 30) / 255;
		float G = (float)(0 + percent * 130) / 255;
		float B = (float)(0 + percent * 130) / 255;
		gameObject.GetComponent<Image>().color = new Color(R,G,B, 255);
	}
	
	public void setHealth(int newHealth)
	{
		Health = newHealth;
		setHealthTone();
	}
	
	public void setInitialHealth(int newHealth)
	{
		Health = newHealth;
		InitialHealth = newHealth;
		setHealthTone();
	}
	
	public int getHealth()
	{
		return Health;
	}
}
