using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;

public class AI : MonoBehaviour
{
    [SerializeField]
    private int[] EnemyValues = new[] { 300, 170, 500 }; //stores current bets
    [SerializeField]
    private int[] EnemyNumber = new[] { 22, 17, 5 };

    public TextMeshProUGUI[] EnemyValuesTxt;
    public TextMeshProUGUI[] EnemyNumberTxt;

    public TextMeshProUGUI RaiseTxt;

    public void ShowNumber()
    {
        for (int i = 0; i < 3; i++)
        {
            EnemyNumberTxt[i].text = "x" + EnemyNumber[i].ToString();
        }
    }

    public void ShowValue()
    {
        for (int i = 0; i < 3; i++)
        {
            EnemyValuesTxt[i].text = "£" + EnemyValues[i].ToString();
            EnemyNumberTxt[i].text = "x" + EnemyNumber[i].ToString();
        }
    }

    public void Raise()
    {
        EnemyNumber[0] += 3;
        EnemyValues[0] += 150;

        RaiseTxt.text = "Rock by x3";

        ShowNumber();
    }

    public void Call(int num, int index)
    {
        int value = 10;
        if (num > 12)
        {
            value = 1;
        }
        EnemyNumber[index] += num;
        EnemyValues[index] += num * value;

        ShowNumber();
    }

    public int[] GetAllValues()
    {
        return EnemyValues;
    }
}
