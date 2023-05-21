using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
    [SerializeField] private GameObject parentCanvas;
    [SerializeField] private GameObject hpCanvas;
    public void Resume()
    {
        parentCanvas.SetActive(false);
        Time.timeScale = 1;
        hpCanvas.SetActive(true);
    }
    public void Options()
    {
        // cos
    }
    public void Save()
    {

    }
    public void SaveandQuit()
    {
        //save
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }
}
