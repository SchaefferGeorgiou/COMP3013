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
        //code to satisfy the VS error
        int[] arrayCounts = { num100s, num50s, num20s, num10s, num5s, num1s };
        return arrayCounts;
    }

    void AlterCount(int Chip, int Amount)
    {
    }
}
