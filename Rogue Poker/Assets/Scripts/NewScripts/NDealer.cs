using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NDealer : MonoBehaviour
{
    private int option;

    public Sprite[] threeOptions;
    public Image display;
    public Sprite Default;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Deal()
    {
        option = Random.Range(0, 3);
        display.sprite = threeOptions[option];
    }

    void ShowDealer()
    {

    }

    public int returnOption()
    {
        return option;
    }
}
