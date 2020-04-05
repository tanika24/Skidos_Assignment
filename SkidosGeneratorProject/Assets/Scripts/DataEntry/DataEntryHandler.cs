using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Android;


public class DataEntryHandler : MonoBehaviour
{
    public InputField keyInput;
    public InputField valueInput;
    public void OpenDataEntry()
    {
        gameObject.SetActive(true);
    }

    void OnEnable()
    {

        if (!Permission.HasUserAuthorizedPermission(Permission.ExternalStorageWrite))
        {
            Permission.RequestUserPermission(Permission.ExternalStorageWrite);
        }
    }

    public void SaveData()
    {

        string data = keyInput.text + ":" + valueInput.text + "\n";
        string path = Path.Combine(Application.persistentDataPath, "KVPData.txt");
        StreamWriter writer = new StreamWriter(path, true);
        writer.Write(data);
        writer.Close();
        Debug.Log(Application.identifier);

    }
    public void CloseDataEntry()
    {
        gameObject.SetActive(false);
    }
}
