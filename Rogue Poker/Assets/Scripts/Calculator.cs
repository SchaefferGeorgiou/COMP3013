using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Calculator : MonoBehaviour
{
    public NPlayer refPlayer;
    public NAI refAi;
    public NDealer refDealer;
    public NBet refBet;

    public UnityEvent PlayerWin;
    public UnityEvent OpponentWin;

    public TextMeshProUGUI PlayerWinningsTxt;
    public TextMeshProUGUI EnemyWinningsTxt;

    private int PlayerWinnings = 0;
    private int OpponentWinnings = 0;

    private int FoldIndex;

    public void displayCalLablel()
    {
        string option = "";
        switch (refAi.getRaiseIndex())
        {
            case 0:
                option = "Rock";
                break;
            case 1:
                option = "Paper";
                break;
            case 2:
                option = "Scissors";
                break;
        }
        refBet.setCallLabelText(option, refAi.getRaiseAmount());
    }

    public void Calculate()
    {
        FoldIndex = refPlayer.getFoldIndex(); //-1 = no fold, otherwise index = folded option
        int[] PlayerBets = refBet.returnAllValues();
        int[] OpponentBets = refAi.getAllValues();

        int dealer = refDealer.returnOption();

        int Bonus = 0;
        int OppBonus = 0;

        for (int x = 0; x < 3; x++) //x refers to player
        {
            for (int y = 0; y < 3; y++) //y = enemy
            {
                if(x != y) //don't compare matches
                {
                    // Want to compare Player Vs Dealer, Player Vs Opponent, Opponent Vs Dealer, Opponent Vs Player

                    //Player vs Opponent
                    if (Compare(x, y))
                    {
                        Bonus += 50;
                    }

                    if (Compare(x, dealer)) //P vs D
                    {
                        Bonus += 75;
                    }

                    if (Compare(y, x)) //E vs P
                    {
                        OppBonus += 50;
                    }

                    if (Compare(y, dealer)) //E vs D
                    {
                        OppBonus += 75;
                    }


                    if (PlayerBets[x] + Bonus > OpponentBets[y] + OppBonus)
                    {
                        if (x == FoldIndex)
                        {
                            //if the current option was folded
                            PlayerWinnings += (PlayerBets[x] + Bonus) - (OpponentBets[y] + OppBonus) / 2;
                        }
                        else
                        {
                            PlayerWinnings += (PlayerBets[x] + Bonus) - (OpponentBets[y] + OppBonus);
                        }
                    }
                    else
                    {
                        if (x == FoldIndex)
                        {
                            //if the current option was folded
                            OpponentWinnings += (OpponentBets[y] + OppBonus) - (PlayerBets[x] + Bonus) / 2;
                        }
                        else
                        {
                            OpponentWinnings += (OpponentBets[y] + OppBonus) - (PlayerBets[x] + Bonus);
                        }
                    }
                    OppBonus = 0;
                    Bonus = 0;
                }
            }
        }

        if (PlayerWinnings > OpponentWinnings)
        {
            PlayerWin.Invoke();

            PlayerWinningsTxt.text = "+£" + PlayerWinnings.ToString();
            EnemyWinningsTxt.text = "+£" + OpponentWinnings.ToString();
        }
        else
        {
            OpponentWin.Invoke();

            PlayerWinningsTxt.text = "+£" + PlayerWinnings.ToString();
            EnemyWinningsTxt.text = "+£" + OpponentWinnings.ToString();
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
