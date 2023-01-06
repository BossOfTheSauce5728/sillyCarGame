using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingArray : MonoBehaviour
{
    public List<GameObject> Spots;
    public GameObject CurrentSpot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CallSpot()
    {
        CurrentSpot = Spots[Random.Range(0, Spots.Count)];
    }
}
