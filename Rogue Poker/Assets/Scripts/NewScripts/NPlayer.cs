using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class NPlayer : MonoBehaviour
{
    public NBet playerBets; //player's bet's value (in £)
    private NChipCount playerChips; //player's number of chips
    private void Start()
    {
        playerChips = this.gameObject.AddComponent<NChipCount>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            /*int[] temp = playerChips.GetCount();
            for (int i = 0; i < 6; i++)
            {
                Debug.Log(temp[i]);
            }
            */
            AlterChipCounts();
            Debug.Log("BREK");
            /*
            int[] bleh = playerChips.GetCount();
            for (int i = 0; i < 6; i++)
            {
                Debug.Log(bleh[i]);
            }*/
        }
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

    public void resetGame()
    {
        int[] numTotals = { 3, 5, 10, 10, 20, 50 };
        playerChips.AlterCount(numTotals);

        playerBets.ResetBets();
        playerBets.refPhases.resetGame();
    }

}
