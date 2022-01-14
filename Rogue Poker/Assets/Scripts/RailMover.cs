using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RailMover : MonoBehaviour
{
    //Current instance of rail that object is on
    public Rail currentRail;
    public Rigidbody rig;

    public UnityEvent MoveToEndRail;
    public UnityEvent BackToMainMenu;

    private float transition;
    //Current speed float
    public float Speed = 0f;
    //Current segment that object is on
    private int currentSeg;
    //Bool to check if current section of track is complete
    private int tilt = 0;
    
    private bool isComplete = false;

    private void Update()
    {
        //If there is no current rail, return nothing
        if (!currentRail)
        {
            return;
        }
        //If not completed, run Play method
        if (!isComplete)
        {
            Play();
        }

        
        if (Input.GetKeyDown(KeyCode.B))
        {
            //test code, delete
            SetSpeed(1f);
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            //more test code, delete later

            MoveToEndRail.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetRail();
        }

    }
    
    //Method to be invoked when game is still running
    private void Play()
    {
        //Increases the transiton float by time * speed 
        transition += Time.deltaTime * (Speed/4.5f);

        //If transiton value is larger than one, rail section is complete
        //so set transition back to 0 and move into the next node of the array
        if (transition > 1)
        {
            transition = 0;
            currentSeg++;
            currentRail.Rotate(currentSeg);
        }

        //Else if transition value is smaller than zero, a new rail section is
        //before the object so set transition value to 1 and move back to the prevoius node
        else if (transition < 0)
        {
            transition = 1;
            currentSeg--;
        }

        transform.position = currentRail.CatmullPositon(currentSeg, transition);
        //transform.rotation = currentRail.Rotation(currentSeg, rTransition, tilt);
        transform.rotation = currentRail.Rotation(currentSeg, transition, tilt);
    }

    //Use this method to increase and decrease the camera moving between scenes
    public void SetSpeed(float inSpeed)
    {
        Speed = inSpeed;
    }

    public void Halt()
    {
        SetSpeed(0f);
    }

    public Vector3 SendSpeed()
    {
        //return move;
        var vel = rig.velocity;
        return vel;
    }

    //Entering a new Rail
    public void SwitchRail(Rail newRail)
    {
        currentRail = newRail;
        ResetRail();
    }


    //Setting a Rail to the first node
    public void ResetRail()
    {
        currentSeg = 0;
    }
}
