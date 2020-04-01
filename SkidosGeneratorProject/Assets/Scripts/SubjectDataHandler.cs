using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubjectDataHandler : MonoBehaviour
{
    public Text subjectNameText;
    SimpleJSON.JSONNode subjectData;

    public GameObject chapterPrefab;
    public Transform chapterParent;

    private bool isExpanded;

    public void SetData(string subject, SimpleJSON.JSONNode data)
    {
        subjectData = data;
        subjectNameText.text = subject;
    }
    public void OnExpand()
    {
        Debug.Log("on expand in subjects...");
        if (isExpanded)
        {
            chapterParent.gameObject.SetActive(false);
        }
        else
        {
            if (chapterParent.childCount > 0)
            {
                chapterParent.gameObject.SetActive(true);
            }
            else
            {
                GameObject obj;

                foreach (var key in subjectData.Keys)
                {
                    obj = Instantiate(chapterPrefab) as GameObject;
                    obj.transform.parent = chapterParent;
                    obj.GetComponent<ChapterHandler>().SetData(key, subjectData[key]);
                }
            }
        }
        isExpanded = !isExpanded;
        EventManager.Instance.TriggerResize();

    }
}
