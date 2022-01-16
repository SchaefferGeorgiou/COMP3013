using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Events;

[ExecuteInEditMode]
public class Rail : MonoBehaviour
{
    //Transform Array to hold all nodes in the current scene
    private Transform[] nodes;
    private GameObject Camera;
    public int currentRotation = 0;
    private bool isrotating = false;

    private void Start()
    {
        //Gets all nodes that are children of the rail object in the current scene 
        nodes = GetComponentsInChildren<Transform>();
        //Grabs the Camera
        Camera = GameObject.Find("Main Camera");
    }

    public void CheckFinish(int seg)
    {
        //Checks if current node is last node
        if (seg == nodes.Length - 2)
        {
            //Runs command in the ui for ending level
            Camera.SendMessage("Halt");
        }
    }

    //NOT BEING USED
    //Linearly positons the object by returning a lerped vector3 between the current node and the next node in the array
    public Vector3 LinearPositon(int seg, float ratio)
    {
        //TEST TRY CATCH FOR NOW
        try
        {
            //Takes the positon of the 'current' node
            Vector3 pos1 = nodes[seg].position;
            //Takes the positon of the next node
            Vector3 pos2 = nodes[seg + 1].position;

            //Return a vector3 of linear interpolation between pos1 and pos2
            return Vector3.Lerp(pos1, pos2, ratio);
        }
        catch (System.IndexOutOfRangeException)
        {

            throw;
        }
    }
    
    public Vector3 CatmullPositon(int seg, float ratio)
    {
        Vector3 pos1, pos2, pos3, pos4;

        //for each new node, check if it's the last node
        CheckFinish(seg);
        //If first node on rail
        if (seg == 0)
        {
            pos1 = nodes[seg].position;
            pos2 = pos1;
            pos3 = nodes[seg + 1].position;
            pos4 = nodes[seg + 2].position;
        }
        else if (seg == nodes.Length -2)
        {
            pos1 = nodes[seg - 1].position;
            pos2 = nodes[seg].position;
            pos3 = nodes[seg + 1].position;
            pos4 = pos3;
        }
        else
        {
            pos1 = nodes[seg - 1].position;
            pos2 = nodes[seg].position;
            pos3 = nodes[seg + 1].position;
            pos4 = nodes[seg + 2].position;
        }


        //Square of ratio
        float t2 = ratio * ratio;
        //Power of three ratio
        float t3 = t2 * ratio;

        //Camull Curve smoothing math equation for axis
        float x = 
            0.5f * ((2.0f * pos2.x) + (-pos1.x + pos3.x) 
            *ratio + (2.0f * pos1.x - 5.0f * pos2.x + 4 * pos3.x -pos4.x) 
            *t2 + (-pos1.x + 3.0f * pos2.x - 3.0f * pos3.x + pos4.x) * t3);
        float y =
            0.5f * ((2.0f * pos2.y) + (-pos1.y + pos3.y)
            * ratio + (2.0f * pos1.y - 5.0f * pos2.y + 4 * pos3.y - pos4.y)
            * t2 + (-pos1.y + 3.0f * pos2.y - 3.0f * pos3.y + pos4.y) * t3);
        float z =
            0.5f * ((2.0f * pos2.z) + (-pos1.z + pos3.z)
            * ratio + (2.0f * pos1.z - 5.0f * pos2.z + 4 * pos3.z - pos4.z)
            * t2 + (-pos1.z + 3.0f * pos2.z - 3.0f * pos3.z + pos4.z) * t3);

        //Return postions using catmull curve axis 
        return new Vector3(x, y, z);
    }

    //Takes the rotation of the nodes and returns a lerped Quaternion
    public Quaternion Rotation(int seg, float ratio, int tilt)
    {
        //Takes the rotation of the 'current' node      node.rotation.x adds the x rotation of the node for tilting
        Quaternion qu1 = new Quaternion(0.2f * nodes[seg].rotation.x, nodes[seg].rotation.y, nodes[seg].rotation.z, nodes[seg].rotation.w);
        //Takes the rotation of the next node
        Quaternion qu2 = new Quaternion(0.2f * nodes[seg+1].rotation.x, nodes[seg + 1].rotation.y, nodes[seg + 1].rotation.z, nodes[seg + 1].rotation.w);
        //Returns a rotation that is linearly interpolated between the rotation of qu1 and qu2
        return Quaternion.Lerp(qu1, qu2, ratio);
    }

    public void Rotate(int seg)
    {
        if (isrotating)
        {
            Debug.Log("1st" + nodes[seg].rotation.x);
            //Sets the rotation of the next node
            //nodes[seg + 1].rotation.Set((currentRotation * 10) + nodes[seg + 1].rotation.x, nodes[seg + 1].rotation.y, nodes[seg + 1].rotation.z, nodes[seg + 1].rotation.w);
            float temp = currentRotation * 0.2f;
            nodes[seg+1].rotation = new Quaternion(temp + nodes[seg+1].rotation.x, nodes[seg+1].rotation.y, nodes[seg+1].rotation.z, nodes[seg+1].rotation.w);
            Debug.Log(nodes[seg].rotation.x);
        }
    }

    //Draws linear lines between each node in a scene in the editor view
    private void OnDrawGizmos()
    {
        //Loop to step through all nodes in a scene and draw a line between them
        /*for (int i = 0; i < nodes.Length - 1; i++)
        {
            Handles.DrawDottedLine(nodes[i].position, nodes[i + 1].position, 3.0f);
        }*/
    }

}
