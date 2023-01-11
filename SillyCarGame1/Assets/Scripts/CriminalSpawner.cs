using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriminalSpawner : MonoBehaviour
{

    [SerializeField] GameObject crimPrefab;
    private GameObject crimInGame;
    public bool isCrimSpawned;
    Vector3 crimSpawn;
    public float waitTime = 10;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        crimSpawn = new Vector3(Random.Range(-104, 96), 5.1f, Random.Range(-115, -10));
        IsSpawned();
        SpawnCrim();
        crimInGame = GameObject.FindGameObjectWithTag("PickUp");
        if(isCrimSpawned == true)
        {
            waitTime -= Time.deltaTime;
        }
        if(waitTime <= 0)
        {
            Destroy(crimInGame);
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
    }

    private void SpawnCrim()
    {
        if(isCrimSpawned == false)
        {
            Instantiate(crimPrefab, crimSpawn, Quaternion.identity);
            waitTime = 10;
        }
    }
}
