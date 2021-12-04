using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class NPlayer : MonoBehaviour
{
    private NBet playerBets; //player's bet's value (in £)
    private NChipCount playerChips; //player's number of chips
    private NBetIndicator UIindicator; //UI variable
    private NBettingPanel panel; //object for the player's betting panel

    UnityEvent PhaseTwo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int[] getAllCounts()
    {
        return playerBets.returnAllCounts();
    }

    public int[] getAllValues()
    {
        return playerBets.returnAllValues();
    }
}
