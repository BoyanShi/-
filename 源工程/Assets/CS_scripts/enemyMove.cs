using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyMove : MonoBehaviour
{
    
    Transform player;  //抓取玩家
    playerHealth pHealth;  //抓取玩家生命值
    enemyHealth eHealth;  //抓取当前enemy生命值
    NavMeshAgent nav;  //抓取enemy的nav组件

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;  //绑定玩家
        pHealth = player.GetComponent <playerHealth> ();  //绑定玩家生命值
        eHealth = GetComponent <enemyHealth> ();  //绑定当前enemy生命值
        nav = GetComponent<NavMeshAgent>();  //绑定nav组件
    }


    void Update()
    {
        if(eHealth.currentHealth > 0 && pHealth.currentHealth > 0 && !createrEnemy.destoryall)  //如果当前enemy和玩家生命值都大于0
        {
            nav.SetDestination(player.position);  //enemy自动跟踪玩家
        }
        else
        {
            nav.enabled = false;  //禁止nav组件
        }
    }
}

 