using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NCalculator : MonoBehaviour
{
    private int dealerInt;
    private int bonus;
    private int opponentBonus;
    private NAI opponent;
    private NPlayer player;
    private NDealer dealer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Calculate()
    {
        int[] playerBets = player.getAllValues();
        int[] playerNums = player.getAllCounts();

        int[] opponentBets = opponent.getAllValues();
        int[] opponentNums = opponent.getAllCounts();

        int playerWinnings = 0;
        int opponentWinnings = 0;

        int foldIndex = 0;

        for (int x = 0; x < 3; x++) //x refers to player
        {
            for (int y = 0; y < 3; y++) //y = enemy
            {
                if (x != y) //don't compare matches
                {

                    bonus = 0;
                    opponentBonus = 0;
                    // Want to compare Player Vs Dealer, Player Vs Opponent, Opponent Vs Dealer, Opponent Vs Player

                    //Player vs Opponent
                    if (CompareBets(x, y)) //Player Wins Match Up
                    {
                        bonus += 50;
                    }
                    else  //Enemy Wins Match Up
                    {
                        opponentBonus += 50;
                    }

                    if (CompareBets(x, dealer.returnOption())) //P vs D
                    {
                        bonus += 75;
                    }
                    else
                    {
                        opponentBonus += 75;
                    }                        

                    //if (CompareBets(y, x)) //E vs P
                    //{
                    //    oppBonus += 50;
                    //}

                    //if (CompareBets(y, dealer.returnOption())) //E vs D
                    //{
                    //    oppBonus += 75;
                    //}


                    if (playerBets[x] + bonus > opponentBets[y] + opponentBonus)
                    {
                        if (x == foldIndex)
                        {
                            //if the current option was folded
                            playerWinnings += (playerBets[x] + bonus) - (opponentBets[y] + opponentBonus) / 2;
                        }
                        else
                        {
                            playerWinnings += (playerBets[x] + bonus) - (opponentBets[y] + opponentBonus);
                        }
                    }
                    else
                    {
                        if (x == foldIndex)
                        {
                            //if the current option was folded
                            opponentWinnings += (opponentBets[y] + opponentBonus) - (playerBets[x] + bonus) / 2;
                        }
                        else
                        {
                            opponentWinnings += (opponentBets[y] + opponentBonus) - (playerBets[x] + bonus);
                        }
                    }

                }
            }
        }
    }

    public bool CompareBets(int Player, int Opponent)
    {
        bool Return = false;

        if (Player == 0 && Opponent == 2)
        {
            Return = true;
        }
        else if (Player == 1 && Opponent == 0)
        {
            Return = true;
        }
        else if (Player == 2 && Opponent == 1)
        {
            Return = true;
        }

        return Return;
    }
}
