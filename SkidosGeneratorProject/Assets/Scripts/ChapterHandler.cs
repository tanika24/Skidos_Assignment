using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChapterHandler : MonoBehaviour
{
    public Text chapterNameText;
    SimpleJSON.JSONNode chapterData;

    public GameObject subtopicPrefab;
    public Transform subtopicParent;
    private bool isExpanded;
    public void SetData(string chapterName, SimpleJSON.JSONNode chapterData)
    {
        chapterNameText.text = chapterName;
        this.chapterData = chapterData;
    }

    public void OnExpand()
    {
        Debug.Log("on expand in subjects...");
        if (isExpanded)
        {
            subtopicParent.gameObject.SetActive(false);
        }
        else
        {
            if (subtopicParent.childCount > 0)
            {
                subtopicParent.gameObject.SetActive(true);
            }
            else
            {
                GameObject obj;

                foreach (var value in chapterData.Values)
                {
                    obj = Instantiate(subtopicPrefab) as GameObject;
                    obj.transform.parent = subtopicParent;
                    obj.GetComponent<SubtopicDataHandler>().SetData(value);
                }
            }
        }
        isExpanded = !isExpanded;
        EventManager.Instance.TriggerResize();

    }
}
