﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveControl : MonoBehaviour//自动巡逻
{
    public Transform[] transformGroup;//目标地点
    private NavMeshAgent navAgent;
    private int index = 0;
    public float waitTIme = 3;//在每个点等待的时间
    private float timer = 0;//计时器，累计时间
    private EnemyControl enemyControl;
    private float t = 0;
    private void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.destination = transformGroup[0].position;
        enemyControl = GetComponent<EnemyControl>();
        //navAgent.updatePosition = false;
        //navAgent.updateRotation = false;
    }
    
   

    // Update is called once per frame
    void Update()
    {
        if (enemyControl.isPlayerInside)
        {
            navAgent.isStopped = false;
            //在视线范围内，可以射击了
            print("shoot");

        }
        else if (enemyControl.perLastPlayerPosition!=Vector3.zero)
        {
            navAgent.speed = 5f;
            navAgent.isStopped = false;//让导航网格不停止
            Trace();
        }
        else
        {
            Patrol();
        }
       
        
    }
    void Patrol()//设置了4个空物体作为巡逻点，用NavMeshAgient让玩家巡逻
    {

        if (Vector3.Distance(transform.position, transformGroup[index].position) < 0.1f)
        {

            navAgent.isStopped = true;
            timer += Time.deltaTime;
            if (timer < waitTIme)
                return;


            //WDNMD，我傻了，在这里瞎鸡儿操作什么呢，下面一行庚号求余就解决的事情我在这里写个鸡儿的if
            //if (index == 3 && Vector3.Distance(transform.position, transformGroup[transformGroup.Length].position) < 0.1f)
            //{

            //    index = 0;
            //    navAgent.SetDestination(transformGroup[index].position);
            //    return;
            //}
            index++;
            index %= transformGroup.Length;//大于4的都会变成0123
            timer = 0;
            navAgent.isStopped = false;
            navAgent.SetDestination(transformGroup[index].position);
            //navAgent.updatePosition = false;
            //navAgent.updateRotation = false;
        }

    }
    void Trace()//追踪玩家
    {
        navAgent.SetDestination(enemyControl.perLastPlayerPosition);
        
        
        if (navAgent.remainingDistance<2f)
        {

            t += Time.deltaTime;
            if (t>5&&enemyControl.isPlayerInside==false)
            {
                
                print("Timer is finish");
                navAgent.destination = transformGroup[index].position;
                enemyControl.perLastPlayerPosition = Vector3.zero;
                GameManger._gameManager.isPlayAlarmAudio = false;
            }
        }
    }
    void Shoot()//射击玩家
    {

    }
}
