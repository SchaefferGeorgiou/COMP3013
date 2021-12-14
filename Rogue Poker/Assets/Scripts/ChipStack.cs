using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipStack : MonoBehaviour
{
    //note: this script is to be put onto empty GameObjects that serve as the base for each individual stack

    //declaring variables
    [SerializeField, Header("Gap size")]
    private float GapSize = 0.02f; //Size of the gap between each chip
    [SerializeField]
    GameObject chip; //a gameObject for the reference chip to use for the particular stack
    Vector3 stackPosition; //the chip stack's position
    List<GameObject> chipStack = new List<GameObject>(); //list of chips returned from instantiation

    // Start is called before the first frame update
    void Start()
    {
        GapSize += chip.GetComponent<Renderer>().bounds.size.y; 
        stackPosition = transform.position;
        Debug.Log(transform.position.y);

        //for loop for the sake of testing without a button
        for (int i = 0; i < 5; i++)
        {
            StackChips(1);
        }

        StartCoroutine(Wait());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //a method for stacking individual chips as they are added (progressively) in the Betting Panel
    void StackChips(int numChips)
    {
        for (int i = 0; i < numChips; i++)
        {
            //create a chip, save it and then add it to the stack
            GameObject temp = Instantiate(chip, stackPosition, chip.transform.rotation * Quaternion.Euler(0f, 0f, 90f));
            chipStack.Add(temp);
            stackPosition.y += GapSize; //the y value of the stack's position changes by the height
        }
    }

    //a method for removing individual chips as they are subtracted (progressively) in the Betting Panel
    void RemoveChips(int numChips)
    {
        for (int i = 0; i < numChips; i++)
        {
            //destroys last chip element
            Destroy(chipStack[chipStack.Count - 1]);
            //removes last chip element from list
            chipStack.RemoveAt(chipStack.Count - 1);
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
        RemoveChips(3);
    }
}
