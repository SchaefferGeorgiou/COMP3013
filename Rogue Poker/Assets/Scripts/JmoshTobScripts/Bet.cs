using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bet : MonoBehaviour
{

    //References To UI Elements NEEDED

    [SerializeField]
    private int playerRockValue, playerScissorsValue, playerPaperValue,
                playerRockChips, playerScissorsChips, playerPaperChips;

    private string playerFold, playerRaise;

    private string dealerChoice;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ConfirmBets(string type)
    {
        //for each case, note the individual sliders' totals such that those may be totalled into the above 'value' ints
        //Place this code above break
        switch (type)
        {
            case "Rock":
                break;
            case "Paper":
                break;
            case "Scissors":
                break;
        }
    }

    public void ConfirmAllBets()
    {

        if (playerRockValue >= 50 || playerPaperValue >= 50 || playerScissorsValue >= 50)
        {
            if(playerRockValue <= 500 || playerPaperValue <= 500 || playerScissorsValue <= 500)
            {
                // UI shifts to Phase 2
                DealerChoice();
            }
            else
            {
                //UI element that says you've bet too much
            }
        }
        else
        {
            //UI element that says you've bet too little
        }
    }

    //Use these methods on the fold buttons under the click event respectively
    void FoldRock()
    {
        playerFold = "Rock";
    }

    void FoldPaper()
    {
        playerFold = "Paper";
    }

    void FoldScissors()
    {
        playerFold = "Scissors";
    }


    int getPlayerRockChips()
    {
        return playerRockChips;
    }
    int getPlayerPaperChips()
    {
        return playerPaperChips;
    }
    int getPlayerScissorsChips()
    {
        return playerScissorsChips;
    }

    //following method(s) describe betting rules
    // - Max. £500 in single bubble
    // - Min. £50 in single bubble
    // - Max. Raise of half prior bet value in that bubble
    // - Call must match Raise in NUMBER of chips (not value)

    void DealerChoice()
    {
        System.Random generate = new System.Random();
        int choice = generate.Next(1, 4);

        switch (choice)
        {
            case 1:
                dealerChoice = "Rock";
                break;
            case 2:
                dealerChoice = "Paper";
                break;
            case 3:
                dealerChoice = "Scissors";
                break;
        }

        //Display the chips bet for each in the texts displays
    }

}
