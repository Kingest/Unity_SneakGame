using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveControl : MonoBehaviour//自动巡逻
{
    public Transform[] transformGroup;//4个地点
    private NavMeshAgent navAgent;
    private int index = 0;
    public float waitTIme = 3;//在每个点等待的时间
    private float timer = 0;//计时器，累计时间
    private void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.destination = transformGroup[0].position;
        //navAgent.updatePosition = false;
        //navAgent.updateRotation = false;
    }
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        Patrol();
    }
    void Patrol()//设置了4个空物体作为巡逻点，用NavMeshAgient让玩家巡逻
    {
        
        if (Vector3.Distance(transform.position,transformGroup[index].position)<0.1f)
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
}
