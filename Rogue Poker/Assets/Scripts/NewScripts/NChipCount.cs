using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NChipCount : MonoBehaviour
{
    private int[] numTotals = new int[] { 4, 5, 8, 8, 10, 10 };

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

    public void setCount(int[] chips)
    {
        for (int i = 0; i < chips.Length; i++)
        {
            int a = chips[i];
            numTotals[i] = a;
        }
    }
}
