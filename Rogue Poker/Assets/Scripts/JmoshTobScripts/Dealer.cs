using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dealer : MonoBehaviour
{
    private int option;
    public UnityEngine.Sprite[] ThreeOptions;
    public UnityEngine.UI.Image Display;
    public UnityEngine.Sprite Default;

    public void Start()
    {
        //set image to default ?-pic
    }
    public void Deal()
    {
        option = Random.Range(0, 3);
        Display.sprite = ThreeOptions[option];
    }

    public int getDeal()
    {
        return option;
    }
}
