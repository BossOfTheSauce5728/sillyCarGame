using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControllerX : MonoBehaviour
{
    public float speed;
    public float speed2;
    public float moveSpeed;
    public float rotationSpeed;
    public float horizontalInput;
    public float horizontalInput2;
    public float verticalInput;
    private int lives;
    public TextMeshProUGUI livesText;
    public Collider collider;

    public AudioSource audioSource;
    public AudioClip audioClip;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        lives = 3;
        Owie();
    }

    private void OnTriggerEnter(Collider other)
    {
        speed2 = speed2 * -1;

      //  if (gameObject.CompareTag("Mario"))
        if(other.gameObject.tag == "Mario")
        {
            audioSource.Play();
            lives -= 1;
            Owie();
            StartCoroutine(wait());

            if(lives < 1)
            {
                GameOver();
            }
        }
    }

    private void Owie()
    {
       livesText.text = "Lives: " + lives;
    }

    IEnumerator wait()
    {
        collider.enabled = false;
        yield return new WaitForSeconds(3);
        collider.enabled = true;
    }

    private void GameOver()
    {
        SceneManager.LoadScene("PlaneCrash");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // get the user's vertical input
        horizontalInput = Input.GetAxis("Horizontal4");

        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * speed);

        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(Vector3.forward * rotationSpeed * horizontalInput * Time.deltaTime);

        horizontalInput2 = Input.GetAxis("Horizontal3");
        transform.Translate(Vector3.right * horizontalInput2 * Time.deltaTime * speed2);

        verticalInput = Input.GetAxis("Vertical3");
        transform.Translate(Vector3.up * verticalInput * Time.deltaTime * speed2);

        if (speed2 <= 0)
        {
            speed2 = speed2 * -1;
        }
    }

    
}
