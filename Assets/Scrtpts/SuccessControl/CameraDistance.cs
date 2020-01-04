using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDistance : MonoBehaviour
{
    public float minDistance;
    public float maxDistance;
    public float smooth;
    private Vector3 dollyDir;
    public Vector3 dollyDirAdiusted;
    public float distance;
    public static bool isHit = false;
    // Start is called before the first frame update
    void Awak()
    {
        
        dollyDir = transform.position.normalized;
       
        distance = transform.localPosition.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        print(dollyDir);
        Vector3 desiredCameraPos = transform.position;/*transform.parent.TransformPoint(dollyDir * maxDistance);*/
        RaycastHit hit;
        if (Physics.Raycast(desiredCameraPos,transform.parent.position,out hit))
        {
            isHit = true;
            print(isHit);
            distance = Mathf.Clamp(hit.distance*0.9f, minDistance, maxDistance);
        }
        else
        {
            distance = maxDistance;
        }
        transform.position = Vector3.Lerp(transform.position, dollyDir * distance, Time.deltaTime * smooth);
    }
}
