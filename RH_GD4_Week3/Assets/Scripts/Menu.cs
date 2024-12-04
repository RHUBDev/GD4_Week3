using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Animator anim;
    public int num = 9;
    private void Start()
    {
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
