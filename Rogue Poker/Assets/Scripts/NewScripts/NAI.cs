using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NAI : MonoBehaviour
{
    NBet opponentBets;
    NChipCount opponentChips;

    private int raiseIndex;
    private int raiseAmount;

    // Start is called before the first frame update
    void Start()
    {
        System.Random generate = new System.Random();
        int option = generate.Next(0, 4);
        int[] nums;
        switch (option)
        {
            case 1:
                nums = new int[] { 0, 3, 0, 20, 0, 0 };
                opponentBets.AlterBet(0, nums);
                nums = new int[] { 0, 1, 5, 0, 4, 0 };
                opponentBets.AlterBet(1, nums);
                nums = new int[] { 2, 0, 0, 0, 0, 12 };
                opponentBets.AlterBet(2, nums);
                break;

            case 2:
                nums = new int[] { 2, 0, 1, 0, 0, 0 };
                opponentBets.AlterBet(0, nums);
                nums = new int[] { 0, 2, 2, 7, 1, 15 };
                opponentBets.AlterBet(1, nums);
                nums = new int[] { 0, 2, 5, 0, 10, 0 };
                opponentBets.AlterBet(2, nums);
                break;

            case 3:
                nums = new int[] { 0, 1, 0, 4, 0, 0 };
                opponentBets.AlterBet(0, nums);
                nums = new int[] { 0, 2, 3, 0, 0, 0 };
                opponentBets.AlterBet(1, nums);
                nums = new int[] { 5, 0, 0, 0, 0, 0 };
                opponentBets.AlterBet(2, nums);
                break;
        }
    }

    public void RaiseFold()
    {
        int[] bets = opponentBets.returnAllValues();
        int lowest = 2, highest = 0, lowestval = 49, highestVal = 501;
        //identify highest bet and lowest bet
        for (int i = 0; i < bets.Length; i++)
        {
            if (bets[i] > lowestval)
            {
                highest = i;
            }
            if (bets[i] < highestVal)
            {
                lowest = i;
            }
        }

        //Raising
        int[] nums = { 0, 0, 0, 0, 0, 0 };

        int dif = 0;
        double temp = highestVal / 2;
        //some pre-set partial raises depending on values. All leave some spare change
        if (highestVal > 450)
        {
            nums[0] = 2;
            nums[2] = 1;
            dif = (int)Math.Round(temp) - 220;
        }
        else if (highestVal > 400)
        {
            nums[0] = 2;
            dif = (int)Math.Round(temp) - 200;
        }
        else if (highestVal > 350)
        {
            nums[1] = 3;
            nums[2] = 1;
            dif = (int)Math.Round(temp) - 170;
        }
        else if (highestVal > 300)
        {
            nums[2] = 7;
            dif = (int)Math.Round(temp) - 140;
        }
        else if (highestVal > 250)
        {
            nums[0] = 1;
            nums[4] = 4;
            dif = (int)Math.Round(temp) - 120;
        }
        else if (highestVal > 200)
        {
            nums[3] = 9;
            dif = (int)Math.Round(temp) - 90;
        }
        else if (highestVal > 150)
        {
            nums[2] = 3;
            nums[4] = 2;
            dif = (int)Math.Round(temp) - 70;
        }
        else if (highestVal > 100)
        {
            nums[3] = 4;
            dif = (int)Math.Round(temp) - 40;
        }
        else if (highestVal > 50)
        {
            dif = (int)Math.Round(temp);
        }

        while (dif > 0)
        {
            //keep adding to raise until difference is made up
            if (dif - 50 >= 0)
            {
                nums[1] += 1;
                dif -= 50;
            }
            else if (dif - 20 >= 0)
            {
                nums[2] += 1;
                dif -= 20;
            }
            else if (dif - 10 >= 0)
            {
                nums[3] += 1;
                dif -= 10;
            }
            else if (dif - 5 >= 0)
            {
                nums[4] += 1;
                dif -= 5;
            }
            else if (dif - 1 >= 0)
            {
                nums[5] += 1;
                dif -= 1;
            }
        }

        //Identify which is highest and apply calculated Raise
        switch (highest)
        {//Somewhere here, need to notify UI and allow player to Call
            case 0:
                opponentBets.AlterBet(0, nums);
                break;

            case 1:
                opponentBets.AlterBet(1, nums);
                break;

            case 2:
                opponentBets.AlterBet(2, nums);
                break;
        }
        raiseIndex = highest;

        //Fold lowest valued bet
        opponentBets.setFoldIndex(lowest);
    }

    public void Call()
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

    public NBet getOpponentBets()
    {
        return opponentBets;
    }

    public int getRaiseIndex()
    {
        return raiseIndex;
    }

    public int getRaiseAmount()
    {
        int[] temp =  opponentBets.returnAllValues();
        return temp[raiseIndex];
    }
}
