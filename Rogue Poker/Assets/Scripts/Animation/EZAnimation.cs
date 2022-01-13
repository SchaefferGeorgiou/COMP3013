using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EZAnimation : MonoBehaviour
{
    //Can add other variables later
    private Animator animator;
    private int newInt;


    //I got tired so I gave up and hardcoded the boi
    public NDealer dealer;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    
    
    public void setBoolTrue(string boolName)
    {
        animator.SetBool(boolName, true);
    }

    public void setBoolFalse(string boolName)
    {
        animator.SetBool(boolName, false);
    }


    /*
    //Actual method, but not needed rn
    //public void setNewIntValue(int value)
    //{
    //    newInt = value;
    //}
    */

    //Used to set postition in the array

    //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
    //NOTE FOR BELOW: IN EVENTS THESE SHOULD BE BEFORE ANY OF THE OTHER METHODS (in this class) TO AVOID ERRORS
    //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 

    //Hard coded thing
    public void setAnimIntValue(string intName)
    {
        animator.SetInteger(intName, dealer.returnOption());
    }


    //public void setAnimIntValue(string intName)
    //{
    //    animator.SetInteger(intName, newInt);
    //}


}
