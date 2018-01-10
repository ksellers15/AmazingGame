using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public MiniGameUIController miniGameUI;
    public GameObject zombie, hide;
    public Vector3 spawnValues;
    public int zombieCount;
    public float startWait;
    public int spawnWait;
    public float waveWait;
    public GameObject startButton;
    public int waveCount = 0;
    public GameObject jump;
    public AudioSource bgMusic;
    public Canvas paused;

    public bool start;
    public bool restart;
    public bool check;
    public bool isPaused;


    // Use this for initialization
    void Awake()
    {
        Time.timeScale = 1.0f;
        StartCoroutine(SpawnWaves());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePauseMenu();
        }
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    private void FixedUpdate()
    {

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
            restart = false;
        }
        else
        {
            paused.GetComponentInChildren<Canvas>().enabled = true;
            Time.timeScale = 0f;
            bgMusic.Pause();
            isPaused = true;
            restart = true;
        }

        Debug.Log("GAMEMANAGER:: TimeScale: " + Time.timeScale);
    }


    public void StartGame()
    {
        start = true;
        startButton.SetActive(false);
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        StartCoroutine(TellJump());
        while (start)
        {
            waveCount += 1;
            miniGameUI.UpdateWave();
            for (int i = 0; i < zombieCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(zombie, spawnPosition, spawnRotation);
                float rand = Random.value;
                if (rand > 0.9)
                    for (int j = 0; j < Random.value; j++)
                    {

                        Vector3 spawnPosition2 = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                        Quaternion spawnRotation2 = Quaternion.identity;
                        Instantiate(hide, spawnPosition2, spawnRotation2);
                    }

                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            zombieCount += 1;

        }
    }

    public void Lose()
    {
        restart = true;
        start = false;
        miniGameUI.LoseText();
    }

    public IEnumerator TellJump()
    {
        if (start)
        {
            yield return new WaitForSeconds((float)1.5);
            jump.SetActive(true);
            yield return new WaitForSeconds(2);
            jump.SetActive(false);
        }
    }

    
}


