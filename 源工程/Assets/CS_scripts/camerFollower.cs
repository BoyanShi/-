using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerFollower : MonoBehaviour
{
    public Transform target;  //相机将跟随的目标
    public float smoothing = 5f;  //相机移动速度，略低于玩家移动速度
    Vector3 offset;  //存储从相机到目标的位移差的初始值

    void Start()
    {
        offset = transform.position - target.position;  //从角色指向相机的向量
    }

    void FixedUpdate()
    {
        Vector3 targetCamPos = target.position + offset;   //相机的移动目标
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);  //平滑移动相机
    }
}
