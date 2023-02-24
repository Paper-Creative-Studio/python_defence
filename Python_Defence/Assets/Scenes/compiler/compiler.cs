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
using UnityEditor.UI;
using System.Linq;
using System.Text.RegularExpressions;
using static IronPython.Modules.PythonDateTime;


public class compiler : MonoBehaviour
{
    public TMP_InputField tmpro;
    private string kod;
    public TMP_Text output;
    public string desiredOutput;
    public TMP_Text desOut;
    public bool result;
    string replacement;
    public string addition;
    public string polecenie;
    public string stale;
    public TMP_Text textplace;
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
        try
        {
            var engine = Python.CreateEngine();

            string plik = Application.dataPath + "/pyton.py";
            
            kod = tmpro.text;
            File.WriteAllText(plik, kod);
            File.AppendAllText(plik, addition);
            var source = engine.CreateScriptSourceFromFile(plik);
            var eIO = engine.Runtime.IO;
            var errors = new MemoryStream();
            eIO.SetErrorOutput(errors, Encoding.Default);
            var results = new MemoryStream();
            eIO.SetOutput(results, Encoding.Default);
            var scope = engine.CreateScope();
            source.Execute(scope);
            string str(byte[] x) => Encoding.UTF8.GetString(x);
            output.text = str(results.ToArray());
           
            replacement = Regex.Replace(output.text, @"\t|\n|\r", "");

        }
        catch(Exception ex)
        {
            output.text = ex.Message;
            
        }
        if(replacement == desiredOutput)  
        {
            result = true;
            output.color = Color.green;
            StartCoroutine(WaitSeconds());
        }
        else
        {
            result = false;
            output.color = Color.red;
        }
       
    }
    public void LoadNewTask()
    {
        output.text = string.Empty;
        desOut.text = string.Empty;
        tmpro.text = string.Empty;
        desOut.text = polecenie;
        tmpro.text = stale;
        
    }
    IEnumerator WaitSeconds()
    {
        yield return new WaitForSecondsRealtime(3);
        output.text = "";
        kod = "";
        tmpro.text = kod;
        Time.timeScale = 1; 
        transform.parent.parent.gameObject.SetActive(false);
        
    }

}
