using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EnemyController : MonoBehaviour
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
    PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = gameObject.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        HealthText.text = "Player 2 Health: " + Health;

        if (isdead == true)
        {
            HealthText.text = "You're Dead!";
        }

        AI();

        if (isdead == false)
        {
            //left/right and forward/back movement
            horizontalInput = Input.GetAxis("Horizontal2");
            forwardInput = Input.GetAxis("Vertical2");


            // move the vehicle forward
            transform.Translate(Vector3.left * Time.deltaTime * speed * forwardInput);
            transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
        }
        
        if (forwardInput > 0)
        {
            dirtParticle.Play();
        }

        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            explosionParticle.Play();
            explosionParticle2.Play();
        }

        if (Health <= 0)
        {
            StartCoroutine(Kill());

        }
    }

    private void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.tag == "Projectile")
        {
            Health = Health - 1;
            Destroy(other.gameObject);
            
            if(isdead == false)
            {
                audioSource.PlayOneShot(Hurt, 2.0f);
            }
        }
        

    }

    IEnumerator Kill()
    {
        isdead = true;
        audioSource.PlayOneShot(death, 1.0f);
        yield return new WaitForSeconds(4.0f);
        SceneManager.LoadScene("Win");
        
    }


    public void AI()
    {
        //if(PlayerController.playerX < transform.position.x)
        {
            Debug.Log("movin'");
            transform.Translate(Vector3.left * Time.deltaTime * speed);

        }

        //if (PlayerController.playerX > transform.position.x)
        {
            Debug.Log("movin'");
            transform.Translate(Vector3.right * Time.deltaTime * speed);

        }

       




       


    }



}
