using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createrEnemy : MonoBehaviour
{
    public playerHealth pHealth; //玩家的生命值组件
    public GameObject enemy; //要产生的敌人种类
    public float spawnTime = 5f; //时间间隔
    public Transform[] spawnPoints; //刷新点的位置

    public static bool destoryall;

    void Start()
    {
        destoryall = false;
        InvokeRepeating("Spawn", spawnTime, spawnTime); //定时器，按一定时间间隔执行Spawn函数
    }


    void Spawn()
    {
        if (pHealth.currentHealth <= 0f||destoryall)//当玩家死亡或游戏胜利时不再刷怪
        {
            return;
        }

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        //在固定位置生成固定角度的敌人
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation); 
    }
}
