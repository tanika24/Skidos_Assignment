using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    private static EventManager instance;
    public static EventManager Instance
    {
        get
        {
            return instance;
        }
    }

    void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
    }

    public delegate void Resize();
    public event Resize OnResize;
    public void TriggerResize()
    {
        if (OnResize != null)
        {
            OnResize();
        }
    }

}
