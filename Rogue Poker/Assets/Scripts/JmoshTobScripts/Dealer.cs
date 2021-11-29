using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dealer : MonoBehaviour
{
    private int option;
    public UnityEngine.UI.Image[] ThreeOptions;
    public UnityEngine.UI.Image Display;
    public UnityEngine.UI.Image Default;
    public void Start()
    {
        //set image to default ?-pic
    }
    public void Deal()
    {
        option = Random.Range(0, 3);
        //Display = ThreeOptions[option];
    }

    public int getDeal()
    {
        return option;
    }
}
