using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tag : MonoBehaviour
{
    public const string Player = "Player";//const和static的作用相近，都是可以直接透过类名调用的固态变量，但是const无法修改变量数值，static可以
    public const string Enemy = "Enemy";//标签可以直接访问，这样以确保不会打错
    public const string AlarmBorad="AlarmBorad";
    public const string AlarmArea = "AlarmArea";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
