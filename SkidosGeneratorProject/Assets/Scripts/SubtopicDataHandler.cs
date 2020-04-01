using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubtopicDataHandler : MonoBehaviour
{
    public Text subtopicText;
    SimpleJSON.JSONNode subtopicData;
    public void SetData(SimpleJSON.JSONNode subtopicJson)
    {
        subtopicData = subtopicJson;
        subtopicText.text = subtopicData[AppConstants.SubtopicName];
    }
}
