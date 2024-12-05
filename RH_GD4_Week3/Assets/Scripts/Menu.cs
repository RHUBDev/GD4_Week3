using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Animator anim;
    public int num = 9;
    public GameObject musicprefab;

    private void Awake()
    {
        GameObject music = GameObject.FindWithTag("Music");
        if (!music)
        {
            Instantiate(musicprefab, Vector3.zero, Quaternion.identity);
        }
        Time.timeScale = 1f;
        anim.SetInteger("Animation_int", num);//.Play("Idle_SittingOnGround");
    }

    public void PlayGame1()
    {
        SceneManager.LoadScene("MyLevel");
    }

    public void PlayGame2()
    {
        SceneManager.LoadScene("MyLevel2");
    }
}
