using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject UI;
    public UIController uiController;
    public Canvas paused;
    public AudioSource bgMusic;
    public AudioSource lose;
    public GameObject pm;
    public PlayerMovement playerMovement;

    public bool isPaused;
    public float seconds;


	// Use this for initialization
	void Awake () {
        UI = GameObject.FindGameObjectWithTag("UI");
        uiController = UI.GetComponent<UIController>();
        pm = GameObject.FindGameObjectWithTag("Player");
        playerMovement = pm.GetComponent<PlayerMovement>();

        StartCoroutine("StartTimer");

    }

    // Update is called once per frame
    void Update () {
        
        if (uiController.isWin || uiController.isLose)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePauseMenu();
        }

        if(seconds == 0 && !uiController.isWin || playerMovement.dead)
        {
            Lose();
        }

    }

    IEnumerator StartTimer()
    {
        while (seconds > 0 && !uiController.isWin)
        {
            yield return new WaitForSeconds(1);
            seconds--;
        }
    }

        public void TogglePauseMenu()
    {
        // not the optimal way but for the sake of readability
        if (isPaused)
        {
            paused.GetComponentInChildren<Canvas>().enabled = false;
            Time.timeScale = 1.0f;
            bgMusic.UnPause();
            isPaused = false;
        }
        else
        {
            paused.GetComponentInChildren<Canvas>().enabled = true;
            Time.timeScale = 0f;
            bgMusic.Pause();
            isPaused = true;
        }

        Debug.Log("GAMEMANAGER:: TimeScale: " + Time.timeScale);
    }

    void Lose()
    {
        uiController.LoseScreen();
        bgMusic.Pause();
        //lose.Play();
       
    }

    public void OnClickStart(int level)
    {
        uiController.loadingImage.SetActive(true);
        SceneManager.LoadScene(level);
    }
}
