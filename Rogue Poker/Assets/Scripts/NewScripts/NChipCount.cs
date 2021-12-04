using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NChipCount : MonoBehaviour
{
    private int numHundreds, numFiftys, numTwenties, numTens, numFives, numUnits;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int[] GetCount()
    {
        //code to satisfy the VS error
        int[] array = new int[] {1, 2, 3};
        return array;
    }

    void AlterCount(int Chip, int Amount)
    {

    }
}
