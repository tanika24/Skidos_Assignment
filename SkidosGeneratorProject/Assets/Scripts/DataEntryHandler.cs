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
    public Text result;
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

        result.text = Application.persistentDataPath;
        string data = keyInput.text + ":" + valueInput.text;
        // File.Open("some path", FileMode.OpenOrCreate);
        //     using (FileStream fileStream = File.Open(GetFullPath(fileName), FileMode.OpenOrCreate))
        //     {
        //         fileStream.
        //     }
        string path = Path.Combine(Application.persistentDataPath, "KVPData.txt");
        StreamWriter writer = new StreamWriter(path, true);
        writer.Write(data);
        writer.Close();
        Debug.Log(Application.identifier);
        // FileStream fs = File.Open(path, FileMode.OpenOrCreate);
        // fs.Write(System.Text.Encoding.UTF8.GetBytes(data));
        // // fs.Write(data);
        //  // Read
        //  StreamReader reader = new StreamReader("MyPath.txt");
        //  string lineA = reader.ReadLine();
        //  string[] splitA = lineA.Split(',');
        //  scoreA = int.Parse(splitA[1]);

        //  string lineB = reader.ReadLine();
    }
    public void CloseDataEntry()
    {
        gameObject.SetActive(false);
    }
}
