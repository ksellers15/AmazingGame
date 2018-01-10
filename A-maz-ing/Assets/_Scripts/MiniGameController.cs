using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameController : MonoBehaviour
{
    public GameObject zombie;
    public Vector3 spawnValues;
    public int zombieCount;
    public int startWait;

    public bool start;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void StartGame()
    {
        start = true;
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (start)
        {
            //UpdateWave();
            yield return new WaitForSeconds(startWait);
            for (int i = 0; i < zombieCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(zombie, spawnPosition, spawnRotation);
                zombieCount += 5;
                /*float rand = Random.value;
                if (rand > 0.9)
                    for (int j = 0; j < Random.value; j++)
                    {

                        Vector3 spawnPosition2 = new Vector3(Random.Range(-spawnValues2.x, spawnValues2.x), spawnValues2.y, spawnValues2.z);
                        Quaternion spawnRotation2 = Quaternion.identity;
                        Instantiate(powerUps, spawnPosition2, spawnRotation2);
                    }*/
            }
        }
    }
}

