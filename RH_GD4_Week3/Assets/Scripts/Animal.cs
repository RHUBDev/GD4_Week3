using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    private float moveSpeed = 1f;
    public string neededFood;
    public Game game;

    // Update is called once per frame
    void Update()
    {
        //Slowly walk forward
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if correct food fed, add a point, else end game
        if(collision.gameObject.tag == neededFood)
        {
            game.AddScore();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else
        {
            game.EndGame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Animal reached bottom, player lost
        if (other.gameObject.tag == "EndZone")
        {
            game.EndGame();
        }
    }
}
