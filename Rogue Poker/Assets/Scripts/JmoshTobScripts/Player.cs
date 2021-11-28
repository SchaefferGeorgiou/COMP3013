using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public TextMeshProUGUI[] ChipsTxt;

    //number ofindividually valued chips (initialised for the start of the game)
    [SerializeField]
    private int[] numChips;
    //starting number of player chips (£700)
    [SerializeField]
    private int numChipsTotal;
    //total value of all the player's chips
    [SerializeField]
    private int totalChipsValue = 1000;

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

}
