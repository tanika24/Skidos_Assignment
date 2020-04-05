using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubjectDataHandler : MonoBehaviour
{
    public Text subjectNameText;
    SimpleJSON.JSONNode subjectData;


    public void SetData(string subject, SimpleJSON.JSONNode data)
    {
        subjectData = data;
        subjectNameText.text = subject;
    }
    public void OnExpand()
    {
        EventManager.Instance.TriggerChapterView(subjectData);

    }
}
