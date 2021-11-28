using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //number of individually valued chips (initialised for the start of the game)
    [SerializeField]
    private int numHundredChips = 3, 
                numFiftyChips = 5, 
                numTwentyChips = 10, 
                numTenChips = 10, 
                numFiveChips = 20, 
                numUnitChips = 50;
    //starting number of player chips (£700)
    [SerializeField]
    private int numChipsTotal;
    //total value of all the player's chips
    [SerializeField]
    private int totalChipsValue = 1000;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int getNumHundredChips()
    {
        return numHundredChips;
    }

    int getNumFiftyChips()
    {
        return numFiftyChips;
    }

    int getNumTwentyChips()
    {
        return numTwentyChips;
    }

    int getNumTenChips()
    {
        return numTenChips;
    }

    int getNumFiveChips()
    {
        return numFiveChips;
    }

    int getNumUnitChips()
    {
        return numUnitChips;
    }


}
