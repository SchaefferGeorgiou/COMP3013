using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;

public class NBettingPanel : MonoBehaviour
{
    //the string defining the type of UI panel
    private string type;
    //the player's bet
    private NBet refBet;
    //the player
    private NPlayer refPlayer;

    //array of the values of individual chips
    private readonly int[] chipValues = {100, 50, 20, 10, 5, 1};

    //ints related to bet options
    [SerializeField]
    private int totalBetNum, 
                totalBetValue, 
                maxBet, 
                maxNum, 
                minBet,
                opponentNum;

    //unity events for betting (in each phase)
    public UnityEvent closeBettingPanel;
    public UnityEvent displayResults;

    //text fields for describing UI elements
    public TextMeshProUGUI maxValueChips;
    public TextMeshProUGUI maxNumChips;
    public TextMeshProUGUI currentValueChips;
    public TextMeshProUGUI currentNumChips;

    //boolean to define whether betting panel is active
    private bool isActive;

    //UI elements for betting panel
    public GameObject[] incrementBtns;
    public TextMeshProUGUI[] numChipsBet;

    // Start is called before the first frame update
    void Start()
    {
        //setting the refBet to the player's bet
        refBet = refPlayer.getPlayerBet();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OpenPanel(string Type)
    {
        type = Type; //giving "type" the parameter value

        //switch-case to define bet type
        switch (type)
        {
            case "bet":
                //setting the base values for a beginning bet
                minBet = 50;
                maxBet = 500;
                maxNum = 0;
                maxNumChips.text = "---";
                maxValueChips.text = "£500";
                break;
            case "raise":
                //setting the base values for a raise bet
                //temporary array whose indices represent rock, paper, and scissors 
                int[] tempArray = new int[3];
                tempArray = refBet.returnAllValues();
                //maxBet is half the original bet on a particular bubble (R, P, or S)
                //this line needs to be changed when NPlayer is complete
                maxBet = (tempArray[0] / 2);
                maxNum = 0;
                minBet = 0;
                maxNumChips.text = "---";
                maxValueChips.text = maxBet.ToString();
                break;
            case "call":
                //setting the base values for matching an opponent's raise
                int[] temp = new int[3];
                temp = refBet.returnAllValues();
                //this line needs to be changed when NPlayer is complete
                maxBet = (temp[0] / 2);
                maxNum = opponentNum;
                maxNumChips.text = maxNum.ToString();
                maxValueChips.text = maxBet.ToString();
                break;
        }    
    }

    public void ValidateBet(string betType, int betValue)
    {
        bool betValid = false;

        switch (betType)
        {
            case "bet":
                if (betValue <= 500 && betValue >= 50)
                {
                    betValid = true;
                }
                break;

            case "raise":
                if (betValue <= maxBet)
                {
                    betValid = true;
                }
                break;
            case "call":
                if (betValue <= maxBet && totalBetNum == maxNum)
                {
                    betValid = true;
                }
                break;
        }


        if (betValid)
        {
            closeBettingPanel.Invoke();
        }
        else
        {
            Debug.Log("Bet is not Valid");
        }
    }

    void SetBetRef(Bet Reference)
    {

    }
}
