using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class DataRetriever : MonoBehaviour
{
    public Text resultTxt;

    const string generatorPkgName = "com.Skidos.Generator";
    const string fileName = "KVPData.txt";

    // Start is called before the first frame update
    void Start()
    {

        Invoke("ShowData", 2);
    }

    void ShowData()
    {
        string path = Path.Combine(Application.persistentDataPath.Replace(Application.identifier, generatorPkgName), fileName);
        StreamReader reader = new StreamReader(path);
        string lineA = reader.ReadToEnd();
        resultTxt.text = lineA;
    }

}
