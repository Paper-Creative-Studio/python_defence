
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject mainCanvas;
    [SerializeField] GameObject HTPCanvas;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartButton()
    {
        SceneManager.LoadScene("Defense");
    }
    public void HTPButton()
    {
        
        HTPCanvas.SetActive(true);
        mainCanvas.SetActive(false);
    }
    public void ExitHTPButton()
    {
        mainCanvas.SetActive(true);
        HTPCanvas.SetActive(false);
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}
