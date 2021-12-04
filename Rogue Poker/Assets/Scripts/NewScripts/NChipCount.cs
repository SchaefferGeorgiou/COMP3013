using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NChipCount : MonoBehaviour
{
    private int num100s, num50s, num20s, num10s, num5s, num1s;

    // Start is called before the first frame update
    void Start()
    {
        num100s = 3;
        num50s = 5;
        num20s = 10;
        num10s = 10;
        num5s = 20;
        num1s = 50;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int[] GetCount()
    {
        int[] arrayCounts = { num100s, num50s, num20s, num10s, num5s, num1s };
        return arrayCounts;
    }

    public void AlterCount(int chip, int amount)
    {
        // Alters the chip values after the round for each player
        switch (chip)
        {
            case 0:
                num100s += amount;
                break;
            case 1:
                num50s += amount;
                break;
            case 2:
                num20s += amount;
                break;
            case 3:
                num10s += amount;
                break;
            case 4:
                num5s += amount;
                break;
            case 5:
                num1s += amount;
                break;
        }
    }
}
