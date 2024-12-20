using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float moveSpeed = 5f;
    private float xBounds = 13.5f;
    private float zBounds = 9f;
    public GameObject bone;
    public GameObject carrot;
    public GameObject steak;
    public GameObject apple;
    private Vector3[] playerlocs;
    private float playerz = -14f;
    private int currentloc = 0;
    // Start is called before the first frame update
    void Start()
    {
        playerlocs = new Vector3[4];
        playerlocs[0] = new Vector3(-12f, 0, playerz);
        playerlocs[1] = new Vector3(-4f, 0, playerz);
        playerlocs[2] = new Vector3(4f, 0, playerz);
        playerlocs[3] = new Vector3(12f, 0, playerz);
        transform.position = playerlocs[0];
    }

    // Update is called once per frame
    void Update()
    {
        //Get inputs

        /*float horiz = Input.GetAxis("Horizontal");
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
        }*/

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentloc += 1;
            if(currentloc > (playerlocs.Length - 1))
            {
                currentloc = 0;
            }
            transform.position = playerlocs[currentloc];
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentloc -= 1;
            if (currentloc < 0)
            {
                currentloc = (playerlocs.Length - 1);
            }
            transform.position = playerlocs[currentloc];
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Instantiate(bone, transform.position + new Vector3(0, 0.5f, 1), Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Instantiate(carrot, transform.position + new Vector3(0, 0.5f, 1), Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Instantiate(steak, transform.position + new Vector3(0, 0.5f, 1), Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Instantiate(apple, transform.position + new Vector3(0, 0.5f, 1), Quaternion.identity);
        }
    }
}
