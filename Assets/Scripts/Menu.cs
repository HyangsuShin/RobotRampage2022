using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Click Begin button -> load battle scene
    public void StartGame()
    {
        SceneManager.LoadScene("Battle");
    }

    // Exit the app
    public void Quit()
    {
        Application.Quit();
    }
}
