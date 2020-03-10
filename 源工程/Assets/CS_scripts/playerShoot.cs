using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShoot : MonoBehaviour
{
    public int damagePerShot = 50; //射击伤害
    public float timeBetweenBullets = 0.15f; //射击间隔
    public float range = 100f; //射程


    float timer;
    Ray shootRay = new Ray(); //射线对象，用于射击判定
    RaycastHit shootHit; //被射线对象碰撞到的物体
    int shootableMask;
    //ParticleSystem gunParticles;
    LineRenderer gunLine; 
    //AudioSource gunAudio;
    Light gunLight; //光源组件，开枪时打开
    float effectsDisplayTime = 0.2f;


    void Awake()
    {
        shootableMask = LayerMask.GetMask("ShootTable");
        //gunParticles = GetComponent<ParticleSystem>();
        gunLine = GetComponent<LineRenderer>();
        //gunAudio = GetComponent<AudioSource>();
        gunLight = GetComponent<Light>();
    }


    void Update()
    {
        timer += Time.deltaTime;
        //检测鼠标左键
        if (Input.GetButton("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0 && !createrEnemy.destoryall)
        {
            Shoot();
        }

        if (timer >= timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects();
        }
    }


    public void DisableEffects()
    { 
        gunLine.enabled = false;
        gunLight.enabled = false;
    }


    void Shoot()
    {
        timer = 0f;

        //gunAudio.Play();

        gunLight.enabled = true;

        //gunParticles.Stop();
        //gunParticles.Play();

        gunLine.enabled = true;
        gunLine.SetPosition(0, transform.position);

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
        {
            enemyHealth eHealth = shootHit.collider.GetComponent<enemyHealth>();
            if (eHealth != null)
            {
                eHealth.TakeDamage(damagePerShot, shootHit.point);
            }
            gunLine.SetPosition(1, shootHit.point);
        }
        else
        {
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }
    }
}
