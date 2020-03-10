using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System;
using UnityEngine;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{
    public float speed = 6f;  //玩家移动速度
    //public Text textShow;
    Vector3 movement;  //存储玩家位移
    Animator anim;     //绑定动画组件
    Rigidbody playerRigidbody;   //绑定刚体组件
    int floorMask;  //floor图层
    float camRayLength = 100f;    // 相机射线长度
    void Awake()  //不论脚本是否可用都会在初始化时执行一次
    {
        floorMask = LayerMask.GetMask("Floor");  //获取Floor层
        anim = GetComponent<Animator>();  //获取动画
        playerRigidbody = GetComponent<Rigidbody>();  //获取刚体
        //textShow.text = "当前坐标:" + transform.localPosition;
    }

    void FixedUpdate()  //物理更新时运行 跟随物理系统
    {
        if (createrEnemy.destoryall)
            return;
        float h = Input.GetAxisRaw("Horizontal");  //取横轴输入值，按A键时为-1，按D键时为1。
        float v = Input.GetAxisRaw("Vertical");  //取纵轴输入值，按S键时为-1，按W键时为1。
        Move(h, v);  //位移
        Turning();  //转向
        Animating(h, v);  //根据状态播放动画
    }

    void Move(float h, float v)
    {
        movement.Set(h, 0f, v);  //设置位移
        movement = movement.normalized * speed * Time.deltaTime;  //得到每帧位移
        playerRigidbody.MovePosition(transform.position + movement);  //移动角色
    }

    void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);  //从鼠标位置发出与摄像机射线平行的射线。
        RaycastHit floorHit;  //存储射线与Floor的交点
        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))  //如果射线击中了Floor层上的物体
        {
            Vector3 playerToMouse = floorHit.point - transform.position;  //交点与玩家位置的位移差
            playerToMouse.y = 0f;  //确保玩家不会被颠倒
            Quaternion newRotatation = Quaternion.LookRotation(playerToMouse);  //用Quaternion存储旋转信息
            playerRigidbody.MoveRotation(newRotatation);  //旋转角色
        }
    }

    void Animating(float h, float v)
    {
        bool walking = h != 0f || v != 0f;  //h或v不为0时，walking为真，其余状态为假。
        anim.SetBool("isWalk", walking);  //设置状态机
    }


}
