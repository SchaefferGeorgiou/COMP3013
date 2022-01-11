using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailMover : MonoBehaviour
{
    //Current instance of rail that object is on
    public Rail currentRail;
    public Rigidbody rig;

    private float transition;
    //Current speed float
    private float rTransition;
    public float Speed = 0f;
    //Current segment that object is on
    private int currentSeg;
    //Bool to check if current section of track is complete
    private int tilt = 0;

    private bool isRotating = false;
    
    private bool isComplete = false;

    public Vector3 move;

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
            SetSpeed(1f);
        }

    }
    
    //Method to be invoked when game is still running
    private void Play()
    {
        //Increases the transiton float by time * speed 
        transition += Time.deltaTime * (Speed/4.5f);

        if (isRotating)
        {
            rTransition += Time.deltaTime * (1 / 0.75f);
        }

        //Debug.Log("INPLAY");
        //If transiton value is larger than one, rail section is complete
        //so set transition back to 0 and move into the next node of the array
        if (transition > 1)
        {
            transition = 0;
            currentSeg++;
            currentRail.Rotate(currentSeg);
        }

        /*if (rTransition > 1)
        {
            currentRail.currentRotation += tilt;
            rTransition = 0;
            tilt = 0;
            isRotating = false;
        }*/

        //Else if transition value is smaller than zero, a new rail section is
        //before the object so set transition value to 1 and move back to the prevoius node
        else if (transition < 0)
        {
            transition = 1;
            currentSeg--;
        }

        move = currentRail.CatmullPositon(currentSeg, transition);
        transform.position = move;
        //transform.rotation = currentRail.Rotation(currentSeg, rTransition, tilt);
        transform.rotation = currentRail.Rotation(currentSeg, transition, tilt);
    }

    public void IncSpeed()
    {
        //Gradual Increases speed by 0.2 for speed between 0-3
        if (Speed < 3)
        {
            Speed = Speed + 0.2f;
        }
        Debug.Log("W was pressed - Speed: " + Speed);
    }

    public void DecSpeed()
    {
        //Gradual Decreases speed by 0.2 for speed between 0-3
        if (Speed >= 0.2)
        {
            Speed = Speed - 0.2f;
        }
        Debug.Log("S was pressed - Speed: " + Speed);
    }

    //Use this method to increase and decrease the camera moving between scenes
    public void SetSpeed(float inSpeed)
    {
        Speed = inSpeed;
        Debug.Log("Speed: " + Speed);
    }

    public void Halt()
    {
        SetSpeed(0f);
    }

    public void TiltLeft()
    {
        currentRail.rotateLeft(currentSeg);
    }

    public void TiltRight()
    {
        currentRail.rotateRight(currentSeg);
    }

    public Vector3 SendSpeed()
    {
        //return move;
        var vel = rig.velocity;
        return vel;
    }

    public float SendX()
    {
       return transform.localPosition.x;
    }

    public float SendZ()
    {
        return transform.localPosition.z;
    }
}
