using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChapterHandler : MonoBehaviour
{
    public Text chapterNameText;
    SimpleJSON.JSONNode chapterData;
    public void SetData(string chapterName, SimpleJSON.JSONNode chapterData)
    {
        chapterNameText.text = chapterName;
        this.chapterData = chapterData;
    }

    public void OnExpand()
    {
        EventManager.Instance.TriggerSubtopicView(chapterData);

    }
}
