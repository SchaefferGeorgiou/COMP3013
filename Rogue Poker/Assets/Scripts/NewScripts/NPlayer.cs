using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class NPlayer : MonoBehaviour
{
    public NBet playerBets; //player's bet's value (in £)
    private NChipCount playerChips; //player's number of chips
    private NBetIndicator UIindicator; //UI variable
    private void Start()
    {
        playerChips = this.gameObject.AddComponent<NChipCount>();
    }
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

}
