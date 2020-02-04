using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitEleveter : MonoBehaviour
{
    private BoxCollider boxcll;
    private SphereCollider sphecll;
    public static bool playerIsExit;
    // Start is called before the first frame update
    void Start()
    {
        boxcll = GetComponent<BoxCollider>();
        sphecll = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag==Tag.Player)
        {
            boxcll.enabled = true;
            playerIsExit = true;
        }
    }
}
