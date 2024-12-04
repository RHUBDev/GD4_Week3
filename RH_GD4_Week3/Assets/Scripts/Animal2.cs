using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Animal2 : MonoBehaviour
{
    private float moveSpeed = 5f;
    public string neededFood;
    public Game2 game;
    private float xBounds = 28f;
    private float zBounds = 21f;
    public RectTransform myUI;
    public RectTransform myUIBar;
    public Image myUIBarImage;
    public float fullness;
    // Update is called once per frame
    void Update()
    {
        //Move animal
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        //Destroy animal if out of screen bounds
        if (transform.position.x > xBounds || transform.position.x < -xBounds || transform.position.z > zBounds || transform.position.z < -zBounds)
        {
            Destroy(gameObject);
        }

        myUI.position = Camera.main.WorldToScreenPoint(transform.position + Vector3.up * 3f + Vector3.forward * 2f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == neededFood)
        {
            //Correct food, add point and destroy both
            fullness += 0.25f;
            Destroy(collision.gameObject);
            myUIBar.localScale = new Vector3(fullness, 1, 1);
            if (fullness < 0.3f)
            {
                myUIBarImage.color = new Color(1, 0, 0);
            }
            else if (fullness < 0.6f)
            {
                myUIBarImage.color = new Color(1, 1, 0);
            }
            else
            {
                myUIBarImage.color = new Color(0, 1, 0);
            }
            if (fullness >= 1)
            {
                Destroy(myUI.gameObject);
                game.AddScore();
                Destroy(gameObject);
            }
        }
        else if(collision.gameObject.tag == "Player")
        {
            //Animal hit player, lose a life
            game.LoseLife();
            Destroy(myUI.gameObject);
            Destroy(gameObject);
        }
        else if(collision.gameObject.tag != "Untagged")
        {
            //Animal hit wrong food, lose a life
            game.LoseLife();
            Destroy(collision.gameObject);
        }
    }
}