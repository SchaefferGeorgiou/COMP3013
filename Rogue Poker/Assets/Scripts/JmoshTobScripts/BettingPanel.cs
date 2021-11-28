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

    [SerializeField]
    private int NumChips, TotalValue;

    private int[] ChipValues = { 100, 50, 20, 10, 5, 1 };

    //Value Text Fields

    public TextMeshProUGUI MaxValueChips;
    public TextMeshProUGUI MaxNumChips;

    public TextMeshProUGUI CurValueChips;
    public TextMeshProUGUI CurNumChips;


    private bool bettingPanelActive;

    //References To UI Elements NEEDED


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
            TotalValue = 0;
            NumChips = 0;
            for (int i = 0; i < numChipsBet.Length; i++)
            {
                numChipsBet[i].text = Sliders[i].value.ToString();
                TotalValue += ChipValues[i] * (int)Sliders[i].value;
                NumChips += (int)Sliders[i].value;
            }

            CurValueChips.text = TotalValue.ToString();
            CurNumChips.text = NumChips.ToString();
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
