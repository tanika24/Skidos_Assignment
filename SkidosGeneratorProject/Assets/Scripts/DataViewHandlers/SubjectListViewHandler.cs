using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubjectListViewHandler : ListViewBase
{
    public override void Initialise(SimpleJSON.JSONNode dataList)
    {
        base.Initialise(dataList);
        GameObject obj;

        string[] subjects = { AppConstants.Addition, AppConstants.Geometry, AppConstants.MixedOperations, AppConstants.NumberSense, AppConstants.Subtraction };

        foreach (string subject in subjects)
        {
            obj = Instantiate(prefab) as GameObject;
            obj.transform.parent = parent;
            obj.transform.localScale = Vector3.one;
            obj.GetComponent<SubjectDataHandler>().SetData(subject, dataList[subject]);
        }
    }
}
