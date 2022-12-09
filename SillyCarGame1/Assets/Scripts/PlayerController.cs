using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 20;
    public float turnSpeed;
    public float horizontalInput;
    public float forwardInput;
    public ParticleSystem explosionParticle;
    public ParticleSystem explosionParticle2;
    public ParticleSystem dirtParticle;
    public int Health = 3;
    public AudioClip death;
    public AudioClip Hurt;
    public AudioSource audioSource;
    public bool isdead = false;
    public TextMeshProUGUI HealthText;
    static public float playerX;
    static public float playerZ;
    static public float playerRot;
    static public GameObject PortSide;
    static public GameObject StarSide;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HealthText.text = "Player 1 Health: " + Health; 

        if (isdead == false)
        {
            //left/right and forward/back movement
            horizontalInput = Input.GetAxis("Horizontal");
            forwardInput = Input.GetAxis("Vertical");


            // move the vehicle forward
            transform.Translate(Vector3.left * Time.deltaTime * speed * forwardInput);
            transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
        }

        if (isdead == true)
        {
            HealthText.text = "You're Dead!";
        }
        

        if (forwardInput > 0)
        {
            dirtParticle.Play();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            explosionParticle.Play();
            explosionParticle2.Play();
        }

        if (Health <= 0)
        {
            isdead = true;
            StartCoroutine(Kill());
            
        }

        playerX = transform.position.x;
        playerZ = transform.position.z;
        playerRot = transform.rotation.y;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Projectile2")
        {
            Health = Health - 1;
            Destroy(other.gameObject);
            
            
            if(isdead == false)
            {
                audioSource.PlayOneShot(Hurt, 1.0f);
            }

        }


    }

    IEnumerator Kill()
    {
        isdead = true;
        audioSource.PlayOneShot(death, 1.0f);
        yield return new WaitForSeconds(4.0f);
        SceneManager.LoadScene("Lose");

    }





}
