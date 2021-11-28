using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventCaller : MonoBehaviour
{
    public UnityEvent massFolding;
    public void MassFolding()
    {
        massFolding.Invoke();
    }
}
