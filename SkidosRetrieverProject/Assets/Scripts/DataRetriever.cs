using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class DataRetriever : MonoBehaviour
{
    public Text resultTxt;
    public Text warningTxt;

    const string generatorPkgName = "com.Skidos.Generator";
    const string fileName = "KVPData.txt";

    // Start is called before the first frame update
    void Start()
    {

        Invoke("ShowData", 2);
    }

    void ShowData()
    {
        // string path = "C:/Users/pc/AppData/LocalLow/DefaultCompany/SkidosGeneratorProject/KVPData.txt";
        string path = Path.Combine(Application.persistentDataPath.Replace(Application.identifier, generatorPkgName), fileName);
        warningTxt.text = path;
        StreamReader reader = new StreamReader(path);
        string lineA = reader.ReadLine();
        resultTxt.text = lineA;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
