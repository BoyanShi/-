using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class over : MonoBehaviour
{
    public playerHealth pHealth;
    public Text tex;
    float endTime = 0f;
    float nowTime = 0f;
    Animator anim;


    void Awake()
    {
        //anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (pHealth.currentHealth <= 0)
        {
            //anim.SetTrigger("GameOver");
            tex.text = "菜";
        }
        else if (createrEnemy.destoryall)
        {
            tex.text = "算你狠！";
            nowTime += Time.deltaTime;
            //Debug.Log(nowTime);
            if (nowTime >= 3f) 
            {
                //Application.Quit();
                //UnityEditor.EditorApplication.isPlaying = false;
                //Debug.Log(1);
                SceneManager.LoadScene(0);
            }
        }
    }
}
