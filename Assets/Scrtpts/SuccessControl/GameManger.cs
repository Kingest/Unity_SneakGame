using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    private PlayerHPControl playerHPControl;
    public Image gameOver;
    private float gameOverImageA;
    public Text cai;
    public Text haohuo;
    private GameObject exiteLevator;
    public Button reLoadScene;
    public Button quitGame;
    public GameObject gameover;
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
        playerHPControl = GameObject.FindGameObjectWithTag(Tag.Player).GetComponent<PlayerHPControl>();
        exiteLevator = GameObject.FindGameObjectWithTag("Exit");
        reLoadScene.onClick.AddListener(ReLoadScene);
        quitGame.onClick.AddListener(GameQuit);
        ExitEleveter.playerIsExit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHPControl.PlayerHP<=0)
        {
            GameOver();
        }
        if (ExitEleveter.playerIsExit==true)
        {
            GameWin();
        }
        
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
                    gb[i].GetComponent<AudioSource>().volume = 0.1f;
                    gb[i].GetComponent<AudioSource>().Play();
                    //audioSurceMy.clip = bgmClip[0];
                    if (bgmClip[0]!=null)
                    {
                        audioSurceMy.Stop();
                    }
                    
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
   
    public void SeePlayer(Transform player)//用于统一玩家的位置信息，摄像头也好，机械人也好，看到了玩家之后就会汇报信息
    {
        isPlayAlarmAudio = true;
        lastPlayerPos = player.position;
    }
    public void GameOver()
    {
        gameOver.gameObject.SetActive(true);
        gameOver.color = new Color(0, 0, 0, Mathf.Lerp(gameOver.color.a, 1, Time.deltaTime));//务必在第一个位置上填你自己想改的变量，不能写0,1不然结果相同
        cai.color = new Color(cai.color.r, cai.color.g, cai.color.b, Mathf.Lerp(cai.color.a, 1, Time.deltaTime));
    }
    public void GameWin()
    {
        exiteLevator.transform.Translate(new Vector3(0, 1, 0)*Time.deltaTime);
        gameOver.gameObject.SetActive(true);
        gameOver.color = new Color(0, 0, 0, Mathf.Lerp(gameOver.color.a, 1, Time.deltaTime));
        haohuo.color = new Color(cai.color.r, cai.color.g, cai.color.b, Mathf.Lerp(haohuo.color.a, 1, Time.deltaTime));
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
    public void ReLoadScene()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void GameQuit()
    {
        Application.Quit();
    }
}

