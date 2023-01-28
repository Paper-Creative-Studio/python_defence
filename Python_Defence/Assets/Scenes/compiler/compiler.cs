using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using System.IO;
using IronPython.Hosting;
using System.Text;
using UnityEngine.Rendering;
using Microsoft.Unity.VisualStudio.Editor;

public class compiler : MonoBehaviour
{
    public TMP_InputField tmpro;
    private String kod;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    public void wpiszdopliku()
    {
        var engine = Python.CreateEngine();
        
        string plik = Application.dataPath + "/pyton.py";
        
        kod = tmpro.text;
        File.WriteAllText(plik, kod);
        var source = engine.CreateScriptSourceFromFile(plik);
        var eIO = engine.Runtime.IO;
        var errors = new MemoryStream();
        eIO.SetErrorOutput(errors, Encoding.Default);
        var results = new MemoryStream();
        eIO.SetOutput(results, Encoding.Default);
        var scope = engine.CreateScope();
        source.Execute(scope);
        string str(byte[] x) => Encoding.Default.GetString(x);
        Debug.Log(str(results.ToArray()));






    }

}
