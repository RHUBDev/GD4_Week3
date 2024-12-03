using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    private float moveSpeed = 1f;
    public string neededFood;
    public Game game;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
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
}
