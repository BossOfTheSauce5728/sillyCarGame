using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriminalSpawner : MonoBehaviour
{

    [SerializeField] GameObject crimPrefab;
    [SerializeField] GameObject watchPrefab;
    private GameObject crimInGame;
    private GameObject watchInGame;
    public bool isCrimSpawned;
    public bool isWatchSpawned;
    Vector3 watchSpawn;
    Vector3 crimSpawn1;
    Vector3 crimSpawn2;
    Vector3 crimSpawn3;
    private float spawn;
    public float waitTime = 10;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        crimSpawn1 = new Vector3(Random.Range(-104, 96), 5.1f, Random.Range(-115, -10));
        //crimSpawn2 = new Vector3(Random.Range(-104, -95), 5.1f, Random.Range(-115, -10));
       // crimSpawn3 = new Vector3(Random.Range(-57, -49), 5.1f, Random.Range(-115, -10));
        watchSpawn = new Vector3(Random.Range(-104, 96), 5.1f, Random.Range(-115, -10));
        //spawn = Random.Range(1, 3);
        IsSpawned();
        SpawnCrim();
        WatchSpawn();
        crimInGame = GameObject.FindGameObjectWithTag("PickUp");
        watchInGame = GameObject.FindGameObjectWithTag("Watch");
        if(isWatchSpawned == true)
        {
            waitTime -= Time.deltaTime;
        }
        if(waitTime <= 0)
        {
            Destroy(watchInGame);
        }
    }

    private void IsSpawned()
    {
        if (crimInGame == true)
        {
            isCrimSpawned = true;
        }
        else if(crimInGame == false)
        {
            isCrimSpawned = false;
        }
        if (watchInGame == true)
        {
            isWatchSpawned = true;
        }
        else if (watchInGame == false)
        {
            isWatchSpawned = false;
        }
    }

    private void SpawnCrim()
    {
        if(isCrimSpawned == false)
        {
            Instantiate(crimPrefab, crimSpawn1, Quaternion.identity);
        }
    }

    private void WatchSpawn()
    {
        if (isWatchSpawned == false)
        {
            Instantiate(watchPrefab, watchSpawn, Quaternion.identity);
            waitTime = 10;
        }
    }
}
