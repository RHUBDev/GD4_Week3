using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    public Canvas animalCanvas;
    public GameObject animalUI;
    public AudioSource doh;
    public AudioSource end;
    public AudioSource chomp;

    // Start is called before the first frame update
    void Start()
    {
        //Start game, start spawning animals
        Time.timeScale = 1.0f;
        InvokeRepeating("SpawnAnimal", startdelay, waittime);
    }

    // Update is called once per frame
    void Update()
    {
        //Show "Life Lost!" for 2 seconds
        if (lifetimer > 0)
        {
            lifetimer -= Time.deltaTime;
            lifelostText.text = "Life Lost!";
        }
        else
        {
            lifelostText.text = "";
        }
    }

    void SpawnAnimal()
    {
        //spawn random animal in random position around screen edges
        //and make them walk more towards the middle of the screen than away from it
        int randomAnimal = Random.Range(0, 4);
        int screenSide = Random.Range(0, 4);

        float xpos = 0f;
        float zpos = 0f;
        float randomRotation = Random.Range(0f, 90f);
        if (screenSide == 0)
        {
            //top side of screen
            zpos = animalz;
            xpos = Random.Range(-(animalx - 1), (animalx - 1));
            
            //see which half of the screen edge it spawns on
            if (xpos < 0)
            {
                //then make the rotation face into the screen rather than straight out again
                randomRotation += 90;
            }
            else
            {
                randomRotation += 180;
            }
        }
        else if (screenSide == 1)
        {
            //right side of screen
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
            //bottom side of screen
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
            //left side of screen
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
        //Spawn the animal
        GameObject theAnimalGO = Instantiate(animalprefabs[randomAnimal], new Vector3(xpos, 0, zpos), Quaternion.Euler(0, randomRotation, 0));
        Animal2 animal = theAnimalGO.GetComponent<Animal2>();
        animal.game = this;
        GameObject theAnimalUI = Instantiate(animalUI, new Vector3(-3000, 0, 0), Quaternion.Euler(0, 0, 0), animalCanvas.transform);
        theAnimalUI.transform.localScale = new Vector3(1, 1, 1);
        animal.myUI = theAnimalUI.GetComponent<RectTransform>();
        animal.myUIBar = theAnimalUI.transform.GetChild(1).GetComponent<RectTransform>();
        animal.fullness = 1 - (0.25f * (Random.Range(1, 5)));
        animal.myUIBar.localScale = new Vector3(animal.fullness, 1, 1);
        animal.myUIBarImage = animal.myUIBar.GetComponent<Image>();
        if (animal.fullness < 0.3f)
        {
            animal.myUIBarImage.color = new Color(1, 0, 0);
        }
        else if (animal.fullness < 0.6f)
        {
            animal.myUIBarImage.color = new Color(1, 1, 0);
        }
        else
        {
            animal.myUIBarImage.color = new Color(0, 1, 0);
        }
    }

    public void AddScore()
    {
        //called when adding a point to the score
        score += 1;
        scoreText.text = "Score: " + score.ToString("n0");
    }

    public void LoseLife()
    {
        //called when losing a life
        lives -= 1;
        livesText.text = "Lives: " + lives;
        if(lives <= 0)
        {
            end.Play();
            //if out of lives, end game
            lives = 0;
            EndGame();
        }
        else
        {
            doh.Play();
            //else reset life timer to show "Lost Life!" message for two seconds
            lifetimer = lifetime;
        }
    }

    private void EndGame()
    {
        //End game, and show/set high scores
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
        //Restart game
        SceneManager.LoadScene("MyLevel2");
    }

    public void Quit()
    {
        //Restart game
        SceneManager.LoadScene("Menu");
    }
}

