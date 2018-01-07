using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIController : MonoBehaviour
{

    public GameObject GC;
    public GameController gameController;
    public GameObject pm;
    public PlayerMovement playerMovement;
    public Canvas winCanvas;
    public Text winText;
    public Text restartText, restartText1;
    public Text timeText;
    public Text timeLeft;
    public Text playerHealth;
    public Text loseText;
    public GameObject loadingImage;
    public bool isWin;
    public bool isLose;

    // Use this for initialization
    void Awake()
    {

        GC = GameObject.FindGameObjectWithTag("GameController");
        gameController = GC.GetComponent<GameController>();
        pm = GameObject.FindGameObjectWithTag("Player");
        playerMovement = pm.GetComponent<PlayerMovement>();
        winText.text = "";
        loseText.text = "";
        restartText1.text = "";
        isWin = false;
        isLose = false;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft.text = gameController.seconds.ToString();
        playerHealth.text = "Health: " + playerMovement.health.ToString();


    }

    public void WinScreen()
    {

        {
            int time = (int)Time.timeSinceLevelLoad;
            winCanvas.GetComponentInChildren<Canvas>().enabled = true;
            winText.text = "You Made It!";
            isWin = true;
            restartText.text = "Press R to restart!";
            timeText.text = "It took you " + time.ToString() + " seconds";
        }
    }

    public void LoseScreen()
    {

        isWin = false;
        isLose = true;
        loseText.text = "YOU LOST";
        restartText1.text = "Press R to restart!";
    }
}
