using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayMaker;


public class RE_PlayerControl : MonoBehaviour//第三人称玩家的移动
{
    public float speed;
    public Animator Anir;
    public AudioSource audio;
    public VariableJoystick joy;

    public PlayMakerFSM PFsm;
    // Start is called before the first frame update
    void Start()
    {
        Anir = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //var v1 = PFsm.FsmVariables.GetFsmFloat("V1");
        //v1.Value = joy.Vertical;

        
        if (Anir.GetCurrentAnimatorStateInfo(0).IsName("Walk") || Anir.GetCurrentAnimatorStateInfo(0).IsName("Run"))//检测当前状态是否为走路
        {
            SoundPlay();
            print("Walk or Run");
        }
        else
        {
            audio.Stop();
        }
        //另一种脚步检测播放
        //if (Anir.GetFloat("Speed") > 0)
        //{
        //    Anir.SetFloat("Speed", speed);
        //}
        //else
        //{
        //    SoundStop();
        //}
        if (Mathf.Abs(joy.Horizontal) >0.1f)
        {
            AnimMove();
        }
        if (Mathf.Abs(joy.Horizontal) < 0.1f)
        {
            Anir.SetFloat("Speed", 0);
        }
       
    }
    private void PlayerMovement()//正常控制移动
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(h, 0, v) * speed * Time.deltaTime);

    }
    private void SoundPlay()
    {
        print("AudioPlay");
        if (!audio.isPlaying)//!的意思是取反，
        {
            audio.Play();
        }
        
    }
    private void SoundStop()
    {
        if (audio.isPlaying)
        {
            audio.Stop();
        }
        
    }
    private void AnimMove()
    {
        Anir.SetFloat("Speed", Mathf.Abs(joy.Horizontal)*speed);
    }
}
