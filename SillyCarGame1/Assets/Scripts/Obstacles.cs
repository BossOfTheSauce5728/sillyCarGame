using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public GameObject[] obstacles;
    private float spawnPosX = 7.029203f;
    private float spawnPosY = 1.63837f;
    private float spawnPosZ = 333.9929f;

    private float startDelay = 1.0f;
    private float spawnInterval = 4.0f;

    private Move moveScript;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(wait());
        InvokeRepeating("SpawnObstacle", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(10);
        Debug.Log("Speed Up!");
        spawnInterval -= 0.5f;
    }

    void SpawnObstacle()
    {
        Vector3 spawnPos = new Vector3(spawnPosX, spawnPosY, spawnPosZ);
        int obIndex = Random.Range(0, obstacles.Length);
        Instantiate(obstacles[obIndex], spawnPos, obstacles[obIndex].transform.rotation);
    }
}
