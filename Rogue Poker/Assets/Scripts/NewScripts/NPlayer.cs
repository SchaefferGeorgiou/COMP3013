using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class NPlayer : MonoBehaviour
{
    public NBet playerBets; //player's bet's value (in £)
    public NChipCount playerChips; //player's number of chips
    
    public int[] getAllBetsNums()
    {
        return playerBets.returnAllCounts();
    }

    public int[] getAllBetValues()
    {
        return playerBets.returnAllValues();
    }

    public int[] getTotalChipNums()
    {
        return playerChips.GetCount();
    }

    public NBet getPlayerBet()
    {
        return playerBets;
    }

    public int getFoldIndex()
    {
        return playerBets.returnFoldIndex();
    }

    public void AlterChipCounts()
    {
        playerChips.AlterCount(playerBets.returnBetChange());
    }

    public void resetGame()
    {
        int[] numTotals = { 4, 5, 8, 8, 10, 10 };
        playerChips.setCount(numTotals);
        playerBets.ResetBets();
        playerBets.refPhases.resetGame();
    }

}
