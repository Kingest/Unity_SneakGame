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
    private AudioSource audioSource;
    private Animator animator;

    protected ThirdPersonUserControl thirdPersonUserControl;//要调用此脚本需要命名空间unitystandardasset...此脚本为prefab上自带的脚本
    protected float cameraRotateSpeed = 0.2f;
    protected float cameraAngels = 2f;

    //摄影机的Collision
    public bool collisionDeubg;
    public LayerMask collisionMask;
    Ray camRay;
    RaycastHit cameraRayHit;
    public float collisionCusion = 0.3f;


    //是否拿到钥匙
    public static bool isGetKey;
    private void Awake()
    {
        
        Camera.main.transform.SetParent(null);
    }
    // Start is called before the first frame update
    void Start()
    {
        thirdPersonUserControl = GetComponent<ThirdPersonUserControl>();
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        collisionDeubg = true;
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


        
        
        if (animator.GetFloat("Forward") >= 0.1f)//为啥又把这个单独截图保存呢？
        {
            if (audioSource.isPlaying!=true)//因为我是憨逼，之前省略了这个步骤，如果省略这个步骤就会造成1秒播放差不多60次
                                            //携程方法的 yield new waitfor Second都没吉尔用
            {
                audioSource.Play();
                
            }
           
        }
        if (animator.GetFloat("Forward") <= 0.1f)
        {
            if (audioSource.isPlaying==true)
            {
                audioSource.Stop();
            }
           
        }

        CameraCollision();

        //Vector3 crossleft= Vector3.Cross(Vector3.forward, Vector3.left);//cross值为（0，-1，0）
        //Vector3 crossright = Vector3.Cross(Vector3.forward, Vector3.right);//cross值为（0,1,0）
        //可以通过Y值的正负来判断旋转是向左还是向右

        
    }
    void CameraCollision()
    {
        float currentDistance = (Camera.main.transform.position - transform.position - new Vector3(0, 1.2f, 0)).magnitude;
        float camDistacne = currentDistance + 0.35f;
        
        camRay.origin = Camera.main.transform.position;
        camRay.direction = (transform.position+new Vector3(0,1.2f,0)-Camera.main.transform.position).normalized;
                                                                                      
        if (Physics.Raycast(camRay,out cameraRayHit,currentDistance))
        {
        }
        else
        {

        }
        if (collisionDeubg)
            Debug.DrawLine(camRay.origin, camRay.origin + camRay.direction * camDistacne, Color.black);



    }
   
}
