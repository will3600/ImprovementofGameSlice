using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text highscoreText;

    // Use this for initialization
    void Start()
    {
        // Writes whatever your highscore is on the main menu screen
        highscoreText.text = "Highscore " + ((int)PlayerPrefs.GetFloat("Highscore")).ToString();
    }

    public void ToGame()
    {
        // Loads the scene Game
        SceneManager.LoadScene("Game");
    }
}
