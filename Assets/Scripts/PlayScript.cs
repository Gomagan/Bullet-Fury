using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayScript : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Main Game");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("TitleScreen");
        Cursor.lockState = CursorLockMode.None;
    }

    public void Controls()
    {
        SceneManager.LoadScene("Main Game");
        Cursor.lockState = CursorLockMode.None;
    }

    public void Options()
    {
        SceneManager.LoadScene("Main Game");
        Cursor.lockState = CursorLockMode.None;
    }
}
