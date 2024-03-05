using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameManager gameManager;

    public void ResumeGame()
    {
        //gameManager.PauseMenu();
    }

    public void RestartGame()
    {
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
