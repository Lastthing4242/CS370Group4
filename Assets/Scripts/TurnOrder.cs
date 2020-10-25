using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class TurnOrder : NetworkBehaviour
{
    public static Button TurnChanger;//button that you click to change the turn
    public PlayerManager PlayerManager;
    /*

    public static float TurnTime = 10f;//this sets all of the timers for the code, chaging this number changes all the timers
    public static float CurrentTime = -100f;//this will be the dynamic time variable
    public static bool CombatTimer = true;// this will set the combat timer's value inside of the update section
    public static int AttackPhase = 0;// this manages how many phases have been played, if it reaches two it will iniate the attack phase
    public static Text TurnText;//displays what turn or phase it is currently 
    public static Text TimerText;// displays timer
    
    public static bool PlayerOneClick = false;
    public static bool PlayerTwoClick = false;

    */


    public void Onclick()// progresses turn per click
    {
        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        PlayerManager = networkIdentity.GetComponent<PlayerManager>();
        PlayerManager.CmdProgressTurn();
    }

    /*

    //these allow player manager to access TurnOrders variables
    public int getAttackPhase()
    {
        return AttackPhase;
    }
    public bool getPlayerClickOne()
    {
        return PlayerOneClick;
    }
    public bool getPlayerClickTwo()
    {
        return PlayerTwoClick;
    }
    //these allow it to change them
    public void setAttackPhase(int newAttackPhase)
    {
        AttackPhase=newAttackPhase;
    }
    public void setPlayerClickOne(bool newPlayerClickOne)
    {
        PlayerOneClick=newPlayerClickOne;
    }
    public void setPlayerClickTwo(bool newPlayerClickTwo)
    {
        PlayerTwoClick=newPlayerClickTwo;
    }
    

    public void Update()
    {
        if (PlayerTwoClick||PlayerOneClick)
        {
            //decreases current time and displays it
            CurrentTime -= 1 * Time.deltaTime;
            if (CurrentTime > 0)
            {
                TimerText.text = "Time remaining:" + CurrentTime.ToString("f0");
            }


            if (AttackPhase == 1 && CurrentTime <= 0f && CurrentTime >= -30f)
            {
                AttackPhase++;
            }


            if (AttackPhase == 2)//checks that both players have hade a turn to play then plays the combat step
            {
                /*faux start function inside of the update that sets the timer for combat,
                the timer is more just for show until we have things happening in 
                attack phase to show we do have multiple phases*/
            /*    if (CombatTimer)
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
                    CurrentTime = -100f;
                    PlayerOneClick = false;
                    PlayerTwoClick = false;
                }

            }

        }
    }     */
}
