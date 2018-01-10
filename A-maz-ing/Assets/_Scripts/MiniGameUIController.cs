using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MiniGameUIController : MonoBehaviour
{
    public MiniGameBallAttack ballAttack;
    public SpawnEnemies spawnEnemies;

    public Text restartText, waveText, scoreText, winText, resultsText;
    // Use this for initialization
    void Awake()
    {
        restartText.text = "";
        winText.text = "";
    }



    // Update is called once per frame
    void Update()
    {
        if (spawnEnemies.restart)
        {
            restartText.text = "Press 'R' to restart";

        }
        else
            restartText.text = "";
    }

    public void UpdateScore()
    {
        scoreText.text = "Score: " + ballAttack.score;
    }

    public void UpdateWave()
    {
        waveText.text = "Wave " + spawnEnemies.waveCount;
    }

    public void LoseText()
    {
        restartText.text = "Press 'R' to restart";
        winText.text = "Game Over";
        resultsText.text = "You survived " + spawnEnemies.waveCount + " waves!";  
    }
}
