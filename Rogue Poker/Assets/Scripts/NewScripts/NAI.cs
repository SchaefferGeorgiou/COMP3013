using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NAI : MonoBehaviour
{
    NBet opponentBets;
    NChipCount opponentChips;

    // Start is called before the first frame update
    void Start()
    {
        System.Random generate = new System.Random();
        int option = generate.Next(0, 4);
        switch (option)
        {
            case 1:
                opponentBets.AlterBet(0, 300, 22);
                opponentBets.AlterBet(1, 170, 17);
                opponentBets.AlterBet(2, 250, 5);
                break;

            case 2:
                opponentBets.AlterBet(0, 80, 3);
                opponentBets.AlterBet(1, 370, 5);
                opponentBets.AlterBet(2, 205, 12);
                break;

            case 3:
                opponentBets.AlterBet(0, 275, 15);
                opponentBets.AlterBet(1, 55, 2);
                opponentBets.AlterBet(2, 199, 9);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int[] getAllCounts()
    {
        return opponentBets.returnAllCounts();
    }

    public int[] getAllValues()
    {
        return opponentBets.returnAllValues();
    }

    public int getFoldedIndex()
    {
        return opponentBets.returnFoldIndex();
    }
}
