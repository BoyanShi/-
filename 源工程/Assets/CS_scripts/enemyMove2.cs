using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyMove2 : MonoBehaviour
{
    Transform player;
    Transform key;
    playerHealth pHealth;
    enemyHealth eHealth;  //抓取当前enemy生命值
    UnityEngine.AI.NavMeshAgent nav;  //抓取enemy的nav组件

    void Awake()
    {
        key = GameObject.FindGameObjectWithTag("key").transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        pHealth = player.GetComponent<playerHealth>();
        eHealth = GetComponent<enemyHealth>();  //绑定当前enemy生命值
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();  //绑定nav组件
    }


    void Update()
    {
        if (pHealth.currentHealth > 0 && eHealth.currentHealth > 0 && ScoreManager.score > 0 && !createrEnemy.destoryall)
        {
            nav.SetDestination(key.position);  //分数大于0时追踪能量球
        }
        else if (pHealth.currentHealth > 0 && ScoreManager.score == 0 && eHealth.currentHealth > 0 && !createrEnemy.destoryall) 
        {
            nav.SetDestination(player.position);  //分数为0时追踪玩家
        }
        else
        {
            Debug.Log("can't");
            nav.enabled = false;  //禁止nav组件
        }
    }
}
