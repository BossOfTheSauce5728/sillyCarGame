using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaxiPlayer : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private Rigidbody playerRb;
    [SerializeField] float speed;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * Time.deltaTime * speed * verticalInput);
        transform.Rotate(Vector3.up, 55 * horizontalInput * Time.deltaTime);
    }
}
