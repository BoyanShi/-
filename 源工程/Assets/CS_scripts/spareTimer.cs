using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spareTimer : MonoBehaviour
{
    public float startingTime = 10f;  //最大持续时间
    float currentTime; //当前持续时间 
    public Slider timeSlider;  
    playerHealth pHealth; //本体生命值
    Animator anim;
    AudioSource playerAudio;
    playerMovement pMovement;
    playerShoot pShooting;
    //bool isDead;


    void Awake()
    {
        pHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<playerHealth>();
        anim = GetComponent<Animator>();  //绑定动画
        pMovement = GetComponent<playerMovement>();  //绑定自定义引动脚本
        pShooting = GetComponentInChildren<playerShoot>();
        currentTime = startingTime;  //设置初始生命值
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        timeSlider.value = currentTime;
        if (pHealth.currentHealth <= 0f||currentTime<=0f) 
        {
            Death();
        }
    }
    void Death()
    {
        //isDead = true;
        pShooting.DisableEffects();
        anim.SetTrigger("die");
        //playerAudio.clip = deathClip;
        //playerAudio.Play();
        pMovement.enabled = false;
        pShooting.enabled = false;
        Destroy(gameObject,1f);
        //RestartLevel();
    }
}
