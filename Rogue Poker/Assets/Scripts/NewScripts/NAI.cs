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
                int[] nums = { 0, 2, 0, 20, 0, 0 };
                opponentBets.AlterBet(0, nums);
                nums = new int[] { 0, 0, 0, 17, 0, 0 };
                opponentBets.AlterBet(1, nums);
                nums = new int[] { 0, 5, 0, 0, 0, 0 };
                opponentBets.AlterBet(2, nums);
                break;

            case 2:
                //opponentBets.AlterBet(0, 80, 3);
                //opponentBets.AlterBet(1, 370, 5);
                //opponentBets.AlterBet(2, 205, 12);
                break;

            case 3:
                //opponentBets.AlterBet(0, 275, 15);
                //opponentBets.AlterBet(1, 55, 2);
                //opponentBets.AlterBet(2, 199, 9);
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
