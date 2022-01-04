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
//Singleton
    [System.Serializable]
    public class AllStacks
    {
        public ChipStack[] Stack;
    }

    public static AllStacks Instance;

    public AllStacks[] allChipStacks;

    //the string defining the type of UI panel
    private string type;
    //the player's bet
    private NBet refBet;
    //the player
    public NPlayer refPlayer;
    //the oppoenent
    public NAI refAI;

    //[SerializeField]
    //private ChipStack[][] AllStacks;

    //ints related to bet options
    //[SerializeField]
    private int totalBetNum, 
                totalBetValue, 
                maxBet, 
                maxNum, 
                minBet,
                opponentNum;

    private int[] referenceValues = { 100, 50, 20, 10, 5, 1 };

    //unity events for betting (in each phase)
    public UnityEvent closeBettingPanel;
    public UnityEvent displayResults;

    //text fields for describing UI elements
    public TextMeshPro maxBetValue; //when setting text, include "Max Bet = �" + int.toString
    public TextMeshPro maxNumChips;
    public TextMeshPro selectedChipValue;
    public TextMeshPro currentNumChips;
    public TextMeshPro currentBetValue; //when setting text, include "Total Bet = �" + int.toString

    //boolean to define whether betting panel is active
    private bool isActive;

    //UI elements for betting panel
    public GameObject[] incrementBtns; //needed?????????????
    public TextMeshPro[] numChipsBet;
    public TextMeshPro[] totalNumChips;

    private int[] currentBet = new int[5];
    private int selectedChip; //0-5, 100-1, index value for selection

    // Start is called before the first frame update
    void Start()
    {
        //setting the refBet to the player's bet
        refBet = refPlayer.getPlayerBet();
    }

    public void SetType(string betType)
    {
        if (isActive)
        {
            return;
        }
        //set whether raise, call or fold
        type = betType;
        isActive = true;
    }

    public void OpenPanel(int Option)
    {
        if (isActive)
        {
            return;
        }
        isActive = true;
        int[] currentBet = {0, 0, 0, 0, 0 };
        ChangeChipSelected(5);
        SetPlayerChips();
        UpdatePanel();

        refBet.setBetOption(Option);
        int[] tempValues = new int[3];
        switch (type)
        {

            case "bet":
                //setting the base values for a beginning bet
                minBet = 50;
                maxBet = 500;
                maxNum = 0;
                maxNumChips.SetText("---");
                maxBetValue.SetText("�" + maxBet.ToString());
                break;
            case "raise":
                //setting the base values for a raise bet
                //temporary array whose indices represent rock, paper, and scissors 
                tempValues = refBet.returnAllValues();
                //maxBet is half the original bet on a particular bubble (R, P, or S)
                //this line needs to be changed when NPlayer is complete
                maxBet = (tempValues[Option] / 2);
                maxNum = 0;
                minBet = 0;
                maxNumChips.SetText("---");
                maxBetValue.SetText(maxBet.ToString());
                break;
            case "call":
                //setting the base values for matching an opponent's raise
                opponentNum = refAI.getOpponentBets().returnRaisedNums().Sum();


                tempValues = refBet.returnAllValues();
                //this line needs to be changed when NPlayer is complete
                maxBet = (tempValues[Option] / 2);
                maxNum = opponentNum;
                maxNumChips.SetText(maxNum.ToString());
                maxBetValue.SetText(maxBet.ToString());
                break;
        }    
    }

    public void SetPlayerChips()
    {
        //getting the total number of chips the player has from nBet and updating the UI appropriately
        int[] temp = refBet.returnAllCounts();

        foreach (int i in temp)
        {
            totalNumChips[i].SetText("x" + temp[i].ToString());
        }
    }

    public void ValidateBet()
    {
        bool betValid = false;
        int betTotal = 0;
        int betNum = 0;

        foreach (int i in currentBet)
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
            if (type == "bet")
            {
                //This bit of code needs to alter the number chips bet on rock / paper / scissors passed through to bet script
                //see below code for example
                //refBet.AlterBet(totalBetValue,totalBetNum);
            }
            //If it's raising then runs the setRaisedNums method to store the number of chips for calling
            else if (type == "raise")
            {
                
                // raiseNums = new int[]
                //for(i < 6){
                // raiseNums[i] = textbox.text
                //}
                //refBet.setRaisedNums(raiseNums)
            }

            isActive = false;
            closeBettingPanel.Invoke();
        }
        else
        {
            Debug.Log("Bet is not Valid");
        }
    }

    public void IncrementBet()
    {
        //adds 1 chip to the current total bet
        currentBet[selectedChip] += 1;
        UpdatePanel();
    }

    public void DecrementBet()
    {
        if (currentBet[selectedChip] > 0)
        {
            //if there's at least 1 of this chip bet, then take 1 away
            currentBet[selectedChip] -= 1;
            UpdatePanel();
        }
    }

    public void UpdatePanel()
    {
        int totalNum = 0;
        int totalVal = 0;
        foreach (int i in currentBet)
        {
            //update the number of currently bet chips
            numChipsBet[i].SetText("x" + currentBet[i].ToString());

            totalNum += currentBet[i];
            totalVal += referenceValues[i] * currentBet[i];
        }

        currentBetValue.SetText("Total Bet = �" + totalVal.ToString());
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
                selectedChipValue.SetText("�100's");
            }
            else if (selectedChip == 1)
            {
                selectedChipValue.SetText("�50's");
            }
            else if (selectedChip == 2)
            {
                selectedChipValue.SetText("�20's");
            }
            else if (selectedChip == 3)
            {
                selectedChipValue.SetText("�10's");
            }
            else if (selectedChip == 4)
            {
                selectedChipValue.SetText("�5's");
            }
            else if (selectedChip == 5)
            {
                selectedChipValue.SetText("�1's");
            }
        }
    }

    public void SetBetRef(NBet Reference)
    {
        refBet = Reference;
    }
}
