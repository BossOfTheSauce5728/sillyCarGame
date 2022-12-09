using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Projectile : MonoBehaviour
{
    public GameObject projectile;
    public AudioSource audioSource;
    public float launchVelocity;
    
    bool cooldown;
    public AudioClip shoot;
    

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    IEnumerator Shoot()
    {
        audioSource.PlayOneShot(shoot);
        yield return new WaitForSeconds(3);
        cooldown = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && cooldown == false)
        {
            GameObject ball = Instantiate(projectile, transform.position, transform.rotation);

            ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, launchVelocity, 0));

             cooldown = true;
            StartCoroutine(Shoot());

        }

        

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("AGH");

    }





}
