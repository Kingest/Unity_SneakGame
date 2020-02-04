using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RERE_PlayerMoveMent : MonoBehaviour
{
    private CharacterController CC;
    public float speed = 12;
    public float gravityValue = 9.81f;//阿基米德解锁的重力大小
    public Vector3 gravity;

    public Transform groundCheck;//在底部添加一个空物体
    public float groundDistance;//和底部的碰撞距离
    public LayerMask groundMask;//选择地面的图层
    bool isground;
    public VariableJoystick joyStick;
    // Start is called before the first frame update
    void Start()
    {
        CC = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //重力检测，如果碰到了地面那么重力就为-2
        isground = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isground &&gravity.y<0 )
        {
            gravity.y = -2f;
        }
        //移动控制
        //float z = Input.GetAxis("Vertical");
        //float x = Input.GetAxis("Horizontal");

        float z = joyStick.Vertical;
        float x = joyStick.Horizontal;
        Vector3 Move = transform.forward * z + transform.right * x;//注意此处为transfrom.forward不是V3forward
        CC.Move(Move*speed*Time.deltaTime);

        //重力模拟
        gravity.y -= gravityValue * Time.deltaTime;
        CC.Move(gravity*Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space)&&isground)//跳跃
        {
            gravity.y += 10f;
        }
        
    }
}
