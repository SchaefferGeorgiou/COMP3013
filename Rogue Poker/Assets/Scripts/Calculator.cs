using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Calculator : MonoBehaviour
{
    public Player refPlayer;
    public AI refAi;
    public Dealer refDealer;
    public Bet refBet;

    public UnityEvent PlayerWin;
    public UnityEvent OpponentWin;

    public void Calculate()
    {
        int[] PlayerBets = refBet.getAllBets();
        int[] OpponentBets = refAi.GetAllValues();

        int dealer = refDealer.getDeal();

        int Bonus = 0;
        int OppBonus = 0;

        int PlayerWinnings = 0;
        int OpponentWinnings = 0;

        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                if(x != y)
                {
                    // Want to compare Player Vs Dealer, Player Vs Opponent, Opponent Vs Dealer, Opponent Vs Player


                    //Player vs Opponent
                    if (Compare(x, y))
                    {
                        Bonus += 50;
                    }

                    if (Compare(x, dealer))
                    {
                        Bonus += 75;
                    }

                    if (Compare(y, x))
                    {
                        OppBonus += 50;
                    }

                    if (Compare(y, dealer))
                    {
                        OppBonus += 75;
                    }


                    if (PlayerBets[x] + Bonus > OpponentBets[y] + OppBonus)
                    {
                        PlayerWinnings += (PlayerBets[x] + Bonus) - (OpponentBets[y] + OppBonus);
                    }
                    else
                    {
                        OpponentWinnings += (OpponentBets[y] + OppBonus) - (PlayerBets[x] + Bonus);
                    }
                    OppBonus = 0;
                    Bonus = 0;
                }
            }
        }

        if (PlayerWinnings > OpponentWinnings)
        {
            PlayerWin.Invoke();
        }
        else
        {
            OpponentWin.Invoke();
        }
    }

    public bool Compare(int Player, int Opponent)
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
