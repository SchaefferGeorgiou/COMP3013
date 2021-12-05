using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NBet : MonoBehaviour
{
    NPhase phases;

    private bool isPlayer;
    private int[] playerBet, playerNum;
    private int foldedIndex;

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

    public void setFoldIndex(int type)
    {
        foldedIndex = type;
    }

    public int[] returnAllValues()
    {
        return playerBet;
    }   

    public int[] returnAllCounts()
    {
        return playerNum;
    }

    public int returnFoldIndex()
    {
        return foldedIndex;
    }
}
