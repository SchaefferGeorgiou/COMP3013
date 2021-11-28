using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    [SerializeField]
    private int numHundredChips = 3,
                numFiftyChips = 5,
                numTwentyChips = 10,
                numTenChips = 10,
                numFiveChips = 20,
                numUnitChips = 50;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getNumHundredChips()
    {
        return numHundredChips;
    }

    public int getNumFiftyChips()
    {
        return numFiftyChips;
    }

    public int getNumTwentyChips()
    {
        return numTwentyChips;
    }

    public int getNumTenChips()
    {
        return numTenChips;
    }

    public int getNumFiveChips()
    {
        return numFiveChips;
    }

    public int getNumUnitChips()
    {
        return numUnitChips;
    }
}
