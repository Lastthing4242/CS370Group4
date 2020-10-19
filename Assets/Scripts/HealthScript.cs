using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    private int Health = 100;
	
	public void setHealth(int newHealth)
	{
		Health = newHealth;
	}
	
	public int getHealth()
	{
		return Health;
	}
}
