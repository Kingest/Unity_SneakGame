using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControl : MonoBehaviour
{
    public bool isPlayerInside = false;//是否看到玩家
    public float enemySeeAngle = 130;//视野角度
    // Start is called before the first frame update
    private NavMeshAgent navAgient;
    private Animator playerAnimator;
    private SphereCollider sphereCollider;
    public Vector3 alertPosition;
    float ang;
    private void Awake()
    {
        navAgient = GetComponent<NavMeshAgent>();
        sphereCollider = GetComponent<SphereCollider>();
        alertPosition = Vector3.zero;
    }
    private void Update()
    {
        print(ang);
    }
    private void OnTriggerStay(Collider other)
    {

        if (other.tag==Tag.Player)
        {
            //视觉检测
            Vector3 forward = transform.forward;//得到敌人正前方的那条线
            Vector3 playerPos = other.transform.position - transform.position;//得到玩家减去敌人的那条线
            /*float allangle*/ ang= Vector3.Angle(forward, playerPos);//得到这两条线的夹角
            if (ang<enemySeeAngle*0.5)//夹角小于视野的2分之1角度，就证明被康到了
            {
                isPlayerInside = true;
                alertPosition = other.transform.position;
            }
            else
            {
                isPlayerInside = false;
            }
            playerAnimator = other.gameObject.GetComponent<Animator>();
            //以下是听觉检测
            if (playerAnimator.GetFloat("Forward")!=0f)
            {
                NavMeshPath path = new NavMeshPath();
                if (navAgient.CalculatePath(other.transform.position, path)) 
                {
                    Vector3[] waypoints = new Vector3[path.corners.Length+2];
                    waypoints[0] = transform.position;
                    waypoints[waypoints.Length - 1] = other.transform.position;
                    for (int i = 0; i < path.corners.Length; i++)
                    {
                        waypoints[i + 1] = path.corners[i];
                    }
                    float length = 0;
                    for (int i = 0; i < waypoints.Length; i++)
                    {
                        length += (waypoints[i] - waypoints[i - 1]).magnitude;
                    }
                    if (length<sphereCollider.radius)
                    {
                       alertPosition=other.transform.position;
                    }
                }
                
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag==Tag.Player)
        {
            isPlayerInside = false;
        }
    }
}
