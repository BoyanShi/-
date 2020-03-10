using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShooter : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 5;
    public GameObject bomb;
    public GameObject enemy;


    GameObject player;
    playerHealth pHealth;
    enemyHealth eHealth;
    bool playerInRange;
    float timer;
    Vector3 dest;
    Rigidbody enemyRigidbody;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pHealth = player.GetComponent<playerHealth>();
        eHealth = enemy.GetComponent<enemyHealth>();
    }


    


    void Update()
    {
        timer += Time.deltaTime;
        dest = player.transform.position - transform.position;
        if (dest.magnitude <= 15)
        {
            playerInRange = true;
        }
        else 
        {
            playerInRange = false;
        }
        if (timer >= timeBetweenAttacks && playerInRange && eHealth.currentHealth > 0)
        {
            Attack();
        }

    }


    void Attack()
    {
        timer = 0f;
        if (pHealth.currentHealth > 0)
        {
            dest.y = 0;
            Quaternion newRotatation = Quaternion.LookRotation(dest);
            transform.rotation = newRotatation;
            Instantiate(bomb, transform.position, transform.rotation);
        }
    }
}
