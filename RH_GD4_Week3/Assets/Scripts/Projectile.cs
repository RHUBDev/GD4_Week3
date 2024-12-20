using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float moveSpeed = 15f;
    private float xBounds = 28f;
    private float zBounds = 21f;

    public Game2 game2;

    // Update is called once per frame
    void Update()
    {
        //Shoot food forwards
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        if (transform.position.x > xBounds || transform.position.x < -xBounds || transform.position.z > zBounds || transform.position.z < -zBounds)
        {
            //If 'MyLevel2' then lose life if food misses
            /*GameObject obj = GameObject.FindWithTag("Game");
            game2 = obj.GetComponent<Game2>();
            if (game2)
            {
                game2.LoseLife();
            }*/
            //Destroy food
            Destroy(gameObject);
        }
    }
}