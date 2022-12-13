using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CannonCars()
    {
        SceneManager.LoadScene("CannonTutorial");
    }

    void SoaringSedans()
    {
        SceneManager.LoadScene("FlyingMini");
    }

    void PerilousParking()
    {
        SceneManager.LoadScene("");
    }

    void SnaringSUVS()
    {
        SceneManager.LoadScene("CopTutorial");
    }
}
