using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class excuseOfseparation : MonoBehaviour
{
    public playerHealth pHealth;
    public GameObject sepatate;
    public Slider cdSlider;
    float coldDownTime;
    void Start()
    {
        coldDownTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (coldDownTime > 0)
            coldDownTime -= Time.deltaTime;
        if (coldDownTime < 0)
            coldDownTime = 0;
        if (Input.GetKey("q") && coldDownTime <= 0)
        {
            Spawn();
            coldDownTime = 20f;
        }
        cdSlider.value = 20 - coldDownTime;
    }
    void Spawn()
    {
        if (pHealth.currentHealth <= 0f)
        {
            return;
        }
        Debug.Log(transform.forward);
        Instantiate(sepatate, transform.position, transform.rotation);
    }
}
