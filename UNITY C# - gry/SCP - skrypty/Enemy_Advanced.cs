using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Advanced : MonoBehaviour
{
    private Blinking blinking;
    Transform transform_Player;

    private NavMeshAgent Mob;

    public GameObject Player;
    public Transform playerTransform;

    public float MobDistanceRun = 4f;


    //Spawning
    float timer;
    public int spawnDelay = 30;

    public Transform[] spawnPointsLevel1;
    public Transform[] spawnPointsLevel2;
    public Transform[] spawnPointsLevel3;
    public GameObject enemy;

    int randomSpawnPoint;
    int oldRandomSpawnPoint;

    public static bool spawnAllowed;

    //cam shake
    public CameraShake cameraShakeScript;

    // Start is called before the first frame update
    void Start()
    {
        blinking = GameObject.FindObjectOfType<Blinking>();
        transform_Player = GameObject.FindGameObjectWithTag("Player").transform;

        Mob = GetComponent<NavMeshAgent>();

        playerTransform = Player.GetComponent<Transform>();

        cameraShakeScript = GameObject.FindObjectOfType<CameraShake>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, Player.transform.position);

        //run towards
        if (distance < MobDistanceRun && blinking.isBlinking == true)
        {
            StartCoroutine(ExecuteAfterTime(.25f));
        }
        else if(distance > MobDistanceRun)
        {
            timer += Time.deltaTime;

            spawnAllowed = true;

            //After some time enemy spawnes in diffrent spawnpoint
            if (timer > spawnDelay && spawnAllowed)
            {
                Debug.Log("Spawning time!");
                SpawnEnemy();
                Destroy(this.gameObject);
            }
        }

        if (playerTransform.position.y >= 17)
        {
            //camera shake
            cameraShakeScript.enabled = true;
            cameraShakeScript.shakeAmount = 0.02f;
            cameraShakeScript.shakeDuration = 0.02f;
        }
            
    }

    void SpawnEnemy()
    {
        /* backup - working
        randomSpawnPoint = Random.Range(0, spawnPoints.Length);

        //Generate diffrent number from the previous one
        oldRandomSpawnPoint = randomSpawnPoint;
        if(oldRandomSpawnPoint == randomSpawnPoint)
        {
            randomSpawnPoint = Random.Range(0, spawnPoints.Length);
            Instantiate(enemy, spawnPoints[randomSpawnPoint].position, Quaternion.identity);
        }
        else
        {
            Instantiate(enemy, spawnPoints[randomSpawnPoint].position, Quaternion.identity);
        }
        */

        if (playerTransform.position.y < 13) //if player is on the first floor spawn on the first 4 spawn points
        {
            randomSpawnPoint = Random.Range(0, spawnPointsLevel1.Length);

            //Generate diffrent number from the previous one
            oldRandomSpawnPoint = randomSpawnPoint;
            if (oldRandomSpawnPoint == randomSpawnPoint)
            {
                randomSpawnPoint = Random.Range(0, spawnPointsLevel1.Length);
                Instantiate(enemy, spawnPointsLevel1[randomSpawnPoint].position, Quaternion.identity);
            }
            else
            {
                Instantiate(enemy, spawnPointsLevel1[randomSpawnPoint].position, Quaternion.identity);
            }
        }
        else if(playerTransform.position.y >= 13 && playerTransform.position.y < 15) //if player is on the second floor spawn on the diffrent spawnpoints
        {
            randomSpawnPoint = Random.Range(0, spawnPointsLevel2.Length);

            //Generate diffrent number from the previous one
            oldRandomSpawnPoint = randomSpawnPoint;
            if (oldRandomSpawnPoint == randomSpawnPoint)
            {
                randomSpawnPoint = Random.Range(0, spawnPointsLevel2.Length);
                Instantiate(enemy, spawnPointsLevel2[randomSpawnPoint].position, Quaternion.identity);
            }
            else
            {
                Instantiate(enemy, spawnPointsLevel2[randomSpawnPoint].position, Quaternion.identity);
            }
        }
        else if (playerTransform.position.y >= 17) //if player is on the third floor spawn on the diffrent spawnpoints
        {
            spawnDelay = 2;
            MobDistanceRun = 12;

            //camera shake
            cameraShakeScript.enabled = true;
            cameraShakeScript.shakeAmount = 0.02f;
            cameraShakeScript.shakeDuration = 0.02f;

            randomSpawnPoint = Random.Range(0, spawnPointsLevel3.Length);

            //Generate diffrent number from the previous one
            oldRandomSpawnPoint = randomSpawnPoint;
            if (oldRandomSpawnPoint == randomSpawnPoint)
            {
                randomSpawnPoint = Random.Range(0, spawnPointsLevel3.Length);
                Instantiate(enemy, spawnPointsLevel3[randomSpawnPoint].position, Quaternion.identity);
            }
            else
            {
                Instantiate(enemy, spawnPointsLevel3[randomSpawnPoint].position, Quaternion.identity);
            }
        }

    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        try
        {
            Vector3 dirToPlayer = transform.position - Player.transform.position;
            transform.LookAt(transform_Player);
            Vector3 newPos = transform.position - dirToPlayer;

            //Mob.SetDestination(newPos);

            Mob.destination = newPos;   
        }
        catch
        {
            Debug.Log("nie ruszam sie");
        }
    }
}
