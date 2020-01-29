using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    public static GameManger _gameManager;
    public  bool isPlayAlarmAudio = false;
    private GameObject[] gb;
    private AudioSource[] alarmAudio;
    AudioSource ad;

    public GameObject CameraHead;
    public GameObject[] cld;

    public GameObject exitDoorleft;
    public GameObject exitDoorRight;

    public GameObject doorleft;
    public GameObject doorRight;

    public Vector3 lastPlayerPos = Vector3.zero;
    /// <summary>
    /// 用于测试进入战斗之后BGM的播放，clip就像是子弹，audiosource就像是枪，可以更换子弹的，而枪只有一把
    /// </summary>
    public AudioClip [] bgmClip;
    private AudioSource audioSurceMy;
    public FixButtenED alarmoff;
    public GameObject alarmoffButton;
    private void Awake()
    {
        _gameManager = this;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        gb = GameObject.FindGameObjectsWithTag(Tag.AlarmBorad);
        cld = GameObject.FindGameObjectsWithTag(Tag.AlarmArea);
        audioSurceMy = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        AlarmLight._Alarmlight.isalarm=isPlayAlarmAudio;//和警报光效bool值绑定，光效一起，音效也起
        if (isPlayAlarmAudio==true)
        {
            alarmoffButton.SetActive(true);
            if (alarmoff.Pressed == true)
            {
                isPlayAlarmAudio = false;
            }
        }
       
        //我也能做到的！第二种方法
        if (isPlayAlarmAudio)
        {
            for (int i = 0; i < gb.Length; i++)
            {
                if (gb[i].GetComponent<AudioSource>().isPlaying == false)
                {
                    gb[i].GetComponent<AudioSource>().Play();
                    audioSurceMy.clip = bgmClip[0];
                    audioSurceMy.Play();
                }

            }
        }
        else
        {
            for (int i = 0; i < gb.Length; i++)
            {
                gb[i].GetComponent<AudioSource>().Stop();
            }
        }

        foreach (var go in cld)
        {
            go.GetComponent<Collider>();
            
        }
        exitDoorleft.transform.position = new Vector3(Mathf.Lerp(exitDoorleft.transform.position.x,doorleft.transform.position.x,Time.deltaTime), exitDoorleft.transform.position.y, exitDoorleft.transform.position.z);
        exitDoorRight.transform.position = new Vector3(Mathf.Lerp(exitDoorRight.transform.position.x, doorRight.transform.position.x,Time.deltaTime), exitDoorRight.transform.position.y, exitDoorRight.transform.position.z);
        
    }
    void DoorExitAniPlay()
    {

    }
    public void SeePlayer(Transform player)//用于统一玩家的位置信息，摄像头也好，机械人也好，看到了玩家之后就会汇报信息
    {
        isPlayAlarmAudio = true;
        lastPlayerPos = player.position;
    }
    
    ///第一种方法的另一部分
    //private void PlayAlarm()
    //{

    //        foreach (GameObject go in gb)
    //        {
    //            if (go.GetComponent<AudioSource>().isPlaying==false)
    //            {
    //                go.GetComponent<AudioSource>().Play();
    //            }

    //        }

    //}
    //private void stopAlarm()
    //{
    //    foreach (GameObject go in gb)
    //    {
    //        go.GetComponent<AudioSource>().Stop();
    //    }
    //}

    //void CameraRotate()
    //{
    //    //此处这么多次的尝试，大多数都是因为在游戏引擎层级中，上层的父物体旋转角度没有清0
    //    //CameraHead.transform.rotation = Quaternion.Lerp (CameraHead.transform.rotation,new Quaternion(42,-90,0,1),Time.time*0.01f);
    //    //CameraHead.transform.rotation = new Quaternion(40, -60, 0,1);

    //    //bool rotatefinish = false;
    //    //if (rotatefinish==false)
    //    //{
    //    //    CameraHead.transform.eulerAngles = new Vector3(40, Mathf.LerpAngle(-90, -180, Time.time),0);//直接设置旋转角度

    //    //    if (CameraHead.transform.eulerAngles == new Vector3(CameraHead.transform.rotation.x, -180, CameraHead.transform.rotation.z))
    //    //    {
    //    //        rotatefinish = true;
    //    //        print(rotatefinish);
    //    //    }
    //    //}
        
    //    //if (rotatefinish)
    //    //{
    //    //    CameraHead.transform.eulerAngles = new Vector3(40, Mathf.LerpAngle(-180, -90, Time.time), 0);
    //    //}
        
    //}
    
}

