using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisionsX : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Ball") && other.CompareTag("Dog"))
        {
            PlayerControllerX player = GameObject.FindWithTag("Player").GetComponent<PlayerControllerX>();
            player.AddScore();
        }
        Destroy(gameObject);
    }
}
