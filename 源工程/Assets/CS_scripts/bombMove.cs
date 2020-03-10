using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombMove : MonoBehaviour
{
    Vector3 origin;//技能起始坐标
    Vector3 movement; //技能位移
    public int range; //技能射程
    public float speed; //飞行速度
    Rigidbody skillRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(transform.forward);
        skillRigidbody = GetComponent<Rigidbody>();
        origin = transform.position;
        //Debug.Log(origin);
    }

    // Update is called once per frame
    void Update()
    {
        movement=transform.forward;
        movement = movement.normalized * speed * Time.deltaTime;
        skillRigidbody.MovePosition(transform.position + movement);
        if ((transform.position - origin).magnitude>=range) 
        {
            Destroy(gameObject);
        }
    }
}
