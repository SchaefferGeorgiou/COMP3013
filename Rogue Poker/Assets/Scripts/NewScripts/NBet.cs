using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NBet : MonoBehaviour
{
    NPhase phases;

    public UnityEvent ChipCountChanged;

    private int currentOption;

    private bool isPlayer;
    private int[] playerBet, playerNum;
    private int[][] betNums;
    private int foldedIndex;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AlterBet(int option, int[] betNum)
    {
        //Sets a new value for the bets
        for (int i = 0; i < betNums.Length; i++)
        {
            betNums[option][i] = betNum[i];
            playerNum[option] += betNum[i];
        }

        playerBet[option] += betNum[0] * 100;
        playerBet[option] += betNum[1] * 50;
        playerBet[option] += betNum[2] * 20;
        playerBet[option] += betNum[3] * 10;
        playerBet[option] += betNum[4] * 5;
        playerBet[option] += betNum[5] * 1;

        ChipCountChanged.Invoke();
        setBetOption(option);

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
                break;
            }
        }

        if (isPlayer && betsMade)
        {
            switch (phases.getPhaseNum())
            {
                case 1:
                    phases.PhaseTwo();
                    break;
            }
        }

    }

    // Please call this method in NBet when folding
    public void setFoldIndex(int type)
    {
        foldedIndex = type;
    }

    //This returns the total value bet on each option rock / paper etc.
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


    //This returns all individual number of chips on a specific bet option 100s, 50s, 20s etc.
    public int[] returnBetNums()
    {
        return betNums[currentOption];
    }


    //Setting whether the bet is rock / paper / scissors
    public void setBetOption(int option)
    {
        currentOption = option;
    }
    public int getBetOption()
    {
        return currentOption;
    }
}
