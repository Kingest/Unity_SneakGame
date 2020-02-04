using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RERE_PlayerControl : MonoBehaviour
{
    /// <summary>
    /// 最简单的第三人称摄影机控制
    /// </summary>
    public float moux;
    public float mouy;
    public float rotateSpeed;
    public float xrotation;
    public Transform playerTransform;
    public Transform cameraTransform;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject()==false)
        {
            moux = Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime;
            mouy = Input.GetAxis("Mouse Y") * rotateSpeed * Time.deltaTime;
            playerTransform.Rotate(Vector3.up * moux);//此处v3.up是一个xyz的v3向量，x=0,y=1,z=0，如果不乘那么float无法变成v3向量
            xrotation += mouy;//注意此处务必在input mouseY 那里勾上翻转（Invert）
            xrotation = Mathf.Clamp(xrotation, -90, 60);
            cameraTransform.localRotation = Quaternion.Euler(xrotation, 0, 0);

        }
       
       
        
    }
}
