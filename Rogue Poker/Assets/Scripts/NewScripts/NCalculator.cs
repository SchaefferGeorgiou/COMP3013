using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class NCalculator : MonoBehaviour
{
    private int dealerInt;
    private int bonus;
    private int opponentBonus;
    public NAI opponent;
    public NPlayer player;
    public NDealer dealer;

    private int FoldIndex;
    private int Dealer;

    public UnityEvent PlayerWin;
    public UnityEvent OpponentWin;

    public TextMeshPro PlayerWinningsTxt;
    public TextMeshPro EnemyWinningsTxt;

    // Start is called before the first frame update
    void Start()
    {
        PlayerWinningsTxt.SetText("");
        EnemyWinningsTxt.SetText("");
    }

    public void resetGame()
    {
        player.resetGame();
        opponent.resetGame();
        dealer.resetDealer();
    }

    public void AICall()
    {
        opponent.Call(player.playerBets.returnRaisedIndex() ,player.playerBets.returnRaisedNums());
    }

    //shows the user what the AI raised so that they can call them
    public void displayCalLablel()
    {
        string option = "";
        switch (opponent.getRaiseIndex())
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
        player.playerBets.setCallLabelText(option, opponent.getRaiseAmount());
    }

    public void Calculate()
    {
        FoldIndex = player.getFoldIndex(); //-1 = no fold, otherwise index = folded option
        Dealer = dealer.returnOption();

        int[] playerBets = player.getAllBetValues(); //value of each bet
        int[] opponentBets = opponent.getAllValues();

        int playerWinnings = 0;
        int opponentWinnings = 0;

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

                    if (CompareBets(x, Dealer)) //P vs D
                    {
                        bonus += 75;
                    }

                    if (CompareBets(y, Dealer)) //E vs D
                    {
                        opponentBonus += 75;
                    }


                    if (playerBets[x] + bonus > opponentBets[y] + opponentBonus)
                    {
                        if (x == FoldIndex)
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
                        if (x == FoldIndex)
                        {
                            //if the current option was folded
                            opponentWinnings += (opponentBets[y] + opponentBonus) - (playerBets[x] + bonus) / 2;
                        }
                        else
                        {
                            opponentWinnings += (opponentBets[y] + opponentBonus) - (playerBets[x] + bonus);
                        }
                    }
                    bonus = 0;
                    opponentBonus = 0;
                }
            }
        }

        if (playerWinnings > opponentWinnings)
        {
            PlayerWin.Invoke();

            PlayerWinningsTxt.text = "+£" + playerWinnings.ToString();
            EnemyWinningsTxt.text = "+£" + opponentWinnings.ToString();
        }
        else
        {
            OpponentWin.Invoke();

            PlayerWinningsTxt.text = "+£" + playerWinnings.ToString();
            EnemyWinningsTxt.text = "+£" + opponentWinnings.ToString();
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
