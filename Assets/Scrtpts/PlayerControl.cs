using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControl : MonoBehaviour
{
    //private NavMeshAgent nav;
    // Start is called before the first frame update
    private float h;
    private float v;
    public float speed = 10;
    
    public float anispeed = 1;
    public float anglespeed;

    public Animator Anir;
    void Start()
    {
        //nav = GetComponent<NavMeshAgent>();
        //Anir = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");//谨慎，务必写在此处，因为这个值是实时获取的
        v = Input.GetAxis("Vertical");

        ////通过导航网格来进行移动
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit;
        //    Physics.Raycast(ray, out hit);
        //    nav.SetDestination(hit.point);
        //    GetComponent<Animator>().SetFloat("Speed", nav.speed);
        //}
        //transform.Translate(new Vector3(-v * speed * Time.deltaTime, 0, h * speed * Time.deltaTime));
        //Anir.SetFloat("Speed", Mathf.Abs(h - v) * 10);


        //print(h + "                  " + v);
        if (Mathf.Abs(v) > 0.1 || Mathf.Abs(h) > 0.1)
        {
            anispeed = Mathf.Lerp(Anir.GetFloat("Speed"), 10, speed * Time.time);
            Anir.SetFloat("Speed", anispeed);
            Vector3 TargetV3 = new Vector3(v, 0, h);
            Vector3 CurrentV3 = transform.forward;
            float angles = Vector3.Angle(CurrentV3, TargetV3);
            transform.Rotate(Vector3.up * angles * Time.deltaTime * anglespeed);

            //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(TargetV3, Vector3.up), speed * Time.deltaTime);
            //transform.Translate(new Vector3(-v, 0, h) * speed * Time.deltaTime);


        }
        else
        {
            Anir.SetFloat("Speed", 0);
        }


    }
}
