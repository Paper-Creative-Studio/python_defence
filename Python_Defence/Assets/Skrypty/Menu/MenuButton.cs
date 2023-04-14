
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    // Start is called before the first frame update
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
    public void OptionButton()
    {
        //nie wiem
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}
