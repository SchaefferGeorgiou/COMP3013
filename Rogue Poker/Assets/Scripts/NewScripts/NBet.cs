using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NBet : MonoBehaviour
{
    NPhase phases;

    private bool isPlayer;
    private int[] playerBet, playerNum;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AlterBet(int type, int value, int num)
    {
        //Sets a new value for the bets
        playerBet[type] = value;
        playerNum[type] = num;
    }

    public void CheckBetsMade()
    {
        //Checks that all the bets have none-zero values before changing phases
        bool betsMade = true;
        for (int i = 0; i < playerBet.Length; i++)
        {
            if (!(playerBet[i] > 0))
            {
                betsMade = false;
            }
        }

        if (isPlayer && betsMade)
        {
            switch (phases.getPhaseNum())
            {
                case 1:
                    phases.PhaseTwo();
                    break;
                case 2:
                    phases.PhaseThree();
                    break;
            }
        }

    }

    public bool BetValid(string betType, int betValue)
    {
        bool betValid = false;

        switch (betType) 
        {
            case "bet":
                if (betValue <= 500 && betValue >= 50)
                {
                    betValid = true;
                }
                break;

            case "raise":

                break;

            case "fold":

                break;
        }


        return betValid;
    }

    public int[] returnAllValues()
    {
        return playerBet;
    }   

    public int[] returnAllCounts()
    {
        return playerNum;
    }
}
