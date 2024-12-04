using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float moveSpeed = 15f;
    private float zbounds = 18f;
    public Game2 game2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        if (transform.position.z > zbounds)
        {
            GameObject obj = GameObject.FindWithTag("Game");
            game2 = obj.GetComponent<Game2>();
            if (game2)
            {
                game2.LoseLife();
            }
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("coll = " + collision.gameObject.name);
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("coll = " + collision.gameObject.name);
    }
}