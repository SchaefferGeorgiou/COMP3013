using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NChipCount : MonoBehaviour
{
    private int[] numTotals;

    // Start is called before the first frame update
    void Start()
    {
        numTotals = new int[6];

        numTotals[0] = 3;
        numTotals[1] = 5;
        numTotals[2] = 10;
        numTotals[3] = 10;
        numTotals[4] = 20;
        numTotals[5] = 50;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int[] GetCount()
    {
        return numTotals;
    }

    public void AlterCount(int[] chips)
    {
        // Alters the chip values after the round for each player
        for (int i = 0; i < chips.Length; i++)
        {
            int a = chips[i];
            numTotals[i] -= a;
        }
    }
}
