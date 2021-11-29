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
    private int[] EnemyValues; //stores current bets
    [SerializeField]
    private int[] EnemyNumber;

    public TextMeshProUGUI[] EnemyValuesTxt;
    public TextMeshProUGUI[] EnemyNumberTxt;

    public TextMeshProUGUI RaiseTxt;

    public void Start()
    {
        int option = Random.Range(1, 4);
        switch (option)
        {
            case 1:
                EnemyValues = new[] { 300, 170, 250 };
                EnemyNumber = new[] { 22, 17, 5 };
                break;

            case 2:
                EnemyValues = new[] { 80, 370, 205 };
                EnemyNumber = new[] { 3, 5, 12 };
                break;

            case 3:
                EnemyValues = new[] { 275, 55, 199 };
                EnemyNumber = new[] { 15, 2, 9 };
                break;
        }
    }

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
            EnemyValuesTxt[i].text = "�" + EnemyValues[i].ToString();
            EnemyNumberTxt[i].text = "x" + EnemyNumber[i].ToString();
        }
    }

    public void Raise()
    {
        EnemyNumber[0] += 3;
        EnemyValues[0] += 60;

        RaiseTxt.text = "Rock by x3";

        ShowNumber();
    }

    public void Call(int num, int index)
    {
        int value = 10;
        if (num > 11)
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
