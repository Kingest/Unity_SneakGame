using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimatorControl : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent navMeshAgent;
    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (navMeshAgent.desiredVelocity==Vector3.zero)//敌不动
        {
            animator.SetFloat("Speed",0);
            animator.SetFloat("TurnAng", 0);
        }
        else
        {

            float angle = Vector3.Angle(transform.forward, navMeshAgent.desiredVelocity);
            float angleRad = 0f;
            if (angle>90)//必须要先改变方向才能走路
            {
                animator.SetFloat("Speed", 0);//所以先停止了
            }
            else
            {
                angleRad = angle * Mathf.Deg2Rad;//弧度的转换，角度转换成弧度
                Vector3 project= Vector3.Project(navMeshAgent.desiredVelocity, transform.forward);
                animator.SetFloat("Speed", project.magnitude);
                
            }
            Vector3 cross = Vector3.Cross(transform.forward, navMeshAgent.desiredVelocity);//左手定则，有详细的测试图
            if (cross.y<0)//如果为复数则取反
            {
                angleRad = -angleRad;
            }
            animator.SetFloat("TurnAng", angleRad);//把弧度设置回动画状态机里的弧度
        }
    }
}
