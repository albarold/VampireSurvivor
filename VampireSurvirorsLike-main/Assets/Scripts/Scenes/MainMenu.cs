using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Represents the main menu of the game
/// </summary>
public class MainMenu : MonoBehaviour
{

    public void OnClickPlay()
    {
        SceneManager.LoadScene("MainGameplay");
        Debug.Log("Play");
    }

    public void OnClickQuit()
    {
        Debug.Log("quit");
        Application.Quit();
    }
    
}
