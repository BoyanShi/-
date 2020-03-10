using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpFllow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    void FixedUpdate()
    {
        transform.rotation = Camera.main.transform.rotation;
    }
}
