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
    [SerializeField] float speed;
    [SerializeField] float turnSpeed;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI timeText;

    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * Time.deltaTime * speed * -verticalInput);
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);

        scoreText.text = "Score: " + score;
        Timer();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == ("PickUp"))
        {
            score = score + 1;
            Destroy(collision.gameObject);
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

    }
}
