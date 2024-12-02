using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float moveSpeed = 5f;
    private float xBounds = 13.5f;
    private float zBounds = 9f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Get inputs
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        Vector3 moveDir = new Vector3(horiz, 0, vert);
        //Move player on X/Z axes
        transform.Translate(moveDir.normalized * moveSpeed * Time.deltaTime);

        //Keep player in bounds
        if(transform.position.x > xBounds)
        {
            transform.position = new Vector3(xBounds, 0, transform.position.z);
        }
        if (transform.position.x < -xBounds)
        {
            transform.position = new Vector3(-xBounds, 0, transform.position.z);
        }
        if (transform.position.z > zBounds)
        {
            transform.position = new Vector3(transform.position.x, 0, zBounds);
        }
        if (transform.position.z < -zBounds)
        {
            transform.position = new Vector3(transform.position.x, 0, -zBounds);
        }
    }
}
