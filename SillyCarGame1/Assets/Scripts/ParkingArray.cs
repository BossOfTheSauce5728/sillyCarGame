using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingArray : MonoBehaviour
{
    public GameObject[] Spots;
    public GameObject CurrentSpot;
    public AudioSource audioSource;
    public AudioClip Score;
    int index;

    // Start is called before the first frame update
    void Start()
    {
        CallSpot();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CallSpot()
    {
        index = Random.Range(0, Spots.Length);
        CurrentSpot = Spots[index];
        CurrentSpot.SetActive(true);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Test");
            StartCoroutine(Reset());

        }


    }


    IEnumerator Reset()
    {
        
        audioSource.PlayOneShot(Score, 1.0f);
        yield return new WaitForSeconds(2.0f);
        CallSpot();
    }
}
