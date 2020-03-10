using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seprateSkill : MonoBehaviour
{
    playerHealth pHealth;
    public GameObject bomb;
    float coldDownTime;
    void Start()
    {
        pHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<playerHealth>();
        coldDownTime = 0f;
    }

    void Update()
    {
        if (coldDownTime > 0)
            coldDownTime -= Time.deltaTime;
        if (coldDownTime < 0)
            coldDownTime = 0;
        if (Input.GetKey("e") && coldDownTime <= 0)
        {
            Spawn();
            coldDownTime = 5f;
        }
    }
    void Spawn()
    {
        if (pHealth.currentHealth <= 0f)
        {
            return;
        }
        //Debug.Log(transform.forward);
        Instantiate(bomb, transform.position, transform.rotation);
    }
}
