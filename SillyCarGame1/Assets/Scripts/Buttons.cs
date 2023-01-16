using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public AudioClip Rev;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CannonCars()
    {
        SceneManager.LoadScene("CannonTutorial");
    }

    public void SoaringSedans()
    {
        SceneManager.LoadScene("FlyingTutorial");
    }

    public void PerilousParking()
    {
        SceneManager.LoadScene("ParkingTutorial");
    }

    public void SnaringSUVS()
    {
        SceneManager.LoadScene("CopTutorial");
    }

    public void TheNoise()
    {
        audioSource.PlayOneShot(Rev, 1.0f);
    }
}

