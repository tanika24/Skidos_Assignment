using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;

public class ViewHandler : MonoBehaviour
{
    public GameObject studentPrefab;
    public Transform studentParent;
    public UnityEngine.UI.Button fetchBtn;

    public UnityEngine.UI.VerticalLayoutGroup layoutGroup;

    public SubjectListViewHandler subjectListViewHandler;
    public ChapterListViewHandler chapterListViewHandler;
    public SubtopicViewHandler subtopicViewHandler;


    // Start is called before the first frame update


    void OnEnable()
    {
        EventManager.Instance.OnResize += DelayedResize;
        EventManager.Instance.OnSubjectView += OnSubjectView;
        EventManager.Instance.OnChapterView += OnChapterView;
        EventManager.Instance.OnSubtopicView += OnSubtopicView;
    }


    void Resize()
    {
        Debug.Log("false....");
        layoutGroup.enabled = false;
        layoutGroup.enabled = true;
        Debug.Log("true....");
    }

    void DelayedResize()
    {
        Invoke("Resize", 0.5f);
    }

    public void FetchData()
    {
        fetchBtn.enabled = false;
        Debug.Log("fetching data...");

        StartCoroutine("Fetch");
    }

    IEnumerator Fetch()
    {
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        //formData.Add(new MultipartFormDataSection("field1=foo&field2=bar"));
        //formData.Add(new MultipartFormFileSection("my file data", "myfile.txt"));

        UnityWebRequest www = UnityWebRequest.Get("https://5e6b24f90f70dd001643c248.mockapi.io/v1/demo/math/data");
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
            Debug.Log(www.isNetworkError);
            Debug.Log(www.isHttpError);
            Debug.Log(www);
            fetchBtn.enabled = true;
        }
        else
        {
            Debug.Log("Form upload complete!");
            Debug.Log(www.downloadHandler.text);
            // string data = "{[{ \"id\": \"1\",\"createdAt\": \"2020-03-12T22:21:35.592Z\",\"name\": \"Nichole Schneider\",\"avatar\": \"https://s3.amazonaws.com/uifaces/faces/twitter/jeremiaha/128.jpg\"}]}";
            // Debug.Log(data) ;
            // List<ContentField> content =  JsonUtility.FromJson<List<ContentField>>(data);
            JSONNode jSONData = JSON.Parse(www.downloadHandler.text);
            JSONArray jSONArray = (JSONArray)jSONData;
            // JSONArray addition = JSONArray.Parse(jSONArray[0]["Addition"]);
            Debug.Log(jSONArray[0]["Addition"][1]);
            Debug.Log(jSONArray[0]["Addition"]["1"]);
            DisplayData(jSONArray);
        }
    }

    void DisplayData(JSONArray data)
    {
        GameObject obj;
        foreach (var value in data.Values)
        {

            obj = Instantiate(studentPrefab) as GameObject;
            obj.transform.parent = studentParent;
            obj.transform.localScale = Vector3.one;
            obj.GetComponent<StudentDataHandler>().SetData(value);
        }
    }

    void OnSubjectView(SimpleJSON.JSONNode data)
    {
        subjectListViewHandler.Initialise(data);
    }

    void OnChapterView(SimpleJSON.JSONNode data)
    {
        chapterListViewHandler.Initialise(data);
    }

    void OnSubtopicView(SimpleJSON.JSONNode data)
    {
        subtopicViewHandler.Initialise(data);
    }


    void OnDisable()
    {
        EventManager.Instance.OnResize -= DelayedResize;
        EventManager.Instance.OnSubjectView -= OnSubjectView;
        EventManager.Instance.OnChapterView -= OnChapterView;
        EventManager.Instance.OnSubtopicView -= OnSubtopicView;
    }
}



