using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;
using UnityEngine.Events;

public class Bet : MonoBehaviour
{
    [SerializeField]
    private int[] PlayerValues; //stores current bets
    [SerializeField]
    private int[] PlayerNumber;

   // [SerializeField]
   // private int aiRockValue, aiScissorsValue, aiPaperValue,
   //             aiRockChips, aiScissorsChips, aiPaperChips;

    public TextMeshProUGUI[] PlayerValuesTxt;
    public TextMeshProUGUI[] PlayerNumberTxt; //Ui for displaying current bets

    [SerializeField]
    private string playerFold, playerRaise;

    [SerializeField]
    private string aiFold, aiRaise; //don't care fn

    private string dealerChoice;
    // Start is called before the first frame update
    public UnityEvent FinishPhase1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 3; i++)
        {
            PlayerValuesTxt[i].text = "£" + PlayerValues[i].ToString();
            PlayerNumberTxt[i].text = "x" + PlayerNumber[i].ToString();
        }
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

    void SecondPhaseConfirmBets()
    {

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
        return PlayerValues[0];
    }
    int getPlayerPaperChips()
    {
        return PlayerValues[1];
    }
    int getPlayerScissorsChips()
    {
        return PlayerValues[2];
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

    public void SetBet(int index, int value, int count)
    {
        PlayerValues[index] += value;
        PlayerNumber[index] += count;
    }

    public void ConfirmBets()
    {
        Debug.Log("hmmm");
        for (int i = 0; i < PlayerNumber.Length; i++)
        {
            if (PlayerNumber[i] == 0 || PlayerValues[i] == 0)
            {
                return; //something not bet on, quit 
            }
        }
        //everything bet on
        FinishPhase1.Invoke();
        Debug.Log("yay");
    }

}
