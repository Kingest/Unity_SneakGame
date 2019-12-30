using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class PhoneThirdPersonContaol : MonoBehaviour
{
    public VariableJoystick LeftvariableJoystick;//摇杆
    //public VariableJoystick RightvarobleJoystick;//测试用
    public FixedTouchField fixedTouchField;//在Canvas上新建一张图片添加此脚本，图片在Hireachy层级为最上，不然会遮挡其他按键，此图片作为手机触摸改变镜头位置的按键区域
    public FixButtenED fixButtenED;//在图片上添加此脚本作为事件按键的监听，此为跳跃事件
    


    protected ThirdPersonUserControl thirdPersonUserControl;//要调用此脚本需要命名空间unitystandardasset...此脚本为prefab上自带的脚本
    protected float cameraRotateSpeed = 0.2f;
    protected float cameraAngels = 2f;
    // Start is called before the first frame update
    void Start()
    {
        thirdPersonUserControl = GetComponent<ThirdPersonUserControl>();
    }

    // Update is called once per frame
    void Update()
    {
        cameraAngels += fixedTouchField.TouchDist.x * cameraRotateSpeed;//旋转角，为+=累计
        Camera.main.transform.position = transform.position + Quaternion.AngleAxis(cameraAngels, Vector3.up) * new Vector3(0, 1.3f, -1.43f);//相机坐标位置
        Camera.main.transform.rotation = Quaternion.LookRotation(transform.position + Vector3.up - Camera.main.transform.position, Vector3.up);//相机旋转角度
        

        if (thirdPersonUserControl == null) return;
        thirdPersonUserControl.m_Jump = fixButtenED.Pressed;
        thirdPersonUserControl.Hinput = LeftvariableJoystick.Horizontal;//摇杆的Z轴输入
        thirdPersonUserControl.Vinput = LeftvariableJoystick.Vertical;//摇杆的X轴输入

       
        
    }
}
