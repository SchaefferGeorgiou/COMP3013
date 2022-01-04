using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class NPlayer : MonoBehaviour
{
    private NBet playerBets; //player's bet's value (in £)
    private NChipCount playerChips; //player's number of chips
    private NBetIndicator UIindicator; //UI variable

    public int[] getAllCounts()
    {
        return playerBets.returnAllCounts();
    }

    public int[] getAllValues()
    {
        return playerBets.returnAllValues();
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
        playerChips.AlterCount(playerBets.returnBetNums());
    }

}
