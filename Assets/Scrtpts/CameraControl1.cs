using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl1 : MonoBehaviour
{
    float mh;
    float mv;
    public Transform targetpos;
    public Transform playerpos;
    public float speed;
    public VariableJoystick joy;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //mh += Input.GetAxis("Mouse X") * speed * Time.deltaTime;
        //mv += Input.GetAxis("Mouse Y") * speed * Time.deltaTime;
        mh += joy.Horizontal * speed;
        mv -= joy.Vertical * speed;

        transform.LookAt(targetpos);
        targetpos.rotation = Quaternion.Euler(new Vector3(mv, 0, 0));
        playerpos.rotation = Quaternion.Euler(new Vector3(0, mh, 0));

    }
}
