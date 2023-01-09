using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaxiPlayer : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float score = 0;
    private float time = 60f;
    private float displayTime;
    public float wheelsOnGround;
    private Vector3 resetRot;
    [SerializeField] float speed;
    [SerializeField] float turnSpeed;
    [SerializeField] List<GameObject> wheels;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI timeText;
    public bool isGameOver;
    public bool isOnGround;


    void Start()
    {
        isGameOver = false;
        resetRot = new Vector3(0, gameObject.transform.eulerAngles.y, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        IsGrounded();
        if(isGameOver == false && isOnGround)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
            transform.Translate(Vector3.right * Time.deltaTime * speed * -verticalInput);
            transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);

            scoreText.text = "Score: " + score;
            Timer();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == ("PickUp"))
        {
            score = score + 1;
            Destroy(collision.gameObject);
        }
        foreach(GameObject wheel in wheels)
        {
            if(collision.gameObject.tag == ("Ground"))
            {
                wheelsOnGround = wheelsOnGround + 1;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        foreach (GameObject wheel in wheels)
        {
            if (collision.gameObject.tag == ("Ground"))
            {
                wheelsOnGround = wheelsOnGround - 1;
            }
        }
    }

    private void Timer()
    {
        if(time > 0)
        {
            time -= Time.deltaTime;
            displayTime = Mathf.Round(time);
            timeText.text = "Time: " + displayTime;
        }
        else if(time == 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        isGameOver = true;
        Debug.Log("Game Over");
    }

    private void IsGrounded()
    {
        
        if(wheelsOnGround > 4)
        {
            isOnGround = true;
        }
        else if(wheelsOnGround <= 4)
        {
            isOnGround = false;
            Debug.Log("Reset Car with Space");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                gameObject.transform.eulerAngles = resetRot;
            }
        }
    }
}
