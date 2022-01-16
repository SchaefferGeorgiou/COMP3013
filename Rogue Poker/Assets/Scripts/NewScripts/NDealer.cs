using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NDealer : MonoBehaviour
{
    private int option;

    public GameObject[] threeOptions;
    //public Image display;
    public GameObject Default;

    public TextMeshPro DelaerTxt;
    [Header ("Delay between when dealer.Deal is called and the text update")]
    public float textDelay = 2;

    // Start is called before the first frame update
    void Start()
    {
        DelaerTxt.SetText("Dealer");
        Default.SetActive(true);

        foreach (GameObject item in threeOptions)
        {
            item.SetActive(false);
        }
    }

    public void Deal()
    {
        option = Random.Range(0, 3);
        threeOptions[option].SetActive(true);
        string choice = "";
        if (option == 0) { choice = "Rock"; }
        else if (option == 1) { choice = "Paper"; }
        else if (option == 2) { choice = "Scissors"; }

        StartCoroutine(showChoice(textDelay, choice));
    }

    IEnumerator showChoice(float delay, string choice)
    {
        DelaerTxt.SetText("");
        yield return new WaitForSeconds(delay);
        DelaerTxt.SetText(choice);
    }

    public void resetDealer()
    {
        DelaerTxt.SetText("Dealer");
        threeOptions[option].SetActive(false);
        Default.SetActive(true);
    }

    public int returnOption()
    {
        return option;
    }
}
