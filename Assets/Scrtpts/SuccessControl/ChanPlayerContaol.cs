using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChanPlayerContaol : MonoBehaviour
{
    /// <summary>
    /// 使用rigibody的移动，手机thirdperson的移动控制！啊！这流畅如丝的快感！
    /// </summary>
    public VariableJoystick variableJoystick;//虚拟按钮
    public FixButtenED FixButtenED;//跳跃按键
    public FixedTouchField fixedTouch;//触屏切换摄影机视角
    private Rigidbody rigidbody;

    protected float cameraAngley;
    protected float cameraAngelSpeed = 0.1f;
    protected float cameraPosy;
    protected float CameraPosSpeed = 0.1f;

    private Animator Animr;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        Animr = GetComponentInChildren<Animator>();
    }

    
    void Update()
    {
        
        var input = new Vector3(variableJoystick.Horizontal, 0, variableJoystick.Vertical);
        var vel = Quaternion.AngleAxis(cameraAngley + 180, Vector3.up)*-input*5f;
        rigidbody.velocity = new Vector3(vel.x, rigidbody.velocity.y, vel.z);
        cameraAngley += fixedTouch.TouchDist.x * cameraAngelSpeed;
        print(fixedTouch.TouchDist.x);
        

        //此为控制角色面向我们摇杆
        transform.rotation = Quaternion.AngleAxis(cameraAngley+Vector3.SignedAngle(Vector3.forward,input.normalized+Vector3.forward*0.001f,Vector3.up), Vector3.up);
       
        //动画状态机测试
        if (rigidbody.velocity.x>0.1||rigidbody.velocity.z>0.1)
        {
            Animr.SetBool("isRun", true);
        }
        if (rigidbody.velocity.magnitude<0.1f)
        {
            
            Animr.SetBool("isRun", false);
        }
        if (FixButtenED.Pressed)
        {
            Animr.Play("jump");
            //Animr.SetBool("isJump",true);
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, 2f, rigidbody.velocity.z);
        }
        
    }
    private void LateUpdate()
    {
        Camera.main.transform.position = transform.position + Quaternion.AngleAxis(cameraAngley, Vector3.up) * new Vector3(0, 2, -4);
        //print(Quaternion.AngleAxis(cameraAngley, Vector3.up) * new Vector3(0, 2, -4));//此方法为环绕角色的坐标，就像是溜溜球，得出的结果就是溜溜球离手的坐标
        Camera.main.transform.rotation = Quaternion.LookRotation(transform.position + Vector3.up * 1f - Camera.main.transform.position, Vector3.up);
    }
}
