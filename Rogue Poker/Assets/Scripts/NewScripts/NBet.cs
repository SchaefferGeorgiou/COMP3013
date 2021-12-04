using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NBet : MonoBehaviour
{
    private bool ifPlayer;
    private int[] playerBet, playerNum;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AlterBet(int type, int value, int num)
    {
        playerBet[type] = value;
        playerNum[type] = num;
    }

    void CheckBetsMade()
    {
        bool betsMade = true;
        for (int i = 0; i < playerBet.Length; i++)
        {
            if (!(playerBet[i] > 0))
            {
                betsMade = false;
            }
        }

        if (betsMade && ifPlayer)
        {
            //phase2
        }
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
