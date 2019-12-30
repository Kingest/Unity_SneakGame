using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour//第三人称摄像机和玩家的旋转
{
    public float rotatespeed = 1;
    public Transform target, player;
    float moux, mouy;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;//不知到有什么用，和下面这个联动好像
        Cursor.lockState = CursorLockMode.Locked;//游戏运行时鼠标不可见
    }

    // Update is called once per frame
    void Update()
    {
        camcontrol();
    }
    void camcontrol()
    {
        moux += Input.GetAxis("Mouse X") * rotatespeed;
        mouy -= Input.GetAxis("Mouse Y") * rotatespeed;
        print("Moux"+moux+"|||||||||||||" +"Mouy"+mouy);
        mouy = Mathf.Clamp(mouy, -35, 60);//限制鼠标Y轴的度数，不让镜头旋转过高或者过低
        transform.LookAt(target);//看向摄像机的上一层级，目标点
        target.rotation = Quaternion.Euler(mouy, moux, 0);//注意此处我YX，不是XY，XY镜头会乱
        player.rotation = Quaternion.Euler(0, moux, 0);//控制玩家看向


    }
}
