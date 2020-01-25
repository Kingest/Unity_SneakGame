using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float timer = 0;
    
    void Update()
    {
        timer = Mathf.PingPong(Time.time, 4);
        if (timer>2)
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<AudioSource>().Stop();
            GetComponent<Collider>().enabled = false;
        }
        else
        {
            GetComponent<MeshRenderer>().enabled = true;
            GetComponent<AudioSource>().Play();
            GetComponent<Collider>().enabled = true;
        }
    }
    private void OnTriggerEnter(Collider cld)
    {
        if (cld.tag==Tag.Player)
        {
            GameManger._gameManager.isPlayAlarmAudio = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag==Tag.Player)
        {
            GameManger._gameManager.SeePlayer(other.transform);
        }
    }

}
