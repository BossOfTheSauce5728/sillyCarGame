using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ParkingArray : MonoBehaviour
{
    public GameObject[] Spots;
    public GameObject CurrentSpot;
    public AudioSource audioSource;
    public AudioClip Score;
    public int score = 0;
    int index;
    public TextMeshProUGUI Scoretext;

    // Start is called before the first frame update
    void Start()
    {
        CallSpot();
    }

    // Update is called once per frame
    void Update()
    {
        Scoretext.text = "Spots Parked " + score;

        if (score == 10)
        {
            StartCoroutine(Win());
        }
    }

    public void CallSpot()
    {
        index = Random.Range(0, Spots.Length);
        CurrentSpot = Spots[index];
        CurrentSpot.SetActive(true);
        
    }

   public void Park(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Parked");
            score = score + 1;
            StartCoroutine(Reset());

        }
    }


    IEnumerator Reset()
    {
        
        audioSource.PlayOneShot(Score, 1.0f);
        yield return new WaitForSeconds(2.0f);
        CurrentSpot.SetActive(false);
        CallSpot();
    }

    IEnumerator Win()
    {
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene("ParkWin");


    }
}
