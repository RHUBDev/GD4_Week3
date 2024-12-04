using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Game2 : MonoBehaviour
{
    private int score = 0;
    private float waittime = 2f;
    private Vector3[] animallocs;
    private float animalx = 26.9f;
    private float animalz = 19.9f;
    private float timer = 2f;
    public GameObject[] animalprefabs;
    private Quaternion animalRotation = Quaternion.Euler(0, 180, 0);
    public TMP_Text scoreText;
    private int lives = 3;
    public TMP_Text endText;
    public GameObject restartButton;
    public TMP_Text livesText;
    public TMP_Text lifelostText;
    private float lifetimer = 0f;
    private float lifetime = 2f;
    private float startdelay = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        InvokeRepeating("SpawnAnimal", startdelay, waittime);
    }

    // Update is called once per frame
    void Update()
    {
        if (lifetimer > 0)
        {
            lifetimer -= Time.deltaTime;
            lifelostText.text = "Life Lost!";
        }
        else
        {
            lifelostText.text = "";
        }
/*
        if (timer < waittime)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0f;
            
            int randomAnimal = Random.Range(0, 4);
            int screenSide = Random.Range(0, 4);

            float xpos = 0f;
            float zpos = 0f;
            float randomRotation = Random.Range(0f, 90f);
            if (screenSide == 0)
            {
                zpos = animalz;
                xpos = Random.Range(-(animalx - 1), (animalx - 1));
                if(xpos < 0)
                {
                    randomRotation += 90;
                }
                else
                {
                    randomRotation += 180;
                }
            }
            else if (screenSide == 1)
            {
                zpos = Random.Range(-(animalz - 1), (animalz - 1));
                xpos = animalx;
                if (zpos < 0)
                {
                    randomRotation += 270;
                }
                else
                {
                    randomRotation += 180;
                }
            }
            else if (screenSide == 2)
            {
                zpos = -animalz;
                xpos = Random.Range(-(animalx - 1), (animalx - 1));
                if (xpos < 0)
                {
                    randomRotation += 0;
                }
                else
                {
                    randomRotation += 270;
                }
            }
            else if (screenSide == 3)
            {
                zpos = Random.Range(-(animalz - 1), (animalz - 1));
                xpos = -animalx;
                if (zpos < 0)
                {
                    randomRotation += 0;
                }
                else
                {
                    randomRotation += 90;
                }
            }
            //Debug.Log("ScreenSide = " + screenSide);
            GameObject theAnimalGO = Instantiate(animalprefabs[randomAnimal], new Vector3(xpos, 0, zpos), Quaternion.Euler(0, randomRotation, 0));
            Animal2 animal = theAnimalGO.GetComponent<Animal2>();
            animal.game = this;
        }*/
    }

    void SpawnAnimal()
    {
        int randomAnimal = Random.Range(0, 4);
        int screenSide = Random.Range(0, 4);

        float xpos = 0f;
        float zpos = 0f;
        float randomRotation = Random.Range(0f, 90f);
        if (screenSide == 0)
        {
            zpos = animalz;
            xpos = Random.Range(-(animalx - 1), (animalx - 1));
            if (xpos < 0)
            {
                randomRotation += 90;
            }
            else
            {
                randomRotation += 180;
            }
        }
        else if (screenSide == 1)
        {
            zpos = Random.Range(-(animalz - 1), (animalz - 1));
            xpos = animalx;
            if (zpos < 0)
            {
                randomRotation += 270;
            }
            else
            {
                randomRotation += 180;
            }
        }
        else if (screenSide == 2)
        {
            zpos = -animalz;
            xpos = Random.Range(-(animalx - 1), (animalx - 1));
            if (xpos < 0)
            {
                randomRotation += 0;
            }
            else
            {
                randomRotation += 270;
            }
        }
        else if (screenSide == 3)
        {
            zpos = Random.Range(-(animalz - 1), (animalz - 1));
            xpos = -animalx;
            if (zpos < 0)
            {
                randomRotation += 0;
            }
            else
            {
                randomRotation += 90;
            }
        }
        //Debug.Log("ScreenSide = " + screenSide);
        GameObject theAnimalGO = Instantiate(animalprefabs[randomAnimal], new Vector3(xpos, 0, zpos), Quaternion.Euler(0, randomRotation, 0));
        Animal2 animal = theAnimalGO.GetComponent<Animal2>();
        animal.game = this;
    }

    public void AddScore()
    {
        score += 1;
        scoreText.text = "Score: " + score.ToString("n0");
    }

    public void LoseLife()
    {
        lives -= 1;
        livesText.text = "Lives: " + lives;
        if(lives <= 0)
        {
            lives = 0;
            EndGame();
        }
        else
        {
            lifetimer = lifetime;
        }
    }

    private void EndGame()
    {
        int high = 0;
        if (PlayerPrefs.HasKey("HighScore2"))
        {
            high = PlayerPrefs.GetInt("HighScore2");
        }
        if (score > high)
        {
            endText.text = "You Scored: " + score.ToString("n0") + "!\nNew High Score!";
            PlayerPrefs.SetInt("HighScore2", score);
        }
        else
        {
            endText.text = "You Scored: " + score.ToString("n0") + "!\nRecord: " + high.ToString("n0");
        }
        restartButton.SetActive(true);
        Time.timeScale = 0.0f;
        lifetimer = 0;
        lifelostText.text = "";
    }

    public void Restart()
    {
        SceneManager.LoadScene("MyLevel2");
    }
}

