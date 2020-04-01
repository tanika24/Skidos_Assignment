using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class StudentDataHandler : MonoBehaviour
{

    public Image profileImg;
    public Text studentNameTxt;
    private SimpleJSON.JSONNode studentData;

    public GameObject subjectPrefab;
    public Transform subjectParent;

    private bool isExpanded;

    public void SetData(SimpleJSON.JSONNode data)
    {
        studentData = data;
        studentNameTxt.text = studentData["name"];
        StartCoroutine("LoadImage");

    }

    IEnumerator LoadImage()
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(studentData["avatar"]);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
            Debug.Log(request.error);
        else
        {
            Texture2D tex = ((DownloadHandlerTexture)request.downloadHandler).texture;
            profileImg.sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
        }
    }

    public void OnExpand()
    {
        if (isExpanded)
        {
            subjectParent.gameObject.SetActive(false);
        }
        else
        {
            if (subjectParent.childCount > 0)
            {
                subjectParent.gameObject.SetActive(true);
            }
            else
            {
                GameObject obj;

                string[] subjects = { AppConstants.Addition, AppConstants.Geometry, AppConstants.MixedOperations, AppConstants.NumberSense, AppConstants.Subtraction };

                foreach (string subject in subjects)
                {
                    obj = Instantiate(subjectPrefab) as GameObject;
                    obj.transform.parent = subjectParent;
                    obj.GetComponent<SubjectDataHandler>().SetData(subject, studentData[subject]);
                }
            }
        }
        isExpanded = !isExpanded;
        EventManager.Instance.TriggerResize();

    }
}
