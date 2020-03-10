using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySteal : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;

    Animator anim;
    GameObject player;
    enemyHealth eHealth;
    bool playerInRange;
    float timer;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("key");
        eHealth = GetComponent<enemyHealth>();
        anim = GetComponent<Animator>();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = false;
        }
    }


    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenAttacks && playerInRange && eHealth.currentHealth > 0)
        {
            Attack();
        }

    }


    void Attack()
    {
        timer = 0f;

        if (ScoreManager.score >= 50)
        {
            ScoreManager.score -= 50;
        }
        else if (ScoreManager.score >= 0) 
        {
            ScoreManager.score = 0;
        }
    }
}
