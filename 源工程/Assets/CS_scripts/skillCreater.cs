using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class skillCreater : MonoBehaviour
{
    public playerHealth pHealth;
    public GameObject bomb; //飞行道具建模
    public Slider cdSlider; //能量槽
    float coldDownTime; //技能冷却时间
    void Start()
    {
        coldDownTime = 0f; //开始时将冷却时间归零
    }

    // Update is called once per frame
    void Update()
    {
        if (coldDownTime > 0)
            coldDownTime -= Time.deltaTime; 
        if (coldDownTime < 0)
            coldDownTime = 0;
        if (Input.GetKey("e")&&coldDownTime<=0) 
        {
            Spawn();
            coldDownTime = 5f;
        }
        cdSlider.value = 5 - coldDownTime;
    }
    void Spawn()
    {
        if (pHealth.currentHealth <= 0f)
        {
            return;
        }
        Debug.Log(transform.forward);
        Instantiate(bomb, transform.position, transform.rotation);
    }
}
