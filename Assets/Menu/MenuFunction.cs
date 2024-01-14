using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFunction : MonoBehaviour
{
    public void newgame()
    {
        SceneManager.LoadScene(1);
    }
    public void exitmenu()
    {
        SceneManager.LoadScene(0);
    }

    public void pause()
    {
        //SceneManager.SetActive(true);
        Time.timeScale = 0;
    }

    public void Continue()
    {
        //SceneManager.SetActive(true);
        Time.timeScale = 1;
    }

    public void exit()
    {
        //Application.Quit();
        Debug.Log("QUIT");
    }
}
