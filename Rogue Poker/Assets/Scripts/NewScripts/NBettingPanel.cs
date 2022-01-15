using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;
using System.Linq;

public class NBettingPanel : MonoBehaviour
{
    //the string defining the type of UI panel
    private string type;
    //the player's bet
    public NBet refBet;
    //the player
    public NPlayer refPlayer;
    //the oppoenent
    public NAI refAI;

    //[SerializeField]
    //private ChipStack[][] AllStacks;

    //ints related to bet options
    //[SerializeField]
    private int maxBet, 
                maxNum, 
                minBet,
                opponentNum;

    private int[] referenceValues = { 100, 50, 20, 10, 5, 1 };

    //unity events for betting (in each phase)
    public UnityEvent closeBettingPanel;
    public UnityEvent displayResults;

    //text fields for describing UI elements
    public TextMeshPro maxBetValue;
    public TextMeshPro maxNumChips;
    public TextMeshPro selectedChipValue;
    public TextMeshPro currentNumChips;
    public TextMeshPro currentBetValue;

    //boolean to define whether betting panel is active
    private bool isActive;

    //UI elements for betting panel
    public TextMeshPro[] numChipsBet;
    public TextMeshPro[] totalNumChips;

    public TextMeshPro BetTypeLabel;
    private string[] options = { "Rock", "Paper", "Scissors" };

    private int[] currentBet = new int[6], tot = new int[6];
    private int selectedChip; //0-5, 100-1, index value for selection

    public void SetType(string betType)
    {
        if (isActive) return;
        //set whether raise, call or fold
        type = betType;
        isActive = true;
    }

    public void OpenPanel(int Option)
    {
        if (!isActive) return;
        //if option sent is -1, then get the opponents Raised option to use
        if (Option == -1) { Option = refAI.getRaiseIndex(); };

        refBet.setBetOption(Option);

        //set current bet equal to the saved bet, unless it#s null then set to defaul 0's
        currentBet = new int[6];
        int[] temp;
        for (int i = 0; i < 6; i++)
        {
            temp = refBet.returnBetNums();
            currentBet[i] = temp[i];
        }

        if (currentBet == null) { currentBet = new int[] { 0, 0, 0, 0, 0, 0 }; }

        ChangeChipSelected(5); //set selected to £1's
        SetPlayerChips(); 
        UpdatePanel(); //Update bettingPanel UI with info

        //Set label to show current selected option
        BetTypeLabel.SetText(type + ": " + options[Option]);

        int[] tempValues = new int[3];
        switch (type)
        {

            case "bet":
                //setting the base values for a beginning bet
                minBet = 50;
                maxBet = 500;
                maxNum = 0;
                maxNumChips.SetText("Min Bet: £50");
                maxBetValue.SetText("Max Bet: £" + maxBet.ToString());
                break;
            case "raise":
                //setting the base values for a raise bet
                //temporary array whose indices represent rock, paper, and scissors 
                tempValues = refBet.returnAllValues();
                //maxBet is half the original bet on a particular bubble (R, P, or S)
                //this line needs to be changed when NPlayer is complete
                maxBet = (tempValues[Option] + (tempValues[Option] / 2));
                maxNum = 0;
                minBet = 0;
                maxNumChips.SetText("");
                maxBetValue.SetText("Max Raised Bet: £" + maxBet.ToString());
                break;
            case "call":
                //setting the base values for matching an opponent's raise
                opponentNum = refAI.getOpponentBets().returnRaisedNums().Sum();
                tempValues = refBet.returnAllValues();
                //this line needs to be changed when NPlayer is complete
                maxBet = (tempValues[Option] / 2) + tempValues[Option];

                for (int i = 0; i < 6; i++)
                {
                    //calculate total number of chips bet
                    maxNum += currentBet[i];
                }

                maxNum += opponentNum;
                maxNumChips.SetText("Number Chips:" + maxNum.ToString());
                maxBetValue.SetText("Call Amount: £" + maxBet.ToString());
                break;
        }    
    }

    public void SetPlayerChips()
    {
        //getting the total number of chips the player has from nChipCount via nPlayer and updating the UI appropriately
        int[] temp = new int[6];
        temp = refPlayer.getTotalChipNums();
        
        for (int i = 0; i < 6; i++)
        {
            int a = temp[i], b = currentBet[i];

            tot[i] = a + b;
            totalNumChips[i].SetText("x" + tot[i].ToString());
        }
    }

    public void ValidateBet()
    {
        bool betValid = false;
        int betTotal = 0;
        int betNum = 0;

        for (int i = 0; i < 6; i++)
        {
            //calculate the total amount bet
            betTotal += currentBet[i] * referenceValues[i];
            //calculate total number of chips bet
            betNum += currentBet[i];
        }

        switch (type)
        {
            case "bet":
                if (betTotal <= 500 && betTotal >= 50)
                {
                    betValid = true;
                }
                break;
            case "raise":
                if (betTotal <= maxBet)
                {
                    betValid = true;
                }
                break;
            case "call":
                if (betTotal <= maxBet && betNum == maxNum)
                {
                    betValid = true;
                }
                break;
        }

        if (betValid)
        {
            if (type == "bet" || type == "call") //serve same purpose, chips are updated with new values and no need to differentiate
            {
                refBet.AlterBet(currentBet);

                if (type == "call") { refBet.refPhases.setPhaseNum(5); }//if calling, then ensure progress to next phase
            }
            //If it's raising then runs the setRaisedNums method to store the number of chips for calling
            else if (type == "raise")
            {
                refBet.setRaisedNums(currentBet);
            }

            isActive = false;
            closeBettingPanel.Invoke();
        }
        else
        {
            Debug.Log("Bet is not Valid");
        }
    }

    public void cancelBet()
    {
        isActive = false;

        currentBet = new int[6];
        int[] temp;
        for (int i = 0; i < 6; i++)
        {
            temp = refBet.returnBetNums();
            currentBet[i] = temp[i];
        }

        if (currentBet == null) { currentBet = new int[] { 0, 0, 0, 0, 0, 0 }; }
        refBet.AlterBet(currentBet);

        closeBettingPanel.Invoke();
    }

    public void IncrementBet()
    { 
        if (currentBet[selectedChip] >= tot[selectedChip]) return;
        //adds 1 chip to the current total bet
        currentBet[selectedChip] += 1;
        UpdatePanel();
    }

    public void DecrementBet()
    {
        //if there's at least 1 of this chip bet, then take 1 away
        if (currentBet[selectedChip] - 1 < 0) return;
        currentBet[selectedChip] -= 1;
        UpdatePanel();
    }

    public void UpdatePanel()
    {
        int totalNum = 0;
        int totalVal = 0;
        for (int i = 0; i < currentBet.Length; i++)
        {
            //update the number of currently bet chips
            numChipsBet[i].SetText("x" + currentBet[i].ToString());

            totalNum += currentBet[i];
            totalVal += referenceValues[i] * currentBet[i];
        }

        currentBetValue.SetText("Total Bet = £" + totalVal.ToString());
        currentNumChips.SetText("Total x" + totalNum.ToString() + " chips bet");
    }

    public void ChangeChipSelected(int index)
    {
        //0 = 100, 1 = 50.... 5 = 1
        if (index <= 5 && index >= 0)
        {
            selectedChip = index;

            if (selectedChip == 0)
            {
                selectedChipValue.SetText("£100's");
            }
            else if (selectedChip == 1)
            {
                selectedChipValue.SetText("£50's");
            }
            else if (selectedChip == 2)
            {
                selectedChipValue.SetText("£20's");
            }
            else if (selectedChip == 3)
            {
                selectedChipValue.SetText("£10's");
            }
            else if (selectedChip == 4)
            {
                selectedChipValue.SetText("£5's");
            }
            else if (selectedChip == 5)
            {
                selectedChipValue.SetText("£1's");
            }
        }
    }

    public void SetBetRef(NBet Reference)
    {
        refBet = Reference;
    }
}
