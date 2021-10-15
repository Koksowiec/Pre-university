using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableLevel : MonoBehaviour
{
    public Transform playerTransform;

    public GameObject[] levelToDisable;
    public int numberOfLevelToDisable;

    // Start is called before the first frame update
    void Start()
    {
        //playerTransform = GameObject.FindObjectOfType<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        playerTransform = GameObject.FindObjectOfType<Transform>();

        if (playerTransform.position.y < 12)
        {
            for(int i = 0; i < numberOfLevelToDisable; i++)
            {
                levelToDisable[i].SetActive(false);
            }

        }
        else //if (playerTransform.position.y >= 13)
        {
            for (int i = 0; i < numberOfLevelToDisable; i++)
            {
                levelToDisable[i].SetActive(true);
            }       
        }
    }
}
