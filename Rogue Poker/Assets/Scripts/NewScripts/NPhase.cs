using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class NPhase : MonoBehaviour
{
    [SerializeField]
    private GameObject betBtns, pickBtnsRaise, pickBtnsFold, CPBtns, EndBtns;

    [SerializeField, Header ("Final score text displays")]
    private GameObject dealerText;

    [SerializeField]
    private GameObject[] playerText, opponentText;

    [SerializeField]
    private int phaseNum;

    private bool hasFolded, hasRaised;

    [Header("Events NOT Necessary for functionality")]
    public UnityEvent phaseOne, phaseTwo_RF, phaseTwo_C, phaseThree;

    private int[] winnings = new int[3];

    // Start is called before the first frame update
    void Start()
    {
        PhaseOne();
    }

    //This method isn't necessary at current, however we will make it reset the game for testing purposes
    public void PhaseOne()
    {
        //This enables the bet buttons only
        setPhaseNum(1);
        betBtns.SetActive(true);
        pickBtnsFold.SetActive(false);
        pickBtnsRaise.SetActive(false);
        CPBtns.SetActive(false);
        EndBtns.SetActive(false);
        hasFolded = false; 
        hasRaised = false;

        phaseOne.Invoke();
    }

    public void PhaseTwo()
    {
        //This enables the Raise Fold buttons for Phase 2 and disables the Phase 1 Bet Buttons
        setPhaseNum(2);
        betBtns.SetActive(false);
        //RFBtns.SetActive(true);
            pickBtnsRaise.SetActive(true);

        phaseTwo_RF.Invoke();
    }

    public void PhaseTwo_F()
    {
        setPhaseNum(3);
        pickBtnsRaise.SetActive(false);
        pickBtnsFold.SetActive(true);
    }

    public void Raise()
    {
        hasRaised = true;
        PhaseTwo_F();
        //PhaseTwo_RF("reset");
        RaisedAndFolded();

    }
    public void Fold()
    {
        hasFolded = true;
        //PhaseTwo_RF("reset");
        RaisedAndFolded();
    }

    public void RaisedAndFolded()
    {
        if (hasRaised && hasFolded)
        {
            PhaseTwo_C();
            phaseTwo_C.Invoke();
        }
    }


    public void PhaseTwo_C()
    {
        setPhaseNum(4);
        CPBtns.SetActive(true);
        //RFBtns.SetActive(false);
        pickBtnsFold.SetActive(false);
    }

    public void PhaseThree()
    {
        setPhaseNum(5);
        CPBtns.SetActive(false);
        EndBtns.SetActive(true);
        //do other stuffs
        //smooth rotate text displays so user can see


        //Don't forget to reset these rotations in phase_one()
        phaseThree.Invoke();
    }


    public void setPhaseNum(int phase)
    {
        phaseNum = phase;
    }

    public int getPhaseNum()
    {
        return phaseNum;
    }

    public void displayCurrentPhase()
    {
        switch(phaseNum)
        {
            case 1:
                PhaseOne();
                break;
            case 2:
                PhaseTwo();
                break;
            case 3:
                PhaseTwo_F();
                break;
            case 4:
                PhaseTwo_C();
                break;
            case 5:
                PhaseThree();
                break;
        }
    }
}
