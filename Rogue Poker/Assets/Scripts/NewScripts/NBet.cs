using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NBet : MonoBehaviour
{
    NPhase phases;

    private bool isPlayer;
    private int[] playerBet, playerNum;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AlterBet(int type, int value, int num)
    {
        playerBet[type] = value;
        playerNum[type] = num;
    }

    public void CheckBetsMade()
    {
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
                    
                    break;
            }
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
