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
        EventManager.Instance.TriggerSubjectView(studentData);

    }
}
