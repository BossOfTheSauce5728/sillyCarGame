using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    public float speed = 0.04f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * speed);

        if (transform.position.z < 0)
        {
            Destroy(gameObject);
        }
    }

    public void Stop()
    {
         speed = 0;
    }

    public void Commence()
    {
        speed = 0.04f;
    }
}
