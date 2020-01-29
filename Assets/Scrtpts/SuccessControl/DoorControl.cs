using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    private Animator anir;
    private Animator doorExitAnir;
    private AudioSource audioSource;
    public bool isExitDoor = false;
   
    // Start is called before the first frame update
    void Start()
    {
        if (isExitDoor==false)
        {
            anir = GetComponent<Animator>();
            
        }
        else
        {
            doorExitAnir = GetComponent<Animator>();
            audioSource = GetComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag==Tag.Player||other.tag==Tag.Enemy)
        {
            if (isExitDoor==false)
            {
                anir.SetBool("Isopen", true);
            }
            
            if (PhoneThirdPersonContaol.isGetKey==true&&isExitDoor==true)
            {
                doorExitAnir.Play("DoorExit");
                doorExitAnir.speed = 1f;
                
            }
            
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player"|| other.tag==Tag.Enemy)
        {
            if (isExitDoor==false)
            {
                anir.SetBool("Isopen", false);
            }
            
            if (PhoneThirdPersonContaol.isGetKey == true && isExitDoor == true)
            {
                doorExitAnir.Play("DoorClose");
            }
        }
    }
}
