using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // Holds the score
    private float score = 0.0f;

    // Beginning diffiuclty level 
    private int difficultyLevel = 1;

    // Max difficulty level
    private int maxDifficultyLevel = 10;

    // Score needed for next level
    private int scoreToNextLevel = 40;

    // isDead false when you have not hit a collider
    private bool isDead = false;

    // Access to the public field on the player 
    public Text scoreText;

    // Access to the public field on the player 
    public DeathMenu deathMenu;

	// Update is called once per frame
	void Update ()
    {
        if (isDead)
            return;

        // Goes to next level if the score is higher then the next level
        if (score >= scoreToNextLevel)
            LevelUp();

        // Players Y value diveded by 10 multiplied by difficulty level is added to the score 
        score += Input.GetAxis("Vertical") /10 * difficultyLevel;
        
        // Score is cast into an int and so written in the scoresaver on screen when playing
        scoreText.text = ((int)score).ToString();
    }

    // Level up function
    void LevelUp()
    {
        // Prevents going over difficulty level
        if (difficultyLevel == maxDifficultyLevel)
            return;

        // Multiplies score to next value by 2. e.g 10 * 2 = 20. 20 * 2 = 40, etc.
        scoreToNextLevel *= 2;
        difficultyLevel++;

        // Calls speed function in PlayerMove script
        GetComponent<PlayerMove>().SetSpeed(difficultyLevel);
        
        // Just to show what difficulty level you make it to
        Debug.Log(difficultyLevel);
    }

    public void OnDeath()
    {
        // isDead true when you do hit a collider
        isDead = true;

        // Makes it so that it does not save a lower score then your highscore
        if (PlayerPrefs.GetFloat("Highscore") < score)
        
            // Saves Score
            PlayerPrefs.SetFloat("Highscore", score);
            
        // When the player dies, the death menu pops up
        deathMenu.ToggleEndMenu(score);
    }
}
