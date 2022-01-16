using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectButton : MonoBehaviour
{
    public UnityEvent Clicked;
    public UnityEvent Enter;
    public UnityEvent Exit;

    public void OnMouseDown()
    {
        Clicked.Invoke();
    }

    private void OnMouseEnter()
    {
        Enter.Invoke();
    }

    private void OnMouseExit()
    {
        Exit.Invoke();
    }
}
