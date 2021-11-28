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

    public TextMeshProUGUI[] PlayerValuesTxt;
    public TextMeshProUGUI[] PlayerNumberTxt; //Ui for displaying current bets

    [SerializeField]
    private string playerFold, playerRaise;

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

    //Use these methods on the raise buttons under the click event respectively
    //"UISliders" is a catch-all term, not a variable

    public int[] getAllBets()
    {
        return PlayerValues;
    }

    public void SetBet(int index, int value, int count)
    {
        PlayerValues[index] += value;
        PlayerNumber[index] += count;
    }

    public void ConfirmBets()
    {
        for (int i = 0; i < PlayerNumber.Length; i++)
        {
            if (PlayerNumber[i] == 0 || PlayerValues[i] == 0)
            {
                return; //something not bet on, quit 
            }
        }
        //everything bet on
        FinishPhase1.Invoke();
    }
}
