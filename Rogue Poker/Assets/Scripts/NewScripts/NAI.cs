using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class NAI : MonoBehaviour
{
    public NBet opponentBets;
    public NChipCount opponentChips;
    public TextMeshPro ifCalledLbl;

    private int raiseIndex;
    private int raiseAmount;

    public void resetGame()
    {
        int[] numTotals = { 4, 5, 8, 8, 10, 10 };
        opponentChips.setCount(numTotals);
        opponentBets.ResetBets();
        startGame();
    }

    public void startGame()
    {
        opponentBets.ResetBets();

        System.Random generate = new System.Random();
        int option = generate.Next(1, 5);
        int[] nums;
        switch (option)
        {
            case 1:
                nums = new int[] { 0, 1, 0, 20, 0, 0 };
                opponentBets.AlterBet(0, nums);
                nums = new int[] { 0, 1, 5, 0, 4, 0 };
                opponentBets.AlterBet(1, nums);
                nums = new int[] { 2, 0, 0, 0, 0, 12 };
                opponentBets.AlterBet(2, nums);
                break;

            case 2:
                nums = new int[] { 2, 0, 1, 0, 0, 0 };
                opponentBets.AlterBet(0, nums);
                nums = new int[] { 0, 0, 2, 7, 1, 15 };
                opponentBets.AlterBet(1, nums);
                nums = new int[] { 0, 1, 5, 0, 10, 0 };
                opponentBets.AlterBet(2, nums);
                break;

            case 3:
                nums = new int[] { 0, 0, 1, 4, 0, 5 };
                opponentBets.AlterBet(0, nums);
                nums = new int[] { 0, 2, 3, 0, 0, 0 };
                opponentBets.AlterBet(1, nums);
                nums = new int[] { 4, 0, 0, 0, 0, 0 };
                opponentBets.AlterBet(2, nums);
                break;

            case 4:
                nums = new int[] { 1, 0, 0, 0, 0, 0 };
                opponentBets.AlterBet(0, nums);
                nums = new int[] { 0, 3, 0, 5, 0, 0 };
                opponentBets.AlterBet(1, nums);
                nums = new int[] { 0, 0, 4, 0, 0, 0 };
                opponentBets.AlterBet(2, nums);
                break;
        }
    }

    public void RaiseFold()
    {
        int[] bets = opponentBets.returnAllValues();
        int lowest = 0, highest = 2, lowestval = bets[0], highestVal = bets[2];
        //identify highest bet and lowest bet
        for (int i = 0; i < bets.Length; i++)
        {
            if (bets[i] < lowestval)
            {
                lowest = i;
                lowestval = bets[i];
            }
            if (bets[i] > highestVal)
            {
                highest = i;
                highestVal = bets[i];
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
        else if (highestVal >= 50)
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

        int[][] allbets = opponentBets.returnAllBetNums();
        //add raise values to the original bet
        for (int i = 0; i < 6; i++)
        {
            int a = allbets[highest][i];
            nums[i] += a;
        }

        //Identify which is highest and apply calculated Raise
        opponentBets.setBetOption(highest);
        opponentBets.setRaisedNums(nums);
        raiseIndex = highest;

        //Fold lowest valued bet
        opponentBets.setFoldIndex(lowest);
    }

    public void Call(int index, int[] Raise)
    {
        bool called = false;
        if (index != getFoldedIndex())
        {
            int[] temp = getAllValues();
            int dif = temp[index] / 2;
            int[][] allChips = opponentBets.returnAllBetNums();

            int[] counts = getAllCounts();
            int totCount = 0;

            for (int i = 0; i < 3; i++) { totCount += counts[i]; }

            int[] referenceValues = { 100, 50, 20, 10, 5, 1 };
            int totNum = 0;

            for (int i = 0; i < 6; i++)
            {
                totNum += Raise[i];
            }

            //multi-stage check to see if want to call
            bool enough = false;
            System.Random generate = new System.Random();
            int a = generate.Next(1, 11);
            int b = generate.Next(0, 6);
            int c = generate.Next(5, 41);
            int oppTotal = allChips[index][5] + allChips[index][4] + allChips[index][3] + allChips[index][2] + allChips[index][1] + allChips[index][0];

            //if enough chips & chips raised is more than the random num difference
            if (oppTotal > totNum && totNum >= a-b) { enough = true; }
            //calculates a low probability for deciding not to call, which is influenced by the total value of that bet option
            double mod = 1 - ((500 / temp[index]) *b) * -1;
            if (enough && (100/(c+(int)Math.Round(mod))>= a * 2)) { called = true; }

            if (called)
            {
                int[] nums = { 0, 0, 0, 0, 0, 0 };
                int check = 0;
                while (dif > 0 && totNum > 0)
                {
                    check++;
                    //keep adding to raise until difference is made up
                    if (dif - 100 >= 0 && allChips[index][0] > 0)
                    {
                        nums[0] += 1;
                        dif -= 100;
                        allChips[index][0] -= 1;
                        totNum--;
                        check--;
                    }
                    else if (dif - 50 >= 0 && allChips[index][1] > 0)
                    {
                        nums[1] += 1;
                        dif -= 50;
                        allChips[index][1] -= 1;
                        totNum--;
                        check--;
                    }
                    else if (dif - 20 >= 0 && allChips[index][2] > 0)
                    {
                        nums[2] += 1;
                        dif -= 20;
                        allChips[index][2] -= 1;
                        totNum--;
                        check--;
                    }
                    else if (dif - 10 >= 0 && allChips[index][3] > 0)
                    {
                        nums[3] += 1;
                        dif -= 10;
                        allChips[index][3] -= 1;
                        totNum--;
                        check--;
                    }
                    else if (dif - 5 >= 0 && allChips[index][4] > 0)
                    {
                        nums[4] += 1;
                        dif -= 5;
                        allChips[index][4] -= 1;
                        check--;
                    }
                    else if (dif - 1 >= 0 && allChips[index][5] > 0)
                    {
                        nums[5] += 1;
                        dif -= 1;
                        allChips[index][5] -= 1;
                        totNum--;
                        check--;
                    }
                    if (check == 0) { break; } //pass without making a change = infinite loop somehow (-'ve numbers maybe?)
                }
                int[][] allbets = opponentBets.returnAllBetNums();
                //add raise values to the original bet
                for (int i = 0; i < 6; i++)
                {
                    int g = allbets[index][i];
                    nums[i] += g;
                }

                opponentBets.AlterBet(index, nums);
            }
        }

        //Input logic here
        //get raised nums from player bet, random chance not to call

        if (called) { ifCalledLbl.SetText("\n - Opponent Called your Raise,\n   Click to continue"); }
        else { ifCalledLbl.SetText("\n - Opponent didn't call your Raise,\n   Click to continue"); }
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
        int[] temp =  opponentBets.returnRaisedNums();
        int total = 0;

        for (int i = 0; i < 6; i++)
        {
            total += temp[i];
        }

        return total;
    }
}
