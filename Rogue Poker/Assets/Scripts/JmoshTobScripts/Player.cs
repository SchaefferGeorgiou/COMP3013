using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public TextMeshProUGUI[] ChipsTxt;

    //number ofindividually valued chips (initialised for the start of the game)
    [SerializeField]
    private int[] numChips; //Holds num of ALL chips
    //starting number of player chips (�700)
    [SerializeField]
    private int numChipsTotal;
    //total value of all the player's chips
    [SerializeField]
    private int totalChipsValue = 1000;
    
    public UnityEngine.UI.Button[] betButtons;
    public UnityEngine.UI.Image[] ThreeOptions; //pictures

    public int FoldedIndex;

    public Color color;

    public int CurrentPos;

    private bool Folded;
    public UnityEngine.UI.Button FoldBtn;
    private bool Raised;
    public UnityEngine.UI.Button RaiseBtn;

    public UnityEvent Phase2_2;

    // Start is called before the first frame update
    void Start()
    {
        UpdateChipTotals();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getNumChips(int Index) 
    {
        return numChips[Index];
    }

    void UpdateChipTotals()
    {
        for (int i = 0; i < ChipsTxt.Length; i++)
        {
            ChipsTxt[i].text = numChips[i].ToString();
        }
    }

    public void CurrentBet(string option)
    {
        if(option == "Rock")
        {
            CurrentPos = 0;
        }
        else if (option == "Paper")
        {
            CurrentPos = 1;
        }
        else if (option == "Scissors")
        {
            CurrentPos = 2;
        }
    }

    public void EditChips(int[] values)
    {
        for (int i = 0; i < values.Length; i++)
        {
            numChips[i] -= values[i];
        }
        betButtons[CurrentPos].enabled = false;
        betButtons[CurrentPos].image.color = color;
        UpdateChipTotals();
    }

    public void Fold(int index)
    {
        if (index == -1) //-1 = fold no
        {
            FoldedIndex = index;
            Folded = true;
        }
        else if (!Folded)
        {
            FoldedIndex = index;
            var tempColor = ThreeOptions[index].color;
            tempColor.a = 0.5f;
            ThreeOptions[index].color = tempColor;
            Folded = true;
        }
        FoldBtn.enabled = false;
        FoldBtn.image.color = color;
    }

    public void Raise()
    {
        Raised = true;
        RaiseBtn.enabled = false;
        RaiseBtn.image.color = color;
    }

    public void CheckFinishRaiseFold()
    {
        Debug.Log("Calling");
        Debug.Log(Raised);
        Debug.Log(Folded);
        if (Raised && Folded)
        {
            Debug.Log("ye");
            Phase2_2.Invoke();
            Debug.Log("ya");
        }
    }

}
