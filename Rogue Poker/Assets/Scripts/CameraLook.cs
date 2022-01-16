using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    private Transform target;

    [SerializeField]
    private Transform blackboard;
    [SerializeField]
    private Transform tableCentre;
    [SerializeField]
    private Transform pokerPlayer;
    [SerializeField]
    private Transform pokerOpponent;
    [SerializeField]
    private Transform tableSide;

    [SerializeField]
    private float speed = 0.5f;

    void Update()
    {
        transform.LookAt(target);

        var targetRotation = Quaternion.LookRotation(target.position - transform.position);

        // Smoothly rotate towards the target point.
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);

        // cam.fieldOfView = Mathf.MoveTowards(cam.fieldOfView, 1, 30 * Time.deltaTime);
    }

    public void moveBlackboard()
    {
        target = blackboard;
    }

    public void moveCentreTable()
    {
        target = tableCentre;
    }

    public void movePlayerView()
    {
        target = pokerPlayer;
    }

    public void moveOpponentView()
    {
        target = pokerOpponent;
    }

    public void moveTableSide()
    {
        target = tableSide;
    }

    public void Activate()
    {
        moveCentreTable();
        gameObject.SetActive(true);
    }
}
