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

    public delegate void SubjectView(SimpleJSON.JSONNode data);
    public event SubjectView OnSubjectView;
    public void TriggerSubjectView(SimpleJSON.JSONNode data)
    {
        if (OnSubjectView != null)
        {
            OnSubjectView(data);
        }
    }

    public delegate void ChapterView(SimpleJSON.JSONNode data);
    public event ChapterView OnChapterView;
    public void TriggerChapterView(SimpleJSON.JSONNode data)
    {
        if (OnChapterView != null)
        {
            OnChapterView(data);
        }
    }

    public delegate void SubtopicView(SimpleJSON.JSONNode data);
    public event SubtopicView OnSubtopicView;
    public void TriggerSubtopicView(SimpleJSON.JSONNode data)
    {
        if (OnSubtopicView != null)
        {
            OnSubtopicView(data);
        }
    }

}
