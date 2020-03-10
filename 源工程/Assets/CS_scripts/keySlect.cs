using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keySlect : MonoBehaviour
{
    Light keylight;
    GameObject player;
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        keylight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreManager.score >= 450)
        {
            keylight.enabled = true;
        }
        else 
        {
            keylight.enabled = false;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject==player&&ScoreManager.score >= 450)
        {
            createrEnemy.destoryall = true;
            Destroy(gameObject);
        }
    }
}
