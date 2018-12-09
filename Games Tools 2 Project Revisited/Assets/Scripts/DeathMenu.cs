using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour
{
    public Text scoreText;
    public Image backgroundImg;

    private float transition = 0.0f;

    // Relates to the dark image when the player dies
    public bool isShown = false;

	// Use this for initialization
	void Start ()
    {
        // Turns off the black screen when you play the game
        gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update ()
    {
        // If the image comes up, prevents the player from interacting with the game further
        if (!isShown)
            return;

        // If the image shows, colour it dark
        transition += Time.deltaTime;
        backgroundImg.color = Color.Lerp(new Color(0, 0, 0, 0), Color.black, transition);
	}

    // Calls function and places in scoretext on screen when the player dies in game
    public void ToggleEndMenu(float score)
    {
        gameObject.SetActive (true);
        scoreText.text = ((int)score).ToString();
        isShown = true;
    }

    // Allows the player to play the game again
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Allows the player to return to the main menu
    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
