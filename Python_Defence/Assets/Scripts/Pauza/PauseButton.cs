using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
    [SerializeField] private GameObject parentCanvas;
    [SerializeField] private GameObject hpCanvas;
    [SerializeField] GameObject mainPause;
    [SerializeField] GameObject HTPPause;
    public void Resume()
    {
        parentCanvas.SetActive(false);
        Time.timeScale = 1;
        hpCanvas.SetActive(true);
    }
    public void HTPButton()
    {
       HTPPause.SetActive(true);
       mainPause.SetActive(false);
    }
    public void ExitHTPButton()
    {
        HTPPause.SetActive(false);
        mainPause.SetActive(true);
    }
    public void SaveandQuit()
    {
        //save
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }
}
