using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using IronPython.Hosting;
using PythonDefence.UI;
using TMPro;
using UnityEngine;

namespace PythonDefence.Compiler
{
    public class compiler : MonoBehaviour
    {
        public TMP_InputField tmpro;
        private string kod;
        public TMP_Text output;
        public TMP_Text prereq;
        public string desiredOutput;
        public string secOutput;
   
        public TMP_Text desOut;
        public bool result;
        string replacement;
        public string addition;
        public string polecenie;
        public string condition;
        public string stale;
        public TMP_Text textplace;
        public PythonGame scriptwyw;
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
                File.WriteAllText(plik, stale);
                File.AppendAllText(plik, kod);
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
            if(condition!= string.Empty)
            {
            
                if (!tmpro.text.Contains(condition))
                {

                    scriptwyw.result = false;
                    output.color = Color.red;
                
                }
                else
                {
                    if(secOutput != string.Empty)
                    {
                        if (replacement == desiredOutput)
                        {
                        
                            scriptwyw.result = true;
                            output.color = Color.green;
                            StartCoroutine(WaitSeconds());
                        }
                        else if (replacement == secOutput)
                        {
                       
                            scriptwyw.result = true;
                            output.color = Color.green;
                            StartCoroutine(WaitSeconds());

                        }
                        else
                        {
                        
                            scriptwyw.result = false;
                            output.color = Color.red;
                        }
                    }
                    else
                    {
                        if (replacement == desiredOutput)
                        {
                        
                            scriptwyw.result = true;
                            output.color = Color.green;
                            StartCoroutine(WaitSeconds());
                        }
                        else
                        {
                        
                            scriptwyw.result = false;
                            output.color = Color.red;
                        }
                    }

                }
            }
            else
            {
            
                if (secOutput != string.Empty)
                {
                    if (replacement == desiredOutput)
                    {
                   
                        scriptwyw.result = true;
                        output.color = Color.green;
                        StartCoroutine(WaitSeconds());
                    }
                    else if (replacement == secOutput)
                    {
                    
                        scriptwyw.result = true;
                        output.color = Color.green;
                        StartCoroutine(WaitSeconds());

                    }
                    else
                    {
                    
                        scriptwyw.result = false;
                        output.color = Color.red;
                    }
                }
                else
                {
                    if (replacement == desiredOutput)
                    {
                    
                        scriptwyw.result = true;
                        output.color = Color.green;
                        StartCoroutine(WaitSeconds());
                    }
                    else
                    {
                    
                        scriptwyw.result = false;
                        output.color = Color.red;
                    }
                }
            }
        
        
       
        }
        public void LoadNewTask()
        {
            output.text = string.Empty;
            desOut.text = string.Empty;
            tmpro.text = string.Empty;
            desOut.text = polecenie;
            prereq.text = stale;
        
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
}
