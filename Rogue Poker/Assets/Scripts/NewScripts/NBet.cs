using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NBet : MonoBehaviour
{
    public NPhase phases;

    public UnityEvent ChipCountChanged;

    private int currentOption;

    private bool isPlayer;
    private int[] playerBet, playerNum;
    private int[][] betNums;
    private int foldedIndex;
    private int[] raiseNums;

    private int[] referenceValues = { 100, 50, 20, 10, 5, 1 };

    public void AlterBet(int[] betNum)
    {
        //Sets a new value for the bets
        for (int i = 0; i < betNums.Length; i++)
        {
            betNums[currentOption][i] = betNum[i];

            playerNum[currentOption] += betNum[i];
            playerBet[currentOption] += betNum[i] * referenceValues[i];
        }

        ChipCountChanged.Invoke();
    }

    public void AlterBet(int option, int[] betNum)
    {

        setBetOption(option);
        //Sets a new value for the bets
        for (int i = 0; i < betNums.Length; i++)
        {
            betNums[currentOption][i] = betNum[i];

            playerNum[currentOption] += betNum[i];
            playerBet[currentOption] += betNum[i] * referenceValues[i];
        }

        ChipCountChanged.Invoke();
    }

    public void CheckBetsMade()
    {
        //Checks that all the bets have none-zero values before changing from phase 1 to 2
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
            phases.PhaseTwo();
        }

    }

    public void CheckCallMade()
    {
        bool callMade = false;
        for (int i = 0; i < raiseNums.Length; i++)
        {
            if (!(raiseNums[i] > 0))
            {
                callMade = true;
                break;
            }
        }

        if (isPlayer && callMade)
        {
            phases.PhaseThree();
        }
    }

    // Please call this method in NBet when folding
    public void setFoldIndex(int type)
    {
        foldedIndex = type;
    }

    public void setRaisedNums(int[] nums)
    {
        for (int i = 0; i < raiseNums.Length; i++)
        {
            raiseNums[i] = nums[i];
        }
        ChipCountChanged.Invoke();
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

    //Returns the Number of Chips used in the Call phase
    public int[] returnRaisedNums()
    {
        return raiseNums;
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
