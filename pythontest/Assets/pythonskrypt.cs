using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEditor.Scripting.Python;

public class pythonskrypt : MonoBehaviour
{
    [SerializeField] private InputField kod;
    [SerializeField] private Text wynik;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void sprawdz()
    {
        
        //File.AppendAllText(Application.dataPath + "/jeden.py", "import UnityEngine as unity");
        //File.AppendAllText(Application.dataPath + "/jeden.py", "\r\n" + kod.text);
        //File.AppendAllText(Application.dataPath + "/jeden.py", "\r\nzmienna = sprawdzanie()\r\n\r\nif zmienna == \"elo\":\r\n    tekst = unity.GameObject.Find(\"wynik\")\r\n    tekst.text = \"dobrze\"\r\nelse:\r\n    tekst = unity.GameObject.Find(\"wynik\")\r\n    tekst.text = \"zle\"");
        PythonRunner.RunFile(Application.dataPath + "/jeden.py");
        //PythonRunner.RunFile(Application.dataPath + "/glowny.py");
    }
}
