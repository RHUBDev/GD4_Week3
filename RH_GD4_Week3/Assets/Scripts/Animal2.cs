using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal2 : MonoBehaviour
{
    private float moveSpeed = 5f;
    public string neededFood;
    public Game2 game;
    private float xBounds = 28f;
    private float zBounds = 21f;
    private float alivetime = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        alivetime += Time.deltaTime;
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        if (transform.position.x > xBounds || transform.position.x < -xBounds || transform.position.z > zBounds || transform.position.z < -zBounds)
        {
            if (alivetime < 2)
            {
                Debug.Log("alivetime = " + alivetime + "; x = " + transform.position.x + "; z = " + transform.position.z);
            }
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == neededFood)
        {
            game.AddScore();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}