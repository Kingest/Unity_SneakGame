using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmLight : MonoBehaviour
{
    public Light alarmLight;
    
    public float value = 1;
    public float targetintensity = 0;
    public float maxintensity = 1;
    public float minintensity = 0;
    public bool isalarm = false;
    public static AlarmLight _Alarmlight;
    // Start is called before the first frame update
    private void Awake()
    {
        _Alarmlight = this;
        
    }
    void Start()
    {
        targetintensity = maxintensity;
    }

    // Update is called once per frame
    void Update()
    {
        //alarmLight.intensity = Mathf.PingPong(Time.time*value, 1);//花里胡哨的呢，一行代码写完的警报灯非得这么多
        //alarmLight.intensity = Mathf.PingPong(1 + Time.time, 2);//这样限制值的范围就可以从1开始到2结束
        
        if (isalarm)
        {
            alarmLight.intensity = Mathf.Lerp(alarmLight.intensity, targetintensity, (value+=Time.deltaTime)*0.01f);
            if (Mathf.Abs(alarmLight.intensity - targetintensity) < 0.01f)
            {
                if (targetintensity == maxintensity)
                {
                    targetintensity = minintensity;
                }
                else if (targetintensity == minintensity)
                {
                    targetintensity = maxintensity;
                }

            }
        }
        else
        { //alarmLight.intensity = 0;
            alarmLight.intensity = Mathf.Lerp(alarmLight.intensity, minintensity, (value += Time.deltaTime) * 0.01f);
        }
        
       

    }
}
