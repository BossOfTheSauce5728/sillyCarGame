using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaxiPlayer : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    [SerializeField] float speed;
    public float score;

    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * Time.deltaTime * speed * verticalInput);
        transform.Rotate(Vector3.up, 55 * horizontalInput * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == ("PickUp"))
        {
            score = score + 1;
            Destroy(collision.gameObject);
        }
    }
}
