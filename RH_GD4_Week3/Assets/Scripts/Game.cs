using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game : MonoBehaviour
{
    private int score = 0;
    private float waittime = 5f;
    private Vector3[] animallocs;
    private float animalz = 27f;
    private float timer = 5f;
    public GameObject[] animalprefabs;
    private Quaternion animalRotation = Quaternion.Euler(0, 180, 0);
    public TMP_Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        animallocs = new Vector3[4];
        animallocs[0] = new Vector3(-12f, 0, animalz);
        animallocs[1] = new Vector3(-4f, 0, animalz);
        animallocs[2] = new Vector3(4f, 0, animalz);
        animallocs[3] = new Vector3(12f, 0, animalz);
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < waittime)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0f;
            for (int i = 0; i < animallocs.Length; i++)
            {
                int randomAnimal = Random.Range(0, 4);
                GameObject theAnimalGO = Instantiate(animalprefabs[randomAnimal], animallocs[i], animalRotation);
                Animal animal = theAnimalGO.GetComponent<Animal>();
                animal.game = this;
            }
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
