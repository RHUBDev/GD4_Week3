using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
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
        }
    }

    public void AddScore()
    {
        score += 1;
        scoreText.text = "Score: " + score.ToString("n0");
    }

    public void EndGame()
    {
        Time.timeScale = 0.0f;
    }
}

