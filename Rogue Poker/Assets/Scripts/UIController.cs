using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIController : MonoBehaviour
{

    public GameObject[] AllTexts;
    public Transform[] textPositions;
    public GameObject ContinueBtn;

    public UnityEvent showArrows;

    public NPhase refPhases;

    [Header ("Array of the various Help Screens")]
    public GameObject[] HelpScreens;

    public GameObject rotationTarget;

    private bool open, atTable, end, started;

    // Start is called before the first frame update
    void Start()
    {
        open = false;
        atTable = false;
        end = false;
        started = false;
        ContinueBtn.SetActive(false);

        for (int i = 0; i < 7; i++)
        {
            textPositions[i].rotation = AllTexts[i].transform.rotation;
        }
    }

    public void closeJalp()
    {
        int phase = refPhases.getPhaseNum();

        if (phase > 1)
        {//Normalise the Phase num to work with the array
            if (phase == 2 || phase == 3) { phase = 1; }
            else if (phase > 3) { phase = 2; }
        }
        else { phase = 0; }

        HelpScreens[phase].SetActive(false);
        open = false;
    }

    public void openJalp()
    {
        if (open) return;
        int phase = refPhases.getPhaseNum();

        if (phase > 1)
        {//Normalise the Phase num to work with the array
            if (phase == 2 || phase == 3) { phase = 1; }
            else if (phase > 3) { phase = 2; }
        }
        else { phase = 0; }

        HelpScreens[phase].SetActive(true);
        open = true;
    }

    private void Update()
    {
        //replace with a button for turning on/off
        if (Input.GetKey("j") && atTable)
        {
            openJalp();
        }

        if (end)
        {
            foreach (GameObject item in AllTexts)
            {
                //item.transform.LookAt(rotationTarget.transform);

                //var targetRotation = Quaternion.LookRotation(rotationTarget.transform.position - transform.position);
                //item.transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.1f * Time.deltaTime);

                //Vector3 direction = item.transform.position - rotationTarget.transform.position;
                //direction.y += 90;
                //Quaternion targetRotation = Quaternion.LookRotation(direction);
                //item.transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 180f);
                //item.transform.eulerAngles = new Vector3(item.transform.rotation.x, direction.y, item.transform.rotation.z);

                //transform.rotation = Quaternion.FromToRotation(Vector3.up, rotationTarget.transform.position - item.transform.position);
            }
        }
    }

    public void SpinText()
    {
        leaveTable();
        //end = true;
        foreach (GameObject item in AllTexts)
        {
            item.transform.Rotate(new Vector3(item.transform.position.x, item.transform.position.y + 90f, item.transform.position.z));
        }
    }

    public void resetText()
    {
        //0-2, player = x:30, 3-5 opp = x:30 & y:180, 6 delaer = 0,0,0

        end = false;

        for (int i = 0; i < 7; i++)
        {
            AllTexts[i].transform.rotation = textPositions[i].rotation;
        }
    }

    public void AtTable()
    {
        if (!started) { StartCoroutine(openButton()); }
        started = true;
        atTable = true;
    }

    public void leaveTable()
    {
        atTable = false;
    }

    public void ResetGame()
    {
        ContinueBtn.SetActive(false);
        started = false;
        leaveTable();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator openButton()
    {
        yield return new WaitForSeconds(5f);
        ContinueBtn.SetActive(true);
        showArrows.Invoke();
    }
}
