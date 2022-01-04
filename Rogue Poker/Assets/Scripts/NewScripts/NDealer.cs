using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NDealer : MonoBehaviour
{
    private int option;

    public GameObject[] threeOptions;
    //public Image display;
    public GameObject Default;

    // Start is called before the first frame update
    void Start()
    {
        Default.SetActive(true);

        foreach (GameObject item in threeOptions)
        {
            item.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Deal()
    {
        option = Random.Range(0, 3);
        threeOptions[option].SetActive(true);
    }

    void ShowDealer()
    {

    }

    public int returnOption()
    {
        return option;
    }
}
