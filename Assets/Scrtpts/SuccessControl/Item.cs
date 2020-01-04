using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public bool isCard = false;
    public FixButtenED fixButtenED;
    public GameObject TriggerButton;
    bool canDestoryCard;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isCard)
        {
            transform.Rotate(0, 1, 0);
            if (canDestoryCard==true)
            {
                if (fixButtenED.Pressed)
                {
                    PhoneThirdPersonContaol.isGetKey = true;
                    Destroy(gameObject);
                }
            }
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        TriggerButton.SetActive(true);
        if (isCard==true&&other.tag=="Player")
        {
            canDestoryCard = true;
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag=="Player")
        {
            TriggerButton.SetActive(false);
        }
        
    }
}
