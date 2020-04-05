using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterListViewHandler : ListViewBase
{
    public override void Initialise(SimpleJSON.JSONNode dataList)
    {
        base.Initialise(dataList);
        GameObject obj;

        foreach (var key in dataList.Keys)
        {
            obj = Instantiate(prefab) as GameObject;
            obj.transform.parent = parent;
            obj.transform.localScale = Vector3.one;
            obj.GetComponent<ChapterHandler>().SetData(key, dataList[key]);
        }
    }
}
