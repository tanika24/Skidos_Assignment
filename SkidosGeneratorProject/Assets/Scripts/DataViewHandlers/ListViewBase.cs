using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public abstract class ListViewBase : MonoBehaviour
{
    public GameObject prefab;
    public Transform parent;


    public virtual void Initialise(JSONNode dataList)
    {
        CleanPreviousData();
        gameObject.SetActive(true);
    }

    void CleanPreviousData()
    {
        int count = parent.childCount;
        for (int i = 0; i < count; i++)
        {
            Destroy(parent.GetChild(i).gameObject);
        }

    }

    public virtual void Close()
    {
        gameObject.SetActive(false);
    }
}
