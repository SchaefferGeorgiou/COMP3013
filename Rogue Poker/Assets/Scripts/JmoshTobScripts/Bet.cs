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

    [SerializeField]
    private int aiRockValue, aiScissorsValue, aiPaperValue,
                aiRockChips, aiScissorsChips, aiPaperChips;

    [SerializeField]
    private string playerFold, playerRaise;

    [SerializeField]
    private string aiFold, aiRaise;

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

    //following method(s) describe betting rules
    // - Max. £500 in single bubble
    // - Min. £50 in single bubble
    // - Max. Raise of half prior bet value in that bubble
    // - Call must match Raise in NUMBER of chips (not value)
    // - Call is optional

    public void ConfirmAllBets()
    {

        if (playerRockValue >= 50 || playerPaperValue >= 50 || playerScissorsValue >= 50)
        {
            if(playerRockValue <= 500 || playerPaperValue <= 500 || playerScissorsValue <= 500)
            {
                // UI shifts to Phase 2

                //We'll use a little bit of randomness; will need changing later
                System.Random generate = new System.Random();
                

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

    //Use these methods on the raise buttons under the click event respectively
    //"UISliders" is a catch-all term, not a variable
    public void RaiseRock()
    {
        /*
        if(Total of UISliders <= (playerRockValue / 2))
        {
            playerRaise = "Rock";
            playerRockValue += //total of UISliders
            playerRockChips += //total chips from UISliders
        }
        else
        {
            //UI element that notes the raise is too high in value
        }
        */
    }

    public void RaisePaper()
    {
        /*
        if(Total of UISliders <= (playerPaperValue / 2))
        {
            playerRaise = "Paper";
            playerPaperValue += //total value of UISliders
            playerPaperChips += //total chips from UISliders
        }
        else
        {
            //UI element that notes the raise is too high in value
        }
        */
    }

    public void RaiseScissors()
    {
        /*
        if(Total of UISliders <= (playerScissorsValue / 2))
        {
            playerRaise = "Scissors";
            playerScissorsValue += //total of UISliders
            playerScissorsChips += //total chips from UISliders
        }
        else
        {
            //UI element that notes the raise is too high in value
        }
        */
    }

    //Use these methods on the fold buttons under the click event respectively
    public void FoldRock()
    {
        playerFold = "Rock";
    }

    public void FoldPaper()
    {
        playerFold = "Paper";
    }

    public void FoldScissors()
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
