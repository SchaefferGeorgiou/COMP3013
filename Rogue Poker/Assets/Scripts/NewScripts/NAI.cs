using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NAI : MonoBehaviour
{
    NBet opponentBets;
    NChipCount opponentChips;

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
        return opponentBets.returnAllCounts();
    }

    public int[] getAllValues()
    {
        return opponentBets.returnAllValues();
    }
}