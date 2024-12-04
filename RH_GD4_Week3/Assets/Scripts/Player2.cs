using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    private float moveSpeed = 10f;
    private float xBounds = 22f;
    private float zBounds = 15f;
    public GameObject bone;
    public GameObject carrot;
    public GameObject steak;
    public GameObject apple;
    private float foodspawnz = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Get inputs
        float horiz = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");

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

        //Spawn Food
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Instantiate(bone, transform.position + transform.forward * foodspawnz + transform.up * 0.5f, transform.rotation);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Instantiate(carrot, transform.position + transform.forward * foodspawnz + transform.up * 0.5f, transform.rotation);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Instantiate(steak, transform.position + transform.forward * foodspawnz + transform.up * 0.5f, transform.rotation);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Instantiate(apple, transform.position + transform.forward * foodspawnz + transform.up * 0.5f, transform.rotation);
        }
    }
}
