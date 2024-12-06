using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float waittime = 1f;
    private float timer = 1f;
    private int score = 0;
    private int lives = 2;
    public TMP_Text scoretext;
    public TMP_Text lifetext;
    public TMP_Text centretext;
    private float lifetime = 2f;
    private float lifetimer = 2f;
    private float endtime = 3f;
    private float resettime = 1f;
    private float endtimer = 3f;
    // Update is called once per frame
    void Update()
    {
        if(timer < waittime)
        {
            timer += Time.deltaTime;
        }
        // On spacebar press, send dog
        if (timer >= waittime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                timer = 0f;
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            }
        }

        if (lifetimer < lifetime)
        {
            lifetimer += Time.deltaTime;
            centretext.text = "Lost A Life!";
        }
        else if(lives <= 0 && endtimer < endtime)
        {
            endtimer += Time.deltaTime;
        }
        else if(lives <= 0 && endtimer >= endtime)
        {
           
        }
        else if(endtimer >= endtime)
        {
            centretext.text = "";
        }
        if(endtimer > resettime && endtimer < endtime)
        {
            lives = 2;
            score = 0;
            scoretext.text = "Score: " + score;
            lifetext.text = "Lives: " + lives;
        }
    }

    public void AddScore()
    {
        score++;
        scoretext.text = "Score: " + score;
    }

    public void LoseLife()
    {
        lives--;
        lifetext.text = "Lives: " + lives;

        lifetimer = 0;
        if (lives <= 0)
        {
            lifetimer = lifetime;
            endtimer = 0;
            int high = 0;
            if (PlayerPrefs.HasKey("Challenge2HighScore"))
            {
                high = PlayerPrefs.GetInt("Challenge2HighScore");
            }
            if (score > high)
            {
                centretext.text = "New High Score!\nScored: "+score;
                PlayerPrefs.SetInt("Challenge2HighScore", score);
            }
            else
            {
                centretext.text = "Unlucky!\nHigh Score: " + high;
            }
        }
        else
        {
            centretext.text = "Lost A Life!";
        }
    }
}
