using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    public float speed = 0.04f;
    public bool tony = true;

    // Start is called before the first frame update
    void Start()
    {
        tony = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * speed);

        if (Input.GetKeyDown(KeyCode.Escape) & tony == true)
        {
            speed = 0f;
            Debug.Log(speed);
            tony = false;
        }
        
        
        if (transform.position.z < 0)
        {
            Destroy(gameObject);
        }
    }

    public void Stop()
    {
        transform.Translate(Vector3.back * 0);
    }

    public void Commence()
    {
        speed = 0.04f;
        Debug.Log(speed);
        tony = true;
    }
}
