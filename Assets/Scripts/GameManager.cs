using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class GameManager : MonoBehaviour
{
    public static GameManager Singleton;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI lifeCountText;
    public TextMeshProUGUI gameOverText;
    public int score;
    private float waitCounter;

    public Button restartButton;                                    
    public bool isGameActive;

    public float lifeCount = 3;


    // Start is called before the first frame update
    void Start()
    {
        waitCounter = 50;
        Singleton = this;
        isGameActive = true;
        lifeCountText.text = "Lives: " + lifeCount;
    }

    // Update is called once per frame
    void Update()
    {
        lifeCountText.text = "Lives: " + lifeCount;

        if (lifeCount <= 0)
        {
            if (waitCounter < 0)
            {
                GameOver();
            }
            waitCounter--;
            return;          
           
        }              

    }

    public void UpdateScore(int scoreToAdd)
    {   
        score += scoreToAdd;
        scoreText.text = "Score:" + score;
    }

    public void CountLife()
    {
        lifeCount = lifeCount - 0.5f;
        Debug.Log("Lost Life. Remaining: " + lifeCount);
    }

    public void GameOver()
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
