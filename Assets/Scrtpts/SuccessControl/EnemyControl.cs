using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControl : MonoBehaviour
{
    public bool isPlayerInside = false;//是否看到玩家
    public float enemySeeAngle = 130;//视野角度
    // Start is called before the first frame update
    private NavMeshAgent navAgient;//导航组件
    private Animator playerAnimator;
    private SphereCollider sphereCollider;//用于检测是否能听到玩家的组件
    public Vector3 alertPosition;
    public Vector3 perLastPlayerPosition;
    private float ang;
    public static bool seePlayer = false;
    private void Awake()
    {
        navAgient = GetComponent<NavMeshAgent>();
        sphereCollider = GetComponent<SphereCollider>();
        alertPosition = Vector3.zero;
       
    }
    private void Start()
    {
        perLastPlayerPosition = GameManger._gameManager.lastPlayerPos;//设定最后看到玩家的地点，默认为000
    }
    private void Update()
    {
         
        if (GameManger._gameManager.lastPlayerPos != alertPosition)//如果最后看到玩家的地点发生变动，那么就是玩家触发了警报or被看到了
        {
            alertPosition = GameManger._gameManager.lastPlayerPos;
            perLastPlayerPosition = GameManger._gameManager.lastPlayerPos;
            
        }
       
    }
    private void OnTriggerStay(Collider other)
    {
       
        if (other.tag==Tag.Player)
        {
            //视觉检测
            Vector3 forward = transform.forward;//得到敌人正前方的那条线
            Vector3 playerPos = other.transform.position - transform.position;//得到玩家减去敌人的那条线
            /*float allangle*/ ang= Vector3.Angle(forward, playerPos);//得到这两条线的夹角
            RaycastHit hit;
            bool rayCasthit= Physics.Raycast(transform.position + Vector3.up, other.transform.position - transform.position, out hit);
            if (ang<enemySeeAngle*0.5&&hit.collider.tag==Tag.Player)//夹角小于视野的2分之1角度，就证明被康到了
            {
                isPlayerInside = true;
                alertPosition = other.transform.position;
                GameManger._gameManager.SeePlayer(other.transform);
                
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
                    Vector3[] waypoints = new Vector3[path.corners.Length+2];//新建一个vector3的数组用于储存路径点
                    waypoints[0] = transform.position;//开始的起点
                    waypoints[waypoints.Length - 1] = other.transform.position;//lenth是数组总数，0,1 两个元素的length为2，所以此处最大值为3-1=2，数组元素为0,1,2
                   
                    for (int i = 0; i < path.corners.Length; i++)
                    {
                        waypoints[i + 1] = path.corners[i];//除了开始的那个点和结束的那个点，中间的总数
                        //print(i);
                    }
                    float length = 0;
                    for (int i = 1; i < waypoints.Length; i++)
                    {
                        length += (waypoints[i] - waypoints[i - 1]).magnitude;//数次的+=，数次循环让路径点的距离都加起来
                    }
                    if (length<sphereCollider.radius)//将加起来的路径点距离和球形碰撞机进行比较
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
