using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;

public class BettingPanel : MonoBehaviour
{
    public UnityEngine.UI.Slider[] Sliders;
    public TextMeshProUGUI[] numChipsBet;
    public Player refPlayer;

    private bool bettingPanelActive;

    //References To UI Elements NEEDED

    private int[] ChipTotals;


    void Start()
    {
        this.gameObject.SetActive(true);
        SetActive(true);

        SetActive(false);
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (bettingPanelActive)
        {
            for (int i = 0; i < numChipsBet.Length; i++)
            {
                numChipsBet[i].text = Sliders[i].value.ToString();
            }
        }

    }

    public void SetActive(bool state)
    {
        bettingPanelActive = state;
        if (bettingPanelActive)
        {
            PanelReset();
        }
    }

    public void PanelReset()
    {
        for (int i = 0; i < numChipsBet.Length; i++)
        {
            Sliders[i].value = 0;
            Sliders[i].maxValue = refPlayer.getNumChips(i);
        }
    }
}
