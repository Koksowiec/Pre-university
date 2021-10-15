using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCards : MonoBehaviour
{
    //Spawning
    public Transform[] spawnPoints;
    public GameObject card;
    int randomSpawnPoint;
    int oldRandomSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        SpawnCard();
    }

    void SpawnCard()
    {
        randomSpawnPoint = Random.Range(0, spawnPoints.Length);

        //Generate diffrent number from the previous one
        oldRandomSpawnPoint = randomSpawnPoint;

        if (oldRandomSpawnPoint == randomSpawnPoint)
        {
            randomSpawnPoint = Random.Range(0, spawnPoints.Length);
            Instantiate(card, spawnPoints[randomSpawnPoint].position, spawnPoints[randomSpawnPoint].rotation);
        }
        else
        {
            Instantiate(card, spawnPoints[randomSpawnPoint].position, spawnPoints[randomSpawnPoint].rotation);
        }
    }
}
