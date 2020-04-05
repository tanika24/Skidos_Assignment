using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubtopicViewHandler : ListViewBase
{

    public override void Initialise(SimpleJSON.JSONNode dataList)
    {
        base.Initialise(dataList);
        GameObject obj;

        foreach (var value in dataList.Values)
        {
            obj = Instantiate(prefab) as GameObject;
            obj.transform.parent = parent;
            obj.transform.localScale = Vector3.one;
            obj.GetComponent<SubtopicDataHandler>().SetData(value);
        }
    }
}
