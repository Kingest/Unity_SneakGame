using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHPControl : MonoBehaviour
{
    public float PlayerHP = 100;
    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerHP <= 0)
        {
            animator.SetBool("Dead", true);
        }
    }
    public void Damange(float damage)
    {
        PlayerHP -= damage;
        
    }
}
