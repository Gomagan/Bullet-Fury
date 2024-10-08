using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayScript : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Main Game");
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("TitleScreen");
        Cursor.lockState = CursorLockMode.None;
    }

    public void Controls()
    {
        SceneManager.LoadScene("Controls");
        Cursor.lockState = CursorLockMode.None;
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
        Cursor.lockState = CursorLockMode.None;
    }
}
