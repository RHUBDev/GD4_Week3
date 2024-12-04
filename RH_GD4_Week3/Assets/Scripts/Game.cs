using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    private int score = 0;
    private float waittime = 5f;
    private Vector3[] animallocs;
    private float animalz = 19.1f;
    private float timer = 5f;
    public GameObject[] animalprefabs;
    private Quaternion animalRotation = Quaternion.Euler(0, 180, 0);
    public TMP_Text scoreText;
    public TMP_Text endText;
    public GameObject restartButton;
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
        int high = 0;
        if (PlayerPrefs.HasKey("HighScore"))
        {
            high = PlayerPrefs.GetInt("HighScore");
        }
        if(score > high)
        {
            endText.text = "You Scored: " + score.ToString("n0") + "!\nNew High Score!";
            PlayerPrefs.SetInt("HighScore", score);
        }
        else
        {
            endText.text = "You Scored: " + score.ToString("n0") + "!\nRecord: "+ high.ToString("n0");
        }
        restartButton.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void Restart()
    {
        SceneManager.LoadScene("MyLevel");
    }

    public void Quit()
    {
        //Restart game
        SceneManager.LoadScene("Menu");
    }
}
