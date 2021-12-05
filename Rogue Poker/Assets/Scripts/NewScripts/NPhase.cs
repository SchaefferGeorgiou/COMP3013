using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NPhase : MonoBehaviour
{
    [SerializeField]
    private GameObject betBtns, pickBtnsRaise, RFBtns, pickBtnsFold, CPBtns, endScores;
    [SerializeField]
    private int phaseNum;

    private bool hasFolded, hasRaised;

    // Start is called before the first frame update
    void Start()
    {
        PhaseOne();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //This method isn't necessary at current, however we will make it reset the game for testing purposes
    public void PhaseOne()
    {
        //This enables the bet buttons only
        betBtns.SetActive(true);
        RFBtns.SetActive(false);
        pickBtnsFold.SetActive(false);
        pickBtnsRaise.SetActive(false);
        CPBtns.SetActive(false);
        hasFolded = false; 
        hasRaised = false; 
    }

    public void PhaseTwo()
    {
        //This enables the Raise Fold buttons for Phase 2 and disables the Phase 1 Bet Buttons
        setPhaseNum(2);
        betBtns.SetActive(false);
        RFBtns.SetActive(true);

    }
    public void PhaseTwo_RF(string choice)
    {

        //This takes in the specific button type and changes the UI respectively
        switch (choice)
        {
            case "raise":
                RFBtns.SetActive(false);
                pickBtnsRaise.SetActive(true);
                break;

            case "fold":
                RFBtns.SetActive(false);
                pickBtnsFold.SetActive(true);
                break;

            case "reset":
                RFBtns.SetActive(true);
                pickBtnsFold.SetActive(false);
                pickBtnsRaise.SetActive(false);
                break;

            default:
                Debug.Log("Incorrect text written in a raise / fold / pass button");
                break;
        }

        //The pass button can have the text change to reflect whether the player has done one or none
        //e.g. changing 'pass' to 'continue'
    }

    public void Raise()
    {
        hasRaised = true;
        PhaseTwo_RF("reset");
        RaisedAndFolded();
    }
    public void Fold()
    {
        hasFolded = true;
        PhaseTwo_RF("reset");
        RaisedAndFolded();
    }

    public void RaisedAndFolded()
    {
        if (hasRaised && hasFolded)
        {
            PhaseTwo_C();
        }
    }


    public void PhaseTwo_C()
    {
        CPBtns.SetActive(true);
        RFBtns.SetActive(false);
    }

    public void PhaseThree()
    {
        setPhaseNum(3);
        CPBtns.SetActive(false);
        endScores.SetActive(true);
    }


    public void setPhaseNum(int phase)
    {
        phaseNum = phase;
    }

    public int getPhaseNum()
    {
        return phaseNum;
    }
}
