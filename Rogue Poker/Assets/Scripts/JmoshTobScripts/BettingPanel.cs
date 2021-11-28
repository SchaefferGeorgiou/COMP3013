using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;
using UnityEngine.Events;

public class BettingPanel : MonoBehaviour
{
    public UnityEngine.UI.Slider[] Sliders;
    public TextMeshProUGUI[] numChipsBet;
    public Player refPlayer;
    public Bet refBet;

    public UnityEvent closePopup;

    public string Type;

    [SerializeField]
    private int TotalBetNumber, TotalBetValue;
    [SerializeField]
    private int MaxBet, MaxNum;

    private int[] ChipValues = { 100, 50, 20, 10, 5, 1 };

    //Value Text Fields

    public TextMeshProUGUI MaxValueChips;
    public TextMeshProUGUI MaxNumChips;

    public TextMeshProUGUI CurValueChips;
    public TextMeshProUGUI CurNumChips;


    private bool bettingPanelActive;

    //References To UI Elements NEEDED


    void Start()
    {
        this.gameObject.SetActive(true);
        SetActive(true);

        SetActive(false);
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (bettingPanelActive)
        {
            TotalBetValue = 0;
            TotalBetNumber = 0;
            for (int i = 0; i < numChipsBet.Length; i++)
            {
                numChipsBet[i].text = "x" +  Sliders[i].value.ToString();
                TotalBetValue += ChipValues[i] * (int)Sliders[i].value;
                TotalBetNumber += (int)Sliders[i].value;
            }

            CurValueChips.text = "£" + TotalBetValue.ToString();
            CurNumChips.text = "x" + TotalBetNumber.ToString();
        }

    }

    public void SetActive(bool state)
    {
        bettingPanelActive = state;
        if (bettingPanelActive)
        {
            PanelReset();
        }
    }

    public void BetType(string type)
    {
        Type = type;
        if (Type == "Bet")
        {
            MaxBet = 500;
            MaxNum = 0;
            MaxNumChips.text = "";
            MaxValueChips.text = "£500";
        }
        else if (Type == "Raise")
        {
            //get num, need to know R/P/S
            int[] temp = new int[3];
            temp = refBet.getAllBets();
            MaxBet = (temp[refPlayer.CurrentPos] / 2);
            MaxNum = 0;
            MaxNumChips.text = "";
            MaxValueChips.text = MaxBet.ToString();
        }
        else if (Type == "Call")
        {

        }
    }

    public void PanelReset()
    {
        for (int i = 0; i < numChipsBet.Length; i++)
        {
            Sliders[i].value = 0;
            Sliders[i].maxValue = refPlayer.getNumChips(i);
        }
    }

    public void PlaceBet() //need feedback at some point
    {
        //check bet < 50, bet >= 500
        if (TotalBetValue <= MaxBet && TotalBetValue >= 50 && TotalBetNumber > 0)
        {
            if (Type == "Call")
            {
                if (TotalBetNumber != MaxNum)
                {
                    //can't bet
                    return;
                }
            }

            refBet.SetBet(refPlayer.CurrentPos, TotalBetValue, TotalBetNumber);

            int[] temp = new int[6];

            for (int i = 0; i < Sliders.Length; i++)
            {
                temp[i] = (int)Sliders[i].value;
            }
            refPlayer.EditChips(temp);

            CloseBetWindow();
            //can bet
        }

        //can't bet
    }

    public void CloseBetWindow()
    {
        closePopup.Invoke();
    }
}
