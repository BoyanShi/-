using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDamge : MonoBehaviour
{
    public int skillDamange;
    public string target;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(target))
        {
            enemyHealth eHealth = other.GetComponent<enemyHealth>();
            if (eHealth != null)
                eHealth.TakeDamage(skillDamange, transform.position);
            else 
            {
                playerHealth pHealth = other.GetComponent<playerHealth>();
                pHealth.TakeDamage(skillDamange);
            }
        }
    }
}
