using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour
{

    public int startingHealth = 100;  //初始生命值
    public int currentHealth;  //当前生命值
    public Slider healthSlider;  //抓取生命条UI
    public Image damageImage;  //受伤效果图
   // public AudioClip deathClip;  //死亡音效
    public float flashSpeed = 5f;   //
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);


    Animator anim;
    AudioSource playerAudio;
    playerMovement pMovement;
    playerShoot pShooting;
    bool isDead;
    bool damaged;


    void Awake()
    {
        anim = GetComponent<Animator>();  //绑定动画
       // playerAudio = GetComponent<AudioSource>();
        pMovement = GetComponent<playerMovement>();  //绑定移动脚本
        pShooting = GetComponentInChildren <playerShoot> ();
        currentHealth = startingHealth;  //设置初始生命值
    }


    void Update()
    {
        if (damaged)
        {
            damageImage.color = flashColour;  //受伤后从指定颜色开始变淡
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
    }


    public void TakeDamage(int amount)  //外部单元可以通过这个函数使玩家受伤
    {
        damaged = true;
        currentHealth -= amount;
        healthSlider.value = currentHealth;
       // playerAudio.Play();  
        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }
    void Death()
    {
        isDead = true;
        pShooting.DisableEffects ();
        anim.SetTrigger("die");
        //playerAudio.clip = deathClip;
        //playerAudio.Play();
        pMovement.enabled = false;
        pShooting.enabled = false;
    }
    public void RestartLevel()  
    {
        SceneManager.LoadScene(0);
    }
}
