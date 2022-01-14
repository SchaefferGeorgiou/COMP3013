using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class NBet : MonoBehaviour
{
    public NPhase refPhases;

    [Header ("Called when successfully updated player chip #")]
    public UnityEvent ChipCountChanged;

    public TextMeshPro callLabel;

    public TextMeshPro[] optionsText;

    private int currentOption;

    [SerializeField]
    private bool isPlayer;
    private int[] playerBet = new int[3], //total value of all bets
        playerNum = new int[3], //total number of chips bet
        previousBet = new int[6]; //the num of chips on the bet before being updated
    private int[][] betNums = new int[3][];
    private int foldedIndex;
    private int[] raiseNums = new int[6];

    private int[] referenceValues = { 100, 50, 20, 10, 5, 1 };

    private void Start()
    {
        ResetBets();
    }

    public void AlterBet(int[] betNum)
    {
        playerNum[currentOption] = 0;
        playerBet[currentOption] = 0;
        //Sets a new value for the bets
        for (int i = 0; i < 6; i++)
        {
            previousBet[i] = betNums[currentOption][i];

            betNums[currentOption][i] = betNum[i];

            playerNum[currentOption] += betNum[i];
            playerBet[currentOption] += betNum[i] * referenceValues[i]; 
        }

        optionsText[currentOption].SetText("£" + playerBet[currentOption].ToString()); //sets the label text to the bets value
        ChipCountChanged.Invoke();
    }

    public void AlterBet(int option, int[] betNum)
    {
        setBetOption(option);

        playerNum[currentOption] = 0;
        playerBet[currentOption] = 0;
        //Sets a new value for the bets
        for (int i = 0; i < 6; i++)
        {
            previousBet[i] = betNums[currentOption][i];

            betNums[currentOption][i] = betNum[i];

            playerNum[currentOption] += betNum[i];
            playerBet[currentOption] += betNum[i] * referenceValues[i];
        }

        optionsText[currentOption].SetText("£" + playerBet[currentOption].ToString()); //sets the label text to the bets value

        ChipCountChanged.Invoke();
    }

    public void CheckBetsMade()
    {
        Debug.Log("pressed");
        //Checks that all the bets have none-zero values before changing from phase 1 to 2
        bool betsMade = true;
        for (int i = 0; i < playerBet.Length; i++)
        {
            if (playerBet[i] == 0)
            {
                Debug.Log("bad");
                betsMade = false;
                break;
            }
        }
        Debug.Log("good");
        if (isPlayer && betsMade)
        {
            refPhases.PhaseTwo();
        }

        //Can use Else statement here to report that couldn't progress
        //Implement feedback in NPhase and use ref

    }

    // Please call this method in NBet when folding
    public void setFoldIndex(int type)
    {
        foldedIndex = type;
        //Tell phase that folded
        refPhases.Fold();
    }

    public void setRaisedNums(int[] nums)
    {
        for (int i = 0; i < raiseNums.Length; i++)
        {
            //RaisedNums hold amount Raised by for calculating min/max for Calls
            raiseNums[i] = nums[i] - betNums[currentOption][i]; //take original bet from raised bet to get just raise values
        }
        //Tell Phase script that Raised
        AlterBet(nums);
        refPhases.Raise();
    }

    public int[] returnBetChange()
    {
        int[] diff = new int[6];
        for (int i = 0; i < diff.Length; i++)
        {
            diff[i] = betNums[currentOption][i] - previousBet[i];
            previousBet[i] = betNums[currentOption][i]; //then reset previous to stop reppeat subtraction
        }
        return diff;
    }

    //This returns the total value bet on each option rock / paper etc.
    public int[] returnAllValues()
    {
        return playerBet;
    }   

    public int[] returnAllCounts()
    {
        return playerNum;
    }

    public int returnFoldIndex()
    {
        return foldedIndex;
    }

    //Returns the Number of Chips used in the Call phase
    public int[] returnRaisedNums()
    {
        return raiseNums;
    }

    //This returns all individual number of chips on a specific bet option 100s, 50s, 20s etc.
    public int[] returnBetNums()
    {
        return betNums[currentOption];
    }

    public int[][] returnAllBetNums()
    {
        return betNums;
    }

    //Setting whether the bet is rock / paper / scissors
    public void setBetOption(int option)
    {
        currentOption = option;
    }
    public int getBetOption()
    {
        return currentOption;
    }

    public void setCallLabelText(string option, int value)
    {
        callLabel.SetText("\n - Opponent Raised " + option + " by £" + value.ToString() + ".\n   Would you like to Call or Skip?");
    }

    public void ResetBets()
    {
        //method to reset bet values for new run
        playerNum = new int[] { 0, 0, 0 };
        playerBet = new int[] { 0, 0, 0 };
        betNums[0] = new int[] { 0, 0, 0, 0, 0, 0 };
        betNums[1] = new int[] { 0, 0, 0, 0, 0, 0 };
        betNums[2] = new int[] { 0, 0, 0, 0, 0, 0 };

        //previousBet = betNums[0];
        
        for (int i = 0; i < 6; i++)
        {
            previousBet[i] = betNums[0][i];
        }
    }
}
